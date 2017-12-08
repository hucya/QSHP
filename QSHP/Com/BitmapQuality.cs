using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace QSHP.Com
{
    public static class BitmapQuality
    {
        /// <summary>
        /// 获取图像清晰度梯度函数 Brenner方差模式 效果较差 计算量大 不建议使用
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static unsafe double GetBrennerQuality(this Bitmap src)
        {
            try
            {
                double val = 0;
                Rectangle rec = new Rectangle(0, 0, src.Width, src.Height);
                byte[] data = src.ToGrayData();
                if (data != null)
                {
                    fixed (byte* ptr = data)
                    {
                        val = GetBrennerQuality(new IntPtr(ptr), rec.Width, rec.Height);
                    }
                }
                return val;
            }
            catch
            {
                return 0;
            }
        }

        public static unsafe double GetBrennerQuality(IntPtr src, int w, int h)
        {
            try
            {
                double sum = 0;
                double val = 0;
                byte* ptr = (byte*)src;
                int num = 0;
                int pnum = 0;
                for (int j = h; j > -1; j--)
                {
                    pnum = j * h;
                    for (int i = w; i > -1; i--)
                    {
                        num = pnum + i;
                        if (i == 0 || i == w - 1 || j == 0 || j == h - 1)
                        {
                            val = 0;
                        }
                        else
                        {
                            val = Math.Pow(ptr[num] - ptr[num - 1], 2);
                        }
                        sum += val;
                    }
                }
                return Math.Round(sum / (h * w),3);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取图像清晰度 熵函数 模式 效果一般
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static unsafe double GetEntropyQuality(this Bitmap src)
        {
            try
            {
                double val = 0;
                Rectangle rec = new Rectangle(0, 0, src.Width, src.Height);
                byte[] data = src.ToGrayData();
                if (data != null)
                {
                    fixed (byte* ptr = data)
                    {
                        val = GetEntropyQuality(new IntPtr(ptr), rec.Width, rec.Height);
                    }
                }
                return val;
            }
            catch
            {
                return 0;
            }
        }

        public static unsafe double GetEntropyQuality(IntPtr src, int w, int h)
        {
            try
            {
                double mag = 0;
                double sum = 0;
                int gradX, gradY, pos = 0;
                byte* ptr = (byte*)src;
                int pnum = 0;
                for (int y = h; y > -1; y--)
                {
                    pnum = y * w;
                    for (int x = w; x > -1; x--)
                    {
                        pos = pnum + x;
                        if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                        {
                            mag = 0;
                        }
                        else
                        {
                            gradX = ptr[pos + 1] - ptr[pos - 1];
                            gradY = ptr[pos + w] - ptr[pos - w];
                            mag = Math.Sqrt(gradX * gradX + gradY * gradY);
                        }
                        sum += mag;
                    }
                }
                return Math.Round(sum / (w * h),3);
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 利用最小二乘法拟合  效果最好 计算量小 建议使用
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static unsafe double GetLinearQuality(this Bitmap src)
        {
            try
            {
                double val = 0;
                Rectangle rec = new Rectangle(0, 0, src.Width, src.Height);
                byte[] data = src.ToGrayData();
                if (data != null)
                {
                    fixed (byte* ptr = data)
                    {
                        val = GetLinearQuality(new IntPtr(ptr), rec.Width, rec.Height);
                    }
                }
                return val;
            }
            catch
            {
                return 0;
            }
        }

        public static unsafe double GetLinearQuality(IntPtr src, int w, int h)
        {
            try
            {
                double val = 0;
                byte* ptr = (byte*)src;
                int num = 0;
                LinearSize pValue;
                LinearSize value = new LinearSize();
                LinearSize maxValue = new LinearSize();
                bool flag = false;
                double linear = 0;
                int pnum = 0;
                for (int j = h; j > -1; j-=2)
                {
                    int m = 0;
                    flag = false;
                    value.Clear();
                    maxValue.Clear();
                    pnum = j * h;
                    for (int i = w ; i > -1; i-=2)
                    {
                        num = pnum + i;
                        if (ptr[num] - m>10)//连续上升
                        {
                            if (flag)
                            {
                                if (value.Count > maxValue.Count)
                                {
                                    pValue = maxValue;
                                    maxValue = value;
                                    value = pValue;
                                }
                                else if (value.Count == maxValue.Count)
                                {
                                    if (Math.Abs(ptr[value.Min] - ptr[value.Max]) > Math.Abs(ptr[maxValue.Min] - ptr[maxValue.Max]))
                                    {
                                        pValue = maxValue;
                                        maxValue = value;
                                        value = pValue;
                                    }
                                }
                            }
                            flag = false;
                            m = ptr[num];
                        }
                        else//连续下降
                        {
                            if (!flag)
                            {
                                value.Max = num;
                            }
                            value.Min = num;
                            m = ptr[num];
                            flag = true;
                        }
                    }
                    linear = LinearMath.LinearScaleValue(&ptr[maxValue.Min], maxValue.Count);
                    val += linear;
                }
                return val;
            }
            catch
            {
                return 0;
            }
        }
    }
}
