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
    public partial class BladeTestDataEdit : BaseForm
    {
        TabData tabData;
        bool saved = false;
        bool applyNCS = true;
        public BladeTestDataEdit()
        {
            InitializeComponent();
        }
        public BladeTestDataEdit(TabData data)
        {
            InitializeComponent();
            applyNCS = Globals.NoTouchTest;
            tabData = data;
        }
        private void buttonEx1_Click(object sender, EventArgs e)
        {
            PointF p = Globals.AxisPoint;
            xPos.Value = p.X;
            yPos.Value = p.Y;
            
        }

        private void LoadTabDataValue(bool ncs=false)
        {
            deFaultMode.Enabled = ncs;
            if (ncs)
            {
                label7.Visible = true;
                label8.Visible = true;
                autoMode.Visible = true;
                cycCounter.Visible = true;
                ncsAllowMaxErr.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                groupBox3.Visible = true;
            }
            else
            {
                label7.Visible = false;
                label8.Visible = false;
                autoMode.Visible = false;
                cycCounter.Visible = false;
                ncsAllowMaxErr.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                groupBox3.Visible = false;
            }
            deFaultMode.SelectedIndex = tabData.ToolBarCsMode?0:1;
            checkTick.Value = tabData.TestTick;
            autoMode.SelectedIndex = tabData.NcsAutoMode;
            cycCounter.Value = tabData.NcsRepeatTick;
            csAllowMaxErr.Value = tabData.CsMaxErrValue;
            ncsAllowMaxErr.Value = tabData.NcsMaxErrValue;
            xPos.Value = tabData.NcsXpos;
            yPos.Value = tabData.NcsYpos;
            zPos.Value = tabData.NcsZlowPos;
            blowingWaterTime.Value = tabData.NcsBlowingWaterTime;
            waitTime.Value = tabData.NcsWaitTime;
            blowingAirTime.Value = tabData.NcsBlowingAirTime;

        }

        private void SaveTabDataValue()
        {
           
            tabData.ToolBarCsMode = deFaultMode.SelectedIndex == 0;
            tabData.TestTick = checkTick.Int;
            tabData.NcsAutoMode = autoMode.SelectedIndex;
            tabData.NcsRepeatTick = cycCounter.Int;
            tabData.CsMaxErrValue = csAllowMaxErr.Value;
            tabData.NcsMaxErrValue = ncsAllowMaxErr.Value;
            tabData.NcsXpos = xPos.Value;
            tabData.NcsYpos = yPos.Value;
            tabData.NcsZlowPos = zPos.Value;
            tabData.NcsBlowingWaterTime = blowingWaterTime.Int;
            tabData.NcsWaitTime = waitTime.Int;
            tabData.NcsBlowingAirTime = blowingAirTime.Int;

            Globals.TabData = tabData;
            Globals.TabData.SaveTabDataFile(Globals.AppCfg.TabFileFullPath);
        }
        private void BladeTestDataEdit_Load(object sender, EventArgs e)
        {
            LoadTabDataValue(applyNCS);
        }

        private void BladeTestDataEdit_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveTabDataValue();
            }
            if (this.ParentForm != null)
            {
                this.ParentForm.OnCancelClick();
            }
        }

        private void BladeTestDataEdit_ConfirmClick(object sender, EventArgs e)
        {
            saved = CheckBladeTestDataIsValid();
            if (saved)
            {
                Common.ReportCmdKeyProgress(CmdKey.B0009);
            }
        }

        private bool CheckBladeTestDataIsValid()
        {
            return true;
        }

        private void BladeTestDataEdit_BT0Click(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveTabDataValue();
            }
            this.ParentForm.ReplaceChildForm(new Bld.BladeCirTabEditManager(tabData));
        }

        private void BladeTestDataEdit_BT1Click(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveTabDataValue();
            }
            this.ParentForm.ReplaceChildForm(new Bld.BladeRecTabEditManager(tabData));
        }
    }
}
