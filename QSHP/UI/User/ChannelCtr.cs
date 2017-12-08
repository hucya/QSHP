using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.Data;

namespace QSHP.UI
{
    public partial class ChannelCtr : UserControl
    {
        private CutChannel ch;
        private float length = 100;
        private int channel = 1;
        [Bindable(false)]
        public CutChannel CH
        {
            get
            {
                return ch;
            }
            set
            {
                ch = value;
                if (value != null)
                {
                    LoadChannelDataValue(ch);
                }
            }
        }

        public ChannelCtr()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public int Channel
        {
            get
            {
                return channel;
            }
            set
            {
                channel = value;
                groupBox.Text = string.Format("CH{0} 通道", value);
            }
        }

        [Browsable(false)]
        public float Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
                cutNum.Value = (int)Math.Floor(length / stepEdit.Value) + 1;
                cutNum.SetWarn = true;
            }
        }


        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ch != null)
            {
                ch.Style = (CutStyle)pauseStyle.SelectedIndex;
            }
        }


        public bool CheckValueIsValid()
        {
            bool flag = true;
            if (CH != null)
            {
                ch.Enable = this.Enabled;
                ch.TotalLine = cutNum.Int;
                ch.Style = (CutStyle)pauseStyle.SelectedIndex;
                if (cutSpeed.Value <= 0)
                {
                    cutSpeed.SetError = true;
                    flag &= false;
                }
                if (stepEdit.Value > ch.Length)
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0029);
                    stepEdit.SetError = true;
                    flag &= false;
                }
                if (stepEdit2.Value > ch.Length)
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0029);
                    stepEdit2.SetError = true;
                    flag &= false;
                }
                if (cycleTime.Value > 0)
                {
                    cycleTime.SetWarn = true;
                }
                if (pauseValue.Value != 0)
                {
                    switch (pauseStyle.SelectedIndex)
                    {
                        case 1:
                            {
                                if (pauseValue.Value >= cutNum.Value / 2)
                                {
                                    Common.ReportCmdKeyProgress(CmdKey.F0030);
                                    pauseValue.SetError = true;
                                    flag &= false;
                                }
                            }
                            break;
                        case 2:
                        case 3:
                            {
                                if (pauseValue.Value >= cutNum.Value)
                                {
                                    Common.ReportCmdKeyProgress(CmdKey.F0030);
                                    pauseValue.SetError = true;
                                    flag &= false;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return flag;
        }

        public void SaveChannelDataValue()
        {
            if (ch != null)
            {
                ch.Enable = this.Enabled;
                ch.TRoatePos = rotatePos.Value;
                ch.Speed = cutSpeed.Value;
                ch.PauseTick = pauseValue.Int;
                ch.PauseMode = pauseStyle.SelectedIndex;
                ch.IndexStep = stepEdit.Value;
                ch.IndexStep2 = stepEdit2.Value;
                ch.TotalLine = cutNum.Int;
                ch.CycleCount = cycleTime.Int;
                ch.YPosAdj = yOffset.Value;
                ch.TPosAdj = tOffset.Value;
                ch.Style = (CutStyle)cutStyle.SelectedIndex;
            }
        }
        public void LoadChannelDataValue(CutChannel c)
        {
            this.Enabled = ch.Enable;
            cutSpeed.Value = ch.Speed;
            rotatePos.Value = ch.TRoatePos;
            pauseValue.Value = ch.PauseTick;
            pauseStyle.SelectedIndex = ch.PauseMode;
            stepEdit.Value = ch.IndexStep;
            stepEdit2.Value = ch.IndexStep2;
            cutNum.Value = ch.TotalLine;
            cycleTime.Value = ch.CycleCount;
            yOffset.Value = ch.YPosAdj;
            tOffset.Value = ch.TPosAdj;
            cutStyle.SelectedIndex = (int)ch.Style;
        }

        private void IndexStep_ValueChanged(object sender, EventArgs e)
        {
            cutNum.Value = (int)Math.Floor(Length / stepEdit.Value) + 1;
            cutNum.SetWarn = true;
        }
    }
}
