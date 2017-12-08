using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace QSHP.UI.Ctr
{
    public class LedEx : UserControl
    {
        #region 组件设计器生成的代码
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        #endregion
        public LedEx()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            this.Width = 48;
            this.Height = 48;
            Random c=new Random();
            circleColor = Color.FromArgb(c.Next(255), c.Next(255), c.Next(255));
            this.BackColor = Color.Transparent;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LEDControl_Paint);
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
        /// <summary>
        /// LED打开或者关闭
        /// </summary>
        private bool ledSwitch = true;
        private LedStatus status = LedStatus.None;
        [DefaultValue(LedStatus.None)]
        public LedStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                if (status != value)
                {
                    status = value;
                    switch (value)
                    {
                        case LedStatus.None:
                            {
                                this.ledSwitch = false;
                            } break;
                        case LedStatus.OK:
                            {
                                this.ledCenterColor = Color.PaleGreen;
                                this.circleColor = Color.LimeGreen;
                                this.ledSwitch = true;
                            } break;
                        case LedStatus.Warn:
                            {
                                this.ledCenterColor = Color.Yellow;
                                this.circleColor = Color.Gold;
                                this.ledSwitch = true;
                            } break;
                        case LedStatus.Error:
                            {
                                this.ledCenterColor = Color.Red;
                                this.circleColor = Color.Salmon;
                                this.ledSwitch = true;
                            } break;
                    }
                    Invalidate();
                }
            }
        }

        [CategoryAttribute("状态"), Description("LED打开或关闭")]
        public bool Switch
        {
            set
            {
                if (ledSwitch != value)
                {
                    ledSwitch = value;
                    Invalidate();
                }
            }
            get { return ledSwitch; }
        }

        /// <summary>
        /// LED中心颜色
        /// </summary>
        private Color ledCenterColor = Color.LightYellow;
        [CategoryAttribute("颜色"), Description("中心颜色")]
        public Color CenterColor
        {
            set
            {
                ledCenterColor = value;
                Invalidate();
            }
            get 
            { 
                return ledCenterColor;
            }
        }

        /// <summary>
        /// LED边缘颜色
        /// </summary>
        private Color circleColor = Color.DeepPink;
        [CategoryAttribute("颜色"), Description("边缘颜色")]
        public Color CircleColor
        {
            set
            {
                circleColor = value;
                Invalidate();
            }
            get 
            { 
                return circleColor; 
            }
        }

        /// <summary>
        /// LED外环颜色
        /// </summary>
        private Color borderColor = Color.Gray;
        [CategoryAttribute("颜色"), Description("外环颜色")]
        public Color BorderColor
        {
            set 
            { 
                borderColor = value;
                Invalidate();
            }
            get 
            { 
                return borderColor;
            }
        }
        private int borderWidth = 1;
        [CategoryAttribute("状态"), Description("边缘宽度")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set 
            {
                if (value > Math.Min(this.Width, this.Height) / 2)
                {
                    value = (int)Math.Min(this.Width, this.Height) / 2;
                }
                borderWidth = value;
                Invalidate();
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, this.Width, this.Height);
                this.Region = new Region(gp);//这句就是设置圆形的规格区域的 
            }
        }

        /// <summary>
        /// 绘制LED响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LEDControl_Paint(object sender, PaintEventArgs e)
        {
            Color centerColor;
            Color surroundColor;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (ledSwitch)
            {
                centerColor = ledCenterColor;
                surroundColor = circleColor;
            }
            else
            {
                centerColor = Color.LightGray;
                surroundColor = Color.Gray;
            }
            // 创建一个变色圆形的区域
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(borderWidth, borderWidth, this.Width - 2 * borderWidth, this.Height - 2 * borderWidth);
            PathGradientBrush pthGrBrush = new PathGradientBrush(path);
            // 设置中间颜色
            pthGrBrush.CenterColor = centerColor;
            // 设置边缘颜色
            Color[] colors = { surroundColor };
            pthGrBrush.SurroundColors = colors;
            // 绘制变色圆形
            e.Graphics.FillEllipse(pthGrBrush, borderWidth, borderWidth, this.Width - 2 * borderWidth, this.Height - 2 * borderWidth);
            // 绘制圆形边框
            if (borderWidth > 0)
            {
                Pen p = new Pen(new SolidBrush(borderColor), borderWidth);
                e.Graphics.DrawEllipse(p, borderWidth, borderWidth, this.Width - 2 * borderWidth, this.Height - 2 * borderWidth);
            }
        }
    }
}
