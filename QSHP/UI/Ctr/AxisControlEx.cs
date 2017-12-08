using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using QSHP.HW;
using QSHP.HW.AmpC;
namespace QSHP.UI.Ctr
{

    [ToolboxItem(false)]
    public partial class AxisControlEx : UserControl
    {
        int waitTick = 0;
        int waitCount = 8;
        bool wait = false;
        IAmpCProvider provider;
        int dir = 0;
        public ButtonEx IncButton
        {
            get
            {
                return BT3;
            }
        }
        public ButtonEx DecButton
        {
            get
            {
                return BT1;
            }
        }
        public AxisControlEx()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetCommonAxisObject();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void BT5_Click(object sender, EventArgs e)
        {
            SetCommonAxisObject();
            if (BT5.Pressed)
            {
                BT5.Text = "*";
                BT2.Text = "O";
                BT4.Text = "Q";
                BT6.Text = "R";
                BT8.Text = "P";
                BT7.Text = "Y";
                BT9.Text = "Z";
            }
            else
            {
                BT5.Text = "+";

                BT2.Text = "I";
                BT4.Text = "G";
                BT6.Text = "H";
                BT8.Text = "J";
                BT7.Text = "W";
                BT9.Text = "X";
            }
        }

        private void SetCommonAxisObject()
        {
            BT1.Flag = 1;
            BT2.Flag = -1;
            BT3.Flag = -1;
            BT4.Flag = -1;
            BT6.Flag = 1;
            BT7.Flag = 1;
            BT8.Flag = 1;
            BT9.Flag = -1;
            BT7.Tag = Common.T_Axis;
            BT9.Tag = Common.T_Axis;
            BT2.Tag = Common.Y_Axis;
            BT8.Tag = Common.Y_Axis;
            BT4.Tag = Common.X_Axis;
            BT6.Tag = Common.X_Axis;
        }

        private void BT_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            ButtonEx bt = sender as ButtonEx;
            if (bt != null && bt.Tag != null)
            {
                if (!BT5.Pressed)//低倍步进值
                {
                    provider = bt.Tag as IAmpCProvider;
                    dir = bt.Flag;
                    wait = true;
                    waitTick = 0;
                }
            }
        }

        private void BT_MouseUp(object sender, MouseEventArgs e)
        {

            ButtonEx bt = sender as ButtonEx;
            if (bt != null && bt.Tag != null)
            {
                IAmpCProvider provider = bt.Tag as IAmpCProvider;
                if (provider != null)
                {
                    if (BT5.Pressed)
                    {
                        Common.AxisJogStep(provider, bt.Flag);
                    }
                    else
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
