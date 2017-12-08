using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace QSHP.UI.Ctr
{
    [DefaultProperty("Text"), Description("Description PanelEx")]
    public class PanelEx:Panel
    {
        private Font headerFont= new System.Drawing.Font("微软雅黑", 18F);

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),Bindable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                OnPaintBackground(new PaintEventArgs(this.CreateGraphics(),this.Bounds));
            }
        }
        public PanelEx() : base()
        {
            this.DoubleBuffered = true;
            this.Font= new System.Drawing.Font("微软雅黑", 12F);
        }
        public bool LeftMode
        {
            get
            {
                return leftMode;
            } 
            set
            {
                leftMode = value;
                OnPaintBackground(new PaintEventArgs(this.CreateGraphics(),this.Bounds));
            }
        }

        public Font HeaderFont 
        { 
            get 
            {
                return headerFont; 
            }

            set
            {
                headerFont = value;
            }
        }

        private bool leftMode = false;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            GroupBoxState state = this.Enabled ? GroupBoxState.Normal : GroupBoxState.Disabled;
            if (string.IsNullOrWhiteSpace(base.Text))
            {
                GroupBoxRenderer.DrawGroupBox(e.Graphics, new System.Drawing.Rectangle(1, 1, this.Width - 2, this.Height - 2), state);
            }
            else
            {
                if (LeftMode)
                {
                    GroupBoxRenderer.DrawGroupBox(e.Graphics, new System.Drawing.Rectangle(1, 1, this.Width - 2, this.Height - 2), base.Text, this.headerFont, state);
                }
                else
                {
                    GroupBoxRenderer.DrawGroupBox(e.Graphics, new System.Drawing.Rectangle(1, 1, this.Width - 2, this.Height - 2), base.Text, this.headerFont, TextFormatFlags.Right, state);
                }
            }
        }
        
    }
}
