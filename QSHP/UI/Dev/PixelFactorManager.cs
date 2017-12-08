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
    public partial class PixelFactorManager : AlignFormBase
    {
        int h = 420;
        int h1 = 0;
        int tickCount = 0;
        float s1, s2,factor;
        bool btFlag = false;
        Pen linePen = new Pen(Color.Yellow, 1);
        public PixelFactorManager()
        {
            InitializeComponent();
        }

        private void PixelFactorManager_Load(object sender, EventArgs e)
        {
            CaptureView.UserPaint += CaptureView_UserPaint;
            CaptureView.MouseFollow = false;//关闭鼠标跟随
            CaptureView.ApplyBinning = true;//不支持倍率切换
            if (CaptureView.CaptureProvider != null)
            {
                factor = CaptureView.CaptureProvider.Scale;
                pixScale.Value = factor;
                CaptureView.CaptureProvider.BinningMode = false;
            }
            yPix.Value =  h;
            Common.ReportCmdKeyProgress(CmdKey.P0200);
        }

        private void CaptureView_UserPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            h1 = e.ClipRectangle.Height - 30;
            if (CaptureView.IncHeightPressed | CaptureView.DecHeightPressed)
            {
                if (tickCount == 0 || tickCount > 5)
                {
                    if (CaptureView.IncHeightPressed)
                    {
                        h++;
                    }
                    else
                    {
                        h--;
                    }
                    yPix.Value = h;
                }
                tickCount++;
            }
            else
            {
                tickCount=0;
            }
            if (h > h1-20)
            {
                h = h1-20;
                yPix.Value = h;
            }
            else if (h<20)
            {
                h = 20;
                yPix.Value = h;
            }
            if (btFlag&& Common.Y_Axis != null)
            {
                yLenth.Value = Common.Y_Axis.RealPos - s1;
            }
            g.DrawLine(linePen, 0, h1, e.ClipRectangle.Width, h1);
            g.DrawLine(linePen, 0, h1-h, e.ClipRectangle.Width, h1-h);
        }

        private void PixelFactorManager_BT0Click(object sender, EventArgs e)
        {
            if (Common.Y_Axis != null)
            {
                s1 = Common.Y_Axis.RealPos;
                y1Pos.Value = s1;
                y2Pos.Value = s1;
                btFlag = true;
                Common.ReportCmdKeyProgress(CmdKey.P0201);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0309);
            }
        }

        private void PixelFactorManager_BT5Click(object sender, EventArgs e)
        {
            if (Common.Y_Axis != null)
            {
                s2 = Common.Y_Axis.RealPos;
                y2Pos.Value = s2;
                if (s1 == s2)
                {
                    Common.ReportCmdKeyProgress(CmdKey.P0202);
                }
                else
                {
                    factor = Math.Abs(s2 - s1) / h;
                    pixScale.Value = factor;
                    btFlag = false;
                    Common.ReportCmdKeyProgress(CmdKey.P0203);
                }
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0309);
            }

        }

        private void PixelFactorManager_ConfirmClick(object sender, EventArgs e)
        {
            if (CaptureView.CaptureProvider != null)
            {
                CaptureView.CaptureProvider.Scale=factor;//倍率当前
                Globals.DevCfg.LowPixValue = factor;
                Globals.DevCfg.SaveDevDataToFile(Globals.AppCfg.DevFullPathName);
                Common.ReportCmdKeyProgress(CmdKey.P0204);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0309);
            }
        }
    }
}
