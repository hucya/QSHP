using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI.Ctr
{
    public class PictureBoxEx:Panel
    {
        public Image Image
        {
            get;
            set;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
        }
        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            //if (this.Image != null)
            //{
            //    pevent.Graphics.DrawImageUnscaled(this.Image, new Point(0, 0));
            //}
        }
    }
}
