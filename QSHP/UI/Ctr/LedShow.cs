using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QSHP.UI.Ctr
{
    public partial class LedShow : UserControl
    {
        public LedShow()
        {
            this.Size = new Size(40, 40);
            this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Properties.Resources.None;
            using (System.Drawing.Drawing2D.GraphicsPath g = new System.Drawing.Drawing2D.GraphicsPath())
            {
                g.AddEllipse(0,0,this.Width,this.Height);
                this.Region = new Region(g);
            }
        }
        private LedStatus status = LedStatus.None;
        [Browsable(false),EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
        [DefaultValue(LedStatus.None)]
        public LedStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                if (status != value)
                {
                    status = value;
                    switch (value)
                    {
                        case LedStatus.None:
                            {
                                this.BackgroundImage = Properties.Resources.None;
                            }break;
                        case LedStatus.OK:
                            {
                                this.BackgroundImage = Properties.Resources.OK;
                            } break;
                        case LedStatus.Warn:
                            {
                                this.BackgroundImage = Properties.Resources.Warn;
                            } break;
                        case LedStatus.Error:
                            {
                                this.BackgroundImage = Properties.Resources.Error;
                            } break;
                    }
                    Invalidate();
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            using (System.Drawing.Drawing2D.GraphicsPath g = new System.Drawing.Drawing2D.GraphicsPath())
            {
                g.AddEllipse(0, 0, this.Width, this.Height);
                this.Region = new Region(g);
            }
        }
    }

    public enum LedStatus
    { 
        None=0,
        OK=1,
        Error=2,
        Warn=3
    }
}
