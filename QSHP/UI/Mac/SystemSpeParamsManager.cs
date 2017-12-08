using QSHP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI
{
    public partial class SystemSpeParamsManager : BaseForm
    {
        MacData mac;
        bool saved = false;
        public SystemSpeParamsManager(MacData m)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                mac = m;
                LoadSystemMacDataValue(mac);
                LoadDefaultEventHander();
            }
            
        }

        public MacData MacData
        {
            get
            {
                return mac;
            }

            set
            {
                mac = value;
            }
        }


        private void LoadSystemMacDataValue(MacData m)
        {
            zTestSpeed.Value = m.ZTestSpeed;
            zTestAcc.Value = m.ZTestAcc;
            zTestRiseValue.Value = m.ZRiseValue;

            zCutSpeed.Value = m.ZCutSpeed;
            zCutAcc.Value = m.ZCutAcc;
            zSelfPos.Value = m.ZSelfPos;
            xCutAcc.Value = m.XCutAcc;
            xCutBackAcc.Value = m.XCutBackAcc;
            tStepPos.Value = m.TStep;
            tTestOffset.Value = m.TTestOffset;
            yTestOffset.Value = m.YTestOffset;
            tMaxValue.Value = m.TMaxPos;
            xFollowAcc.Value = m.XFollowAcc;
            xFollowSpeed.Value = m.XFollowSpeed;
            yFollowAcc.Value = m.YFollowAcc;
            yFollowSpeed.Value = m.YFollowSpeed;
        }
        private void SaveMacDataValue()
        {
            MacData m = mac;
            m.ZTestSpeed = zTestSpeed.Value;
            m.ZTestAcc = zTestAcc.Value;
            m.ZRiseValue = zTestRiseValue.Value;
            m.TTestOffset= tTestOffset.Value;
            m.YTestOffset= yTestOffset.Value;
            m.ZCutSpeed = zCutSpeed.Value;
            m.ZCutAcc = zCutAcc.Value;
            m.ZSelfPos = zSelfPos.Value;
            m.XCutAcc = xCutAcc.Value;
            m.XCutBackAcc = xCutBackAcc.Value;
            m.TStep = tStepPos.Value;
            m.TMaxPos = tMaxValue.Value;
            m.XFollowAcc= xFollowAcc.Value;
            m.XFollowSpeed= xFollowSpeed.Value;
            m.YFollowAcc= yFollowAcc.Value;
            m.YFollowSpeed= yFollowSpeed.Value;
        }
        private bool CheckMacDataValueIsValid()
        {
            return true;
        }

        private void SystemSpeParamsManager_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveMacDataValue();
                SystemDataManager.saved = true;
            }
            this.ParentForm.OnCancelClick();
        }

        private void SystemSpeParamsManager_ConfirmClick(object sender, EventArgs e)
        {
            saved = CheckMacDataValueIsValid();
            if (saved)
            {
                Common.ReportCmdKeyProgress(CmdKey.F0041);
            }
        }
        private void LoadDefaultEventHander()
        {
            //BT0Content = "特殊参数";
            //BT0Click += delegate (Object se, System.EventArgs arg)
            //{
            //    if (saved)
            //    {
            //        SaveMacDataValue();
            //    }
            //    this.ParentForm.ReplaceChildForm(new SystemSpeParamsManager(mac));
            //};
            BT4Content = SystemDataManager.cfgNames;
            BT4Click += delegate (Object se, System.EventArgs arg)
            {
                if (saved)
                {
                    SaveMacDataValue();
                }
                ParentForm.ReplaceChildForm(new SystemConfigManger(mac));
            };
            if (Globals.MajorIO)
            {
                BT5Content = SystemDataManager.diNames;
                BT5Click += delegate (Object se, System.EventArgs arg)
                {
                    if (saved)
                    {
                        SaveMacDataValue();
                    }
                    ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac, 0));
                };
                BT6Content = SystemDataManager.doNames;
                BT6Click += delegate (Object se, System.EventArgs arg)
                {
                    if (saved)
                    {
                        SaveMacDataValue();
                    }
                    ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac, 1));
                };
                if (Globals.ApplayAI)
                {
                    if (saved)
                    {
                        SaveMacDataValue();
                    }
                    BT7Content = SystemDataManager.aiNames;
                    BT7Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.ReplaceChildForm(new SystemAnalogManager(mac));
                    };
                }
            }
            else
            {
                BT5Content = SystemDataManager.ioNames;
                BT5Click += delegate (Object se, System.EventArgs arg)
                {
                    if (saved)
                    {
                        SaveMacDataValue();
                    }
                    ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac));
                };
                if (Globals.ApplayAI)
                {
                    BT6Content = SystemDataManager.aiNames;
                    BT6Click += delegate (Object se, System.EventArgs arg)
                    {
                        if (saved)
                        {
                            SaveMacDataValue();
                        }
                        ParentForm.ReplaceChildForm(new SystemAnalogManager(mac));
                    };
                }
            }

        }
    }
}
