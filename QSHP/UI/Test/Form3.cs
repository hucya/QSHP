using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using QSHP.Com;
using QSHP.UI;
using QSHP.Data;
using System.Drawing.Imaging;

namespace QSHP
{
    public partial class Form3 : BaseForm
    {
        public Form3()
        {
            InitializeComponent();
        }
        CutSegment seg = new CutSegment();
        PointF[] p = new PointF[3];
        Bitmap bmp;
        Pen drawPen = new Pen(Color.Blue, 1);
        Pen drawPen1 = new Pen(Color.Red, 1);
        SolidBrush drawBrush = new SolidBrush(Color.Red);
        double angle = 0;

        private void Form3_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            angle = Math.Atan((p[0].Y - p[2].Y) / (p[0].X - p[2].X));
            angle *= -180;
            angle /= Math.PI;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawString("当前AC角度为：" + angle.ToString(), this.Font, drawBrush, new PointF(10, 10));
            }
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random a = new Random();
            for (int i = 0; i < 3; i++)
            {
                p[i].X = a.Next(pictureBox1.Width);
                p[i].Y = a.Next(pictureBox1.Height);
            }
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(pictureBox1.BackColor);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                drawPen.Color = Color.Blue;
                drawPen.DashStyle = DashStyle.Solid;
                g.DrawPolygon(drawPen, p);
                drawPen.DashStyle = DashStyle.Dash;
                drawPen1.DashStyle = DashStyle.Dash;
                drawPen.Color = Color.Green;

                g.DrawLine(drawPen, new Point(0, (int)p[1].Y), new Point(pictureBox1.Width, (int)p[1].Y));
                g.DrawLine(drawPen, new Point((int)p[1].X, 0), new Point((int)p[1].X, pictureBox1.Height));

                g.DrawString("A", this.Font, drawBrush, p[0]);
                g.DrawString("B", this.Font, drawBrush, p[1]);
                g.DrawString("C", this.Font, drawBrush, p[2]);
                angle = Math.Atan((p[0].Y - p[2].Y) / (p[0].X - p[2].X));
                p[0] = RotateMath.PointRotate(p[1], p[0], angle);
                p[2] = RotateMath.PointRotate(p[1], p[2], angle);
                PointF p1 = new PointF((p[0].X + p[2].X) / 2, (p[0].Y + p[2].Y) / 2);
                g.DrawString("M'", this.Font, drawBrush, p1);
                g.DrawString("A'", this.Font, drawBrush, p[0]);
                g.DrawString("C'", this.Font, drawBrush, p[2]);
                angle *= -180;
                angle /= Math.PI;
                g.DrawString("当前应旋转角度为：" + angle.ToString(), this.Font, drawBrush, new PointF(10, 10));
                g.DrawString("X轴移动距离为：" + (p1.X - p[1].X).ToString(), this.Font, drawBrush, new PointF(10, 30));
                g.DrawString("Y轴移动距离为：" + (p1.Y - p[1].Y).ToString(), this.Font, drawBrush, new PointF(10, 50));
                drawPen.Color = Color.Cyan;
                drawPen.DashStyle = DashStyle.Dash;

