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
    public partial class BladeMessageForm : BaseForm
    {
        BldData bldData;
        const string format = "0.####";

        public BladeMessageForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                LoadBladeData(Globals.BldData);
                Common.ReportCmdKeyProgress(CmdKey.B0001);
                if (Globals.Cutting)
                {
                    AutoUpdateEventHander += BladeMessageFrom_AutoUpdataEventHander;
                }
            }
        }

        private void BladeMessageFrom_AutoUpdataEventHander(object sender, EventArgs e)
        {
            LoadBladeData(Globals.BldData);
        }

        private void BladeMessageFrom_BT0Click(object sender, EventArgs e)
        {
            ClearBldData();
        }

        public void LoadBladeData(BldData data)
        {
            bldData = data;
            this.bldDataBindingSource.DataSource = bldData;
            panel1.Visible = Globals.NoTouchTest;
            if (Globals.NoTouchTest)
            {
                ncsOffset.Text = Globals.TabData.NcsOffset.ToString(format);
                ncsTestHeight.Text = Globals.TabData.NcsTestValue.ToString(format);
            }
            testingSpdSpeed.Text = Globals.TabData.SpdSpeed.ToString();
            if (Globals.DoubleCap)
            {
                label4.Text = "刀痕偏移Lo/Hi(mm):";
                bladeOffsetLo.Text = bldData.KnifeMarksOffsetHi.ToString(format)+"/" + bldData.KnifeMarksOffsetLo.ToString(format);
            }
            else
            {
                label4.Text = "刀痕偏移值(mm):";
                bladeOffsetLo.Text = bldData.KnifeMarksOffsetHi.ToString(format);
            }
            bladeDiameter.Text = bldData.BldDiameter.ToString(format)+"/"+bldData.FlangeDiameter.ToString(format);
            
        }

        public void ClearBldData()
        {
            if(bldData!=null)
            {
                bldData.SetCurrentValueClear();
                pieceAfterClear.Text = bldData.PieceAfterClear.ToString();
                linesAfterClear.Text = bldData.LinesAfterClear.ToString();
                bldLossAfterClear.Text = bldData.BldLossAfterClear.ToString(format);
                lengthAfterClear.Text = bldData.LenAfterClear.ToString(format);
                bldData.SaveBladeDataFile(Globals.AppCfg.BladeFileFullName);//保存当前文档
                Common.ReportCmdKeyProgress(CmdKey.B0002);
            }
        }
    }
}
