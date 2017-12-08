using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP
{
    public partial class LockScreenForm : Form
    {
        public LockScreenForm()
        {
            InitializeComponent();
        }

        private void ExitBt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                label1.Text = "密码不能为空";
            }
            else
            {
                string s = Globals.MacData.LockKey;
                if (Com.Checksum.EncryptWithMD5(password.Text).Equals(s))
                {
                    label1.Text = "解锁成功";
                    this.Close();
                }
                else
                {
                    label1.Text = "密码无效，请重新输入";
                    password.Text = string.Empty;
                }
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLable.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
