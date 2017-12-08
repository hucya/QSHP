
using System;
using System.IO;
using System.Linq;
namespace QSHP.UI.Manual
{
    public partial class CutAlignManager : AlignFormBase
    {
        bool load = false;
        public CutAlignManager()
        {
            InitializeComponent();
        }
        private void CutAlignManager_Load(object sender, EventArgs e)
        {
            if (Globals.IsInit)
            {
                Common.X_Axis.AxisJogAbsWork(CH1.AlignPoint.X);
                Common.Y_Axis.AxisJogAbsWork(CH1.AlignPoint.Y + Globals.KniefAdj);//划切位置+偏移位置
                Common.T_Axis.AxisJogAbsWork(CH1.AlignT);//T轴对准点
            }
            load = true;
            curChannel.Items.Clear();
            curChannel.Items.AddRange(CHs.ToArray());
            curChannel.SelectedIndex = 0;
            CaptureView.ChangeCaptureViewModeHander += CaptureView_ChangeCaptureViewModeHander;
            Common.ReportCmdKeyProgress(CmdKey.A0001);
        }

        private void CaptureView_ChangeCaptureViewModeHander(object sender, EventArgs e)
        {
            ccdMode.Text = CCDName;
        }

        public override bool FormLoadReady()
        {
            bool flag = base.FormLoadReady();
            if (load)
            {
                if (CHs.Contains(Globals.Channel))
                {
                    for (int i = 0; i < CHs.Count; i++)
                    {
                        if (CHs[i] == Globals.Channel)
                        {
                            curChannel.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            this.UnderBar.BtList[5].UsedLed = true;
            return flag;
        }

        public override bool FormUnloadReady()
        {
            this.UnderBar.BtList[5].UsedLed = false;
            return base.FormUnloadReady();
        }
        private void CutAlignManager_ConfirmClick(object sender, EventArgs e)   //确认
        {
            if (Common.X_Axis.IsInPosition && Common.Y_Axis.IsInPosition && Common.T_Axis.IsInPosition)
            {
                if (!Globals.HighCCD)
                {
                    Common.ReportCmdKeyProgress(CmdKey.A0012);
                    return;
                }
                if (CH1.TAligned)
                {
                    CH1.AlignPoint.X = Common.X_Axis.RealPos;
                    CH1.AlignPoint.Y = Common.Y_Axis.RealPos - Globals.KniefAdj;  //划切位置=对准位置减去刀痕偏移值
                    CH1.AlignT = Common.T_Axis.RealPos;
                    CH1.KnieffLineWidth = CaptureView.XGuidesWidth;
                    CH1.Aligned = true;
                    Common.ReportCmdKeyProgress(CmdKey.A0007);
                    if (CH2.Enable && !CH2.Aligned)//已经进行T轴调整 
                    {
                        ChangeCurrentCh(true);//对准下一通道
                    }
                    else
                    {
                        Common.ReportCmdKeyProgress(CmdKey.A0009);
                    }
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.A0008);
                }
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0014);
            }

        }

        private void CutAlignManager_NextClick(object sender, EventArgs e)  //取消
        {
            if (Group.Aligned)
            {
                Group.InitCutRunData();
                Common.ReportCmdKeyProgress(CmdKey.A0011);
                this.ParentForm.PushChildForm(new CutStatusManager(Group));
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.A0010);
            }
        }

        private void CutAlignManager_CancelClick(object sender, EventArgs e)
        {
            if (this.ParentForm != null)
            {
                Common.ReportCmdKeyProgress(CmdKey.A0006);
                this.ParentForm.PopToHomeScreen();
            }
        }

        private void CutAlignManager_ChangeCutChannelHander(object sender, Data.CutChannel e)
        {
            if (e != null)
            {
                curChannel.Text = e.Name;
                curStep.Text = e.IndexStep.ToString("0.###");
                curLines.Text = e.TotalLine.ToString();
                cutMode.Text = Group.CutMode.ToString();
                Common.T_Axis.AxisJogAbsWork(e.TRoatePos);
            }
        }

        private void CurChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChannlIndex = curChannel.SelectedIndex;
            SetCurrentChannel();
        }

        private void CutAlignManager_AutoUpdateEventHander(object sender, EventArgs e)
        {
            this.UnderBar.BtList[5].LED = Globals.PreCut;
        }

        private void ChangeCutPreCutEventHander(object sender, EventArgs e)
        {
            Globals.PreCut = !Globals.PreCut;
            if (Globals.PreCut)
            {
                Common.ReportCmdKeyProgress(CmdKey.P0126);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0127);
            }
        }
    }
}
