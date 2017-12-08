using System.Windows.Forms;
using System.IO;
using System.Drawing;
using QSHP.Data;
using System.Collections.Generic;
using QSHP.Com;
using System.Speech.Synthesis;

namespace QSHP
{
    public static partial class Globals
    {
        static PointF axisPoint = new PointF(0, 0);
        static SyStatus sysStatus= SyStatus.HIGHCCD;
        static SysCfg sysCfg = SysCfg.AUTOINIT;
        static SysFunState sysFunState = SysFunState.IDIE;
        static LedCmd ledCmd = new LedCmd(0);
        static BldData bldData = new BldData();
        static TabData tabData = new TabData();
        static AppConfig appCfg = new AppConfig();
        static DevData devData = new DevData();
        static MacData macData=new MacData();
        
        static SpeechSynthesizer speech = new SpeechSynthesizer();
        private static Dictionary<CmdKey, CmdValue> sysCmd = new Dictionary<CmdKey, CmdValue>();
        public static PointF TabCenter = new PointF(140.908F, 203.817F);//工作台中心点
        public static PointF ViewCenter = new PointF(259.147F, 202.148F);
        static int userLeave = 0;
        static bool preCut = false;
        public static float KniefAdj
        {
            get
            {
                return ViewCenter.Y - TabCenter.Y;
            }
            set
            {
                if (HighCCD)
                {
                    if (bldData != null)
                    {
                        bldData.SetCurrentOffsetValue(value, value - devData.CenterOffset, AppCfg.BladeFileFullName);
                    }
                    TabCenter.Y = ViewCenter.Y - value;//需要保存当前的工作台中心
                    if (DevData != null)
                    {
                        float a = devData.CenterOffset;
                        DevData.HighCenterY = TabCenter.Y;
                        DevData.LowCenterY = devData.HighCenterY - a;
                    }
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.P0128);//低倍显微镜下不支持当前操作
                }
            }
        }

        public static PointF AxisPoint
        {
            get
            {
                if (Common.X_Axis != null && Common.Y_Axis != null)
                {
                    axisPoint.X = Common.X_Axis.RealPos;
                    axisPoint.Y = Common.Y_Axis.RealPos;
                }
                return axisPoint;
            }
        }

        public static bool EMG
        {
            get
            {
                return (sysStatus & SyStatus.EMG) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.EMG;
                }
                else
                {
                    sysStatus &= (~SyStatus.EMG);
                }
            }
        }
        
        public static bool SpdStable
        {
            get
            {
                return (sysStatus & SyStatus.SPDSTABLE) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.SPDSTABLE;
                }
                else
                {
                    sysStatus &= (~SyStatus.SPDSTABLE);
                }
            }
        }

        public static bool Cutting
        {
            get
            {
                return (sysStatus & SyStatus.CUTTING) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.CUTTING;
                }
                else
                {
                    sysStatus &= (~SyStatus.CUTTING);
                }
            }
        }

        public static bool Testing
        {
            get
            {
                return (sysStatus & SyStatus.TESTING) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.TESTING;
                }
                else
                {
                    sysStatus &= (~SyStatus.TESTING);
                }
            }
        }

        public static bool Paused
        {
            get
            {
                return (sysStatus & SyStatus.CUTPAUSE) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.CUTPAUSE;
                }
                else
                {
                    sysStatus &= (~SyStatus.CUTPAUSE);
                }
            }
        }

        public static bool TestCancel
        {
            get
            {
                return (sysStatus & SyStatus.TESTCANCEL) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.TESTCANCEL;
                }
                else
                {
                    sysStatus &= (~SyStatus.TESTCANCEL);
                }
            }
        }
        public static bool CutStop
        {
            get
            {
                return (sysStatus & SyStatus.CUTSTOP) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.CUTSTOP;
                }
                else
                {
                    sysStatus &= (~SyStatus.CUTSTOP);
                }
            }
        }

        public static bool IsInit
        {
            get
            {
                return (sysStatus & SyStatus.INIT) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.INIT;
                }
                else
                {
                    sysStatus &= (~SyStatus.INIT);
                }
            }
        }
         
        public static bool Load
        {
            get
            {
                return (sysStatus & SyStatus.LOAD) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.LOAD;
                }
                else
                {
                    sysStatus &= (~SyStatus.LOAD);
                }
            }
        }
        public static bool TestedHeight
        {
            get
            {
                return (sysStatus & SyStatus.TESTHEIGHT) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.TESTHEIGHT;
                }
                else
                {
                    sysStatus &= (~SyStatus.TESTHEIGHT);
                }
            }
        }

        public static bool HighCCD
        {
            get
            {
                return (sysStatus & SyStatus.HIGHCCD) > 0;
            }
            set
            {
                if (value)
                {
                    sysStatus |= SyStatus.HIGHCCD;
                }
                else
                {
                    sysStatus &= (~SyStatus.HIGHCCD);
                }
            }
        }

        public static SysFunState AppFunState
        {
            get
            {
                return sysFunState;
            }
            set
            {
                sysFunState = value;
            }
        }

        public static bool IDIE
        {
            get
            {
                return  Globals.AppFunState == SysFunState.IDIE | Globals.AppFunState == SysFunState.CutPause;
            }
        }

        public static BldData BldData
        {
            get
            {
                return bldData;
            }

            set
            {
                bldData = value;

            }
        }
        public static AppConfig AppCfg
        {
            get
            {
                return appCfg;
            }
            set
            {
                appCfg = value;
            }
        }
        public static float TestHeightValue
        {
            get
            {
                if (BldData != null)
                {
                    return BldData.TestHeightValue;
                }
                else
                {
                    return 25f;
                }
            }

            set
            {
                if (BldData != null)
                {
                    BldData.SetCurrentTestValue(value, AppCfg.BladeFileFullName);
                }
            }
        }
        public static TabData TabData
        {
            get
            {
                return tabData;
            }
            set
            {
                tabData = value;
            }
        }

        public static MacData MacData
        {
            get
            {
                return macData;
            }

            set
            {
                macData = value;
                macData.InitMacDataToHardWare();
            }
        }

        public static Dictionary<CmdKey, CmdValue> SysCmd
        {
            get
            {
                return sysCmd;
            }

            set
            {
                sysCmd = value;
            }
        }

        public static SysCfg SysCfg
        {
            get
            {
                return sysCfg;
            }

            set
            {
                sysCfg = value;
            }
        }

        public static DevData DevData
        {
            get
            {
                return devData;
            }

            set
            {
                devData = value;
                devData.InitMacDataToHardWare();
            }
        }

        public static int UserLeave
        {
            get
            {
                return userLeave;
            }

            set
            {
                userLeave = value;
            }
        }


        public static LedCmd LedCmd
        {
            get
            {
                return ledCmd;
            }

            set
            {
                ledCmd = value;
            }
        }

        public static SpeechSynthesizer Speech
        {
            get
            {
                return speech;
            }

            set
            {
                speech = value;
            }
        }

        public static bool PreCut
        {
            get
            {
                return preCut;
            }

            set
            {
                preCut = value;
            }
        }
    }
}
