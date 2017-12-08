using QSHP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using QSHP.Com;
using System.Windows.Threading;
namespace QSHP.UI.Manual
{
    public partial class CutStatusManager : BaseForm
    {
        float xOffset = 0;      //x偏移
        float yOffset = 0;      //y偏移
        float scale = 1;        //图像显示比例
        float penScale = 1;     //画笔倍率
        float preWidth = 10;    //预留尺寸
        float imgAngle = 0;     //图像旋转角度累加
        int imgWidth = 491;     //总图片尺寸 491*491
        bool circTable = true;  //圆盘
        string userFormat = "{0}/{1} ";
        string sysFormat = " {0}%";

        PointF startPoint = new PointF(150, 150);   //划线起点
        SizeF tabSize = new SizeF(152.4f, 152.4f);  //工作盘尺寸
        PointF tabCenter = Globals.TabCenter;       //工作盘中心坐标

        Bitmap img;                                 //显示图片
        Brush tabEdgesColor = Brushes.DodgerBlue;   //工作盘边缘线
        Brush tabColor = Brushes.LightBlue;         //工作盘背景色
        Brush wkEdgesColor = Brushes.Orchid;        //工件边缘线
        Brush wkColor = Brushes.Honeydew;           //工件背景色
        Pen linePen = new Pen(Brushes.Blue, 1);     //线条颜色
        Pen lineCutPen = new Pen(Brushes.OrangeRed, 1); //划切过程线条颜色

        Graphics g; //图片GDI+
        Stopwatch watch = new Stopwatch();  //计时控件
        DispatcherTimer timer = new DispatcherTimer();  //动态绘制划切线控件

        CutGroup group;
        CutSegment seg;

        public CutGroup Group
        {
            get 
            { 
                return group; 
            }
            set 
            {
                group = value;
                imgAngle = group.CH1.AlignT; //起始对准位置
            }
        }

        public CutStatusManager(CutGroup gr)
        {
            InitializeComponent();
            Group = gr;
        }

        private void CuttingManager_Load(object sender, EventArgs e)
        {
            if (Globals.TabData != null)
            {
                tabSize = Globals.TabData.UsedTabSize;
            }
            float len = Math.Max(tabSize.Width, tabSize.Height) + preWidth;
            img = new Bitmap(imgWidth, imgWidth);
            Common.ProgressWorkingChanged += BackWorker_ProgressChanged;
            g = Graphics.FromImage(img);
            scale = imgWidth / len;
            penScale = 1 / scale;
            linePen.Width = penScale;
            lineCutPen.Width = penScale;
            xOffset = len / 2 - tabCenter.X;
            yOffset = len / 2 - tabCenter.Y;
            SetGraphicsMode(g,true);//打开降噪
            DrawTabCtrolImage(g, tabSize);//圆盘尺寸);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;//绘制直线时候取消降噪
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += TimerUpdataTick;
            cutMode.Text = Group.CutMode.ToString();
            int chs = Group.ChipCHs.Where(c => c.Enable == true).Count();
            preTime.Text = TimeSpan.FromSeconds(Group.PreTime + Globals.DevData.CuttingTime+chs*10).ToString(@"hh\:mm\:ss");
            LoadChannelData(Group.ChipCHs[0]);
            Common.SetSystemWorkMode(SysFunState.Cutting);
            watch.Restart();
        }

        private void LoadChannelData(CutSegment seg,bool isChannel=false)
        {
            ClearAdjData();
            if (!isChannel)
            {
                segName.Text = seg.Name;
            }
            else
            {
                segName.Text = "None";
            }
            this.seg = seg;
            cutProcess.StringFormat = string.Format(userFormat,0, seg.Lines.Count)+ sysFormat;
            cutProcess.Value = 0;
            cutLeaveLines.Text = seg.WaitCutNum.ToString();
            cutSpeed.Text = seg.Speed.ToString();
            cutDeapth.Text = seg.Dual ? seg.ReDepth2.ToString() : seg.ReDepth.ToString();
            cutStep.Text = seg.IndexStep.ToString();
        }