                g.DrawPolygon(drawPen, p);
                g.DrawLine(drawPen, p[1], p1);
            }
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random a = new Random();
            for (int i = 0; i < 3; i++)
            {
                p[i].X = a.Next(pictureBox1.Width);
                p[i].Y = a.Next(pictureBox1.Height);
            }
            double angle = a.Next(360);
            angle = 180 - angle;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(pictureBox1.BackColor);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                drawPen.Color = Color.Blue;
                drawPen.DashStyle = DashStyle.Dash;
                drawPen1.DashStyle = DashStyle.Dash;
                g.DrawString("旋转角度为：" + (-angle).ToString(), this.Font, drawBrush, new PointF(10, 10));
                angle /= 180;
                angle *= Math.PI;
                double r = RotateMath.GetRotateR(p[0], p[2], angle);
                p[1] = RotateMath.RotateCenterPoint(p[0], p[2], angle);
                g.DrawPolygon(drawPen, p);
                g.DrawString("A坐标为：" + p[0].ToString(), this.Font, drawBrush, new PointF(10, 30));
                g.DrawString("C坐标为：" + p[2].ToString(), this.Font, drawBrush, new PointF(10, 50));
                drawPen.Color = Color.Green;

                g.DrawLine(drawPen, new Point(0, (int)p[0].Y), new Point(pictureBox1.Width, (int)p[0].Y));
                g.DrawLine(drawPen, new Point((int)p[0].X, 0), new Point((int)p[0].X, pictureBox1.Height));
                drawPen.Color = Color.DarkViolet;
                g.DrawPie(drawPen, new RectangleF((float)(p[1].X - r), (float)(p[1].Y - r), (float)(2 * r), (float)(2 * r)), 0, 360);
                g.DrawString("A", this.Font, drawBrush, p[0]);
                g.DrawString("O", this.Font, drawBrush, p[1]);
                g.DrawString("C", this.Font, drawBrush, p[2]);
            }
            pictureBox1.Image = bmp;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Random a = new Random();
            for (int i = 0; i < 3; i++)
            {
                p[i].X = a.Next(pictureBox1.Width);
                p[i].Y = a.Next(pictureBox1.Height);
            }
            double angle = a.Next(360);
            angle = 180 - angle;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(pictureBox1.BackColor);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                drawPen.Color = Color.Blue;
                drawPen.DashStyle = DashStyle.Dash;
                drawPen1.DashStyle = DashStyle.Dash;
                float r = 0;
                g.DrawPolygon(drawPen, p);
                drawPen.Color = Color.Green;
                g.DrawLine(drawPen, new Point(0, (int)p[0].Y), new Point(pictureBox1.Width, (int)p[0].Y));
                g.DrawLine(drawPen, new Point((int)p[0].X, 0), new Point((int)p[0].X, pictureBox1.Height));
                drawPen.Color = Color.DarkViolet;
                PointF center = RotateMath.RotateCenterPoint(p[0], p[1], p[2], out r);
                g.DrawPie(drawPen, new RectangleF((float)(center.X - r), (float)(center.Y - r), (float)(2 * r), (float)(2 * r)), 0, 360);
                g.DrawString("A", this.Font, drawBrush, p[0]);
                g.DrawString("B", this.Font, drawBrush, p[1]);
                g.DrawString("C", this.Font, drawBrush, p[2]);
                g.DrawString("O", this.Font, drawBrush, center);
            }
            pictureBox1.Image = bmp;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }
        int i = 0;
        private void button3_Click_1(object sender, EventArgs e)
        {
            bmp = new Bitmap(481, 481);
            seg = new CutSegment();
            timer1.Stop();
            seg.Length = 480;
            seg.Dir = true;
            seg.SinDir = false;
            seg.Speed = 50;
            seg.BackSpeed = 200;
            seg.Fixed = false;
            seg.Forward = true;
            seg.Abs = true;
            seg.IndexStep = 4.8f;
            seg.Center = new PointF(240, 240);

            if (seg.Forward)
            {
                seg.StartPos = new PointF(0, 0);
            }
            else
            {
                seg.StartPos = new PointF(0, 480);

            }
            seg.TotalLine = 100;
            seg.InitCutRunData();
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(pictureBox1.BackColor);
                g.DrawEllipse(drawPen,new Rectangle(0,0,480,480));
            }
            pictureBox1.Image = bmp;
            i = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                seg[i].StartPos.Y = seg.StartPos.Y +i * seg[i].StartPos.Y;
                if (seg[i].Dir)
                {
                    g.DrawLine(drawPen, seg[i].StartPos, new PointF(seg[i].StartPos.X - seg[i].Length, seg[i].StartPos.Y));
                }
                else
                {
                    g.DrawLine(drawPen1, new PointF(seg[i].StartPos.X + seg[i].Length, seg[i].StartPos.Y), seg[i].StartPos);
                }
            }
            pictureBox1.Image = bmp;
            i++;
            if (i >= seg.TotalLine)
            {
                timer1.Stop();
                GC.Collect();
            }
           
        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    timer1.Stop();
        //    seg.PreWidth = 0;
        //    seg.Length = 480;
        //    seg.Dual = false;
        //    seg.Dir = true;
        //    seg.SinDir = false;
        //    seg.Speed = 50;
        //    seg.BackSpeed = 200;
        //    seg.Fixed = false;
        //    seg.Forward = false;
        //    seg.Abs = true;
        //    seg.IndexStep = 4.8f;
        //    seg.Center = new PointF(240, 240);
        //    if (seg.Forward)
        //    {
        //        seg.StartPos = new PointF(0, 0);
        //    }
        //    else
        //    {
        //        seg.StartPos = new PointF(0, 480);

        //    }
        //    seg.TotalLine = 100;
        //    seg.InitCutRunData();
        //    bmp = BitmapHelper.RotateImg(bmp, 30);

        //    pictureBox1.Image = bmp;
        //    i = 0;
        //    timer1.Start();
        //}
        private void button5_Click(object sender, EventArgs e)
        {
            CutChannel seg1 = new CutChannel();
            bmp = new Bitmap(481, 481);
            seg1.AlignPoint = new PointF(240, 240);
            seg1.Style = CutStyle.FrontToBack;
            seg1.Width = 480;
            seg1.YPosAdj = 20;
            timer1.Stop();
            seg = seg1;
            seg.Length = 200;
            seg.SinDir = false;
            seg.Dir = false;
            seg.Speed = 50;
            seg.BackSpeed = 200;
            seg.Fixed = false;
            seg.Forward = false;
            seg.Abs = true;
            seg.IndexStep = 4.8f;
            seg.Center = new PointF(240, 240);

            seg.TotalLine = 101;
            seg.InitCutRunData();
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(pictureBox1.BackColor);
                g.DrawEllipse(drawPen, new Rectangle(0, 0, 480, 480));
            }
            pictureBox1.Image = bmp;
            i = 0;
            timer1.Start();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
