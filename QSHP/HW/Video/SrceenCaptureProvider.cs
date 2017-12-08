using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.HW.Video
{
    public class SrceenCaptureProvider
    {
        int MaxHeight = 1024;
        int MaxWidth = 1280;
        Bitmap image;
        Rectangle rect;
        private static SrceenCaptureProvider uniqueInstance = null;

        private static readonly object locker = new object();

        public Bitmap ScreemImage
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public Rectangle CaptureRect
        {
            get
            {
                return rect;
            }
            set
            {
                if (value.Size == rect.Size)
                {
                    return;
                }
                lock (image)
                {
                    if (image != null)
                    {
                        image.Dispose();
                    }
                    image = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
                }
                rect = value;
            }
        }
        public SrceenCaptureProvider()
        {
            MaxHeight = SystemInformation.VirtualScreen.Height;
            MaxWidth = SystemInformation.VirtualScreen.Width;
            rect = new Rectangle(0, 0, MaxWidth, MaxHeight);
            image = new Bitmap(MaxWidth, MaxHeight, PixelFormat.Format24bppRgb);
        }
        void Dispose()
        {
            if (image != null)
            {
                image.Dispose();
            }
        }
        public static SrceenCaptureProvider GetInstance()
        {
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    uniqueInstance = new SrceenCaptureProvider();
                }
            }
            return uniqueInstance;
        }

        public Bitmap GetCaptureFrame()
        {
            try
            {
                lock (image)
                {
                    using (Graphics g = Graphics.FromImage(image))
                    {
                        g.CopyFromScreen(new Point(rect.X, rect.Y), new Point(0, 0), rect.Size);
                    }
                }
            }
            catch
            {
                return null;
            }
            return image;
        }
    }
}
