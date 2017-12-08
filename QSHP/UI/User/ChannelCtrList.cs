using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.Data;

namespace QSHP.UI.User
{
    public partial class ChannelCtrList : UserControl
    {
        public event EventHandler UserEnabledChanged;
        private byte cHIndex = 0;

        private CutChannel ch;
        [Bindable(true)]
        public CutChannel CH
        {
            get
            {
                return ch;
            }
            set
            {
                ch = value;
                if (ch != null)
                {
                    this.Enabled = ch.Enable;
                    LoadCutChannelData(ch);
                }
            }
        }

        [Bindable(true)]
        public new bool Enabled
        {
            get
            {
                return enableBt.Checked;
            }
            set
            {
                enableBt.Checked = value;
            }
        }

        [Browsable(true)]
        public override string Text
        {
            get
            {
                return enableBt.Text;
            }

            set
            {
                enableBt.Text = value;
            }
        }
        [Browsable(true)]
        public byte CHIndex
        {
            get
            {
                return cHIndex;
            }

            set
            {
                if (value < 11)
                {
                    cHIndex = value;
                    Text = string.Format("CH{0}",cHIndex);
                }
            }
        }

        public ChannelCtrList()
        {
            InitializeComponent();
        }

        private void enableBt_CheckedChanged(object sender, EventArgs e)
        {
            panelEx1.Enabled = enableBt.Checked;
            if (UserEnabledChanged != null)
            {
                UserEnabledChanged(this, null);
            }
        }

        private void LoadCutChannelData(CutChannel c)
        {
            this.Enabled = c.Enable;
            cutSpeed.Value = c.Speed;
            cutLeave.Value = c.ReDepth;
            cutLeave2.Value = c.ReDepth2;
            cutStep.Value = c.IndexStep;
            cutLine.Value = c.TotalLine;
            yOffset.Value = c.YPosAdj;
            tOffset.Value = c.TPosAdj;
            tStartPos.Value = c.TRoatePos;
            pauseLine.Value = c.PauseTick;
            pauseMode.SelectedIndex = c.PauseMode;
            cutDir.SelectedIndex = (int)c.Style;//0 向后  1 向前
        }

        public void SaveCutChannelData()
        {
            if (ch != null)
            {
                ch.Enable = this.Enabled;
                ch.Speed = cutSpeed.Value;
                ch.ReDepth = cutLeave.Value;
                ch.ReDepth2 = cutLeave2.Value;
                ch.IndexStep = cutStep.Value;
                ch.TotalLine = cutLine.Int;
                ch.YPosAdj = yOffset.Value;
                ch.TPosAdj = tOffset.Value;
                ch.TRoatePos = tStartPos.Value;
                ch.PauseTick = pauseLine.Int;
                ch.PauseMode = pauseMode.SelectedIndex;
                ch.StandMode = true;
                ch.Segs.Clear();
                ch.Style = (CutStyle)cutDir.SelectedIndex;
            }
        }

        public void ClearCutChannelData()
        {
            this.enableBt.Checked = false;
            cutSpeed.Value = 0;
            cutLeave.Value = 0;
            cutLeave2.Value = 0;
            cutStep.Value = 0;
            cutLine.Value = 0;
            yOffset.Value = 0;
            tOffset.Value = 0;
            tStartPos.Value = 0;
            pauseLine.Value = 0;
            pauseMode.SelectedIndex = 0;
            cutDir.SelectedIndex = 0;
        }

        public bool  CheckChannelDataIsValid()
        {
            bool flag = true;
            if (Enabled)
            {
                if (cutSpeed.Value == 0)
                {
                    cutSpeed.SetError = true;
                    flag = false;
                }
                if (cutStep.Value == 0)
                {
                    cutStep.SetError = true;
                    flag = false;
                }
                if (cutLine.Value == 0)
                {
                    cutLine.SetError = true;
                    flag = true;
                }
            }
            return flag;
        }
    }
}
