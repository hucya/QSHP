using QSHP.Com;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace QSHP.UI
{
    public partial class AlignedCenterManager : AlignFormBase
    {
        int countTick = 0;
        float lineWidth = 80;
        float lineHeight = 80;
        float w, h;
        int posFlag = 0;
        PointF p1, p2,p3,centerPos;
        float arc1, arc2;
        Pen linePen = new Pen(Color.YellowGreen, 1);
        Pen recPen = new Pen(Color.GreenYellow, 1);
        bool repairSucessful = false;
        public AlignedCenterManager()
        {
            InitializeComponent();
          
        }
        private void CaptureView_UserPaint(object sender, PaintEventArgs e)
        {
            w = e.ClipRectangle.Width/2;
            h = e.ClipRectangle.Height/2;
            Graphics g = e.Graphics;
            g.DrawLine(linePen,w,0, w, e.ClipRectangle.Height);
            g.DrawLine(linePen, 0, h , e.ClipRectangle.Width, h );
            if (CaptureView.IncWidthPressed | CaptureView.DecWidthPressed | CaptureView.IncHeightPressed | CaptureView.DecHeightPressed)
            {
                if (countTick==0||countTick > 5)
                {
                    if (CaptureView.IncWidthPressed)
                    {
                        lineWidth++;
                    }
                    if (CaptureView.DecWidthPressed)
                    {
                        lineWidth--;
                    }
                    if (CaptureView.IncHeightPressed)
                    {
                        lineHeight++;
                    }
                    if (CaptureView.DecHeightPressed)
                    {
                        lineHeight--;
                    }
                }
                countTick++;
            }
            else
            {
                countTick = 0;
            }
            
            if (lineWidth > w)
            {
                lineWidth = w;
            }
            if (lineHeight > h)
            {
                lineHeight = h;
            }
            if (Common.T_Axis != null&& posFlag>0)
            {
                tAdj.Value = Common.T_Axis.RealPos - arc1;
            }
            g.DrawRectangle(recPen, w- lineWidth,h- lineHeight,2*lineWidth,2*lineHeight);
        }

        private void AlignedCenterManager_Load(object sender, EventArgs e)
        {
            CaptureView.UserPaint += CaptureView_UserPaint;
            posFlag = 0;
            centerPos = Globals.ViewCenter;
            cPosX.Value = centerPos.X;
            cPosY.Value = centerPos.Y;
            Common.ReportCmdKeyProgress(CmdKey.P0300);
        }

        private void AlignedCenterManager_ConfirmClick(object sender, EventArgs e)
        {
            if (repairSucessful)
            {
                Globals.ViewCenter = centerPos;//保存实时中心点坐标参数

                Globals.DevCfg.LowCenterX = centerPos.X;
                Globals.DevCfg.LowCenterY = centerPos.Y;
                Globals.DevCfg.SaveDevDataToFile(Globals.AppCfg.DevFullPathName);
                Common.ReportCmdKeyProgress(CmdKey.P0310);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0303);
            }
        }

        private void AlignedCenterManager_BT0Click(object sender, EventArgs e)
        {
            if (posFlag == 0)
            {
                p1 = Globals.AxisPoint;
                arc1 = Common.T_Axis.RealPos;
                p1X.Value = p1.X;
                p1Y.Value = p1.Y;
                posFlag = 1;
                Common.ReportCmdKeyProgress(CmdKey.P0301);
            }
            else if (posFlag == 1)
            {
                arc2 = Common.T_Axis.RealPos;
                if (Math.Abs(arc2-arc1)<30)//T轴旋转角度小于30度需要重新拾取
                {
                    posFlag = 1;
                    Common.ReportCmdKeyProgress(CmdKey.P0305);
                }
                else if (p1 == p2)
                {
                    posFlag = 1;
                    Common.ReportCmdKeyProgress(CmdKey.P0306);
                }
                else
                {
                    p2 = Globals.AxisPoint;
                    p2X.Value = p2.X;
                    p2Y.Value = p2.Y;
                    posFlag = 2;
                    Common.ReportCmdKeyProgress(CmdKey.P0302);
                }
            }
            else if(posFlag == 2) //提示相关信息
            {
                if (p2 == p3)
                {
                    Common.ReportCmdKeyProgress(CmdKey.P0306);
                    posFlag = 2;
                }
                else
                {
                    p3 = Globals.AxisPoint;
                    p3X.Value = p3.X;
                    p3Y.Value = p3.Y;
                    posFlag = 3;
                    Common.ReportCmdKeyProgress(CmdKey.P0303);
                }
            }
            else
            {
                posFlag = 0;
            }
            repairSucessful = false;
        }

        private void AlignedCenterManager_BT1Click(object sender, EventArgs e)
        {
            if (posFlag == 2)//两点计算圆心
            {
                float arc = arc2 - arc1;
                PointF p = RotateMath.RotateCenterPoint(p1, p2, arc);
                posFlag = 0;
                Common.ReportCmdKeyProgress(CmdKey.P0304);
                repairSucessful = true;
            }
            else if (posFlag == 3)//三点计算圆心
            {
                float r = 0;
                centerPos = RotateMath.RotateCenterPoint(p1, p2, p3,out r);
                posFlag = 0;
                repairSucessful = true;
                Common.ReportCmdKeyProgress(CmdKey.P0309);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0307);
            }
            cPosX.Value = centerPos.X;
            cPosY.Value = centerPos.Y;
        }

        private void AlignedCenterManager_BT5Click(object sender, EventArgs e)
        {
           
            p1 = new PointF(200, 200);
            p2 = new PointF(200, 200);
            p3 = new PointF(200, 200);
            centerPos = Globals.ViewCenter;
            posFlag = 0;
            arc1 = 0;
            tAdj.Value = 0;
            p1X.Value = 0;
            p1Y.Value = 0;
            p2X.Value = 0;
            p2Y.Value = 0;
            p3X.Value = 0;
            p3Y.Value = 0;
            repairSucessful = false;
            Common.ReportCmdKeyProgress(CmdKey.P0308);
        }

        public override bool FormUnloadReady()
        {
            CaptureView.UserPaint -= CaptureView_UserPaint;
            return base.FormUnloadReady();
        }
    }
}
