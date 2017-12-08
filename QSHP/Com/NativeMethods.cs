using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Globalization;

namespace QSHP.Com
{
    [Flags]
    public enum WindowStyle
    {
        Overlapped = 0x00000000,
        Popup = unchecked((int)0x80000000), // enum can't be uint for VB
        Child = 0x40000000,
        Minimize = 0x20000000,
        Visible = 0x10000000,
        Disabled = 0x08000000,
        ClipSiblings = 0x04000000,
        ClipChildren = 0x02000000,
        Maximize = 0x01000000,
        Caption = 0x00C00000,
        Border = 0x00800000,
        DlgFrame = 0x00400000,
        VScroll = 0x00200000,
        HScroll = 0x00100000,
        SysMenu = 0x00080000,
        ThickFrame = 0x00040000,
        Group = 0x00020000,
        TabStop = 0x00010000,
        MinimizeBox = 0x00020000,
        MaximizeBox = 0x00010000
    }
    [Flags]
    public enum WindowStyleEx
    {
        DlgModalFrame = 0x00000001,
        NoParentNotify = 0x00000004,
        Topmost = 0x00000008,
        AcceptFiles = 0x00000010,
        Transparent = 0x00000020,
        MDIChild = 0x00000040,
        ToolWindow = 0x00000080,
        WindowEdge = 0x00000100,
        ClientEdge = 0x00000200,
        ContextHelp = 0x00000400,
        Right = 0x00001000,
        Left = 0x00000000,
        RTLReading = 0x00002000,
        LTRReading = 0x00000000,
        LeftScrollBar = 0x00004000,
        RightScrollBar = 0x00000000,
        ControlParent = 0x00010000,
        StaticEdge = 0x00020000,
        APPWindow = 0x00040000,
        Layered = 0x00080000,
        NoInheritLayout = 0x00100000,
        LayoutRTL = 0x00400000,
        Composited = 0x02000000,
        NoActivate = 0x08000000
    }
    public enum WindowState
    {
        Hide = 0,
        Normal,
        ShowMinimized,
        ShowMaximized,
        ShowNoActivate,
        Show,
        Minimize,
        ShowMinNoActive,
        ShowNA,
        Restore,
        ShowDefault,
        ForceMinimize
    }
    public static class NativeMethods
    {

        /*
        * Window Style
        */

        public const int WM_SYSCOMMAND = 0x0112;//系统菜单
        public const int SC_SCREENSAVE = 0xF140;//屏幕保护
        public const int WM_QUERYENDSESSION = 0x0011;//关闭操作系统
        public const int WM_DEVICECHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CONFIGCHANGED = 0x0018;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        public const int DBT_DEVNODES_CHANGED = 0x0007;
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;


        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        public const int WS_OVERLAPPED = 0x00000000;
        public const uint WS_POPUP = 0x80000000;
        public const int WS_CHILD = 0x40000000;
        public const int WS_MINIMIZE = 0x20000000;
        public const int WS_VISIBLE = 0x10000000;
        public const int WS_DISABLED = 0x08000000;
        public const int WS_CLIPSIBLINGS = 0x04000000;
        public const int WS_CLIPCHILDREN = 0x02000000;
        public const int WS_MAXIMIZE = 0x01000000;
        public const int WS_CAPTION = 0x00C00000;
        public const int WS_BORDER = 0x00800000;
        public const int WS_DLGFRAME = 0x00400000;
        public const int WS_VSCROLL = 0x00200000;
        public const int WS_HSCROLL = 0x00100000;
        public const int WS_SYSMENU = 0x00080000;
        public const int WS_THICKFRAME = 0x00040000;
        public const int WS_GROUP = 0x00020000;
        public const int WS_TABSTOP = 0x00010000;

        public const int WS_MINIMIZEBOX = 0x00020000;
        public const int WS_MAXIMIZEBOX = 0x00010000;

        /*
        * Extended Window StyLes
        */
        public const int WS_EX_DLGMODALFRAME = 0x00000001;
        public const int WS_EX_NOPARENTNOTIFY = 0x00000004;
        public const int WS_EX_TOPMOST = 0x00000008;
        public const int WS_EX_ACCEPTFILES = 0x00000010;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int WS_EX_MDICHILD = 0x00000040;
        public const int WS_EX_TOOLWINDOW = 0x00000080;
        public const int WS_EX_WINDOWEDGE = 0x00000100;
        public const int WS_EX_CLIENTEDGE = 0x00000200;
        public const int WS_EX_CONTEXTHELP = 0x00000400;

        public const int WS_EX_RIGHT = 0x00001000;
        public const int WS_EX_LEFT = 0x00000000;
        public const int WS_EX_RTLREADING = 0x00002000;
        public const int WS_EX_LTRREADING = 0x00000000;
        public const int WS_EX_LEFTSCROLLBAR = 0x00004000;
        public const int WS_EX_RIGHTSCROLLBAR = 0x00000000;

        public const int WS_EX_CONTROLPARENT = 0x00010000;
        public const int WS_EX_STATICEDGE = 0x00020000;
        public const int WS_EX_APPWINDOW = 0x00040000;


        //public const int DropShadow = 0x20000;
        //public const int GCL_STYLE = (-26);

