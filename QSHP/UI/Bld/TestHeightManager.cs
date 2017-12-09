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
    public partial class TestHeightManager : BaseForm
    {
        string format = "0.###";
        string[] tabNums = { "一号工作台","二号工作台","三号工作台","四号工作台","五号工作台"};
        string[] tabTypes = { "圆形", "方形" };
        string[] names = { "接触式测高", "非接触测高" , "NCS矫正" };
        int mode = 0;
        TabData tabData;
        public TestHeightManager()
        {
            InitializeComponent();
        }

        public TestHeightManager(int m= 0)
        {
            InitializeComponent();
            if (m > 2)
            {
                mode = 2;
            }
            mode = m;
            this.Text = names[m];
            this.panelEx1.Text = names[m];
        }

        public void LoadTestData(bool show=false)
        {
            panel1.Visible = mode > 0;
            panel2.Visible = mode > 0;
            if (mode > 0)
            {
                panel3.Location= new Point(112,19);
                panel4.Location = new Point(112, 28);
            }
            else
            {
                panel3.Location = new Point(275, 19);
                panel4.Location = new Point(275, 28);
            }
            tabData = Globals.TabData;
            bldNum.Text = Globals.BladeData.BldNum;
            bldMode.Text = Globals.BladeData.BldModel;
            spdSpeed.Text = tabData.SpdSpeed.ToString();
            tabNum.Text = tabNums[tabData.TabIndex];
            tabType.Text = tabTypes[tabData.UsedTable.RotateType?0:1];
            tabSize.Text = string.Format("{0} * {1}", tabData.UsedTabSize.Width, tabData.UsedTabSize.Height);
            csXpos.Text = tabData.UsedTable.CurXpos.ToString(format);
            csYpos.Text = tabData.UsedTable.CurYpos.ToString(format);
            csZpos.Text = tabData.UsedTable.ZLowPos.ToString(format);
            csTpos.Text = tabData.UsedTable.CurTpos.ToString(format);

            ncsXpos.Text = tabData.NcsXpos.ToString(format);
            ncsYpos.Text = tabData.NcsYpos.ToString(format);
            ncsZpos.Text = tabData.NcsZlowPos.ToString(format);

            csValue.Text = tabData.CsTestValue.ToString(format);
            ncsValue.Text = tabData.NcsTestValue.ToString(format);

        }

        private void TestHeightManager_Load(object sender, EventArgs e)
        {
            Common.ProgressWorkingChanged += new ProgressChangedEventHandler(Common_ProgressWorkingChanged);
            LoadTestData();
        }

        void Common_ProgressWorkingChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case ProcessCmd.CsTestingStartCmd:
                    {
                        csValue.ForeColor = Color.Blue;
                    }break;
                case ProcessCmd.CsTestingErrCmd:
                    {
                        csValue.Text = Globals.TestHeightValue.ToString(format);
                        csValue.ForeColor = Color.Red;
                    }break;
                case ProcessCmd.CsTestingEndCmd:
                    {
                        csValue.Text = Globals.TestHeightValue.ToString(format);
                        csValue.ForeColor = Color.Green;
                    }break;
                case ProcessCmd.CsTestingTickCmd:
                    {
                        csYpos.Text = Common.Y_Axis.RealPos.ToString(format);
                        csTpos.Text = Common.T_Axis.RealPos.ToString(format);
                        csValue.Text = e.UserState.ToString();
                        csValue.ForeColor = Color.Orange;
                    }break;
                default:
                    { 
                    }break;
            }

               
        }

        private void TestHeightManager_ConfirmClick(object sender, EventArgs e)
        {
            Globals.TestCancel = false;
            Common.SetSystemWorkMode(SysFunState.TouchTesting);
        }

        private void TestHeightManager_CancelClick(object sender, EventArgs e)
        {
            Globals.TestCancel = true;
            Common.ProgressWorkingChanged -=Common_ProgressWorkingChanged;
            if (this.ParentForm != null)
            {
                this.ParentForm.OnCancelClick();
            }
        }
    }
}
