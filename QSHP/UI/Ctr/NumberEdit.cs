using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
namespace QSHP.UI.Ctr
{
    [DefaultEvent("ValueChanged")]
    public class NumberEdit : TextBoxEx
    {
        public event EventHandler ValueChanged;
        public NumberEdit() : base()
        {
            this.Text = "0";
        }
        string unit = "mm";
        Font unitFont;
        private int decPlaces = 3;
        public static string[] DecFormat = { "F0", "0.#", "0.##", "0.###", "0.####", "0.#####", "0.######" };
        [Bindable(false), Browsable(false)]
        public override bool IsNum
        {
            get
            {
                return true;
            }
        }
        private float minimum = float.MinValue;
        private float maximum = float.MaxValue;

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                unitFont = value;
            }
        }
        private float value = 0;
        [Bindable(true), Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
        [Bindable(true)]
        public float Value
        {
            get
            {
                if (decPlaces == 0)
                {
                    return Int;
                }
                else
                {
                    return this.value;
                }
            }
            set
            {
                if (value < this.minimum)
                {
                    this.value = this.minimum;
                    if (!DesignMode)
                    {
                        this.BackColor = errorColor;
                        setError = true;
                    }
                }
                else if (value > this.maximum)
                {
                    this.value = this.maximum;
                    if (!DesignMode)
                    {
                        this.BackColor = errorColor;
                        setError = true;
                    }
                }
                else
                {
                    this.value = value;
                    if (setError || setWarn)
                    {
                        this.BackColor = defaultColor;
                        setError = false;
                        setWarn = false;
                    }
                }
                this.Text = this.value.ToString(DecFormat[decPlaces]);
                
            }
        }
        [Bindable(false), Browsable(false)]
        public float Float
        {
            get
            {
                return (float)value;
            }
        }
        [Bindable(false), Browsable(false)]
        public int Int
        {
            get
            {
                return (int)value;
            }
        }
        [DefaultValue(float.MaxValue), Bindable(true)]
        public float Maximum
        {
            get { return maximum; }
            set { maximum = value; }
        }
        [DefaultValue(float.MinValue), Bindable(true)]
        public float Minimum
        {
            get { return minimum; }
            set { minimum = value; }
        }
        [Browsable(true)]
        public int DecPlaces
        {
            get
            {
                return decPlaces;
            }
            set
            {
                if (value > 6)
                {
                    decPlaces = 6;
                }
                else
                {
                    decPlaces = value;
                }
                this.Text = this.value.ToString(DecFormat[decPlaces]);
            }
        }

        public string Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }

        protected override bool ParseEditText()
        {
            float tryValue = Value;
            if (float.TryParse(this.Text, out tryValue))
            {
                if (Value != tryValue)
                {
                    Value = tryValue;
                    if (ValueChanged != null)
                    {
                        ValueChanged(this, null);
                    }
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                base.OnKeyPress(e);
            }
            else if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == '\r')
                {
                    this.OnLostFocus(null);
                }
                else
                {
                    base.OnKeyPress(e);
                }
            }
            else if (e.KeyChar == '.' && !this.Text.Contains(e.KeyChar))
            {
                if (decPlaces > 0)
                {
                    if (string.IsNullOrWhiteSpace(this.Text) || this.Text[0] == e.KeyChar)//如果当前为空或者以.开始
                    {
                        this.Text = "0.";
                        this.SelectionStart = 2;
                        e.Handled = true;
                    }
                    else
                    {
                        base.OnKeyPress(e);
                    }
                }
                else
                {
                    e.Handled = true;
                }

            }
            else if (e.KeyChar == '-')//自动切换正负符号
            {
                if (!string.IsNullOrWhiteSpace(this.Text))
                {
                    if (this.Text[0] == '-')
                    {
                        this.Text = this.Text.Substring(1);//由负变正
                        this.SelectionStart = this.Text.Length;
                        e.Handled = true;
                    }
                    else
                    {
                        this.Text = this.Text.Insert(0, "-");//由正变负
                        this.SelectionStart = this.Text.Length;
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (e.KeyChar == '.')
                {
                    this.BackColor = errorColor;
                }
                e.Handled = true;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            ParseEditText();
            this.OnTextChanged(null);
            base.OnLostFocus(e);
        }

        public override void ResetText()
        {
            base.ResetText();
            this.Text = "0";
            this.SelectionStart = 1;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //if (m.Msg == 0xf||m.Msg==0x133)
            //{
            //    if (!string.IsNullOrWhiteSpace(unit) && this.Enabled)
            //    {
            //        using (Graphics pe = this.CreateGraphics())
            //        {
            //            SizeF size = pe.MeasureString(unit, this.Font);
            //            pe.DrawString(unit, this.Font,Brushes.DimGray, this.Width - size.Width-2, 2);
            //        }
            //    }
            //}

        }

    }

}