        //public const int NM_CUSTOMDRAW = -12;
        //public const int NM_FIRST = 0;
        //public const int S_OK = 0;
        //public const int TMT_COLOR = 0xcc;

        //[DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int CloseThemeData(IntPtr hTheme);
        //[DllImport("Comctl32.dll", EntryPoint = "DllGetVersion", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int CommonControlsGetVersion(ref DLLVERSIONINFO pdvi);
        //[DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pRect, ref RECT pClipRect);
        //[DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int GetThemeColor(IntPtr hTheme, int iPartId, int iStateId, int iPropId, ref int pColor);
        //[return: MarshalAs(UnmanagedType.Bool)]
        //[DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool IsAppThemed();
        //[DllImport("UxTheme.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        // public static extern IntPtr OpenThemeData(IntPtr hwnd, string pszClassList);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern IntPtr GetForegroundWindow();
        [DllImport("kernel32.dll")]
        internal static extern bool FreeLibrary(IntPtr module);
        [DllImport("kernel32.dll")]
        internal static extern uint GetModuleFileName(IntPtr module, StringBuilder filename, uint size);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetProcAddress(IntPtr module, string name);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetProcAddress(IntPtr module, uint ordinal);
        [DllImport("kernel32.dll")]
        internal static extern IntPtr LoadLibrary(string filename);
        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory")]
        public static extern void CopyMemory(IntPtr Destination, IntPtr Source, [MarshalAs(UnmanagedType.U4)] int Length);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hwnd, int msg, int wparam, int lparam);
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keyboardEvent(byte bVk, byte bScan, short dwFlags, int ptr);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rectangle lpRect);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        [DllImportAttribute("user32.dll")]
        public static extern int FindWindow(string ClassName, string WindowName);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(int handle, int cmdShow);
        [DllImport("user32.dll")]
        public static extern int GetDesktopWindow();
        public enum CustomDrawDrawStage
        {
            CDDS_ITEM = 0x10000,
            CDDS_ITEMPOSTERASE = 0x10004,
            CDDS_ITEMPOSTPAINT = 0x10002,
            CDDS_ITEMPREERASE = 0x10003,
            CDDS_ITEMPREPAINT = 0x10001,
            CDDS_POSTERASE = 4,
            CDDS_POSTPAINT = 2,
            CDDS_PREERASE = 3,
            CDDS_PREPAINT = 1,
            CDDS_SUBITEM = 0x20000
        }

        public enum CustomDrawItemState
        {
            CDIS_CHECKED = 8,
            CDIS_DEFAULT = 0x20,
            CDIS_DISABLED = 4,
            CDIS_FOCUS = 0x10,
            CDIS_GRAYED = 2,
            CDIS_HOT = 0x40,
            CDIS_INDETERMINATE = 0x100,
            CDIS_MARKED = 0x80,
            CDIS_SELECTED = 1,
            CDIS_SHOWKEYBOARDCUES = 0x200
        }

        public enum CustomDrawReturnFlags
        {
            CDRF_DODEFAULT = 0,
            CDRF_NEWFONT = 2,
            CDRF_NOTIFYITEMDRAW = 0x20,
            CDRF_NOTIFYPOSTERASE = 0x40,
            CDRF_NOTIFYPOSTPAINT = 0x10,
            CDRF_NOTIFYSUBITEMDRAW = 0x20,
            CDRF_SKIPDEFAULT = 4
        }

        public enum TrackBarCustomDrawPart
        {
            TBCD_CHANNEL = 3,
            TBCD_THUMB = 2,
            TBCD_TICS = 1
        }

        public enum TrackBarParts
        {
            TKP_THUMB = 3,
            TKP_THUMBBOTTOM = 4,
            TKP_THUMBLEFT = 7,
            TKP_THUMBRIGHT = 8,
            TKP_THUMBTOP = 5,
            TKP_THUMBVERT = 6,
            TKP_TICS = 9,
            TKP_TICSVERT = 10,
            TKP_TRACK = 1,
            TKP_TRACKVERT = 2
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DLLVERSIONINFO
        {
            public int cbSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformID;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMCUSTOMDRAW
        {
            public NativeMethods.NMHDR hdr;
            public NativeMethods.CustomDrawDrawStage dwDrawStage;
            public IntPtr hdc;
            public NativeMethods.RECT rc;
            public IntPtr dwItemSpec;
            public NativeMethods.CustomDrawItemState uItemState;
            public IntPtr lItemlParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR
        {
            public IntPtr HWND;
            public IntPtr idFrom;
            public int code;
            public override string ToString()
            {
                return string.Format(CultureInfo.InvariantCulture, "Hwnd: {0}, ControlID: {1}, Code: {2}", new object[] { this.HWND, this.idFrom, this.code });
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public RECT(Rectangle rect)
            {
                this = new NativeMethods.RECT();
                this.Left = rect.Left;
                this.Top = rect.Top;
                this.Right = rect.Right;
                this.Bottom = rect.Bottom;
            }

            public override string ToString()
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}, {1}, {2}, {3}", new object[] { this.Left, this.Top, this.Right, this.Bottom });
            }

            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(this.Left, this.Top, this.Right, this.Bottom);
            }
        }


    }
}
