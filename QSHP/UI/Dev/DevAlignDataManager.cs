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
    public partial class DevAlignDataManager : BaseForm
    {
        DevData dev;
        bool saved = false;
        public DevAlignDataManager(DevData d)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                dev = d;
                LoadDevDataValue(dev);
            }
        }
        private void SaveDevDataValue()
        {
            DevData d = dev;
            d.OnceAlignLineAdj = adjTickValue.Value;
            d.MaxAlignLineAdj = adjMaxValue.Value;
            d.MaxPosAdj = posMaxValue.Value;
            d.MaxHeightAdj = heightMaxValue.Value;
            d.OnceHeightAdj = heightTickValue.Value;
            d.MaxSpeedAdj = speedMaxValue.Value;
            d.MaxStepAdj = stepMaxValue.Value;

            d.ReplaceBldXNoMove = xReplaceBldnNoMove.Checked;
            d.ReplaceBldXPos = xRePos.Value;
            d.ReplaceBldYPos = yRePos.Value;
            d.ReplaceBldZPos = zRePos.Value;
            DevDataManager.saved = true;
        }
        private void LoadDevDataValue(DevData d)
        {
            adjTickValue.Value = d.OnceAlignLineAdj;
            adjMaxValue.Value = d.MaxAlignLineAdj;
            posMaxValue.Value = d.MaxPosAdj;
            heightMaxValue.Value = d.MaxHeightAdj;
            heightTickValue.Value = d.OnceHeightAdj;
            speedMaxValue.Value = d.MaxSpeedAdj;
            stepMaxValue.Value = d.MaxStepAdj;

            xReplaceBldnNoMove.Checked = d.ReplaceBldXNoMove;
            xRePos.Value = d.ReplaceBldXPos;
            yRePos.Value = d.ReplaceBldYPos;
            zRePos.Value = d.ReplaceBldZPos;

        }

        private void DevAlignDataManager_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveDevDataValue();
            }
            this.ParentForm.OnCancelClick();
        }

        private void DevAlignDataManager_ConfirmClick(object sender, EventArgs e)
        {
            saved = true;
        }

        private void xReplaceBldnNoMove_CheckedChanged(object sender, EventArgs e)
        {
            xRePos.Enabled = !xReplaceBldnNoMove.Checked;
        }
    }
}
