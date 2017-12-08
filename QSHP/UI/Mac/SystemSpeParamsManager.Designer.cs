namespace QSHP.UI
{
    partial class SystemSpeParamsManager
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
            this.panelEx1 = new QSHP.UI.Ctr.PanelEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xCutBackAcc = new QSHP.UI.Ctr.NumberEdit();
            this.xCutAcc = new QSHP.UI.Ctr.NumberEdit();
            this.zCutAcc = new QSHP.UI.Ctr.NumberEdit();
            this.zSelfPos = new QSHP.UI.Ctr.NumberEdit();
            this.zCutSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tMaxValue = new QSHP.UI.Ctr.NumberEdit();
            this.tStepPos = new QSHP.UI.Ctr.NumberEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.yFollowAcc = new QSHP.UI.Ctr.NumberEdit();
            this.yFollowSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.xFollowAcc = new QSHP.UI.Ctr.NumberEdit();
            this.xFollowSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yTestOffset = new QSHP.UI.Ctr.NumberEdit();
            this.tTestOffset = new QSHP.UI.Ctr.NumberEdit();
            this.zTestRiseValue = new QSHP.UI.Ctr.NumberEdit();
            this.zTestAcc = new QSHP.UI.Ctr.NumberEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.zTestSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.groupBox2);
            this.panelEx1.Controls.Add(this.groupBox3);
            this.panelEx1.Controls.Add(this.groupBox4);
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 18F);
            this.panelEx1.LeftMode = false;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(815, 495);
            this.panelEx1.TabIndex = 1;
            this.panelEx1.Text = "特殊参数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xCutBackAcc);
            this.groupBox2.Controls.Add(this.xCutAcc);
            this.groupBox2.Controls.Add(this.zCutAcc);
            this.groupBox2.Controls.Add(this.zSelfPos);
            this.groupBox2.Controls.Add(this.zCutSpeed);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 238);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "划切参数";
            // 
            // xCutBackAcc
            // 
            this.xCutBackAcc.BackColor = System.Drawing.SystemColors.Window;
            this.xCutBackAcc.DecPlaces = 3;
            this.xCutBackAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xCutBackAcc.Location = new System.Drawing.Point(245, 166);
            this.xCutBackAcc.Maximum = 1000F;
            this.xCutBackAcc.Minimum = 0.001F;
            this.xCutBackAcc.Name = "xCutBackAcc";
            this.xCutBackAcc.SetError = false;
            this.xCutBackAcc.SetWarn = false;
            this.xCutBackAcc.Size = new System.Drawing.Size(100, 29);
            this.xCutBackAcc.TabIndex = 1;
            this.xCutBackAcc.Text = "2";
            this.xCutBackAcc.Unit = "mm";
            this.xCutBackAcc.Value = 2F;
            // 
            // xCutAcc
            // 
            this.xCutAcc.BackColor = System.Drawing.SystemColors.Window;
            this.xCutAcc.DecPlaces = 3;
            this.xCutAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xCutAcc.Location = new System.Drawing.Point(245, 132);
            this.xCutAcc.Maximum = 1000F;
            this.xCutAcc.Minimum = 0.001F;
            this.xCutAcc.Name = "xCutAcc";
            this.xCutAcc.SetError = false;
            this.xCutAcc.SetWarn = false;
            this.xCutAcc.Size = new System.Drawing.Size(100, 29);
            this.xCutAcc.TabIndex = 1;
            this.xCutAcc.Text = "2";
            this.xCutAcc.Unit = "mm";
            this.xCutAcc.Value = 2F;
            // 
            // zCutAcc
            // 
            this.zCutAcc.BackColor = System.Drawing.SystemColors.Window;
            this.zCutAcc.DecPlaces = 3;
            this.zCutAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zCutAcc.Location = new System.Drawing.Point(245, 96);
            this.zCutAcc.Maximum = 1000F;
            this.zCutAcc.Minimum = 0.001F;
            this.zCutAcc.Name = "zCutAcc";
            this.zCutAcc.SetError = false;
            this.zCutAcc.SetWarn = false;
            this.zCutAcc.Size = new System.Drawing.Size(100, 29);
            this.zCutAcc.TabIndex = 1;
            this.zCutAcc.Text = "1";
            this.zCutAcc.Unit = "mm";
            this.zCutAcc.Value = 1F;
            // 
            // zSelfPos
            // 
            this.zSelfPos.BackColor = System.Drawing.SystemColors.Window;
            this.zSelfPos.DecPlaces = 3;
            this.zSelfPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zSelfPos.Location = new System.Drawing.Point(245, 60);
            this.zSelfPos.Maximum = 1000F;
            this.zSelfPos.Minimum = 0.1F;
            this.zSelfPos.Name = "zSelfPos";
            this.zSelfPos.SetError = false;
            this.zSelfPos.SetWarn = false;
            this.zSelfPos.Size = new System.Drawing.Size(100, 29);
            this.zSelfPos.TabIndex = 1;
            this.zSelfPos.Text = "0.5";
            this.zSelfPos.Unit = "mm";
            this.zSelfPos.Value = 0.5F;
            // 
            // zCutSpeed
            // 
            this.zCutSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.zCutSpeed.DecPlaces = 3;
            this.zCutSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zCutSpeed.Location = new System.Drawing.Point(245, 25);
            this.zCutSpeed.Maximum = 1000F;
            this.zCutSpeed.Minimum = 0.001F;
            this.zCutSpeed.Name = "zCutSpeed";
            this.zCutSpeed.SetError = false;
            this.zCutSpeed.SetWarn = false;
            this.zCutSpeed.Size = new System.Drawing.Size(100, 29);
            this.zCutSpeed.TabIndex = 1;
            this.zCutSpeed.Text = "5";
            this.zCutSpeed.Unit = "mm";
            this.zCutSpeed.Value = 5F;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Z安全距离(mm):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "X返回加速度(mm/s²):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "X划切加速度(mm/s²):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Z轴加速度(mm/s²):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Z轴速度(mm/s):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tMaxValue);
            this.groupBox3.Controls.Add(this.tStepPos);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(403, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "转台设置";
            // 
            // tMaxValue
            // 
            this.tMaxValue.BackColor = System.Drawing.SystemColors.Window;
            this.tMaxValue.DecPlaces = 3;
            this.tMaxValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tMaxValue.Location = new System.Drawing.Point(253, 60);
            this.tMaxValue.Maximum = 720F;
            this.tMaxValue.Minimum = 180F;
            this.tMaxValue.Name = "tMaxValue";
            this.tMaxValue.SetError = false;
            this.tMaxValue.SetWarn = false;
            this.tMaxValue.Size = new System.Drawing.Size(100, 29);
            this.tMaxValue.TabIndex = 1;
            this.tMaxValue.Text = "320";
            this.tMaxValue.Unit = "mm";
            this.tMaxValue.Value = 320F;
            // 
            // tStepPos
            // 
            this.tStepPos.BackColor = System.Drawing.SystemColors.Window;
            this.tStepPos.DecPlaces = 3;
            this.tStepPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tStepPos.Location = new System.Drawing.Point(253, 22);
            this.tStepPos.Maximum = 360F;
            this.tStepPos.Minimum = 0.001F;
            this.tStepPos.Name = "tStepPos";
            this.tStepPos.SetError = false;
            this.tStepPos.SetWarn = false;
            this.tStepPos.Size = new System.Drawing.Size(100, 29);
            this.tStepPos.TabIndex = 1;
            this.tStepPos.Text = "90";
            this.tStepPos.Unit = "mm";
            this.tStepPos.Value = 90F;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "T轴最大转角(°):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "T轴步进(°):";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.yFollowAcc);
            this.groupBox4.Controls.Add(this.yFollowSpeed);
            this.groupBox4.Controls.Add(this.xFollowAcc);
            this.groupBox4.Controls.Add(this.xFollowSpeed);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(403, 141);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(389, 173);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "鼠标跟随";
            // 
            // yFollowAcc
            // 
            this.yFollowAcc.BackColor = System.Drawing.SystemColors.Window;
            this.yFollowAcc.DecPlaces = 3;
            this.yFollowAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yFollowAcc.Location = new System.Drawing.Point(253, 132);
            this.yFollowAcc.Maximum = 100F;
            this.yFollowAcc.Minimum = 0.001F;
            this.yFollowAcc.Name = "yFollowAcc";
            this.yFollowAcc.SetError = false;
            this.yFollowAcc.SetWarn = false;
            this.yFollowAcc.Size = new System.Drawing.Size(100, 29);
            this.yFollowAcc.TabIndex = 1;
            this.yFollowAcc.Text = "1";
            this.yFollowAcc.Unit = "mm";
            this.yFollowAcc.Value = 1F;
            // 
            // yFollowSpeed
            // 
            this.yFollowSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.yFollowSpeed.DecPlaces = 3;
            this.yFollowSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yFollowSpeed.Location = new System.Drawing.Point(253, 97);
            this.yFollowSpeed.Maximum = 1000F;
            this.yFollowSpeed.Minimum = 0.001F;
            this.yFollowSpeed.Name = "yFollowSpeed";
            this.yFollowSpeed.SetError = false;
            this.yFollowSpeed.SetWarn = false;
            this.yFollowSpeed.Size = new System.Drawing.Size(100, 29);
            this.yFollowSpeed.TabIndex = 1;
            this.yFollowSpeed.Text = "40";
            this.yFollowSpeed.Unit = "mm";
            this.yFollowSpeed.Value = 40F;
            // 
            // xFollowAcc
            // 
            this.xFollowAcc.BackColor = System.Drawing.SystemColors.Window;
            this.xFollowAcc.DecPlaces = 3;
            this.xFollowAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xFollowAcc.Location = new System.Drawing.Point(253, 60);
            this.xFollowAcc.Maximum = 100F;
            this.xFollowAcc.Minimum = 0.001F;
            this.xFollowAcc.Name = "xFollowAcc";
            this.xFollowAcc.SetError = false;
            this.xFollowAcc.SetWarn = false;
            this.xFollowAcc.Size = new System.Drawing.Size(100, 29);
            this.xFollowAcc.TabIndex = 1;
            this.xFollowAcc.Text = "2";
            this.xFollowAcc.Unit = "mm";
            this.xFollowAcc.Value = 2F;
            // 
            // xFollowSpeed
            // 
            this.xFollowSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.xFollowSpeed.DecPlaces = 3;
            this.xFollowSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xFollowSpeed.Location = new System.Drawing.Point(253, 25);
            this.xFollowSpeed.Maximum = 1000F;
            this.xFollowSpeed.Minimum = 0.001F;
            this.xFollowSpeed.Name = "xFollowSpeed";
            this.xFollowSpeed.SetError = false;
            this.xFollowSpeed.SetWarn = false;
            this.xFollowSpeed.Size = new System.Drawing.Size(100, 29);
            this.xFollowSpeed.TabIndex = 1;
            this.xFollowSpeed.Text = "80";
            this.xFollowSpeed.Unit = "mm";
            this.xFollowSpeed.Value = 80F;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 21);
            this.label14.TabIndex = 0;
            this.label14.Text = "Y轴加速度(mm/s²):";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(32, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(148, 21);
            this.label16.TabIndex = 0;
            this.label16.Text = "X轴加速度(mm/s²):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 21);
            this.label13.TabIndex = 0;
            this.label13.Text = "Y轴速度(mm/s):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(54, 29);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(126, 21);
            this.label17.TabIndex = 0;
            this.label17.Text = "X轴速度(mm/s):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yTestOffset);
            this.groupBox1.Controls.Add(this.tTestOffset);
            this.groupBox1.Controls.Add(this.zTestRiseValue);
            this.groupBox1.Controls.Add(this.zTestAcc);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.zTestSpeed);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测高参数";
            // 
            // yTestOffset
            // 
            this.yTestOffset.BackColor = System.Drawing.SystemColors.Window;
            this.yTestOffset.DecPlaces = 3;
            this.yTestOffset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yTestOffset.Location = new System.Drawing.Point(245, 166);
            this.yTestOffset.Maximum = 10F;
            this.yTestOffset.Minimum = 0.001F;
            this.yTestOffset.Name = "yTestOffset";
            this.yTestOffset.SetError = false;
            this.yTestOffset.SetWarn = false;
            this.yTestOffset.Size = new System.Drawing.Size(100, 29);
            this.yTestOffset.TabIndex = 1;
            this.yTestOffset.Text = "0.5";
            this.yTestOffset.Unit = "mm";
            this.yTestOffset.Value = 0.5F;
            // 
            // tTestOffset
            // 
            this.tTestOffset.BackColor = System.Drawing.SystemColors.Window;
            this.tTestOffset.DecPlaces = 3;
            this.tTestOffset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tTestOffset.Location = new System.Drawing.Point(245, 132);
            this.tTestOffset.Maximum = 10F;
            this.tTestOffset.Minimum = 0.001F;
            this.tTestOffset.Name = "tTestOffset";
            this.tTestOffset.SetError = false;
            this.tTestOffset.SetWarn = false;
            this.tTestOffset.Size = new System.Drawing.Size(100, 29);
            this.tTestOffset.TabIndex = 1;
            this.tTestOffset.Text = "0.5";
            this.tTestOffset.Unit = "mm";
            this.tTestOffset.Value = 0.5F;
            // 
            // zTestRiseValue
            // 
            this.zTestRiseValue.BackColor = System.Drawing.SystemColors.Window;
            this.zTestRiseValue.DecPlaces = 3;
            this.zTestRiseValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zTestRiseValue.Location = new System.Drawing.Point(245, 97);
            this.zTestRiseValue.Maximum = 10F;
            this.zTestRiseValue.Minimum = 0.001F;
            this.zTestRiseValue.Name = "zTestRiseValue";
            this.zTestRiseValue.SetError = false;
            this.zTestRiseValue.SetWarn = false;
            this.zTestRiseValue.Size = new System.Drawing.Size(100, 29);
            this.zTestRiseValue.TabIndex = 1;
            this.zTestRiseValue.Text = "0.5";
            this.zTestRiseValue.Unit = "mm";
            this.zTestRiseValue.Value = 0.5F;
            // 
            // zTestAcc
            // 
            this.zTestAcc.BackColor = System.Drawing.SystemColors.Window;
            this.zTestAcc.DecPlaces = 3;
            this.zTestAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zTestAcc.Location = new System.Drawing.Point(245, 60);
            this.zTestAcc.Maximum = 1000F;
            this.zTestAcc.Minimum = 0.001F;
            this.zTestAcc.Name = "zTestAcc";
            this.zTestAcc.SetError = false;
            this.zTestAcc.SetWarn = false;
            this.zTestAcc.Size = new System.Drawing.Size(100, 29);
            this.zTestAcc.TabIndex = 1;
            this.zTestAcc.Text = "1";
            this.zTestAcc.Unit = "mm";
            this.zTestAcc.Value = 1F;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 21);
            this.label12.TabIndex = 0;
            this.label12.Text = "方盘Y偏移范围(mm):";
            // 
            // zTestSpeed
            // 
            this.zTestSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.zTestSpeed.DecPlaces = 3;
            this.zTestSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zTestSpeed.Location = new System.Drawing.Point(245, 25);
            this.zTestSpeed.Maximum = 1000F;
            this.zTestSpeed.Minimum = 0.001F;
            this.zTestSpeed.Name = "zTestSpeed";
            this.zTestSpeed.SetError = false;
            this.zTestSpeed.SetWarn = false;
            this.zTestSpeed.Size = new System.Drawing.Size(100, 29);
            this.zTestSpeed.TabIndex = 1;
            this.zTestSpeed.Text = "1";
            this.zTestSpeed.Unit = "mm";
            this.zTestSpeed.Value = 1F;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "圆盘转台偏移范围(°):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "测高上移距离(mm):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Z轴加速度(mm/s²):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Z轴速度(mm/s):";
            // 
            // SystemSpeParamsManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.panelEx1);
            this.Name = "SystemSpeParamsManager";
            this.Text = "特殊参数";
            this.CancelClick += new System.EventHandler(this.SystemSpeParamsManager_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.SystemSpeParamsManager_ConfirmClick);
            this.panelEx1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctr.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private Ctr.NumberEdit xCutBackAcc;
        private Ctr.NumberEdit xCutAcc;
        private Ctr.NumberEdit zCutAcc;
        private Ctr.NumberEdit zCutSpeed;
        private Ctr.NumberEdit zTestAcc;
        private Ctr.NumberEdit zTestSpeed;
        private Ctr.NumberEdit zTestRiseValue;
        private System.Windows.Forms.Label label5;
        private Ctr.NumberEdit zSelfPos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ctr.NumberEdit tStepPos;
        private System.Windows.Forms.Label label11;
        private Ctr.NumberEdit tMaxValue;
        private System.Windows.Forms.Label label9;
        private Ctr.NumberEdit tTestOffset;
        private System.Windows.Forms.Label label10;
        private Ctr.NumberEdit yTestOffset;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private Ctr.NumberEdit yFollowAcc;
        private Ctr.NumberEdit yFollowSpeed;
        private Ctr.NumberEdit xFollowAcc;
        private Ctr.NumberEdit xFollowSpeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}