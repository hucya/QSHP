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
    public class DigitalEx : UserControl
    {
        [Flags]
        private enum MegmentEnum : byte
        {
            Zore = 0x00,
            B1 = 0x01,
            B2 = 0x02,
            B3 = 0x04,
            B4 = 0x08,
            B5 = 0x10,
            B6 = 0x20,
            B7 = 0x40,
            B8 = 0x80,
        }
        private Color _BackColor=Color.Black;
        private Color _BorderColor=Color.DarkGray;
        private Color _BorderLightColor=Color.PowderBlue;
        private Color _BorderShadowColor = Color.DarkKhaki;
        private BorderStyleEnum _BorderStyle;
        private int _BorderWidth;
        private float _CornerRate;
        private int _DarkTime;
        private string _DateTimeFormatString;
        private Color _ForeColor=Color.Red;
        private bool _IsAntiAlias;
        private bool _IsZeroFirst;
        private float _LEDInterval;
        private const float _LEDIntervalRate = 0.08f;
        private LEDStyleEnum _LEDStyle;
        private float _LEDWidth;
        private const float _LEDWidthRate = 0.45f;
        private float _Margin;
        private const float _MarginRate = 0.04f;
        private float _SegmentInterval;
        private const float _SegmentIntervalRate = 0.01f;
        private float _SegmentWidth;
        private const float _SegmentWidthRate = 0.1f;
        private Color _ShadowColor=Color.NavajoWhite;
        private string _Text;
        private AlignType _TextAlign;
        private bool bolDrawText;
        private System.Threading.Thread m_FlashThread;
        public readonly bool RegVer;
        private StringBuilder stringBuilder = new StringBuilder();
        private System.ComponentModel.IContainer components = null;
        public event LEDClickEventHandler LEDClick;
        public event LEDDoubleClickEventHandler LEDDoubleClick;
        private volatile MegmentEnum megment = (MegmentEnum)0xFF;
        private volatile byte lastMegment = 0;
        RectangleF PotRectangle = new RectangleF();
        bool hasPot = false;
        bool potFlag = false;
        bool showShadow = true;
        [DefaultValue(true), Category("LED总体"), Description("是否显示背景")]
        public bool ShowShadow
        {
            get
            {
                return showShadow;
            }
            set
            {
                showShadow = value;
                this.Invalidate();
            }
        }

        public DigitalEx()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            this.ParameterInitial();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void DrawBorder(Graphics g)
        {
            if (this._BorderWidth != 0)
            {
                SolidBrush brush;
                GraphicsPath path;
                Pen pen;
                RectangleF ef;
                Region region;
                PointF tf;
                RectangleF ef2;
                PointF[] points = new PointF[6];
                float y = 0f;
                float num2 = 0f;
                float x = 0f;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                switch (this._BorderStyle)
                {
                    case BorderStyleEnum.Outside:
                        if ((((double)this._BorderWidth) / 3.0) <= 10.0)
                        {
                            x = (float)(((double)this._BorderWidth) / 3.0);
                            y = (float)(((double)this._BorderWidth) / 3.0);
                            num2 = (float)(((double)this._BorderWidth) / 3.0);
                            break;
                        }
                        y = (float)-Convert.ToDouble(((num2 == 10f) != false));
                        x = this._BorderWidth - (2f * y);
                        break;

                    case BorderStyleEnum.Inside:
                        if ((((double)this._BorderWidth) / 3.0) <= 10.0)
                        {
                            x = (float)(((double)this._BorderWidth) / 3.0);
                            y = (float)(((double)this._BorderWidth) / 3.0);
                            num2 = (float)(((double)this._BorderWidth) / 3.0);
                        }
                        else
                        {
                            y = (float)-Convert.ToDouble(((num2 == 10f) != false));
                            x = this._BorderWidth - (2f * y);
                        }
                        tf = new PointF(0f, (float)this.Height);
                        points[0] = tf;
                        tf = new PointF(0f, 0f);
                        points[1] = tf;
                        tf = new PointF((float)this.Width, 0f);
                        points[2] = tf;
                        tf = new PointF(this.Width - y, y);
                        points[3] = tf;
                        tf = new PointF(y, y);
                        points[4] = tf;
                        tf = new PointF(y, this.Height - y);
                        points[5] = tf;
                        path = new GraphicsPath();
                        path.AddLines(points);
                        brush = new SolidBrush(this._BorderShadowColor);
                        g.FillPath(brush, path);
                        tf = new PointF(0f, (float)this.Height);
                        points[0] = tf;
                        tf = new PointF((float)this.Width, (float)this.Height);
                        points[1] = tf;
                        tf = new PointF((float)this.Width, 0f);
                        points[2] = tf;
                        tf = new PointF(this.Width - y, y);
                        points[3] = tf;
                        tf = new PointF(this.Width - y, this.Height - y);
                        points[4] = tf;
                        tf = new PointF(y, this.Height - y);
                        points[5] = tf;
                        path = new GraphicsPath();
                        path.AddLines(points);
                        brush = new SolidBrush(this._BorderLightColor);
                        g.FillPath(brush, path);
                        tf = new PointF(x + y, (this.Height - y) - x);
                        points[0] = tf;
                        tf = new PointF((this.Width - x) - y, (this.Height - x) - y);
                        points[1] = tf;
                        tf = new PointF((this.Width - x) - y, x + y);
                        points[2] = tf;
                        tf = new PointF((float)(this.Width - this._BorderWidth), (float)this._BorderWidth);
                        points[3] = tf;
                        tf = new PointF((float)(this.Width - this._BorderWidth), (float)(this.Height - this._BorderWidth));
                        points[4] = tf;
                        tf = new PointF((float)this._BorderWidth, (float)(this.Height - this._BorderWidth));
                        points[5] = tf;
                        path = new GraphicsPath();
                        path.AddLines(points);
                        brush = new SolidBrush(this._BorderShadowColor);
                        g.FillPath(brush, path);
                        tf = new PointF(x + y, (this.Height - y) - x);
                        points[0] = tf;
                        tf = new PointF(x + y, x + y);
                        points[1] = tf;
                        tf = new PointF((this.Width - x) - y, x + y);
                        points[2] = tf;
                        tf = new PointF((float)(this.Width - this._BorderWidth), (float)this._BorderWidth);
                        points[3] = tf;
                        tf = new PointF((float)this._BorderWidth, (float)this._BorderWidth);
                        points[4] = tf;
                        tf = new PointF((float)this._BorderWidth, (float)(this.Height - this._BorderWidth));
                        points[5] = tf;
                        path = new GraphicsPath();
                        path.AddLines(points);
                        brush = new SolidBrush(this._BorderLightColor);
                        g.FillPath(brush, path);
                        ef2 = new RectangleF(y, y, this.Width - (2f * y), this.Height - (2f * y));
                        ef = ef2;
                        region = new Region(ef);
                        ef2 = new RectangleF(x + y, x + y, this.Width - (2f * (x + y)), this.Height - (2f * (x + y)));
                        ef = ef2;
                        region.Exclude(ef);
                        brush = new SolidBrush(this._BorderColor);
                        g.FillRegion(brush, region);
                        pen = new Pen(this._BorderShadowColor);
                        g.DrawLine(pen, y + x, y + x, (float)this._BorderWidth, (float)this._BorderWidth);
                        g.DrawLine(pen, this.Width - y, this.Height - y, (float)this.Width, (float)this.Height);
                        brush.Dispose();
                        pen.Dispose();
                        return;

                    case BorderStyleEnum.Flat:
                        x = this._BorderWidth;
                        y = 0f;
                        num2 = 0f;
                        ef2 = new RectangleF(0f, 0f, (float)this.Width, (float)this.Height);
                        ef = ef2;
                        region = new Region(ef);
                        ef2 = new RectangleF(x, x, this.Width - (2f * x), this.Height - (2f * x));
                        ef = ef2;
                        region.Exclude(ef);
                        brush = new SolidBrush(this._BorderColor);
                        g.FillRegion(brush, region);
                        brush.Dispose();
                        return;

                    case BorderStyleEnum.None:
                        return;

                    default:
                        return;
                }
                tf = new PointF(0f, (float)this.Height);
                points[0] = tf;
                tf = new PointF(0f, 0f);
                points[1] = tf;
                tf = new PointF((float)this.Width, 0f);
                points[2] = tf;
                tf = new PointF(this.Width - y, y);
                points[3] = tf;
                tf = new PointF(y, y);
                points[4] = tf;
                tf = new PointF(y, this.Height - y);
                points[5] = tf;
                path = new GraphicsPath();
                path.AddLines(points);
                brush = new SolidBrush(this._BorderLightColor);
                g.FillPath(brush, path);
                tf = new PointF(0f, (float)this.Height);
                points[0] = tf;
                tf = new PointF((float)this.Width, (float)this.Height);
                points[1] = tf;
                tf = new PointF((float)this.Width, 0f);
                points[2] = tf;
                tf = new PointF(this.Width - y, y);
                points[3] = tf;
                tf = new PointF(this.Width - y, this.Height - y);
                points[4] = tf;
                tf = new PointF(y, this.Height - y);
                points[5] = tf;
                path = new GraphicsPath();
                path.AddLines(points);
                brush = new SolidBrush(this._BorderShadowColor);
                g.FillPath(brush, path);
                tf = new PointF(x + y, (this.Height - y) - x);
                points[0] = tf;
                tf = new PointF((this.Width - x) - y, (this.Height - x) - y);
                points[1] = tf;
                tf = new PointF((this.Width - x) - y, x + y);
                points[2] = tf;
                tf = new PointF((float)(this.Width - this._BorderWidth), (float)this._BorderWidth);
                points[3] = tf;
                tf = new PointF((float)(this.Width - this._BorderWidth), (float)(this.Height - this._BorderWidth));
                points[4] = tf;
                tf = new PointF((float)this._BorderWidth, (float)(this.Height - this._BorderWidth));
                points[5] = tf;
                path = new GraphicsPath();
                path.AddLines(points);
                brush = new SolidBrush(this._BorderLightColor);
                g.FillPath(brush, path);
                tf = new PointF(x + y, (this.Height - y) - x);
                points[0] = tf;
                tf = new PointF(x + y, x + y);
                points[1] = tf;
                tf = new PointF((this.Width - x) - y, x + y);
                points[2] = tf;
                tf = new PointF((float)(this.Width - this._BorderWidth), (float)this._BorderWidth);
                points[3] = tf;
                tf = new PointF((float)this._BorderWidth, (float)this._BorderWidth);
                points[4] = tf;
                tf = new PointF((float)this._BorderWidth, (float)(this.Height - this._BorderWidth));
                points[5] = tf;
                path = new GraphicsPath();
                path.AddLines(points);
                brush = new SolidBrush(this._BorderShadowColor);
                g.FillPath(brush, path);
                ef2 = new RectangleF(y, y, this.Width - (2f * y), this.Height - (2f * y));
                ef = ef2;
                region = new Region(ef);
                ef2 = new RectangleF(x + y, x + y, this.Width - (2f * (x + y)), this.Height - (2f * (x + y)));
                ef = ef2;
                region.Exclude(ef);
                brush = new SolidBrush(this._BorderColor);
                g.FillRegion(brush, region);
                pen = new Pen(this._BorderShadowColor);
                g.DrawLine(pen, 0f, 0f, y, y);
                g.DrawLine(pen, (float)(this.Width - this._BorderWidth), (float)(this.Height - this._BorderWidth), (this.Width - y) - x, (this.Height - y) - x);
                brush.Dispose();
                pen.Dispose();
            }
        }
        private void DrawFromLeft(Graphics g, string strText)
        {
            char sLeft;
            Rectangle rectToDraw = new Rectangle();
            short num2 = 0;
            rectToDraw.X = 0;
            rectToDraw.Y = (int)Math.Round((double)(this._BorderWidth + this._Margin));
            rectToDraw.Width = (int)Math.Round((double)this._LEDWidth);
            rectToDraw.Height = this.Height - (rectToDraw.Y * 2);
            if (hasPot && potFlag)
            {
                this.DrawOneP(g, PotRectangle, _BackColor);
                hasPot = false;
            }
            int ledNum = (int)Math.Truncate((this.Width - 2 * (this._BorderWidth + this._Margin)) / this._LEDWidth);
            if (strText.Length <= ledNum)
            {
                ledNum = strText.Length;
            }
            for (short i = 0; i < ledNum; i++)
            {
                sLeft = strText[i];
                if (sLeft != '.')
                {
                    rectToDraw.X = (int)Math.Round((double)(((this._BorderWidth + this._Margin) + this._LEDInterval) + (num2 * (this._LEDInterval + this._LEDWidth))));
                    num2 = (short)(num2 + 1);
                }
                else
                {
                    if (hasPot)
                    {
                        continue;
                    }
                    else
                    {
                        hasPot = true;
                    }
                }
                this.DrawNumber(g, rectToDraw, this._ForeColor, sLeft);
            }
        }
        private void DrawFromRight(Graphics g, string strText)
        {
            char sLeft;
            Rectangle rectToDraw = new Rectangle();
            short num2 = 0;
            rectToDraw.X = (int)Math.Round(((this.Width - this._BorderWidth) - this._Margin));
            rectToDraw.Y = (int)Math.Round((this._BorderWidth + this._Margin));
            rectToDraw.Width = (int)Math.Round(this._LEDWidth);
            rectToDraw.Height = this.Height - (rectToDraw.Y * 2);
            if (hasPot && potFlag)
            {
                this.DrawOneP(g, PotRectangle, _BackColor);
                hasPot = false;
            }
            int ledNum = (int)Math.Truncate((this.Width - 2 * (this._BorderWidth + this._Margin)) / this._LEDWidth );//(short)this.GetLEDNum(this._Text.Trim());
            if (strText.Length > ledNum)
            {
                ledNum = strText.Length - ledNum;
            }
            else
            {
                ledNum = 0;
            }
            for (int i = strText.Length - 1; i >= ledNum; i--)
            {
                sLeft = strText[i];
                if (sLeft != '.')
                {
                    num2++;
                    rectToDraw.X = (int)Math.Truncate(((this.Width - this._BorderWidth) - this._Margin) - (num2 * (this._LEDInterval + this._LEDWidth)));
                }
                else
                {
                    if (hasPot)
                    {
                        continue;
                    }
                    else
                    {
                        hasPot = true;
                    }
                }
                this.DrawNumber(g, rectToDraw, this._ForeColor, sLeft);
            }
        }
        private void DrawNumber(Graphics g, Rectangle RectToDraw, Color UseColor, char strNumChar)
        {
            char sLeft = strNumChar;
            switch (strNumChar)
            {
                case '0':
                    {
                        megment = (MegmentEnum)0x7D;
                    }
                    break;
                case '1':
                    {
                        megment = (MegmentEnum)0x50;
                    } break;
                case '2':
                    {
                        megment = (MegmentEnum)0x37;
                    } break;
                case '3':
                    {
                        megment = (MegmentEnum)0x57;
                    } break;
                case '4':
                    {
                        megment = (MegmentEnum)0x5A;
                    } break;
                case '5':
                    {
                        megment = (MegmentEnum)0x4F;
                    } break;
                case '6':
                    {
                        megment = (MegmentEnum)0x6F;
                    } break;
                case '7':
                    {
                        megment = (MegmentEnum)0x51;
                    } break;
                case '8':
                    {
                        megment = (MegmentEnum)0x7F;
                    } break;
                case '9':
                    {
                        megment = (MegmentEnum)0x5F;
                    } break;
                case 'A':
                case 'a':
                    {
                        megment = (MegmentEnum)0x7B;
                    } break;
                case 'B':
                case 'b':
                    {
                        megment = (MegmentEnum)0x6E;
                    } break;
                case 'C':
                case 'c':
                    {
                        megment = (MegmentEnum)0x2D;
                    } break;
                case 'D':
                case 'd':
                    {
                        megment = (MegmentEnum)0x76;
                    } break;
                case 'E':
                case 'e':
                    {
                        megment = (MegmentEnum)0x2F;
                    } break;
                case 'F':
                case 'f':
                    {
                        megment = (MegmentEnum)0x2B;
                    } break;
                case 'G':
                case 'g':
                    {
                        megment = (MegmentEnum)0x5F;
                    } break;
                case 'H':
                case 'h':
                    {
                        megment = (MegmentEnum)0x7A;
                    } break;
                case 'I':
                case 'i':
                    {
                        megment = (MegmentEnum)0x50;
                    } break;
                case 'J':
                case 'j':
                    {
                        megment = (MegmentEnum)0x74;
                    } break;
                case 'L':
                case 'l':
                    {
                        megment = (MegmentEnum)0x2C;
                    } break;
                case 'N':
                case 'n':
                    {
                        megment = (MegmentEnum)0x79;
                    } break;
                case 'O':
                case 'o':
                    {
                        megment = (MegmentEnum)0x7D;
                    } break;
                case 'P':
                case 'p':
                    {
                        megment = (MegmentEnum)0x3B;
                    } break;
                case 'Q':
                case 'q':
                    {
                        megment = (MegmentEnum)0x5B;
                    } break;
                case 'S':
                case 's':
                    {
                        megment = (MegmentEnum)0x4F;
                    } break;
                case 'U':
                case 'u':
                    {
                        megment = (MegmentEnum)0x7C;
                    } break;
                case '|':
                    {
                        megment = MegmentEnum.B4;
                        megment |= MegmentEnum.B6;

                    } break;
                case '-':
                    {
                        megment = MegmentEnum.B2;
                    } break;
                case '_':
                    {
                        megment = MegmentEnum.B3;
                    } break;
                case ':':
                    {
                        this.DrawSegment(g, RectToDraw, this._ShadowColor, 0);
                        this.DrawSegment(g, RectToDraw, this._ShadowColor, 1);
                        this.DrawSegment(g, RectToDraw, this._ShadowColor, 2);
                        this.DrawSegment(g, RectToDraw, this._ShadowColor, 3);
                        this.DrawSegment(g, RectToDraw, this._ShadowColor, 4);
                        this.DrawSegment(g, RectToDraw, this._ShadowColor, 5);
                        this.DrawSegment(g, RectToDraw, this._ShadowColor, 6);
                        megment = MegmentEnum.Zore;
                        this.DrawTwoP(g, RectToDraw);
                        return;
                    }
                case '.':
                    {
                        megment |= MegmentEnum.B8;
                        RectangleF ef = new RectangleF();
                        if (this._TextAlign == AlignType.Left)
                        {
                            if (RectToDraw.X == 0)
                            {
                                ef.X = (this._BorderWidth + this._Margin) + 1f;
                            }
                            else
                            {
                                ef.X = (RectToDraw.X + this._LEDWidth) + 1f;
                            }
                        }
                        else
                        {
                            ef.X = (RectToDraw.X - this._LEDInterval) + 1f;
                        }
                        ef.Width = this._LEDInterval > 5 ? this._LEDInterval - 2 : 3;
                        ef.Height = (float)(ef.Width * 1.1);
                        ef.Y = (((this.Height - this._BorderWidth) - this._Margin) - ef.Height) + 1f;
                        if (PotRectangle != ef)
                        {
                            this.DrawOneP(g, ef, UseColor);
                            PotRectangle = ef;
                            potFlag = true;
                        }
                        else
                        {
                            if (hasPot)
                            {
                                this.DrawOneP(g, ef, UseColor);
                            }
                            potFlag = false;
                        }
                        return;
                    }
                default:
                    {
                        megment = MegmentEnum.Zore;
                    } break;
            }
            
            lastMegment = (byte)megment;
            for (int i = 0; i < 8; i++)
            {
                if (((lastMegment >> i) & 0x01) > 0)
                {
                    this.DrawSegment(g, RectToDraw, UseColor, i);
                }
                else
                {
                    if (showShadow)
                    {
                        this.DrawSegment(g, RectToDraw, this._ShadowColor, i);
                    }
                    else
                    {
                        this.DrawSegment(g, RectToDraw, this._BackColor, i);
                    }
                }
            }
        }
        private void DrawOneP(Graphics g, RectangleF RectToDraw, Color useColor)
        {
            SolidBrush brush = new SolidBrush(useColor);
            g.FillRectangle(brush, RectToDraw);
            brush.Dispose();
        }
        private void DrawSegment(Graphics g, Rectangle RectToDraw, Color UseColor, int SegNum)
        {
            PointF tf;
            float num = this._CornerRate;
            GraphicsPath path = new GraphicsPath();
            PointF[] points = new PointF[6];
            switch (SegNum)
            {
                case 0:
                    tf = new PointF((this._SegmentWidth * num) + this._SegmentInterval, this._SegmentWidth * num);
                    points[0] = tf;
                    tf = new PointF(this._SegmentInterval + ((2f * this._SegmentWidth) * num), 0f);
                    points[1] = tf;
                    tf = new PointF((RectToDraw.Width - this._SegmentInterval) - ((2f * this._SegmentWidth) * num), 0f);
                    points[2] = tf;
                    tf = new PointF((RectToDraw.Width - this._SegmentInterval) - (this._SegmentWidth * num), this._SegmentWidth * num);
                    points[3] = tf;
                    tf = new PointF((RectToDraw.Width - this._SegmentInterval) - this._SegmentWidth, this._SegmentWidth);
                    points[4] = tf;
                    tf = new PointF(this._SegmentWidth + this._SegmentInterval, this._SegmentWidth);
                    points[5] = tf;
                    break;

                case 1:
                    tf = new PointF(((float)(this._SegmentWidth * 0.5)) + this._SegmentInterval, (float)(RectToDraw.Height * 0.5));
                    points[0] = tf;
                    tf = new PointF(this._SegmentWidth + this._SegmentInterval, (float)((RectToDraw.Height * 0.5) - (this._SegmentWidth * 0.5)));
                    points[1] = tf;
                    tf = new PointF((RectToDraw.Width - this._SegmentInterval) - this._SegmentWidth, (float)((RectToDraw.Height * 0.5) - (this._SegmentWidth * 0.5)));
                    points[2] = tf;
                    tf = new PointF((RectToDraw.Width - this._SegmentInterval) - ((float)(this._SegmentWidth * 0.5)), (float)(RectToDraw.Height * 0.5));
                    points[3] = tf;
                    tf = new PointF((RectToDraw.Width - this._SegmentInterval) - this._SegmentWidth, (float)((RectToDraw.Height * 0.5) + (this._SegmentWidth * 0.5)));
                    points[4] = tf;
                    tf = new PointF(this._SegmentWidth + this._SegmentInterval, (float)((RectToDraw.Height * 0.5) + (this._SegmentWidth * 0.5)));
                    points[5] = tf;
                    break;

                case 2:
                    tf = new PointF((this._SegmentWidth * num) + this._SegmentInterval, RectToDraw.Height - (this._SegmentWidth * num));
                    points[0] = tf;
                    tf = new PointF(this._SegmentWidth + this._SegmentInterval, RectToDraw.Height - this._SegmentWidth);
                    points[1] = tf;
                    tf = new PointF((RectToDraw.Width - this._SegmentInterval) - this._SegmentWidth, RectToDraw.Height - this._SegmentWidth);
                    points[2] = tf;
                    tf = new PointF((RectToDraw.Width - this._SegmentInterval) - (this._SegmentWidth * num), RectToDraw.Height - (this._SegmentWidth * num));
                    points[3] = tf;
                    tf = new PointF((RectToDraw.Width - this._SegmentInterval) - ((2f * this._SegmentWidth) * num), (float)RectToDraw.Height);
                    points[4] = tf;
                    tf = new PointF(((2f * this._SegmentWidth) * num) + this._SegmentInterval, (float)RectToDraw.Height);
                    points[5] = tf;
                    break;

                case 3:
                    tf = new PointF(0f, ((2f * this._SegmentWidth) * num) + this._SegmentInterval);
                    points[0] = tf;
                    tf = new PointF(this._SegmentWidth * num, (this._SegmentWidth * num) + this._SegmentInterval);
                    points[1] = tf;
                    tf = new PointF(this._SegmentWidth, this._SegmentWidth + this._SegmentInterval);
                    points[2] = tf;
                    tf = new PointF(this._SegmentWidth, ((float)((((double)RectToDraw.Height) / 2.0) - (this._SegmentWidth * 0.5))) - this._SegmentInterval);
                    points[3] = tf;
                    tf = new PointF(this._SegmentWidth / 2f, ((float)(((double)RectToDraw.Height) / 2.0)) - this._SegmentInterval);
                    points[4] = tf;
                    tf = new PointF(0f, ((float)((((double)RectToDraw.Height) / 2.0) - (this._SegmentWidth * 0.5))) - this._SegmentInterval);
                    points[5] = tf;
                    break;
                case 4:
                    tf = new PointF(RectToDraw.Width - this._SegmentWidth, this._SegmentWidth + this._SegmentInterval);
                    points[0] = tf;
                    tf = new PointF(RectToDraw.Width - (this._SegmentWidth * num), (this._SegmentWidth * num) + this._SegmentInterval);
                    points[1] = tf;
                    tf = new PointF((float)RectToDraw.Width, ((2f * this._SegmentWidth) * num) + this._SegmentInterval);
                    points[2] = tf;
                    tf = new PointF((float)RectToDraw.Width, ((float)((RectToDraw.Height * 0.5) - (this._SegmentWidth * 0.5))) - this._SegmentInterval);
                    points[3] = tf;
                    tf = new PointF(RectToDraw.Width - (this._SegmentWidth / 2f), ((float)(((double)RectToDraw.Height) / 2.0)) - this._SegmentInterval);
                    points[4] = tf;
                    tf = new PointF(RectToDraw.Width - this._SegmentWidth, ((float)((((double)RectToDraw.Height) / 2.0) - (this._SegmentWidth * 0.5))) - this._SegmentInterval);
                    points[5] = tf;
                    break;

                case 5:
                    tf = new PointF(0f, (float)(((RectToDraw.Height * 0.5) + this._SegmentInterval) + (this._SegmentWidth * 0.5)));
                    points[0] = tf;
                    tf = new PointF((float)(this._SegmentWidth * 0.5), ((float)(RectToDraw.Height * 0.5)) + this._SegmentInterval);
                    points[1] = tf;
                    tf = new PointF(this._SegmentWidth, (float)(((RectToDraw.Height * 0.5) + this._SegmentInterval) + (this._SegmentWidth * 0.5)));
                    points[2] = tf;
                    tf = new PointF(this._SegmentWidth, (RectToDraw.Height - this._SegmentWidth) - this._SegmentInterval);
                    points[3] = tf;
                    tf = new PointF(this._SegmentWidth * num, (RectToDraw.Height - (this._SegmentWidth * num)) - this._SegmentInterval);
                    points[4] = tf;
                    tf = new PointF(0f, (RectToDraw.Height - this._SegmentInterval) - ((2f * this._SegmentWidth) * num));
                    points[5] = tf;
                    break;
                case 6:
                    tf = new PointF(RectToDraw.Width - this._SegmentWidth, (float)(((RectToDraw.Height * 0.5) + this._SegmentInterval) + (this._SegmentWidth * 0.5)));
                    points[0] = tf;
                    tf = new PointF((float)(RectToDraw.Width - (this._SegmentWidth * 0.5)), ((float)(RectToDraw.Height * 0.5)) + this._SegmentInterval);
                    points[1] = tf;
                    tf = new PointF((float)RectToDraw.Width, (float)(((RectToDraw.Height * 0.5) + this._SegmentInterval) + (this._SegmentWidth * 0.5)));
                    points[2] = tf;
                    tf = new PointF((float)RectToDraw.Width, (RectToDraw.Height - this._SegmentInterval) - ((2f * this._SegmentWidth) * num));
                    points[3] = tf;
                    tf = new PointF(RectToDraw.Width - (this._SegmentWidth * num), (RectToDraw.Height - (this._SegmentWidth * num)) - this._SegmentInterval);
                    points[4] = tf;
                    tf = new PointF(RectToDraw.Width - this._SegmentWidth, (RectToDraw.Height - this._SegmentWidth) - this._SegmentInterval);
                    points[5] = tf;
                    break;
            }
            SolidBrush brush = new SolidBrush(UseColor);
            path.AddPolygon(points);
            path.CloseFigure();
            Matrix matrix = new Matrix();
            matrix.Translate((float)RectToDraw.X, (float)RectToDraw.Y);
            path.Transform(matrix);
            if (this._IsAntiAlias)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
            }
            else
            {
                g.SmoothingMode = SmoothingMode.Default;
            }
            Rectangle rect = new Rectangle(2, 2, this.Width - 3, this.Height - 2);
            g.Clip = new Region(rect);
            g.FillPath(brush, path);
            brush.Dispose();
        }
        private void DrawShadow(Graphics g)
        {
            if (showShadow)
            {
                short num;
                short ledNum = 0;
                Rectangle rectToDraw = new Rectangle();
                ledNum = (short)Math.Truncate((this.Width - 2 * (this._BorderWidth + this._Margin)) / this._LEDWidth + 1);//(short)this.GetLEDNum(this._Text.Trim());
                switch (this._TextAlign)
                {
                    case AlignType.Left:
                        {
                            rectToDraw.X = 0;
                            rectToDraw.Y = (int)Math.Round((double)(this._BorderWidth + this._Margin));
                            rectToDraw.Width = (int)Math.Round((double)this._LEDWidth);
                            rectToDraw.Height = this.Height - (rectToDraw.Y * 2);
                            short num5 = (short)(ledNum);
                            for (num = 0; num < num5; num = (short)(num + 1))
                            {
                                rectToDraw.X = (int)Math.Round((double)(((this._BorderWidth + this._Margin) + this._LEDInterval) + (num * (this._LEDInterval + this._LEDWidth))));
                                this.DrawNumber(g, rectToDraw, this._ShadowColor, '8');
                            }
                            break;
                        }
                    case AlignType.Right:
                        {
                            rectToDraw.X = 0;
                            rectToDraw.Y = (int)Math.Round((double)(this._BorderWidth + this._Margin));
                            rectToDraw.Width = (int)Math.Round((double)this._LEDWidth);
                            rectToDraw.Height = this.Height - (rectToDraw.Y * 2);
                            short num4 = ledNum;
                            for (num = 1; num <= num4; num = (short)(num + 1))
                            {
                                rectToDraw.X = (int)Math.Round((double)(((this.Width - this._BorderWidth) - this._Margin) - (num * (this._LEDInterval + this._LEDWidth))));
                                this.DrawNumber(g, rectToDraw, this._ShadowColor, '8');
                            }
                            break;
                        }
                }
            }
        }
        private void DrawTwoP(Graphics g, Rectangle RectToDraw)
        {
            float width = RectToDraw.Width * 0.2f;
            float x = RectToDraw.X + ((RectToDraw.Width - width) / 2f);
            float y = (RectToDraw.Y + this._SegmentWidth) + ((float)(((((((double)RectToDraw.Height) / 2.0) - this._SegmentWidth) - (this._SegmentWidth / 2f)) - width) * 0.699999988079071));
            float num4 = (float)(((RectToDraw.Y + (((double)RectToDraw.Height) / 2.0)) + (this._SegmentWidth / 2f)) + (((((((double)RectToDraw.Height) / 2.0) - this._SegmentWidth) - (this._SegmentWidth / 2f)) - width) * 0.30000001192092896));
            SolidBrush brush = new SolidBrush(this._ForeColor);
            g.FillRectangle(brush, x, y, width, width);
            g.FillRectangle(brush, x, num4, width, width);
            brush.Dispose();
        }

        private int GetLEDNum(string strText)
        {
            return strText.Trim().Replace(".", "").Length;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MoLedControl
            // 
            this.Name = "MoLedControl";
            this.Size = new System.Drawing.Size(245, 42);
            base.Click += new EventHandler(this.LEDNumber_Click);
            base.DoubleClick += new EventHandler(this.LEDNumber_DoubleClick);
            this._LEDStyle = LEDStyleEnum.Custom;
            this._Text = "12345678";
            this._TextAlign = AlignType.Right;
            this._DarkTime = 300;
            this._IsZeroFirst = false;
            this._BackColor = Color.Black;
            this._ForeColor = Color.Red;
            this._ShadowColor = Color.FromArgb(100, 100, 100);
            this._IsAntiAlias = false;
            this._CornerRate = 0.25f;
            this._BorderStyle = BorderStyleEnum.Outside;
            this._BorderWidth = 3;
            this._BorderColor = Color.Yellow;
            this._BorderLightColor = SystemColors.ControlLight;
            this._BorderShadowColor = SystemColors.ControlDark;
            this.bolDrawText = true;
            this.BackColor = this._BackColor;
            this.ResumeLayout(false);
        }

        [Description("单击LED控件时发生。"), Browsable(true)]
        private void LEDNumber_Click(object sender, EventArgs e)
        {
            if (this.LEDClick != null)
            {
                this.LEDClick(this, e);
            }
        }

        [Description("双击LED控件时发生。"), Browsable(true)]
        private void LEDNumber_DoubleClick(object sender, EventArgs e)
        {
            if (this.LEDDoubleClick != null)
            {
                this.LEDDoubleClick(this, e);
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.Clear(this._BackColor);
            this.SuspendLayout();
            this.DrawShadow(e.Graphics);
            hasPot = false;
            switch (this._LEDStyle)
            {
                case LEDStyleEnum.Custom:
                    if (!string.IsNullOrEmpty(_Text))
                    {
                        if (this.bolDrawText)
                        {
                            switch (this._TextAlign)
                            {
                                case AlignType.Left:
                                    this.DrawFromLeft(e.Graphics, this._Text);
                                    break;
                                case AlignType.Right:
                                    {
                                        this.DrawFromRight(e.Graphics, this._Text);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                    return;

                case LEDStyleEnum.DateTime:
                    try
                    {
                        this._Text = DateTime.Now.ToString(this._DateTimeFormatString);
                    }
                    catch
                    {
                        return;
                    }
                    if (this.bolDrawText)
                    {
                        switch (this._TextAlign)
                        {
                            case AlignType.Left:
                                this.DrawFromLeft(e.Graphics, this._Text);
                                break;
                            case AlignType.Right:
                                this.DrawFromRight(e.Graphics, this._Text);
                                break;
                        }
                    }
                    break;
            }
            this.DrawBorder(e.Graphics);
            this.ResumeLayout();
        }

        protected void ChangeText()
        {
            this.SuspendLayout();
            switch (this._LEDStyle)
            {
                case LEDStyleEnum.Custom:
                    if (!string.IsNullOrEmpty(_Text))
                    {
                        if (this.bolDrawText)
                        {
                            switch (this._TextAlign)
                            {
                                case AlignType.Left:
                                    this.DrawFromLeft(this.CreateGraphics(), this._Text);
                                    break;
                                case AlignType.Right:
                                    {
                                        this.DrawFromRight(this.CreateGraphics(), this._Text);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                    return;
                case LEDStyleEnum.DateTime:
                    try
                    {
                        this._Text = DateTime.Now.ToString(this._DateTimeFormatString);
                    }
                    catch
                    {
                        return;
                    }
                    if (this.bolDrawText)
                    {
                        switch (this._TextAlign)
                        {
                            case AlignType.Left:
                                this.DrawFromLeft(this.CreateGraphics(), this._Text);
                                break;
                            case AlignType.Right:
                                this.DrawFromRight(this.CreateGraphics(), this._Text);
                                break;
                        }
                    }
                    break;
            }
            this.ResumeLayout();
        }
        protected override void OnResize(EventArgs e)
        {
            this.ParameterInitial();
            this.Invalidate();
        }

        private void ParameterInitial()
        {
            this._Margin = (float)Math.Round((double)(this.Height * 0.04f));
            this._LEDWidth = (float)Math.Round((double)(this.Height * 0.45f));
            this._LEDInterval = (float)Math.Round((double)(this.Height * 0.08f));
            this._SegmentWidth = (float)Math.Round((double)(this.Height * 0.1f));
            this._SegmentInterval = (float)Math.Round((double)(this.Height * 0.01f));
            if (this._Margin < 2f)
            {
                this._Margin = 2f;
            }
            if (this._LEDWidth < 5f)
            {
                this._LEDWidth = 5f;
            }
            if (this._LEDInterval < 3f)
            {
                this._LEDInterval = 3f;
            }
            if (this._SegmentWidth < 1f)
            {
                this._SegmentWidth = 1f;
            }
            if (this._SegmentInterval < 1f)
            {
                this._SegmentInterval = 1f;
            }
        }

        public void ResetBorderColor()
        {
            this._BorderColor = Color.Yellow;
            this.Invalidate();
        }

        public void ResetBorderLightColor()
        {
            this._BorderLightColor = SystemColors.ControlLight;
            this.Invalidate();
        }

        public void ResetBorderShadowColor()
        {
            this._BorderShadowColor = SystemColors.ControlDark;
            this.Invalidate();
        }

        public void ResetBorderStyle()
        {
            this._BorderStyle = BorderStyleEnum.Outside;
            this.Invalidate();
        }

        public void ResetLEDBackColor()
        {
            this._BackColor = Color.Black;
            this.Invalidate();
        }

        public void ResetLEDForeColor()
        {
            this._ForeColor = Color.Red;
            this.Invalidate();
        }

        public void ResetLEDShadowColor()
        {
            this._ShadowColor = Color.FromArgb(100, 100, 100);
            this.Invalidate();
        }

        public void ResetLEDStyle()
        {
            this._LEDStyle = LEDStyleEnum.Custom;
            this.Invalidate();
        }

        public void ResetTextAlign()
        {
            this._TextAlign = AlignType.Right;
            this.Invalidate();
        }

        public bool ShouldSerializeBorderColor()
        {
            if (this._BorderColor == Color.Yellow)
            {
                return false;
            }
            return true;
        }

        public bool ShouldSerializeBorderLightColor()
        {
            if (this._BorderLightColor == SystemColors.ControlLight)
            {
                return false;
            }
            return true;
        }

        public bool ShouldSerializeBorderShadowColor()
        {
            if (this._BorderShadowColor == SystemColors.ControlDark)
            {
                return false;
            }
            return true;
        }

        public bool ShouldSerializeBorderStyle()
        {
            if (this._BorderStyle == BorderStyleEnum.Outside)
            {
                return false;
            }
            return true;
        }

        public bool ShouldSerializeLEDBackColor()
        {
            if (this._BackColor == Color.Black)
            {
                return false;
            }
            return true;
        }

        public bool ShouldSerializeLEDForeColor()
        {
            if (this._ForeColor == Color.Red)
            {
                return false;
            }
            return true;
        }

        public bool ShouldSerializeLEDShadowColor()
        {
            if (this._ShadowColor == Color.FromArgb(100, 100, 100))
            {
                return false;
            }
            return true;
        }

        public bool ShouldSerializeLEDStyle()
        {
            if (this._LEDStyle == LEDStyleEnum.Custom)
            {
                return false;
            }
            return true;
        }

        public bool ShouldSerializeTextAlign()
        {
            if (this._TextAlign == AlignType.Right)
            {
                return false;
            }
            return true;
        }

        private void subFlashText()
        {
            this.bolDrawText = !this.bolDrawText;
            this.Invalidate();
            System.Threading.Thread.Sleep(this._DarkTime);
            this.bolDrawText = !this.bolDrawText;
            this.Invalidate();
        }

        private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invalidate();
        }

        private void TimerFlash_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if ((this.m_FlashThread == null) || (this.m_FlashThread.ThreadState != System.Threading.ThreadState.Running))
            {
                this.m_FlashThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.subFlashText));
                this.m_FlashThread.Name = "FlashText";
                this.m_FlashThread.Priority = System.Threading.ThreadPriority.BelowNormal;
                this.m_FlashThread.Start();
            }
        }

        // Properties
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

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
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

        [Description("边框颜色。"), Category("LED边框")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }
            set
            {
                this._BorderColor = value;
                this.Invalidate();
            }
        }

        [Description("边框亮面颜色。"), Category("LED边框")]
        public Color BorderLightColor
        {
            get
            {
                return this._BorderLightColor;
            }
            set
            {
                this._BorderLightColor = value;
                this.Invalidate();
            }
        }

        [Description("边框暗面颜色。"), Category("LED边框")]
        public Color BorderShadowColor
        {
            get
            {
                return this._BorderShadowColor;
            }
            set
            {
                this._BorderShadowColor = value;
                this.Invalidate();
            }
        }

        [Category("LED边框"), Description("边框风格。")]
        public new BorderStyleEnum BorderStyle
        {
            get
            {
                return this._BorderStyle;
            }
            set
            {
                this._BorderStyle = value;
                if (value == BorderStyleEnum.None)
                {
                }
                this.Invalidate();
            }
        }

        [Description("边框宽度。"), DefaultValue(3), Category("LED边框")]
        public int BorderWidth
        {
            get
            {
                return this._BorderWidth;
            }
            set
            {
                if (((value < 0) || (value > this.Height)) || (value > this.Width))
                {
                    throw new ArgumentOutOfRangeException("BorderWidth", "该值必须大于零且小于控件长宽的最小值");
                }
                this._BorderWidth = value;
                this.Invalidate();
            }
        }

        [Category("LED绘制"), Description("段末端尖利度。值在 0～0.5 之间。"), DefaultValue((float)0.25f)]
        public float CornerRate
        {
            get
            {
                return this._CornerRate;
            }
            set
            {
                if ((value < 0f) || (value > 0.5))
                {
                    throw new ArgumentOutOfRangeException("CornerRate", "段末端尖利度必须大等于 0 且小于 0.5");
                }
                this._CornerRate = value;
                this.Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        [DefaultValue(false), Description("是否采用反锯齿技术。"), Category("LED绘制")]
        public bool IsAntiAlias
        {
            get
            {
                return this._IsAntiAlias;
            }
            set
            {
                this._IsAntiAlias = value;
                this.Invalidate();
            }
        }


        [Category("LED自定义数量"), Description("是否前位补零。仅右对齐风格和自定义LED数量有效。"), DefaultValue(false)]
        public bool IsZeroFirst
        {
            get
            {
                return this._IsZeroFirst;
            }
            set
            {
                this._IsZeroFirst = value;
                this.Invalidate();
            }
        }

        [Description("LED控件的背景色。"), Category("LED绘制")]
        public Color LEDBackColor
        {
            get
            {
                return this._BackColor;
            }
            set
            {
                this._BackColor = value;
                this.Invalidate();
            }
        }

        [Category("LED绘制"), Description("LED数字的前景色。")]
        public Color LEDForeColor
        {
            get
            {
                return this._ForeColor;
            }
            set
            {
                this._ForeColor = value;
                this.Invalidate();
            }
        }

        [Category("LED绘制"), Description("LED数字的阴影颜色。")]
        public Color LEDShadowColor
        {
            get
            {
                return this._ShadowColor;
            }
            set
            {
                this._ShadowColor = value;
                this.Invalidate();
            }
        }

        [Category("LED总体"), Description("控件显示风格。")]
        public LEDStyleEnum LEDStyle
        {
            get
            {
                return this._LEDStyle;
            }
            set
            {
                switch (value)
                {
                    case LEDStyleEnum.Custom:
                        //this.Timer1.Enabled = false;
                        break;

                    case LEDStyleEnum.DateTime:
                        if (string.IsNullOrEmpty(_DateTimeFormatString))
                        {
                            this._DateTimeFormatString = "yyyy-MM-dd hh:mm:ss";
                        }
                        try
                        {
                            string str = DateTime.Now.ToString(this._DateTimeFormatString);
                        }
                        catch (Exception exception1)
                        {
                            Exception exception = exception1;
                            //this.Timer1.Enabled = false;
                            throw new InvalidCastException("格式化字符串对时间类型无效");
                        }
                        //this.Timer1.Enabled = true;
                        break;
                }
                this._LEDStyle = value;
                this.Invalidate();
            }
        }

        [DefaultValue("123456789.0"), Category("LED总体"), Description("采用自定义风格时的显示内容。")]
        public string LEDText
        {
            get
            {
                return this._Text;
            }
            set
            {
                if (value.Length < this._Text.Length)
                {
                    this._Text = value;
                    this.Invalidate();
                }
                else
                {
                    this._Text = value;
                    this.ChangeText();
                }
            }
        }

        [Category("LED总体"), Description("文本的对齐方式。")]
        public AlignType TextAlign
        {
            get
            {
                return this._TextAlign;
            }
            set
            {
                this._TextAlign = value;
                this.Invalidate();
            }
        }

        // Nested Types
        public enum AlignType
        {
            Left,
            Right
        }

        public enum BorderStyleEnum
        {
            Outside,
            Inside,
            Flat,
            None
        }

        private delegate void FlashDelegate();

        public delegate void LEDClickEventHandler(object sender, EventArgs e);

        public delegate void LEDDoubleClickEventHandler(object sender, EventArgs e);

        public enum LEDStyleEnum
        {
            Custom,
            DateTime
        }
    }
}
