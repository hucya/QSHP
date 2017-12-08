using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using QSHP.HW;
using QSHP.UI;

namespace QSHP
{
    public partial class Form1 : BaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                Globals.AppFunState = SysFunState.SysInit;
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            captureViewEx1.StartCapture();
            captureViewEx1.ShowMode = QSHP.UI.VideoMode.RealFollow;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public override bool FormLoadReady()
        {
            captureViewEx1.StartCapture();
            captureViewEx1.ShowMode = QSHP.UI.VideoMode.RealFollow;
            return base.FormLoadReady();
        }
        public override bool FormUnloadReady()
        {
            captureViewEx1.StopCapture();
            return base.FormUnloadReady();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            captureViewEx1.StopCapture();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Common.HwProvider.UnInitHardwareDriver();
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                Globals.AppFunState = SysFunState.TouchTesting;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Common.HwProvider.SaveSystemObjectConfig(Application.StartupPath + @"\789.xml");
        }
        PointF[] p = new PointF[3];
        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Common.Z_Axis.AxisJogAbsWork(Common.HeightValue + 0.5f,true);
            //Common.Z_Axis.AxisJogAbsWork(Common.HeightValue);
            //if (centerFlag == 0)
            //{
            //    p[0] = Common.AxisPoint;
            //    centerFlag = 1;
            //    button7.Text = "T调整取第二点";
            //}
            //else if (centerFlag == 1)
            //{
            //    p[1] = Common.AxisPoint;
            //    //p[2] = Com.RotateMath.RotateCenterPoint(p[0], p[1], 2f);
            //    float a= (float)Com.RotateMath.GetPointsAngle(p[0], p[1]);
            //    Common.T_Axis.AxisJogIncWork(a);
            //    centerFlag = 0;
            //    button7.Text = "T调整取第一点";
            //}
        }

        private void button8_Click(object sender, EventArgs e)
        {
         
        }
    }
}
