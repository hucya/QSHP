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
    public partial class BladeRecTabEditManager : BaseForm
    {
        bool saved = false;
        TabData tabData;
        List<TabArgs> args;

        public BladeRecTabEditManager()
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

        public BladeRecTabEditManager(TabData data)
        {
            InitializeComponent();
            TabData = data;
        }

        private void BladeTabEditManager_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                TabData.InitTabData();
                LoadTabDataValue(TabData.SquareTabArgs);
            }
        }

        private void LoadTabDataValue(List<TabArgs> arg)
        {
            args = arg;
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

            zLowPos1.Value = args[0].ZLowPos;
            zLowPos2.Value = args[1].ZLowPos;
            zLowPos3.Value = args[2].ZLowPos;
            zLowPos4.Value = args[3].ZLowPos;
            zLowPos5.Value = args[4].ZLowPos;

            yLength1.Value = args[0].Length;
            yLength2.Value = args[1].Length;
            yLength3.Value = args[2].Length;
            yLength4.Value = args[3].Length;
            yLength5.Value = args[4].Length;

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

            tabWidth1.Value = args[0].TabSize.Width;
            tabWidth2.Value = args[1].TabSize.Width;
            tabWidth3.Value = args[2].TabSize.Width;
            tabWidth4.Value = args[3].TabSize.Width;
            tabWidth5.Value = args[4].TabSize.Width;

            tabHeight1.Value = args[0].TabSize.Height;
            tabHeight2.Value = args[1].TabSize.Height;
            tabHeight3.Value = args[2].TabSize.Height;
            tabHeight4.Value = args[3].TabSize.Height;
            tabHeight5.Value = args[4].TabSize.Height;

            tStartPos1.Value = args[0].StartTpos;
            tStartPos2.Value = args[1].StartTpos;
            tStartPos3.Value = args[2].StartTpos;
            tStartPos4.Value = args[3].StartTpos;
            tStartPos5.Value = args[4].StartTpos;
        }

        private void SaveTabDataValue()
        {
            args[0].TabSize = new SizeF(tabWidth1.Value, tabHeight1.Value);
            args[1].TabSize = new SizeF(tabWidth2.Value, tabHeight2.Value);
            args[2].TabSize = new SizeF(tabWidth3.Value, tabHeight3.Value);
            args[3].TabSize = new SizeF(tabWidth4.Value, tabHeight4.Value);
            args[4].TabSize = new SizeF(tabWidth5.Value, tabHeight5.Value);

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

            args[0].StartTpos = tStartPos1.Value;
            args[1].StartTpos = tStartPos2.Value;
            args[2].StartTpos = tStartPos3.Value;
            args[3].StartTpos = tStartPos4.Value;
            args[4].StartTpos = tStartPos5.Value;


            args[0].Length = yLength1.Value;
            args[1].Length = yLength2.Value;
            args[2].Length = yLength3.Value;
            args[3].Length = yLength4.Value;
            args[4].Length = yLength5.Value;

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
            if (yLength1.Value> tabHeight1.Value)
            {
                yLength1.SetError = true;
                flag = false;
            }
            if (yLength2.Value > tabHeight2.Value)
            {
                yLength2.SetError = true;
                flag = false;
            }
            if (yLength3.Value > tabHeight3.Value)
            {
                yLength3.SetError = true;
                flag = false;
            }
            if (yLength4.Value > tabHeight4.Value)
            {
                yLength4.SetError = true;
                flag = false;
            }
            if (yLength5.Value > tabHeight5.Value)
            {
                yLength5.SetError = true;
                flag = false;
            }
            if (!flag)
            {
                Common.ReportCmdKeyProgress(CmdKey.B0007);
            }
            bool flag1 = true;
            if (tStartPos1.Value < tabData.MinTpos || tStartPos1.Value > tabData.MaxTpos)
            {
                tStartPos1.SetError = true;
                flag1 = false;
            }
            if (tStartPos2.Value < tabData.MinTpos || tStartPos2.Value > tabData.MaxTpos)
            {
                tStartPos2.SetError = true;
                flag1 = false;
            }
            if (tStartPos3.Value < tabData.MinTpos || tStartPos3.Value > tabData.MaxTpos)
            {
                tStartPos3.SetError = true;
                flag1 = false;
            }
            if (tStartPos4.Value < tabData.MinTpos || tStartPos4.Value > tabData.MaxTpos)
            {
                tStartPos4.SetError = true;
                flag1 = false;
            }
            if (tStartPos5.Value < tabData.MinTpos || tStartPos5.Value > tabData.MaxTpos)
            {
                tStartPos5.SetError = true;
                flag1 = false;
            }
            if (!flag1)
            {
                Common.ReportCmdKeyProgress(CmdKey.B0006);
            }
            return flag& flag1;
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

        private void BladeRecTabEditManager_BT0Click(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveTabDataValue();
            }
            this.ParentForm.ReplaceChildForm(new Bld.BladeCirTabEditManager(tabData));
        }

        private void BladeRecTabEditManager_BT2Click(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveTabDataValue();
            }
            this.ParentForm.ReplaceChildForm(new Bld.BladeTestDataEdit(tabData));
        }
    }
}
