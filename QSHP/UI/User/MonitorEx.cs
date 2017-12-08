using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;
using QSHP.HW;
using QSHP.UI.Ctr;
using QSHP.Com;
namespace QSHP.UI
{
    public partial class MonitorEx : UserControl
    {
        string format = "F3";
        float dxValue = 0f;
        float dyValue = 0f;
        float xValue = 0f;
        float yValue = 0f;
        //float zValue = 0f;
        //float tValue = 0f;
        float current = 0;
        int cycTick = 0;
        MonitorStyle style = MonitorStyle.Default;

        public MonitorStyle Style
        {
            get 
            { 
                return style; 
            }
            set 
            {
                if (value != style&&this.Visible)
                {
                    tabControl1.SelectedIndex = (int)value; 
                    style = value; 
                }
            }
        }
        Queue<float> dataPoints = new Queue<float>();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public MonitorEx()
        {
            InitializeComponent();
            dataPoints.Enqueue(0);
            this.DoubleBuffered = true;
            spdPlot.Series[0].Points.DataBindY(dataPoints);
        }

        public void AutoUpdate(int cyctime = 2)
        {
            if (cycTick-- < 0)
            {
                cycTick = cyctime;
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        {
                            UpDataIOStatus();
                        }
                        break;
                    case 1:
                        {
                            UpDataSpindleStatus();
                        }
                        break;
                    case 2:
                        {
                            UpDataAxisPos();
                        }
                        break;
                    case 3:
                        {
                            UpdataAxisLimit();
                        }
                        break;
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            GC.Collect();
            style = (MonitorStyle)tabControl1.SelectedIndex;
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    {
                        dataPoints.Clear();
                    }break;
            }

        }

        private void ClearPosition_Click(object sender, EventArgs e)
        {
            if (Common.X_Axis != null&&Common.X_Axis.Connected)
            {
                dxValue = Common.X_Axis.RealPos;
            }
            if (Common.Y_Axis != null && Common.Y_Axis.Connected)
            {
                dyValue = Common.Y_Axis.RealPos;
            }
        }

        private void UpdataAxisLimit()
        {
            if (Common.X_Axis != null && Common.X_Axis.Connected)
            {
                xPlimit.Text = Common.X_Axis.OnPLimit ? "正限位" : "---";
                xNlimit.Text = Common.X_Axis.OnNLimit ? "负限位" : "---";
                if (Common.X_Axis.AmpCFault)
                {
                    xErr.Status = LedStatus.Error;
                }
                else
                {
                    xErr.Status = Common.X_Axis.IsInPosition ? LedStatus.OK : LedStatus.Warn;
                }
            }
            else
            {
                xErr.Status = LedStatus.None;
            }
            if (Common.Y_Axis != null && Common.Y_Axis.Connected)
            {
                yPlimit.Text = Common.Y_Axis.OnPLimit ? "正限位" : "---";
                yNlimit.Text = Common.Y_Axis.OnNLimit ? "负限位" : "---";
                if (Common.Y_Axis.AmpCFault)
                {
                    yErr.Status = LedStatus.Error;
                }
                else
                {
                    yErr.Status = Common.Y_Axis.IsInPosition ? LedStatus.OK : LedStatus.Warn;
                }
            }
            else
            {
                yErr.Status = LedStatus.None;
            }
            if (Common.Z_Axis != null && Common.Z_Axis.Connected)
            {
                zPlimit.Text = Common.Z_Axis.OnPLimit ? "正限位" : "---";
                zNlimit.Text = Common.Z_Axis.OnNLimit ? "负限位" : "---";
                if (Common.Z_Axis.AmpCFault)
                {
                    zErr.Status = LedStatus.Error;
                }
                else
                {
                    zErr.Status = Common.Z_Axis.IsInPosition ? LedStatus.OK : LedStatus.Warn;
                }
            }
            else
            {
                zErr.Status = LedStatus.None;
            }
            if (Common.T_Axis != null && Common.T_Axis.Connected)
            {
                tPlimit.Text = Common.T_Axis.OnPLimit ? "正限位" : "---";
                tNlimit.Text = Common.T_Axis.OnNLimit ? "负限位" : "---";
                if (Common.T_Axis.AmpCFault)
                {
                    tErr.Status = LedStatus.Error;
                }
                else
                {
                    tErr.Status = Common.T_Axis.IsInPosition ? LedStatus.OK : LedStatus.Warn;
                }
            }
            else
            {
                tErr.Status = LedStatus.None;
            }
        }

        private void UpDataAxisPos()
        {
            if (Common.X_Axis != null && Common.X_Axis.Connected)
            {
                xValue=Common.X_Axis.Position;
                xPos.Text = xValue.ToString(format);
                xSpeed.Text = Common.X_Axis.Speed.ToString(format);
                dx.Text = (xValue - dxValue).ToString(format);
            }
            if (Common.Y_Axis != null && Common.Y_Axis.Connected)
            {
                yValue=Common.Y_Axis.Position;
                yPos.Text = yValue.ToString(format);
                dy.Text = (yValue - dyValue).ToString(format);
            }
            if (Common.Z_Axis != null && Common.Z_Axis.Connected)
            {
                zPos.Text = Common.Z_Axis.Position.ToString(format);
            }
            if (Common.T_Axis != null && Common.T_Axis.Connected)
            {
                tPos.Text = Common.T_Axis.Position.ToString(format);
            }
        }

        private void UpDataIOStatus()
        {
            if (Common.DI != null&& Common.DI.Enabled)
            {
                uint input = Common.DI.Status;
                cutWater.Text= input.Bit(Common.DI.IOList[DiDefine.CUT_WATER]) ?"1":"0";
                mainAIR.Text = input.Bit(Common.DI.IOList[DiDefine.MAIN_AIR]) ? "1" : "0";
                mainWater.Text = input.Bit(Common.DI.IOList[DiDefine.MAIN_WATER]) ? "1" : "0";
                workAir.Text = input.Bit(Common.DI.IOList[DiDefine.WORK_AIR]) ? "1" : "0";
                tabAir.Text = input.Bit(Common.DI.IOList[DiDefine.TAB_AIR])? "1" : "0";
            }
        }

        private void UpDataSpindleStatus()
        {
            if (Common.SPD == null)
            {
                return;
            }
            spdSpeed.Text = Common.SPD.GetSpdSpeed().ToString();
            spdStatus.Text = Common.SPD.GetSpdStatusString();
            if (Common.SPD.IsInit)
            {
                if (dataPoints.Count > 40)
                {
                    dataPoints.Dequeue();
                }
                current = Common.SPD.GetSpdCurrent();
                dataPoints.Enqueue(current);
                spdPlot.Titles[0].Text = string.Format("I= {0:f2} A", current);
                spdPlot.Series[0].Points.DataBindY(dataPoints);
                float max = dataPoints.Max();
                if (max > 2)
                {
                    spdPlot.ChartAreas[0].AxisY.Maximum = Math.Ceiling(max);
                }
                else
                {
                    spdPlot.ChartAreas[0].AxisY.Maximum = 2;
                }
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                if (Common.SPD != null && Common.SPD.IsInit)
                {
                    dataPoints.Clear();
                }
            }
        }
    }

    public enum MonitorStyle
    {
        Default = 0,
        IO = 0,
        SPD = 1,
        Axis = 2,
        AmpC = 3
    }
}
