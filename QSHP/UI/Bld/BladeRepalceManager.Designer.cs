namespace QSHP.UI.Bld
{
    partial class BladeRepalceManager
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
            this.flangeDiameter = new QSHP.UI.Ctr.NumberEdit();
            this.bldDiameter = new QSHP.UI.Ctr.NumberEdit();
            this.bldTicknessEdit = new QSHP.UI.Ctr.NumberEdit();
            this.bldTypeEdit = new QSHP.UI.Ctr.ComboBoxEx();
            this.bldNumEdit = new QSHP.UI.Ctr.TextBoxEx();
            this.bldModelEdit = new QSHP.UI.Ctr.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.repalceResult = new QSHP.UI.Ctr.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.selfWarnEdit = new QSHP.UI.Ctr.NumberEdit();
            this.maxCutLineEdit = new QSHP.UI.Ctr.NumberEdit();
            this.maxCutLenEdit = new QSHP.UI.Ctr.NumberEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.depthCompensatedValue = new QSHP.UI.Ctr.NumberEdit();
            this.depthCompensatedLen = new QSHP.UI.Ctr.NumberEdit();
            this.depthCompensatedLines = new QSHP.UI.Ctr.NumberEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.depthCompensatedMode = new QSHP.UI.Ctr.ComboBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.handTestValue = new QSHP.UI.Ctr.NumberEdit();
            this.usedHandTest = new QSHP.UI.Ctr.ComboBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flangeDiameter);
            this.groupBox1.Controls.Add(this.bldDiameter);
            this.groupBox1.Controls.Add(this.bldTicknessEdit);
            this.groupBox1.Controls.Add(this.bldTypeEdit);
            this.groupBox1.Controls.Add(this.bldNumEdit);
            this.groupBox1.Controls.Add(this.bldModelEdit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " 刀具基本参数";
            // 
            // flangeDiameter
            // 
            this.flangeDiameter.BackColor = System.Drawing.SystemColors.Window;
            this.flangeDiameter.DecPlaces = 3;
            this.flangeDiameter.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.flangeDiameter.Location = new System.Drawing.Point(640, 122);
            this.flangeDiameter.Maximum = 70F;
            this.flangeDiameter.Minimum = 20F;
            this.flangeDiameter.Name = "flangeDiameter";
            this.flangeDiameter.SetError = false;
            this.flangeDiameter.SetWarn = false;
            this.flangeDiameter.Size = new System.Drawing.Size(106, 30);
            this.flangeDiameter.TabIndex = 5;
            this.flangeDiameter.Text = "49.4";
            this.flangeDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.flangeDiameter.Unit = "mm";
            this.flangeDiameter.Value = 49.4F;
            // 
            // bldDiameter
            // 
            this.bldDiameter.BackColor = System.Drawing.SystemColors.Window;
            this.bldDiameter.DecPlaces = 3;
            this.bldDiameter.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.bldDiameter.Location = new System.Drawing.Point(640, 79);
            this.bldDiameter.Maximum = 70F;
            this.bldDiameter.Minimum = 20F;
            this.bldDiameter.Name = "bldDiameter";
            this.bldDiameter.SetError = false;
            this.bldDiameter.SetWarn = false;
            this.bldDiameter.Size = new System.Drawing.Size(106, 30);
            this.bldDiameter.TabIndex = 5;
            this.bldDiameter.Text = "56";
            this.bldDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bldDiameter.Unit = "mm";
            this.bldDiameter.Value = 56F;
            // 
            // bldTicknessEdit
            // 
            this.bldTicknessEdit.BackColor = System.Drawing.SystemColors.Window;
            this.bldTicknessEdit.DecPlaces = 3;
            this.bldTicknessEdit.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.bldTicknessEdit.Location = new System.Drawing.Point(640, 36);
            this.bldTicknessEdit.Maximum = 5F;
            this.bldTicknessEdit.Minimum = 0.001F;
            this.bldTicknessEdit.Name = "bldTicknessEdit";
            this.bldTicknessEdit.SetError = false;
            this.bldTicknessEdit.SetWarn = false;
            this.bldTicknessEdit.Size = new System.Drawing.Size(106, 30);
            this.bldTicknessEdit.TabIndex = 5;
            this.bldTicknessEdit.Text = "0.03";
            this.bldTicknessEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bldTicknessEdit.Unit = "mm";
            this.bldTicknessEdit.Value = 0.03F;
            // 
            // bldTypeEdit
            // 
            this.bldTypeEdit.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.bldTypeEdit.FormattingEnabled = true;
            this.bldTypeEdit.Items.AddRange(new object[] {
            "软刀",
            "硬刀"});
            this.bldTypeEdit.Location = new System.Drawing.Point(247, 122);
            this.bldTypeEdit.Name = "bldTypeEdit";
            this.bldTypeEdit.Size = new System.Drawing.Size(106, 31);
            this.bldTypeEdit.TabIndex = 4;
            this.bldTypeEdit.Text = "软刀";
            // 
            // bldNumEdit
            // 
            this.bldNumEdit.BackColor = System.Drawing.SystemColors.Window;
            this.bldNumEdit.Enabled = false;
            this.bldNumEdit.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.bldNumEdit.Location = new System.Drawing.Point(247, 79);
            this.bldNumEdit.Name = "bldNumEdit";
            this.bldNumEdit.SetError = false;
            this.bldNumEdit.SetWarn = false;
            this.bldNumEdit.Size = new System.Drawing.Size(106, 30);
            this.bldNumEdit.TabIndex = 3;
            this.bldNumEdit.Text = "17-10-0001";
            // 
            // bldModelEdit
            // 
            this.bldModelEdit.BackColor = System.Drawing.SystemColors.Window;
            this.bldModelEdit.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.bldModelEdit.Location = new System.Drawing.Point(247, 36);
            this.bldModelEdit.MaxLength = 12;
            this.bldModelEdit.Name = "bldModelEdit";
            this.bldModelEdit.SetError = false;
            this.bldModelEdit.SetWarn = false;
            this.bldModelEdit.Size = new System.Drawing.Size(106, 30);
            this.bldModelEdit.TabIndex = 3;
            this.bldModelEdit.Text = "HT_RM_08";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(449, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "刀具厚度(mm)：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(449, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "法兰直径(mm)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "刀具型号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "刀具直径(mm)：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "刀具类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "刀具编号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.repalceResult);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.selfWarnEdit);
            this.groupBox2.Controls.Add(this.maxCutLineEdit);
            this.groupBox2.Controls.Add(this.maxCutLenEdit);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 192);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "刀具性能参数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "换刀原因：";
            // 
            // repalceResult
            // 
            this.repalceResult.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.repalceResult.FormattingEnabled = true;
            this.repalceResult.Items.AddRange(new object[] {
            "新刀",
            "刀具破损",
            "磨损量超标",
            "刀数超标",
            "崩边过大",
            "其他"});
            this.repalceResult.Location = new System.Drawing.Point(247, 150);
            this.repalceResult.Name = "repalceResult";
            this.repalceResult.Size = new System.Drawing.Size(106, 31);
            this.repalceResult.TabIndex = 4;
            this.repalceResult.Text = "新刀";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(78, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "安全余量(mm)：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "最大划切刀数：";
            // 
            // selfWarnEdit
            // 
            this.selfWarnEdit.BackColor = System.Drawing.SystemColors.Window;
            this.selfWarnEdit.DecPlaces = 3;
            this.selfWarnEdit.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.selfWarnEdit.Location = new System.Drawing.Point(247, 108);
            this.selfWarnEdit.Maximum = 5F;
            this.selfWarnEdit.Minimum = 0.001F;
            this.selfWarnEdit.Name = "selfWarnEdit";
            this.selfWarnEdit.SetError = false;
            this.selfWarnEdit.SetWarn = false;
            this.selfWarnEdit.Size = new System.Drawing.Size(106, 30);
            this.selfWarnEdit.TabIndex = 5;
            this.selfWarnEdit.Text = "0.1";
            this.selfWarnEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.selfWarnEdit.Unit = "mm";
            this.selfWarnEdit.Value = 0.1F;
            // 
            // maxCutLineEdit
            // 
            this.maxCutLineEdit.BackColor = System.Drawing.SystemColors.Window;
            this.maxCutLineEdit.DecPlaces = 0;
            this.maxCutLineEdit.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.maxCutLineEdit.Location = new System.Drawing.Point(247, 68);
            this.maxCutLineEdit.Maximum = 1E+08F;
            this.maxCutLineEdit.Minimum = 0F;
            this.maxCutLineEdit.Name = "maxCutLineEdit";
            this.maxCutLineEdit.SetError = false;
            this.maxCutLineEdit.SetWarn = false;
            this.maxCutLineEdit.Size = new System.Drawing.Size(106, 30);
            this.maxCutLineEdit.TabIndex = 5;
            this.maxCutLineEdit.Text = "500000";
            this.maxCutLineEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxCutLineEdit.Unit = "mm";
            this.maxCutLineEdit.Value = 500000F;
            // 
            // maxCutLenEdit
            // 
            this.maxCutLenEdit.BackColor = System.Drawing.SystemColors.Window;
            this.maxCutLenEdit.DecPlaces = 3;
            this.maxCutLenEdit.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.maxCutLenEdit.Location = new System.Drawing.Point(247, 28);
            this.maxCutLenEdit.Maximum = 9999999F;
            this.maxCutLenEdit.Minimum = 100F;
            this.maxCutLenEdit.Name = "maxCutLenEdit";
            this.maxCutLenEdit.SetError = false;
            this.maxCutLenEdit.SetWarn = false;
            this.maxCutLenEdit.Size = new System.Drawing.Size(106, 30);
            this.maxCutLenEdit.TabIndex = 5;
            this.maxCutLenEdit.Text = "10000";
            this.maxCutLenEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxCutLenEdit.Unit = "mm";
            this.maxCutLenEdit.Value = 10000F;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "最大划切距离(m)：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.depthCompensatedValue);
            this.groupBox3.Controls.Add(this.depthCompensatedLen);
            this.groupBox3.Controls.Add(this.depthCompensatedLines);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.depthCompensatedMode);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(411, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 192);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "划切深度补偿";
            // 
            // depthCompensatedValue
            // 
            this.depthCompensatedValue.BackColor = System.Drawing.SystemColors.Window;
            this.depthCompensatedValue.DecPlaces = 3;
            this.depthCompensatedValue.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.depthCompensatedValue.Location = new System.Drawing.Point(240, 150);
            this.depthCompensatedValue.Maximum = 5F;
            this.depthCompensatedValue.Minimum = 0F;
            this.depthCompensatedValue.Name = "depthCompensatedValue";
            this.depthCompensatedValue.SetError = false;
            this.depthCompensatedValue.SetWarn = false;
            this.depthCompensatedValue.Size = new System.Drawing.Size(106, 30);
            this.depthCompensatedValue.TabIndex = 5;
            this.depthCompensatedValue.Text = "0.001";
            this.depthCompensatedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.depthCompensatedValue.Unit = "mm";
            this.depthCompensatedValue.Value = 0.001F;
            // 
            // depthCompensatedLen
            // 
            this.depthCompensatedLen.BackColor = System.Drawing.SystemColors.Window;
            this.depthCompensatedLen.DecPlaces = 3;
            this.depthCompensatedLen.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.depthCompensatedLen.Location = new System.Drawing.Point(240, 108);
            this.depthCompensatedLen.Minimum = 0F;
            this.depthCompensatedLen.Name = "depthCompensatedLen";
            this.depthCompensatedLen.SetError = false;
            this.depthCompensatedLen.SetWarn = false;
            this.depthCompensatedLen.Size = new System.Drawing.Size(106, 30);
            this.depthCompensatedLen.TabIndex = 5;
            this.depthCompensatedLen.Text = "1000";
            this.depthCompensatedLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.depthCompensatedLen.Unit = "mm";
            this.depthCompensatedLen.Value = 1000F;
            // 
            // depthCompensatedLines
            // 
            this.depthCompensatedLines.BackColor = System.Drawing.SystemColors.Window;
            this.depthCompensatedLines.DecPlaces = 0;
            this.depthCompensatedLines.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.depthCompensatedLines.Location = new System.Drawing.Point(240, 68);
            this.depthCompensatedLines.Maximum = 500000F;
            this.depthCompensatedLines.Minimum = 0F;
            this.depthCompensatedLines.Name = "depthCompensatedLines";
            this.depthCompensatedLines.SetError = false;
            this.depthCompensatedLines.SetWarn = false;
            this.depthCompensatedLines.Size = new System.Drawing.Size(106, 30);
            this.depthCompensatedLines.TabIndex = 5;
            this.depthCompensatedLines.Text = "0";
            this.depthCompensatedLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.depthCompensatedLines.Unit = "mm";
            this.depthCompensatedLines.Value = 0F;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(49, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 21);
            this.label13.TabIndex = 2;
            this.label13.Text = "深度补偿模式：";
            // 
            // depthCompensatedMode
            // 
            this.depthCompensatedMode.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.depthCompensatedMode.FormattingEnabled = true;
            this.depthCompensatedMode.Items.AddRange(new object[] {
            "不补偿",
            "刀数补偿",
            "距离补偿",
            "智能补偿"});
            this.depthCompensatedMode.Location = new System.Drawing.Point(240, 28);
            this.depthCompensatedMode.Name = "depthCompensatedMode";
            this.depthCompensatedMode.Size = new System.Drawing.Size(106, 31);
            this.depthCompensatedMode.TabIndex = 4;
            this.depthCompensatedMode.Text = "不补偿";
            this.depthCompensatedMode.SelectedIndexChanged += new System.EventHandler(this.DepthCompensatedMode_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(49, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 21);
            this.label16.TabIndex = 2;
            this.label16.Text = "补偿深度(mm)：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(49, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 21);
            this.label15.TabIndex = 2;
            this.label15.Text = "每隔距离(mm)：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 21);
            this.label14.TabIndex = 2;
            this.label14.Text = "每隔刀数：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(411, 391);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(395, 100);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "操作提示";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label17.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label17.Location = new System.Drawing.Point(44, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(283, 60);
            this.label17.TabIndex = 0;
            this.label17.Text = "1、如为修改刀具配置，请单击“修改”退出\r\n2、如为更换新刀具，请单击“创建”退出\r\n3、更换新刀具后务必进行 <测高> 操作";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.handTestValue);
            this.groupBox5.Controls.Add(this.usedHandTest);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(12, 391);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(393, 100);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "手动测高配置";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(78, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 21);
            this.label12.TabIndex = 2;
            this.label12.Text = "手动输入测高：";
            // 
            // handTestValue
            // 
            this.handTestValue.BackColor = System.Drawing.SystemColors.Window;
            this.handTestValue.DecPlaces = 3;
            this.handTestValue.Enabled = false;
            this.handTestValue.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.handTestValue.Location = new System.Drawing.Point(247, 60);
            this.handTestValue.Maximum = 50F;
            this.handTestValue.Minimum = 0F;
            this.handTestValue.Name = "handTestValue";
            this.handTestValue.SetError = false;
            this.handTestValue.SetWarn = false;
            this.handTestValue.Size = new System.Drawing.Size(106, 30);
            this.handTestValue.TabIndex = 5;
            this.handTestValue.Text = "1";
            this.handTestValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.handTestValue.Unit = "mm";
            this.handTestValue.Value = 1F;
            // 
            // usedHandTest
            // 
            this.usedHandTest.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.usedHandTest.FormattingEnabled = true;
            this.usedHandTest.Items.AddRange(new object[] {
            "禁用",
            "启用"});
            this.usedHandTest.Location = new System.Drawing.Point(247, 23);
            this.usedHandTest.Name = "usedHandTest";
            this.usedHandTest.Size = new System.Drawing.Size(106, 31);
            this.usedHandTest.TabIndex = 4;
            this.usedHandTest.Text = "禁用";
            this.usedHandTest.SelectedIndexChanged += new System.EventHandler(this.usedHandTest_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(78, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "手动测高值(mm)：";
            // 
            // BladeRepalceManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.ConfirmText = "修  改";
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FmStyle = QSHP.FormStyle.NextOKCancel;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "BladeRepalceManager";
            this.NextText = "创  建";
            this.Text = "换刀";
            this.ConfirmClick += new System.EventHandler(this.BladeRepalceManager_ConfirmClick);
            this.NextClick += new System.EventHandler(this.BladeRepalceManager_NextClick);
            this.Load += new System.EventHandler(this.BladeRepalceManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ctr.NumberEdit flangeDiameter;
        private Ctr.NumberEdit bldDiameter;
        private Ctr.NumberEdit bldTicknessEdit;
        private Ctr.ComboBoxEx bldTypeEdit;
        private Ctr.TextBoxEx bldNumEdit;
        private Ctr.TextBoxEx bldModelEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private Ctr.ComboBoxEx repalceResult;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Ctr.NumberEdit selfWarnEdit;
        private Ctr.NumberEdit maxCutLineEdit;
        private Ctr.NumberEdit maxCutLenEdit;
        private System.Windows.Forms.Label label7;
        private Ctr.NumberEdit depthCompensatedValue;
        private Ctr.NumberEdit depthCompensatedLen;
        private Ctr.NumberEdit depthCompensatedLines;
        private System.Windows.Forms.Label label13;
        private Ctr.ComboBoxEx depthCompensatedMode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private Ctr.NumberEdit handTestValue;
        private Ctr.ComboBoxEx usedHandTest;
        private System.Windows.Forms.Label label11;
    }
}