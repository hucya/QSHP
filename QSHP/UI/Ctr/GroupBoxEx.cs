using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI.Ctr
{
    public partial class GroupBoxEx : ContainerControl
    {
        private Label header;

        public string HeaderText
        {
            get
            {
                return this.header.Text;
            }
            set
            {
                this.header.Text = value;
                //this.Invalidate();
            }
        }
        private int boardWidth = 5;

        public int BoardWidth
        {
            get 
            { 
                return boardWidth-4; 
            }
            set 
            { 
                boardWidth = 4+value;
                this.Invalidate();
            }
        }

        public Font HeaderFont
        {
            get
            {
               return  this.header.Font;
            }
            set
            {
                this.header.Font = value;
                this.header.Height = value.Height;
            }
        }

        public ContentAlignment HeaderAligment
        {
            get
            {
                return this.header.TextAlign;
            }
            set
            {
                this.header.TextAlign = value;
            }
        }

        public Color HeaderBackColor
        {
            get
            {
                return this.header.BackColor;
            }
            set
            {
                this.header.BackColor=value;
                this.Invalidate();
            }
        }

        public Color HeaderForeColor
        {
            get
            {
                return this.header.ForeColor;
            }
            set
            {
                this.header.ForeColor = value;
            }
        }
    
        public GroupBoxEx()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.header.Height = this.header.Font.Height;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // label1
            // 
            this.header = new System.Windows.Forms.Label();
            this.header.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.TextAlign = ContentAlignment.MiddleLeft;
            this.header.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.header.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.header.Width = this.Width;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(1);
            this.header.Name = "header";
            this.header.AutoSize = false;
            this.header.Text = "标题";
            // 
            // GroupEx
            // 
            this.Controls.Add(this.header);
            this.Name = "GroupEx";
            this.Size = new System.Drawing.Size(177, 123);
            this.ResumeLayout(false);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (boardWidth > 3)
            {
                e.Graphics.DrawRectangle(new Pen(this.header.BackColor, boardWidth), ClientRectangle);
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            this.header.SendToBack();
        }
        
    }
}
