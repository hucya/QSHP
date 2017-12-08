using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.UI.Ctr;
using QSHP.HW;
using QSHP.HW.Video;
using System.Drawing.Imaging;
using System.IO;
using QSHP.UI.Bld;
using System.Diagnostics;
using QSHP.Com;
using System.Windows.Threading;

namespace QSHP.UI
{
    public partial class UnderBar : UserControl
    {
        private UnderStyle style = UnderStyle.Default;
        private MonitorEx moitor = null;
        private object locker = new object();
        private int cycTick = 0;
        public MonitorEx Moitor
        {
            get { return moitor; }
            set
            {
                if (moitor == null)
                {
                    moitor = value;
                }
            }
        }
        public UnderStyle Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
                underControl.SelectedIndex = (int)value;
            }
        }
        public List<ButtonEx> BtList = new List<ButtonEx>();

        public UnderBar()
        {
            InitializeComponent();
            BtList.Add(BT1);
            BtList.Add(BT2);
            BtList.Add(BT3);
            BtList.Add(BT4);
            BtList.Add(BT5);
            BtList.Add(BT6);
            BtList.Add(BT7);
            BtList.Add(BT8);
            BtList.Add(BT9);
            BtList.Add(BT10);
        }

        private void PT1_Click(object sender, EventArgs e)
        {
            if (underControl.SelectedIndex == 0)
            {
                if (style == UnderStyle.User)
                {
                    underControl.SelectedIndex = 2;
                }
                //else
                //{
                //    underControl.SelectedIndex = 3;
                //}
            }
            else
            {
                underControl.SelectedIndex = 0;
            }
        }

        private void PT3_Click(object sender, EventArgs e)
        {
            if (underControl.SelectedIndex == 1)
            {
                if (style == UnderStyle.User)
                {
                    underControl.SelectedIndex = 2;
                }
                //else
                //{
                //    underControl.SelectedIndex = 3;
                //}
            }
            else
            {
                underControl.SelectedIndex = 1;
                if (moitor != null)
                {
                    moitor.Style = MonitorStyle.Axis;
                }
            }
        }

        private void ST1_Click(object sender, EventArgs e)
        {
            Common.SetSystemWorkMode(SysFunState.SysInit);
            if (moitor != null)
            {
                moitor.Style = MonitorStyle.Axis;
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0029);
            }
        }

        private void ST2_Click(object sender, EventArgs e)
        {
            if (Globals.IDIE)
            {
                int s = 10000;
                if (Globals.Group != null)
                {
                    s = Globals.Group.SpdSpeed;
                }
                if (!Common.SPD.IsInit)
                {
                    Common.SPD.InitSpd();
                }
                if (Common.SPD.SpeedZore)
                {
                    Common.RunSpd(s);
                }
                else
                {
                    Common.SPD.StopSpd();
                }
                moitor.Style = MonitorStyle.SPD;
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0029);
            }
        }

        private void ST3_Click(object sender, EventArgs e)
        {
            if (Globals.IDIE)
            {
                Common.DO[DoDefine.WORK_AIR] = !ST3.LED;
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0029);
            }
        }

        private void ST4_Click(object sender, EventArgs e)
        {
            if (Globals.IDIE)
            {
                Common.DO[DoDefine.CUT_WATER] = !ST4.LED;
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0029);
            }
        }

        private void ST5_Click(object sender, EventArgs e)
        {
            if (Globals.IDIE)
            {
                Common.DO[DoDefine.TAB_AIR] = !ST5.LED;
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0029);
            }
        }

        private void ST8_Click(object sender, EventArgs e)
        {
            MainForm p = this.ParentForm as MainForm;
            if (p != null)
            {
                if (p.ChildForm is CutDataManager == false)
                {
                    CutDataManager p1 = new CutDataManager();
                    p1.FilePath = Globals.AppCfg.CutFileFullName;
                    p1.RePair = false;
                    p.PushChildForm(p1, false);
                }
            }
        }

        private void ST9_Click(object sender, EventArgs e)
        {
            MainForm p = this.ParentForm as MainForm;
            if (p != null)
            {
                if (p.ChildForm is BladeMessageFrom == false)
                {
                    p.PushChildForm(new BladeMessageFrom(), false);
                }
            }
        }

        private void PT2_Click(object sender, EventArgs e)
        {
            lock (locker)
            {
                string path = String.Format("{0}\\Screen", Application.StartupPath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (this.ParentForm != null)
                {
                    using (Bitmap bit = new Bitmap(this.ParentForm.Width, this.ParentForm.Height))
                    {
                        this.ParentForm.DrawToBitmap(bit, this.ParentForm.ClientRectangle);
                        bit.Save(String.Format("{0}\\{1}.Png", path, DateTime.Now.ToString("yyyyMMddHHmmss")), ImageFormat.Png);
                    }
                };
                //using (Bitmap bit = SrceenCaptureProvider.GetInstance().GetCaptureFrame())
                //{
                //    if (bit == null)
                //        return;
                //    bit.Save(String.Format("{0}\\{1}.Png", path, DateTime.Now.ToString("yyyyMMddHHmmss")), ImageFormat.Png);
                //}
            }

        }

        private void ST6_Click(object sender, EventArgs e)
        {
            MainForm p = this.ParentForm as MainForm;
            if (p != null)
            {
                if (p.ChildForm is BladeTestHeightManager == false)
                {
                    if (Globals.NoTouchTest)
                    {
                        p.PushChildForm(new BladeTestHeightManager(Globals.TabData.ToolBarCsMode ? 0 : 1), false);//接触式测高/非接触测高
                    }
                    else
                    {
                        p.PushChildForm(new BladeTestHeightManager(0), false);//接触式测高/非接触测高
                    }
                }
            }
        }

        private void PT4_Click(object sender, EventArgs e)
        {
            //Process p = new Process();
            //p.EnableRaisingEvents = true;

            //p.StartInfo.CreateNoWindow = true;
            //p.StartInfo.ErrorDialogParentHandle = tabPage1.Handle;
            //p.StartInfo.FileName = Application.StartupPath+@"\Tool\osk.exe";
            //p.Start();
        }
        public void AutoUpate(int cycTime = 10)
        {
            if (!Globals.Load)
                return;
            switch (underControl.SelectedIndex)
            {
                case 0:
                    {
                        if (cycTick++ > cycTime)
                        {
                            cycTick = 0;
                            if (underAxis1.Enabled != Globals.IDIE)
                            {
                                underAxis1.Enabled = Globals.IDIE;
                            }
                            if (ST1.LED != Globals.IsInit)
                            {
                                ST1.LED = Globals.IsInit;
                            }
                            if (Common.SPD != null && Common.SPD.IsInit)
                            {
                                bool flag = !Common.SPD.SpeedZore;//当前运转状态
                                if (ST2.LED != flag)
                                {
                                    ST2.LED = flag;
                                }
                            }
                            else
                            {
                                ST2.LED = false;
                            }
                            if (Common.DO.Enabled)
                            {
                                uint output = Common.DO.Status;
                                if (ST4.LED != output.Bit(Common.DO.IOList[DoDefine.CUT_WATER]))
                                {
                                    ST4.LED = output.Bit(Common.DO.IOList[DoDefine.CUT_WATER]);
                                }
                                if (ST3.LED != output.Bit(Common.DO.IOList[DoDefine.WORK_AIR]))//吸台气压
                                {
                                    ST3.LED = output.Bit(Common.DO.IOList[DoDefine.WORK_AIR]);
                                }
                                if (ST5.LED != output.Bit(Common.DO.IOList[DoDefine.TAB_AIR]))//吸台气压
                                {
                                    ST5.LED = output.Bit(Common.DO.IOList[DoDefine.TAB_AIR]);
                                }
                            }
                            else
                            {
                                ST3.LED = false;
                                ST4.LED = false;
                            }
                            if (ST6.LED != Globals.TestedHeight)
                            {
                                ST6.LED = Globals.TestedHeight;
                            }
                        }
                    }
                    break;
                case 1:
                    {
                        underAxis1.AutoUpdata();
                    }break;
                default:
                    break;
            }
        }
    }
    public enum UnderStyle
    {
        Default = 0,
        Main = 0,
        Axis = 1,
        User = 2,
        None = 3
    }
}
