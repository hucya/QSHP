using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.Com;

namespace QSHP.UI.Ctr
{
    public class ButtonEx : Button
    {
        bool pressed = false;
        BtMode mode = BtMode.Normal;
        bool locker = true;
        string numText = string.Empty;
        bool usedLed = false;
        bool ledMask = false;
        Point ledLocation = new Point(4, 4);
        [Bindable(true)]
        public Point LedLocation
        {
            get
            {
                return ledLocation;
            }
            set
            {
                if (value.X > this.Width - this.Font.Height)
                {
                    ledLocation.X = this.Width - this.Font.Height;
                }
                else
                {
                    ledLocation.X = value.X;
                }
                if (value.Y > this.Height - this.Font.Height)
                {
                    ledLocation.Y = this.Height - this.Font.Height;
                }
                else
                {
                    ledLocation.Y = value.Y;
                }
                this.Invalidate();
            }
        }
        [Bindable(true)]
        public bool LED
        {
            get
            {
                return ledMask;
            }
            set
            {
                if (usedLed)
                {
                    ledMask = value;
                    this.Invalidate();
                }
            }
        }
        [Bindable(true)]
        public bool UsedLed
        {
            get
            {
                return usedLed;
            }
            set
            {
                usedLed = value;
            }
        }
        public BtMode ButtonMode
        {
            get { return mode; }
            set { mode = value; }
        }
        private int flag = 0;

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        [Bindable(true)]
        public bool Pressed
        {
            get
            {
                return pressed;
            }
            set
            {
                if (ButtonMode == BtMode.Pop)
                {
                    pressed = value;
                    this.Invalidate();
                }
            }
        }
        [Bindable(true)]
        public string NumText
        {
            get
            {
                return numText;
            }
            set
            {
                numText = value;
                this.Invalidate();
            }
        }

        public ButtonEx()
        {
            this.FlatStyle = FlatStyle.Popup;
            this.Text = String.Empty;
            this.DoubleBuffered = true;
            this.TabStop = false;
        }

        public ButtonEx(IContainer container)
        {
            container.Add(this);
            this.FlatStyle = FlatStyle.Popup;
            this.Text = String.Empty;
            this.TabStop = false;
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!string.IsNullOrWhiteSpace(NumText))
            {
                SizeF size = e.Graphics.MeasureString(NumText, this.Font);
                if (pressed)
                {
                    e.Graphics.DrawString(NumText, this.Font, this.Enabled ? SystemBrushes.ControlDark : SystemBrushes.ControlLight, this.Width - size.Width, 2);
                }
                else
                {
                    e.Graphics.DrawString(NumText, this.Font, this.Enabled ? SystemBrushes.ControlDark : SystemBrushes.ControlLight, this.Width - size.Width - 1, 1);
                }
            }
            if (this.usedLed && this.Enabled)
            {
                if (pressed)
                {
                    e.Graphics.DrawImage(QSHP.Properties.Resources.Warn, ledLocation.X + 1, ledLocation.Y + 1, this.Font.Height, this.Font.Height);
                }
                else
                {
                    e.Graphics.DrawImage(ledMask ? QSHP.Properties.Resources.OK : QSHP.Properties.Resources.Error, ledLocation.X, ledLocation.Y, this.Font.Height, this.Font.Height);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (mode != BtMode.Pop && mevent.Button == MouseButtons.Left)
            {
                pressed = true;
            }
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (mode == BtMode.Pop && mevent.Button == MouseButtons.Left)
            {
                if (!pressed)
                {
                    pressed = true;
                    if (base.GetStyle(ControlStyles.UserPaint))
                    {
                        OnClick(null);
                    }
                    OnMouseClick(mevent);
                    return;
                }
                else
                {
                    pressed = false;
                }
            }
            else
            {
                if (mevent.Button == MouseButtons.Left)
                {
                    pressed = false;
                }
            }
            base.OnMouseUp(mevent);
            if (mode != BtMode.Pop && this.Parent != null)
            {
                this.Parent.Focus();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (locker)
            {
                locker = false;
                base.OnMouseClick(e);
                locker = true;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (mode != BtMode.Pop && pressed)
            {
                OnMouseUp(new MouseEventArgs(MouseButtons.Left, -1, 0, 0, 0));
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            OnMouseEnter(null);
            if (mode != BtMode.Pop)
            {
                this.Parent.Select();
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case KeyMsg.WM_KILLFOCUS:
                    {
                        m.Result = new IntPtr(KeyMsg.WM_KILLFOCUS);
                        return;
                    }
            }
            base.WndProc(ref m);
        }

        public override bool Focused
        {
            get
            {
                return true;
            }
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return false;
                //return base.ShowFocusCues;
            }
        }
        
    }
    public enum BtMode : byte
    {
        Normal = 0,
        Pop = 1,
    }
}
