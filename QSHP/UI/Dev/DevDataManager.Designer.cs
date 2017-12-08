namespace QSHP.UI
{
    partial class DevDataManager
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
            this.heightCCD = new System.Windows.Forms.GroupBox();
            this.hCenterX = new QSHP.UI.Ctr.NumberEdit();
            this.hCenterY = new QSHP.UI.Ctr.NumberEdit();
            this.hPix = new QSHP.UI.Ctr.NumberEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lowCCDSet = new System.Windows.Forms.GroupBox();
            this.lCenterX = new QSHP.UI.Ctr.NumberEdit();
            this.lCenterY = new QSHP.UI.Ctr.NumberEdit();
            this.lPix = new QSHP.UI.Ctr.NumberEdit();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.spdReadyTime = new QSHP.UI.Ctr.NumberEdit();
            this.CutTime = new QSHP.UI.Ctr.NumberEdit();
            this.testTime = new QSHP.UI.Ctr.NumberEdit();
            this.spdAxis = new QSHP.UI.Ctr.NumberEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.zlift = new System.Windows.Forms.CheckBox();
            this.unloadVacuum = new System.Windows.Forms.CheckBox();
            this.cutPauseCloseCutwater = new System.Windows.Forms.CheckBox();
            this.resumeCutCloseBuzzer = new System.Windows.Forms.CheckBox();
            this.cutStopCloseWater = new System.Windows.Forms.CheckBox();
            this.testNoCheckAir = new System.Windows.Forms.CheckBox();
            this.doorProtect = new System.Windows.Forms.CheckBox();
            this.leakWaterChecked = new System.Windows.Forms.CheckBox();
            this.cutWaterChecked = new System.Windows.Forms.CheckBox();
            this.buzzerUsed = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlAcc = new QSHP.UI.Ctr.NumberEdit();
            this.zlAcc = new QSHP.UI.Ctr.NumberEdit();
            this.ylAcc = new QSHP.UI.Ctr.NumberEdit();
            this.xlAcc = new QSHP.UI.Ctr.NumberEdit();
            this.tlSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.zlSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.ylSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.xlSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.tAcc = new QSHP.UI.Ctr.NumberEdit();
            this.zAcc = new QSHP.UI.Ctr.NumberEdit();
            this.yAcc = new QSHP.UI.Ctr.NumberEdit();
            this.xAcc = new QSHP.UI.Ctr.NumberEdit();
            this.tSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.zSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.ySpeed = new QSHP.UI.Ctr.NumberEdit();
            this.xSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            this.heightCCD.SuspendLayout();
            this.lowCCDSet.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.heightCCD);
            this.panelEx1.Controls.Add(this.lowCCDSet);
            this.panelEx1.Controls.Add(this.groupBox3);
            this.panelEx1.Controls.Add(this.groupBox5);
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 18F);
            this.panelEx1.LeftMode = false;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(815, 495);
            this.panelEx1.TabIndex = 0;
            this.panelEx1.Text = "设备参数";
            // 
            // heightCCD
            // 
            this.heightCCD.Controls.Add(this.hCenterX);
            this.heightCCD.Controls.Add(this.hCenterY);
            this.heightCCD.Controls.Add(this.hPix);
            this.heightCCD.Controls.Add(this.label20);
            this.heightCCD.Controls.Add(this.label21);
            this.heightCCD.Controls.Add(this.label22);
            this.heightCCD.Location = new System.Drawing.Point(499, 176);
            this.heightCCD.Name = "heightCCD";
            this.heightCCD.Size = new System.Drawing.Size(303, 134);
            this.heightCCD.TabIndex = 5;
            this.heightCCD.TabStop = false;
            this.heightCCD.Text = "高倍显微镜设置";
            // 
            // hCenterX
            // 
            this.hCenterX.BackColor = System.Drawing.SystemColors.Window;
            this.hCenterX.DecPlaces = 3;
            this.hCenterX.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.hCenterX.Location = new System.Drawing.Point(186, 22);
            this.hCenterX.Maximum = 1000F;
            this.hCenterX.Minimum = 0.001F;
            this.hCenterX.Name = "hCenterX";
            this.hCenterX.SetError = false;
            this.hCenterX.SetWarn = false;
            this.hCenterX.Size = new System.Drawing.Size(90, 29);
            this.hCenterX.TabIndex = 22;
            this.hCenterX.Text = "260";
            this.hCenterX.Unit = "mm";
            this.hCenterX.Value = 260F;
            // 
            // hCenterY
            // 
            this.hCenterY.BackColor = System.Drawing.SystemColors.Window;
            this.hCenterY.DecPlaces = 3;
            this.hCenterY.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.hCenterY.Location = new System.Drawing.Point(186, 59);
            this.hCenterY.Maximum = 1000F;
            this.hCenterY.Minimum = 0.001F;
            this.hCenterY.Name = "hCenterY";
            this.hCenterY.SetError = false;
            this.hCenterY.SetWarn = false;
            this.hCenterY.Size = new System.Drawing.Size(90, 29);
            this.hCenterY.TabIndex = 21;
            this.hCenterY.Text = "202";
            this.hCenterY.Unit = "mm";
            this.hCenterY.Value = 202F;
            // 
            // hPix
            // 
            this.hPix.BackColor = System.Drawing.SystemColors.Window;
            this.hPix.DecPlaces = 6;
            this.hPix.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.hPix.Location = new System.Drawing.Point(186, 96);
            this.hPix.Maximum = 1000F;
            this.hPix.Minimum = 0.001F;
            this.hPix.Name = "hPix";
            this.hPix.SetError = false;
            this.hPix.SetWarn = false;
            this.hPix.Size = new System.Drawing.Size(90, 29);
            this.hPix.TabIndex = 20;
            this.hPix.Text = "0.00133";
            this.hPix.Unit = "mm";
            this.hPix.Value = 0.00133F;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(144, 21);
            this.label20.TabIndex = 19;
            this.label20.Text = "中心坐标X轴(mm):";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 99);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(147, 21);
            this.label21.TabIndex = 17;
            this.label21.Text = "像素系数(mm/pix):";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(20, 63);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(144, 21);
            this.label22.TabIndex = 18;
            this.label22.Text = "中心坐标Y轴(mm):";
            // 
            // lowCCDSet
            // 
            this.lowCCDSet.Controls.Add(this.lCenterX);
            this.lowCCDSet.Controls.Add(this.lCenterY);
            this.lowCCDSet.Controls.Add(this.lPix);
            this.lowCCDSet.Controls.Add(this.label19);
            this.lowCCDSet.Controls.Add(this.label9);
            this.lowCCDSet.Controls.Add(this.label10);
            this.lowCCDSet.Location = new System.Drawing.Point(499, 34);
            this.lowCCDSet.Name = "lowCCDSet";
            this.lowCCDSet.Size = new System.Drawing.Size(303, 132);
            this.lowCCDSet.TabIndex = 6;
            this.lowCCDSet.TabStop = false;
            this.lowCCDSet.Text = "低倍显微镜设置";
            // 
            // lCenterX
            // 
            this.lCenterX.BackColor = System.Drawing.SystemColors.Window;
            this.lCenterX.DecPlaces = 3;
            this.lCenterX.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lCenterX.Location = new System.Drawing.Point(186, 24);
            this.lCenterX.Maximum = 1000F;
            this.lCenterX.Minimum = 260F;
            this.lCenterX.Name = "lCenterX";
            this.lCenterX.SetError = false;
            this.lCenterX.SetWarn = false;
            this.lCenterX.Size = new System.Drawing.Size(90, 29);
            this.lCenterX.TabIndex = 22;
            this.lCenterX.Text = "260";
            this.lCenterX.Unit = "mm";
            this.lCenterX.Value = 260F;
            // 
            // lCenterY
            // 
            this.lCenterY.BackColor = System.Drawing.SystemColors.Window;
            this.lCenterY.DecPlaces = 3;
            this.lCenterY.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lCenterY.Location = new System.Drawing.Point(186, 59);
            this.lCenterY.Maximum = 1000F;
            this.lCenterY.Minimum = 0.001F;
            this.lCenterY.Name = "lCenterY";
            this.lCenterY.SetError = false;
            this.lCenterY.SetWarn = false;
            this.lCenterY.Size = new System.Drawing.Size(90, 29);
            this.lCenterY.TabIndex = 21;
            this.lCenterY.Text = "202";
            this.lCenterY.Unit = "mm";
            this.lCenterY.Value = 202F;
            // 
            // lPix
            // 
            this.lPix.BackColor = System.Drawing.SystemColors.Window;
            this.lPix.DecPlaces = 6;
            this.lPix.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lPix.Location = new System.Drawing.Point(186, 95);
            this.lPix.Maximum = 1000F;
            this.lPix.Minimum = 0.001F;
            this.lPix.Name = "lPix";
            this.lPix.SetError = false;
            this.lPix.SetWarn = false;
            this.lPix.Size = new System.Drawing.Size(90, 29);
            this.lPix.TabIndex = 20;
            this.lPix.Text = "0.00266";
            this.lPix.Unit = "mm";
            this.lPix.Value = 0.00266F;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(144, 21);
            this.label19.TabIndex = 19;
            this.label19.Text = "中心坐标X轴(mm):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 21);
            this.label9.TabIndex = 17;
            this.label9.Text = "像素系数(mm/pix):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 21);
            this.label10.TabIndex = 18;
            this.label10.Text = "中心坐标Y轴(mm):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.spdReadyTime);
            this.groupBox3.Controls.Add(this.CutTime);
            this.groupBox3.Controls.Add(this.testTime);
            this.groupBox3.Controls.Add(this.spdAxis);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Location = new System.Drawing.Point(498, 319);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 170);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "主轴参数";
            // 
            // spdReadyTime
            // 
            this.spdReadyTime.BackColor = System.Drawing.SystemColors.Window;
            this.spdReadyTime.DecPlaces = 0;
            this.spdReadyTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.spdReadyTime.Location = new System.Drawing.Point(186, 134);
            this.spdReadyTime.Maximum = 1000F;
            this.spdReadyTime.Minimum = 0F;
            this.spdReadyTime.Name = "spdReadyTime";
            this.spdReadyTime.SetError = false;
            this.spdReadyTime.SetWarn = false;
            this.spdReadyTime.Size = new System.Drawing.Size(90, 29);
            this.spdReadyTime.TabIndex = 2;
            this.spdReadyTime.Text = "30";
            this.spdReadyTime.Unit = "mm";
            this.spdReadyTime.Value = 30F;
            // 
            // CutTime
            // 
            this.CutTime.BackColor = System.Drawing.SystemColors.Window;
            this.CutTime.DecPlaces = 0;
            this.CutTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.CutTime.Location = new System.Drawing.Point(186, 62);
            this.CutTime.Maximum = 1000F;
            this.CutTime.Minimum = 1F;
            this.CutTime.Name = "CutTime";
            this.CutTime.SetError = false;
            this.CutTime.SetWarn = false;
            this.CutTime.Size = new System.Drawing.Size(90, 29);
            this.CutTime.TabIndex = 2;
            this.CutTime.Text = "20";
            this.CutTime.Unit = "mm";
            this.CutTime.Value = 20F;
            // 
            // testTime
            // 
            this.testTime.BackColor = System.Drawing.SystemColors.Window;
            this.testTime.DecPlaces = 0;
            this.testTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.testTime.Location = new System.Drawing.Point(186, 26);
            this.testTime.Maximum = 1000F;
            this.testTime.Minimum = 1F;
            this.testTime.Name = "testTime";
            this.testTime.SetError = false;
            this.testTime.SetWarn = false;
            this.testTime.Size = new System.Drawing.Size(90, 29);
            this.testTime.TabIndex = 2;
            this.testTime.Text = "20";
            this.testTime.Unit = "mm";
            this.testTime.Value = 20F;
            // 
            // spdAxis
            // 
            this.spdAxis.BackColor = System.Drawing.SystemColors.Window;
            this.spdAxis.DecPlaces = 3;
            this.spdAxis.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.spdAxis.Location = new System.Drawing.Point(186, 97);
            this.spdAxis.Maximum = 50F;
            this.spdAxis.Minimum = -50F;
            this.spdAxis.Name = "spdAxis";
            this.spdAxis.SetError = false;
            this.spdAxis.SetWarn = false;
            this.spdAxis.Size = new System.Drawing.Size(90, 29);
            this.spdAxis.TabIndex = 2;
            this.spdAxis.Text = "-10";
            this.spdAxis.Unit = "mm";
            this.spdAxis.Value = -10F;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 21);
            this.label16.TabIndex = 0;
            this.label16.Text = "划切稳定时间(s):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 21);
            this.label12.TabIndex = 0;
            this.label12.Text = "测高稳定时间(s):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 138);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(149, 21);
            this.label17.TabIndex = 0;
            this.label17.Text = "系统暖机时间(min):";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(150, 21);
            this.label18.TabIndex = 0;
            this.label18.Text = "主轴中心坐标(mm):";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.zlift);
            this.groupBox5.Controls.Add(this.unloadVacuum);
            this.groupBox5.Controls.Add(this.cutPauseCloseCutwater);
            this.groupBox5.Controls.Add(this.resumeCutCloseBuzzer);
            this.groupBox5.Controls.Add(this.cutStopCloseWater);
            this.groupBox5.Controls.Add(this.testNoCheckAir);
            this.groupBox5.Controls.Add(this.doorProtect);
            this.groupBox5.Controls.Add(this.leakWaterChecked);
            this.groupBox5.Controls.Add(this.cutWaterChecked);
            this.groupBox5.Controls.Add(this.buzzerUsed);
            this.groupBox5.Location = new System.Drawing.Point(13, 227);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(479, 262);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "设备配置";
            // 
            // zlift
            // 
            this.zlift.AutoSize = true;
            this.zlift.Location = new System.Drawing.Point(286, 98);
            this.zlift.Name = "zlift";
            this.zlift.Size = new System.Drawing.Size(157, 25);
            this.zlift.TabIndex = 0;
            this.zlift.Text = "双向划切划切抬刀";
            this.zlift.UseVisualStyleBackColor = true;
            // 
            // unloadVacuum
            // 
            this.unloadVacuum.AutoSize = true;
            this.unloadVacuum.Location = new System.Drawing.Point(286, 160);
            this.unloadVacuum.Name = "unloadVacuum";
            this.unloadVacuum.Size = new System.Drawing.Size(157, 25);
            this.unloadVacuum.TabIndex = 0;
            this.unloadVacuum.Text = "划切完成卸载真空";
            this.unloadVacuum.UseVisualStyleBackColor = true;
            // 
            // cutPauseCloseCutwater
            // 
            this.cutPauseCloseCutwater.AutoSize = true;
            this.cutPauseCloseCutwater.Location = new System.Drawing.Point(286, 129);
            this.cutPauseCloseCutwater.Name = "cutPauseCloseCutwater";
            this.cutPauseCloseCutwater.Size = new System.Drawing.Size(173, 25);
            this.cutPauseCloseCutwater.TabIndex = 0;
            this.cutPauseCloseCutwater.Text = "划切暂停关闭切割水";
            this.cutPauseCloseCutwater.UseVisualStyleBackColor = true;
            // 
            // resumeCutCloseBuzzer
            // 
            this.resumeCutCloseBuzzer.AutoSize = true;
            this.resumeCutCloseBuzzer.Location = new System.Drawing.Point(46, 160);
            this.resumeCutCloseBuzzer.Name = "resumeCutCloseBuzzer";
            this.resumeCutCloseBuzzer.Size = new System.Drawing.Size(173, 25);
            this.resumeCutCloseBuzzer.TabIndex = 0;
            this.resumeCutCloseBuzzer.Text = "继续划切关闭蜂鸣器";
            this.resumeCutCloseBuzzer.UseVisualStyleBackColor = true;
            // 
            // cutStopCloseWater
            // 
            this.cutStopCloseWater.AutoSize = true;
            this.cutStopCloseWater.Location = new System.Drawing.Point(46, 129);
            this.cutStopCloseWater.Name = "cutStopCloseWater";
            this.cutStopCloseWater.Size = new System.Drawing.Size(173, 25);
            this.cutStopCloseWater.TabIndex = 0;
            this.cutStopCloseWater.Text = "划切停止关闭切割水";
            this.cutStopCloseWater.UseVisualStyleBackColor = true;
            // 
            // testNoCheckAir
            // 
            this.testNoCheckAir.AutoSize = true;
            this.testNoCheckAir.Location = new System.Drawing.Point(46, 98);
            this.testNoCheckAir.Name = "testNoCheckAir";
            this.testNoCheckAir.Size = new System.Drawing.Size(157, 25);
            this.testNoCheckAir.TabIndex = 0;
            this.testNoCheckAir.Text = "允许放置工件测高";
            this.testNoCheckAir.UseVisualStyleBackColor = true;
            // 
            // doorProtect
            // 
            this.doorProtect.AutoSize = true;
            this.doorProtect.Location = new System.Drawing.Point(286, 67);
            this.doorProtect.Name = "doorProtect";
            this.doorProtect.Size = new System.Drawing.Size(125, 25);
            this.doorProtect.TabIndex = 0;
            this.doorProtect.Text = "启用仓门保护";
            this.doorProtect.UseVisualStyleBackColor = true;
            // 
            // leakWaterChecked
            // 
            this.leakWaterChecked.AutoSize = true;
            this.leakWaterChecked.Location = new System.Drawing.Point(286, 36);
            this.leakWaterChecked.Name = "leakWaterChecked";
            this.leakWaterChecked.Size = new System.Drawing.Size(125, 25);
            this.leakWaterChecked.TabIndex = 0;
            this.leakWaterChecked.Text = "启用漏水检测";
            this.leakWaterChecked.UseVisualStyleBackColor = true;
            // 
            // cutWaterChecked
            // 
            this.cutWaterChecked.AutoSize = true;
            this.cutWaterChecked.Location = new System.Drawing.Point(46, 67);
            this.cutWaterChecked.Name = "cutWaterChecked";
            this.cutWaterChecked.Size = new System.Drawing.Size(141, 25);
            this.cutWaterChecked.TabIndex = 0;
            this.cutWaterChecked.Text = "启用切割水检测";
            this.cutWaterChecked.UseVisualStyleBackColor = true;
            // 
            // buzzerUsed
            // 
            this.buzzerUsed.AutoSize = true;
            this.buzzerUsed.Location = new System.Drawing.Point(46, 36);
            this.buzzerUsed.Name = "buzzerUsed";
            this.buzzerUsed.Size = new System.Drawing.Size(141, 25);
            this.buzzerUsed.TabIndex = 0;
            this.buzzerUsed.Text = "启用蜂鸣器报警";
            this.buzzerUsed.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tlAcc);
            this.groupBox1.Controls.Add(this.zlAcc);
            this.groupBox1.Controls.Add(this.ylAcc);
            this.groupBox1.Controls.Add(this.xlAcc);
            this.groupBox1.Controls.Add(this.tlSpeed);
            this.groupBox1.Controls.Add(this.zlSpeed);
            this.groupBox1.Controls.Add(this.ylSpeed);
            this.groupBox1.Controls.Add(this.xlSpeed);
            this.groupBox1.Controls.Add(this.tAcc);
            this.groupBox1.Controls.Add(this.zAcc);
            this.groupBox1.Controls.Add(this.yAcc);
            this.groupBox1.Controls.Add(this.xAcc);
            this.groupBox1.Controls.Add(this.tSpeed);
            this.groupBox1.Controls.Add(this.zSpeed);
            this.groupBox1.Controls.Add(this.ySpeed);
            this.groupBox1.Controls.Add(this.xSpeed);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "速度设置面板";
            // 
            // tlAcc
            // 
            this.tlAcc.BackColor = System.Drawing.SystemColors.Window;
            this.tlAcc.DecPlaces = 3;
            this.tlAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tlAcc.Location = new System.Drawing.Point(394, 152);
            this.tlAcc.Maximum = 1000F;
            this.tlAcc.Minimum = 0.001F;
            this.tlAcc.Name = "tlAcc";
            this.tlAcc.SetError = false;
            this.tlAcc.SetWarn = false;
            this.tlAcc.Size = new System.Drawing.Size(72, 29);
            this.tlAcc.TabIndex = 2;
            this.tlAcc.Text = "0.5";
            this.tlAcc.Unit = "mm";
            this.tlAcc.Value = 0.5F;
            // 
            // zlAcc
            // 
            this.zlAcc.BackColor = System.Drawing.SystemColors.Window;
            this.zlAcc.DecPlaces = 3;
            this.zlAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zlAcc.Location = new System.Drawing.Point(316, 152);
            this.zlAcc.Maximum = 1000F;
            this.zlAcc.Minimum = 0.001F;
            this.zlAcc.Name = "zlAcc";
            this.zlAcc.SetError = false;
            this.zlAcc.SetWarn = false;
            this.zlAcc.Size = new System.Drawing.Size(72, 29);
            this.zlAcc.TabIndex = 2;
            this.zlAcc.Text = "0.5";
            this.zlAcc.Unit = "mm";
            this.zlAcc.Value = 0.5F;
            // 
            // ylAcc
            // 
            this.ylAcc.BackColor = System.Drawing.SystemColors.Window;
            this.ylAcc.DecPlaces = 3;
            this.ylAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ylAcc.Location = new System.Drawing.Point(238, 152);
            this.ylAcc.Maximum = 1000F;
            this.ylAcc.Minimum = 0.001F;
            this.ylAcc.Name = "ylAcc";
            this.ylAcc.SetError = false;
            this.ylAcc.SetWarn = false;
            this.ylAcc.Size = new System.Drawing.Size(72, 29);
            this.ylAcc.TabIndex = 2;
            this.ylAcc.Text = "0.5";
            this.ylAcc.Unit = "mm";
            this.ylAcc.Value = 0.5F;
            // 
            // xlAcc
            // 
            this.xlAcc.BackColor = System.Drawing.SystemColors.Window;
            this.xlAcc.DecPlaces = 3;
            this.xlAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xlAcc.Location = new System.Drawing.Point(160, 152);
            this.xlAcc.Maximum = 1000F;
            this.xlAcc.Minimum = 0.001F;
            this.xlAcc.Name = "xlAcc";
            this.xlAcc.SetError = false;
            this.xlAcc.SetWarn = false;
            this.xlAcc.Size = new System.Drawing.Size(72, 29);
            this.xlAcc.TabIndex = 2;
            this.xlAcc.Text = "1";
            this.xlAcc.Unit = "mm";
            this.xlAcc.Value = 1F;
            // 
            // tlSpeed
            // 
            this.tlSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.tlSpeed.DecPlaces = 3;
            this.tlSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tlSpeed.Location = new System.Drawing.Point(394, 117);
            this.tlSpeed.Maximum = 1000F;
            this.tlSpeed.Minimum = 0.001F;
            this.tlSpeed.Name = "tlSpeed";
            this.tlSpeed.SetError = false;
            this.tlSpeed.SetWarn = false;
            this.tlSpeed.Size = new System.Drawing.Size(72, 29);
            this.tlSpeed.TabIndex = 2;
            this.tlSpeed.Text = "2";
            this.tlSpeed.Unit = "mm";
            this.tlSpeed.Value = 2F;
            // 
            // zlSpeed
            // 
            this.zlSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.zlSpeed.DecPlaces = 3;
            this.zlSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zlSpeed.Location = new System.Drawing.Point(316, 117);
            this.zlSpeed.Maximum = 1000F;
            this.zlSpeed.Minimum = 0.001F;
            this.zlSpeed.Name = "zlSpeed";
            this.zlSpeed.SetError = false;
            this.zlSpeed.SetWarn = false;
            this.zlSpeed.Size = new System.Drawing.Size(72, 29);
            this.zlSpeed.TabIndex = 2;
            this.zlSpeed.Text = "1.5";
            this.zlSpeed.Unit = "mm";
            this.zlSpeed.Value = 1.5F;
            // 
            // ylSpeed
            // 
            this.ylSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.ylSpeed.DecPlaces = 3;
            this.ylSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ylSpeed.Location = new System.Drawing.Point(238, 117);
            this.ylSpeed.Maximum = 1000F;
            this.ylSpeed.Minimum = 0.001F;
            this.ylSpeed.Name = "ylSpeed";
            this.ylSpeed.SetError = false;
            this.ylSpeed.SetWarn = false;
            this.ylSpeed.Size = new System.Drawing.Size(72, 29);
            this.ylSpeed.TabIndex = 2;
            this.ylSpeed.Text = "0.05";
            this.ylSpeed.Unit = "mm";
            this.ylSpeed.Value = 0.05F;
            // 
            // xlSpeed
            // 
            this.xlSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.xlSpeed.DecPlaces = 3;
            this.xlSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xlSpeed.Location = new System.Drawing.Point(160, 117);
            this.xlSpeed.Maximum = 1000F;
            this.xlSpeed.Minimum = 0.001F;
            this.xlSpeed.Name = "xlSpeed";
            this.xlSpeed.SetError = false;
            this.xlSpeed.SetWarn = false;
            this.xlSpeed.Size = new System.Drawing.Size(72, 29);
            this.xlSpeed.TabIndex = 2;
            this.xlSpeed.Text = "2";
            this.xlSpeed.Unit = "mm";
            this.xlSpeed.Value = 2F;
            // 
            // tAcc
            // 
            this.tAcc.BackColor = System.Drawing.SystemColors.Window;
            this.tAcc.DecPlaces = 3;
            this.tAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tAcc.Location = new System.Drawing.Point(394, 82);
            this.tAcc.Maximum = 1000F;
            this.tAcc.Minimum = 0.001F;
            this.tAcc.Name = "tAcc";
            this.tAcc.SetError = false;
            this.tAcc.SetWarn = false;
            this.tAcc.Size = new System.Drawing.Size(72, 29);
            this.tAcc.TabIndex = 2;
            this.tAcc.Text = "2";
            this.tAcc.Unit = "mm";
            this.tAcc.Value = 2F;
            // 
            // zAcc
            // 
            this.zAcc.BackColor = System.Drawing.SystemColors.Window;
            this.zAcc.DecPlaces = 3;
            this.zAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zAcc.Location = new System.Drawing.Point(316, 82);
            this.zAcc.Maximum = 1000F;
            this.zAcc.Minimum = 0.001F;
            this.zAcc.Name = "zAcc";
            this.zAcc.SetError = false;
            this.zAcc.SetWarn = false;
            this.zAcc.Size = new System.Drawing.Size(72, 29);
            this.zAcc.TabIndex = 2;
            this.zAcc.Text = "0.5";
            this.zAcc.Unit = "mm";
            this.zAcc.Value = 0.5F;
            // 
            // yAcc
            // 
            this.yAcc.BackColor = System.Drawing.SystemColors.Window;
            this.yAcc.DecPlaces = 3;
            this.yAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yAcc.Location = new System.Drawing.Point(238, 82);
            this.yAcc.Maximum = 1000F;
            this.yAcc.Minimum = 0.001F;
            this.yAcc.Name = "yAcc";
            this.yAcc.SetError = false;
            this.yAcc.SetWarn = false;
            this.yAcc.Size = new System.Drawing.Size(72, 29);
            this.yAcc.TabIndex = 2;
            this.yAcc.Text = "0.5";
            this.yAcc.Unit = "mm";
            this.yAcc.Value = 0.5F;
            // 
            // xAcc
            // 
            this.xAcc.BackColor = System.Drawing.SystemColors.Window;
            this.xAcc.DecPlaces = 3;
            this.xAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xAcc.Location = new System.Drawing.Point(160, 82);
            this.xAcc.Maximum = 1000F;
            this.xAcc.Minimum = 0.001F;
            this.xAcc.Name = "xAcc";
            this.xAcc.SetError = false;
            this.xAcc.SetWarn = false;
            this.xAcc.Size = new System.Drawing.Size(72, 29);
            this.xAcc.TabIndex = 2;
            this.xAcc.Text = "5";
            this.xAcc.Unit = "mm";
            this.xAcc.Value = 5F;
            // 
            // tSpeed
            // 
            this.tSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.tSpeed.DecPlaces = 3;
            this.tSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tSpeed.Location = new System.Drawing.Point(394, 47);
            this.tSpeed.Maximum = 1000F;
            this.tSpeed.Minimum = 0.001F;
            this.tSpeed.Name = "tSpeed";
            this.tSpeed.SetError = false;
            this.tSpeed.SetWarn = false;
            this.tSpeed.Size = new System.Drawing.Size(72, 29);
            this.tSpeed.TabIndex = 2;
            this.tSpeed.Text = "30";
            this.tSpeed.Unit = "mm";
            this.tSpeed.Value = 30F;
            // 
            // zSpeed
            // 
            this.zSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.zSpeed.DecPlaces = 3;
            this.zSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zSpeed.Location = new System.Drawing.Point(316, 47);
            this.zSpeed.Maximum = 1000F;
            this.zSpeed.Minimum = 0.001F;
            this.zSpeed.Name = "zSpeed";
            this.zSpeed.SetError = false;
            this.zSpeed.SetWarn = false;
            this.zSpeed.Size = new System.Drawing.Size(72, 29);
            this.zSpeed.TabIndex = 2;
            this.zSpeed.Text = "8";
            this.zSpeed.Unit = "mm";
            this.zSpeed.Value = 8F;
            // 
            // ySpeed
            // 
            this.ySpeed.BackColor = System.Drawing.SystemColors.Window;
            this.ySpeed.DecPlaces = 3;
            this.ySpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ySpeed.Location = new System.Drawing.Point(238, 47);
            this.ySpeed.Maximum = 1000F;
            this.ySpeed.Minimum = 0.001F;
            this.ySpeed.Name = "ySpeed";
            this.ySpeed.SetError = false;
            this.ySpeed.SetWarn = false;
            this.ySpeed.Size = new System.Drawing.Size(72, 29);
            this.ySpeed.TabIndex = 2;
            this.ySpeed.Text = "25";
            this.ySpeed.Unit = "mm";
            this.ySpeed.Value = 25F;
            // 
            // xSpeed
            // 
            this.xSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.xSpeed.DecPlaces = 3;
            this.xSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xSpeed.Location = new System.Drawing.Point(160, 47);
            this.xSpeed.Maximum = 1000F;
            this.xSpeed.Minimum = 0.001F;
            this.xSpeed.Name = "xSpeed";
            this.xSpeed.SetError = false;
            this.xSpeed.SetWarn = false;
            this.xSpeed.Size = new System.Drawing.Size(72, 29);
            this.xSpeed.TabIndex = 2;
            this.xSpeed.Text = "50";
            this.xSpeed.Unit = "mm";
            this.xSpeed.Value = 50F;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "T轴";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "Z轴";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Y轴";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "X轴";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "慢加速度(mm/s²):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "慢速度(mm/s):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "加速度(mm/s²):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "速度(mm/s):";
            // 
            // DevDataManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BT0Content = "三色灯配置";
            this.BT1Content = "划切参数";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.panelEx1);
            this.Name = "DevDataManager";
            this.Text = "功能参数";
            this.BT0Click += new System.EventHandler(this.DevDataManager_BT0Click);
            this.BT1Click += new System.EventHandler(this.DevDataManager_BT1Click);
            this.CancelClick += new System.EventHandler(this.DevDataManager_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.DevDataManager_ConfirmClick);
            this.panelEx1.ResumeLayout(false);
            this.heightCCD.ResumeLayout(false);
            this.heightCCD.PerformLayout();
            this.lowCCDSet.ResumeLayout(false);
            this.lowCCDSet.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctr.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ctr.NumberEdit tlAcc;
        private Ctr.NumberEdit zlAcc;
        private Ctr.NumberEdit ylAcc;
        private Ctr.NumberEdit xlAcc;
        private Ctr.NumberEdit tlSpeed;
        private Ctr.NumberEdit zlSpeed;
        private Ctr.NumberEdit ylSpeed;
        private Ctr.NumberEdit xlSpeed;
        private Ctr.NumberEdit tAcc;
        private Ctr.NumberEdit zAcc;
        private Ctr.NumberEdit yAcc;
        private Ctr.NumberEdit xAcc;
        private Ctr.NumberEdit tSpeed;
        private Ctr.NumberEdit zSpeed;
        private Ctr.NumberEdit ySpeed;
        private Ctr.NumberEdit xSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Ctr.NumberEdit testTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ctr.NumberEdit CutTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private Ctr.NumberEdit spdReadyTime;
        private Ctr.NumberEdit spdAxis;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox zlift;
        private System.Windows.Forms.CheckBox testNoCheckAir;
        private System.Windows.Forms.CheckBox doorProtect;
        private System.Windows.Forms.CheckBox leakWaterChecked;
        private System.Windows.Forms.CheckBox cutWaterChecked;
        private System.Windows.Forms.CheckBox buzzerUsed;
        private System.Windows.Forms.GroupBox heightCCD;
        private Ctr.NumberEdit hCenterX;
        private Ctr.NumberEdit hCenterY;
        private Ctr.NumberEdit hPix;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox lowCCDSet;
        private Ctr.NumberEdit lCenterX;
        private Ctr.NumberEdit lCenterY;
        private Ctr.NumberEdit lPix;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cutPauseCloseCutwater;
        private System.Windows.Forms.CheckBox resumeCutCloseBuzzer;
        private System.Windows.Forms.CheckBox cutStopCloseWater;
        private System.Windows.Forms.CheckBox unloadVacuum;
    }
}