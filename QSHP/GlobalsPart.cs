using QSHP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSHP
{
    public static partial class Globals
    {
        static CutGroup group = new CutGroup();
        static CutChannel channel;
        static CutSegment segment;
        static CutLine line;
        public static CutLine Line
        {
            get { return Globals.line; }
            set { Globals.line = value; }
        }

        public static CutGroup Group
        {
            get
            {
                return group;
            }

            set
            {
                group = value;
                group.InitCutRunData(false);//初始化结构体
                if (Common.X_Axis != null)
                {
                    Common.X_Axis.Param.StepPos = group.CH2.IndexStep;
                }
                if (Common.Y_Axis != null)
                {
                    Common.Y_Axis.Param.StepPos = group.CH1.IndexStep;
                }
            }
        }


        public static CutChannel Channel
        {
            get
            {
                return channel;
            }

            set
            {
                channel = value;
            }
        }

        public static CutSegment Segment
        {
            get
            {
                return segment;
            }

            set
            {
                segment = value;
            }
        }

        public static bool SVNCTR
        {

            get
            {
                return (SysCfg & SysCfg.SVNBACKUP) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.SVNBACKUP;
                }
                else
                {
                    SysCfg &= (~SysCfg.SVNBACKUP);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool ApplySpeech
        {

            get
            {
                return (SysCfg & SysCfg.SPEECH) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.SPEECH;
                }
                else
                {
                    SysCfg &= (~SysCfg.SPEECH);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool DoubleCap
        {

            get
            {
                return (SysCfg & SysCfg.DCCD) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.DCCD;
                }
                else
                {
                    SysCfg &= (~SysCfg.DCCD);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool AutoFource
        {

            get
            {
                return (SysCfg & SysCfg.AUTOFOURCE) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.AUTOFOURCE;
                }
                else
                {
                    SysCfg &= (~SysCfg.AUTOFOURCE);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool AutoCut
        {
            get
            {
                return (SysCfg & SysCfg.AUTOCUT) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.AUTOCUT;
                }
                else
                {
                    SysCfg &= (~SysCfg.AUTOCUT);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool BladeCheck
        {
            get
            {
                return (SysCfg & SysCfg.BLDCHECK) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.BLDCHECK;
                }
                else
                {
                    SysCfg &= (~SysCfg.BLDCHECK);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool NoTouchTest
        {
            get
            {
                return (SysCfg & SysCfg.NOTOUCHHEIGHT) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.NOTOUCHHEIGHT;
                }
                else
                {
                    SysCfg &= (~SysCfg.NOTOUCHHEIGHT);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool AutoInit
        {
            get
            {
                return (SysCfg & SysCfg.AUTOINIT) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.AUTOINIT;
                }
                else
                {
                    SysCfg &= (~SysCfg.AUTOINIT);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool ApplayAI
        {
            get
            {
                return (SysCfg & SysCfg.ANALOG) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.ANALOG;
                }
                else
                {
                    SysCfg &= (~SysCfg.ANALOG);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool AutoLight
        {
            get
            {
                return (SysCfg & SysCfg.AUTOLIGHT) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.AUTOLIGHT;
                }
                else
                {
                    SysCfg &= (~SysCfg.AUTOLIGHT);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool WaterAirClear
        {
            get
            {
                return (SysCfg & SysCfg.WATERAIRCLEAR) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.WATERAIRCLEAR;
                }
                else
                {
                    SysCfg &= (~SysCfg.WATERAIRCLEAR);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool DoubleWaterSenser
        {
            get
            {
                return (SysCfg & SysCfg.DWATERSENER) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.DWATERSENER;
                }
                else
                {
                    SysCfg &= (~SysCfg.DWATERSENER);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }

        public static bool NetControl
        {
            get
            {
                return (SysCfg & SysCfg.NETCTR) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.NETCTR;
                }
                else
                {
                    SysCfg &= (~SysCfg.NETCTR);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool MajorIO
        {
            get
            {
                return (SysCfg & SysCfg.MAJORIO) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.MAJORIO;
                }
                else
                {
                    SysCfg &= (~SysCfg.MAJORIO);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }
        public static bool DebugMode
        {
            get
            {
                return (SysCfg & SysCfg.DEBUG) > 0;
            }
            set
            {
                if (value)
                {
                    SysCfg |= SysCfg.DEBUG;
                }
                else
                {
                    SysCfg &= (~SysCfg.DEBUG);
                }
                if (appCfg != null)
                {
                    appCfg.SysConfig = SysCfg;
                }
            }
        }


    }
}
