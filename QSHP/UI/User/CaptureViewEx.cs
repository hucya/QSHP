using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Windows.Threading;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;
using QSHP.HW;
using QSHP.HW.Video;
using QSHP.Com;
using System.IO;
using QSHP.UI.Ctr;

namespace QSHP.UI
{
    public partial class CaptureViewEx : UserControl
    {
        public event PaintEventHandler UserPaint;
        public event EventHandler ChangeCaptureViewModeHander;
        DispatcherTimer timer = new DispatcherTimer();
        IVideoProvider captureProvider;
        SolidBrush drawBrush = new SolidBrush(Color.Red);
        PointF drawPoint = new PointF(150.0F, 420.0F);
        VideoMode showMode = VideoMode.Logo;//虚拟模式
        Pen drawPen = new Pen(Color.MediumSpringGreen, 1);
        Font ft = new System.Drawing.Font("微软雅黑", 10F);
        string widthString = string.Empty;
        int xGuidesWidth = 60;
        int yGuidesWidth = 258;
        int strShowTime = 0;
        bool showflag = true;
        bool mouseFollow = true;
        bool applyBinning = true;
        int btTick = 0;
        float h, w, y1, y2, x1, x2;
        float xStep = 2;
        float yStep = 2;
        bool xStepDefault = false;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public ButtonEx IncChButton
        {
            get
            {
                return Axis.IncButton;
            }
        }
        public ButtonEx DecChButton
        {
            get
            {
                return Axis.DecButton;
            }
        }
        public int XGuidesWidth
        {
            get
            {
                return xGuidesWidth;
            }
            set
            {
                if (value <= imageCtr.Height && value >= 0)
                {
                    xGuidesWidth = value;
                }
            }
        }

        public float GuidesLineWidth
        {
            get
            {
                if (captureProvider != null)
                {
                    return xGuidesWidth*captureProvider.Scale;
                }
                else
                {
                    return xGuidesWidth;
                }
               
            }
        }
        public bool IncWidthPressed
        {
            get
            {
                return BT6.Pressed;
            }
        }
        public bool DecWidthPressed
        {
            get
            {
                return BT7.Pressed;
            }
        }
        public bool IncHeightPressed
        {
            get
            {
                return BT4.Pressed;
            }
        }
        public bool DecHeightPressed
        {
            get
            {
                return BT5.Pressed;
            }
        }
        public IVideoProvider CaptureProvider
        {
            get
            {
                if (captureProvider == null)
                {
                    if (Globals.DoubleCap && !Globals.HighCCD)
                    {
                        captureProvider = Common.CaptureL;
                    }
                    else
                    {
                        captureProvider = Common.Capture;
                    }
                }
                return captureProvider;
            }
            set
            {
                if (captureProvider != value)
                {
                    if (captureProvider != null && captureProvider.IsRunning)
                    {
                        StopCapture();
                    }
                    captureProvider = value;
                    switch (showMode)
                    {
                        case VideoMode.RealFollow:
                        case VideoMode.RealTime:
                            {
                                StartCapture();
                            }
                            break;
                        default:
                            {
                            }
                            break;
                    }
                    VC1.CaptureProvider = captureProvider;
                    if (VC1.Visible)
                    {
                        VC1.Enabled = true;
                    }
                }
            }
        }
        public VideoMode ShowMode
        {
            get
            {
                return showMode;
            }
            set
            {
                if (showMode != value)
                {
                    showMode = value;
                    switch (showMode)
                    {
                        case VideoMode.RealFollow:
                        case VideoMode.RealTime:
                            {
                                if (CaptureProvider != null && !CaptureProvider.IsRunning)
                                {
                                    if (CaptureProvider.StartCapture())
                                    {
                                        timer.Start();
                                    }
                                }
                            }
                            break;
                        default:
                            {
                                if (CaptureProvider != null && CaptureProvider.IsRunning)
                                {
                                    CaptureProvider.StopCapture();
                                }
                            }
                            break;
                    }
                }
            }
        }

