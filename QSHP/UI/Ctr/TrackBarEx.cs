using QSHP.Com;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;

namespace QSHP.UI.Ctr
{    
    /// <summary>
    /// A trackbar that supports transparency
    /// </summary>
    public class TrackBarEx : TrackBar
    {
        #region Fields

        private Rectangle ChannelBounds;
        private TrackBarOwnerDrawParts m_OwnerDrawParts;
        private Rectangle ThumbBounds;
        private int ThumbState;

        #endregion

        #region Public Events

        public event EventHandler<TrackBarDrawItemEventArgs> DrawChannel;
        public event EventHandler<TrackBarDrawItemEventArgs> DrawThumb;
        public event EventHandler<TrackBarDrawItemEventArgs> DrawTicks;

        #endregion

        #region Constructors

        public TrackBarEx()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Overrides WndProc to intercept custom draw messages in  the message queue
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 20)
            {
                m.Result = IntPtr.Zero;
            }
            else
            {
                base.WndProc(ref m);
                if (m.Msg == 0x204e)
                {
                    NativeMethods.NMHDR structure = (NativeMethods.NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NMHDR));
                    if (structure.code == -12)
                    {
                        IntPtr ptr;
                        Marshal.StructureToPtr(structure, m.LParam, false);
                        NativeMethods.NMCUSTOMDRAW nmcustomdraw = (NativeMethods.NMCUSTOMDRAW)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NMCUSTOMDRAW));
                        if (nmcustomdraw.dwDrawStage == NativeMethods.CustomDrawDrawStage.CDDS_PREPAINT)
                        {
                            Graphics graphics = Graphics.FromHdc(nmcustomdraw.hdc);
                            PaintEventArgs e = new PaintEventArgs(graphics, this.Bounds);
                            e.Graphics.TranslateTransform((float)(0 - this.Left), (float)(0 - this.Top));
                            this.InvokePaintBackground(this.Parent, e);
                            this.InvokePaint(this.Parent, e);
                            SolidBrush brush = new SolidBrush(this.BackColor);
                            e.Graphics.FillRectangle(brush, this.Bounds);
                            brush.Dispose();
                            e.Graphics.ResetTransform();
                            e.Dispose();
                            graphics.Dispose();
                            ptr = new IntPtr(0x30);
                            m.Result = ptr;
                        }
                        else if (nmcustomdraw.dwDrawStage == NativeMethods.CustomDrawDrawStage.CDDS_POSTPAINT)
                        {
                            this.OnDrawTicks(nmcustomdraw.hdc);
                            this.OnDrawChannel(nmcustomdraw.hdc);
                            this.OnDrawThumb(nmcustomdraw.hdc);
                        }
                        else if (nmcustomdraw.dwDrawStage == NativeMethods.CustomDrawDrawStage.CDDS_ITEMPREPAINT)
                        {
                            if (nmcustomdraw.dwItemSpec.ToInt32() == 2)
                            {
                                this.ThumbBounds = nmcustomdraw.rc.ToRectangle();
                                if (this.Enabled)
                                {
                                    if (nmcustomdraw.uItemState == NativeMethods.CustomDrawItemState.CDIS_SELECTED)
                                    {
                                        this.ThumbState = 3;
                                    }
                                    else
                                    {
                                        this.ThumbState = 1;
                                    }
                                }
                                else
                                {
                                    this.ThumbState = 5;
                                }
                                this.OnDrawThumb(nmcustomdraw.hdc);
                            }
                            else if (nmcustomdraw.dwItemSpec.ToInt32() == 3)
                            {
                                this.ChannelBounds = nmcustomdraw.rc.ToRectangle();
                                this.OnDrawChannel(nmcustomdraw.hdc);
                            }
                            else if (nmcustomdraw.dwItemSpec.ToInt32() == 1)
                            {
                                this.OnDrawTicks(nmcustomdraw.hdc);
                            }
                            ptr = new IntPtr(4);
                            m.Result = ptr;
                        }
                    }
                }
            }
        }

        #endregion

        #region Private Drawing Methods

        /// <summary>
        /// Draws horizontal ticks
        /// </summary>
        /// <param name="g">The graphics context</param>
        /// <param name="color">The colour of the ticks</param>
        private void DrawHorizontalTicks(Graphics g, Color color)
        {
            RectangleF innerTickRect;
            int numofTicks = (this.Maximum / this.TickFrequency) - 1;
            Pen tickPen = new Pen(color);
            RectangleF endTickRRect = new RectangleF((float)(this.ChannelBounds.Left + (this.ThumbBounds.Width / 2)), (float)(this.ThumbBounds.Top - 5), 0f, 3f);
            RectangleF endTickLRect = new RectangleF((float)((this.ChannelBounds.Right - (this.ThumbBounds.Width / 2)) - 1), (float)(this.ThumbBounds.Top - 5), 0f, 3f);
            float tickPitch = (endTickLRect.Right - endTickRRect.Left) / ((float)(numofTicks + 1));
            // Draw upper (top) ticks
            if (this.TickStyle != TickStyle.BottomRight)
            {
                // Draw right outer tick
                g.DrawLine(tickPen, endTickRRect.Left, endTickRRect.Top, endTickRRect.Right, endTickRRect.Bottom);
                // Draw left outer tick
                g.DrawLine(tickPen, endTickLRect.Left, endTickLRect.Top, endTickLRect.Right, endTickLRect.Bottom);
                // Draw inner ticks
                innerTickRect = endTickRRect;
                innerTickRect.Height--;
                innerTickRect.Offset(tickPitch, 1f);
                int numOfInnerTicks = numofTicks - 1;
                for (int i = 0; i <= numOfInnerTicks; i++)
                {
                    g.DrawLine(tickPen, innerTickRect.Left, innerTickRect.Top, innerTickRect.Left, innerTickRect.Bottom);
                    innerTickRect.Offset(tickPitch, 0f);
                }
            }
            endTickRRect.Offset(0f, (float)(this.ThumbBounds.Height + 6));
            endTickLRect.Offset(0f, (float)(this.ThumbBounds.Height + 6));
            // Draw lower (bottom) ticks
            if (this.TickStyle != TickStyle.TopLeft)
            {
                // Draw right outer tick
                g.DrawLine(tickPen, endTickRRect.Left, endTickRRect.Top, endTickRRect.Left, endTickRRect.Bottom);
                // Draw left outer tick
                g.DrawLine(tickPen, endTickLRect.Left, endTickLRect.Top, endTickLRect.Left, endTickLRect.Bottom);
                // Draw innerticks
                innerTickRect = endTickRRect;
                innerTickRect.Height--;
                innerTickRect.Offset(tickPitch, 0f);
                int numOfInnerTicks = numofTicks - 1;
                for (int j = 0; j <= numOfInnerTicks; j++)
                {
                    g.DrawLine(tickPen, innerTickRect.Left, innerTickRect.Top, innerTickRect.Left, innerTickRect.Bottom);
                    innerTickRect.Offset(tickPitch, 0f);
                }
            }
            tickPen.Dispose();
        }

        /// <summary>
        /// Draws the ticks on a vertical track-bar
        /// </summary>
        /// <param name="g">The graphics context</param>
        /// <param name="color">The colour of which to draw the ticks</param>
        private void DrawVerticalTicks(Graphics g, Color color)
        {
            RectangleF innerTickRect;
            int numOfTicks = (this.Maximum / this.TickFrequency) - 1;
            Pen tickPen = new Pen(color);
            RectangleF endTickBottomRect = new RectangleF((float)(this.ThumbBounds.Left - 5), (float)((this.ChannelBounds.Bottom - (this.ThumbBounds.Height / 2)) - 1), 3f, 0f);
            RectangleF endTickTopRect = new RectangleF((float)(this.ThumbBounds.Left - 5), (float)(this.ChannelBounds.Top + (this.ThumbBounds.Height / 2)), 3f, 0f);
            float y = (endTickTopRect.Bottom - endTickBottomRect.Top) / ((float)(numOfTicks + 1));
            // Draw left-hand ticks
            if (this.TickStyle != TickStyle.BottomRight)
            {
                // Draw lower (bottom) outer tick
                g.DrawLine(tickPen, endTickBottomRect.Left, endTickBottomRect.Top, endTickBottomRect.Right, endTickBottomRect.Bottom);
                // Draw upper (top) outer tick
                g.DrawLine(tickPen, endTickTopRect.Left, endTickTopRect.Top, endTickTopRect.Right, endTickTopRect.Bottom);
                // Draw inner ticks
                innerTickRect = endTickBottomRect;
                innerTickRect.Width--;
                innerTickRect.Offset(1f, y);
                int numOfInnerTicks = numOfTicks - 1;
                for (int i = 0; i <= numOfInnerTicks; i++)
                {
                    g.DrawLine(tickPen, innerTickRect.Left, innerTickRect.Top, innerTickRect.Right, innerTickRect.Bottom);
                    innerTickRect.Offset(0f, y);
                }
            }
            endTickBottomRect.Offset((float)(this.ThumbBounds.Width + 6), 0f);
            endTickTopRect.Offset((float)(this.ThumbBounds.Width + 6), 0f);
            // Draw right-hand ticks
            if (this.TickStyle != TickStyle.TopLeft)
            {
                // Draw lower (bottom) tick
                g.DrawLine(tickPen, endTickBottomRect.Left, endTickBottomRect.Top, endTickBottomRect.Right, endTickBottomRect.Bottom);
                // Draw upper (top) tick
                g.DrawLine(tickPen, endTickTopRect.Left, endTickTopRect.Top, endTickTopRect.Right, endTickTopRect.Bottom);
                // Draw inner ticks
                innerTickRect = endTickBottomRect;
                innerTickRect.Width--;
                innerTickRect.Offset(0f, y);
                int numOfInnerTicks = numOfTicks - 1;
                for (int j = 0; j <= numOfInnerTicks; j++)
                {
                    g.DrawLine(tickPen, innerTickRect.Left, innerTickRect.Top, innerTickRect.Right, innerTickRect.Bottom);
                    innerTickRect.Offset(0f, y);
                }
            }
            tickPen.Dispose();
        }

        /// <summary>
        /// Draw a downward pointer
        /// </summary>
        /// <param name="g">The graphics context</param>
        private void DrawPointerDown(Graphics g)
        {
            Point[] points = new Point[6]
            {
                new Point(this.ThumbBounds.Left + (this.ThumbBounds.Width / 2), this.ThumbBounds.Bottom - 1),
                new Point(this.ThumbBounds.Left, (this.ThumbBounds.Bottom - (this.ThumbBounds.Width / 2)) - 1),
                this.ThumbBounds.Location,
                new Point(this.ThumbBounds.Right - 1, this.ThumbBounds.Top),
                new Point(this.ThumbBounds.Right - 1, (this.ThumbBounds.Bottom - (this.ThumbBounds.Width / 2)) - 1),
                new Point(this.ThumbBounds.Left + (this.ThumbBounds.Width / 2), this.ThumbBounds.Bottom - 1)
            };
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            Region region = new Region(path);
            g.Clip = region;
            if ((this.ThumbState == 3) || !this.Enabled)
            {
                ControlPaint.DrawButton(g, this.ThumbBounds, ButtonState.All);
            }
            else
            {
                g.Clear(SystemColors.Control);
            }
            g.ResetClip();
            region.Dispose();
            path.Dispose();
            // Draw light shadow
            Point[] shadowPoints = new Point[] { points[0], points[1], points[2], points[3] };
            g.DrawLines(SystemPens.ControlLightLight, shadowPoints);
            // Draw dark shadow
            shadowPoints = new Point[] { points[3], points[4], points[5] };
            g.DrawLines(SystemPens.ControlDarkDark, shadowPoints);
            points[0].Offset(0, -1);
            points[1].Offset(1, 0);
            points[2].Offset(1, 1);
            points[3].Offset(-1, 1);
            points[4].Offset(-1, 0);
            points[5] = points[0];
            shadowPoints = new Point[] { points[0], points[1], points[2], points[3] };
            g.DrawLines(SystemPens.ControlLight, shadowPoints);
            shadowPoints = new Point[] { points[3], points[4], points[5] };
            g.DrawLines(SystemPens.ControlDark, shadowPoints);
        }

        /// <summary>
        /// Draw left-facing pointer
        /// </summary>
        /// <param name="g">The graphics context</param>
        private void DrawPointerLeft(Graphics g)
        {
            Point[] points = new Point[6]
            {            
                new Point(this.ThumbBounds.Left, this.ThumbBounds.Top + (this.ThumbBounds.Height / 2)),
                new Point(this.ThumbBounds.Left + (this.ThumbBounds.Height / 2), this.ThumbBounds.Top),
                new Point(this.ThumbBounds.Right - 1, this.ThumbBounds.Top),
                new Point(this.ThumbBounds.Right - 1, this.ThumbBounds.Bottom - 1),
                new Point(this.ThumbBounds.Left + (this.ThumbBounds.Height / 2), this.ThumbBounds.Bottom - 1),
                new Point(this.ThumbBounds.Left, this.ThumbBounds.Top + (this.ThumbBounds.Height / 2)),
            };
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            Region region = new Region(path);
            g.Clip = region;
            if ((this.ThumbState == 3) || !this.Enabled)
            {
                ControlPaint.DrawButton(g, this.ThumbBounds, ButtonState.All);
            }
            else
            {
                g.Clear(SystemColors.Control);
            }
            g.ResetClip();
            region.Dispose();
            path.Dispose();
            // Draw light shadow
            Point[] shadowPoints = new Point[] { points[0], points[1], points[2] };
            g.DrawLines(SystemPens.ControlLightLight, shadowPoints);
            // Draw dark shadow
            shadowPoints = new Point[] { points[2], points[3], points[4], points[5] };
            g.DrawLines(SystemPens.ControlDarkDark, shadowPoints);
            points[0].Offset(1, 0);
            points[1].Offset(0, 1);
            points[2].Offset(-1, 1);
            points[3].Offset(-1, -1);
            points[4].Offset(0, -1);
            points[5] = points[0];
            shadowPoints = new Point[] { points[0], points[1], points[2] };
            g.DrawLines(SystemPens.ControlLight, shadowPoints);
            shadowPoints = new Point[] { points[2], points[3], points[4], points[5] };
            g.DrawLines(SystemPens.ControlDark, shadowPoints);
        }

        /// <summary>
        /// Draws a right-facing pointer
        /// </summary>
        /// <param name="g">The graphics context</param>
        private void DrawPointerRight(Graphics g)
        {
            Point[] points = new Point[6]
            {
                new Point(this.ThumbBounds.Left, this.ThumbBounds.Bottom - 1),
                new Point(this.ThumbBounds.Left, this.ThumbBounds.Top),
                new Point((this.ThumbBounds.Right - (this.ThumbBounds.Height / 2)) - 1, this.ThumbBounds.Top),
                new Point(this.ThumbBounds.Right - 1, this.ThumbBounds.Top + (this.ThumbBounds.Height / 2)),
                new Point((this.ThumbBounds.Right - (this.ThumbBounds.Height / 2)) - 1, this.ThumbBounds.Bottom - 1),
                new Point(this.ThumbBounds.Left, this.ThumbBounds.Bottom - 1)
            };
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            Region region = new Region(path);
            g.Clip = region;
            if ((this.ThumbState == 3) || !this.Enabled)
            {
                ControlPaint.DrawButton(g, this.ThumbBounds, ButtonState.All);
            }
            else
            {
                g.Clear(SystemColors.Control);
            }
            g.ResetClip();
            region.Dispose();
            path.Dispose();
            // Draw light shadow
            Point[] shadowPoints = new Point[] { points[0], points[1], points[2], points[3] };
            g.DrawLines(SystemPens.ControlLightLight, shadowPoints);
            // Draw dark shadow
            shadowPoints = new Point[] { points[3], points[4], points[5] };
            g.DrawLines(SystemPens.ControlDarkDark, shadowPoints);
            points[0].Offset(1, -1);
            points[1].Offset(1, 1);
            points[2].Offset(0, 1);
            points[3].Offset(-1, 0);
            points[4].Offset(0, -1);
            points[5] = points[0];
            shadowPoints = new Point[] { points[0], points[1], points[2], points[3] };
            g.DrawLines(SystemPens.ControlLight, shadowPoints);
            shadowPoints = new Point[] { points[3], points[4], points[5] };
            g.DrawLines(SystemPens.ControlDark, shadowPoints);
        }

        /// <summary>
        /// Draws an upwards facing pointer
        /// </summary>
        /// <param name="g">The graphics context</param>
        private void DrawPointerUp(Graphics g)
        {
            Point[] points = new Point[6]
            {
                new Point(this.ThumbBounds.Left, this.ThumbBounds.Bottom - 1),
                new Point(this.ThumbBounds.Left, this.ThumbBounds.Top + (this.ThumbBounds.Width / 2)),
                new Point(this.ThumbBounds.Left + (this.ThumbBounds.Width / 2), this.ThumbBounds.Top),
                new Point(this.ThumbBounds.Right - 1, this.ThumbBounds.Top + (this.ThumbBounds.Width / 2)),
                new Point(this.ThumbBounds.Right - 1, this.ThumbBounds.Bottom - 1),
                new Point(this.ThumbBounds.Left, this.ThumbBounds.Bottom - 1)
            };
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            Region region = new Region(path);
            g.Clip = region;
            if ((this.ThumbState == 3) || !this.Enabled)
            {
                ControlPaint.DrawButton(g, this.ThumbBounds, ButtonState.All);
            }
            else
            {
                g.Clear(SystemColors.Control);
            }
            g.ResetClip();
            region.Dispose();
            path.Dispose();
            // Draw light shadow
            Point[] shadowPoints = new Point[] { points[0], points[1], points[2] };
            g.DrawLines(SystemPens.ControlLightLight, shadowPoints);
            // Draw dark shadow
            shadowPoints = new Point[] { points[2], points[3], points[4], points[5] };
            g.DrawLines(SystemPens.ControlDarkDark, shadowPoints);
            points[0].Offset(1, -1);
            points[1].Offset(1, 0);
            points[2].Offset(0, 1);
            points[3].Offset(-1, 0);
            points[4].Offset(-1, -1);
            points[5] = points[0];
            shadowPoints = new Point[] { points[0], points[1], points[2] };
            g.DrawLines(SystemPens.ControlLight, shadowPoints);
            shadowPoints = new Point[] { points[2], points[3], points[4], points[5] };
            g.DrawLines(SystemPens.ControlDark, shadowPoints);
        }

        #endregion

        #region Event Invoker Methods

        /// <summary>
        /// Fires the tick drawing events
        /// </summary>
        /// <param name="hdc">The device context that holds the graphics operations</param>
        protected virtual void OnDrawTicks(IntPtr hdc)
        {
            Graphics graphics = Graphics.FromHdc(hdc);
            if (((this.OwnerDrawParts & TrackBarOwnerDrawParts.Ticks) == TrackBarOwnerDrawParts.Ticks) && !this.DesignMode)
            {
                TrackBarDrawItemEventArgs e = new TrackBarDrawItemEventArgs(graphics, this.ClientRectangle, (TrackBarItemState)this.ThumbState);
                if (this.DrawTicks != null)
                {
                    this.DrawTicks(this, e);
                }
            }
            else
            {
                if (this.TickStyle == TickStyle.None)
                {
                    return;
                }
                if (this.ThumbBounds.Equals(Rectangle.Empty))
                {
                    return;
                }
                Color black = Color.Black;
                if (VisualStyleRenderer.IsSupported)
                {
                    VisualStyleRenderer vsr = new VisualStyleRenderer("TRACKBAR", (int)NativeMethods.TrackBarParts.TKP_TICS, ThumbState);
                    black = vsr.GetColor(ColorProperty.TextColor);
                }
                if (this.Orientation == Orientation.Horizontal)
                {
                    this.DrawHorizontalTicks(graphics, black);
                }
                else
                {
                    this.DrawVerticalTicks(graphics, black);
                }
            }
            graphics.Dispose();
        }

        /// <summary>
        /// Fires the DrawThumb events
        /// </summary>
        /// <param name="hdc">The device context for graphics operations</param>
        protected virtual void OnDrawThumb(IntPtr hdc)
        {
            Graphics graphics = Graphics.FromHdc(hdc);
            graphics.Clip = new Region(this.ThumbBounds);
            if (((this.OwnerDrawParts & TrackBarOwnerDrawParts.Thumb) == TrackBarOwnerDrawParts.Thumb) && !this.DesignMode)
            {
                TrackBarDrawItemEventArgs e = new TrackBarDrawItemEventArgs(graphics, this.ThumbBounds, (TrackBarItemState)this.ThumbState);
                if (this.DrawThumb != null)
                {
                    this.DrawThumb(this, e);
                }
            }
            else
            {
                // Determine the style of the thumb, based on the tickstyle
                NativeMethods.TrackBarParts part = NativeMethods.TrackBarParts.TKP_THUMB;
                if (this.ThumbBounds.Equals(Rectangle.Empty))
                {
                    return;
                }
                switch (this.TickStyle)
                {
                    case TickStyle.None:
                    case TickStyle.BottomRight:
                        part = (Orientation != Orientation.Horizontal) ? NativeMethods.TrackBarParts.TKP_THUMBRIGHT : NativeMethods.TrackBarParts.TKP_THUMBBOTTOM;
                        break;
                    case TickStyle.TopLeft:
                        part = (this.Orientation != Orientation.Horizontal) ? NativeMethods.TrackBarParts.TKP_THUMBLEFT : NativeMethods.TrackBarParts.TKP_THUMBTOP;
                        break;

                    case TickStyle.Both:
                        part = (this.Orientation != Orientation.Horizontal) ? NativeMethods.TrackBarParts.TKP_THUMBVERT : NativeMethods.TrackBarParts.TKP_THUMB;
                        break;
                }
                // Perform drawing
                if (VisualStyleRenderer.IsSupported)
                {
                    VisualStyleRenderer vsr = new VisualStyleRenderer("TRACKBAR", (int)part, ThumbState);
                    vsr.DrawBackground(graphics, this.ThumbBounds);
                    graphics.ResetClip();
                    graphics.Dispose();
                    return;
                }
                else
                {
                    switch (part)
                    {
                        case NativeMethods.TrackBarParts.TKP_THUMBBOTTOM:
                            this.DrawPointerDown(graphics);
                            break;
                        case NativeMethods.TrackBarParts.TKP_THUMBTOP:
                            this.DrawPointerUp(graphics);

                            break;
                        case NativeMethods.TrackBarParts.TKP_THUMBLEFT:
                            this.DrawPointerLeft(graphics);

                            break;
                        case NativeMethods.TrackBarParts.TKP_THUMBRIGHT:
                            this.DrawPointerRight(graphics);

                            break;
                        default:
                            if ((this.ThumbState == 3) || !this.Enabled)
                            {
                                ControlPaint.DrawButton(graphics, this.ThumbBounds, ButtonState.All);
                            }
                            else
                            {
                                // Tick-style is both - draw the thumb as a solid rectangle
                                graphics.FillRectangle(SystemBrushes.Control, this.ThumbBounds);
                            }
                            ControlPaint.DrawBorder3D(graphics, this.ThumbBounds, Border3DStyle.Raised);
                            break;
                    }
                }
            }
            graphics.ResetClip();
            graphics.Dispose();
        }

        /// <summary>
        /// Fires the DrawChannel events
        /// </summary>
        /// <param name="hdc">The device context for graphics operations</param>
        protected virtual void OnDrawChannel(IntPtr hdc)
        {
            Graphics graphics = Graphics.FromHdc(hdc);
            if (((this.OwnerDrawParts & TrackBarOwnerDrawParts.Channel) == TrackBarOwnerDrawParts.Channel) && !this.DesignMode)
            {
                TrackBarDrawItemEventArgs e = new TrackBarDrawItemEventArgs(graphics, this.ChannelBounds, (TrackBarItemState)this.ThumbState);
                if (this.DrawChannel != null)
                {
                    this.DrawChannel(this, e);
                }
            }
            else
            {
                if (this.ChannelBounds.Equals(Rectangle.Empty))
                {
                    return;
                }
                if (VisualStyleRenderer.IsSupported)
                {
                    VisualStyleRenderer vsr = new VisualStyleRenderer("TRACKBAR", (int)NativeMethods.TrackBarParts.TKP_TRACK, (int)TrackBarItemState.Normal);
                    vsr.DrawBackground(graphics, this.ChannelBounds);
                    graphics.ResetClip();
                    graphics.Dispose();
                    return;
                }
                ControlPaint.DrawBorder3D(graphics, this.ChannelBounds, Border3DStyle.Sunken);
            }
            graphics.Dispose();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets which parts of the trackbar will be owner drawn
        /// </summary>
        [DefaultValue(typeof(TrackBarOwnerDrawParts), "None")]
        [Description("Gets/sets the trackbar parts that will be OwnerDrawn.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(TrackDrawModeEditor), typeof(UITypeEditor))]
        public TrackBarOwnerDrawParts OwnerDrawParts
        {
            get
            {
                return this.m_OwnerDrawParts;
            }
            set
            {
                this.m_OwnerDrawParts = value;
            }
        }

        #endregion
    }

    public class TrackBarDrawItemEventArgs : EventArgs
    {
        #region Fields

        private Rectangle _bounds;
        private Graphics _graphics;
        private TrackBarItemState _state;

        #endregion

        #region Methods

        public TrackBarDrawItemEventArgs(Graphics graphics, Rectangle bounds, TrackBarItemState state)
        {
            this._graphics = graphics;
            this._bounds = bounds;
            this._state = state;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the bounds
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                return this._bounds;
            }
        }

        /// <summary>
        /// Gets the graphics context
        /// </summary>
        public Graphics Graphics
        {
            get
            {
                return this._graphics;
            }
        }

        /// <summary>
        /// Gets the state of the item
        /// </summary>
        public TrackBarItemState State
        {
            get
            {
                return this._state;
            }
        }

        #endregion
    }

    public enum TrackBarItemState
    {
        Active = 3,
        Disabled = 5,
        Hot = 2,
        Normal = 1
    }

    [Flags]
    public enum TrackBarOwnerDrawParts
    {
        Channel = 4,
        None = 0,
        Thumb = 2,
        Ticks = 1
    }
    public class TrackDrawModeEditor : UITypeEditor
    {
        #region Methods

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            TrackBarOwnerDrawParts parts = TrackBarOwnerDrawParts.None;
            if (!(value is TrackBarOwnerDrawParts) || (provider == null))
            {
                return value;
            }
            IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (service == null)
            {
                return value;
            }
            CheckedListBox control = new CheckedListBox();
            control.BorderStyle = BorderStyle.None;
            control.CheckOnClick = true;
            control.Items.Add("Ticks", (((TrackBarEx)context.Instance).OwnerDrawParts & TrackBarOwnerDrawParts.Ticks) == TrackBarOwnerDrawParts.Ticks);
            control.Items.Add("Thumb", (((TrackBarEx)context.Instance).OwnerDrawParts & TrackBarOwnerDrawParts.Thumb) == TrackBarOwnerDrawParts.Thumb);
            control.Items.Add("Channel", (((TrackBarEx)context.Instance).OwnerDrawParts & TrackBarOwnerDrawParts.Channel) == TrackBarOwnerDrawParts.Channel);
            service.DropDownControl(control);
            IEnumerator enumerator = control.CheckedItems.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
                parts |= (TrackBarOwnerDrawParts)Enum.Parse(typeof(TrackBarOwnerDrawParts), objectValue.ToString());
            }
            control.Dispose();
            service.CloseDropDown();
            return parts;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        #endregion
    }


}
