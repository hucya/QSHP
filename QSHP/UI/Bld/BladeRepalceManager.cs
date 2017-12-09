using QSHP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace QSHP.UI.Bld
{
    public partial class BladeRepalceManager : BaseForm
    {
        BldData bladeData;
        bool firstCreate = true;
        public BladeRepalceManager()
        {
            InitializeComponent();
        }
        private void BladeRepalceManager_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (Globals.BldData != null)
                {
                    bladeData = Globals.BldData.CreateNewBladeData(true);//克隆一个新的数据类
                }
                else
                {
                    bladeData = new BldData();
                }
                LoadDefalutBldData(bladeData);
                CheckValueIsValid();
            }
        }
        private void LoadDefalutBldData(BldData bld)
        {
            bldModelEdit.Text = bld.BldModel;
            bldNumEdit.Text = bld.BldNum;
            bldTypeEdit.SelectedIndex = bld.BldType;
            bldTicknessEdit.Value = bld.BldTickness;
            bldDiameter.Value = bld.BldDiameter;
            flangeDiameter.Value = bld.FlangeDiameter;
            maxCutLenEdit.Value = bld.MaxSafeLength;
            maxCutLineEdit.Value = bld.MaxSafeLines;
            selfWarnEdit.Value = bld.SafetyMargin;
            repalceResult.SelectedIndex = bld.ReplaceReason;
            depthCompensatedMode.SelectedIndex = bld.DepthCompensatedMode;
            depthCompensatedLines.Value = bld.DepthCompensatedLines;
            depthCompensatedLen.Value = bld.DepthCompensatedLen;
            depthCompensatedValue.Value = bld.DepthCompensatedValue;
            usedHandTest.SelectedIndex = bld.UsedHandTest?1:0;
            handTestValue.Value = bld.TestHeightValue;
        }

        private void SaveDefaultBldData()
        {
            BldData bld = bladeData;
            bld.BldModel = bldModelEdit.Text;
            bld.BldNum = bldNumEdit.Text;
            bld.BldType = (byte)bldTypeEdit.SelectedIndex;
            bld.BldTickness = bldTicknessEdit.Value;
            bld.BldDiameter = bldDiameter.Value;
            bld.FlangeDiameter = flangeDiameter.Value;
            bld.MaxSafeLength = maxCutLenEdit.Value;
            bld.MaxSafeLines = maxCutLineEdit.Int;
            bld.SafetyMargin = selfWarnEdit.Value;
            bld.ReplaceReason = (byte)repalceResult.SelectedIndex;
            bld.DepthCompensatedMode = (byte)depthCompensatedMode.SelectedIndex;
            bld.DepthCompensatedLines = depthCompensatedLines.Value;
            bld.DepthCompensatedLen = depthCompensatedLen.Value;
            bld.DepthCompensatedValue = depthCompensatedValue.Value;
            bld.UsedHandTest = usedHandTest.SelectedIndex > 0;
            if (bld.UsedHandTest)
            {
                bld.TestHeightValue = handTestValue.Value;
            }
        }

        private void SaveChangeBladeDate(bool isNew=false)
        {
            if (CheckValueIsValid())//检查值是否有效
            {
                SaveDefaultBldData();
                if (isNew && firstCreate)
                {
                    bladeData = bladeData.CreateNewBladeData();//创建一个新的数据类
                    firstCreate = false;
                    bladeData.ReadyTest = false;
                    Globals.TestedHeight = false;//清除当前测高标志 更换刀具后需要重新进行测高
                    Common.ReportCmdKeyProgress(CmdKey.B0013);
                }
                if (usedHandTest.SelectedIndex != 0)
                {
                    Globals.TestHeightValue = handTestValue.Value;
                    Globals.TestedHeight = true;
                    bladeData.TestHeightValue = handTestValue.Value;//手动输入测高值
                    Common.ReportCmdKeyProgress(CmdKey.B0014);
                }
                Globals.AppCfg.BladeFileName = string.Format("QS{0}{1}.drs", bladeData.ReplaceTime.ToString("yyyyMM"), bladeData.Number.ToString("D4"));
                this.bladeData.SaveBladeDataFile(Globals.AppCfg.BladeFileFullName);
                Globals.AppCfg.SaveDefaultSysConfigFile();
                Globals.BldData = this.bladeData;
            }
        }

        private void BladeRepalceManager_ConfirmClick(object sender, EventArgs e)
        {
            SaveChangeBladeDate();
        }

        private void BladeRepalceManager_NextClick(object sender, EventArgs e)
        {
            SaveChangeBladeDate(true);
        }

        private bool CheckValueIsValid()
        {
            bool flag = true;
            float lossValue = Math.Abs(flangeDiameter.Value - bldDiameter.Value) / 2;
            if (flangeDiameter.Value > bldDiameter.Value)
            {
                Common.ReportCmdKeyProgress(CmdKey.B0010);
                flangeDiameter.SetError = true;
                flag = false;
            }
            if (selfWarnEdit.Value > lossValue)
            {
                Common.ReportCmdKeyProgress(CmdKey.B0011);
                selfWarnEdit.SetError = true;
                flag = false;
            }
            if (depthCompensatedValue.Value> (lossValue - selfWarnEdit.Value))//深度补偿值 < 默认漏出量 - 安全余量
            {
                Common.ReportCmdKeyProgress(CmdKey.B0012);
                depthCompensatedValue.SetError = true;
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(bldModelEdit.Text))
            {
                bldModelEdit.SetError = true;
            }
            return flag;
        }

        private void DepthCompensatedMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            depthCompensatedLen.Value = bladeData.DepthCompensatedLen;
            depthCompensatedLines.Value = bladeData.DepthCompensatedLines;
            depthCompensatedValue.Value = bladeData.DepthCompensatedValue;
            switch (depthCompensatedMode.SelectedIndex)
            {
                case 0:
                    {
                        depthCompensatedLen.Enabled = false;
                        depthCompensatedLines.Enabled = false;
                        depthCompensatedValue.Enabled = false;
                    }
                    break;
                case 1:
                    {
                        depthCompensatedLen.Enabled = false;
                        depthCompensatedLines.Enabled = true;
                        depthCompensatedValue.Enabled = true;
                    }
                    break;
                case 2:
                    {
                        depthCompensatedLen.Enabled = true;
                        depthCompensatedLines.Enabled = true;
                        depthCompensatedValue.Enabled = false;
                    }
                    break;
                case 3:
                    {
                        depthCompensatedLen.Enabled = false;
                        depthCompensatedLines.Enabled = false;
                        depthCompensatedValue.Enabled = false;
                    }
                    break;
            }
        }

        private void usedHandTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            handTestValue.Enabled = usedHandTest.SelectedIndex == 1;
        }
    }
}
