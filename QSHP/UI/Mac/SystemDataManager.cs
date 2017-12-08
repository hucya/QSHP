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
    public partial class SystemDataManager : BaseForm
    {
        MacData mac;

        public static bool saved = false;
        public static string specNames = "特殊参数";
        public static string ioNames = "IO 配置";
        public static string diNames = "DI 配置";
        public static string doNames = "DO 配置";
        public static string aiNames = "AI 配置";
        public static string cfgNames = "配置修改";
        public SystemDataManager()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                mac = Globals.MacData.CreateNewMacData();
                LoadSystemDataValue(mac);
                LoadDefaultEventHander();
            }
        }
        private void LoadSystemDataValue(MacData m)
        {
            saved = false;
            xStartPos.Value = m.XStartPos;
            xOffset.Value = m.XOffset;
            xHomeSpeed.Value = m.XHomeSpeed;
            xHomeAcc.Value = m.XHomeAcc;
            xResolution.Value = m.XResolution;
            xLead.Value = m.XLead;
            xAccuracy.Value = m.XAccuracy;
            xMaxError.Value = m.XMaxError;
            xSpeed.Value = m.XSpeed;
            xAcc.Value = m.XAcc;

            yStartPos.Value = m.YStartPos;
            yOffset.Value = m.YOffset;
            yHomeSpeed.Value = m.YHomeSpeed;
            yHomeAcc.Value = m.YHomeAcc;
            yResolution.Value = m.YResolution;
            yLead.Value = m.YLead;
            yAccuracy.Value = m.YAccuracy;
            yMaxError.Value = m.YMaxError;
            ySpeed.Value = m.YSpeed;
            yAcc.Value = m.YAcc;

            zStartPos.Value = m.ZStartPos;
            zOffset.Value = m.ZOffset;
            zHomeSpeed.Value = m.ZHomeSpeed;
            zHomeAcc.Value = m.ZHomeAcc;
            zResolution.Value = m.ZResolution;
            zLead.Value = m.ZLead;
            zAccuracy.Value = m.ZAccuracy;
            zMaxError.Value = m.ZMaxError;
            zSpeed.Value = m.ZSpeed;
            zAcc.Value = m.ZAcc;

            tStartPos.Value = m.TStartPos;
            tOffset.Value = m.TOffset;
            tHomeSpeed.Value = m.THomeSpeed;
            tHomeAcc.Value = m.THomeAcc;
            tResolution.Value = m.TResolution;
            tLead.Value = m.TLead;
            tAccuracy.Value = m.TAccuracy;
            tMaxError.Value = m.TMaxError;
            tSpeed.Value = m.TSpeed;
            tAcc.Value = m.TAcc;

            xCenterPos.Value = m.CenterPos.X;
            yCenterPos.Value = m.CenterPos.Y;
            xPlimit.Value = m.XPLimit;
            xNlimit.Value = m.XNLimit;
            yPlimit.Value = m.YPLimit;
            yNlimit.Value = m.YNLimit;
            tAdjXSpeed.Value = m.TAdjSpeed;
            tAdjXAcc.Value = m.TAdjAcc;
            pickXPos.Value = m.PickXPos;
            pickYPos.Value = m.PickYPos;
            pickZPos.Value = m.PickZPos;
            pickTPos.Value = m.PickTPos;

            p1Xpos.Value = m.P1Pos.X;
            p1YPos.Value = m.P1Pos.Y;
            p2XPos.Value = m.P2Pos.X;
            p2YPos.Value = m.P2Pos.Y;
        }
        private void SaveSystemDataValue()
        {
            MacData m= mac;
            m.XStartPos = xStartPos.Value;
            m.XOffset = xOffset.Value;
            m.XHomeSpeed = xHomeSpeed.Value;
            m.XHomeAcc = xHomeAcc.Value;
            m.XResolution = xResolution.Value;
            m.XLead = xLead.Value;
            m.XAccuracy = xAccuracy.Value;
            m.XMaxError = xMaxError.Value;
            m.XSpeed = xSpeed.Value;
            m.XAcc = xAcc.Value;

            m.YStartPos = yStartPos.Value;
            m.YOffset = yOffset.Value;
            m.YHomeSpeed = yHomeSpeed.Value;
            m.YHomeAcc = yHomeAcc.Value;
            m.YResolution = yResolution.Value;
            m.YLead = yLead.Value;
            m.YAccuracy = yAccuracy.Value;
            m.YMaxError = yMaxError.Value;
            m.YSpeed = ySpeed.Value;
            m.YAcc = yAcc.Value;

            m.ZStartPos = zStartPos.Value;
            m.ZOffset = zOffset.Value;
            m.ZHomeSpeed = zHomeSpeed.Value;
            m.ZHomeAcc = zHomeAcc.Value;
            m.ZResolution = zResolution.Value;
            m.ZLead = zLead.Value;
            m.ZAccuracy = zAccuracy.Value;
            m.ZMaxError = zMaxError.Value;
            m.ZSpeed = zSpeed.Value;
            m.ZAcc = zAcc.Value;

            m.TStartPos = tStartPos.Value;
            m.TOffset = tOffset.Value;
            m.THomeSpeed = tHomeSpeed.Value;
            m.THomeAcc = tHomeAcc.Value;
            m.TResolution = tResolution.Value;
            m.TLead = tLead.Value;
            m.TAccuracy = tAccuracy.Value;
            m.TMaxError = tMaxError.Value;
            m.TSpeed = tSpeed.Value;
            m.TAcc = tAcc.Value;

            m.CenterPos= new PointF(xCenterPos.Value, yCenterPos.Value); ;
            m.XPLimit = xPlimit.Value;
            m.XNLimit = xNlimit.Value;
            m.YPLimit = yPlimit.Value;
            m.YNLimit = yNlimit.Value;
            m.TAdjSpeed = tAdjXSpeed.Value;
            m.TAdjAcc = tAdjXAcc.Value;
            m.PickXPos = pickXPos.Value;
            m.PickYPos = pickYPos.Value;
            m.PickZPos = pickZPos.Value;
            m.PickTPos = pickTPos.Value;
            m.P1Pos = new PointF(p1Xpos.Value,p1YPos.Value);
            m.P1Pos = new PointF(p2XPos.Value, p2YPos.Value);
            Globals.MacData = mac;//赋值为全局变量
            Globals.MacData.SaveMacDataToFile(Globals.AppCfg.MacFullPathName); //保存当前文件配置
            Common.ReportCmdKeyProgress(CmdKey.F0040);  //
            GC.Collect();
        }
        private bool CheckMacDataValueIsValid()
        {
            return true;
        }
        
        private void SystemDataManger_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveSystemDataValue();
            }
            this.ParentForm.OnCancelClick();
        }

        private void SystemDataManger_ConfirmClick(object sender, EventArgs e)
        {
            if (CheckMacDataValueIsValid())
            {
                saved = true;
                Common.ReportCmdKeyProgress(CmdKey.F0051);
            }
        }
        private void LoadDefaultEventHander()
        {
            BT0Content = SystemDataManager.specNames;
            BT0Click += delegate (Object se, System.EventArgs arg)
            {
                this.ParentForm.PushChildForm(new SystemSpeParamsManager(mac));
            };
            BT4Content = SystemDataManager.cfgNames;
            BT4Click += delegate (Object se, System.EventArgs arg)
            {
                ParentForm.PushChildForm(new SystemConfigManger(mac));
            };
            if (Globals.MajorIO)
            {
                BT5Content = SystemDataManager.diNames;
                BT5Click += delegate (Object se, System.EventArgs arg)
                {
                    ParentForm.PushChildForm(new SystemDigIOConfigManager(mac, 0));
                };
                BT6Content = SystemDataManager.doNames;
                BT6Click += delegate (Object se, System.EventArgs arg)
                {
                    ParentForm.PushChildForm(new SystemDigIOConfigManager(mac, 1));
                };
                if (Globals.ApplayAI)
                {
                    
                    BT7Content = SystemDataManager.aiNames;
                    BT7Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.PushChildForm(new SystemAnalogManager(mac));
                    };
                }
            }
            else
            {
                BT5Content = SystemDataManager.ioNames;
                BT5Click += delegate (Object se, System.EventArgs arg)
                {
                    
                    ParentForm.PushChildForm(new SystemDigIOConfigManager(mac));
                };
                if (Globals.ApplayAI)
                {
                    BT6Content = SystemDataManager.aiNames;
                    BT6Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.PushChildForm(new SystemAnalogManager(mac));
                    };
                }
            }

        }

    }
}
