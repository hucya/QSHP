using QSHP.Com;
using QSHP.HW;
using QSHP.UI;
using QSHP.UI.Ctr;
using QSHP.UI.Manual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace QSHP
{

    public partial class MainForm : Form
    {
     
        #region 字段属性
        Stack<BaseForm> childs = new Stack<BaseForm>();
        FormStyle style = FormStyle.PathMode;
        BaseForm childForm;
        DispatcherTimer timer = new DispatcherTimer();
        LedCmd ledTick = new LedCmd(0);
        LedCmd ledStatus = new LedCmd(0);
        LedCmd cmd = new LedCmd(0);
        int cycTick = 0;
        public MainForm()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                timer.Interval = TimeSpan.FromMilliseconds(100);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
        }

        public UnderBar FnBar
        {
            get
            {
                return underBar1;
            }
        }

        public MonitorEx Moitor
        {
            get
            {
                return this.monitorEx1;
            }
        }

        public TopBar TopBar
        {
            get
            {
                return this.topBar1;
            }
        }

        public Button CancelBT
        {
            get
            {
                return this.cancelBt;
            }
        }

        public Button ConfirmBT
        {
            get
            {
                return this.confirmBt;
            }
        }

        public Button NextBT
        {
            get
            {
                return this.nextBt;
            }
        }
        [Category("自定义")]
        public FormStyle Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
                if (value < FormStyle.PathMode)
                {
                    switch (value)
                    {
                        case FormStyle.Cancel:
                            {
                                this.confirmBt.Visible = false;
                                this.cancelBt.Visible = true;
                                this.nextBt.Visible = false;
                            }
                            break;
                        case FormStyle.OKCancel:
                            {
                                this.confirmBt.Visible = true;
                                this.cancelBt.Visible = true;
                                this.nextBt.Visible = false;
                            }
                            break;
                        case FormStyle.NextOKCancel:
                            {
                                this.confirmBt.Visible = true;
                                this.cancelBt.Visible = true;
                                this.nextBt.Visible = true;
                            }
                            break;
                        case FormStyle.OK:
                            {
                                this.confirmBt.Visible = true;
                                this.cancelBt.Visible = false;
                                this.nextBt.Visible = false;
                            }
                            break;
                        case FormStyle.NextOK:
                            {
                                this.confirmBt.Visible = true;
                                this.cancelBt.Visible = false;
                                this.nextBt.Visible = true;
                            }
                            break;
                        default:
                            {
                                this.confirmBt.Visible = false;
                                this.cancelBt.Visible = false;
                                this.nextBt.Visible = false;
                            }
                            break;
                    }
                    funTab.SelectedIndex = 0;
                }
                else
                {
                    int index = ((int)(value) >> 4) & 0xFF;
                    if (index < funTab.TabCount)
                    {
                        funTab.SelectedIndex = ((int)(value) >> 4) & 0xFF;
                        this.CancelBT.Visible = ((int)(value) & 0x01) > 0;
                    }
                    else
                    {
                        this.confirmBt.Visible = false;
                        this.cancelBt.Visible = false;
                        this.nextBt.Visible = false;
                        funTab.SelectedIndex = 0;
                    }
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public BaseForm ChildForm
        {
            get
            {
                return childForm;
            }

            set
            {
                childForm = value;
            }
        }

        public Stack<BaseForm> Childs
        {
            get
            {
                return childs;
            }
            set
            {
                childs = value;
            }
        }
        #endregion

        #region 系统方法

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_DEVICECHANGE:
                    {
                        switch (m.WParam.ToInt32())
                        {
                            case NativeMethods.DBT_DEVICEARRIVAL://U盘插入
                                {
                                    Common.ReportCmdKeyProgress(CmdKey.F0047);
                                }
                                break;
                            case NativeMethods.DBT_DEVICEREMOVECOMPLETE: //U盘卸载
                                {
                                    Common.ReportCmdKeyProgress(CmdKey.F0048);
                                }
                                break;
                            default:
                                break;
                        }
                    }break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            LogHelper.WriteDebugMessage("加载运行程序");
            base.SetVisibleCore(false);//屏蔽ALT+TAB切换
            VerticalScroll.Enabled = false;
            HorizontalScroll.Enabled = false;
            PushChildForm(new HomeScreen());
            underBar1.Moitor = monitorEx1;
            Common.ProgressCmdKeyChanged += Common_ProgressChanged;
            Logo log = new Logo(this);
            log.Show();
        }
        private void Common_ProgressChanged(CmdKey key, object obj)
        {
            this.BeginInvoke((Action<CmdKey>)ProcessCommonProgressChanger, key);
        }
        private void ProcessCommonProgressChanger(CmdKey key)
        {
            if (Globals.SysCmd.ContainsKey(key))
            {
                topBar1.SetSystemMessage(Globals.SysCmd[key]);
                LogHelper.AddNewLogerMessage(key);
            }
        }
        private bool ShowChildFormInfo()
        {
            if (Childs.Count < 2)
            {
                return topBar1.SetChildFormInformation();
            }
            else
            {
                StringBuilder info = new StringBuilder();
                List<Form> childForm = Childs.ToList<Form>();
                childForm.Reverse();
                childForm.RemoveAt(0);
                bool first = false;
                foreach (var item in childForm)
                {
                    if (first)
                    {
                        info.Append(" > ");
                    }
                    info.Append(item.Text);
                    first = true;
                }
                return topBar1.SetChildFormInformation(info.ToString());
            }
        }
        private void TopBar_SensorClick(object sender, EventArgs e)
        {
            if (childForm is LogerViewManager == false)
            {
                this.PushChildForm(new LogerViewManager(), false);
            }
            else
            {
                this.OnCancelClick();
            }
        }
        private void FunTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (funTab.SelectedTab == pathPage)
            {
                fileDir.Text = Globals.AppCfg.CutDirectory;
                fileName.Text = Globals.AppCfg.CutFileNameWithoutExtension;
            }
        }
        public void OnCancelClick()
        {
            if (childForm != null)
            {
                PopChildForm();
            }
        }
        public bool SetFormIndex(int parentIndex = 0, int subIndex = 0, int index = 0)
        {
            return this.topBar1.SetFormIndex(parentIndex, subIndex, index);
        }
        public void AutoUpdate(int cycTime=5)
        {
            if (cycTick-- < 0)
            {
                cycTick = cycTime;
                cmd.Cmd = Globals.LedCmd.Cmd;
                if (ledStatus.Cmd != cmd.Cmd)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int port = DoDefine.BUZZER + i;//蜂鸣器0 绿灯1 黄灯2 红灯3
                        switch (cmd[i])
                        {
                            case 0://关闭
                                {
                                    ledTick[i] = 0;
                                    ledStatus[i] = cmd[i];
                                    Common.DO[port] = false;
                                }
                                break;
                            case 1://打开
                                {
                                    ledTick[i] = 0;
                                    ledStatus[i] = cmd[i];
                                    Common.DO[port] = true;
                                }
                                break;
                            case 2://慢三声响
                                {
                                    if (ledTick[i]++ > 15)
                                    {
                                        ledTick[i] = 0;
                                        Globals.LedCmd[i] = 0;//设置为关闭状态
                                        ledStatus[i] = 0;
                                        Common.DO[port] = false;
                                    }
                                    else
                                    {
                                        if (ledTick[i] % 3 == 0)
                                        {
                                            Common.DO[port] = !Common.DO[port];
                                        }
                                    }
                                }
                                break;
                            case 3://快五声音响
                                {

                                    if (ledTick[i]++ > 18)
                                    {
                                        ledTick[i] = 0;
                                        Globals.LedCmd[i] = 0;//设置为关闭状态
                                        ledStatus[i] = 0;
                                        Common.DO[port] = false;
                                    }
                                    else
                                    {
                                        if (ledTick[i] % 2 == 0)
                                        {
                                            Common.DO[port] = !Common.DO[port];
                                        }
                                    }
                                }
                                break;
                            case 4://更快七声音响
                                {
                                    if (ledTick[i]++ > 12)
                                    {
                                        ledTick[i] = 0;
                                        Globals.LedCmd[i] = 0;//设置为关闭状态
                                        ledStatus[i] = 0;
                                        Common.DO[port] = false;
                                    }
                                    else
                                    {
                                        Common.DO[port] = !Common.DO[port];
                                    }
                                }
                                break;
                            default:
                                {
                                    Globals.LedCmd[i] = 0;
                                    ledTick[i] = 0;
                                }
                                break;
                        }
                    }
                }
            }

        }
        #endregion

        #region 窗体处理
        public void PushChildForm(BaseForm child, bool push = true)
        {
            if (child != null)
            {
                this.SuspendLayout();
                child.MdiParent = this;
                child.Dock = DockStyle.Fill;
                child.PushParent = push;
                if (Childs.Count > 0)
                {
                    BaseForm b = childForm;
                    if (b != null && !b.PushParent) //当前没有入栈
                    {
                        b.UnLoadScreenFuntion();    //卸载底部窗体注册事件及字体
                        child.LoadScreenFuntion();  //加载顶部窗体注册事件及字体
                        b.Close();
                    }
                    else//当前已经入栈
                    {
                        b = Childs.Peek();  //获取底部窗体
                        b.UnLoadScreenFuntion();    //卸载底部窗体注册事件及字体
                        child.LoadScreenFuntion();  //加载顶部窗体注册事件及字体
                        b.Hide();
                    }
                    //后隐藏底部窗体
                }
                else
                {
                    child.PushParent = true;
                    child.LoadScreenFuntion();//第一个窗体必须入栈
                }
                if (push)
                {
                    Childs.Push(child);
                    ShowChildFormInfo();
                }
                else
                {
                    topBar1.SetChildFormInformation(child.Text);
                    SetFormIndex(0, 0, child.Index);
                }
                this.ResumeLayout(false);
                GC.Collect();
            }
        }
        public void PopChildForm(BaseForm f)
        {
            if (f != null)
            {
                if (f.PushParent)
                {
                    this.SuspendLayout();
                    List<BaseForm> list = Childs.ToList();
                    list.Remove(f);
                    Childs.Clear();
                    list.Reverse();
                    foreach (var item in list)
                    {
                        Childs.Push(item);
                    }
                    f.UnLoadScreenFuntion();
                    if (Childs.Count > 0)
                    {
                        BaseForm a = Childs.Peek();
                        a.LoadScreenFuntion();  //加载新窗体注册时间
                    }
                    f.Close();
                    ShowChildFormInfo();
                    this.ResumeLayout(false);
                }
                else
                {
                    f.UnLoadScreenFuntion();
                    f.Close();
                }
                GC.Collect();
            }
        }
        public void PopChildForm()
        {
            if (Childs.Count > 1)
            {
                this.SuspendLayout();
                BaseForm b = childForm;
                if (b.PushParent)//当前已经入栈
                {
                    b = Childs.Pop();
                    b.UnLoadScreenFuntion();        //卸载底部窗体注册事件
                }
                if (Childs.Count > 0)
                {
                    BaseForm a = Childs.Peek();
                    a.LoadScreenFuntion();  //加载新窗体注册时间
                }
                if (b != null)
                {
                    b.Close();
                }
                ShowChildFormInfo();
                this.ResumeLayout(false);
                GC.Collect();
            }
            else
            {
                Childs.Peek().LoadScreenFuntion();
            }
        }
        public void PopToHomeScreen()
        {
            BaseForm b = childForm;
            if (b!=null&&!b.PushParent)
            {
                b.UnLoadScreenFuntion();
                b.Close();
            }
            while (Childs.Count > 1)
            {
                b = Childs.Pop();//弹出当前窗体
                b.UnLoadScreenFuntion();//卸载所注册的事件
                b.Close();
            }
            Childs.Peek().LoadScreenFuntion();
            ShowChildFormInfo();
            GC.Collect();
        }
        public void ReplaceChildForm(BaseForm child)
        {
            if (child != null)
            {
                this.SuspendLayout();
                child.MdiParent = this;
                child.Dock = DockStyle.Fill;
                if (Childs.Count > 0)
                {
                    BaseForm b = childForm;
                    if (b.PushParent)
                    {
                        b= Childs.Pop();
                    }
                    b.UnLoadScreenFuntion();    //卸载原窗体事件
                    child.LoadScreenFuntion();  //加载新窗体事件
                    b.Close();                  //关闭原窗体
                }
                else
                {
                    child.LoadScreenFuntion();//加载新窗体`  
                }
                Childs.Push(child);
                ShowChildFormInfo();
                this.ResumeLayout(false);
                GC.Collect();
            }
        }
        #endregion


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                AutoUpdate(2);
                monitorEx1.AutoUpdate(1); //状态栏目100ms刷新一次
                topBar1.AutoUpdate(5);   //顶部500ms刷新一次
                underBar1.AutoUpate(5);  //500ms//底部500ms刷新一次
                if (childForm != null)
                {
                    childForm.AutoUpdate(childForm.CycTime);//其他窗体根据配置进行刷新
                }
            }
        }
    }

    public enum FormStyle
    {
        None = 0x00,
        Cancel = 0x01,
        OKCancel = 0x02,
        NextOKCancel = 0x03,
        OK = 0x04,
        NextOK = 0x05,
        PathMode = 0x10,
        PathModeCancel = 0x11,
        WorkMode = 0x20,
        WorkModeCancel = 0x21,
        LogMode = 0x30,
        LogModeCancel = 0x31,
        OtherMode = 0x40,
        OtherModeCancel = 0x41,
    }
}
