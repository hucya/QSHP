namespace QSHP
{
    partial class LockScreenForm
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
            this.exitBt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new QSHP.UI.Ctr.TextBoxEx();
            this.timeLable = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // exitBt
            // 
            this.exitBt.BackColor = System.Drawing.Color.White;
            this.exitBt.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exitBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.exitBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.exitBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBt.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitBt.Location = new System.Drawing.Point(392, 412);
            this.exitBt.Name = "exitBt";
            this.exitBt.Size = new System.Drawing.Size(175, 78);
            this.exitBt.TabIndex = 0;
            this.exitBt.Text = "解 锁";
            this.exitBt.UseVisualStyleBackColor = false;
            this.exitBt.Click += new System.EventHandler(this.ExitBt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(383, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "请输入锁屏密码：";
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.SystemColors.Window;
            this.password.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.password.Location = new System.Drawing.Point(387, 322);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.SetError = false;
            this.password.SetWarn = false;
            this.password.Size = new System.Drawing.Size(187, 39);
            this.password.TabIndex = 1;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeLable
            // 
            this.timeLable.AutoSize = true;
            this.timeLable.Font = new System.Drawing.Font("QSHP", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLable.ForeColor = System.Drawing.Color.White;
            this.timeLable.Location = new System.Drawing.Point(613, 694);
            this.timeLable.Name = "timeLable";
            this.timeLable.Size = new System.Drawing.Size(381, 50);
            this.timeLable.TabIndex = 3;
            this.timeLable.Text = "2017/11/23 10:20:30";
            this.timeLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LockScreenForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.timeLable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.exitBt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LockScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "锁屏";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitBt;
        private UI.Ctr.TextBoxEx password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeLable;
        private System.Windows.Forms.Timer timer1;
    }
}