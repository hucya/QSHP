using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QSHP.Data
{
    public class AppConfig//系统分配的全路径
    {
        bool usedStartupPath = true;
        bool shutdown = true;
        int language = 0;
        string dataPath = Application.StartupPath;
        string hardWareFileName = "config61B.sys";
        string bladeFileName = "QS2017100001.drs";
        string cutFileName = "5-2.4.ctd";
        static string macName = @"\Data\MacCfg.sys";
        static string sysName = @"\Data\sysConfig.sys";
        static string cmdName = @"\Data\CmdKey.txt";
        static string tabFileName = @"\Data\TabCfg.sys";
        static string devName = @"\Data\DevCfg.sys";
        static string logName = @"\Data\FCLOG.mdb";
        SysCfg sysCfg;
        DateTime lastUsedDate=DateTime.Now;
        /// <summary>
        /// 使用系统默认启动路径
        /// </summary>
        public bool UsedStartupPath
        {
            get
            {
                return usedStartupPath;
            }

            set
            {
                usedStartupPath = value;
            }
        }
        /// <summary>
        /// 默认位置路径
        /// </summary>
        public string DefaultPath
        {
            get
            {
                return dataPath;
            }
            set
            {
                if (!usedStartupPath)
                {
                    dataPath = value;
                }
            }
        }
        /// <summary>
        /// 默认刀具路径 
        /// </summary>
        public string BladeFilePath
        {
            get
            {
                return DefaultPath + @"\Data\FCBladeData\";
            }
        }

        public string LogFileFullName
        {
            get
            {
                return DefaultPath + logName;
            }
        }

        public string TabFileFullPath
        {
            get
            {
                return DefaultPath + tabFileName;
            }
        }
        /// <summary>
        /// 划切文件全名称
        /// </summary>
        public string CutFileFullName
        {
            get
            {
                return CutFilePath + CutFileName;
            }
        }

        /// <summary>
        /// 默认硬件配置路径
        /// </summary>
        public string HardWareFilePath
        {
            get
            {
                return DefaultPath + @"\Data\Config\";
            }
        }

        /// <summary>
        /// 默认划切文件路径
        /// </summary>
        public string CutFilePath
        {
            get
            {
                return DefaultPath + @"\Data\FCCutData\";
            }
        }
        public string CmdFullName
        {
            get
            {
                return DefaultPath + cmdName;
            }
        }
        /// <summary>
        /// 划切文件名
        /// </summary>
        public string CutFileName
        {
            get
            {
                return cutFileName;
            }
            set
            {
                cutFileName = value;
            }
        }
        /// <summary>
        /// 划切文件夹名
        /// </summary>
        public string CutDirectory
        {
            get
            {
                if (!string.IsNullOrEmpty(CutFileFullName))
                {
                    return Path.GetFileName(Path.GetDirectoryName(CutFileFullName));
                }
                else
                {
                    return "目录无效";
                }
            }
        }
        /// <summary>
        /// 实际划切文件名字无后缀
        /// </summary>
        public string CutFileNameWithoutExtension
        {
            get
            {
                if (File.Exists(CutFileFullName))
                {
                    return Path.GetFileNameWithoutExtension(CutFileFullName);
                }
                else
                {
                    return "文件无效";
                }
            }
        }

        public string HardWareFileFullName
        {
            get
            {
                return HardWareFilePath + HardWareFileName;
            }
        }

        public string BladeFileFullName
        {
            get
            {
                return BladeFilePath + BladeFileName;
            }
        }

        public string HardWareFileName
        {
            get
            {
                return hardWareFileName;
            }

            set
            {
                hardWareFileName = value;
            }
        }
        /// <summary>
        /// 默认硬件配置路径
        /// </summary>
        public string MacFullPathName
        {
            get
            {
                return DefaultPath +macName;
            }
        }
        /// <summary>
        /// 默认设备配置路径
        /// </summary>
        public string DevFullPathName
        {
            get
            {
                return DefaultPath + devName;
            }
        }
        public string BladeFileName
        {
            get
            {
                return bladeFileName;
            }

            set
            {
                bladeFileName = value;
            }
        }
       
        public DateTime LastUsedDate
        {
            get
            {
                return lastUsedDate;
            }

            set
            {
                lastUsedDate = value;
            }
        }

        public SysCfg SysConfig
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

        public int Language
        {
            get
            {
                return language;
            }

            set
            {
                language = value;
            }
        }

        public bool Shutdown
        {
            get
            {
                return shutdown;
            }

            set
            {
                shutdown = value;
            }
        }

        public static AppConfig LoadDefaultSysConfigFile()
        {
            string path = Application.StartupPath + sysName;
            if (File.Exists(path))
            {
                string s = File.ReadAllText(path);
                return Serialize.XmlDeSerialize<AppConfig>(s);
            }
            else
            {
                return new AppConfig();
            }
        }
       
        public void SaveDefaultSysConfigFile()
        {
            lastUsedDate = DateTime.Now;
            string path = Application.StartupPath + sysName;
            ProcessCmd.SetMacConfigRegister((int)this.sysCfg);
            string s = Serialize.XmlSerialize(this);
            File.WriteAllText(path, s);
        }

        public static bool SysConfigFileIsExists()
        {
            string path = Application.StartupPath + sysName;
            return File.Exists(path);
        }
    }
}
