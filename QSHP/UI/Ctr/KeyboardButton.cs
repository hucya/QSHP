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
    internal class KeyboardButton : Button
    {
        private Color defaultStartColor;
        private Color defautEndColor;
        private Color mouseEnterStartColor;
        private Color mouseEnterEndColor;
        private Color mouseDownStartColor;
        private Color mouseDownEndColor;
        private Color defaultBorderColor;
        private Color mouseEnterBorderColor;

        private Color currentStartColor;
        private Color currentEndColor;
        private Color currentBorderColor;

        private bool antialias;
        private bool isChecked;
        private bool showFocusRectangle;
        private short vkCode;

        private static readonly object EventCheckChanged = new object();

        public KeyboardButton()
            : base()
        {
            base.Size = new System.Drawing.Size(107, 31);
            base.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

            this.defaultStartColor = Color.FromArgb(214, 230, 251);
            this.defautEndColor = Color.FromArgb(154, 187, 234);
            this.mouseEnterStartColor = Color.FromArgb(255, 240, 197);
            this.mouseEnterEndColor = Color.FromArgb(255, 213, 152);
            this.mouseDownStartColor = Color.FromArgb(254, 151, 84);
            this.mouseDownEndColor = Color.FromArgb(255, 199, 131);
            this.defaultBorderColor = Color.FromArgb(59, 97, 156);
            this.mouseEnterBorderColor = Color.FromArgb(0, 0, 128);

            this.currentStartColor = this.defaultStartColor;
            this.currentEndColor = this.defautEndColor;
            this.currentBorderColor = this.defaultBorderColor;
            this.antialias = true;
            this.isChecked = false;
            this.showFocusRectangle = false;
            this.Margin = new System.Windows.Forms.Padding(1);
            SetStyle(ControlStyles.Selectable, false);
            base.Paint += new PaintEventHandler(LifeButton_Paint);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x08000080;
                return cp;
            }
        }

        [Category("Data")]
        public short VKCode
        {
            get
            {
                return this.vkCode;
            }
            set
            {
                this.vkCode = value;
            }
        }

        [Category("Appearance")]
        public Color DefaultStartColor
        {
            get
            {
                return this.defaultStartColor;
            }
            set
            {
                this.defaultStartColor = value;
            }
        }

        [Category("Appearance")]
        public Color DefautEndColor
        {
            get
            {
                return this.defautEndColor;
            }
            set
            {
                this.defautEndColor = value;
            }
        }

        [Category("Appearance")]
        public Color MouseEnterStartColor
        {
            get
            {
                return this.mouseEnterStartColor;
            }
            set
            {
                this.mouseEnterStartColor = value;
            }
        }

        [Category("Appearance")]
        public Color MouseEnterEndColor
        {
            get
            {
                return this.mouseEnterEndColor;
            }
            set
            {
                this.mouseEnterEndColor = value;
            }
        }

        [Category("Appearance")]
        public Color MouseDownStartColor
        {
            get
            {
                return this.mouseDownStartColor;
            }
            set
            {
                this.mouseDownStartColor = value;
            }
        }

        [Category("Appearance")]
        public Color MouseDownEndColor
        {
            get
            {
                return this.mouseDownEndColor;
            }
            set
            {
                this.mouseDownEndColor = value;
            }
        }

        [Category("Appearance")]
        public Color DefaultBorderColor
        {
            get
            {
                return this.defaultBorderColor;
            }
            set
            {
                this.defaultBorderColor = value;
            }
        }

        [Category("Appearance")]
        public Color MouseEnterBorderColor
        {
            get
            {
                return this.mouseEnterBorderColor;
            }
            set
            {
                this.mouseEnterBorderColor = value;
            }
        }

        [Browsable(false)]
        public Color CurrentBorderColor
        {
            get
            {
                return this.currentBorderColor;
            }
        }

        [Category("Appearance")]
        public bool AntiAlias
        {
            get
            {
                return this.antialias;
            }
            set
            {
                this.antialias = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        public bool ShowFocusRectangle
        {
            get
            {
                return this.showFocusRectangle;
            }
            set
            {
                this.showFocusRectangle = value;
            }
        }

        [Category("Appearance")]
        public bool Checked
        {
            get
            {
                return this.isChecked;
            }
            set
            {
                this.isChecked = value;
                this.Invalidate();

                CheckChangedEventArgs args = new CheckChangedEventArgs(this.isChecked);
                OnCheckChanged(args);
            }
        }

        public event EventHandler<CheckChangedEventArgs> CheckChanged
        {
            add
            {
                base.Events.AddHandler(EventCheckChanged, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventCheckChanged, value);
            }
        }

        protected virtual void OnCheckChanged(CheckChangedEventArgs args)
        {
            EventHandler<CheckChangedEventArgs> handler = base.Events[EventCheckChanged] as EventHandler<CheckChangedEventArgs>;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void LifeButton_Paint(object sender, PaintEventArgs pevent)
        {
            if (this.ClientSize.Width > 3 && this.ClientSize.Height > 3)
            {
                Graphics g = pevent.Graphics;

                if (this.antialias)
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                }
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                Brush fillBrush = this.isChecked ?
                    new LinearGradientBrush(base.ClientRectangle, this.mouseDownStartColor, this.mouseDownEndColor, LinearGradientMode.Vertical) :
                    new LinearGradientBrush(base.ClientRectangle, this.currentStartColor, this.currentEndColor, LinearGradientMode.Vertical);

                g.FillRectangle(fillBrush, base.ClientRectangle);
                fillBrush.Dispose();
                if (this.BackgroundImage != null)
                {
                    g.DrawImage(base.BackgroundImage, rect);
                }

                using (Pen pen = new Pen(this.isChecked ? this.mouseEnterBorderColor : this.currentBorderColor, 1))
                {
                    g.DrawRectangle(pen, rect);
                    if (base.Focused && this.showFocusRectangle)
                    {
                        pen.Color = this.defaultBorderColor;
                        pen.DashStyle = DashStyle.Dot;
                        rect.Inflate(-2, -2);
                        g.DrawRectangle(pen, rect);
                    }
                }

                StringFormat format = new StringFormat();
                SetTextAlign(format);
                format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

                using (Brush brush = new SolidBrush(base.ForeColor))
                {
                    if (rect.Width > 4 && rect.Height > 2)
                    {
                        rect.Inflate(-4, -2);
                        g.DrawString(base.Text, base.Font, (this.Enabled ? brush : Brushes.Gray), rect, format);
                    }
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.currentStartColor = this.mouseEnterStartColor;
            this.currentEndColor = this.mouseEnterEndColor;
            this.currentBorderColor = this.mouseEnterBorderColor;

            this.Invalidate();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.currentStartColor = this.defaultStartColor;
            this.currentEndColor = this.defautEndColor;
            this.currentBorderColor = this.defaultBorderColor;

            this.Invalidate();

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            this.currentStartColor = this.mouseDownStartColor;
            this.currentEndColor = this.mouseDownEndColor;

            this.Invalidate();

            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            this.currentStartColor = this.mouseEnterStartColor;
            this.currentEndColor = this.mouseEnterEndColor;

            base.OnMouseUp(mevent);
        }

        private void SetTextAlign(StringFormat format)
        {
            string textAlign = base.TextAlign.ToString("G");

            if (textAlign.IndexOf("Right") >= 0)
            {
                format.Alignment = StringAlignment.Far;
            }
            else if (textAlign.IndexOf("Center") >= 0)
            {
                format.Alignment = StringAlignment.Center;
            }
            else if (textAlign.IndexOf("Left") >= 0)
            {
                format.Alignment = StringAlignment.Near;
            }

            if (textAlign.IndexOf("Bottom") >= 0)
            {
                format.LineAlignment = StringAlignment.Far;
            }
            else if (textAlign.IndexOf("Middle") >= 0)
            {
                format.LineAlignment = StringAlignment.Center;
            }
            else if (textAlign.IndexOf("Top") >= 0)
            {
                format.LineAlignment = StringAlignment.Near;
            }
        }
    }

    public class CheckChangedEventArgs : EventArgs
    {
        private bool isChecked;

        public CheckChangedEventArgs(bool isChecked)
            : base()
        {
            this.isChecked = isChecked;
        }

        public bool Checked
        {
            get
            {
                return this.isChecked;
            }
            set
            {
                this.isChecked = value;
            }
        }
    }


}
