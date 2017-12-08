using QSHP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace QSHP.UI
{
    public partial class AlignFormBase : BaseForm
    {
        public event EventHandler<CutChannel> ChangeCutChannelHander;
        Color btBackColor = SystemColors.Control;
        PointF p1;
        PointF p2;
        bool firstPoint = true;
        CutGroup group;
        bool applayTAdj = true;
        bool applayChannelChange = true;
        int ch1Index = 0;
        int ch2Index = 1;
        Color bkColor = Color.Ivory;
        Color stColor = Color.HotPink;
        Color okColor = Color.GreenYellow;
        List<CutChannel> chs = new List<CutChannel>();

        public string CCDName
        {
            get
            {
                return Globals.HighCCD ? "高倍" : "低倍";
            }
        }
        public CaptureViewEx CaptureView
        {
            get
            {
                return cap;
            }
        }
        public CutGroup Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
                if (group != null)
                {
                    chs.Clear();
                    foreach (var item in group.ChipCHs)
                    {
                        if (item.Enable)
                        {
                            chs.Add(item);
                        }
                    }
                    chs = chs.OrderBy(c => c.TRoatePos).ThenBy(c => c.Chip.Index).ThenBy(c => c.Index).ToList();
                    ch1Index = 0;
                    ch2Index = 1;
                    if (chs.Count < 1)
                    {
                        chs.Add(new CutChannel(30));
                    }
                    SetCurrentChannel();
                }
            }
        }
        [Browsable(false)]
        public CutChannel CH1
        {
            get
            {
                if (chs.Count == 0)
                {
                    chs.Add(new CutChannel(30));
                }
                return chs[ch1Index];
            }
        }
        [Browsable(false)]
        public CutChannel CH2
        {
            get
            {
                if (chs.Count > ch2Index)
                {
                    CaptureView.XStepDefault = true;
                    return chs[ch2Index];
                }
                else
                {
                    CaptureView.XStepDefault = false;
                    return chs[ch1Index];
                }
            }
        }

        public bool ApplayTAdj
        {
            get
            {
                return applayTAdj;
            }

            set
            {
                applayTAdj = value;
            }
        }

        public int ChannlIndex
        {
            get
            {
                return ch1Index;
            }
            set
            {
                if (chs.Count > 0)
                {
                    if (value >= chs.Count - 1)
                    {
                        ch1Index = chs.Count - 1;
                        ch2Index = 0;
                    }
                    else if (value >= 0)
                    {
                        ch1Index = value;
                        ch2Index = ch1Index + 1;
                    }
                    else
                    {
                        ch1Index = 0;
                        ch2Index = 1;
                    }
                }
            }
        }

        public List<CutChannel> CHs
        {
            get
            {
                return chs;
            }

            set
            {
                chs = value;
            }
        }

        public bool ApplayChannelChange
        {
            get
            {
                return applayChannelChange;
            }

            set
            {
                applayChannelChange = value;
            }
        }

        public AlignFormBase()
        {
            InitializeComponent();
        }

        public void ChangeCurrentCh(bool inc = true)
        {
            if (ApplayChannelChange && Group != null)
            {
                if (inc)
                {
                    ChannlIndex++;
                }
                else
                {
                    ChannlIndex--;
                }
                SetCurrentChannel();
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0036);
            }
        }

        public void SetCurrentChannel()
        {
            cap.XGuidesWidth = CH1.KnieffLineWidth;
            CaptureView.YStep = CH1.IndexStep;
            CaptureView.XStep = CH2.IndexStep;
            if (applayTAdj)
            {
                if (CH1.TAligned)
                {
                    this.UnderBar.BtList[4].BackColor = okColor;
                    this.UnderBar.BtList[4].LED = true;
                }
                else
                {
                    this.UnderBar.BtList[4].BackColor = bkColor;
                    this.UnderBar.BtList[4].LED = false;
                }
            }
            if (ChangeCutChannelHander != null)
            {
                ChangeCutChannelHander(this, CH1);
            }
        }

        public override bool FormLoadReady()
        {
            if (ApplayTAdj)
            {
                this.BT4Content = "T 轴调整";
                btBackColor = this.UnderBar.BtList[4].BackColor;
                this.BT4Click += new System.EventHandler(this.TadjManager_BTClick);
                this.UnderBar.BtList[4].UsedLed = true;
                this.UnderBar.BtList[4].LED = false;
                this.UnderBar.BtList[4].BackColor = bkColor;
                this.Group = Globals.Group;
                firstPoint = true;
            }
            if (Globals.AutoFource)//自动对焦操作
            {
                this.BT9Content = "自动对焦";
                this.BT9Click += AutoFource_BTClick;
            }
            Globals.HighCCD = true;//设置默认为高倍
            cap.StartCapture();
            return base.FormLoadReady();
        }

        private void AutoFource_BTClick(object sender, EventArgs e)//自动对焦
        {
            //throw new NotImplementedException();
        }
        private void TadjManager_BTClick(object sender, EventArgs e)
        {
            if (!Globals.IsInit)
            {
                Common.ReportCmdKeyProgress(CmdKey.A0005);
                return;
            }
            if (Common.X_Axis.IsInPosition && Common.Y_Axis.IsInPosition && Common.T_Axis.IsInPosition)
            {
                if (firstPoint)//取第一个点
                {
                    firstPoint = false;
                    p1 = Globals.AxisPoint;
                    this.UnderBar.BtList[4].BackColor = stColor;
                    this.UnderBar.BtList[4].LED = false;
                    CH1.TAligned = false;
                    float x = p1.X - Globals.ViewCenter.X;
                    Common.X_Axis.JogInc(Globals.MacData.TAdjSpeed, Globals.MacData.TAdjAcc, -2 * x);//X轴移动 显示中心的镜像
                    Common.ReportCmdKeyProgress(CmdKey.A0002);
                }
                else//取第二个点 
                {
                    p2 = Globals.AxisPoint;
                    if (Math.Abs(p1.X - p2.X) < 10)
                    {
                        Common.ReportCmdKeyProgress(CmdKey.A0003);
                        return;
                    }
                    this.UnderBar.BtList[4].BackColor = okColor;
                    this.UnderBar.BtList[4].LED = true;
                    CH1.TAligned = true;//进行T轴调整
                    float angle = 0;
                    Common.AlignT(p1, p2, Globals.ViewCenter, out angle);//T轴进行旋转 X  Y 移动到旋转 中心 
                    Common.ReportCmdKeyProgress(CmdKey.A0004);
                    firstPoint = true;
                }
            }
            else
            {
                firstPoint = true;
                Common.ReportCmdKeyProgress(CmdKey.S0014);
            }
        }
        public override bool FormUnloadReady()
        {
            if (ApplayTAdj)
            {
                this.BT4Click -= new System.EventHandler(this.TadjManager_BTClick);
                this.UnderBar.BtList[4].UsedLed = false;
                this.UnderBar.BtList[4].BackColor = btBackColor;
            }
            cap.StopCapture();
            return base.FormUnloadReady();
        }

        private void AlignFormBase_Load(object sender, EventArgs e)
        {
            CaptureView.IncChButton.Click += delegate { ChangeCurrentCh(true); };
            CaptureView.DecChButton.Click += delegate { ChangeCurrentCh(false); };
            
        }

    }
}
