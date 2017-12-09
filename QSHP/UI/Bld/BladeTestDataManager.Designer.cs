namespace QSHP.UI.Bld
{
    partial class BladeTestDataManager
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spdSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.tabType = new QSHP.UI.Ctr.ComboBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabNum = new QSHP.UI.Ctr.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tPos = new QSHP.UI.Ctr.NumberEdit();
            this.zPos = new QSHP.UI.Ctr.NumberEdit();
            this.yPos = new QSHP.UI.Ctr.NumberEdit();
            this.xPos = new QSHP.UI.Ctr.NumberEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelEx1 = new QSHP.UI.Ctr.PanelEx();
            this.tabSize = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabSize);
            this.groupBox1.Controls.Add(this.spdSpeed);
            this.groupBox1.Controls.Add(this.tabType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tabNum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(51, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测高环境";
            // 
            // spdSpeed
            // 
            this.spdSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.spdSpeed.DecPlaces = 3;
            this.spdSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.spdSpeed.Location = new System.Drawing.Point(168, 169);
            this.spdSpeed.Maximum = 60000F;
            this.spdSpeed.Minimum = 5000F;
            this.spdSpeed.Name = "spdSpeed";
            this.spdSpeed.SetError = false;
            this.spdSpeed.SetWarn = false;
            this.spdSpeed.Size = new System.Drawing.Size(111, 29);
            this.spdSpeed.TabIndex = 2;
            this.spdSpeed.Text = "10000";
            this.spdSpeed.Unit = "mm";
            this.spdSpeed.Value = 10000F;
            // 
            // tabType
            // 
            this.tabType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabType.FormattingEnabled = true;
            this.tabType.Items.AddRange(new object[] {
            "圆形",
            "方形"});
            this.tabType.Location = new System.Drawing.Point(168, 86);
            this.tabType.Name = "tabType";
            this.tabType.Size = new System.Drawing.Size(111, 29);
            this.tabType.TabIndex = 1;
            this.tabType.Text = "圆形";
            this.tabType.SelectedIndexChanged += new System.EventHandler(this.tabType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "主轴转速：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "台面尺寸：";
            // 
            // tabNum
            // 
            this.tabNum.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabNum.FormattingEnabled = true;
            this.tabNum.Items.AddRange(new object[] {
            "一号工作台",
            "二号工作台",
            "三号工作台",
            "四号工作台",
            "五号工作台"});
            this.tabNum.Location = new System.Drawing.Point(168, 43);
            this.tabNum.Name = "tabNum";
            this.tabNum.Size = new System.Drawing.Size(111, 29);
            this.tabNum.TabIndex = 1;
            this.tabNum.Text = "一号工作台";
            this.tabNum.SelectedIndexChanged += new System.EventHandler(this.tabNum_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "台面类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作台号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tPos);
            this.groupBox2.Controls.Add(this.zPos);
            this.groupBox2.Controls.Add(this.yPos);
            this.groupBox2.Controls.Add(this.xPos);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(411, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 214);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测高位置";
            // 
            // tPos
            // 
            this.tPos.BackColor = System.Drawing.SystemColors.Window;
            this.tPos.DecPlaces = 3;
            this.tPos.Enabled = false;
            this.tPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tPos.Location = new System.Drawing.Point(165, 164);
            this.tPos.Name = "tPos";
            this.tPos.ReadOnly = true;
            this.tPos.SetError = false;
            this.tPos.SetWarn = false;
            this.tPos.Size = new System.Drawing.Size(105, 29);
            this.tPos.TabIndex = 2;
            this.tPos.Text = "0";
            this.tPos.Unit = "mm";
            this.tPos.Value = 0F;
            // 
            // zPos
            // 
            this.zPos.BackColor = System.Drawing.SystemColors.Window;
            this.zPos.DecPlaces = 3;
            this.zPos.Enabled = false;
            this.zPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.zPos.Location = new System.Drawing.Point(165, 121);
            this.zPos.Name = "zPos";
            this.zPos.ReadOnly = true;
            this.zPos.SetError = false;
            this.zPos.SetWarn = false;
            this.zPos.Size = new System.Drawing.Size(105, 29);
            this.zPos.TabIndex = 2;
            this.zPos.Text = "0";
            this.zPos.Unit = "mm";
            this.zPos.Value = 0F;
            // 
            // yPos
            // 
            this.yPos.BackColor = System.Drawing.SystemColors.Window;
            this.yPos.DecPlaces = 3;
            this.yPos.Enabled = false;
            this.yPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yPos.Location = new System.Drawing.Point(165, 83);
            this.yPos.Name = "yPos";
            this.yPos.ReadOnly = true;
            this.yPos.SetError = false;
            this.yPos.SetWarn = false;
            this.yPos.Size = new System.Drawing.Size(105, 29);
            this.yPos.TabIndex = 2;
            this.yPos.Text = "0";
            this.yPos.Unit = "mm";
            this.yPos.Value = 0F;
            // 
            // xPos
            // 
            this.xPos.AccessibleRole = System.Windows.Forms.AccessibleRole.Equation;
            this.xPos.BackColor = System.Drawing.SystemColors.Window;
            this.xPos.DecPlaces = 3;
            this.xPos.Enabled = false;
            this.xPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.xPos.Location = new System.Drawing.Point(165, 48);
            this.xPos.Name = "xPos";
            this.xPos.ReadOnly = true;
            this.xPos.SetError = false;
            this.xPos.SetWarn = false;
            this.xPos.Size = new System.Drawing.Size(105, 29);
            this.xPos.TabIndex = 2;
            this.xPos.Text = "0";
            this.xPos.Unit = "mm";
            this.xPos.Value = 0F;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Z轴坐标：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "X轴坐标：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Y轴坐标：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "T轴坐标：";
            // 
            // panelEx1
            // 
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
            this.panelEx1.Text = "测高参数";
            // 
            // tabSize
            // 
            this.tabSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabSize.Location = new System.Drawing.Point(168, 129);
            this.tabSize.Name = "tabSize";
            this.tabSize.Size = new System.Drawing.Size(111, 29);
            this.tabSize.TabIndex = 3;
            this.tabSize.Text = "100 * 100";
            this.tabSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BladeTestDataManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BT0Content = "圆形工作台";
            this.BT1Content = "方形工作台";
            this.BT2Content = "测高范围调整";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "BladeTestDataManager";
            this.Text = "测高参数";
            this.BT0Click += new System.EventHandler(this.BladeTestDataManager_BT0Click);
            this.BT1Click += new System.EventHandler(this.BladeTestDataManager_BT1Click);
            this.BT2Click += new System.EventHandler(this.BladeTestDataManager_BT2Click);
            this.CancelClick += new System.EventHandler(this.BladeTestDataManager_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.BladeTestDataManager_ConfirmClick);
            this.Load += new System.EventHandler(this.BladeTestDataManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Ctr.PanelEx panelEx1;
        private Ctr.NumberEdit spdSpeed;
        private Ctr.ComboBoxEx tabType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Ctr.ComboBoxEx tabNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Ctr.NumberEdit tPos;
        private Ctr.NumberEdit zPos;
        private Ctr.NumberEdit yPos;
        private Ctr.NumberEdit xPos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label tabSize;
    }
}