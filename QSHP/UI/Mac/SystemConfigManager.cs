using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.Data;
using System.Threading;
using System.Diagnostics;
using System.Management;
using QSHP.Com;

namespace QSHP.UI
{
    public partial class SystemConfigManger : BaseForm
    {
        MacData mac;
        bool saved = false;
        bool cfgSaved = false;
        bool getKeys = false;
        Random random = new Random();
        bool isCanMode = false;
        object[] baudRateValue = { 9600, 38400, 57600, 115200, 128000 };
        object[] canBaudRateValue = {125000, 250000, 500000, 1000000 };

        public SystemConfigManger(MacData m)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                mac = m;
                if (isCanMode)
                {
                    portList.Items.Clear();
                    portList.Items.Add("CAN0");
                    portList.Items.Add("CAN1");
                    portList.Items.Add("CAN2");
                    portList.Items.Add("CAN3");
                    baudRate.Items.AddRange(canBaudRateValue);
                }
                else
                {
                    portList.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                    baudRate.Items.AddRange(baudRateValue);
                }
                LoadMacDataValue(m);
                LoadDefaultEventHander();
            }
        }
        private void SaveMacDataValue()
        {
            if (saved)
            {
                mac.LogDropMode = logDropMode.SelectedIndex;
                mac.LogDropTime = logDropTime.SelectedIndex;
                if (cfgSaved)
                {
                    Globals.DebugMode = debugMode.Checked;
                    Globals.SVNCTR = svnCtr.Checked;
                    Globals.AutoInit = autoInit.Checked;
                    Globals.DoubleCap = doubleCCD.Checked;
                    Globals.AutoLight = softLight.Checked;
                    Globals.AutoFource = autoFource.Checked;
                    Globals.BladeCheck = bldCheck.Checked;
                    Globals.NoTouchTest = noTouchTest.Checked;
                    Globals.ApplayAI = analogApplay.Checked;
                    Globals.MajorIO = majorIO.Checked;
                    Globals.AutoCut = autoCut.Checked;
                    Globals.NetControl = netCtr.Checked;
                    Globals.SVNCTR = svnCtr.Checked;
                    Globals.DoubleWaterSenser = doubleCutWater.Checked;
                    Globals.WaterAirClear = waterAir.Checked;
                    Globals.ApplySpeech = speech.Checked;
                }
            }
        }
        private void LoadDefaultEventHander()
        {
            BT0Content = "特殊参数";
            BT0Click += delegate (Object se, System.EventArgs arg)
            {
                SaveMacDataValue();
                this.ParentForm.ReplaceChildForm(new SystemSpeParamsManager(mac));
            };
            if (Globals.MajorIO)
            {
                BT5Content = "DI 配置";
                BT5Click += delegate (Object se, System.EventArgs arg)
                {

                    SaveMacDataValue();
                    ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac, 0));
                };
                BT6Content = "DO 配置";
                BT6Click += delegate (Object se, System.EventArgs arg)
                {
                    SaveMacDataValue();
                    ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac, 1));
                };
                if (Globals.ApplayAI)
                {
                    SaveMacDataValue();
                    BT7Content = "AI 配置";
                    BT7Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.ReplaceChildForm(new SystemAnalogManager(mac));
                    };
                }
            }
            else
            {
                BT5Content = "IO 配置";
                BT5Click += delegate (Object se, System.EventArgs arg)
                {
                    SaveMacDataValue();
                    ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac));
                };
                if (Globals.ApplayAI)
                {
                    BT6Content = "AI 配置";
                    BT6Click += delegate (Object se, System.EventArgs arg)
                    {
                        SaveMacDataValue();
                        ParentForm.ReplaceChildForm(new SystemAnalogManager(mac));
                    };
                }
            }

        }

        private void ChangePassWord_Click(object sender, EventArgs e)
        {
            string s = Com.Checksum.EncryptWithMD5(passwordEdit.Text);
            if (string.IsNullOrWhiteSpace(newPassWord.Text) || string.IsNullOrWhiteSpace(passWordConfirm.Text) || string.IsNullOrWhiteSpace(passwordEdit.Text))
            {
                Common.ReportCmdKeyProgress(CmdKey.S0024);
                return;
            }
            switch (userType.SelectedIndex)
            {
                case 0://操作人员
                    {
                        if (s.Equals(mac.UserKey))
                        {
                            if (newPassWord.Text.Equals(passWordConfirm.Text))
                            {
                                mac.UserKey = Com.Checksum.EncryptWithMD5(passWordConfirm.Text);
                                SystemDataManager.saved = true;
                                Common.ReportCmdKeyProgress(CmdKey.S0025);
                            }
                            else
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0026);
                            }
                        }
                        else
                        {
                            Common.ReportCmdKeyProgress(CmdKey.S0032);
                        }
                    }
                    break;
                case 1://设备管理员
                    {
                        if (s.Equals(mac.DevKey))
                        {
                            if (newPassWord.Text.Equals(passWordConfirm.Text))
                            {
                                mac.DevKey = Com.Checksum.EncryptWithMD5(passWordConfirm.Text);
                                SystemDataManager.saved = true;
                                Common.ReportCmdKeyProgress(CmdKey.S0025);
                            }
                            else
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0026);
                            }
                        }
                        else
                        {
                            Common.ReportCmdKeyProgress(CmdKey.S0032);
                        }
                    }
                    break;
                case 2://系统管理员
                    {
                        if (s.Equals(mac.AdminKey))
                        {
                            if (newPassWord.Text.Equals(passWordConfirm.Text))
                            {
                                mac.AdminKey = Com.Checksum.EncryptWithMD5(passWordConfirm.Text);
                                SystemDataManager.saved = true;
                                Common.ReportCmdKeyProgress(CmdKey.S0025);
                            }
                            else
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0026);
                            }
                        }
                        else
                        {
                            Common.ReportCmdKeyProgress(CmdKey.S0032);
                        }
                    }
                    break;
                case 3://锁屏密码
                    {
                        if (s.Equals(mac.LockKey))
                        {
                            if (newPassWord.Text.Equals(passWordConfirm.Text))
                            {
                                mac.LockKey = Com.Checksum.EncryptWithMD5(passWordConfirm.Text);
                                SystemDataManager.saved = true;
                                Common.ReportCmdKeyProgress(CmdKey.S0025);
                            }
                            else
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0026);
                            }
                        }
                        else
                        {
                            Common.ReportCmdKeyProgress(CmdKey.S0032);
                        }
                    }
                    break;
                case 4://远程
                    {
                        if (s.Equals(mac.RomoteKey))
                        {
                            if (newPassWord.Text.Equals(passWordConfirm.Text))
                            {
                                mac.RomoteKey = Com.Checksum.EncryptWithMD5(passWordConfirm.Text);
                                SystemDataManager.saved = true;
                                Common.ReportCmdKeyProgress(CmdKey.S0025);
                            }
                            else
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0026);
                            }
                        }
                        else
                        {
                            Common.ReportCmdKeyProgress(CmdKey.S0032);
                        }
                    }
                    break;
                default:
                    break;
            }
            passWordConfirm.Text = string.Empty;
            passwordEdit.Text = string.Empty;
            newPassWord.Text = string.Empty;
        }

        private void LoadMacDataValue(MacData m)
        {
            debugMode.Checked = Globals.DebugMode;
            waterAir.Checked = Globals.WaterAirClear;
            svnCtr.Checked = Globals.SVNCTR;
            autoInit.Checked = Globals.AutoInit;
            doubleCCD.Checked = Globals.DoubleCap;
            softLight.Checked = Globals.AutoLight;
            autoFource.Checked = Globals.AutoFource;
            bldCheck.Checked = Globals.BladeCheck;
            noTouchTest.Checked = Globals.NoTouchTest;
            analogApplay.Checked = Globals.ApplayAI;
            majorIO.Checked = Globals.MajorIO;
            autoCut.Checked = Globals.AutoCut;
            netCtr.Checked = Globals.NetControl;
            svnCtr.Checked = Globals.SVNCTR;
            speech.Checked= Globals.ApplySpeech;
            doubleCutWater.Checked = Globals.DoubleWaterSenser;
            string s = string.Empty;
            if (isCanMode)
            {
                s = string.Format("CAN{0}", m.SpdIndex);
            }
            else
            {
                s = string.Format("COM{0}", m.SpdIndex);
            }
            portList.Text = s;
            baudRate.Text = m.SpdBaud.ToString();
            logDropMode.SelectedIndex = m.LogDropMode;
            logDropTime.SelectedIndex = m.LogDropTime;
        }
        private void UserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            passwordEdit.Text = string.Empty;
            newPassWord.Text = string.Empty;
            passWordConfirm.Text = string.Empty;
        }

        private void ChangeSpdCfg_Click(object sender, EventArgs e)
        {
            changeSpdCfg.Enabled = false;
            string s = portList.Text.ToLower().Replace("com", "");
            s = s.Replace("CAN", "");
            int dev = 1;
            int baud = 9600;
            bool flag = Common.SPD.IsInit;
            int.TryParse(s, out dev);
            int.TryParse(baudRate.Text, out baud);
            if (dev != Common.SPD.DevIndex || Common.SPD.BaudRate != baud)
            {
                if (flag)
                {
                    Common.SPD.CloseSpd();
                }
                Common.SPD.DevIndex = dev;
                Common.SPD.BaudRate = baud;
                if (Common.SPD.InitSpd())
                {
                    SystemDataManager.saved = true;
                    mac.SpdIndex = dev;
                    mac.SpdBaud = baud;
                    Common.ReportCmdKeyProgress(CmdKey.F0054);
                }
                else
                {
                    Common.SPD.DevIndex = mac.SpdIndex;
                    Common.SPD.BaudRate = mac.SpdBaud;//恢复原本参数
                    if (flag)
                    {
                        Common.SPD.InitSpd();
                    }
                    Common.ReportCmdKeyProgress(CmdKey.F0055);
                }
            }
            changeSpdCfg.Enabled = true;
        }

        private void SystemConfigManger_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveMacDataValue();
                mac.LogDropTime = logDropTime.SelectedIndex;
                mac.LogDropMode = logDropMode.SelectedIndex;
                SystemDataManager.saved = true;
            }
            this.ParentForm.OnCancelClick();
        }

        private void SystemConfigManger_ConfirmClick(object sender, EventArgs e)
        {
            saved = true;
            Common.ReportCmdKeyProgress(CmdKey.F0051);
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            if (getKeys)
            {
                if (Checksum.CheckRegiterKeysIsValid(superPassword.Text.ToUpper(), label6.Text.ToUpper()))
                {
                    panel1.Enabled = true;
                    cfgSaved = true;
                    Common.ReportCmdKeyProgress(CmdKey.S0034);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0033);
                    panel1.Enabled = false;
                }
            }
            buttonEx2_Click(this, null);
            superPassword.Text = string.Empty;
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            int value= random.Next(4096,65535);
            string s = value.ToString("X4");//Com.Checksum.GetRegiterKeys(false);
            if (s != null)
            {
                label6.Text = s;
                getKeys = true;
            }
            else
            {
                label6.Text = "xxxxxx";
                getKeys = false;
            }
            superPassword.Text = string.Empty;
        }
      
    }
}
