using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.Data;
namespace QSHP.UI
{
    public partial class PreCutDataManager : BaseForm
    {
        PreData pre;
        bool rePair = true;
        bool saved = false;
        public PreCutDataManager()
        {
            InitializeComponent();
        }
        public PreCutDataManager(PreData p, bool re = true)
        {
            InitializeComponent();
            pre = p;
            rePair = re;
        }

        private void PreMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (preMode.SelectedIndex == 0)//自定义模式
            {
                panelEx4.Enabled = true;
                panelEx3.Enabled = false;
            }
            else//自动模式
            {
                panelEx3.Enabled = true;
                panelEx4.Enabled = false;
            }
        }

        private void PreCutDataManager_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadPreDataValue(pre);
            }
        }

        private void LoadPreDataValue(PreData p)
        {
            p.InitUserData();
            preNum.Value = p.Index;
            preID.Text = p.ID;
            preMode.SelectedIndex = p.AutoMode ? 1 : 0;
            PreMode_SelectedIndexChanged(this, null);
            startSpeed.Value = p.StartSpeed;
            endSpeed.Value = p.EndSpeed;
            incSpeed.Value = p.IncSpeed;
            preLine.Value = p.PreLine;
            speed1.Value = p[0].Speed;
            line1.Value = p[0].Line;
            speed2.Value = p[1].Speed;
            line2.Value = p[1].Line;
            speed3.Value = p[2].Speed;
            line3.Value = p[2].Line;
            speed4.Value = p[3].Speed;
            line4.Value = p[3].Line;
            speed5.Value = p[4].Speed;
            line5.Value = p[4].Line;
            speed6.Value = p[5].Speed;
            line6.Value = p[5].Line;
            speed7.Value = p[6].Speed;
            line7.Value = p[6].Line;
            speed8.Value = p[7].Speed;
            line8.Value = p[7].Line;
            speed9.Value = p[8].Speed;
            line9.Value = p[8].Line;
            speed10.Value = p[9].Speed;
            line10.Value = p[9].Line;
        }

        private void SavePreDataValue()
        {
            if (pre != null)
            {
                pre.Index = preNum.Int;
                pre.ID = preID.Text;
                pre.AutoMode = preMode.SelectedIndex > 0;
                pre.StartSpeed = startSpeed.Value;
                pre.EndSpeed = endSpeed.Value;
                pre.IncSpeed = incSpeed.Value;
                pre.PreLine = preLine.Int;

                pre[0].Speed = speed1.Value;
                pre[0].Line = line1.Int;
                pre[1].Speed = speed2.Value;
                pre[1].Line = line2.Int;
                pre[2].Speed = speed3.Value;
                pre[2].Line = line3.Int;
                pre[3].Speed = speed4.Value;
                pre[3].Line = line4.Int;
                pre[4].Speed = speed5.Value;
                pre[4].Line = line5.Int;
                pre[5].Speed = speed6.Value;
                pre[5].Line = line6.Int;
                pre[6].Speed = speed7.Value;
                pre[6].Line = line7.Int;
                pre[7].Speed = speed8.Value;
                pre[7].Line = line8.Int;
                pre[8].Speed = speed9.Value;
                pre[8].Line = line9.Int;
                pre[9].Speed = speed10.Value;
                pre[9].Line = line10.Int;
            }
        }

        private bool CheckPreDataIsValid()
        {
            bool flag = true;
            if(endSpeed.Value<startSpeed.Value)
            {
                Common.ReportCmdKeyProgress(CmdKey.F0032);
                endSpeed.SetError = true;
                flag = false;
            }
            if(incSpeed.Value>Math.Abs(endSpeed.Value - startSpeed.Value))
            {
                Common.ReportCmdKeyProgress(CmdKey.F0033);
                incSpeed.SetError = true;
                flag = false;
            }
            if(preMode.SelectedIndex>0)
            {
                if(preLine.Value<1)
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0034);
                    preLine.SetError = true;
                    flag = false;
                }
            }
            return flag;
        }

        private void PreCutDataManager_ConfirmClick(object sender, EventArgs e)
        {
            if(CheckPreDataIsValid())
            {
                saved = true;
                CutDataManager.saved = true;
                Common.ReportCmdKeyProgress(CmdKey.F0035);
            }
        }

        private void PreCutDataManager_CancelClick(object sender, EventArgs e)
        {
            if (rePair && saved)
            {
                SavePreDataValue();
            }
            if (this.ParentForm != null)
            {
                this.ParentForm.OnCancelClick();
            }
        }
    }
}
