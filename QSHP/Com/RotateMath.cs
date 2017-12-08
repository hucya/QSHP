using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QSHP.Com
{
    public static class RotateMath
    {
        /// <summary>
        /// 计算p1点围绕center点旋转一定角度后的点坐标
        /// </summary>
        /// <param name="center">中心点坐标</param>
        /// <param name="p0">原始坐标</param>
        /// <param name="angle">旋转角度</param>
        /// <returns></returns>
        public static PointF PointRotate(PointF center, PointF p0,float angle)
        {
            double arc = angle / 180 * Math.PI;

            return PointRotate(center,p0,arc);
        }
        /// <summary>
        /// 计算p1点围绕center点旋转一定角度后的点坐标
        /// </summary>
        /// <param name="center">中心点坐标</param>
        /// <param name="p0">原始坐标</param>
        /// <param name="arc">旋转弧度</param>
        /// <returns></returns>
        public static PointF PointRotate(PointF center, PointF p0, double arc)
        {
            PointF tmp = new PointF();
            double x = (p0.X - center.X) * Math.Cos(arc) + (p0.Y - center.Y) * Math.Sin(arc) + center.X;
            double y = -(p0.X - center.X) * Math.Sin(arc) + (p0.Y - center.Y) * Math.Cos(arc) + center.Y;
            tmp.X = (float)x;
            tmp.Y = (float)y;
            return tmp;
        }
        /// <summary>
        /// 根据两点和弧度计算圆心坐标
        /// </summary>
        /// <param name="p0">起始位置</param>
        /// <param name="p1">旋转后位置</param>
        /// <param name="arc">旋转弧度</param>
        /// <returns></returns>
        public static PointF RotateCenterPoint(PointF p0, PointF p1, double arc)
        {
            double si = Math.Sin(arc);
            if (si != 0)
            {
                PointF tmp = new PointF();
                double ag1 = GetPointsRadian(p0, p1);
                double r = GetRotateR(p0, p1, arc);
                double ag2 = (Math.PI - Math.Abs(arc)) / 2;
                if (arc > 0)
                {
                    ag2 = ag1 - ag2;
                }
                else
                {
                    ag2 = ag1 + ag2;
                }
                if (p0.X > p1.X)
                {
                    ag2 += Math.PI;
                }
                tmp.X = (float)(p0.X + Math.Cos(ag2) * r);
                tmp.Y = (float)(p0.Y + Math.Sin(ag2) * r);
                return tmp;
            }
            else
            {
                return new PointF((p0.X + p1.X) / 2, (p0.Y + p1.Y) / 2);
            }
        }
        /// <summary>
        /// 根据两点和角度计算圆心坐标
        /// </summary>
        /// <param name="p0">起始位置</param>
        /// <param name="p1">旋转后位置</param>
        /// <param name="angle">旋转角度</param>
        /// <returns></returns>
        public static PointF RotateCenterPoint(PointF p0, PointF p1, float angle)
        {
            double arc = angle / 180 * Math.PI;
            return RotateCenterPoint(p0, p1, arc);
            
        }
        /// <summary>
        /// 计算两点和弧度对应圆的半径
        /// </summary>
        /// <param name="p0">起始位置p0</param>
        /// <param name="p1">旋转后位置p1</param>
        /// <param name="arc">旋转弧度</param>
        /// <returns></returns>
        public static double GetRotateR(PointF p0, PointF p1, double arc)
        {
            double si = Math.Sin(arc / 2);
            if (si != 0)
            {
                double l = Math.Sqrt(Math.Pow((p0.X - p1.X), 2) + Math.Pow((p0.Y - p1.Y), 2)) / 2;
                double r = Math.Abs(l / si);
                return r;
            }
            else
            {
                return Math.Sqrt(Math.Pow((p0.X - p1.X), 2) + Math.Pow((p0.Y - p1.Y), 2)) / 2;
            }
        }
        /// <summary>
        /// 计算过三点的圆心坐标和半径
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="r">计算返回半径</param>
        /// <returns></returns>
        public static PointF RotateCenterPoint(PointF p0, PointF p1, PointF p2,out float r)
        {
            PointF center = new PointF();
            double a = 2 * (p1.X - p0.X);
            double b = 2 * (p1.Y - p0.Y);
            double c = p1.X * p1.X + p1.Y * p1.Y - p0.X * p0.X - p0.Y * p0.Y;
            double d = 2 * (p2.X - p1.X);
            double e = 2 * (p2.Y - p1.Y);
            double f = p2.X * p2.X + p2.Y * p2.Y - p1.X * p1.X - p1.Y * p1.Y;
            center.X = (float)((b * f - e * c) / (b * d - e * a));
            center.Y = (float)((d * c - a * f) / (b * d - e * a));
            r = (float)(Math.Sqrt((center.X - p0.X) * (center.X - p0.X) + (center.Y - p0.Y) * (center.Y - p0.Y)));
            return center;
        }
        /// <summary>
        /// 获取两点对相对X轴的弧度值
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns>弧度值</returns>
        public static double GetPointsRadian(PointF p0, PointF p1)
        {
            return  Math.Atan((p0.Y - p1.Y) / (p0.X - p1.X));
        }
        /// <summary>
        /// 获取两点对相对X轴的角度
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns>角度值</returns>
        public static double GetPointsAngle(PointF p0, PointF p1)
        {
            double arc = GetPointsRadian(p0, p1);
            return arc * 180 / Math.PI;
        }
    }
}
