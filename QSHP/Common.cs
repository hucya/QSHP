using System;
using QSHP.HW.AmpC;
using QSHP.HW.Spindle;
using QSHP.HW.Video;
using QSHP.HW.IO;
using QSHP.HW;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using QSHP.Data;
using System.IO;
using System.Text.RegularExpressions;
using QSHP.Com;
using System.Text;
using System.Linq;

namespace QSHP
{
    public static partial class Common
    {
        public static event CmdChangedEventHandler ProgressCmdKeyChanged;
        public static event ProgressChangedEventHandler ProgressWorkingChanged;
        public static event ProgressSpdEventHandler ProgressSpdEventChanged;

        #region 字段属性
        static object locker = new object();
        static HardwareProvider hwProvider = new HardwareProvider();

        static IAmpCProvider x_Axis = null;

        static IAmpCProvider y_Axis = null;

        static IAmpCProvider z_Axis = null;

        static IAmpCProvider t_Axis = null;

        static IVideoProvider capture = null;

        static IVideoProvider captureL = null;

        static ISpindleProvider sPD = null;

        static DigProvider digInput = null;

        static DigProvider digoutput = null;

        static bool doubleCap = false;

        static BackgroundWorker backWorker;


        public static IAmpCProvider X_Axis
        {
            get
            {
                return x_Axis;
            }
            set
            {
                x_Axis = value;
            }
        }

        public static IAmpCProvider Y_Axis
        {
            get
            {
                return y_Axis;
            }
            set
            {
                y_Axis = value;
            }
        }

        public static IAmpCProvider Z_Axis
        {
            get
            {
                return z_Axis;
            }
            set
            {
                z_Axis = value;
            }
        }

        public static IAmpCProvider T_Axis
        {
            get
            {
                return t_Axis;
            }
            set
            {
                t_Axis = value;
            }
        }

        public static IVideoProvider Capture
        {
            get
            {
                return capture;
            }
            set
            {
                capture = value;
            }
        }

        public static IVideoProvider CaptureL
        {
            get
            {
                if (doubleCap)
                {
                    return captureL;
                }
                else
                {
                    return capture;
                }
            }
            set
            {
                if (doubleCap)
                {
                    captureL = value;
                }
            }
        }

        public static ISpindleProvider SPD
        {
            get
            {
                return sPD;
            }
            set
            {
                sPD = value;
            }
        }

        public static DigProvider DI
        {
            get
            {
                return digInput;
            }
            set
            {
                digInput = value;
            }
        }

        public static DigProvider DO
        {
            get
            {
                return digoutput;
            }
            set
            {
                digoutput = value;
            }
        }

        public static bool DoubleCap
        {
            get
            {
                return doubleCap;
            }
            set
            {
                doubleCap = value;
                Globals.DoubleCap = value;
            }
        }
        public static HardwareProvider HwProvider
        {
            get { return hwProvider; }
            set { hwProvider = value; }
        }
        #endregion

        #region 静态操作
        static Common()
        {
            backWorker = new BackgroundWorker();
            backWorker.WorkerSupportsCancellation = true;
            backWorker.WorkerReportsProgress = true;
            backWorker.DoWork += BackWorker_DoWork;
            backWorker.ProgressChanged += BackWorker_ProgressChanged;
        }