        public int YGuidesWidth
        {
            get
            {
                return yGuidesWidth;
            }

            set
            {
                if (value <= imageCtr.Width && value >= 0)
                {
                    yGuidesWidth = value;
                }
            }
        }

        public bool MouseFollow
        {
            get
            {
                return mouseFollow;
            }

            set
            {
                mouseFollow = value;
            }
        }
        
        public bool ApplyBinning
        {
            get
            {
                return applyBinning;
            }

            set
            {
                applyBinning = value;
            }
        }

        public float XStep
        {
            get
            {
                return xStep;
            }

            set
            {
                if (xStepDefault)
                {
                    xStep = imageCtr.Width * CaptureProvider.Scale;
                }
                else
                {
                    xStep = value;
                    if (Common.X_Axis != null)
                    {
                        Common.X_Axis.Param.StepPos = xStep;//设置X轴步进距离
                    }
                }
            }
        }

        public float YStep
        {
            get
            {
                return yStep;
            }

            set
            {
                yStep = value;
                if (Common.Y_Axis != null)
                {
                    Common.Y_Axis.Param.StepPos = YStep;//设置Y轴步进距离
                }
            }
        }

        public bool XStepDefault
        {
            get
            {
                return xStepDefault;
            }

            set
            {
                xStepDefault = value;
            }
        }

