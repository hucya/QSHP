using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI.Ctr
{
    public class TabControlEx : TabControl
    {
        [Browsable(true)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                foreach (TabPage item in this.TabPages)
                {
                    item.BackColor = value;
                }
            }
        }
        public TabControlEx()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲                                      // 设置以上值为 true  
            this.ItemSize = new Size(1, 1);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //this
            System.Drawing.Pen pen = new Pen(this.BackColor, 3);
            e.Graphics.DrawRectangle(pen, 0, 0, this.Width, this.Height);//填充 
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is TabControl)
            {
                e.Control.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            }
            base.OnControlAdded(e);

        }
    }
}
