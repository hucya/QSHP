using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Xml.Serialization;

namespace QSHP
{
    public delegate void CmdChangedEventHandler(CmdKey key, object obj);
    public delegate void ProgressSpdEventHandler(int cmd, float value);
    [Flags]
    public enum SyStatus:uint
    {
        LOAD=0x80000000,        //已经正确加载

        EMG = 0x800000,        //急停已按下
        INIT = 0x400000,       //已经初始化
        TESTHEIGHT = 0x200000, //已经测高
        ALIGNMENT= 0x100000,   //已经对准
        
        ALIGNADJ = 0x80000,    //已经对准线矫正
        CUTTING = 0x40000,     //当前在切割
        CUTPAUSE= 0x20000,     //当前在暂停
        CUTSTOP= 0x10000,      //切割完成

        SPDSTABLE=0x8000,       //划切主轴已经稳定
        TESTING = 0x4000,       //在测高中
        TESTCANCEL = 0x2000,    //测高取消
        HIGHCCD = 0x1000,       //高倍倍率

        MAINWATER = 0x80,    //主轴水正常
        MAINAIR= 0x40,       //气压充足
        TABAIR= 0x20,        //吸片已打开
        WORKARI= 0x10,       //吸台已打开
    }

    public enum SysFunState:byte
    {
        Mask = 0xFF, /*后八个字节预留 用作工作状态*/
        Emergency = 0xFE,//紧急停止
        IDIE = 0x00,//系统空闲
        Load = 0x01,//系统加载
        Crash = 0x02,//紧急停止操作
        SysInit = 0x03,//系统初始化
        Cutting = 0x04,//划切
        CutStop = 0x05,//划切完成
        CutPause = 0x06,//划切暂停
        TouchTesting = 0x07,//接触式测高
        Sharpening = 0x08,//磨刀
        AutoFocus = 0x0A,//自动对焦
        HomeAutoFocus = 0x0B,//回原点对焦
        KniefCheck = 0x0B,//刀破检测
        NoTouchTesting = 0x0C,//非接触式测高
    }
    
    [Flags]
    public enum SysCfg:uint
    {
        DEBUG = 0x80000000,         //调试模式
        AUTOINIT = 0x40000000,      //加载成功后是否自动初始化
        DCCD = 0x20000000,          //是否双镜头
        AUTOFOURCE = 0x10000000,     //是否支持自动对焦

        NOTOUCHHEIGHT = 0x8000000,  //是否支持非接触测高
        AUTOCUT = 0x4000000,        //是否支持自动划切
        BLDCHECK = 0x2000000,       //是否支持刀破检测
        ANALOG = 0x1000000,        //是否支持模拟输入

        AUTOLIGHT=0x800000,        //光源自动控制
        WATERAIRCLEAR=0x400000,    //水帘气帘
        DWATERSENER = 0x200000,    //双切割水
        MAJORIO=0x100000,          //32 IO

        
        NETCTR = 0x80000,            //网络控制
        SVNBACKUP =0x40000,          //SVN备份
        SPEECH=0x20000,              //语音播报
    }

    [XmlType("LedCmd", Namespace = "")]
    [StructLayout(LayoutKind.Explicit, Size = 4, CharSet = CharSet.Ansi), SecuritySafeCritical]
    public class LedCmd
    {
        [DefaultValue(0)]
        [FieldOffset(0)]
        private byte buzzer;
        [FieldOffset(1)]
        private byte green;
        [FieldOffset(2)]
        private byte yellow;
        [FieldOffset(3)]
        private byte red;
        [FieldOffset(0)]
        private UInt32 cmd;
        [XmlIgnore]
        public byte Buzzer
        {
            get
            {
                return buzzer;
            }

            set
            {
                buzzer = value;
            }
        }
        [XmlIgnore]
        public byte Green
        {
            get
            {
                return green;
            }

            set
            {
                green = value;
            }
        }
        [XmlIgnore]
        public byte Yellow
        {
            get
            {
                return yellow;
            }

            set
            {
                yellow = value;
            }
        }
        [XmlIgnore]
        public byte Red
        {
            get
            {
                return red;
            }

            set
            {
                red = value;
            }
        }

        public uint Cmd
        {
            get
            {
                return cmd;
            }

            set
            {
                cmd = value;
            }
        }

        public LedCmd()
        {
        }

        public LedCmd(UInt32 value)
        {
            cmd = value;
        }
        public unsafe byte this[int i]
        {
            get
            {
                byte v = 0;
                fixed (byte* ptr = &buzzer)
                {
                    v = *(ptr + i);
                }
                return v;
            }
            set
            {
                fixed (byte* ptr = &buzzer)
                {
                    *(ptr + i) = value;
                }
            }
        }
    }
}
