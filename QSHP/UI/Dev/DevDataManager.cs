using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.Data;
using QSHP.Com;
using QSHP.UI;

namespace QSHP.UI
{
    public partial class DevDataManager : BaseForm
    {
        DevData dev;
       public static bool saved = false;
        public DevDataManager()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                dev = Globals.DevData.CreateNewDevData();
                LoadDevDataValue(dev);
            }
        }

        private void LoadDevDataValue(DevData d)
        {
            xSpeed.Value = d.XSpeed;
            xAcc.Value = d.XAcc;
            xlSpeed.Value = d.XLowSpeed;
            xlAcc.Value = d.XLowAcc;

            ySpeed.Value = d.YSpeed;
            yAcc.Value = d.YAcc;
            ylSpeed.Value = d.YLowSpeed;
            ylAcc.Value = d.YLowAcc;

            zSpeed.Value = d.ZSpeed;
            zAcc.Value = d.ZAcc;
            zlSpeed.Value = d.ZLowSpeed;
            zlAcc.Value = d.ZLowAcc;

            tSpeed.Value = d.TSpeed;
            tAcc.Value = d.TAcc;
            tlSpeed.Value = d.TLowSpeed;
            tlAcc.Value = d.TLowAcc;

            buzzerUsed.Checked = d.BuzzerUsed;
            cutWaterChecked.Checked = d.CutWaterChecked;
            leakWaterChecked.Checked = d.LeakWaterChecked;
            doorProtect.Checked = d.DoorProtectUsed;
            testNoCheckAir.Checked = d.TestCheckAir;
            zlift.Checked = d.DualZlife;
            cutStopCloseWater.Checked = d.CutStopCloseWater;
            cutPauseCloseCutwater.Checked = d.CutPauseCloseWater;
            resumeCutCloseBuzzer.Checked = d.ResumeCloseBuzzer;
            unloadVacuum.Checked = d.CutStopUnloadVacuum;

            testTime.Value = d.TestTime;
            CutTime.Value = d.CuttingTime;
            spdAxis.Value = d.SpindleAxis;
            spdReadyTime.Value = d.SpindleReadyTime;

            hCenterX.Value = d.HighCenterX;
            hCenterY.Value = d.HighCenterY;
            hPix.Value = d.HighPixValue;
            lowCCDSet.Enabled = Globals.DoubleCap;
            if (Globals.DoubleCap)
            {
                lCenterX.Value = d.LowCenterX;
                lCenterY.Value = d.LowCenterY;
                lPix.Value = d.LowPixValue;
            }
            else
            {
                lCenterX.Value = d.HighCenterX;
                lCenterY.Value = d.HighCenterX;
                lPix.Value = d.HighPixValue*2;
            }
        }

        private void SaveDevDataValue()
        {
            DevData d = dev;
            d.XSpeed = xSpeed.Value;
            d.XAcc = xAcc.Value;
            d.XLowSpeed = xlSpeed.Value;
            d.XLowAcc = xlAcc.Value;

            d.YSpeed = ySpeed.Value;
            d.YAcc = yAcc.Value;
            d.YLowSpeed = ylSpeed.Value;
            d.YLowAcc = ylAcc.Value;

            d.ZSpeed = zSpeed.Value;
            d.ZAcc = zAcc.Value;
            d.ZLowSpeed = zlSpeed.Value;
            d.ZLowAcc = zlAcc.Value;

            d.TSpeed = tSpeed.Value;
            d.TAcc = tAcc.Value;
            d.TLowSpeed = tlSpeed.Value;
            d.TLowAcc = tlAcc.Value;

            d.BuzzerUsed = buzzerUsed.Checked;
            d.CutWaterChecked = cutWaterChecked.Checked;
            d.LeakWaterChecked = leakWaterChecked.Checked;
            d.DoorProtectUsed = doorProtect.Checked;
            d.TestCheckAir = testNoCheckAir.Checked;
            d.CutStopCloseWater = cutStopCloseWater.Checked;
            d.CutPauseCloseWater= cutPauseCloseCutwater.Checked;
            d.ResumeCloseBuzzer= resumeCutCloseBuzzer.Checked;
            d.CutStopUnloadVacuum = unloadVacuum.Checked;

            d.DualZlife = zlift.Checked;
            d.TestTime = testTime.Int;
            d.CuttingTime = CutTime.Int;
            d.SpindleAxis= spdAxis.Value;
            d.SpindleReadyTime= spdReadyTime.Value;



            d.LowCenterX = lCenterX.Value;
            d.LowCenterY = lCenterY.Value;
            d.LowPixValue = lPix.Value;

            d.HighCenterX = hCenterX.Value;
            d.HighCenterY = hCenterY.Value;
            d.HighPixValue = hPix.Value;

            Globals.DevData = d;
            Globals.DevData.SaveDevDataToFile(Globals.AppCfg.DevFullPathName); //保存当前文件配置
            Common.ReportCmdKeyProgress(CmdKey.F0040);  //
            GC.Collect();
        }

        private void DevDataManager_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveDevDataValue();
            }
            this.ParentForm.OnCancelClick();
        }

        private void DevDataManager_ConfirmClick(object sender, EventArgs e)
        {

            saved = true;
        }

        private void DevDataManager_BT0Click(object sender, EventArgs e)
        {
            this.ParentForm.PushChildForm(new DevLedCfgManager(dev));
        }

        private void DevDataManager_BT1Click(object sender, EventArgs e)
        {
            this.ParentForm.PushChildForm(new DevAlignDataManager(dev));
        }
    }
}