        private static void BackWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ProgressWorkingChanged != null)
            {
                ProgressWorkingChanged(e.ProgressPercentage, e);
            }
        }

        private static void BackWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Globals.EMG)//如果触发紧急停止
            {
                Globals.AppFunState = SysFunState.Emergency;//进行紧急操作
            }
            RunSynProgram();//执行任务
        }

        static bool InitAxisSystemParam()
        {
            bool flag = true;
            foreach (var item in hwProvider.HwLib.Values)
            {
                IAmpCProvider provider = item as IAmpCProvider;
                if (provider != null)
                {
                    flag &= provider.InitSystemParam();
                }
            }
            Globals.AppFunState = SysFunState.IDIE;
            return flag;
        }

        private static void RunSynProgram()
        {
            try
            {
                do
                {
                    switch (Globals.AppFunState)
                    {
                        case SysFunState.Load:
                            {
                                Globals.Load = SystemLoad();
                                if (Globals.Load)
                                {
                                    if (Globals.AutoInit)
                                    {
                                        Globals.AppFunState = SysFunState.SysInit;//判断是否直接进行系统初始化操作
                                    }
                                    else
                                    {
                                        Globals.AppFunState = SysFunState.IDIE;//空闲操作
                                    }
                                }
                                else
                                {
                                    Globals.AppFunState = SysFunState.IDIE;//空闲操作
                                }
                            }
                            break;
                        case SysFunState.SysInit://系统初始化
                            {
                                Globals.IsInit = SystemInit();
                                Globals.AppFunState = SysFunState.IDIE;//空闲操作
                            }
                            break;
                        case SysFunState.TouchTesting://测高
                            {
                                if (Globals.IsInit)
                                {
                                    ReportWorkingProgress(ProcessCmd.CsTestingStartCmd);
                                    if (TouchTestingHeight())
                                    {
                                        ReportWorkingProgress(ProcessCmd.CsTestingEndCmd);
                                    }
                                    else
                                    {
                                        ReportWorkingProgress(ProcessCmd.CsTestingErrCmd);
                                    }
                                    Globals.Testing = false;
                                    Z_Axis.AxisGoHomeWork(true);//恢复系统默认回零模式
                                    X_Axis.AxisJogAbsWork(X_Axis.Param.StartPos);
                                    Y_Axis.AxisJogAbsWork(Y_Axis.Param.StartPos);
                                    WaitAxisMoveDone();

                                }
                                else
                                {
                                    ReportCmdKeyProgress(CmdKey.H0000);
                                }
                                Globals.AppFunState = SysFunState.IDIE;//空闲操作
                                Globals.LedCmd.Cmd = Globals.DevData.IdleLedCmd.Cmd;
                            }
                            break;
                        case SysFunState.NoTouchTesting://测高
                            {
                                if (Globals.Paused)//如果当前在暂停中进行非接触式测高
                                {
                                    Globals.AppFunState = SysFunState.Cutting;
                                    Globals.Paused = false;
                                }
                                else
                                {
                                    Globals.AppFunState = SysFunState.IDIE;//空闲操作
                                }
                            }
                            break;
                        case SysFunState.Cutting:
                            {
                                if (Globals.Load && Globals.IsInit)
                                {
                                    Globals.CutStop = false;
                                    if (Globals.Cutting)
                                    {
                                        ReportCmdKeyProgress(CmdKey.P0101);
                                        ReportWorkingProgress(ProcessCmd.CutContinuesCmd);
                                    }
                                    else
                                    {
                                        ReportCmdKeyProgress(CmdKey.P0100);
                                        ReportWorkingProgress(ProcessCmd.CutStartCmd);
                                    }
                                    Globals.Cutting = true;
                                    if (RunGroupCut(Globals.Group))
                                    {
                                        Globals.AppFunState = SysFunState.CutStop;//空闲操作
                                    }
                                    else
                                    {
                                        if (Globals.CutStop)//停止划切
                                        {
                                            Globals.AppFunState = SysFunState.CutStop;
                                            break;
                                        }
                                        if (Globals.Line.Pause)//暂停
                                        {
                                            Globals.Paused = true;
                                            Globals.AppFunState = SysFunState.CutPause;
                                            Globals.LedCmd.Cmd = Globals.DevData.PauseLedCmd.Cmd;
                                            if (Globals.DevData.CutPauseCloseWater)//关闭切割水
                                            {
                                                Common.DO[DoDefine.CUT_WATER] = false;
                                            }
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Common.ReportCmdKeyProgress(CmdKey.S0090);
                                    Globals.AppFunState = SysFunState.CutStop;//空闲操作
                                }
                            }
                            break;
                        case SysFunState.Emergency://紧急停止
                            {
                                //if (Globals.Cutting)
                                //{
                                //    ReportWorkingProgress(ProcessCmd.CutSopCmd);//划切终止
                                //}
                                if (EmergencyStop())
                                {
                                    Globals.AppFunState = SysFunState.IDIE;//空闲操作
                                }
                                else
                                {
                                    ReportCmdKeyProgress(CmdKey.S0097);
                                    Globals.AppFunState = SysFunState.IDIE;//空闲操作
                                }
                            }
                            break;
                        case SysFunState.CutStop:
                            {
                                ReportWorkingProgress(ProcessCmd.CutSopCmd);
                                Globals.Group.AddBladeCutedPieces();//添加已划切片数
                                Globals.Group.ClearAllChannelInfo();//清除对准信息
                                Globals.Cutting = false;
                                Globals.Paused = false;
                                Globals.CutStop = false;
                                Globals.LedCmd.Cmd = Globals.DevData.StopLedCmd.Cmd;
                                if (Globals.DevData.CutStopCloseWater)//关闭切割水
                                {
                                    Common.DO[DoDefine.CUT_WATER] = false;
                                }
                                if (Globals.DevData.CutStopUnloadVacuum)//打开真空开关
                                {
                                    Common.DO[DoDefine.WORK_AIR] = false;
                                }
                                if (Globals.DevData.BuzzerUsed)//打开蜂鸣器
                                {
                                    DO[DoDefine.BUZZER] = true;
                                }
                                if (Globals.Group.Complate)//正常切割完成
                                {
                                    Globals.BldData.SaveBladeDataFile(Globals.AppCfg.BladeFileFullName);//保存当前文档
                                    ReportCmdKeyProgress(CmdKey.P0103);
                                }
                                else
                                {
                                    ReportCmdKeyProgress(CmdKey.P0104);
                                }
                                Globals.AppFunState = SysFunState.IDIE;//空闲操作
                            }
                            break;
                        case SysFunState.AutoFocus:
                            {
                                if (Globals.Load && Globals.IsInit)
                                {
                                    AutoFocus(Capture, 40, 32);
                                }
                                Globals.AppFunState = SysFunState.IDIE;//空闲操作
                            }
                            break;
                        case SysFunState.HomeAutoFocus:
                            {
                                if (Globals.Load && Globals.IsInit)
                                {
                                    Z_Axis.AxisGoHomeWork(true);
                                    AutoFocus(Capture, 40, 32);
                                }
                                Globals.AppFunState = SysFunState.IDIE;//空闲操作
                            }
                            break;
                        case SysFunState.CutPause:
                            {
                                //崩边检测
                                //继续划切
                                //if()  退出划切
                                if (Globals.CutStop)
                                {
                                    Globals.AppFunState = SysFunState.CutStop;//空闲操作
                                }
                                else
                                {
                                    if (!Globals.Paused)    //暂停取消
                                    {
                                        Globals.AppFunState = SysFunState.Cutting;  //继续划切
                                    }
                                }
                            }
                            break;
                        default:// SyStatus.IDIE: 其他操作
                            {
                                //操作
                            }
                            break;
                    }
                    if (Globals.EMG)//如果需要紧急停止
                    {
                        Globals.AppFunState = SysFunState.Emergency;//空闲操作
                    }
                    else
                    {
                        if (Globals.Load)
                        {
                            SystemCheckStatus();
                        }
                    }
                    Thread.Sleep(100);
                } while (!backWorker.CancellationPending);
            }
            catch (Exception ex)
            {
                LogHelper.WriteDebugException(ex);
                if (Globals.Load)
                {
                    Globals.EMG = true;
                    Globals.AppFunState = SysFunState.Emergency;
                    backWorker.RunWorkerAsync();
                }
            }
        }

        public static bool LoadSysConfigFile()
        {
            if (AppConfig.SysConfigFileIsExists())
            {
                bool flag = true;
                Globals.AppCfg = AppConfig.LoadDefaultSysConfigFile();
                Globals.SysCfg = Globals.AppCfg.SysConfig;
                string path = Globals.AppCfg.CmdFullName;
                if (File.Exists(path))
                {
                    string s = File.ReadAllText(path, System.Text.Encoding.Default);
                    Regex regex = new Regex(@"(\S+\d{3})\t([^\t]*)\t([^\t]*)\t+(.*)");
                    try
                    {
                        CmdKey k = CmdKey.None;
                        CmdLeave lv = CmdLeave.Info;
                        int lau = Globals.AppCfg.Language;
                        if (lau > 2)
                        {
                            lau = 0;
                        }
                        Globals.SysCmd.Clear();
                        foreach (Match item in regex.Matches(s))
                        {
                            if (Enum.TryParse(item.Groups[1].Value, out k))
                            {
                                if (!Globals.SysCmd.ContainsKey(k))
                                {
                                    CmdValue value = new CmdValue();
                                    value.Key = k;
                                    if (Enum.TryParse(item.Groups[2].Value, out lv))
                                    {
                                        value.Leave = lv;
                                    }
                                    value.Description = item.Groups[3 + lau].Value;
                                    Globals.SysCmd.Add(k, value);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "文件加载异常");
                    }
                }
                return flag;
            }
            else
            {
                return false;
            }
        }

        public static bool SetSystemWorkMode(SysFunState status)
        {
            if (!backWorker.IsBusy)//如果当前线程没有工作
            {
                Globals.AppFunState = status;
                backWorker.RunWorkerAsync();//打开线程
                return true;
            }
            else
            {
                if (Globals.AppFunState == SysFunState.IDIE)//判断当前处于空闲状态
                {
                    Globals.AppFunState = status;//重新设置其他模式
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void ReportCmdKeyProgress(CmdKey key, params object[] obj)
        {

            if (ProgressCmdKeyChanged != null)
            {
                ProgressCmdKeyChanged(key, obj);
            }
        }

        public static void ReportWorkingProgress(int cmd, object obj = null)
        {
            if (backWorker.IsBusy)
            {
                backWorker.ReportProgress(cmd, obj);
            }
        }
        #endregion

        #region 系统功能
        public static bool SystemInit()
        {
            try
            {
                if (SystemInitCheckStatus())
                {
                    bool flag = true;
                    ReportCmdKeyProgress(CmdKey.S0100);//开始系统初始化
                    if (!InitAxisSystemParam())//重新进行系统初始化
                    {
                        flag = false;
                        ReportCmdKeyProgress(CmdKey.S0013);
                    }
                    else
                    {
                        ReportCmdKeyProgress(CmdKey.S0012);
                    }
                    Globals.LedCmd.Cmd = Globals.DevData.InitLedCmd.Cmd;
                    X_Axis.AxisAotoEscapeLimit();
                    Y_Axis.AxisAotoEscapeLimit();
                    Z_Axis.AxisAotoEscapeLimit();
                    T_Axis.AxisAotoEscapeLimit();
                    if (Z_Axis.AxisGoHomeWork(true))
                    {
                        ReportCmdKeyProgress(CmdKey.S0407);
                    }
                    else
                    {
                        ReportCmdKeyProgress(CmdKey.S0408);
                        flag &= false;
                    }
                    flag &= X_Axis.AxisGoHomeWork();
                    flag &= Y_Axis.AxisGoHomeWork();
                    flag &= T_Axis.AxisGoHomeWork();
                    if (!WaitAxisMoveDone(500))//延迟20S判断
                    {
                        ReportCmdKeyProgress(CmdKey.S0096);
                        return false;
                    }
                    ReportCmdKeyProgress(CmdKey.S0108);
                    flag &= X_Axis.SetPrePosition(X_Axis.Param.StartPos);
                    flag &= Y_Axis.SetPrePosition(Y_Axis.Param.StartPos);
                    flag &= T_Axis.SetPrePosition(T_Axis.Param.StartPos);
                    ReportCmdKeyProgress(CmdKey.S0109);
                    flag &= X_Axis.SetLimitSwitch(true);
                    flag &= Y_Axis.SetLimitSwitch(true);
                    flag &= T_Axis.SetLimitSwitch(true);
                    flag &= X_Axis.SetSoftPLimit(X_Axis.Param.SoftPlimit);
                    flag &= X_Axis.SetSoftNLimit(X_Axis.Param.SoftNlimit);
                    flag &= Y_Axis.SetSoftPLimit(Y_Axis.Param.SoftPlimit);
                    flag &= Y_Axis.SetSoftNLimit(Y_Axis.Param.SoftNlimit);
                    flag &= T_Axis.SetSoftPLimit(T_Axis.Param.SoftPlimit);
                    flag &= T_Axis.SetSoftNLimit(T_Axis.Param.SoftNlimit);
                    if (flag)
                    {
                        Globals.LedCmd.Cmd = Globals.DevData.IdleLedCmd.Cmd;
                        ReportCmdKeyProgress(CmdKey.S0101);
                    }
                    else
                    {
                        ReportCmdKeyProgress(CmdKey.S0102);
                    }
                    return flag;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                ReportCmdKeyProgress(CmdKey.S0098);
                return false;
            }
        }

        public static bool SystemLoad()
        {
            if (!File.Exists(Globals.AppCfg.LogFileFullName))
            {
                File.WriteAllBytes(Globals.AppCfg.LogFileFullName, Properties.Resources.FCLOG);
            }
            LogHelper.ConnectLogerDataBase(Globals.AppCfg.LogFileFullName);//连接数据库
            if ((SysCfg)ProcessCmd.GetMacConfigRegister() != Globals.SysCfg)
            {
                Globals.SysCfg = (SysCfg)ProcessCmd.GetMacConfigRegister();
                Globals.AppCfg.SysConfig = Globals.SysCfg;
                ReportCmdKeyProgress(CmdKey.S0088);
            }
            if (!HwProvider.CreateSystemObject(Globals.AppCfg.HardWareFileFullName))
            {
                ReportCmdKeyProgress(CmdKey.S0004);
            }
            else
            {
                ReportCmdKeyProgress(CmdKey.S0003);
            }
            if (File.Exists(Globals.AppCfg.MacFullPathName))
            {
                Globals.MacData = Serialize.XmlDeSerialize<MacData>(File.ReadAllText(Globals.AppCfg.MacFullPathName));
                LogHelper.AutoDeleteLogTable();
            }
            else
            {
                ReportCmdKeyProgress(CmdKey.S0019);
            }
            if (File.Exists(Globals.AppCfg.DevFullPathName))
            {
                Globals.DevData = Serialize.XmlDeSerialize<DevData>(File.ReadAllText(Globals.AppCfg.DevFullPathName));
            }
            else
            {
                ReportCmdKeyProgress(CmdKey.S0018);
            }
            if (File.Exists(Globals.AppCfg.TabFileFullPath))
            {
                Globals.TabData = Serialize.XmlDeSerialize<TabData>(File.ReadAllText(Globals.AppCfg.TabFileFullPath));//加载工作台信息文件
            }
            else
            {
                ReportCmdKeyProgress(CmdKey.S0017);
            }
            if (File.Exists(Globals.AppCfg.BladeFileFullName))
            {
                Globals.BldData = Serialize.XmlDeSerialize<BldData>(File.ReadAllText(Globals.AppCfg.BladeFileFullName));//加载刀具信息文件
            }
            else
            {
                ReportCmdKeyProgress(CmdKey.S0016);
            }
            if (File.Exists(Globals.AppCfg.CutFileFullName))
            {
                Globals.Group = Serialize.XmlDeSerialize<CutGroup>(File.ReadAllText(Globals.AppCfg.CutFileFullName));   //加载划切文件
            }
            else
            {
                Globals.Group = new CutGroup();
                ReportCmdKeyProgress(CmdKey.S0015);
            }
            bool flag = true;
            if (!HwProvider.InitHardwareDriver())
            {
                flag = false;
                ReportCmdKeyProgress(CmdKey.S0006);
            }
            else
            {
                ReportCmdKeyProgress(CmdKey.S0005);
            }
            if (!InitAxisSystemParam())
            {
                flag = false;
                ReportCmdKeyProgress(CmdKey.S0013);
            }
            else
            {
                ReportCmdKeyProgress(CmdKey.S0012);
            }
            if (flag)
            {
                ReportCmdKeyProgress(CmdKey.S0001);
                DO[DoDefine.TAB_AIR] = true;//打开吸台
                DO[DoDefine.CUT_WATER] = false;//关闭切割水
                Globals.LedCmd.Cmd = Globals.DevData.LoadLedCmd.Cmd;
            }
            else
            {
                ReportCmdKeyProgress(CmdKey.S0002);
            }
            if (!Globals.AppCfg.Shutdown)
            {
                ReportCmdKeyProgress(CmdKey.S0089);
            }
            Globals.AppCfg.Shutdown = false;//清除上次关机标志
            return flag;
        }

        public static bool SystemExit(bool shutDown, bool isOk = true)
        {

            try
            {
                Globals.AppCfg.Shutdown = isOk;
                Globals.AppCfg.SaveDefaultSysConfigFile();//保存当前应用配置
                if (X_Axis != null && X_Axis.Enabled)
                {
                    X_Axis.AxisAotoEscapeLimit();
                }
                if (Y_Axis != null && Y_Axis.Enabled)
                {
                    Y_Axis.AxisAotoEscapeLimit();
                }
                if (T_Axis != null && T_Axis.Enabled)
                {
                    T_Axis.AxisAotoEscapeLimit();
                }
                if (Z_Axis != null && Z_Axis.Enabled)
                {
                    Z_Axis.AxisAotoEscapeLimit();
                    Z_Axis.AxisGoHomeWork(true);//Z轴回位操作
                    ReportCmdKeyProgress(CmdKey.S0407);//Z轴回零成功
                }
                if (SPD != null && SPD.IsInit)
                {
                    SPD.StopSpd();
                    ReportCmdKeyProgress(CmdKey.S0607);
                }
                HwProvider.UnInitHardwareDriver();//关闭所有硬件
                ReportCmdKeyProgress(CmdKey.S0023);//判定是否需要延迟断电
                backWorker.CancelAsync();
                LogHelper.CloseLogerConnect();
            }
            catch
            {

            }
            if (shutDown)
            {
                ProcessCmd.SetSystemShutdown();
            }
            else
            {
                //ProcessCmd.ShowWindowDesk();//显示Window桌面
                //ProcessCmd.ShowLogicalDriver();//显示硬盘
                //ProcessCmd.UsedTaskMgrForm();//使用任务管理器
                //ProcessCmd.SetSystytemLoadShell(true);//设置系统默认加载路径并注销系统
            }
            Application.Exit();
            return true;
        }
        #endregion

    }
}
