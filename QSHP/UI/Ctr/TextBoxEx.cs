using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI.Ctr
{
    public class TextBoxEx : TextBox
    {
        protected Color warnColor = Color.Yellow;
        protected Color errorColor = Color.Red;
        protected Color defaultColor = Color.Green;
        protected bool setError = false;
        protected bool setWarn = false;

        //public new bool Enabled
        //{
        //    get
        //    {
        //       return  base.Enabled;
        //    }
        //    set
        //    {
        //        base.Enabled = value;
        //        if (base.Enabled)
        //        {
        //            this.BackColor = SystemColors.Control;
        //        }
        //        else
        //        {
        //            this.BackColor = SystemColors.Window;
        //        }
        //    }
        //}

        //public new bool ReadOnly
        //{
        //    get
        //    {
        //        return base.ReadOnly;
        //    }
        //    set
        //    {
        //        base.ReadOnly = value;
        //        if (base.ReadOnly)
        //        {
        //            this.BackColor = SystemColors.Control;
        //        }
        //        else
        //        {
        //            this.BackColor = SystemColors.Window;
        //        }
        //    }
        //}
        public TextBoxEx() : base()
        {
            this.defaultColor = this.BackColor;
            this.Font = new Font("微软雅黑", 12F);
        }
        protected Color WarnColor
        {
            get { return warnColor; }
            set { warnColor = value; }
        }

        protected Color ErrorColor
        {
            get { return errorColor; }
            set { errorColor = value; }
        }
        [Bindable(false), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool IsNum
        {
            get
            {
                return false;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this.ReadOnly)
            {
                return;
            }
            if (this.IsInputChar(e.KeyChar))
            {
                this.BackColor = warnColor;
            }
            else
            {
                this.BackColor = errorColor;
            }
            base.OnKeyPress(e);

        }
        [Browsable(false)]
        public bool SetError
        {
            get
            {
                return setError;
            }

            set
            {
                setError = value;
                if (value)
                {
                    this.BackColor = errorColor;
                }
                else
                {
                    this.BackColor = defaultColor;
                }
            }
        }
        [Browsable(false)]
        public bool SetWarn
        {
            get
            {
                return setWarn;
            }

            set
            {
                setWarn = value;
                if (value)
                {
                    this.BackColor = warnColor;
                }
                else
                {
                    this.BackColor = defaultColor;
                }
            }
        }
        protected virtual bool ParseEditText()
        {
            return true;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (!this.DesignMode)
            {
                if (ParseEditText())
                {
                    this.BackColor = this.defaultColor;
                }
                else
                {
                    this.BackColor = this.errorColor;
                }
            }
        }


    }

}
