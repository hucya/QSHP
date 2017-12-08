using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace QSHP.Com
{
    public static class BitmapHelper
    {
        public static Bitmap RotateImg(Bitmap b, float angle)
        {
            angle = angle % 360;
            //弧度转换  

            double radian = angle * Math.PI / 180.0;

            double cos = Math.Cos(radian);

            double sin = Math.Sin(radian);

            int w = b.Width;

            int h = b.Height;

            int W = w; //(int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));

            int H = h;//(int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));

            Bitmap dsImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            //计算偏移量  
            PointF Offset = new PointF((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致  
            RectangleF rect = new RectangleF(Offset.X, Offset.Y, w, h);
            PointF center = new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            g.ResetTransform();
            g.Save();
            g.Dispose();
            b.Dispose();
            return dsImage;
        }
        /// <summary>
        /// 图像边缘检测
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Bitmap Robert(Bitmap src)
        {
            int w = src.Width;
            int h = src.Height;
            try
            {
                Bitmap dstBitmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Imaging.BitmapData srcData = src.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Imaging.BitmapData dstData = dstBitmap.LockBits(new Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    byte* p;
                    int stride = srcData.Stride;
                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            //边缘八个点像素不变
                            if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                            {
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                            }
                            else
                            {
                                int r0, r5, r6, r7;
                                int g5, g6, g7, g0;
                                int b5, b6, b7, b0;
                                double vR, vG, vB;
                                //右
                                p = pIn + 3;
                                r5 = p[2];
                                g5 = p[1];
                                b5 = p[0];
                                //左下
                                p = pIn + stride - 3;
                                r6 = p[2];
                                g6 = p[1];
                                b6 = p[0];
                                //正下
                                p = pIn + stride;
                                r7 = p[2];
                                g7 = p[1];
                                b7 = p[0];
                                //中心点
                                p = pIn;
                                r0 = p[2];
                                g0 = p[1];
                                b0 = p[0];
                                vR = (double)(Math.Abs(r0 - r5) + Math.Abs(r5 - r7));
                                vG = (double)(Math.Abs(g0 - g5) + Math.Abs(g5 - g7));
                                vB = (double)(Math.Abs(b0 - b5) + Math.Abs(b5 - b7));
                                if (vR > 0)
                                {
                                    vR = Math.Min(255, vR);
                                }
                                else
                                {
                                    vR = Math.Max(0, vR);
                                }
                                if (vG > 0)
                                {
                                    vG = Math.Min(255, vG);
                                }
                                else
                                {
                                    vG = Math.Max(0, vG);
                                }
                                if (vB > 0)
                                {
                                    vB = Math.Min(255, vB);
                                }
                                else
                                {
                                    vB = Math.Max(0, vB);
                                }
                                pOut[0] = (byte)vB;
                                pOut[1] = (byte)vG;
                                pOut[2] = (byte)vR;
                            }
                            pIn += 3;
                            pOut += 3;
                        }
                        pIn += srcData.Stride - w * 3;
                        pOut += srcData.Stride - w * 3;
                    }
                }
                src.UnlockBits(srcData);
                dstBitmap.UnlockBits(dstData);
                return dstBitmap;
            }
            catch
            {
                return null;
            }
        }

        public static byte OtsuThreshold(byte[] data)
        {
            if (data != null)
            {
                int count = data.Length;
                if (count<1)
                {
                    return 0;
                }
                byte threshold = 0;
                float gmax = 0;
                float wk = 0, uk = 0;
                float[] histogram = new float[256];
                foreach (var item in data)
                {
                    histogram[item]++;
                }
                float avgValue = 0;
                for (int i = 0; i < 256; i++)
                {
                    histogram[i] = histogram[i] / count;
                    avgValue += i * histogram[i];
                }
               
                for (int i = 0; i < 256; i++)
                {
                    wk += histogram[i];
                    uk += histogram[i];
                    float ut = avgValue * wk - uk;
                    float g = ut * ut / (wk * (1 - wk));
                    if (g > gmax)
                    {
                        gmax = g;
                        threshold = (byte)i;
                    }
                }
                return threshold;
               
            }
            else
            {
                return 0 ;
            }
        }
        /// <summary>
        /// 判断是否为灰度图
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static bool IsGrayscale(this Bitmap image)
        {
            bool ret = false;
            if (image.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                ret = true;
                ColorPalette cp = image.Palette;
                Color c;
                for (int i = 0; i < 256; i++)
                {
                    c = cp.Entries[i];
                    if ((c.R != i) || (c.G != i) || (c.B != i))
                    {
                        ret = false;
                        break;
                    }
                }
            }
            return ret;
        }
    }
}