        void TimerUpdataTick(object sender, EventArgs e)
        {
            lock (g)
            {
                DrawLine(g, startPoint, startPoint.X - Common.X_Axis.RealPos);
            }
        }

        private void SetGraphicsMode(Graphics g,bool smooth=false)
        {
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            if (smooth)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            }
            else
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            }
            g.ScaleTransform(scale, scale);
            g.TranslateTransform(xOffset, yOffset);
        }

        private void RotateImageAngle(float angle)
        {
            float alg = angle - imgAngle;
            if (alg % 360 != 0)
            {
                imgAngle= angle;
                img = BitmapHelper.RotateImg(img, alg); //在中心进行旋转
                g.Dispose();
                g = Graphics.FromImage(img);
                SetGraphicsMode(g);
            }
            imgAngle = angle;
            imgCtr.Image = img;
        }
        
        private void ProcessCutLineStep(CutLine line)
        {
            switch (line.CutStep)
            {
                case CutStep.ST1://更新划切等相关信息
                    {
                        cutSpeed.Text = line.Speed.ToString();//当前配置的划切速度
                        cutLeaveLines.Text = line.Seg.WaitCutNum.ToString();//当前剩余划切刀数
                        if (line.Seg != null)
                        {
                            cutProcess.StringFormat = string.Format(userFormat, line.Index, line.Seg.Lines.Count) + sysFormat;
                            cutProcess.Value = (int)(line.Seg.CuttingIndex * 100 / line.Seg.Lines.Count);//划切进度条
                        }
                    }break;
                case CutStep.ST3:
                    {
                        if (!watch.IsRunning)
                        {
                            watch.Start();//开始计时
                        }
                        lineCutPen.DashStyle = DashStyle.Dash;  //虚线划切
                        startPoint = Globals.AxisPoint;         //获取当前位置绝对位置
                        timer.Start();     //开始进行模拟划切
                    }
                    break;
                case CutStep.ST7:
                    {
                        lineCutPen.DashStyle = DashStyle.Solid;
                        startPoint = Globals.AxisPoint;     //获取当前位置绝对位置
                    }
                    break;
                case CutStep.ST8:
                case CutStep.CutStop:
                    {
                        if (timer.IsEnabled)
                        {
                            timer.Stop(); 
                        }
                    }break;
                case CutStep.Pause:
                case CutStep.STEnd:
                    {
                        if (timer.IsEnabled)
                        {
                            timer.Stop();
                        } 
                        if (line.SinDir)
                        {
                            DrawLine(g, startPoint, line.Dir ? line.Length : -line.Length, false);
                        }
                        else
                        {
                            if (line.Dual)
                            {
                                DrawLine(g, startPoint, line.Dir ? -line.Length : line.Length, false);
                            }
                            else
                            {
                                DrawLine(g, startPoint, line.Dir ? line.Length : -line.Length, false);
                            }
                        }
                    }
                    break;//划切停止
                default:
                    break;
            }
        }

        private void DrawTabCtrolImage(Graphics g,SizeF tabSize)
        {
            lock (g)
            {
                Pen pen = new Pen(tabEdgesColor, 3*penScale);
                lineCutPen.DashStyle = DashStyle.Dash;
                float x1 = tabCenter.X - tabSize.Width / 2;
                float y1 = tabCenter.Y - tabSize.Height / 2;
                float w1 = tabSize.Width;
                float h1 = tabSize.Height;
                if (circTable)
                {
                    g.FillEllipse(tabColor, x1, y1, w1, h1);
                    g.DrawEllipse(pen, x1, y1, w1, h1);
                }
                else
                {
                    g.FillRectangle(tabColor, x1, y1, w1, h1);
                    g.DrawRectangle(pen, x1, y1, w1, h1);
                }
                DrawWorkerGroupImage(g,Globals.Group);
                imgCtr.Image = img;
            }
        }

        private void DrawWorkerGroupImage(Graphics g,CutGroup gr)
        {
            if (!gr.Multiple)
            {
                DrawWorkerImage(g, gr.Center, new SizeF(gr.Length, gr.Width),gr.Fixed);
            }
            else
            {
                foreach (var item in gr.ChipS)
                {
                    DrawWorkerImage(g, item.Center, new SizeF(item.Length, item.Width), item.Fixed);
                }
            }
        }

        private void DrawWorkerImage(Graphics g, PointF cp, SizeF s, bool fix,bool center = true)
        {
            lock (g)
            {
                float w = s.Width;
                float h = s.Height;
                Pen pen = new Pen(wkEdgesColor, 2*penScale);
                if (fix)//绘制圆形工件 
                {
                    PointF p = center ? new PointF(cp.X - s.Width / 2, cp.Y - s.Height / 2) : cp;
                    g.FillRectangle(wkColor, p.X, p.Y, w, h);
                    g.DrawRectangle(pen, p.X, p.Y, w, h);
                }
                else//绘制方形工件
                {
                    PointF p =center ? new PointF(cp.X - s.Width / 2, cp.Y - s.Height / 2) : cp;
                    g.FillEllipse(wkColor, p.X, p.Y, w, h);
                    g.DrawEllipse(pen, p.X, p.Y, w, h);
                }
            }
        }

        private void DrawLine(Graphics g, PointF p, float length, bool cutting = true)
        {
            lock (g)
            {
                float p1=2 * tabCenter.X - p.X;
                g.DrawLine(cutting ? lineCutPen : linePen, p1, p.Y, p1+ length, p.Y);
                imgCtr.Image = img;
            }
        }

        private void CuttingManager_ConfirmClick(object sender, EventArgs e)
        {
            if (Globals.Line != null)
            {
                Globals.Line.Pause = true;      //设置当前刀数暂停
            }
        }

        private void CutStatusManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Common.ProgressWorkingChanged -= BackWorker_ProgressChanged;
            timer.Stop();
            watch.Stop();
            img.Dispose();
            g.Dispose();
        }

        private void CutStatusManager_CancelClick(object sender, EventArgs e)
        {
            if (Globals.Line != null)
            {
                Globals.Line.Pause = true;      //设置当前刀数暂停
            }
            //timer.Stop();
            //Globals.CutStop = true;//立即停止
        }

        private void BackWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case ProcessCmd.CutLineCmd:
                    {
                        ProcessCutLineStep(e.UserState as CutLine);
                    }
                    break;
                case ProcessCmd.CutSegStartCmd://划切当前步距值
                    {
                        CutSegment seg = e.UserState as CutSegment;
                        if (seg != null)
                        {
                            LoadChannelData(seg);
                            
                        }
                    }
                    break;
                case ProcessCmd.CutSegEndCmd://当前步距划切结束
                    {
                        CutSegment seg = e.UserState as CutSegment;
                        if (seg != null)
                        {
                            cutLeaveLines.Text = seg.WaitCutNum.ToString();//剩余刀数更新
                            cutProcess.StringFormat = string.Format(userFormat, seg.Lines.Count, seg.Lines.Count) + sysFormat;
                            cutProcess.Value = 100;
                        }
                    }
                    break;
                case ProcessCmd.CutChStartCmd://划切当前通道
                    {
                        CutChannel ch = e.UserState as CutChannel;
                        if (ch != null)
                        {
                            RotateImageAngle(ch.AlignT + ch.TPosAdj);
                            if (ch.Chip != null)
                            {
                                chipName.Text = ch.Chip.Name;
                            }
                            else
                            {
                                chipName.Text = "Chip1";
                            }
                            curName.Text = ch.Name;
                            LoadChannelData(ch,true);
                        }
                    }
                    break;
                case ProcessCmd.CutChEndCmd://当前通道划切结束
                    {
                        CutChannel ch = e.UserState as CutChannel;
                        if (ch != null)
                        {
                            cutLeaveLines.Text = ch.WaitCutNum.ToString();//剩余刀数更新
                            cutProcess.StringFormat = string.Format(userFormat, ch.Lines.Count, ch.Lines.Count) + sysFormat;
                            cutProcess.Value = 100;//划切进度更新
                        }
                    }
                    break;
                case ProcessCmd.CutPieceCmd://暂时保留
                    {
                        //
                    }
                    break;
                case ProcessCmd.CutGroupCmd://开始进行划切
                    {

                    }
                    break;
                case ProcessCmd.CutPauseCmd:
                    {
                        watch.Stop();
                        if (ParentForm != null)
                        {
                            ParentForm.PushChildForm(new CutPauseManager());//进入暂停界面
                        }
                    } break;
                case ProcessCmd.CutSopCmd:
                    {
                        if (ParentForm != null)
                        {
                            ParentForm.PopChildForm(this);
                        }
                    } break;
                default:
                    break;
            }
        }

        private void ClearAdjData()
        {
            cutStepAdj.Value = 0;
            cutLineAdj.Value = 0;
            cutSpeedAdj.Value = 0;
            cutDeapthAdj.Value = 0;
        }

        private void CutStatusManager_AutoUpdateEventHander(object sender, EventArgs e)
        {
            realTime.Text = watch.Elapsed.ToString(@"hh\:mm\:ss");
            this.UnderBar.BtList[5].LED = Globals.PreCut;
        }

        public override bool FormLoadReady()
        {
            this.UnderBar.BtList[5].UsedLed = true;
            return base.FormLoadReady();
        }

        public override bool FormUnloadReady()
        {
            this.UnderBar.BtList[5].UsedLed = false;
            return base.FormUnloadReady();
        }

        private void ChangeCutLinesEventHander(object sender, EventArgs e)
        {
            if (seg != null && !seg.Complate)
            {
                Common.RepairCutChannelValue(seg, 1, cutLineAdj.Value);
                cutProcess.StringFormat = string.Format("{0}/{1}", seg.CuttingIndex, seg.Lines.Count) + "{0}%";
                cutProcess.Value = (int)(seg.CuttingIndex / seg.Lines.Count);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
            cutLineAdj.Value = 0;
        }

        private void ChangeCutSpeedEventHander(object sender, EventArgs e)
        {
            if (seg != null && !seg.Complate)
            {
                Common.RepairCutChannelValue(seg, 0, cutSpeedAdj.Value);
                cutSpeed.Text = seg.Speed.ToString();
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
            cutSpeedAdj.Value = 0;
        }

        private void ChangeCutDeapthEventHnader(object sender, EventArgs e)
        {
            if (seg != null && !seg.Complate)
            {
                Common.RepairCutChannelValue(seg, 2, cutDeapthAdj.Value);
                cutDeapth.Text = seg.Dual ? seg.ReDepth2.ToString() : seg.ReDepth.ToString();
                cutDeapthAdj.Value = 0;
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
        }

        private void ChangeCutIndexStepEventHander(object sender, EventArgs e)
        {
            if (seg != null && !seg.Complate)
            {
                Common.RepairCutChannelValue(seg, 3, cutStepAdj.Value);
                cutStep.Text = seg.IndexStep.ToString();
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
            cutStepAdj.Value = 0;
        }

        private void ChangePreCutSpeedEventHander(object sender, EventArgs e)
        {
            if (Globals.Cutting)
            {
                Globals.PreCut = !Globals.PreCut;
                if (Globals.PreCut)
                {
                    Common.ReportCmdKeyProgress(CmdKey.P0126);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.P0127);
                }
            }
        }
    }
}
