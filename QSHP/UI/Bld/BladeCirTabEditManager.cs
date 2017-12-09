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
    public partial class BladeCirTabEditManager : BaseForm
    {
        bool saved = false;
        TabData tabData;
        List<TabArgs> args;

        public BladeCirTabEditManager()
        {
            InitializeComponent();
        }


        public TabData TabData
        {
            get
            {
                return tabData;
            }

            set
            {
                tabData = value;
            }
        }

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            PointF p = Globals.AxisPoint;
            xStartPos1.Value = p.X;
            yStartPos1.Value = p.Y;
            tStartPos1.Value = Common.T_Axis.RealPos;
        }

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            PointF p = Globals.AxisPoint;
            xStartPos2.Value = p.X;
            yStartPos2.Value = p.Y;
            tStartPos2.Value = Common.T_Axis.RealPos;
        }

        private void buttonEx3_Click(object sender, EventArgs e)
        {
            PointF p = Globals.AxisPoint;
            xStartPos3.Value = p.X;
            yStartPos3.Value = p.Y;
            tStartPos3.Value = Common.T_Axis.RealPos;
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            PointF p = Globals.AxisPoint;
            xStartPos4.Value = p.X;
            yStartPos4.Value = p.Y;
            tStartPos4.Value = Common.T_Axis.RealPos;
        }

        private void buttonEx5_Click(object sender, EventArgs e)
        {
            PointF p = Globals.AxisPoint;
            xStartPos5.Value = p.X;
            yStartPos5.Value = p.Y;
            tStartPos5.Value = Common.T_Axis.RealPos;
        }

        public BladeCirTabEditManager(TabData data)
        {
            InitializeComponent();
            TabData = data;
        }

        private void BladeTabEditManager_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                TabData.InitTabData();
                LoadTabDataValue(TabData.RotateTabArgs);
            }
        }

        private void LoadTabDataValue(List<TabArgs> arg)
        {
            args = arg;
            tabNum.SelectedIndex = TabData.TabIndex;
            tMaxPos.Value = tabData.MaxTpos;
            tMinPos.Value = tabData.MinTpos;
            args = tabData.RotateTabArgs;
            panelEx1.Text = "圆形工作台";
            xStartPos1.Value = args[0].StartXpos;
            xStartPos2.Value = args[1].StartXpos;
            xStartPos3.Value = args[2].StartXpos;
            xStartPos4.Value = args[3].StartXpos;
            xStartPos5.Value = args[4].StartXpos;

            yStartPos1.Value = args[0].StartYpos;
            yStartPos2.Value = args[1].StartYpos;
            yStartPos3.Value = args[2].StartYpos;
            yStartPos4.Value = args[3].StartYpos;
            yStartPos5.Value = args[4].StartYpos;

            tStartPos1.Value = args[0].StartTpos;
            tStartPos2.Value = args[1].StartTpos;
            tStartPos3.Value = args[2].StartTpos;
            tStartPos4.Value = args[3].StartTpos;
            tStartPos5.Value = args[4].StartTpos;

            zLowPos1.Value = args[0].ZLowPos;
            zLowPos2.Value = args[1].ZLowPos;
            zLowPos3.Value = args[2].ZLowPos;
            zLowPos4.Value = args[3].ZLowPos;
            zLowPos5.Value = args[4].ZLowPos;

            tabWidth1.Value = args[0].TabSize.Width;
            tabWidth2.Value = args[1].TabSize.Width;
            tabWidth3.Value = args[2].TabSize.Width;
            tabWidth4.Value = args[3].TabSize.Width;
            tabWidth5.Value = args[4].TabSize.Width;



            xPos1.Value = args[0].CurXpos;
            xPos2.Value = args[1].CurXpos;
            xPos3.Value = args[2].CurXpos;
            xPos4.Value = args[3].CurXpos;
            xPos5.Value = args[4].CurXpos;

            yPos1.Value = args[0].CurYpos;
            yPos2.Value = args[1].CurYpos;
            yPos3.Value = args[2].CurYpos;
            yPos4.Value = args[3].CurYpos;
            yPos5.Value = args[4].CurYpos;

            tPos1.Value = args[0].CurTpos;
            tPos2.Value = args[1].CurTpos;
            tPos3.Value = args[2].CurTpos;
            tPos4.Value = args[3].CurTpos;
            tPos5.Value = args[4].CurTpos;
        }

        private void SaveTabDataValue()
        {
            tabData.MaxTpos = tMaxPos.Value;
            tabData.MinTpos = tMinPos.Value;

            args[0].TabSize = new SizeF(tabWidth1.Value, tabWidth1.Value);
            args[1].TabSize = new SizeF(tabWidth2.Value, tabWidth2.Value);
            args[2].TabSize = new SizeF(tabWidth3.Value, tabWidth3.Value);
            args[3].TabSize = new SizeF(tabWidth4.Value, tabWidth4.Value);
            args[4].TabSize = new SizeF(tabWidth5.Value, tabWidth5.Value);

            args[0].StartXpos = xStartPos1.Value;
            args[1].StartXpos = xStartPos2.Value;
            args[2].StartXpos = xStartPos3.Value;
            args[3].StartXpos = xStartPos4.Value;
            args[4].StartXpos = xStartPos5.Value;

            args[0].StartYpos = yStartPos1.Value;
            args[1].StartYpos = yStartPos2.Value;
            args[2].StartYpos = yStartPos3.Value;
            args[3].StartYpos = yStartPos4.Value;
            args[4].StartYpos = yStartPos5.Value;


            args[0].StartTpos= tStartPos1.Value;
            args[1].StartTpos = tStartPos2.Value;
            args[2].StartTpos = tStartPos3.Value;
            args[3].StartTpos = tStartPos4.Value;
            args[4].StartTpos = tStartPos5.Value;


            args[0].ZLowPos = zLowPos1.Value;
            args[1].ZLowPos = zLowPos2.Value;
            args[2].ZLowPos = zLowPos3.Value;
            args[3].ZLowPos = zLowPos4.Value;
            args[4].ZLowPos = zLowPos5.Value;

            Globals.TabData = tabData;
            Globals.TabData.SaveTabDataFile(Globals.AppCfg.TabFileFullPath);
        }

        private bool CheckTabValueIsValid()
        {
            bool flag = true;
            if (tMaxPos.Value <= tMinPos.Value)
            {
                tMaxPos.SetError = true;
                flag = false;
            }
            if (tStartPos1.Value < tMinPos.Value || tStartPos1.Value > tMaxPos.Value)
            {
                tStartPos1.SetError = true;
                flag = false;
            }
            if (tStartPos2.Value < tMinPos.Value || tStartPos2.Value > tMaxPos.Value)
            {
                tStartPos2.SetError = true;
                flag = false;
            }
            if (tStartPos3.Value < tMinPos.Value || tStartPos3.Value > tMaxPos.Value)
            {
                tStartPos3.SetError = true;
                flag = false;
            }
            if (tStartPos4.Value < tMinPos.Value || tStartPos4.Value > tMaxPos.Value)
            {
                tStartPos4.SetError = true;
                flag = false;
            }
            if (tStartPos5.Value < tMinPos.Value || tStartPos5.Value > tMaxPos.Value)
            {
                tStartPos5.SetError = true;
                flag = false;
            }
            if (!flag)
            {
                Common.ReportCmdKeyProgress(CmdKey.B0006);
            }
            return flag;
        }

        private void BladeTabEditManager_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveTabDataValue();
            }
            this.ParentForm.OnCancelClick();
        }

        private void BladeTabEditManager_ConfirmClick(object sender, EventArgs e)
        {
            saved = CheckTabValueIsValid();
            if (saved)
            {
                Common.ReportCmdKeyProgress(CmdKey.B0008);
            }
        }

        private void BladeCirTabEditManager_BT1Click(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveTabDataValue();
            }
            this.ParentForm.ReplaceChildForm(new Bld.BladeRecTabEditManager(tabData));
        }

        private void BladeCirTabEditManager_BT2Click(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveTabDataValue();
            }
            this.ParentForm.ReplaceChildForm(new Bld.BladeTestDataEdit(tabData));
        }
    }
}
