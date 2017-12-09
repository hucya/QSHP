namespace QSHP.UI.Bld
{
    partial class BladeTestDataEdit
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
            this.panelEx1 = new QSHP.UI.Ctr.PanelEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonEx1 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.waitTime = new QSHP.UI.Ctr.NumberEdit();
            this.zPos = new QSHP.UI.Ctr.NumberEdit();
            this.blowingAirTime = new QSHP.UI.Ctr.NumberEdit();
            this.blowingWaterTime = new QSHP.UI.Ctr.NumberEdit();
            this.yPos = new QSHP.UI.Ctr.NumberEdit();
            this.xPos = new QSHP.UI.Ctr.NumberEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ncsAllowMaxErr = new QSHP.UI.Ctr.NumberEdit();
            this.csAllowMaxErr = new QSHP.UI.Ctr.NumberEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cycCounter = new QSHP.UI.Ctr.NumberEdit();
            this.checkTick = new QSHP.UI.Ctr.NumberEdit();
            this.deFaultMode = new QSHP.UI.Ctr.ComboBoxEx();
            this.autoMode = new QSHP.UI.Ctr.ComboBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.groupBox3);
            this.panelEx1.Controls.Add(this.groupBox2);
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 18F);
            this.panelEx1.LeftMode = false;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(815, 495);
            this.panelEx1.TabIndex = 1;
            this.panelEx1.Text = "测高范围调整";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonEx1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.waitTime);
            this.groupBox3.Controls.Add(this.zPos);
            this.groupBox3.Controls.Add(this.blowingAirTime);
            this.groupBox3.Controls.Add(this.blowingWaterTime);
            this.groupBox3.Controls.Add(this.yPos);
            this.groupBox3.Controls.Add(this.xPos);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(12, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(791, 242);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测高过程参数设置";
            // 
            // buttonEx1
            // 
            this.buttonEx1.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.buttonEx1.Flag = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEx1.LED = false;
            this.buttonEx1.LedLocation = new System.Drawing.Point(4, 4);
            this.buttonEx1.Location = new System.Drawing.Point(300, 185);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.NumText = "";
            this.buttonEx1.Pressed = false;
            this.buttonEx1.Size = new System.Drawing.Size(106, 45);
            this.buttonEx1.TabIndex = 3;
            this.buttonEx1.TabStop = false;
            this.buttonEx1.Text = "坐标提取";
            this.buttonEx1.UsedLed = false;
            this.buttonEx1.UseVisualStyleBackColor = true;
            this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(452, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "非接触式测高";
            // 
            // waitTime
            // 
            this.waitTime.BackColor = System.Drawing.SystemColors.Window;
            this.waitTime.DecPlaces = 3;
            this.waitTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.waitTime.Location = new System.Drawing.Point(612, 150);
            this.waitTime.Maximum = 100F;
            this.waitTime.Minimum = 1F;
            this.waitTime.Name = "waitTime";
            this.waitTime.SetError = false;
            this.waitTime.SetWarn = false;
            this.waitTime.Size = new System.Drawing.Size(106, 29);
            this.waitTime.TabIndex = 2;
            this.waitTime.Text = "5";
            this.waitTime.Unit = "mm";
            this.waitTime.Value = 5F;
            // 
            // zPos
            // 
            this.zPos.BackColor = System.Drawing.SystemColors.Window;
            this.zPos.DecPlaces = 3;
            this.zPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zPos.Location = new System.Drawing.Point(300, 150);
            this.zPos.Maximum = 50F;
            this.zPos.Minimum = 5F;
            this.zPos.Name = "zPos";
            this.zPos.SetError = false;
            this.zPos.SetWarn = false;
            this.zPos.Size = new System.Drawing.Size(106, 29);
            this.zPos.TabIndex = 2;
            this.zPos.Text = "30";
            this.zPos.Unit = "mm";
            this.zPos.Value = 30F;
            // 
            // blowingAirTime
            // 
            this.blowingAirTime.BackColor = System.Drawing.SystemColors.Window;
            this.blowingAirTime.DecPlaces = 3;
            this.blowingAirTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.blowingAirTime.Location = new System.Drawing.Point(612, 107);
            this.blowingAirTime.Maximum = 100F;
            this.blowingAirTime.Minimum = 1F;
            this.blowingAirTime.Name = "blowingAirTime";
            this.blowingAirTime.SetError = false;
            this.blowingAirTime.SetWarn = false;
            this.blowingAirTime.Size = new System.Drawing.Size(106, 29);
            this.blowingAirTime.TabIndex = 2;
            this.blowingAirTime.Text = "6";
            this.blowingAirTime.Unit = "mm";
            this.blowingAirTime.Value = 6F;
            // 
            // blowingWaterTime
            // 
            this.blowingWaterTime.BackColor = System.Drawing.SystemColors.Window;
            this.blowingWaterTime.DecPlaces = 3;
            this.blowingWaterTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.blowingWaterTime.Location = new System.Drawing.Point(612, 65);
            this.blowingWaterTime.Maximum = 100F;
            this.blowingWaterTime.Minimum = 1F;
            this.blowingWaterTime.Name = "blowingWaterTime";
            this.blowingWaterTime.SetError = false;
            this.blowingWaterTime.SetWarn = false;
            this.blowingWaterTime.Size = new System.Drawing.Size(106, 29);
            this.blowingWaterTime.TabIndex = 2;
            this.blowingWaterTime.Text = "10";
            this.blowingWaterTime.Unit = "mm";
            this.blowingWaterTime.Value = 10F;
            // 
            // yPos
            // 
            this.yPos.BackColor = System.Drawing.SystemColors.Window;
            this.yPos.DecPlaces = 3;
            this.yPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yPos.Location = new System.Drawing.Point(300, 107);
            this.yPos.Maximum = 1000F;
            this.yPos.Minimum = 0F;
            this.yPos.Name = "yPos";
            this.yPos.SetError = false;
            this.yPos.SetWarn = false;
            this.yPos.Size = new System.Drawing.Size(106, 29);
            this.yPos.TabIndex = 2;
            this.yPos.Text = "200";
            this.yPos.Unit = "mm";
            this.yPos.Value = 200F;
            // 
            // xPos
            // 
            this.xPos.BackColor = System.Drawing.SystemColors.Window;
            this.xPos.DecPlaces = 3;
            this.xPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xPos.Location = new System.Drawing.Point(300, 65);
            this.xPos.Maximum = 1000F;
            this.xPos.Minimum = 0F;
            this.xPos.Name = "xPos";
            this.xPos.SetError = false;
            this.xPos.SetWarn = false;
            this.xPos.Size = new System.Drawing.Size(106, 29);
            this.xPos.TabIndex = 2;
            this.xPos.Text = "216";
            this.xPos.Unit = "mm";
            this.xPos.Value = 216F;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(452, 153);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 21);
            this.label16.TabIndex = 0;
            this.label16.Text = "等待时间(s):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(144, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 21);
            this.label13.TabIndex = 0;
            this.label13.Text = "Z低速点(mm):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(452, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "吹气时间(s):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(144, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 21);
            this.label12.TabIndex = 0;
            this.label12.Text = "Y轴坐标(mm):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(452, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 21);
            this.label14.TabIndex = 0;
            this.label14.Text = "吹水时间(s):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(144, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "X轴坐标(mm):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "非接触测高位置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ncsAllowMaxErr);
            this.groupBox2.Controls.Add(this.csAllowMaxErr);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(791, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测高范围设置";
            // 
            // ncsAllowMaxErr
            // 
            this.ncsAllowMaxErr.BackColor = System.Drawing.SystemColors.Window;
            this.ncsAllowMaxErr.DecPlaces = 3;
            this.ncsAllowMaxErr.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ncsAllowMaxErr.Location = new System.Drawing.Point(612, 58);
            this.ncsAllowMaxErr.Maximum = 10F;
            this.ncsAllowMaxErr.Minimum = 0.001F;
            this.ncsAllowMaxErr.Name = "ncsAllowMaxErr";
            this.ncsAllowMaxErr.SetError = false;
            this.ncsAllowMaxErr.SetWarn = false;
            this.ncsAllowMaxErr.Size = new System.Drawing.Size(106, 29);
            this.ncsAllowMaxErr.TabIndex = 2;
            this.ncsAllowMaxErr.Text = "0.1";
            this.ncsAllowMaxErr.Unit = "mm";
            this.ncsAllowMaxErr.Value = 0.1F;
            // 
            // csAllowMaxErr
            // 
            this.csAllowMaxErr.BackColor = System.Drawing.SystemColors.Window;
            this.csAllowMaxErr.DecPlaces = 3;
            this.csAllowMaxErr.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.csAllowMaxErr.Location = new System.Drawing.Point(300, 58);
            this.csAllowMaxErr.Maximum = 10F;
            this.csAllowMaxErr.Minimum = 0.001F;
            this.csAllowMaxErr.Name = "csAllowMaxErr";
            this.csAllowMaxErr.SetError = false;
            this.csAllowMaxErr.SetWarn = false;
            this.csAllowMaxErr.Size = new System.Drawing.Size(106, 29);
            this.csAllowMaxErr.TabIndex = 2;
            this.csAllowMaxErr.Text = "0.1";
            this.csAllowMaxErr.Unit = "mm";
            this.csAllowMaxErr.Value = 0.1F;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "最大允许误差(mm):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "最大允许误差(mm):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "非接触式测高";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "接触式测高";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cycCounter);
            this.groupBox1.Controls.Add(this.checkTick);
            this.groupBox1.Controls.Add(this.deFaultMode);
            this.groupBox1.Controls.Add(this.autoMode);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测高模式设置";
            // 
            // cycCounter
            // 
            this.cycCounter.BackColor = System.Drawing.SystemColors.Window;
            this.cycCounter.DecPlaces = 3;
            this.cycCounter.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cycCounter.Location = new System.Drawing.Point(612, 60);
            this.cycCounter.Maximum = 10F;
            this.cycCounter.Minimum = 1F;
            this.cycCounter.Name = "cycCounter";
            this.cycCounter.SetError = false;
            this.cycCounter.SetWarn = false;
            this.cycCounter.Size = new System.Drawing.Size(106, 29);
            this.cycCounter.TabIndex = 2;
            this.cycCounter.Text = "2";
            this.cycCounter.Unit = "mm";
            this.cycCounter.Value = 2F;
            // 
            // checkTick
            // 
            this.checkTick.BackColor = System.Drawing.SystemColors.Window;
            this.checkTick.DecPlaces = 3;
            this.checkTick.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.checkTick.Location = new System.Drawing.Point(300, 63);
            this.checkTick.Maximum = 10F;
            this.checkTick.Minimum = 2F;
            this.checkTick.Name = "checkTick";
            this.checkTick.SetError = false;
            this.checkTick.SetWarn = false;
            this.checkTick.Size = new System.Drawing.Size(106, 29);
            this.checkTick.TabIndex = 2;
            this.checkTick.Text = "3";
            this.checkTick.Unit = "mm";
            this.checkTick.Value = 3F;
            // 
            // deFaultMode
            // 
            this.deFaultMode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.deFaultMode.FormattingEnabled = true;
            this.deFaultMode.Items.AddRange(new object[] {
            "接触式测高",
            "非接触式测高"});
            this.deFaultMode.Location = new System.Drawing.Point(300, 22);
            this.deFaultMode.Name = "deFaultMode";
            this.deFaultMode.Size = new System.Drawing.Size(106, 29);
            this.deFaultMode.TabIndex = 1;
            this.deFaultMode.Text = "接触式测高";
            // 
            // autoMode
            // 
            this.autoMode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.autoMode.FormattingEnabled = true;
            this.autoMode.Items.AddRange(new object[] {
            "自动进入",
            "呼叫管理员",
            "无"});
            this.autoMode.Location = new System.Drawing.Point(612, 22);
            this.autoMode.Name = "autoMode";
            this.autoMode.Size = new System.Drawing.Size(106, 29);
            this.autoMode.TabIndex = 1;
            this.autoMode.Text = "无";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(452, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "重复次数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "检测次数:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(452, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "自动测高模式:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "默认测高模式:";
            // 
            // BladeTestDataEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BT0Content = "圆形工作台";
            this.BT1Content = "方形工作台";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.panelEx1);
            this.Name = "BladeTestDataEdit";
            this.Text = "测高范围调整";
            this.BT0Click += new System.EventHandler(this.BladeTestDataEdit_BT0Click);
            this.BT1Click += new System.EventHandler(this.BladeTestDataEdit_BT1Click);
            this.CancelClick += new System.EventHandler(this.BladeTestDataEdit_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.BladeTestDataEdit_ConfirmClick);
            this.Load += new System.EventHandler(this.BladeTestDataEdit_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctr.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private Ctr.NumberEdit ncsAllowMaxErr;
        private Ctr.NumberEdit csAllowMaxErr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ctr.NumberEdit cycCounter;
        private Ctr.NumberEdit checkTick;
        private Ctr.ComboBoxEx deFaultMode;
        private Ctr.ComboBoxEx autoMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private Ctr.ButtonEx buttonEx1;
        private System.Windows.Forms.Label label10;
        private Ctr.NumberEdit waitTime;
        private Ctr.NumberEdit zPos;
        private Ctr.NumberEdit blowingAirTime;
        private Ctr.NumberEdit blowingWaterTime;
        private Ctr.NumberEdit yPos;
        private Ctr.NumberEdit xPos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
    }
}