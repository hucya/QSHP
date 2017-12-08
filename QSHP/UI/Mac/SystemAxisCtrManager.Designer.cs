namespace QSHP.UI
{
    partial class SystemAxisCtrManger
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tCheck = new System.Windows.Forms.CheckBox();
            this.tStep = new QSHP.UI.Ctr.NumberEdit();
            this.tNButton = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.tPButton = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.tAcc = new QSHP.UI.Ctr.NumberEdit();
            this.tSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.zCheck = new System.Windows.Forms.CheckBox();
            this.zStep = new QSHP.UI.Ctr.NumberEdit();
            this.zNButton = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.zPButton = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.zAcc = new QSHP.UI.Ctr.NumberEdit();
            this.zSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yCheck = new System.Windows.Forms.CheckBox();
            this.yStep = new QSHP.UI.Ctr.NumberEdit();
            this.yNButton = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.yAcc = new QSHP.UI.Ctr.NumberEdit();
            this.ySpeed = new QSHP.UI.Ctr.NumberEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.yPButton = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xCheck = new System.Windows.Forms.CheckBox();
            this.xStep = new QSHP.UI.Ctr.NumberEdit();
            this.xAcc = new QSHP.UI.Ctr.NumberEdit();
            this.xSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xNButton = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.xPButton = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.panelEx1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.groupBox4);
            this.panelEx1.Controls.Add(this.groupBox3);
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Controls.Add(this.groupBox2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 18F);
            this.panelEx1.LeftMode = false;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(815, 495);
            this.panelEx1.TabIndex = 2;
            this.panelEx1.Text = "运动控制";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tCheck);
            this.groupBox4.Controls.Add(this.tStep);
            this.groupBox4.Controls.Add(this.tNButton);
            this.groupBox4.Controls.Add(this.tPButton);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.tAcc);
            this.groupBox4.Controls.Add(this.tSpeed);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(12, 372);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(674, 114);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "T轴运动";
            // 
            // tCheck
            // 
            this.tCheck.AutoSize = true;
            this.tCheck.Location = new System.Drawing.Point(448, 80);
            this.tCheck.Name = "tCheck";
            this.tCheck.Size = new System.Drawing.Size(82, 25);
            this.tCheck.TabIndex = 3;
            this.tCheck.Text = "步进(°):";
            this.tCheck.UseVisualStyleBackColor = true;
            this.tCheck.CheckedChanged += new System.EventHandler(this.tCheck_CheckedChanged);
            // 
            // tStep
            // 
            this.tStep.BackColor = System.Drawing.SystemColors.Window;
            this.tStep.DecPlaces = 3;
            this.tStep.Enabled = false;
            this.tStep.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tStep.Location = new System.Drawing.Point(559, 79);
            this.tStep.MaxLength = 1000;
            this.tStep.Minimum = 0.001F;
            this.tStep.Name = "tStep";
            this.tStep.SetError = false;
            this.tStep.SetWarn = false;
            this.tStep.Size = new System.Drawing.Size(100, 29);
            this.tStep.TabIndex = 2;
            this.tStep.Text = "30";
            this.tStep.Unit = "mm";
            this.tStep.Value = 30F;
            // 
            // tNButton
            // 
            this.tNButton.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.tNButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tNButton.Font = new System.Drawing.Font("QSHP", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNButton.LED = false;
            this.tNButton.LedLocation = new System.Drawing.Point(-24, -76);
            this.tNButton.Location = new System.Drawing.Point(240, 22);
            this.tNButton.Name = "tNButton";
            this.tNButton.NumText = "";
            this.tNButton.Pressed = false;
            this.tNButton.Size = new System.Drawing.Size(114, 80);
            this.tNButton.TabIndex = 0;
            this.tNButton.TabStop = false;
            this.tNButton.Text = "B";
            this.tNButton.UsedLed = false;
            this.tNButton.UseVisualStyleBackColor = true;
            this.tNButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseDown);
            this.tNButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseUp);
            // 
            // tPButton
            // 
            this.tPButton.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.tPButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tPButton.Font = new System.Drawing.Font("QSHP", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPButton.LED = false;
            this.tPButton.LedLocation = new System.Drawing.Point(-18, -70);
            this.tPButton.Location = new System.Drawing.Point(79, 22);
            this.tPButton.Name = "tPButton";
            this.tPButton.NumText = "";
            this.tPButton.Pressed = false;
            this.tPButton.Size = new System.Drawing.Size(114, 80);
            this.tPButton.TabIndex = 0;
            this.tPButton.TabStop = false;
            this.tPButton.Text = "A";
            this.tPButton.UsedLed = false;
            this.tPButton.UseVisualStyleBackColor = true;
            this.tPButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseDown);
            this.tPButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(418, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "运动速度(°/s):";
            // 
            // tAcc
            // 
            this.tAcc.BackColor = System.Drawing.SystemColors.Window;
            this.tAcc.DecPlaces = 3;
            this.tAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tAcc.Location = new System.Drawing.Point(559, 48);
            this.tAcc.MaxLength = 1000;
            this.tAcc.Minimum = 0.001F;
            this.tAcc.Name = "tAcc";
            this.tAcc.SetError = false;
            this.tAcc.SetWarn = false;
            this.tAcc.Size = new System.Drawing.Size(100, 29);
            this.tAcc.TabIndex = 2;
            this.tAcc.Text = "5";
            this.tAcc.Unit = "mm";
            this.tAcc.Value = 5F;
            // 
            // tSpeed
            // 
            this.tSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.tSpeed.DecPlaces = 3;
            this.tSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tSpeed.Location = new System.Drawing.Point(559, 17);
            this.tSpeed.MaxLength = 1000;
            this.tSpeed.Minimum = 0.001F;
            this.tSpeed.Name = "tSpeed";
            this.tSpeed.SetError = false;
            this.tSpeed.SetWarn = false;
            this.tSpeed.Size = new System.Drawing.Size(100, 29);
            this.tSpeed.TabIndex = 2;
            this.tSpeed.Text = "50";
            this.tSpeed.Unit = "mm";
            this.tSpeed.Value = 50F;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(428, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "加速度(°/s²):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.zCheck);
            this.groupBox3.Controls.Add(this.zStep);
            this.groupBox3.Controls.Add(this.zNButton);
            this.groupBox3.Controls.Add(this.zPButton);
            this.groupBox3.Controls.Add(this.zAcc);
            this.groupBox3.Controls.Add(this.zSpeed);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(12, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(674, 115);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Z轴运动";
            // 
            // zCheck
            // 
            this.zCheck.AutoSize = true;
            this.zCheck.Location = new System.Drawing.Point(425, 85);
            this.zCheck.Name = "zCheck";
            this.zCheck.Size = new System.Drawing.Size(105, 25);
            this.zCheck.TabIndex = 3;
            this.zCheck.Text = "步进(mm):";
            this.zCheck.UseVisualStyleBackColor = true;
            this.zCheck.CheckedChanged += new System.EventHandler(this.zCheck_CheckedChanged);
            // 
            // zStep
            // 
            this.zStep.BackColor = System.Drawing.SystemColors.Window;
            this.zStep.DecPlaces = 3;
            this.zStep.Enabled = false;
            this.zStep.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zStep.Location = new System.Drawing.Point(559, 78);
            this.zStep.MaxLength = 1000;
            this.zStep.Minimum = 0.001F;
            this.zStep.Name = "zStep";
            this.zStep.SetError = false;
            this.zStep.SetWarn = false;
            this.zStep.Size = new System.Drawing.Size(100, 29);
            this.zStep.TabIndex = 2;
            this.zStep.Text = "0.1";
            this.zStep.Unit = "mm";
            this.zStep.Value = 0.1F;
            // 
            // zNButton
            // 
            this.zNButton.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.zNButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zNButton.Font = new System.Drawing.Font("QSHP", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zNButton.LED = false;
            this.zNButton.LedLocation = new System.Drawing.Point(-18, -70);
            this.zNButton.Location = new System.Drawing.Point(240, 22);
            this.zNButton.Name = "zNButton";
            this.zNButton.NumText = "";
            this.zNButton.Pressed = false;
            this.zNButton.Size = new System.Drawing.Size(114, 80);
            this.zNButton.TabIndex = 0;
            this.zNButton.TabStop = false;
            this.zNButton.Text = "T";
            this.zNButton.UsedLed = false;
            this.zNButton.UseVisualStyleBackColor = true;
            this.zNButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseDown);
            this.zNButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseUp);
            // 
            // zPButton
            // 
            this.zPButton.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.zPButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zPButton.Font = new System.Drawing.Font("QSHP", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zPButton.LED = false;
            this.zPButton.LedLocation = new System.Drawing.Point(-18, -70);
            this.zPButton.Location = new System.Drawing.Point(79, 22);
            this.zPButton.Name = "zPButton";
            this.zPButton.NumText = "";
            this.zPButton.Pressed = false;
            this.zPButton.Size = new System.Drawing.Size(114, 80);
            this.zPButton.TabIndex = 0;
            this.zPButton.TabStop = false;
            this.zPButton.Text = "S";
            this.zPButton.UsedLed = false;
            this.zPButton.UseVisualStyleBackColor = true;
            this.zPButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseDown);
            this.zPButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseUp);
            // 
            // zAcc
            // 
            this.zAcc.BackColor = System.Drawing.SystemColors.Window;
            this.zAcc.DecPlaces = 3;
            this.zAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zAcc.Location = new System.Drawing.Point(559, 47);
            this.zAcc.MaxLength = 1000;
            this.zAcc.Minimum = 0.001F;
            this.zAcc.Name = "zAcc";
            this.zAcc.SetError = false;
            this.zAcc.SetWarn = false;
            this.zAcc.Size = new System.Drawing.Size(100, 29);
            this.zAcc.TabIndex = 2;
            this.zAcc.Text = "0.5";
            this.zAcc.Unit = "mm";
            this.zAcc.Value = 0.5F;
            // 
            // zSpeed
            // 
            this.zSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.zSpeed.DecPlaces = 3;
            this.zSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zSpeed.Location = new System.Drawing.Point(559, 16);
            this.zSpeed.MaxLength = 1000;
            this.zSpeed.Minimum = 0.001F;
            this.zSpeed.Name = "zSpeed";
            this.zSpeed.SetError = false;
            this.zSpeed.SetWarn = false;
            this.zSpeed.Size = new System.Drawing.Size(100, 29);
            this.zSpeed.TabIndex = 2;
            this.zSpeed.Text = "1.5";
            this.zSpeed.Unit = "mm";
            this.zSpeed.Value = 1.5F;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "加速度(mm/s²):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(395, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "运动速度(mm/s):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yCheck);
            this.groupBox1.Controls.Add(this.yStep);
            this.groupBox1.Controls.Add(this.yNButton);
            this.groupBox1.Controls.Add(this.yAcc);
            this.groupBox1.Controls.Add(this.ySpeed);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.yPButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Y轴运动";
            // 
            // yCheck
            // 
            this.yCheck.AutoSize = true;
            this.yCheck.Location = new System.Drawing.Point(425, 79);
            this.yCheck.Name = "yCheck";
            this.yCheck.Size = new System.Drawing.Size(105, 25);
            this.yCheck.TabIndex = 3;
            this.yCheck.Text = "步进(mm):";
            this.yCheck.UseVisualStyleBackColor = true;
            this.yCheck.CheckedChanged += new System.EventHandler(this.yCheck_CheckedChanged);
            // 
            // yStep
            // 
            this.yStep.BackColor = System.Drawing.SystemColors.Window;
            this.yStep.DecPlaces = 3;
            this.yStep.Enabled = false;
            this.yStep.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yStep.Location = new System.Drawing.Point(559, 78);
            this.yStep.MaxLength = 1000;
            this.yStep.Minimum = 0.001F;
            this.yStep.Name = "yStep";
            this.yStep.SetError = false;
            this.yStep.SetWarn = false;
            this.yStep.Size = new System.Drawing.Size(100, 29);
            this.yStep.TabIndex = 2;
            this.yStep.Text = "1";
            this.yStep.Unit = "mm";
            this.yStep.Value = 1F;
            // 
            // yNButton
            // 
            this.yNButton.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.yNButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yNButton.Font = new System.Drawing.Font("QSHP", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yNButton.LED = false;
            this.yNButton.LedLocation = new System.Drawing.Point(-18, -70);
            this.yNButton.Location = new System.Drawing.Point(240, 22);
            this.yNButton.Name = "yNButton";
            this.yNButton.NumText = "";
            this.yNButton.Pressed = false;
            this.yNButton.Size = new System.Drawing.Size(114, 80);
            this.yNButton.TabIndex = 0;
            this.yNButton.TabStop = false;
            this.yNButton.Text = "F";
            this.yNButton.UsedLed = false;
            this.yNButton.UseVisualStyleBackColor = true;
            this.yNButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseDown);
            this.yNButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseUp);
            // 
            // yAcc
            // 
            this.yAcc.BackColor = System.Drawing.SystemColors.Window;
            this.yAcc.DecPlaces = 3;
            this.yAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yAcc.Location = new System.Drawing.Point(559, 47);
            this.yAcc.MaxLength = 1000;
            this.yAcc.Minimum = 0.001F;
            this.yAcc.Name = "yAcc";
            this.yAcc.SetError = false;
            this.yAcc.SetWarn = false;
            this.yAcc.Size = new System.Drawing.Size(100, 29);
            this.yAcc.TabIndex = 2;
            this.yAcc.Text = "2";
            this.yAcc.Unit = "mm";
            this.yAcc.Value = 2F;
            // 
            // ySpeed
            // 
            this.ySpeed.BackColor = System.Drawing.SystemColors.Window;
            this.ySpeed.DecPlaces = 3;
            this.ySpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ySpeed.Location = new System.Drawing.Point(559, 16);
            this.ySpeed.MaxLength = 1000;
            this.ySpeed.Minimum = 0.001F;
            this.ySpeed.Name = "ySpeed";
            this.ySpeed.SetError = false;
            this.ySpeed.SetWarn = false;
            this.ySpeed.Size = new System.Drawing.Size(100, 29);
            this.ySpeed.TabIndex = 2;
            this.ySpeed.Text = "0.05";
            this.ySpeed.Unit = "mm";
            this.ySpeed.Value = 0.05F;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "加速度(mm/s²):";
            // 
            // yPButton
            // 
            this.yPButton.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.yPButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yPButton.Font = new System.Drawing.Font("QSHP", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yPButton.LED = false;
            this.yPButton.LedLocation = new System.Drawing.Point(-18, -70);
            this.yPButton.Location = new System.Drawing.Point(79, 22);
            this.yPButton.Name = "yPButton";
            this.yPButton.NumText = "";
            this.yPButton.Pressed = false;
            this.yPButton.Size = new System.Drawing.Size(114, 80);
            this.yPButton.TabIndex = 0;
            this.yPButton.TabStop = false;
            this.yPButton.Text = "E";
            this.yPButton.UsedLed = false;
            this.yPButton.UseVisualStyleBackColor = true;
            this.yPButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseDown);
            this.yPButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "运动速度(mm/s):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xCheck);
            this.groupBox2.Controls.Add(this.xStep);
            this.groupBox2.Controls.Add(this.xAcc);
            this.groupBox2.Controls.Add(this.xSpeed);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.xNButton);
            this.groupBox2.Controls.Add(this.xPButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(674, 114);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "X轴运动";
            // 
            // xCheck
            // 
            this.xCheck.AutoSize = true;
            this.xCheck.Location = new System.Drawing.Point(425, 81);
            this.xCheck.Name = "xCheck";
            this.xCheck.Size = new System.Drawing.Size(105, 25);
            this.xCheck.TabIndex = 3;
            this.xCheck.Text = "步进(mm):";
            this.xCheck.UseVisualStyleBackColor = true;
            this.xCheck.CheckedChanged += new System.EventHandler(this.xCheck_CheckedChanged);
            // 
            // xStep
            // 
            this.xStep.BackColor = System.Drawing.SystemColors.Window;
            this.xStep.DecPlaces = 3;
            this.xStep.Enabled = false;
            this.xStep.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xStep.Location = new System.Drawing.Point(559, 78);
            this.xStep.MaxLength = 1000;
            this.xStep.Minimum = 0.001F;
            this.xStep.Name = "xStep";
            this.xStep.SetError = false;
            this.xStep.SetWarn = false;
            this.xStep.Size = new System.Drawing.Size(100, 29);
            this.xStep.TabIndex = 2;
            this.xStep.Text = "10";
            this.xStep.Unit = "mm";
            this.xStep.Value = 10F;
            // 
            // xAcc
            // 
            this.xAcc.BackColor = System.Drawing.SystemColors.Window;
            this.xAcc.DecPlaces = 3;
            this.xAcc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xAcc.Location = new System.Drawing.Point(559, 47);
            this.xAcc.MaxLength = 1000;
            this.xAcc.Minimum = 0.001F;
            this.xAcc.Name = "xAcc";
            this.xAcc.SetError = false;
            this.xAcc.SetWarn = false;
            this.xAcc.Size = new System.Drawing.Size(100, 29);
            this.xAcc.TabIndex = 2;
            this.xAcc.Text = "1";
            this.xAcc.Unit = "mm";
            this.xAcc.Value = 1F;
            // 
            // xSpeed
            // 
            this.xSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.xSpeed.DecPlaces = 3;
            this.xSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xSpeed.Location = new System.Drawing.Point(559, 16);
            this.xSpeed.MaxLength = 1000;
            this.xSpeed.Minimum = 0.001F;
            this.xSpeed.Name = "xSpeed";
            this.xSpeed.SetError = false;
            this.xSpeed.SetWarn = false;
            this.xSpeed.Size = new System.Drawing.Size(100, 29);
            this.xSpeed.TabIndex = 2;
            this.xSpeed.Text = "2";
            this.xSpeed.Unit = "mm";
            this.xSpeed.Value = 2F;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "加速度(mm/s²):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "运动速度(mm/s):";
            // 
            // xNButton
            // 
            this.xNButton.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.xNButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xNButton.Font = new System.Drawing.Font("QSHP", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xNButton.LED = false;
            this.xNButton.LedLocation = new System.Drawing.Point(-18, -70);
            this.xNButton.Location = new System.Drawing.Point(240, 22);
            this.xNButton.Name = "xNButton";
            this.xNButton.NumText = "";
            this.xNButton.Pressed = false;
            this.xNButton.Size = new System.Drawing.Size(114, 80);
            this.xNButton.TabIndex = 0;
            this.xNButton.TabStop = false;
            this.xNButton.Text = "D";
            this.xNButton.UsedLed = false;
            this.xNButton.UseVisualStyleBackColor = true;
            this.xNButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseDown);
            this.xNButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseUp);
            // 
            // xPButton
            // 
            this.xPButton.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.xPButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xPButton.Font = new System.Drawing.Font("QSHP", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPButton.LED = false;
            this.xPButton.LedLocation = new System.Drawing.Point(-18, -70);
            this.xPButton.Location = new System.Drawing.Point(79, 22);
            this.xPButton.Name = "xPButton";
            this.xPButton.NumText = "";
            this.xPButton.Pressed = false;
            this.xPButton.Size = new System.Drawing.Size(114, 80);
            this.xPButton.TabIndex = 0;
            this.xPButton.TabStop = false;
            this.xPButton.Text = "C";
            this.xPButton.UsedLed = false;
            this.xPButton.UseVisualStyleBackColor = true;
            this.xPButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseDown);
            this.xPButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AxisButton_MouseUp);
            // 
            // SystemAxisCtrManger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.panelEx1);
            this.FmStyle = QSHP.FormStyle.Cancel;
            this.Name = "SystemAxisCtrManger";
            this.Text = "运动控制";
            this.Load += new System.EventHandler(this.SystemAxisCtrManger_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctr.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Ctr.ButtonEx tNButton;
        private Ctr.ButtonEx tPButton;
        private Ctr.ButtonEx zNButton;
        private Ctr.ButtonEx zPButton;
        private Ctr.ButtonEx yNButton;
        private Ctr.ButtonEx yPButton;
        private Ctr.ButtonEx xNButton;
        private Ctr.ButtonEx xPButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox tCheck;
        private Ctr.NumberEdit tStep;
        private Ctr.NumberEdit tAcc;
        private Ctr.NumberEdit tSpeed;
        private System.Windows.Forms.CheckBox zCheck;
        private Ctr.NumberEdit zStep;
        private Ctr.NumberEdit zAcc;
        private Ctr.NumberEdit zSpeed;
        private System.Windows.Forms.CheckBox yCheck;
        private Ctr.NumberEdit yStep;
        private Ctr.NumberEdit yAcc;
        private Ctr.NumberEdit ySpeed;
        private System.Windows.Forms.CheckBox xCheck;
        private Ctr.NumberEdit xStep;
        private Ctr.NumberEdit xAcc;
        private Ctr.NumberEdit xSpeed;
    }
}