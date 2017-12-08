using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI.Ctr
{
    public class ComboBoxEx:ComboBox
    {
        public ComboBoxEx() : base()
        {
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.DropDownStyle = ComboBoxStyle.DropDown;
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams arg = base.CreateParams;
        //        arg.Style |= 0x03;
        //        return arg;
        //    }
        //}
        [Bindable(true)]
        public override int SelectedIndex
        {
            get
            {
                return base.SelectedIndex;
            }

            set
            {
                base.SelectedIndex = value;
            }
        }
        private void ComboBoxEx_MouseUp(object sender, MouseEventArgs e)
        {
            this.SelectionLength = 0;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
            //this.SelectionLength = 0;
            //base.OnKeyPress(e);
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
        }

       
    }
}
