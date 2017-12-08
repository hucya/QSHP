using QSHP.Com;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI
{
    public partial class BaseForm : Form
    {
        public event EventHandler BT0Click;
        public event EventHandler BT1Click;
        public event EventHandler BT2Click;
        public event EventHandler BT3Click;
        public event EventHandler BT4Click;
        public event EventHandler BT5Click;
        public event EventHandler BT6Click;
        public event EventHandler BT7Click;
        public event EventHandler BT8Click;
        public event EventHandler BT9Click;

        public event EventHandler CancelClick;
        public event EventHandler ConfirmClick;
        public event EventHandler NextClick;
        public event EventHandler AutoUpdateEventHander;

        private UnderStyle btStyle = UnderStyle.User;
        private FormStyle fmStyle = FormStyle.OKCancel;
        private UnderBar underBar;
        private FormArg[] fnArgs = new FormArg[10];
        private int index = 0;
        private int cycTick = 0;
        private int cycTime = 10;

        private bool regedit = false;
        private string cancelText = "返  回";
        private string confirmText = "确  认";
        private string nextText = "开  始";
        private Image cancelImage ;
        private Image confirmImage ;
        private Image nextImage;
        private bool pushParent = true;

        #region 自定义属性
        [Category("自定义")]
        [Bindable(BindableSupport.Yes)]
        public UnderStyle BtStyle
        {
            get
            {
                return btStyle;
            }
            set
            {
                btStyle = value;
            }
        }
        [Category("自定义")]
        [Bindable(BindableSupport.Yes)]
        public FormStyle FmStyle
        {
            get
            {
                return fmStyle;
            }
            set
            {
                fmStyle = value;
            }
        }
        [Browsable(false)]
        public new MainForm ParentForm
        {
            get
            {
                return this.MdiParent as MainForm;
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string CancelText
        {
            get
            {
                return cancelText;
            }
            set
            {
                cancelText = value;
                if (ParentForm != null)
                {
                    ParentForm.CancelBT.Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string ConfirmText
        {
            get
            {
                return confirmText;
            }
            set
            {
                confirmText = value;
                if (ParentForm != null)
                {
                    ParentForm.ConfirmBT.Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string NextText
        {
            get
            {
                return nextText;
            }
            set
            {
                nextText = value;
                if (ParentForm != null)
                {
                    ParentForm.NextBT.Text = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image CancelImage
        {
            get
            {
                return cancelImage;
            }
            set
            {
                cancelImage = value;
                if (ParentForm != null)
                {
                    ParentForm.CancelBT.Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image ConfirmImage
        {
            get
            {
                return confirmImage;
            }
            set
            {
                confirmImage = value;
                if (ParentForm != null)
                {
                    ParentForm.ConfirmBT.Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image NextImage
        {
            get
            {
                return nextImage;
            }
            set
            {
                nextImage = value;
                if (ParentForm != null)
                {
                    ParentForm.NextBT.Image = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT0Content
        {
            get
            {
                return fnArgs[0].Context;
            }
            set
            {
                fnArgs[0].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[0].Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT1Content
        {
            get
            {
                return fnArgs[1].Context;
            }
            set
            {
                fnArgs[1].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[1].Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT2Content
        {
            get
            {
                return fnArgs[2].Context;
            }
            set
            {
                fnArgs[2].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[2].Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT3Content
        {
            get
            {
                return fnArgs[3].Context;
            }
            set
            {
                fnArgs[3].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[3].Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT4Content
        {
            get
            {
                return fnArgs[4].Context;
            }
            set
            {
                fnArgs[4].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[4].Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT5Content
        {
            get
            {
                return fnArgs[5].Context;
            }
            set
            {
                fnArgs[5].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[5].Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT6Content
        {
            get
            {
                return fnArgs[6].Context;
            }
            set
            {
                fnArgs[6].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[6].Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT7Content
        {
            get
            {
                return fnArgs[7].Context;
            }
            set
            {
                fnArgs[7].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[7].Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT8Content
        {
            get
            {
                return fnArgs[8].Context;
            }
            set
            {
                fnArgs[8].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[8].Text = value;
                }
            }
        }
        [Category("按键文本")]
        [Bindable(BindableSupport.Yes)]
        public string BT9Content
        {
            get
            {
                return fnArgs[9].Context;
            }
            set
            {
                fnArgs[9].Context = value;
                if (underBar != null)
                {
                    underBar.BtList[9].Text = value;
                }
            }
        }

        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT0Image
        {
            get
            {
                return fnArgs[0].BackImage;
            }
            set
            {
                fnArgs[0].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[0].Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT1Image
        {
            get
            {
                return fnArgs[1].BackImage;
            }
            set
            {
                fnArgs[1].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[1].Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT2Image
        {
            get
            {
                return fnArgs[2].BackImage;
            }
            set
            {
                fnArgs[2].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[2].Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT3Image
        {
            get
            {
                return fnArgs[3].BackImage;
            }
            set
            {
                fnArgs[3].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[3].Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT4Image
        {
            get
            {
                return fnArgs[4].BackImage;
            }
            set
            {
                fnArgs[4].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[4].Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT5Image
        {
            get
            {
                return fnArgs[5].BackImage;
            }
            set
            {
                fnArgs[5].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[5].Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT6Image
        {
            get
            {
                return fnArgs[6].BackImage;
            }
            set
            {
                fnArgs[6].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[6].Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT7Image
        {
            get
            {
                return fnArgs[7].BackImage;
            }
            set
            {
                fnArgs[7].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[7].Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT8Image
        {
            get
            {
                return fnArgs[8].BackImage;
            }
            set
            {
                fnArgs[8].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[8].Image = value;
                }
            }
        }
        [Category("按键图像")]
        [Bindable(BindableSupport.Yes)]
        public Image BT9Image
        {
            get
            {
                return fnArgs[9].BackImage;
            }
            set
            {
                fnArgs[9].BackImage = value;
                if (underBar != null)
                {
                    underBar.BtList[9].Image = value;
                }
            }
        }
        #endregion

        public UnderBar UnderBar
        {
            get
            {
                return underBar;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        public int CycTime
        {
            get
            {
                return cycTime;
            }

            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                cycTime = value;
            }
        }
        [Browsable(false)]
        public bool PushParent
        {
            get
            {
                return pushParent;
            }

            set
            {
                pushParent = value;
            }
        }

        public BaseForm()
        {
            for (int i = 0; i < fnArgs.Length; i++)
            {
                fnArgs[i] = new FormArg();
            }
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        private void RegistEventHander()
        {
            if (ParentForm != null)
            {
                if (CancelClick != null)
                {
                    ParentForm.CancelBT.Click += CancelClick;
                }
                else
                {
                    ParentForm.CancelBT.Click += CancelButton_Click;//如果不注册事件 则直接调用默认事件
                }
                if (ConfirmClick != null)
                {
                    ParentForm.ConfirmBT.Click += ConfirmClick;
                }
                if (NextClick != null)
                {
                    ParentForm.NextBT.Click += NextClick;
                }
                fnArgs[0].ClickEventHander = BT0Click;
                fnArgs[1].ClickEventHander = BT1Click;
                fnArgs[2].ClickEventHander = BT2Click;
                fnArgs[3].ClickEventHander = BT3Click;
                fnArgs[4].ClickEventHander = BT4Click;
                fnArgs[5].ClickEventHander = BT5Click;
                fnArgs[6].ClickEventHander = BT6Click;
                fnArgs[7].ClickEventHander = BT7Click;
                fnArgs[8].ClickEventHander = BT8Click;
                fnArgs[9].ClickEventHander = BT9Click;
            }
        }

        public void LoadScreenFuntion()
        {
            if (ParentForm != null && !regedit)
            {
                underBar = ParentForm.FnBar;
                ParentForm.ChildForm = this;
                try
                {
                    FormLoadReady();
                }
                catch
                { }
                this.Show();
                underBar.Style = btStyle;
                ParentForm.Style = this.fmStyle;
                ParentForm.CancelBT.Text = CancelText;
                ParentForm.ConfirmBT.Text = ConfirmText;
                ParentForm.NextBT.Text = NextText;
                ParentForm.CancelBT.Image = CancelImage;
                ParentForm.ConfirmBT.Image = ConfirmImage;
                ParentForm.NextBT.Image = NextImage;
                RegistEventHander();
                for (int i = 0; i < underBar.BtList.Count; i++)
                {
                    underBar.BtList[i].Text = fnArgs[i].Context;
                    underBar.BtList[i].Image = fnArgs[i].BackImage;
                    if (fnArgs[i].ClickEventHander != null)
                    {
                        underBar.BtList[i].Click += fnArgs[i].ClickEventHander;
                    }
                }
                regedit = true;
            }
        }

        public void UnLoadScreenFuntion(bool enable=true)
        {
            if (ParentForm != null)
            {
                if (enable)
                {
                    try
                    {
                        FormUnloadReady();
                    }
                    catch
                    {

                    }
                    
                }
                if (CancelClick != null)
                {
                    ParentForm.CancelBT.Click -= CancelClick;//卸载取消事件
                }
                else
                {
                    ParentForm.CancelBT.Click -= CancelButton_Click;//卸载默认事件
                }
                if (ConfirmClick != null)
                {
                    ParentForm.ConfirmBT.Click -= ConfirmClick;
                }
                if (NextClick != null)
                {
                    ParentForm.NextBT.Click -= NextClick;
                }
                for (int i = 0; i < underBar.BtList.Count; i++)
                {
                    if (fnArgs[i].ClickEventHander != null)
                    {
                        underBar.BtList[i].Click -= fnArgs[i].ClickEventHander;
                    }
                }
            }
            regedit = false;
        }

        public virtual bool FormLoadReady()
        {
            return true;
        }
        public virtual bool FormUnloadReady()
        {
            return true;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
            {
                ParentForm.OnCancelClick();
            }
        }

        public void AutoUpdate(int cycTime=10)
        {
            if (cycTick-- < cycTime)
            {
                cycTick = cycTime;
                if (AutoUpdateEventHander != null&&this.Visible)
                {
                    AutoUpdateEventHander(this,null);
                }
            }
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (regedit)
            {
                UnLoadScreenFuntion(false);
            }
        }

    }

}
