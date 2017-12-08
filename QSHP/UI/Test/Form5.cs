using QSHP.SIM;
using QSHP.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QSHP
{
    public partial class Form5 : BaseForm
    {
        Stopwatch wacth = new Stopwatch();
        MotorModel motor = new MotorModel();
        public Form5()
        {
            InitializeComponent();
            motor.ProgressChanged += motor_ProgressChanged;
        }

        void motor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                spdPlot.Titles[0].Text = "距离：" + motor.Position.ToString("F4") + " 速度： " + motor.Speed.ToString("f3");
                spdPlot.Titles[1].Text = "总计用时：" + wacth.Elapsed.ToString();
                spdPlot.Series[0].Points.AddY(motor.Position);
            }
            catch
            {
 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wacth.Restart();
            motor.SetSpeed((float)SetSpeed.Value);
            motor.JogAbs ((float)SetPos.Value);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            motor.InitAmpC();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            motor.JogStop();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            wacth.Restart();
            motor.SetSpeed((float)SetSpeed.Value);
            motor.JogStop();
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            wacth.Restart();
            motor.SetSpeed((float)SetSpeed.Value);
            motor.JogDir(1);
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            wacth.Restart();
            motor.SetSpeed((float)SetSpeed.Value);
            motor.JogDir(-1);
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            motor.JogDir(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            wacth.Restart();
            motor.SetSpeed((float)SetSpeed.Value);
            motor.JogInc((float)incPos.Value);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            wacth.Restart();
            motor.SetSpeed((float)SetSpeed.Value);
            motor.JogInc((float)-incPos.Value);
        }

        private void spdPlot_Click(object sender, EventArgs e)
        {

        }

        private void Form5_BT0Click(object sender, EventArgs e)
        {
            MessageBox.Show("软件开发");
        }
    }
}
