namespace QSHP
{
    partial class Logo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logoText = new System.Windows.Forms.Label();
            this.process = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.logoBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new QSHP.UI.Ctr.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonEx4 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.buttonEx2 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.buttonEx3 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.buttonEx1 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskCheck = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.superPassword = new QSHP.UI.Ctr.TextBoxEx();
            this.maskKey = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QSHP.Properties.Resources.logo_1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(89, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(796, 536);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // logoText
            // 
            this.logoText.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.logoText.Location = new System.Drawing.Point(371, 630);
            this.logoText.Name = "logoText";
            this.logoText.Size = new System.Drawing.Size(511, 29);
            this.logoText.TabIndex = 2;
            this.logoText.Text = "hucya@qq.com 版权所有 侵权必究 ";
            this.logoText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // process
            // 
            this.process.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.process.ForeColor = System.Drawing.Color.DarkCyan;
            this.process.Location = new System.Drawing.Point(84, 569);
            this.process.Name = "process";
            this.process.Size = new System.Drawing.Size(798, 29);
            this.process.TabIndex = 2;
            this.process.Text = "系统加载进度 1%";
            this.process.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // logoBar
            // 
            this.logoBar.ForeColor = System.Drawing.Color.HotPink;
            this.logoBar.Location = new System.Drawing.Point(88, 604);
            this.logoBar.Name = "logoBar";
            this.logoBar.Size = new System.Drawing.Size(796, 23);
            this.logoBar.Step = 1;
            this.logoBar.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabPage1);
            this.panel1.Controls.Add(this.tabPage2);
            this.panel1.ItemSize = new System.Drawing.Size(1, 1);
            this.panel1.Location = new System.Drawing.Point(55, 660);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.SelectedIndex = 0;
            this.panel1.Size = new System.Drawing.Size(884, 100);
            this.panel1.TabIndex = 5;
            this.panel1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage1.Controls.Add(this.buttonEx4);
            this.tabPage1.Controls.Add(this.buttonEx2);
            this.tabPage1.Controls.Add(this.buttonEx3);
            this.tabPage1.Controls.Add(this.buttonEx1);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 91);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // buttonEx4
            // 
            this.buttonEx4.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.buttonEx4.Flag = 0;
            this.buttonEx4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEx4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEx4.ForeColor = System.Drawing.Color.Violet;
            this.buttonEx4.LED = false;
            this.buttonEx4.LedLocation = new System.Drawing.Point(4, -9);
            this.buttonEx4.Location = new System.Drawing.Point(658, 18);
            this.buttonEx4.Name = "buttonEx4";
            this.buttonEx4.NumText = "";
            this.buttonEx4.Pressed = false;
            this.buttonEx4.Size = new System.Drawing.Size(132, 53);
            this.buttonEx4.TabIndex = 3;
            this.buttonEx4.TabStop = false;
            this.buttonEx4.Text = "进入系统";
            this.buttonEx4.UsedLed = false;
            this.buttonEx4.UseVisualStyleBackColor = true;
            this.buttonEx4.Click += new System.EventHandler(this.ButtonEx4_Click);
            // 
            // buttonEx2
            // 
            this.buttonEx2.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.buttonEx2.Flag = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEx2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEx2.ForeColor = System.Drawing.Color.SlateGray;
            this.buttonEx2.LED = false;
            this.buttonEx2.LedLocation = new System.Drawing.Point(4, -9);
            this.buttonEx2.Location = new System.Drawing.Point(57, 18);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.NumText = "";
            this.buttonEx2.Pressed = false;
            this.buttonEx2.Size = new System.Drawing.Size(132, 53);
            this.buttonEx2.TabIndex = 3;
            this.buttonEx2.TabStop = false;
            this.buttonEx2.Text = "重新加载";
            this.buttonEx2.UsedLed = false;
            this.buttonEx2.UseVisualStyleBackColor = true;
            this.buttonEx2.Click += new System.EventHandler(this.ReloadBt_Click);
            // 
            // buttonEx3
            // 
            this.buttonEx3.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.buttonEx3.Flag = 0;
            this.buttonEx3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEx3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEx3.ForeColor = System.Drawing.Color.SlateGray;
            this.buttonEx3.LED = false;
            this.buttonEx3.LedLocation = new System.Drawing.Point(4, -9);
            this.buttonEx3.Location = new System.Drawing.Point(454, 18);
            this.buttonEx3.Name = "buttonEx3";
            this.buttonEx3.NumText = "";
            this.buttonEx3.Pressed = false;
            this.buttonEx3.Size = new System.Drawing.Size(132, 53);
            this.buttonEx3.TabIndex = 3;
            this.buttonEx3.TabStop = false;
            this.buttonEx3.Text = "进入后台";
            this.buttonEx3.UsedLed = false;
            this.buttonEx3.UseVisualStyleBackColor = true;
            this.buttonEx3.Click += new System.EventHandler(this.ButtonEx3_Click);
            // 
            // buttonEx1
            // 
            this.buttonEx1.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.buttonEx1.Flag = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEx1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEx1.ForeColor = System.Drawing.Color.SlateBlue;
            this.buttonEx1.LED = false;
            this.buttonEx1.LedLocation = new System.Drawing.Point(4, -9);
            this.buttonEx1.Location = new System.Drawing.Point(248, 18);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.NumText = "";
            this.buttonEx1.Pressed = false;
            this.buttonEx1.Size = new System.Drawing.Size(132, 53);
            this.buttonEx1.TabIndex = 3;
            this.buttonEx1.TabStop = false;
            this.buttonEx1.Text = "关  机";
            this.buttonEx1.UsedLed = false;
            this.buttonEx1.UseVisualStyleBackColor = true;
            this.buttonEx1.Click += new System.EventHandler(this.ExitApplition_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.maskCheck);
            this.tabPage2.Controls.Add(this.superPassword);
            this.tabPage2.Controls.Add(this.maskKey);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 91);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "注册密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "注册秘钥:";
            // 
            // maskCheck
            // 
            this.maskCheck.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.maskCheck.Flag = 0;
            this.maskCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.maskCheck.LED = false;
            this.maskCheck.LedLocation = new System.Drawing.Point(4, 4);
            this.maskCheck.Location = new System.Drawing.Point(615, 27);
            this.maskCheck.Name = "maskCheck";
            this.maskCheck.NumText = "";
            this.maskCheck.Pressed = false;
            this.maskCheck.Size = new System.Drawing.Size(110, 34);
            this.maskCheck.TabIndex = 11;
            this.maskCheck.TabStop = false;
            this.maskCheck.Text = "系统注册";
            this.maskCheck.UsedLed = false;
            this.maskCheck.UseVisualStyleBackColor = true;
            this.maskCheck.Click += new System.EventHandler(this.MaskCheck_Click);
            // 
            // superPassword
            // 
            this.superPassword.BackColor = System.Drawing.SystemColors.Window;
            this.superPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.superPassword.Location = new System.Drawing.Point(450, 30);
            this.superPassword.MaxLength = 10;
            this.superPassword.Name = "superPassword";
            this.superPassword.PasswordChar = '*';
            this.superPassword.SetError = false;
            this.superPassword.SetWarn = false;
            this.superPassword.Size = new System.Drawing.Size(110, 29);
            this.superPassword.TabIndex = 9;
            this.superPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.superPassword.WordWrap = false;
            // 
            // maskKey
            // 
            this.maskKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.maskKey.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.maskKey.Location = new System.Drawing.Point(194, 31);
            this.maskKey.Name = "maskKey";
            this.maskKey.Size = new System.Drawing.Size(142, 27);
            this.maskKey.TabIndex = 8;
            this.maskKey.Text = "xxxxx";
            this.maskKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Logo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.process);
            this.Controls.Add(this.logoText);
            this.Controls.Add(this.logoBar);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Logo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Logo_FormClosing);
            this.Load += new System.EventHandler(this.Logo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label logoText;
        private System.Windows.Forms.Label process;
        private System.Windows.Forms.Timer timer2;
        private UI.Ctr.ButtonEx buttonEx1;
        private UI.Ctr.ButtonEx buttonEx2;
        private UI.Ctr.ButtonEx buttonEx3;
        private UI.Ctr.ButtonEx buttonEx4;
        private UI.Ctr.TabControlEx panel1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private UI.Ctr.ButtonEx maskCheck;
        private UI.Ctr.TextBoxEx superPassword;
        private System.Windows.Forms.Label maskKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar logoBar;
    }
}