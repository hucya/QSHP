using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.HW.Video;
namespace QSHP.UI.Ctr
{
      [ToolboxItem(false)]
    public partial class VideoControlEx : UserControl
    {
        IVideoProvider captureProvider;
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
                groupBox1.ForeColor = value;
            }
        }
        public IVideoProvider CaptureProvider
        {
            get 
            { 
                return captureProvider; 
            }
            set 
            { 
                 captureProvider = value;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public VideoControlEx()
        {
            InitializeComponent();
            RV.DataBindings.Add("Text", Rbar, "Value",true);
            TV.DataBindings.Add("Text", Tbar, "Value", true);
        }

        private void Rbar_ValueChanged(object sender, EventArgs e)
        {
            if (captureProvider != null)
            {
                if (captureProvider.IsRunning)
                {
                    captureProvider.Gain = (byte)Rbar.Value;
                }
            }
        }

        private void Tbar_ValueChanged(object sender, EventArgs e)
        {
            if (captureProvider != null)
            {
                if (captureProvider.IsRunning)
                {
                    captureProvider.Exposure = Tbar.Value;
                }
            }
        }

        private void VideoControlEx_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && captureProvider != null&&captureProvider.IsRunning)
            {
                Tbar.Value = captureProvider.Exposure;
                Rbar.Value = captureProvider.Gain;
                switch (captureProvider.AdcMode)
                {
                    case 2:
                        {
                            Lrb.Checked = true;
                        } break;
                    case 1:
                        {
                            Mrb.Checked = true;
                        } break;
                    case 0:
                        {
                            Hrb.Checked = true;
                        } break;
                    default:
                        {
                            Hrb.Checked = true;
                        } break;
                }
                this.Enabled = true;
            }
            else
            {
                this.Enabled = false;
            }
        }

        private void Hrb_CheckedChanged(object sender, EventArgs e)
        {
            if (Hrb.Checked && captureProvider != null)
            {
                captureProvider.AdcMode = 0;
            }
        }

        private void Mrb_CheckedChanged(object sender, EventArgs e)
        {
            if (Mrb.Checked && captureProvider != null)
            {
                captureProvider.AdcMode = 1;
            }
        }

        private void Lrb_CheckedChanged(object sender, EventArgs e)
        {
            if (Lrb.Checked && captureProvider != null)
            {
                captureProvider.AdcMode = 2;
            }
        }
    }
}
