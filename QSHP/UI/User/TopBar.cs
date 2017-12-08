using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;
using QSHP.HW;
using QSHP.Com;
using System.Threading;

namespace QSHP.UI
{
    public partial class TopBar : UserControl
    {
        public event EventHandler SensorClick;
        List<CmdValue> CmdList = new List<CmdValue>();
        Stack<CmdKey> cmdStack = new Stack<CmdKey>();

        int tick = 0;
        int logTick = 0;
        int logIndex = 0;
        int cycTick = 0;

        public TopBar()
        {
            InitializeComponent();
            Common.ProgressSpdEventChanged += (int cmd,float value)=>
            {
                this.BeginInvoke((Action<int, float>)ProcessSpdProgress, cmd, value);
            };
        }


        private void ProcessSpdProgress(int cmd, float value)
        {
            switch (cmd)
            {
                case ProcessCmd.SpdWaitCmd:
                    {
                        if (!spdRrogressBar.Visible)
                        {
                            spdRrogressBar.Visible = true;
                        }
                        else
                        {
                            spdRrogressBar.Value = (int)value;
                        }
                    }
                    break;
                case ProcessCmd.SpdWaitReportCmd:
                    {
                        spdRrogressBar.Value = (int)value;
                    }
                    break;
                case ProcessCmd.SpdWaitReadyCmd:
                    {
                        spdRrogressBar.Value = (int)value;
                        spdRrogressBar.Visible = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Common_ProgressWorkingChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > ProcessCmd.SpdCmd)
            {
                switch (e.ProgressPercentage)
                {
                    case ProcessCmd.SpdWaitCmd:
                        {
                            if (!spdRrogressBar.Visible)
                            {
                                spdRrogressBar.Visible = true;
                            }
                            else
                            {
                                spdRrogressBar.Value = 0;
                            }
                        }
                        break;
                    case ProcessCmd.SpdWaitReportCmd:
                        {
                            spdRrogressBar.Value = int.Parse(e.UserState.ToString());
                        }
                        break;
                    case ProcessCmd.SpdWaitReadyCmd:
                        {
                            spdRrogressBar.Value = 100;
                            Thread.Sleep(500);
                            spdRrogressBar.Visible = false;
                        }
                        break;
                    default:
                        break;
                }
            }

        }

        public void AutoUpdate(int cyctime = 10)
        {
            if (cycTick-- < 0)
            {
                cycTick = cyctime;
                timeShow.Text = DateTime.Now.ToString();
                if (Common.SPD != null && Common.SPD.ErrCode == 0)
                {
                    spdStatus.BackColor = Common.SPD.SpeedZore ? Color.Turquoise : Color.Yellow;
                    tick = 0;
                }
                else
                {
                    tick++;
                    spdStatus.BackColor = tick % 2 == 0 ? Color.Red : SystemColors.Control;
                }
                if (CmdList.Count > 1)
                {
                    if (++logTick % 6 == 0)
                    {
                        logTick = 0;
                        SetSystemMessage(CmdList[logIndex++], false);
                        if (logIndex >= CmdList.Count)
                        {
                            logIndex = 0;
                        }
                    }
                }
            }
        }

        public bool SetChildFormInformation(string formInfo = "主界面")
        {
            if (string.IsNullOrWhiteSpace(formInfo))
            {
                label9.Text = "主界面";
            }
            else
            {
                label9.Text = formInfo;
            }
            return true;
        }

        public bool SetFormIndex(int parentIndex = 0, int subIndex = 0, int index = 0)
        {
            indexLable.Text = string.Format("({0},{1},{2})", parentIndex, subIndex, index);
            return true;
        }

        public bool SetSystemMessage(CmdValue v, bool push = true)
        {
            lock (indexLable)
            {
                switch (v.Leave)
                {
                    case CmdLeave.Debug:
                    case CmdLeave.Info:
                        {
                            SetBackColor(Color.Yellow, Color.Green);
                        }
                        break;
                    case CmdLeave.Warn:
                        {
                            SetBackColor(Color.Orange, Color.WhiteSmoke);
                        }
                        break;
                    case CmdLeave.Error:
                        {
                            if (push)
                            {
                                if (!CmdList.Contains(v))
                                {
                                    CmdList.Add(v);
                                    logIndex = CmdList.Count - 1;
                                    if (Globals.ApplySpeech)
                                    {
                                        Globals.Speech.SpeakAsync(v.Description);
                                    }
                                }
                            }
                            SetBackColor(Color.OrangeRed, Color.Yellow);
                        }
                        break;
                    case CmdLeave.Fault:
                        {
                            if (push)
                            {
                                if (!CmdList.Contains(v))
                                {
                                    CmdList.Add(v);
                                    logIndex = CmdList.Count - 1;
                                    if (Globals.ApplySpeech)
                                    {
                                        Globals.Speech.SpeakAsync(v.Description);
                                    }
                                }
                            }
                            SetBackColor(Color.Red, Color.White);
                        }
                        break;
                    default:
                        break;
                }
                logNum.Text = v.Key.ToString();
                logShow.Text = v.Description;
                return true;
            }

        }
        private void SetBackColor(Color c, Color f)
        {
            if (logShow.BackColor != c)
            {
                logNum.BackColor = c;
                logShow.BackColor = c;
                logShow.ForeColor = f;
            }
        }
        private void SensorBt_Click(object sender, EventArgs e)
        {
            if (SensorClick != null)
            {
                SensorClick(sender, e);
            }
        }

        private void AlarmBt_Click(object sender, EventArgs e)
        {
            CmdList.Clear();
            SetBackColor(SystemColors.Info, SystemColors.InfoText);
            logNum.Text = "S9999";
            logShow.Text = "hucya@qq.com 版权所有 侵权必究 ";
            if (Globals.LedCmd.Buzzer != 0)
            {
                Globals.LedCmd.Buzzer = 0;//关闭蜂鸣器
            }
        }

        private void EmgBt_Click(object sender, EventArgs e)
        {
            if (!Globals.EMG)
            {
                Globals.EMG = true;
            }
        }

        private void LogoButton_Click(object sender, EventArgs e)
        {
            LockScreenForm locker = new LockScreenForm();
            locker.Show();
        }

        private void progressBarEx1_VisibleChanged(object sender, EventArgs e)
        {
            spdRrogressBar.Value = 0;
        }
    }
}