        public CaptureViewEx()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += new EventHandler(Timer_Tick);
            drawPen.DashStyle = DashStyle.Dash;
            imageCtr.Image = QSHP.Properties.Resources.logo_1;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint, true);
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            if (Axis.Visible)
            {
                Axis.AutoUpdata();
            }
            ShowImagePagram();
        }
        private void ShowImagePagram()
        {
            if (showflag)
            {
                showflag = false;
                switch (showMode)
                {
                    case VideoMode.RealTime:
                    case VideoMode.RealFollow:
                        {
                            ShowRealTimePicture();
                        }
                        break;
                    case VideoMode.Logo:
                        {
                            this.BeginInvoke((Action)delegate () { imageCtr.Image = QSHP.Properties.Resources.logo_1; });
                            timer.Stop();
                        }
                        break;
                    case VideoMode.Virual:
                        {
                            using (Graphics gph1 = Graphics.FromHwnd(imageCtr.Handle))
                            {

                            }
                        }
                        break;
                    default:
                        {
                            this.BeginInvoke((Action)delegate () { imageCtr.Image = QSHP.Properties.Resources.logo_1; });
                            timer.Stop();
                        }
                        break;
                }
                showflag = true;
            }
        }

        public bool SetCaptureSource(IVideoProvider cap)
        {
            if (CaptureProvider != null)
            {
                if (CaptureProvider.IsRunning)
                {
                    CaptureProvider.StopCapture();
                }
                if (!cap.IsInit)
                {
                    cap.InitDriver();
                }
                CaptureProvider = cap;
                return CaptureProvider.StartCapture();
            }
            else
            {
                CaptureProvider = cap;
                return true;
            }
        }

        public bool StartCapture()
        {
            try
            {
                if (CaptureProvider == null)
                {
                    if (Globals.DoubleCap)
                    {
                        CaptureProvider = Common.CaptureL;
                    }
                    else
                    {
                        CaptureProvider = Common.Capture;
                    }
                }
                if (CaptureProvider != null)
                {
                    VC1.CaptureProvider = CaptureProvider;
                    if (!CaptureProvider.IsInit)
                    {
                        CaptureProvider.InitDriver();
                    }
                    CaptureProvider.BinningMode = !Globals.HighCCD;
                    if (CaptureProvider.IsRunning)
                    {
                        timer.Start();
                        return true;
                    }
                    if (CaptureProvider.StartCapture())
                    {
                        this.showMode = VideoMode.RealTime;
                        timer.Start();
                    }
                    GC.Collect();
                    return CaptureProvider.IsRunning;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool StopCapture()
        {
            if (CaptureProvider != null)
            {
                timer.Stop();
                GC.Collect();
                imageCtr.Image = QSHP.Properties.Resources.logo_1;
                return CaptureProvider.StopCapture();
            }
            else
            {
                return false;
            }
        }

        private void BT8_Click(object sender, EventArgs e)
        {
            if (Common.HwProvider.CreateSucessful)//&&Common.X_Axis.Connected)
            {
                if (Globals.IDIE)
                {
                    Axis.Visible = !Axis.Visible;
                    if (Axis.Visible)
                    {
                        Axis.Parent = imageCtr;
                    }
                    else
                    {
                        Axis.Parent = panel5;
                    }
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0029);
                    Axis.Visible = false;
                }
            }
            else
            {
                Axis.Visible = false;
                Axis.Parent = panel5;
            }
        }

        private void BT1_Click(object sender, EventArgs e)
        {
            if (Common.HwProvider.CreateSucessful & Common.Capture.IsInit)
            {
                if (Globals.IDIE)
                {
                    VC1.Visible = !VC1.Visible;
                    if (VC1.Visible)
                    {
                        VC1.ForeColor = Color.MediumSpringGreen;
                        VC1.Parent = imageCtr;
                    }
                    else
                    {
                        VC1.Parent = panel5;
                    }

                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0029);
                }
            }
            else
            {
                VC1.Visible = false;
                VC1.Parent = panel5;
            }
        }

        private void BT2_Click(object sender, EventArgs e)
        {
            ChangeCaptureMode();
        }

        public bool ChangeCaptureMode()
        {
            VC1.Visible = false;
            if (Globals.DoubleCap)//改变倍率
            {
                if (Common.X_Axis.IsInPosition && Common.Y_Axis.IsInPosition)
                {
                    Globals.HighCCD = !Globals.HighCCD;
                    if (Globals.HighCCD)
                    {
                        CaptureProvider = Common.Capture;
                    }
                    else
                    {
                        CaptureProvider = Common.CaptureL;
                    }
                    float x = Globals.DevData.HighCenterX- Globals.DevData.LowCenterX;
                    float y = Globals.DevData.HighCenterY- Globals.DevData.LowCenterY;
                    if (Globals.HighCCD)//低倍走向高倍
                    {
                        Common.X_Axis.AxisJogIncWork(x);
                        Common.Y_Axis.AxisJogIncWork(y);
                    }
                    else//高倍走向低倍
                    {
                        Common.X_Axis.AxisJogIncWork(-x);
                        Common.Y_Axis.AxisJogIncWork(-y);
                    }
                    Common.ReportCmdKeyProgress(Globals.HighCCD?CmdKey.S0806: CmdKey.S0807);
                    if (ChangeCaptureViewModeHander != null)
                    {
                        ChangeCaptureViewModeHander(this, null);
                    }
                    return true;
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0014);
                    return false;
                }
            }
            else
            {
                if (ApplyBinning)
                {
                    CaptureProvider.BinningMode = !CaptureProvider.BinningMode;
                    Globals.HighCCD = !CaptureProvider.BinningMode;
                    Common.ReportCmdKeyProgress(Globals.HighCCD ? CmdKey.S0806 : CmdKey.S0807);
                    if (ChangeCaptureViewModeHander != null)
                    {
                        ChangeCaptureViewModeHander(this, null);
                    }
                    return true;
                }
                else
                {
                    Globals.HighCCD = true;
                    CaptureProvider.BinningMode = false;
                    Common.ReportCmdKeyProgress(CmdKey.S0809);
                    return false;
                }
            }
        }

        private void ShowRealTimePicture()
        {
            try
            {
                if (CaptureProvider != null && CaptureProvider.IsRunning)
                {
                    Bitmap src = CaptureProvider.GetCurrentFrame();
                    if (src != null)
                    {
                        lock (src)
                        {
                            using (Graphics gph1 = Graphics.FromImage(src))
                            {
                                if (UserPaint != null)
                                {
                                    UserPaint(src, new PaintEventArgs(gph1, imageCtr.ClientRectangle));
                                }
                                else
                                {
                                    DrawGuidesLines(gph1, src.Width, src.Height);
                                }
                            }
                            this.BeginInvoke((Action)delegate () { imageCtr.Image = src; });
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void DrawGuidesLines(Graphics g, int width, int height)
        {
            if (BT4.Pressed || BT5.Pressed || BT6.Pressed || BT7.Pressed)
            {
                if (btTick == 0 || btTick > 5)
                {
                    if (BT4.Pressed)
                    {
                        XGuidesWidth += 2;
                    }
                    else if (BT5.Pressed)
                    {
                        XGuidesWidth -= 2;
                    }
                    else if (BT6.Pressed)
                    {
                        YGuidesWidth += 2;
                    }
                    else
                    {
                        YGuidesWidth -= 2;
                    }
                    strShowTime = 0;
                }
                btTick++;
            }
            else
            {
                btTick = 0;
            }
            try
            {
                h = height / 2;
                w = width / 2;
                y1 = w - YGuidesWidth / 2;
                y2 = w + YGuidesWidth / 2;
                x1 = h - xGuidesWidth / 2;
                x2 = h + xGuidesWidth / 2;
                drawPen.DashStyle = DashStyle.Solid;
                g.DrawLine(drawPen, 0, h, width, h);
                drawPen.DashStyle = DashStyle.Dash;
                g.DrawLine(drawPen, w, 0, w, height);
                if (strShowTime < 200)
                {
                    strShowTime++;
                    drawPoint.Y = h;
                    widthString = string.Format("width: {0:f4} mm", GuidesLineWidth);
                    drawPoint.X = width - g.MeasureString(widthString, ft, width).Width;
                    g.DrawString(widthString, ft, drawBrush, drawPoint);
                }
                g.DrawLine(drawPen, 0, x1, width, x1);
                g.DrawLine(drawPen, y1, x1, y1, x2);
                g.DrawLine(drawPen, y2, x1, y2, x2);
                g.DrawLine(drawPen, 0, x2, width, x2);
            }
            catch
            { }
        }

        private void BT3_Click(object sender, EventArgs e)
        {
            if (CaptureProvider != null)
            {
                Bitmap src = CaptureProvider.GetCurrentFrame();
                //ImgLib.ImageU8 p = new ImageU8(src);
                //p.ApplyCannyEdgeDetector();
                if (src == null)
                    return;
                string path = String.Format("{0}\\Image", Application.StartupPath);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                // p.Save(String.Format("{0}\\{1}.bmp", path, DateTime.Now.ToString("yyyyMMddHHmmss")));
                src.Save(String.Format("{0}\\{1}.bmp", path, DateTime.Now.ToString("yyyyMMddHHmmss")), ImageFormat.Bmp);
            }
        }

        private void CaptureViewEx_Disposed(object sender, EventArgs e)
        {
            StopCapture();
        }

        private void ImageCtr_MouseDown(object sender, MouseEventArgs e)
        {
            if (VC1.Visible || Axis.Visible)
            {
                VC1.Visible = false;
                Axis.Visible = false;
                return;
            }
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (mouseFollow)
            {
                if (CaptureProvider != null && Common.HwProvider.CreateSucessful)
                {
                    float x = imageCtr.Width / 2 - e.X;
                    float y = e.Y - imageCtr.Height / 2;
                    Common.Y_Axis.JogInc(Globals.MacData.YFollowSpeed, Globals.MacData.YFollowAcc, y * CaptureProvider.Scale);
                    Common.X_Axis.JogInc(Globals.MacData.YFollowSpeed, Globals.MacData.YFollowAcc, x * CaptureProvider.Scale);
                }
            }
        }
    }
    public enum VideoMode : byte
    {
        Logo = 0,//显示Logo模式
        Virual = 1,//虚拟划切模式
        RealTime = 2,//实时采集模式
        RealFollow = 3,//实时采集坐标跟随
        Hold = 3,//保持模式，暂停实时显示
        None = 255,
    }
}
