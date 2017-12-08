using Microsoft.Win32;
using QSHP.Com;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;

namespace QSHP
{
    public static class ProcessCmd
    {
        #region 全局命令变量

        public const int CutLineCmd = 0x1000;
        public const int CutSegStartCmd = 0x1001;
        public const int CutSegEndCmd = 0x1002;
        public const int CutPieceCmd = 0x1003;
        public const int CutChStartCmd = 0x1004;
        public const int CutChEndCmd = 0x1005;
        public const int CutGroupCmd = 0x1006;

        public const int CutPauseCmd = 0x1100;
        public const int CutSopCmd = 0x1101;
        public const int CutStartCmd = 0x1102;
        public const int CutContinuesCmd = 0x1103;


        public const int CsTestingStartCmd = 0x1200;
        public const int CsTestingEndCmd = 0x1201;
        public const int CsTestingErrCmd = 0x1202;
        public const int CsTestingTickCmd = 0x1203;

        public const int SpdCmd = 0x2000;
        public const int SpdWaitCmd = 0x2001;
        public const int SpdWaitReportCmd = 0x2002;
        public const int SpdWaitReadyCmd = 0x2003;


        #endregion

        #region 应用函数
        static string registerPath = "SOFTWARE\\Microsoft\\MacSystem\\Register";
        public static string ProductName
        {
            get
            {
                return Application.StartupPath + @"\" + Application.ProductName + @".exe";
            }
        }
        /// <summary>
        /// 显示桌面
        /// </summary>
        public static void ShowWindowDesk()
        {
            NativeMethods.ShowWindow(NativeMethods.FindWindow("Progman", null), NativeMethods.SW_SHOW);
            NativeMethods.ShowWindow(NativeMethods.FindWindow("Shell_TrayWnd", null), NativeMethods.SW_SHOW);
            NativeMethods.ShowWindow(NativeMethods.FindWindow("Button", null), NativeMethods.SW_SHOW);
        }
        /// <summary>
        /// 隐藏桌面
        /// </summary>
        public static void HideWindowDesk()
        {
            NativeMethods.ShowWindow(NativeMethods.FindWindow("Progman", null), NativeMethods.SW_HIDE);
            NativeMethods.ShowWindow(NativeMethods.FindWindow("Shell_TrayWnd", null), NativeMethods.SW_HIDE);
            NativeMethods.ShowWindow(NativeMethods.FindWindow("Button", null), NativeMethods.SW_HIDE);
        }
        /// <summary>
        /// 设置当前程序开机自启动
        /// </summary>
        public static void SetProcessAutoStart(bool start = true)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (start)
            {
                if (key == null)
                {
                    key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                key.SetValue(Application.ProductName, ProductName + " -autorun");
            }
            else
            {
                if (key != null)
                {
                    key.DeleteValue(Application.ProductName);
                }
            }

        }
        /// <summary>
        /// 设置当前进程在启动后直接进入 不启动桌面
        /// </summary>
        /// <param name="reset"></param>
        public static bool SetSystytemLoadShell(bool reset = false)
        {
            bool flag = SetValueWithRegView(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", "Shell", reset ? @"explorer.exe" : ProductName, RegistryValueKind.String);
            if (reset)
            {
                CancellSystem();
            }
            return flag;
        }
        public static void CancellSystem()
        {
            Process.Start("shutdown.exe", "-f -t 3");//立即强制注销电脑 -l 也可进行注销
        }
        /// <summary>
        /// 关机系统
        /// </summary>
        /// <param name="time"></param>
        public static void SetSystemShutdown(int time = -1)
        {
            if (time == -1)
            {
                Process.Start("shutdown.exe", "-p");//立即关闭本地计算机
            }
            else
            {
                Process.Start("shutdown.exe", string.Format("-s -t {0}", time));//关闭本地计算机有提示
            }
        }
        /// <summary>
        /// 重启系统
        /// </summary>
        /// <param name="time"></param>
        public static void RestartSystem(int time = -1)
        {
            if (time == -1)
            {
                Process.Start("shutdown.exe", "-r");//关闭并重启计算机
            }
            else
            {
                Process.Start("shutdown.exe", string.Format("-s -r {0}", time));//几秒后关闭计算机并重启
            }
        }
        /// <summary>
        ///  隐藏所有驱动器
        /// </summary>
        /// <returns></returns>
        public static bool HideLogicalDriver()
        {
            string[] MyDrivers = System.IO.Directory.GetLogicalDrives();
            int iData = 0;
            int flag = 0;
            foreach (var item in MyDrivers)
            {
                char DriverLetter = item[0];
                flag= 1 << (DriverLetter - 'A');
                iData += flag;
            }
            try
            {
                RegistryKey MyReg = CreateSubKey(RegistryHive.CurrentUser,"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
                MyReg.SetValue("NoDrives", iData);
                MyReg.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 显示所有驱动器
        /// </summary>
        /// <returns></returns>
        public static bool ShowLogicalDriver()
        {
            try
            {
                RegistryKey MyReg = OpenSubKey(RegistryHive.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);
                MyReg.DeleteValue("NoDrives");
                MyReg.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 禁用任务管理器
        /// </summary>
        /// <returns></returns>
        public static bool NoUsedTaskMgrForm()
        {
            try
            {
                RegistryKey MyReg = CreateSubKey(RegistryHive.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                MyReg.SetValue("DisableTaskMgr", 1);
                MyReg.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 启用任务管理器
        /// </summary>
        /// <returns></returns>
        public static bool UsedTaskMgrForm()
        {
            try
            {
                RegistryKey MyReg = OpenSubKey(RegistryHive.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                MyReg.DeleteValue("DisableTaskMgr");
                MyReg.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveUsbDiskDriver()
        {
            try
            {
                Process.Start("RUNDLL32.exe", "SHELL32.dll,Control_RunDLL hotplug.dll");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool CheckMachineRegistKeyIsValid()
        {
            string s = Com.Checksum.GetRegiterKeys();
            try
            {
                RegistryKey k = CreateSubKey(RegistryHive.LocalMachine, registerPath);
                object obj = GetValueWithRegView(RegistryHive.LocalMachine, registerPath, "MachineID", Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                if(obj!=null)
                { 
                    string s1 = obj.ToString();
                    return s.Equals(s1);
                }
                else
                {

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckMachineRegistValueIsValid()
        {
            try
            {
                object obj= GetValueWithRegView(RegistryHive.LocalMachine, registerPath, "MachineValue", Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                if (obj != null)//已经注册
                {
                    string s1= obj.ToString().ToUpper();
                    return Com.Checksum.CheckRegiterKeysIsValid(s1);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public static void RegisterSystem(string key, string value)
        {
            SetValueWithRegView(RegistryHive.LocalMachine, registerPath, "MachineID",key, RegistryValueKind.String);
            SetValueWithRegView(RegistryHive.LocalMachine, registerPath, "MachineValue", value, RegistryValueKind.String);
        }

        public static int GetMacConfigRegister()
        {
            object obj = GetValueWithRegView(RegistryHive.LocalMachine, registerPath, "cfg", Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
            if (obj != null)
            {
                int i = 0;
                int.TryParse(obj.ToString(), out i);
                return i;
            }
            else
            {
                return 0;
            }
        }
        public static void SetMacConfigRegister(int value)
        {
            SetValueWithRegView(RegistryHive.LocalMachine, registerPath, "cfg", value, RegistryValueKind.DWord);
        }

        public static bool HasMoveHardDisk()
        {
            bool flag = false;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var item in drives)
            {
                if (item.DriveType == DriveType.Removable)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public static void InstallFont()
        {
            string path = string.Format(@"{0}\QSHP.otf", Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
            if (!File.Exists(path))
            {
                File.WriteAllBytes(path, Properties.Resources.QSHP);
            }
        }

        #region 取消注册表映射
        static IntPtr GetHiveHandle(RegistryHive hive)
        {
            IntPtr preexistingHandle = IntPtr.Zero;

            IntPtr HKEY_CLASSES_ROOT = new IntPtr(-2147483648);
            IntPtr HKEY_CURRENT_USER = new IntPtr(-2147483647);
            IntPtr HKEY_LOCAL_MACHINE = new IntPtr(-2147483646);
            IntPtr HKEY_USERS = new IntPtr(-2147483645);
            IntPtr HKEY_PERFORMANCE_DATA = new IntPtr(-2147483644);
            IntPtr HKEY_CURRENT_CONFIG = new IntPtr(-2147483643);
            IntPtr HKEY_DYN_DATA = new IntPtr(-2147483642);
            switch (hive)
            {
                case RegistryHive.ClassesRoot: preexistingHandle = HKEY_CLASSES_ROOT; break;
                case RegistryHive.CurrentUser: preexistingHandle = HKEY_CURRENT_USER; break;
                case RegistryHive.LocalMachine: preexistingHandle = HKEY_LOCAL_MACHINE; break;
                case RegistryHive.Users: preexistingHandle = HKEY_USERS; break;
                case RegistryHive.PerformanceData: preexistingHandle = HKEY_PERFORMANCE_DATA; break;
                case RegistryHive.CurrentConfig: preexistingHandle = HKEY_CURRENT_CONFIG; break;
                case RegistryHive.DynData: preexistingHandle = HKEY_DYN_DATA; break;
            }
            return preexistingHandle;
        }
        static object GetValueWithRegView(RegistryHive hive, string keyName, string valueName, RegistryView view = RegistryView.Registry32)
        {
            try
            {
                SafeRegistryHandle handle = new SafeRegistryHandle(GetHiveHandle(hive), true);//获得根节点的安全句柄

                RegistryKey subkey = RegistryKey.FromHandle(handle, view).OpenSubKey(keyName);//获得要访问的键

                RegistryKey key = RegistryKey.FromHandle(subkey.Handle, view);//根据键的句柄和视图获得要访问的键

                return key.GetValue(valueName);//获得键下指定项的值
            }
            catch
            {
                return string.Empty;
            }
        }

        static bool SetValueWithRegView(RegistryHive hive, string keyName, string valueName, object value, RegistryValueKind kind)
        {
            try
            {
                SafeRegistryHandle handle = new SafeRegistryHandle(GetHiveHandle(hive), true);
                RegistryView view = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
                RegistryKey subkey = RegistryKey.FromHandle(handle, view).OpenSubKey(keyName, true);
                RegistryKey key = RegistryKey.FromHandle(subkey.Handle, view);
                key.SetValue(valueName, value, kind);
                return true;
            }
            catch
            {
                
                return false;
            }

        }

        static RegistryKey CreateSubKey(RegistryHive hive, string keyName)
        {
            try
            {
                SafeRegistryHandle handle = new SafeRegistryHandle(GetHiveHandle(hive), true);
                RegistryView view = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
                RegistryKey subkey= RegistryKey.FromHandle(handle, view).CreateSubKey(keyName);
                return subkey;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        static RegistryKey OpenSubKey(RegistryHive hive, string keyName,bool writeable=true)
        {
            try
            {
                SafeRegistryHandle handle = new SafeRegistryHandle(GetHiveHandle(hive), true);
                RegistryView view = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
                RegistryKey subkey = RegistryKey.FromHandle(handle, view).OpenSubKey(keyName, writeable);
                return subkey;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        #endregion
        #endregion

    }
}
