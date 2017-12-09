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
    public partial class BladeTestDataManager : BaseForm
    {
        TabData tabData;
        TabArgs args;
        bool saved = false;
        public BladeTestDataManager()
        {
            InitializeComponent();
        }

        private void BladeTestDataManager_Load(object sender, EventArgs e)
        {
            if(!DesignMode)
            {
                tabData = Globals.TabData.CreateNewTabData();
                if (tabData == null)
                {
                    tabData = new TabData();
                }
                LoadTabData();
            }
        }

        private void LoadTabData(bool updata=true)
        {
            if (updata)
            {
                tabNum.SelectedIndex = tabData.TabIndex;
                spdSpeed.Value = tabData.SpdSpeed;
            }
            tabType.SelectedIndex = tabData.RotateType ? 0 : 1;
            args = tabData.UsedTable;
            tabSize.Text = string.Format("{0} * {1}", args.TabSize.Width, args.TabSize.Height);
            xPos.Value = args.CurXpos;
            yPos.Value = args.CurYpos;
            zPos.Value = args.ZLowPos;
            tPos.Value = args.CurTpos;
        }

        private void SaveTabDataValue()
        {
            tabData.TabIndex = tabNum.SelectedIndex;
            tabData.RotateType = tabType.SelectedIndex == 0;
            tabData.SpdSpeed = spdSpeed.Int;
            Globals.TabData = tabData;
        }

        private bool CheckTabDataIsValid()
        {
            if (spdSpeed.Value > 60000 || spdSpeed.Value < 5000)
            {
                spdSpeed.SetError = true;
                Common.ReportCmdKeyProgress(CmdKey.B0004);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void tabNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabData.TabIndex = tabNum.SelectedIndex;
            LoadTabData(false);
        }

        private void tabType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabData.RotateType = tabType.SelectedIndex == 0;
        }

        private void BladeTestDataManager_BT0Click(object sender, EventArgs e)//圆形工作盘
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.PushChildForm(new BladeCirTabEditManager(tabData));
            }

        }

        private void BladeTestDataManager_BT1Click(object sender, EventArgs e)//方形工作盘
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.PushChildForm(new BladeRecTabEditManager(tabData));
            }
        }

        private void BladeTestDataManager_BT2Click(object sender, EventArgs e)//测高参数调整
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.PushChildForm(new BladeTestDataEdit(tabData));
            }
        }

        private void BladeTestDataManager_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveTabDataValue();
            }
            this.ParentForm.OnCancelClick();
        }

        private void BladeTestDataManager_ConfirmClick(object sender, EventArgs e)
        {
            saved = CheckTabDataIsValid();
            Common.ReportCmdKeyProgress(CmdKey.B0003);
        }
    }
}
