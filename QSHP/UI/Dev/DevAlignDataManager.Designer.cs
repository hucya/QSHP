namespace QSHP.UI
{
    partial class DevAlignDataManager
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.zRePos = new QSHP.UI.Ctr.NumberEdit();
            this.xRePos = new QSHP.UI.Ctr.NumberEdit();
            this.yRePos = new QSHP.UI.Ctr.NumberEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.xReplaceBldnNoMove = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.stepMaxlable = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.stepMaxValue = new QSHP.UI.Ctr.NumberEdit();
            this.speedMaxValue = new QSHP.UI.Ctr.NumberEdit();
            this.heightMaxValue = new QSHP.UI.Ctr.NumberEdit();
            this.heightTickValue = new QSHP.UI.Ctr.NumberEdit();
            this.posMaxValue = new QSHP.UI.Ctr.NumberEdit();
            this.adjMaxValue = new QSHP.UI.Ctr.NumberEdit();
            this.adjTickValue = new QSHP.UI.Ctr.NumberEdit();
            this.panelEx1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.groupBox4);
            this.panelEx1.Controls.Add(this.groupBox2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 18F);
            this.panelEx1.LeftMode = false;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(815, 495);
            this.panelEx1.TabIndex = 1;
            this.panelEx1.Text = "划切参数";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.zRePos);
            this.groupBox4.Controls.Add(this.xRePos);
            this.groupBox4.Controls.Add(this.yRePos);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.xReplaceBldnNoMove);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(12, 317);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(303, 170);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "换刀位置";
            // 
            // zRePos
            // 
            this.zRePos.BackColor = System.Drawing.SystemColors.Window;
            this.zRePos.DecPlaces = 3;
            this.zRePos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zRePos.Location = new System.Drawing.Point(185, 132);
            this.zRePos.Maximum = 1000F;
            this.zRePos.Minimum = 0.001F;
            this.zRePos.Name = "zRePos";
            this.zRePos.SetError = false;
            this.zRePos.SetWarn = false;
            this.zRePos.Size = new System.Drawing.Size(90, 29);
            this.zRePos.TabIndex = 2;
            this.zRePos.Text = "30";
            this.zRePos.Unit = "mm";
            this.zRePos.Value = 30F;
            // 
            // xRePos
            // 
            this.xRePos.BackColor = System.Drawing.SystemColors.Window;
            this.xRePos.DecPlaces = 3;
            this.xRePos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xRePos.Location = new System.Drawing.Point(185, 60);
            this.xRePos.Maximum = 1000F;
            this.xRePos.Minimum = 0.001F;
            this.xRePos.Name = "xRePos";
            this.xRePos.SetError = false;
            this.xRePos.SetWarn = false;
            this.xRePos.Size = new System.Drawing.Size(90, 29);
            this.xRePos.TabIndex = 2;
            this.xRePos.Text = "300";
            this.xRePos.Unit = "mm";
            this.xRePos.Value = 300F;
            // 
            // yRePos
            // 
            this.yRePos.BackColor = System.Drawing.SystemColors.Window;
            this.yRePos.DecPlaces = 3;
            this.yRePos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yRePos.Location = new System.Drawing.Point(185, 95);
            this.yRePos.Maximum = 1000F;
            this.yRePos.Minimum = 0.001F;
            this.yRePos.Name = "yRePos";
            this.yRePos.SetError = false;
            this.yRePos.SetWarn = false;
            this.yRePos.Size = new System.Drawing.Size(90, 29);
            this.yRePos.TabIndex = 2;
            this.yRePos.Text = "270";
            this.yRePos.Unit = "mm";
            this.yRePos.Value = 270F;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "Z 位置(mm):";
            // 
            // xReplaceBldnNoMove
            // 
            this.xReplaceBldnNoMove.AutoSize = true;
            this.xReplaceBldnNoMove.Location = new System.Drawing.Point(185, 28);
            this.xReplaceBldnNoMove.Name = "xReplaceBldnNoMove";
            this.xReplaceBldnNoMove.Size = new System.Drawing.Size(66, 25);
            this.xReplaceBldnNoMove.TabIndex = 0;
            this.xReplaceBldnNoMove.Text = "不 动";
            this.xReplaceBldnNoMove.UseVisualStyleBackColor = true;
            this.xReplaceBldnNoMove.CheckedChanged += new System.EventHandler(this.xReplaceBldnNoMove_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 21);
            this.label14.TabIndex = 0;
            this.label14.Text = "Y 位置(mm):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 21);
            this.label13.TabIndex = 0;
            this.label13.Text = "X 位置(mm):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.stepMaxlable);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.stepMaxValue);
            this.groupBox2.Controls.Add(this.speedMaxValue);
            this.groupBox2.Controls.Add(this.heightMaxValue);
            this.groupBox2.Controls.Add(this.heightTickValue);
            this.groupBox2.Controls.Add(this.posMaxValue);
            this.groupBox2.Controls.Add(this.adjMaxValue);
            this.groupBox2.Controls.Add(this.adjTickValue);
            this.groupBox2.Location = new System.Drawing.Point(11, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 283);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "划切参数";
            // 
            // stepMaxlable
            // 
            this.stepMaxlable.AutoSize = true;
            this.stepMaxlable.Location = new System.Drawing.Point(23, 224);
            this.stepMaxlable.Name = "stepMaxlable";
            this.stepMaxlable.Size = new System.Drawing.Size(126, 21);
            this.stepMaxlable.TabIndex = 0;
            this.stepMaxlable.Text = "分度调整最大值:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(23, 191);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(126, 21);
            this.label25.TabIndex = 0;
            this.label25.Text = "速度调整最大值:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(23, 157);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(126, 21);
            this.label24.TabIndex = 0;
            this.label24.Text = "高度调整最大值:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(23, 125);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(126, 21);
            this.label23.TabIndex = 0;
            this.label23.Text = "高度调整单次值:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "位置调整最大值:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "基准线调整最大值:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "基准线调整单次值:";
            // 
            // stepMaxValue
            // 
            this.stepMaxValue.BackColor = System.Drawing.SystemColors.Window;
            this.stepMaxValue.DecPlaces = 3;
            this.stepMaxValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.stepMaxValue.Location = new System.Drawing.Point(186, 220);
            this.stepMaxValue.Maximum = 1000F;
            this.stepMaxValue.Minimum = 0.001F;
            this.stepMaxValue.Name = "stepMaxValue";
            this.stepMaxValue.SetError = false;
            this.stepMaxValue.SetWarn = false;
            this.stepMaxValue.Size = new System.Drawing.Size(90, 29);
            this.stepMaxValue.TabIndex = 2;
            this.stepMaxValue.Text = "0.5";
            this.stepMaxValue.Unit = "mm";
            this.stepMaxValue.Value = 0.5F;
            // 
            // speedMaxValue
            // 
            this.speedMaxValue.BackColor = System.Drawing.SystemColors.Window;
            this.speedMaxValue.DecPlaces = 3;
            this.speedMaxValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.speedMaxValue.Location = new System.Drawing.Point(186, 187);
            this.speedMaxValue.Maximum = 1000F;
            this.speedMaxValue.Minimum = 0.001F;
            this.speedMaxValue.Name = "speedMaxValue";
            this.speedMaxValue.SetError = false;
            this.speedMaxValue.SetWarn = false;
            this.speedMaxValue.Size = new System.Drawing.Size(90, 29);
            this.speedMaxValue.TabIndex = 2;
            this.speedMaxValue.Text = "30";
            this.speedMaxValue.Unit = "mm";
            this.speedMaxValue.Value = 30F;
            // 
            // heightMaxValue
            // 
            this.heightMaxValue.BackColor = System.Drawing.SystemColors.Window;
            this.heightMaxValue.DecPlaces = 3;
            this.heightMaxValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.heightMaxValue.Location = new System.Drawing.Point(186, 153);
            this.heightMaxValue.Maximum = 1000F;
            this.heightMaxValue.Minimum = 0.003F;
            this.heightMaxValue.Name = "heightMaxValue";
            this.heightMaxValue.SetError = false;
            this.heightMaxValue.SetWarn = false;
            this.heightMaxValue.Size = new System.Drawing.Size(90, 29);
            this.heightMaxValue.TabIndex = 2;
            this.heightMaxValue.Text = "0.01";
            this.heightMaxValue.Unit = "mm";
            this.heightMaxValue.Value = 0.01F;
            // 
            // heightTickValue
            // 
            this.heightTickValue.BackColor = System.Drawing.SystemColors.Window;
            this.heightTickValue.DecPlaces = 3;
            this.heightTickValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.heightTickValue.Location = new System.Drawing.Point(186, 121);
            this.heightTickValue.Maximum = 1000F;
            this.heightTickValue.Minimum = 0.001F;
            this.heightTickValue.Name = "heightTickValue";
            this.heightTickValue.SetError = false;
            this.heightTickValue.SetWarn = false;
            this.heightTickValue.Size = new System.Drawing.Size(90, 29);
            this.heightTickValue.TabIndex = 2;
            this.heightTickValue.Text = "0.01";
            this.heightTickValue.Unit = "mm";
            this.heightTickValue.Value = 0.01F;
            // 
            // posMaxValue
            // 
            this.posMaxValue.BackColor = System.Drawing.SystemColors.Window;
            this.posMaxValue.DecPlaces = 3;
            this.posMaxValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.posMaxValue.Location = new System.Drawing.Point(186, 88);
            this.posMaxValue.Maximum = 1000F;
            this.posMaxValue.Minimum = 0.001F;
            this.posMaxValue.Name = "posMaxValue";
            this.posMaxValue.SetError = false;
            this.posMaxValue.SetWarn = false;
            this.posMaxValue.Size = new System.Drawing.Size(90, 29);
            this.posMaxValue.TabIndex = 2;
            this.posMaxValue.Text = "5";
            this.posMaxValue.Unit = "mm";
            this.posMaxValue.Value = 5F;
            // 
            // adjMaxValue
            // 
            this.adjMaxValue.BackColor = System.Drawing.SystemColors.Window;
            this.adjMaxValue.DecPlaces = 3;
            this.adjMaxValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.adjMaxValue.Location = new System.Drawing.Point(186, 55);
            this.adjMaxValue.Maximum = 1000F;
            this.adjMaxValue.Minimum = 0.001F;
            this.adjMaxValue.Name = "adjMaxValue";
            this.adjMaxValue.SetError = false;
            this.adjMaxValue.SetWarn = false;
            this.adjMaxValue.Size = new System.Drawing.Size(90, 29);
            this.adjMaxValue.TabIndex = 2;
            this.adjMaxValue.Text = "10";
            this.adjMaxValue.Unit = "mm";
            this.adjMaxValue.Value = 10F;
            // 
            // adjTickValue
            // 
            this.adjTickValue.BackColor = System.Drawing.SystemColors.Window;
            this.adjTickValue.DecPlaces = 3;
            this.adjTickValue.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.adjTickValue.Location = new System.Drawing.Point(186, 22);
            this.adjTickValue.Maximum = 1000F;
            this.adjTickValue.Minimum = 0.001F;
            this.adjTickValue.Name = "adjTickValue";
            this.adjTickValue.SetError = false;
            this.adjTickValue.SetWarn = false;
            this.adjTickValue.Size = new System.Drawing.Size(90, 29);
            this.adjTickValue.TabIndex = 2;
            this.adjTickValue.Text = "4";
            this.adjTickValue.Unit = "mm";
            this.adjTickValue.Value = 4F;
            // 
            // DevAlignDataManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.panelEx1);
            this.Name = "DevAlignDataManager";
            this.Text = "划切参数";
            this.CancelClick += new System.EventHandler(this.DevAlignDataManager_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.DevAlignDataManager_ConfirmClick);
            this.panelEx1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctr.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label stepMaxlable;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private Ctr.NumberEdit stepMaxValue;
        private Ctr.NumberEdit speedMaxValue;
        private Ctr.NumberEdit heightMaxValue;
        private Ctr.NumberEdit heightTickValue;
        private Ctr.NumberEdit posMaxValue;
        private Ctr.NumberEdit adjMaxValue;
        private Ctr.NumberEdit adjTickValue;
        private System.Windows.Forms.GroupBox groupBox4;
        private Ctr.NumberEdit zRePos;
        private Ctr.NumberEdit xRePos;
        private Ctr.NumberEdit yRePos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox xReplaceBldnNoMove;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}