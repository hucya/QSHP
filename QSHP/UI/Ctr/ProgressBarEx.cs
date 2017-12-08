using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace QSHP.UI.Ctr
{
    public class ProgressBarEx:ProgressBar
    {
        Pen pen=new Pen(Color.Blue,2);
        Color fontColor = Color.Black;
        SolidBrush brush= new SolidBrush(Color.Blue);
        SolidBrush fontBrush = new SolidBrush(Color.Black);
        
        string format = "{0}";
        public string StringFormat
        {
            get
            {
                return format;
            }
            set
            {
                if (value.Contains("{0}"))
                {
                    format = value;
                }
                //this.Invalidate();
            }
        }
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return String.Format(format,Value);
            }
        }
        [Browsable(true)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
                this.Invalidate();
            }
        }
        [Browsable(true)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;  
            }
            set
            {
                base.ForeColor = value;
                pen.Color = value;
                brush.Color = value;
                this.Invalidate();
            }
        }

        public Color FontColor
        {
            get
            {
                return fontColor;
            }

            set
            {
                fontColor = value;
                fontBrush.Color = value;
                this.Invalidate();
            }
        }

        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = this.ClientRectangle;
            Graphics g = e.Graphics;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(new SolidBrush(this.BackColor), rec);
            g.DrawRectangle(pen, rec);
            int h = rec.Height -= 4;
            int w = (int)(rec.Width * Value / Maximum) - 4;
            g.FillRectangle(brush, 2, 2, w, h);
            SizeF s = g.MeasureString(Text, this.Font);
            PointF p = new PointF((rec.Width-s.Width)/2,(rec.Height-this.FontHeight)/2);
            g.DrawString(Text,Font,fontBrush,p);
        }
    }
}
