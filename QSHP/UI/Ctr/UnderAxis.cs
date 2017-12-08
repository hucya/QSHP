using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.UI.Ctr;
using QSHP.HW.AmpC;
using System.Diagnostics;
using System.Threading;

namespace QSHP.UI.Ctr
{
    public partial class UnderAxis : UserControl
    {
        int waitTick = 0;
        int waitCount = 3;
        bool wait=false;
        IAmpCProvider provider ;
        int dir = 0;
        public UnderAxis()
        {
            InitializeComponent();
        }

        private void SetCommonAxisObject()
        {
            xPFBt.Tag = Common.X_Axis;
            xNFBt.Tag = Common.X_Axis;
            yPFBt.Tag = Common.Y_Axis;
            yNFBt.Tag = Common.Y_Axis;
            tPFBt.Tag = Common.T_Axis;
            tNFBt.Tag = Common.T_Axis;

            xPSBt.Tag = Common.X_Axis;
            xNSBt.Tag = Common.X_Axis;
            yPSBt.Tag = Common.Y_Axis;
            yNSBt.Tag = Common.Y_Axis;
            tPSBt.Tag = Common.T_Axis;
            tNSBt.Tag = Common.T_Axis;
            zPSBt.Tag = Common.Z_Axis;
            zNSBt.Tag = Common.Z_Axis;

            xPFBt.Flag = 1;
            xNFBt.Flag = -1;
            yPFBt.Flag = -1;
            yNFBt.Flag = 1;
            tPFBt.Flag = 1;
            tNFBt.Flag = -1;

            xPSBt.Flag = 1;
            xNSBt.Flag = -1;
            yPSBt.Flag = -1;
            yNSBt.Flag = 1;
            tPSBt.Flag = 1;
            tNSBt.Flag = -1;
            zPSBt.Flag = 1;
            zNSBt.Flag = -1;
        }

        private void AxisBt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (modeBt.Pressed)
            {
                return;
            }
            ButtonEx bt = sender as ButtonEx;
            if (bt != null)
            {
                provider = bt.Tag as IAmpCProvider;
                if (provider != null)
                {
                    provider.AxisJogDir(bt.Flag);
                }
            }
        }

        private void AxisBt_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ButtonEx bt = sender as ButtonEx;
            if (bt != null)
            {
                ProcessAxisBtClick(bt, !modeBt.Pressed);
            }
        }

        private void AxisSlowJogStop(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ButtonEx bt = sender as ButtonEx;
            if (bt != null && bt.Tag != null)
            {
                IAmpCProvider provider = bt.Tag as IAmpCProvider;
                if (provider != null)
                {
                    if (wait)
                    {
                        provider.JogInc(provider.Param.JogVelSlow, provider.Param.JogAccSlow, 0.001f * bt.Flag);
                        wait = false;
                    }
                    else
                    {
                        provider.JogStop();//停止移动
                    }
                }
            }
        }

        private void AxisSlowJogDone(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ButtonEx bt = sender as ButtonEx;
            if (bt != null)
            {
                provider = bt.Tag as IAmpCProvider;
                dir = bt.Flag;
                wait = true;
                waitTick = 0;
            }
        }

        private void ZAxisFastJogDone(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (Common.Z_Axis != null && Common.Z_Axis.Enabled)
            {
                Common.Z_Axis.AxisJogDir(1);
            }
        }

        private void ModeBt_Click(object sender, EventArgs e)
        {
            if (modeBt.Pressed)
            {
                modeBt.Text = "步进";
                yPFBt.Text = "O";
                yNFBt.Text = "P";
                xPFBt.Text = "R";
                xNFBt.Text = "Q";
                tPFBt.Text = "Z";
                tNFBt.Text = "Y";
                label2.Text = "步 进 控 制 区";
            }
            else
            {
                modeBt.Text = "连续";

                yPFBt.Text = "I";
                yNFBt.Text = "J";
                xPFBt.Text = "H";
                xNFBt.Text = "G";
                tPFBt.Text = "X";
                tNFBt.Text = "W";
                label2.Text = "高 速 控 制 区";
            }
        }

        private void UnderAxis_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                SetCommonAxisObject();
            }
        }

        private void ProcessAxisBtClick(ButtonEx bt, bool dirMode)
        {
            IAmpCProvider ampC = bt.Tag as IAmpCProvider;
            if (ampC != null)
            {
                if (dirMode)
                {
                    ampC.JogStop();
                }
                else
                {
                    if (ampC.IsInPosition)
                    {
                        Common.AxisJogStep(ampC, bt.Flag);
                    }
                }
            }
        }

        private void P1PosBt_Click(object sender, EventArgs e)
        {
            if (Globals.Load)
            {
                PointF p = Globals.MacData.P1Pos;
                Common.X_Axis.AxisJogAbsWork(p.X);
                Common.Y_Axis.AxisJogAbsWork(p.X);
            }
        }

        private void P2PosBt_Click(object sender, EventArgs e)
        {
            if (Globals.Load)
            {
                PointF p = Globals.MacData.P2Pos;
                Common.X_Axis.AxisJogAbsWork(p.X);
                Common.Y_Axis.AxisJogAbsWork(p.X);
            }
        }

        public void AutoUpdata()
        {
            if (wait)
            {
                if (waitTick++ > waitCount)
                {
                    if (provider != null)
                    {
                        provider.AxisJogDirSlow(dir);
                        wait = false;
                    }
                }
            }
        }
    }
}
