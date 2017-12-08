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
    public partial class SegmentCtr : UserControl
    {
        public event EventHandler UserEnabledChanged;
        int segIndex = 0;
        CutSegment seg;

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
        public int SegIndex
        {
            get
            {
                return segIndex;
            }

            set
            {
                if (value < 11)
                {
                    segIndex = value;
                    Text = string.Format("Seg{0}", segIndex);
                }
            }
        }
        [Browsable(true)]
        public CutSegment Seg
        {
            get
            {
                return seg;
            }

            set
            {
                seg = value;
                if (seg != null)
                {
                    this.Enabled = seg.Enable;
                    LoadCutSegmentData(seg);
                }
            }
        }

        
        public SegmentCtr()
        {
            InitializeComponent();
        }

        private void LoadCutSegmentData(CutSegment s)
        {
            this.Enabled = s.Enable;
            cutSpeed.Value = s.Speed;
            cutLeave.Value = s.ReDepth;
            cutLeave2.Value = s.ReDepth2;
            cutStep.Value = s.IndexStep;
            cutLine.Value = s.TotalLine;
        }
        public void SaveCutSegmentData()
        {
            if (seg != null)
            {
                seg.Enable = this.Enabled;
                seg.Speed = cutSpeed.Value;
                seg.ReDepth = cutLeave.Value;
                seg.ReDepth2 = cutLeave2.Value;
                seg.IndexStep = cutStep.Value;
                seg.TotalLine = cutLine.Int;
            }
        }
        public void ClearCutSegmentData()
        {
            this.enableBt.Checked = false;
            cutSpeed.Value = 0;
            cutLeave.Value = 0;
            cutLeave2.Value = 0;
            cutStep.Value = 0;
            cutLine.Value = 0;
        }
        public bool CheckChannelDataIsValid()
        {
            if (Enabled)
            {
                bool flag = true;
                if (cutLine.Value == 0)
                {
                    cutLine.SetError = true;
                    flag = false;
                }
                if (cutStep.Value == 0)
                {
                    cutStep.SetError =true;
                    flag = false;
                }
                if (cutSpeed.Value == 0)
                {
                    cutSpeed.SetError = true;
                    flag = false;
                }
                return flag;
            }
            return true;
        }
        private void EnableBt_CheckedChanged(object sender, EventArgs e)
        {
            panelEx1.Enabled = enableBt.Checked;
            if (UserEnabledChanged != null)
            {
                UserEnabledChanged(this, null);
            }
        }
    }
}
