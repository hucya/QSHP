using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Forms;
using QSHP.UI.Ctr;
using System.Diagnostics;
using QSHP.Com;

namespace QSHP
{
    public static class Program
    {
        static KeyPad keyPad1;
        static KeyMessageFilter keyMessage;
        static TextBoxBase textBoxBase;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            ProcessApplication();
        }

        public static void ProcessApplication()
        {
            try
            {
                try
                {

                    //ProcessCmd.InstallFont();//安装字体
                    //ProcessCmd.HideWindowDesk();//隐藏桌面
                    //ProcessCmd.HideLogicalDriver();//隐藏驱动器
                    //ProcessCmd.NoUsedTaskMgrForm();//关闭任务管理器
                    //if (ProcessCmd.SetSystytemLoadShell())//设置启动项目
                    //{
                    //    ProcessCmd.SetProcessAutoStart(false);//删除重启项目
                    //}
                    //else
                    //{
                    //    ProcessCmd.SetProcessAutoStart();//如果设置失败就设置自动启动
                    //}
                }
                finally
                {
                    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
                    Application.ThreadException += Application_ThreadException;
                    Application.ApplicationExit += Application_ApplicationExit;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    keyPad1 = new UI.Ctr.KeyPad();
                    keyMessage = new KeyMessageFilter();
                    Application.AddMessageFilter(keyMessage);
                    Common.LoadSysConfigFile();
                    Application.Run(new MainForm());
                    Application.RemoveMessageFilter(keyMessage);
                    keyPad1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Common.SystemExit(true, false);
            }
            finally
            {

            }
        }
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            LogHelper.WriteDebugMessage("退出应用程序");
            ProcessCmd.ShowWindowDesk();
            //System.Diagnostics.Process.Start("shutdown.exe", "-s -t 15"); //1分钟后关机
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), "捕获程序异常");
            LogHelper.WriteDebugException(e.Exception);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public class KeyMessageFilter : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                switch (m.Msg)
                {
                    case KeyMsg.WM_LBUTTONUP:
                        {
                            Control ctr = Control.FromHandle(m.HWnd);
                            if (ctr == null)
                            {
                                if (keyPad1.Visible)
                                {
                                    keyPad1.Hide();
                                }
                                return false;
                            }
                            if (ctr.FindForm() == keyPad1)
                            {
                                return false;
                            }
                            textBoxBase = ctr as TextBoxBase;
                            if (textBoxBase != null && ctr.Enabled && !textBoxBase.ReadOnly)
                            {
                                keyPad1.Show(ctr);
                            }
                            else
                            {
                                if (keyPad1.Visible)
                                {
                                    keyPad1.Hide();
                                }
                            }
                            return false;
                        }
                    case NativeMethods.WM_SYSCOMMAND://禁用系统菜单
                        {
                            m.Result = IntPtr.Zero;
                            return true;
                        }
                    case NativeMethods.WM_QUERYENDSESSION:
                        {
                            m.Result = IntPtr.Zero;//禁止关闭操作系统
                            return true;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }
        }
    }
}
