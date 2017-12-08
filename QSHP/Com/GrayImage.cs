using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using QSHP.Com;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace QSHP.Com
{
    public static class GrayImage
    {
        public static ColorMatrix GrayMatrix = new ColorMatrix(
                new float[][]   
                        {  
                            new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },  
                            new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },  
                            new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },  
                            new float[] { 0, 0, 0, 1, 0 },  
                           new float[] { 0, 0, 0, 0, 1 }  
                        });
        public static ColorPalette GrayColorPalette;
        static GrayImage()
        {
            using (Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                GrayColorPalette = bmp.Palette;
            }
            for (int i = 0; i < 256; i++)
            {
                GrayColorPalette.Entries[i] = Color.FromArgb(i, i, i);
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
        /// <summary>  
        /// 将源图像灰度化，实际为伪彩色图像。
        /// </summary>  
        /// <param name="src"> 源图像。 </param>  
        /// <returns> 灰度RGB图像。 </returns>  
        public static Bitmap MakeGrayScale(this Bitmap src)
        {
            Bitmap newBitmap = new Bitmap(src.Width, src.Height, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(GrayMatrix);
                g.DrawImage(src, new Rectangle(0, 0, src.Width, src.Height), 0, 0, src.Width, src.Height, GraphicsUnit.Pixel, attributes);
            }
            return newBitmap;
        }
        /// <summary>
        /// 将源图像灰度化，并转化为8位灰度图像。
        /// </summary>
        /// <param name="original"> 源图像。 </param>
        /// <returns> 8位灰度图像。 </returns>
        public static Bitmap ToGrayScale(this Bitmap original)
        {
            if (original != null)
            {
                Bitmap retBitmap = BuiltGrayBitmap(ToGrayData(original), original.Width, original.Height);
                return retBitmap;
            }
            else
            {
                return null;
            }
        }
        public unsafe static Bitmap ToGrayBitmap(this Bitmap src)
        {
            if (src != null)
            {
                if (src.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    return src.Clone() as Bitmap;
                }
                else
                {
                    Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);
                    Bitmap des = new Bitmap(rect.Width, rect.Height, PixelFormat.Format8bppIndexed);
                    BitmapData srcData = src.LockBits(rect, ImageLockMode.WriteOnly, src.PixelFormat);
                    BitmapData desData = des.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                    byte* srcPtr = (byte*)srcData.Scan0.ToPointer();
                    byte* desPtr = (byte*)desData.Scan0.ToPointer();
                    int srcoffSet = srcData.Stride % 4;
                    int desoffSet = desData.Stride % 4;
                    int r, g, b = 0;
                    for (int h = 0; h < srcData.Height; h++)
                    {
                        for (int w = 0; w < srcData.Width; w++)
                        {
                            b = *srcPtr++;
                            g = *srcPtr++;
                            r = *srcPtr++;
                            *desPtr++ = (byte)(r * 0.229 + g * 0.587 + b * 0.114);
                        }
                        srcPtr += srcoffSet;
                        desPtr += desoffSet;
                    }
                    src.UnlockBits(srcData);
                    des.UnlockBits(desData);
                    des.Palette = GrayColorPalette;
                    return des;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取RGB图灰度数组
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] ToGrayData(this Bitmap src)
        {
            if (src != null)
            {
                Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);
                BitmapData bmpData = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
                int width = bmpData.Width;
                int height = bmpData.Height;
                int stride = bmpData.Stride;
                int posDst = 0;
                byte[] grayValues = new byte[width * height]; // 不含未用空间。
                unsafe
                {
                    Parallel.ForEach(Partitioner.Create(0, height), (H) =>
                    {
                        byte* srcPtr = (byte*)bmpData.Scan0;
                        int r, g, b = 0;
                        byte* curP;
                        {
                            for (int i = H.Item1; i < H.Item2; i++)
                            {
                                posDst = i * stride;
                                curP = srcPtr + posDst;
                                for (int j = 0; j < width; j++)
                                {
                                    r = *curP++;
                                    g = *curP++;
                                    r = *curP++;
                                    grayValues[posDst++] = (byte)(r * 0.229 + g * 0.587 + b * 0.114);
                                }
                            }
                        }
                    });
                }
                src.UnlockBits(bmpData);  // 解锁内存区域
                return grayValues;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 用灰度数组新建一个8位灰度图像。
        /// </summary>
        /// <param name="rawValues"> 灰度数组(length = width * height)。 </param>
        /// <param name="width"> 图像宽度。 </param>
        /// <param name="height"> 图像高度。 </param>
        /// <returns> 新建的8位灰度位图。 </returns>
        public static Bitmap BuiltGrayBitmap(byte[] rawValues, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            int stride = bmpData.Stride;        // 计算每行未用空间字节数
            IntPtr desPtr = bmpData.Scan0;           // 为图像数据分配内存
            unsafe
            {
                fixed (byte* ptr = &rawValues[0])
                {
                    IntPtr srcPtr = new IntPtr((void*)ptr);
                    for (int i = 0; i < height; i++)
                    {
                        NativeMethods.CopyMemory(desPtr, srcPtr, width);
                        srcPtr += width;
                        desPtr += stride;
                    }
                }
            }
            bitmap.UnlockBits(bmpData);  // 解锁内存区域
            bitmap.Palette = GrayColorPalette;
            return bitmap;
        }
        /// <summary>
        /// 从灰度src指针构建灰度图
        /// </summary>
        /// <param name="srcPtr"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap BuiltGrayBitmap(IntPtr srcPtr, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height),ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            int stride = bmpData.Stride;        // 计算每行未用空间字节数
            IntPtr desPtr = bmpData.Scan0;      // 获取首地址
            for (int i = 0; i < height; i++)
            {
                NativeMethods.CopyMemory(desPtr, srcPtr, width);
                srcPtr += width;
                desPtr += stride;
            }
            bitmap.UnlockBits(bmpData);  // 解锁内存区域
            bitmap.Palette = GrayColorPalette;
            return bitmap;
        }
    }
}
