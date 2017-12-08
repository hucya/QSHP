using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QSHP
{
    public partial class Logo : Form
    {
        public const int TIMER_TICK = 30;
        public new MainForm ParentForm;
        private int tick = 60;
        public Logo()
        {
            InitializeComponent();
        }
        public Logo(MainForm f)
        {
            ParentForm = f;
            InitializeComponent();
        }
        private void Logo_Load(object sender, EventArgs e)
        {
            base.SetVisibleCore(false);//屏蔽ALT+TAB切换
            Process.GetCurrentProcess().PriorityBoostEnabled = true;
            Common.ProgressCmdKeyChanged += Common_ProgressChanged;
            if (ProcessCmd.CheckMachineRegistKeyIsValid())
            {
                if (ProcessCmd.CheckMachineRegistValueIsValid())
                {
                    timer2.Enabled = true;
                    panel1.Visible = false;
                    Common.SetSystemWorkMode(SysFunState.Load);
                    return;
                }
            }
            DialogResult re = MessageBox.Show(string.Format("系统未进行注册或发生设备环境变更\n点击 '确认' 进行注册\n点击 '取消' 系统将于三分钟后关闭\n"), "系统警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (re == DialogResult.OK)
            {
                maskKey.Text = Com.Checksum.GetRegiterKeys();
                logoText.Text = "请向厂家技术人员提供注册秘钥";
            }
            else
            {
                maskKey.Text = Com.Checksum.GetRegiterKeys();
                ProcessCmd.SetSystemShutdown(180);
            }
            panel1.Visible = true;
            panel1.SelectedIndex = 1;
            timer2.Enabled = false;
        }
        private void ProcessCommonProgressChanger(CmdKey key)
        {
            if (Globals.SysCmd.ContainsKey(key))
            {
                if (logoBar.Value < 90)
                {
                    logoBar.Value += 10;
                    if (Globals.AppCfg.Language == 0)
                    {
                        process.Text = string.Format("系统加载进度 {0}%", logoBar.Value);
                    }
                    else
                    {
                        process.Text = string.Format("System Loading Progress {0}%", logoBar.Value);
                    }
                }
                CmdValue v = Globals.SysCmd[key];
                logoText.Text = v.Description;
                switch (v.Leave)
                {
                    case CmdLeave.Debug:
                        {
                            logoText.ForeColor = Color.Green;
                        }
                        break;
                    case CmdLeave.Info:
                        {
                            logoText.ForeColor = Color.Blue;
                        }
                        break;
                    case CmdLeave.Warn:
                        {
                            logoText.ForeColor = Color.Orange;
                        }
                        break;
                    default:
                        {
                            logoText.ForeColor = Color.Red;
                        }
                        break;
                }
            }
            else
            {
                logoText.ForeColor = Color.Red;
                if (Globals.SysCmd.ContainsKey(CmdKey.S0099))
                {
                    logoText.Text = Globals.SysCmd[CmdKey.S0099].Description;
                }
                else
                {
                    logoText.Text = "当前指令缺失";
                }
            }
            if (key == CmdKey.S0001 || key == CmdKey.S0002)
            {
                logoBar.Value = 100;
                if (Globals.AppCfg.Language == 0)
                {
                    process.Text = string.Format("系统加载进度 100%");
                }
                else
                {
                    process.Text = string.Format("System Loading Progress 100%");
                }
                ParentForm.Show();
                timer1.Start();
                timer2.Stop();
                Common.ProgressCmdKeyChanged -= Common_ProgressChanged;
            }
        }
        private void Common_ProgressChanged(CmdKey key, object obj)
        {
            this.Invoke((Action<CmdKey>)ProcessCommonProgressChanger,key);
            Thread.Sleep(300);
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.01;
            if (this.Opacity < 0.01)
            {
                this.Close();
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (tick-- < 0)
            {
                timer2.Enabled = false;
                Common.ReportCmdKeyProgress(CmdKey.S0094);
                panel1.Visible = true;
                panel1.SelectedIndex = 0;
            }
        }
       // 8AEFE7
        private void ExitApplition_Click(object sender, EventArgs e)
        {
            Common.SystemExit(true,true);
            ProcessCmd.SetSystemShutdown();
        }

        private void ReloadBt_Click(object sender, EventArgs e)
        {
            Common.SystemExit(false,false);//异常关机
            Process.Start(Process.GetCurrentProcess().ProcessName + ".exe");
        }
        private void ButtonEx3_Click(object sender, EventArgs e)
        {
            ProcessCmd.SetSystytemLoadShell(true);
        }

        private void ButtonEx4_Click(object sender, EventArgs e)
        {
            ParentForm.Show();
            this.Close();
        }

        private void Logo_FormClosing(object sender, FormClosingEventArgs e)
        {
            ParentForm.Show();
            Common.ProgressCmdKeyChanged -= Common_ProgressChanged;
        }

        private void MaskCheck_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(superPassword.Text))
            {
                if (Com.Checksum.CheckRegiterKeysIsValid(superPassword.Text))
                {
                    ProcessCmd.RegisterSystem(maskKey.Text, superPassword.Text);
                    timer2.Enabled = true;
                    panel1.Visible = false;
                    try
                    {
                        File.Delete(Globals.AppCfg.LogFileFullName);//重新清理生成日志
                        File.WriteAllBytes(Globals.AppCfg.LogFileFullName, Properties.Resources.FCLOG);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        Common.SetSystemWorkMode(SysFunState.Load);
                    }
                }
                else
                {
                    logoText.Text = "注册密码无效";
                }
            }
            else
            {
                logoText.Text = "请输入厂家提供的注册密码";
            }
            superPassword.Text = string.Empty;
        }

    }
}
