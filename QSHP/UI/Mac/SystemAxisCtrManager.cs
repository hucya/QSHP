using QSHP.HW.AmpC;
using QSHP.UI.Ctr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI
{
    public partial class SystemAxisCtrManger : BaseForm
    {
        bool xStepMode = false;
        bool yStepMode = false;
        bool zStepMode = false;
        bool tStepMode = false;
        public SystemAxisCtrManger()
        {
            InitializeComponent();
        }

        private void AxisButton_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonEx bt = sender as ButtonEx;
            IAmpCProvider ampc = bt.Tag as IAmpCProvider;
            if (ampc == Common.X_Axis)
            {
                if (!xStepMode)
                {
                    ampc.JogStop();
                }
                else
                {
                    if (ampc.IsInPosition)
                    {
                        ampc.JogInc(xSpeed.Value, xAcc.Value, xStep.Value);
                    }
                    else
                    {
                        Common.ReportCmdKeyProgress(CmdKey.S0014);
                    }
                }
            }
            else if (ampc == Common.Y_Axis)
            {
                if (!yStepMode)
                {
                    ampc.JogStop();
                }
                else
                {
                    if (ampc.IsInPosition)
                    {
                        ampc.JogInc(ySpeed.Value, yAcc.Value, yStep.Value);
                    }
                    else
                    {
                        Common.ReportCmdKeyProgress(CmdKey.S0014);
                    }
                }
            }
            else if (ampc == Common.Z_Axis)
            {
                if (!zStepMode)
                {
                    ampc.JogStop();
                }
                else
                {
                    if (ampc.IsInPosition)
                    {
                        ampc.JogInc(zSpeed.Value, zAcc.Value, zStep.Value);
                    }
                    else
                    {
                        Common.ReportCmdKeyProgress(CmdKey.S0014);
                    }
                }
            }
            else if (ampc == Common.T_Axis)
            {
                if (!tStepMode)
                {
                    ampc.JogStop();
                }
                else
                {
                    if (ampc.IsInPosition)
                    {
                        ampc.JogInc(tSpeed.Value, tAcc.Value, tStep.Value);
                    }
                    else
                    {
                        Common.ReportCmdKeyProgress(CmdKey.S0014);
                    }
                }
            }
            else
            {

            }
        }

        private void AxisButton_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonEx bt = sender as ButtonEx;
            IAmpCProvider ampc = bt.Tag as IAmpCProvider;
            if (ampc == Common.X_Axis)
            {
                if (!xStepMode)
                {
                    ampc.JogDir(xSpeed.Value,xAcc.Value,bt.Flag);
                }
            }
            else if (ampc == Common.Y_Axis)
            {
                if (!yStepMode)
                {
                    ampc.JogDir(ySpeed.Value, yAcc.Value, bt.Flag);
                }
            }
            else if (ampc == Common.Z_Axis)
            {
                if (!zStepMode)
                {
                    ampc.JogDir(zSpeed.Value, zAcc.Value, bt.Flag);
                }
            }
            else if (ampc == Common.T_Axis)
            {
                if (!tStepMode)
                {
                    ampc.JogDir(tSpeed.Value, tAcc.Value, bt.Flag);
                }
            }
            else
            {

            }
        }

        private void xCheck_CheckedChanged(object sender, EventArgs e)
        {
            xStep.Enabled = xCheck.Checked;
            xStepMode = xCheck.Checked;
            if (xCheck.Checked)
            {
                xPButton.Text = "Q";
                xNButton.Text = "R";
            }
            else
            {
                xPButton.Text = "C";
                xNButton.Text = "D";
            }
        }

        private void yCheck_CheckedChanged(object sender, EventArgs e)
        {
            yStep.Enabled = yCheck.Checked;
            yStepMode = yCheck.Checked;
            if (yCheck.Checked)
            {
                yPButton.Text = "O";
                yNButton.Text = "P";
            }
            else
            {
                yPButton.Text = "E";
                yNButton.Text = "F";
            }
        }

        private void zCheck_CheckedChanged(object sender, EventArgs e)
        {
            zStep.Enabled = zCheck.Checked;
            zStepMode = zCheck.Checked;
            if (zCheck.Checked)
            {
                zPButton.Text = "U";
                zNButton.Text = "V";
            }
            else
            {
                zPButton.Text = "S";
                zNButton.Text = "T";
            }
        }

        private void tCheck_CheckedChanged(object sender, EventArgs e)
        {
            tStep.Enabled = tCheck.Checked;
            tStepMode = tCheck.Checked;
            if (tCheck.Checked)
            {
                tPButton.Text = "Z";
                tNButton.Text = "Y";
            }
            else
            {
                tPButton.Text = "A";
                tNButton.Text = "B";
            }
        }

        private void LoadButtonStatus()
        {
            xPButton.Tag = Common.X_Axis;
            xPButton.Flag = -1;

            xNButton.Tag = Common.X_Axis;
            xNButton.Flag = 1;

            yPButton.Tag = Common.X_Axis;
            yPButton.Flag = -1;

            yNButton.Tag = Common.X_Axis;
            yNButton.Flag = 1;

            zPButton.Tag = Common.X_Axis;
            zPButton.Flag = 1;

            zNButton.Tag = Common.X_Axis;
            zNButton.Flag = -1;

            tPButton.Tag = Common.X_Axis;
            tPButton.Flag = 1;

            tNButton.Tag = Common.X_Axis;
            tNButton.Flag = -1;

        }

        private void SystemAxisCtrManger_Load(object sender, EventArgs e)
        {
            LoadButtonStatus();
        }
    }
}
