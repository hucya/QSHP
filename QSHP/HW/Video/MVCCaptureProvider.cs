using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using QSHP.Com;
using System.Xml.Serialization;

namespace QSHP.HW.Video
{
    [XmlType("MVCCaptureProvider")]
    public class MVCCaptureProvider : IVideoProvider
    {
        [XmlIgnore]
        public int MaxHeight = 1024;
        [XmlIgnore]
        public int MaxWidth = 1280;
        MVCLibWrapper mLib;
        Size size = new Size(516, 480);
        byte[] gain = { 30, 30, 30 };
        byte[] bGDIMode = { 1, 0, 0, 0, 0, 0, 0, 0 };
        int exposure = 300;
        IntPtr handle;
        private IntPtr buffer;
        bool binningMode = false;
        CapInfoStruct capinfo;
        Object locker = new object();
        Bitmap image;
        Rectangle rect;
        byte luminance = 2;
        bool enlarge = false;
        bool isRunning = false;
        string sourceName = "MVCCamera";
        int devIndex = 0;
        float scale = 0.0025f;
        public string SourceName
        {
            get
            {
                return sourceName;
            }
        }
        public int Index
        {
            get
            {
                return devIndex;
            }
            set
            {
                if (!IsInit)
                {
                    devIndex = value;
                }
            }
        }
        public Size Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value != size)
                {
                    size = value;
                    lock (locker)
                    {
                        if (IsInit)
                        {
                            image = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
                            rect.Width = size.Width;
                            rect.Height = size.Height;
                            SetBlingMode(binningMode);
                        }
                    }
                }
            }
        }

        public float Scale
        {
            get
            {
                if (binningMode)
                {
                    return scale * 2;
                }
                else
                {
                    return scale;
                }
            }
            set
            {
                if (value != 0)
                {
                    if (binningMode)
                    {
                        scale = value / 2;
                    }
                    else
                    {
                        scale = value;
                    }
                }
            }
        }

        public byte AdcMode
        {
            get
            {
                return luminance;
            }
            set
            {
                if (luminance != (byte)(value & 7))
                {
                    luminance = (byte)(value & 7);
                    if (IsInit)
                    {
                        mLib.MV_SetUsb2ADCMode(handle, luminance);
                    }
                }
            }
        }
        [XmlIgnore]
        public int DataSize
        {
            get
            {
                return size.Height * size.Width;
            }
        }

        public int Exposure
        {
            get
            {
                return exposure;
            }
            set
            {
                if (exposure != value)
                {
                    exposure = value;
                    capinfo.Exposure = exposure;
                    if (IsInit)
                    {
                        mLib.MV_Usb2SetPartOfCapInfo(handle, ref capinfo);
                    }
                }
            }
        }

        public byte Gain
        {
            get
            {
                return gain[0];
            }
            set
            {
                if (gain[0] != value)
                {
                    gain[0] = value;
                    gain[1] = value;
                    gain[2] = value;
                    capinfo.Gain = gain;
                    if (IsInit)
                    {
                        mLib.MV_Usb2SetPartOfCapInfo(handle, ref capinfo);
                    }
                }
            }
        }
        [XmlIgnore]
        public bool IsInit
        {
            get;
            set;
        }

        public bool BinningMode
        {
            get
            {
                return binningMode;
            }
            set
            {
                if (binningMode != value)
                {
                    binningMode = value;
                    if (IsInit)
                    {
                        SetBlingMode(value);
                    }
                }
            }
        }

        public bool IsRunning
        {
            get { return isRunning; }
        }
        [XmlIgnore]
        public float FrameRate
        {
            get
            {
                if (IsInit)
                {
                    float rate = 0f;
                    this.mLib.MV_Usb2GetFrameRate(handle, out rate);
                    return rate;
                }
                else
                {
                    return 0;
                }
            }
        }

        public MVCCaptureProvider()
        {
            mLib = new MVCLibWrapper();
            capinfo = new CapInfoStruct();
            handle = IntPtr.Zero;
            capinfo.Control = 0;
            capinfo.Gain = gain;
            capinfo.Height = size.Height;
            capinfo.Width = size.Width;
            capinfo.HorizontalOffset = (MaxWidth - Size.Width) / 2;
            capinfo.VerticalOffset = (MaxHeight - Size.Height) / 2;
            image = new Bitmap(Size.Width, Size.Height, PixelFormat.Format24bppRgb);
            rect = new Rectangle(0, 0, Size.Width, Size.Height);
            buffer = Marshal.AllocCoTaskMem(MaxHeight * MaxWidth);
            capinfo.Buffer = buffer;
            capinfo.Reserved = bGDIMode;
            IsInit = false;
        }

        public MVCCaptureProvider(int index)
            : this()
        {
            this.devIndex = index;
        }

        private void SetBlingMode(bool mode)
        {
            lock (locker)
            {
                if (size.Width * 2 > MaxWidth || 2 * size.Height > MaxHeight)
                {
                    capinfo.Control = 0;
                    capinfo.Width = size.Width;
                    capinfo.Height = size.Height;
                    capinfo.HorizontalOffset = (MaxWidth - capinfo.Width) / 2;
                    capinfo.VerticalOffset = (MaxHeight - capinfo.Height) / 2;
                    enlarge = !mode;
                }
                else
                {
                    enlarge = false;
                    if (mode)
                    {
                        capinfo.Control = 0x18;
                        capinfo.Width = 2 * Size.Width;
                        capinfo.Height = 2 * size.Height;
                        capinfo.HorizontalOffset = (MaxWidth - capinfo.Width) / 2;
                        capinfo.VerticalOffset = (MaxHeight - capinfo.Height) / 2;
                    }
                    else
                    {
                        capinfo.Control = 0;
                        capinfo.Width = size.Width;
                        capinfo.Height = size.Height;
                        capinfo.HorizontalOffset = (MaxWidth - capinfo.Width) / 2;
                        capinfo.VerticalOffset = (MaxHeight - capinfo.Height) / 2;
                    }
                }
                if (IsInit)
                {
                    mLib.MV_Usb2SetPartOfCapInfo(handle, ref capinfo);
                }
            }
        }

        public void Dispose()
        {
            Marshal.FreeCoTaskMem(buffer);
            if (image != null)
            {
                image.Dispose();
            }
            if (IsInit)
            {
                StopCapture();
                UninitDriver();
            }
            mLib.Dispose();
        }

        public bool InitDriver()
        {
            try
            {
                int res = mLib.MV_Usb2Init(string.Format("MVCCamera{0}",devIndex), out devIndex, ref capinfo, out handle);
                if (res == 0 && handle != IntPtr.Zero)
                {
                    IsInit = true;
                    res = mLib.MV_SetUsb2ADCMode(handle, luminance);
                    DevType type = DevType.MVC1000MF;
                    res = mLib.MV_Usb2GetDeviceType(handle, ref type);
                    sourceName = type.ToString() + devIndex.ToString();
                    //res = mLib.MV_Usb2SetMirrorMode(handle, 1);//采集数据进行水平垂直翻转 bit0 水平镜像 bit1 垂直镜像 效率较低
                    return res == 0;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                UninitDriver();
                return false;
            }
        }
        /// <summary>
        /// 反初始化设备
        /// </summary>
        /// <returns></returns>
        public bool UninitDriver()
        {
            IsInit = false;
            isRunning = false;
            if (handle != IntPtr.Zero)
            {
                mLib.MV_Usb2Uninit(ref handle);
                handle = IntPtr.Zero;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 开始采集图像
        /// </summary>
        /// <returns></returns>
        public bool StartCapture()
        {
            if (IsInit)
            {
                int res = this.mLib.MV_Usb2StartCapture(handle, true);
                isRunning = res == 0;
                return isRunning;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 停止采集图像
        /// </summary>
        /// <returns></returns>
        public bool StopCapture()
        {
            if (IsInit)
            {
                int res = this.mLib.MV_Usb2StartCapture(handle, false);
                if (res == 0)
                {
                    isRunning = false;
                }
                return isRunning;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取图像
        /// </summary>
        /// <returns></returns>
        public Bitmap GetCurrentFrame()
        {
            if (IsInit)
            {
                int res = -1;
                try
                {
                    lock (image)
                    {
                        BitmapData bmData = image.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                        res = this.mLib.MV_Usb2GetRgbData(handle, ref capinfo, bmData.Scan0);
                        image.UnlockBits(bmData);
                        image.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                        if (enlarge)
                        {
                            using (Graphics g = Graphics.FromImage(image))
                            {
                                g.DrawImage(image, rect, new Rectangle(rect.Width / 4, rect.Height / 4, rect.Width / 2, rect.Height / 2), GraphicsUnit.Pixel);//虚拟放大
                            }
                        }
                    }
                }
                catch
                {
                    return null;
                }
                return image;
            }
            else
            {
                return null;
            }

        }
    }
    #region 内部类和结构体
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct CapInfoStruct
    {
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr Buffer;
        [MarshalAs(UnmanagedType.U4)]
        public int Height;
        [MarshalAs(UnmanagedType.U4)]
        public int Width;
        [MarshalAs(UnmanagedType.U4)]
        public int HorizontalOffset;
        [MarshalAs(UnmanagedType.U4)]
        public int VerticalOffset;
        [MarshalAs(UnmanagedType.U4)]
        public int Exposure;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Gain;
        public byte Control;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Reserved;
    }
    internal enum DevType:ushort
    {
        MVC1000F = 0x7076,
        MVC1000MF = 0x7176,
        MVC2000F = 0x7276,
        MVC3000F = 0x7376,
        MVC5000F = 0x7476,
        MVC300F = 0x7576,
        MVC5001F = 0x7477,
        MVC5001MF = 0x7478,
        MVC360MF = 0x7676,
        MVC360F = 0x7677,
        MVC1450DF = 0x7701,
        MVC1450DMF = 0x7702,
        MVC1450DMF14 = 0x7703,
        MVC2900DF = 0x7704,
        MVC2900DMF = 0x7705,
        MVC2010DF = 0x7706,
        MVC2010DMF = 0x7707,
        MVC380DF = 0x7708,
        MVC380DMF = 0x7709,
        MVC1450DMF14C = 0x770a,
        MVC2900DMF14 = 0x770b,
        MVC2900DMF14C = 0x770c,
        MVC9000F = 0x7876,
        MVC10KF = 0x7976
    }

    internal sealed class MVCLibWrapper : DLLWrapper
    {
        /// <summary>
        /// 设备初始化，查找并打开设备，并返回设备句柄，这个句柄用于以后的API函数调用。此函数必须在调用MV_Usb2Start()函数之前调用，否则将不会显示图象。
        /// </summary>
        internal Usb2Init MV_Usb2Init;
        /// <summary>
        /// 反初始化指定的MVC设备。建议程序结束前调用此函数，否则会造成程序出错。
        /// </summary>
        internal Usb2Uninit MV_Usb2Uninit;
        /// <summary>
        /// 停止视频显示并关闭预览窗口。在程序结束前请确保视频关闭。要重新开始预览，调用MV_Usb2Start函数。
        /// </summary>
        internal Usb2Stop MV_Usb2Stop;
        /// <summary>
        /// 控制相机开始/停止采集图像，调用此函数的采集方式不创建图像预览窗口，可以通过采集回调函数取得图像数据，进行处理。
        /// </summary>
        internal Usb2StartCapture MV_Usb2StartCapture;
        /// <summary>
        /// 如果当前没有预览窗口，这个函数将创建一个预览窗口并开始预览。如果当前预览暂停，调用此函数可以继续预览。除了hImager之外，其它的参数都是可选的。此函数适用于需要采集同时预览图像的情况，如果您只需要获取时实图像数据，不需要打开预览窗口进行显示，建议调用MV_Usb2StartCapture函数实现采集。
        /// </summary>
        internal Usb2Start MV_Usb2Start;
        /// <summary>
        /// 设置当前预览视频的CapInfoStruct结构 。注意这个与	MV_Usb2SetCapInfo（）函数的区别。这个函数不更新预览窗口的尺寸。详细用法请参考CapInfoStruct结构的说明。
        /// </summary>
        internal Usb2SetPartOfCapInfo MV_Usb2SetPartOfCapInfo;
        /// <summary>
        /// 设置采集的图像是否左右翻转，是否上下翻转。
        /// </summary>
        internal Usb2SetMirrorMode MV_Usb2SetMirrorMode;
        /// <summary>
        /// 得到一帧图象的同时，存为bmp文件。
        /// </summary>
        internal Usb2SaveFrameAsBmp MV_Usb2SaveFrameAsBmp;
        /// <summary>
        /// 用于获取一帧图象数据。
        /// </summary>
        internal Usb2GetRgbData MV_Usb2GetRgbData;
        /// <summary>
        /// 此函数用于采集raw data数据。
        /// </summary>
        internal Usb2GetRawData MV_Usb2GetRawData;
        /// <summary>
        /// 用于获得当前连接的MVC数目。请在MV_Usb2Init调用之后调用此函数。
        /// </summary>
        internal Usb2GetNumberDevices MV_Usb2GetNumberDevices;
        /// <summary>
        /// 获得摄像头的产品型号。
        /// </summary>
        internal Usb2GetDeviceType MV_Usb2GetDeviceType;
        /// <summary>
        /// 此函数用于将RawData转换为RGB24数据格式放在指定内存中。在调用此函数之前，应对pDst分配内存（3×width×height字节），并且应先调用MV_Usb2GetRawData，得到RawData。
        /// </summary>
        internal Usb2ConvertRawToRgb MV_Usb2ConvertRawToRgb;
        /// <summary>
        /// 用于设置采集位数的选择。对于MVC5000F，A/D为12bit，可选择其中的8bit采集；对于MVC3000F和MVC1000MF，A/D为10bit，可选择高、中、低8bit进行采集。
        /// </summary>
        internal Usb2SetADCMode MV_SetUsb2ADCMode;

        internal Usb2GetFrameRate MV_Usb2GetFrameRate;
        internal MVCLibWrapper()
            : base((IntPtr.Size == 4) ? @"Driver\x86\MVCAPI.dll" : @"Driver\x64\MVCAPI.dll")
        {
            IntPtr procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2Init");
            this.MV_Usb2Init = (Usb2Init)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2Init));
            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2Uninit");
            this.MV_Usb2Uninit = (Usb2Uninit)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2Uninit));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2Stop");
            this.MV_Usb2Stop = (Usb2Stop)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2Stop));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2StartCapture");
            this.MV_Usb2StartCapture = (Usb2StartCapture)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2StartCapture));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2Start");
            this.MV_Usb2Start = (Usb2Start)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2Start));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2SetPartOfCapInfo");
            this.MV_Usb2SetPartOfCapInfo = (Usb2SetPartOfCapInfo)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2SetPartOfCapInfo));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2SetMirrorMode");
            this.MV_Usb2SetMirrorMode = (Usb2SetMirrorMode)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2SetMirrorMode));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2SaveFrameAsBmp");
            this.MV_Usb2SaveFrameAsBmp = (Usb2SaveFrameAsBmp)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2SaveFrameAsBmp));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2GetRgbData");
            this.MV_Usb2GetRgbData = (Usb2GetRgbData)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2GetRgbData));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2GetRawData");
            this.MV_Usb2GetRawData = (Usb2GetRawData)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2GetRawData));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2GetNumberDevices");
            this.MV_Usb2GetNumberDevices = (Usb2GetNumberDevices)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2GetNumberDevices));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2GetDeviceType");
            this.MV_Usb2GetDeviceType = (Usb2GetDeviceType)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2GetDeviceType));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2ConvertRawToRgb");
            this.MV_Usb2ConvertRawToRgb = (Usb2ConvertRawToRgb)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2ConvertRawToRgb));


            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2SetADCMode");
            this.MV_SetUsb2ADCMode = (Usb2SetADCMode)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2SetADCMode));

            procAddress = NativeMethods.GetProcAddress(base.mHandle, "MV_Usb2GetFrameRate");
            MV_Usb2GetFrameRate = (Usb2GetFrameRate)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Usb2GetFrameRate));

        }
        internal delegate Int32 Usb2Init(string pFilterName, out int index, ref CapInfoStruct pCapInfo, out IntPtr hImager);
        internal delegate Int32 Usb2Uninit(ref IntPtr hImager);
        internal delegate Int32 Usb2Start(IntPtr hImager, String tilte, uint style, int x, int y, int width, int height, IntPtr parent, uint nId, int ViewDataThreadPriority, int ViewDrawThreadPriority);
        internal delegate Int32 Usb2StartCapture(IntPtr hImager, bool bCapture);
        internal delegate Int32 Usb2ConvertRawToRgb(IntPtr hImager, IntPtr lpSrc, Int32 width, Int32 height, IntPtr pDest);
        internal delegate Int32 Usb2Stop(IntPtr hImager);
        internal delegate Int32 Usb2GetRgbData(IntPtr hImager, ref CapInfoStruct pCapInfo, IntPtr pDest);
        internal delegate Int32 Usb2SaveFrameAsBmp(IntPtr hImager, ref CapInfoStruct pCapInfo, IntPtr pDest, string FileName);
        internal delegate Int32 Usb2GetDeviceType(IntPtr hImager, ref DevType pSubNum);
        internal delegate Int32 Usb2GetNumberDevices(IntPtr hImager, ref ulong m_nDeviceNum);
        internal delegate Int32 Usb2SetPartOfCapInfo(IntPtr hImager, ref CapInfoStruct pCapInfo);
        internal delegate Int32 Usb2GetRawData(IntPtr hImager, ref CapInfoStruct pCapInfo);
        internal delegate Int32 Usb2SetMirrorMode(IntPtr hImage, byte nMode);
        internal delegate Int32 Usb2SetADCMode(IntPtr hImage, byte nMode);
        internal delegate Int32 Usb2SharpPreview(IntPtr hImage, bool nMode);
        internal delegate Int32 Usb2GetFrameRate(IntPtr hImage, out float nMode);
    }
#endregion
}
