using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Drawing;
using QSHP.Com;

namespace QSHP.UI.Ctr
{
    public partial class KeyPad : Form
    {
        private bool isNum = false;
        private bool topMost=false;
        public KeyPad()
        {
            InitializeComponent();
            this.Parent = null;
            InitKeyPad();
        }
        private Control editControl = null;
        public Control EditControl
        {
            get
            {
                return editControl;
            }
            set
            {
                editControl = value;
            }
        }
        Dictionary<KeyboardButton, char> charDic = new Dictionary<KeyboardButton, char>();
        Dictionary<char, KeyboardButton> numDic = new Dictionary<char, KeyboardButton>();
        bool numMode = true;
        int childWidth = 0;
        int selfWidth = 0;
        string resetText = string.Empty;
        Rectangle rect = new Rectangle();
        Size screenSize = new Size();
        protected override bool ShowFocusCues
        {
            get
            {
                return false;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x0A000008;
                return cp;
            }
        }

        private void InitKeyPad()
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.FixedHeight, true);
            //SetStyle(ControlStyles.Selectable, false);
            charDic.Clear();
            numDic.Clear();
            childWidth = this.Width - charPanel.Width;
            selfWidth = this.Width;
            charDic.Add(aBt, 'a');
            charDic.Add(bBt, 'b');
            charDic.Add(cBt, 'c');
            charDic.Add(dBt, 'd');
            charDic.Add(eBt, 'e');
            charDic.Add(fBt, 'f');
            charDic.Add(gBt, 'g');
            charDic.Add(hBt, 'h');
            charDic.Add(iBt, 'i');
            charDic.Add(jBt, 'j');
            charDic.Add(kBt, 'k');
            charDic.Add(lBt, 'l');
            charDic.Add(mBt, 'm');
            charDic.Add(nBt, 'n');
            charDic.Add(oBt, 'o');
            charDic.Add(pBt, 'p');
            charDic.Add(qBt, 'q');
            charDic.Add(rBt, 'r');
            charDic.Add(sBt, 's');
            charDic.Add(tBt, 't');
            charDic.Add(uBt, 'u');
            charDic.Add(vBt, 'v');
            charDic.Add(wBt, 'w');
            charDic.Add(xBt, 'x');
            charDic.Add(yBt, 'y');
            charDic.Add(zBt, 'z');
            charDic.Add(NumBt, '.');
            foreach (var item in charDic)
            {
                item.Key.VKCode = (short)item.Value;
            }
            numDic.Add('7', eBt);
            numDic.Add('8', fBt);
            numDic.Add('9', gBt);
            numDic.Add('4', lBt);
            numDic.Add('5', mBt);
            numDic.Add('6', nBt);
            numDic.Add('1', sBt);
            numDic.Add('2', tBt);
            numDic.Add('3', CapBt);
            numDic.Add('-', yBt);
            numDic.Add('0', zBt);
            numDic.Add('.', NumBt);
            numMode = false;
            screenSize.Height = SystemInformation.VirtualScreen.Height;
            screenSize.Width = SystemInformation.VirtualScreen.Width;
        }

        private void NumBt_Click(object sender, EventArgs e)
        {
            if (isNum)
            {
                numMode = true;
                CharBt_Click(NumBt, null);
            }
            else
            {
                numMode = !numMode;
                SetKeyPadNumberMode();
            }
            ResetFormPosition(this.EditControl);
        }

        private void ChangeCharCapsLock(bool caps)
        {
            this.SuspendLayout();
            CapBt.Checked = caps;
            foreach (var item in charDic)
            {
                if (item.Key == NumBt)
                {
                    continue;
                }
                if (caps)
                {
                    item.Key.VKCode = (short)(item.Value - 32);//转换成大写
                }
                else
                {
                    item.Key.VKCode = (short)(item.Value);//转换成小写 
                }
                item.Key.Text = ((char)item.Key.VKCode).ToString();
            }
            this.ResumeLayout(false);
        }

        public void SetKeyPadNumberMode()
        {
            if (numMode)
            {
                charPanel.Visible = false;
                this.Width = childWidth;
                tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.AutoSize;
            }
            else
            {
                charPanel.Visible = true;
                this.Width = selfWidth;
                tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
            }
            this.SuspendLayout();
            foreach (var item in numDic)
            {
                if (numMode)
                {
                    item.Value.Text = item.Key.ToString();
                    item.Value.VKCode = (short)item.Key;
                }
                else
                {
                    if (charDic.ContainsKey(item.Value))
                    {
                        item.Value.VKCode = (short)charDic[item.Value];
                    }
                }
            }
            if (!numMode)
            {
             
                ChangeCharCapsLock(Console.CapsLock);
                CapBt.Text = "Cap";
            }
            else
            {
                CapBt.Checked = false;
            }
            NumBt.Text = numMode ? "abc" : "123";
            this.ResumeLayout(false);
        }

        private void ResetFormPosition(Control ctr)
        {
            if (ctr == null)
            {
                return;
            }
            if (ctr != this.editControl)
            {
                if (ctr is NumberEdit || ctr.Parent is UpDownBase)
                {
                    numMode = true;
                    isNum = true;
                    SetKeyPadNumberMode();
                    NumBt.Text = ".";
                }
                else
                {
                    numMode = false;
                    isNum = false;
                    SetKeyPadNumberMode();
                }
            }
            if (NativeMethods.GetWindowRect(ctr.Handle, out rect))
            {
                Point pos = new Point(rect.Left + ctr.Width, rect.Y + ctr.Height);
                if (pos.Y + this.Height > screenSize.Height)
                {
                    pos.Y = rect.Y - this.Height;
                }
                if (pos.X + this.Width > screenSize.Width)
                {
                    pos.X = screenSize.Width - this.Width;
                }
                this.Location = pos;
            }
        }

        private void CapBt_Click(object sender, EventArgs e)
        {
            if (numMode)
            {
                CharBt_Click(sender, e);
            }
            else
            {
                bool flag = Console.CapsLock;
                NativeMethods.keyboardEvent(0x14, 0x15, 1, 0);
                NativeMethods.keyboardEvent(0x14, 0x15, 2, 0);
                ChangeCharCapsLock(!flag);
            }
        }

        private void EnBt_Click(object sender, EventArgs e)
        {
            NativeMethods.PostMessage(editControl.Handle, KeyMsg.WM_CHAR, (int)Keys.Enter, 0);
            Hide();
        }

        private void BkBT_Click(object sender, EventArgs e)
        {
            NativeMethods.PostMessage(editControl.Handle, KeyMsg.WM_CHAR, (int)Keys.Back, 0);
        }

        private void DeBT_Click(object sender, EventArgs e)
        {
            NativeMethods.PostMessage(editControl.Handle, KeyMsg.WM_CHAR, (int)Keys.Delete, 0);
        }

        private void LeBt_Click(object sender, EventArgs e)
        {
            NativeMethods.PostMessage(editControl.Handle, KeyMsg.WM_KEYDOWN, (int)Keys.Left, 0);
        }

        private void RiBT_Click(object sender, EventArgs e)
        {
            NativeMethods.PostMessage(editControl.Handle, KeyMsg.WM_KEYDOWN, (int)Keys.Right, 0);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.editControl.Text = resetText;
            NativeMethods.PostMessage(editControl.Handle, KeyMsg.WM_KEYDOWN, (int)Keys.End, 0);
        }

        private void ClrBt_Click(object sender, EventArgs e)
        {
            this.editControl.ResetText();
        }

        private void CharBt_Click(object sender, EventArgs e)
        {
            KeyboardButton but = sender as KeyboardButton;
            NativeMethods.PostMessage(editControl.Handle, KeyMsg.WM_SETFOCUS, 0, 0);
            NativeMethods.PostMessage(editControl.Handle, KeyMsg.WM_CHAR, but.VKCode, 0);
        }

        public void Show(Control ctr)
        {
            if (ctr == null)
            {
                return;
            }
            ResetFormPosition(ctr);
            if (this.editControl != ctr)
            {
                if (this.editControl != null && this.editControl.FindForm() != null)
                {
                    this.editControl.FindForm().LocationChanged -= new EventHandler(EditControl_Move);
                }
                this.editControl = ctr;
                resetText = ctr.Text;
                if (this.editControl != null && this.editControl.FindForm() != null)
                {
                    this.editControl.FindForm().LocationChanged += new EventHandler(EditControl_Move);
                }
                
                this.Visible = true;
                NativeMethods.PostMessage(editControl.Handle, KeyMsg.EM_SETSEL, 0, -1);
            }
            topMost = this.editControl.FindForm().TopMost;
            if (topMost)
            {
                this.editControl.FindForm().TopMost = false;
                this.TopMost = true;
            }
            if (!this.editControl.Focused)
            {
                this.editControl.Focus();
            }
        }

        void EditControl_Move(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)delegate ()
            {
                ResetFormPosition(this.editControl);
            });
        }

        public new void Hide()
        {
            if (this.Visible)
            {
                this.Visible = false;
                if (this.editControl != null && this.editControl.FindForm() != null)
                {
                    this.editControl.FindForm().TopMost = topMost;
                    topMost = false;
                    this.editControl.FindForm().LocationChanged -= new EventHandler(EditControl_Move);
                    NativeMethods.SendMessage(this.editControl.Handle, KeyMsg.WM_KILLFOCUS, 0, 0);
                }
                this.editControl = null;
                this.resetText = string.Empty;
                GC.Collect();
            }
        }

        private void KeyPad_Load(object sender, EventArgs e)
        {
            ResetFormPosition(this.editControl);
        }
    }

    public static class KeyMsg
    {
        public const int WM_ACTIVATE = 0x0006;
        public const int WM_SHOWWINDOW = 0x018;
        public const int WA_INACTIVE = 0;
        public const int WA_ACTIVE = 1;
        public const int WA_CLICKACTIVE = 2;
        public const int MA_NOACTIVATE = 3;
        public const int WM_MOUSEACTIVE = 0x21;
        public const int WM_CHILDACTIVATE = 0x22;
        public const int WM_SETFOCUS = 0x007;
        public const int WM_KILLFOCUS = 0x0008;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_CHAR = 0x0102;
        public const int WM_DEADCHAR = 0x0103;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;
        public const int WM_SYSCHAR = 0x0106;
        public const int WM_SYSDEADCHAR = 0x0107;
        public const int WM_KEYLAST = 0x0108;
        public const int WM_MOUSEFIRST = 0x0200;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MBUTTONDBLCLK = 0x0209;
        public const int EM_SETSEL = 0xB1;
        public const short KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const short KEYEVENTF_KEYUP = 0x0002;
    }
}
