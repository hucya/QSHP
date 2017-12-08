using QSHP.UI.Ctr;

namespace QSHP.UI
{
    partial class ChannelCtr
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.tOffset = new QSHP.UI.Ctr.NumberEdit();
            this.yOffset = new QSHP.UI.Ctr.NumberEdit();
            this.rotatePos = new QSHP.UI.Ctr.NumberEdit();
            this.stepEdit = new QSHP.UI.Ctr.NumberEdit();
            this.cycleTime = new QSHP.UI.Ctr.NumberEdit();
            this.pauseValue = new QSHP.UI.Ctr.NumberEdit();
            this.pauseStyle = new QSHP.UI.Ctr.ComboBoxEx();
            this.cutStyle = new QSHP.UI.Ctr.ComboBoxEx();
            this.stepEdit2 = new QSHP.UI.Ctr.NumberEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.cutSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.cutNum = new QSHP.UI.Ctr.NumberEdit();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.tOffset);
            this.groupBox.Controls.Add(this.yOffset);
            this.groupBox.Controls.Add(this.rotatePos);
            this.groupBox.Controls.Add(this.stepEdit);
            this.groupBox.Controls.Add(this.cycleTime);
            this.groupBox.Controls.Add(this.pauseValue);
            this.groupBox.Controls.Add(this.pauseStyle);
            this.groupBox.Controls.Add(this.cutStyle);
            this.groupBox.Controls.Add(this.stepEdit2);
            this.groupBox.Controls.Add(this.label15);
            this.groupBox.Controls.Add(this.cutSpeed);
            this.groupBox.Controls.Add(this.cutNum);
            this.groupBox.Controls.Add(this.label18);
            this.groupBox.Controls.Add(this.label20);
            this.groupBox.Controls.Add(this.label21);
            this.groupBox.Controls.Add(this.label22);
            this.groupBox.Controls.Add(this.label23);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label24);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.label25);
            this.groupBox.Controls.Add(this.label26);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(578, 158);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "CH1通道";
            // 
            // tOffset
            // 
            this.tOffset.BackColor = System.Drawing.SystemColors.Window;
            this.tOffset.DecPlaces = 3;
            this.tOffset.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.tOffset.Location = new System.Drawing.Point(478, 122);
            this.tOffset.Maximum = 360F;
            this.tOffset.Minimum = -360F;
            this.tOffset.Name = "tOffset";
            this.tOffset.SetError = false;
            this.tOffset.SetWarn = false;
            this.tOffset.Size = new System.Drawing.Size(90, 30);
            this.tOffset.TabIndex = 8;
            this.tOffset.Text = "0";
            this.tOffset.Unit = "mm";
            this.tOffset.Value = 0F;
            // 
            // yOffset
            // 
            this.yOffset.BackColor = System.Drawing.SystemColors.Window;
            this.yOffset.DecPlaces = 3;
            this.yOffset.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.yOffset.Location = new System.Drawing.Point(291, 122);
            this.yOffset.Maximum = 300F;
            this.yOffset.Minimum = -300F;
            this.yOffset.Name = "yOffset";
            this.yOffset.SetError = false;
            this.yOffset.SetWarn = false;
            this.yOffset.Size = new System.Drawing.Size(90, 30);
            this.yOffset.TabIndex = 7;
            this.yOffset.Text = "0";
            this.yOffset.Unit = "mm";
            this.yOffset.Value = 0F;
            // 
            // rotatePos
            // 
            this.rotatePos.BackColor = System.Drawing.SystemColors.Window;
            this.rotatePos.DecPlaces = 3;
            this.rotatePos.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.rotatePos.Location = new System.Drawing.Point(291, 22);
            this.rotatePos.Maximum = 380F;
            this.rotatePos.Minimum = 0F;
            this.rotatePos.Name = "rotatePos";
            this.rotatePos.SetError = false;
            this.rotatePos.SetWarn = false;
            this.rotatePos.Size = new System.Drawing.Size(90, 30);
            this.rotatePos.TabIndex = 1;
            this.rotatePos.Text = "0";
            this.rotatePos.Unit = "mm";
            this.rotatePos.Value = 0F;
            this.rotatePos.ValueChanged += new System.EventHandler(this.IndexStep_ValueChanged);
            // 
            // stepEdit
            // 
            this.stepEdit.BackColor = System.Drawing.SystemColors.Window;
            this.stepEdit.DecPlaces = 3;
            this.stepEdit.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.stepEdit.Location = new System.Drawing.Point(291, 55);
            this.stepEdit.Maximum = 300F;
            this.stepEdit.Minimum = 0F;
            this.stepEdit.Name = "stepEdit";
            this.stepEdit.SetError = false;
            this.stepEdit.SetWarn = false;
            this.stepEdit.Size = new System.Drawing.Size(90, 30);
            this.stepEdit.TabIndex = 1;
            this.stepEdit.Text = "0";
            this.stepEdit.Unit = "mm";
            this.stepEdit.Value = 0F;
            this.stepEdit.ValueChanged += new System.EventHandler(this.IndexStep_ValueChanged);
            // 
            // cycleTime
            // 
            this.cycleTime.BackColor = System.Drawing.SystemColors.Window;
            this.cycleTime.DecPlaces = 0;
            this.cycleTime.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.cycleTime.Location = new System.Drawing.Point(478, 89);
            this.cycleTime.Maximum = 10F;
            this.cycleTime.Minimum = 0F;
            this.cycleTime.Name = "cycleTime";
            this.cycleTime.SetError = false;
            this.cycleTime.SetWarn = false;
            this.cycleTime.Size = new System.Drawing.Size(90, 30);
            this.cycleTime.TabIndex = 5;
            this.cycleTime.Text = "0";
            this.cycleTime.Unit = "mm";
            this.cycleTime.Value = 0F;
            // 
            // pauseValue
            // 
            this.pauseValue.BackColor = System.Drawing.SystemColors.Window;
            this.pauseValue.DecPlaces = 0;
            this.pauseValue.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.pauseValue.Location = new System.Drawing.Point(91, 55);
            this.pauseValue.Maximum = 999F;
            this.pauseValue.Minimum = 0F;
            this.pauseValue.Name = "pauseValue";
            this.pauseValue.SetError = false;
            this.pauseValue.SetWarn = false;
            this.pauseValue.Size = new System.Drawing.Size(105, 30);
            this.pauseValue.TabIndex = 0;
            this.pauseValue.Text = "0";
            this.pauseValue.Unit = "mm";
            this.pauseValue.Value = 0F;
            // 
            // pauseStyle
            // 
            this.pauseStyle.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pauseStyle.FormattingEnabled = true;
            this.pauseStyle.Items.AddRange(new object[] {
            "不暂停",
            "起止暂停",
            "每隔暂停",
            "累计暂停"});
            this.pauseStyle.Location = new System.Drawing.Point(91, 90);
            this.pauseStyle.Name = "pauseStyle";
            this.pauseStyle.Size = new System.Drawing.Size(105, 29);
            this.pauseStyle.TabIndex = 3;
            this.pauseStyle.Text = "每隔暂停";
            // 
            // cutStyle
            // 
            this.cutStyle.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cutStyle.FormattingEnabled = true;
            this.cutStyle.Items.AddRange(new object[] {
            "从前往后",
            "从后往前",
            "对准点向前",
            "对准点向后"});
            this.cutStyle.Location = new System.Drawing.Point(91, 123);
            this.cutStyle.Name = "cutStyle";
            this.cutStyle.Size = new System.Drawing.Size(105, 29);
            this.cutStyle.TabIndex = 6;
            this.cutStyle.Text = "从前往后";
            this.cutStyle.SelectedIndexChanged += new System.EventHandler(this.ComboBox3_SelectedIndexChanged);
            // 
            // stepEdit2
            // 
            this.stepEdit2.BackColor = System.Drawing.SystemColors.Window;
            this.stepEdit2.DecPlaces = 0;
            this.stepEdit2.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.stepEdit2.Location = new System.Drawing.Point(291, 89);
            this.stepEdit2.Maximum = 300F;
            this.stepEdit2.Minimum = 0F;
            this.stepEdit2.Name = "stepEdit2";
            this.stepEdit2.SetError = false;
            this.stepEdit2.SetWarn = false;
            this.stepEdit2.Size = new System.Drawing.Size(90, 30);
            this.stepEdit2.TabIndex = 4;
            this.stepEdit2.Text = "0";
            this.stepEdit2.Unit = "mm";
            this.stepEdit2.Value = 0F;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label15.Location = new System.Drawing.Point(392, 127);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "T 轴偏移: ";
            // 
            // cutSpeed
            // 
            this.cutSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.cutSpeed.DecPlaces = 0;
            this.cutSpeed.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.cutSpeed.Location = new System.Drawing.Point(478, 22);
            this.cutSpeed.Maximum = 1000F;
            this.cutSpeed.Minimum = 0F;
            this.cutSpeed.Name = "cutSpeed";
            this.cutSpeed.SetError = false;
            this.cutSpeed.SetWarn = false;
            this.cutSpeed.Size = new System.Drawing.Size(90, 30);
            this.cutSpeed.TabIndex = 2;
            this.cutSpeed.Text = "0";
            this.cutSpeed.Unit = "mm";
            this.cutSpeed.Value = 0F;
            // 
            // cutNum
            // 
            this.cutNum.BackColor = System.Drawing.SystemColors.Window;
            this.cutNum.DecPlaces = 0;
            this.cutNum.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.cutNum.Location = new System.Drawing.Point(478, 55);
            this.cutNum.Maximum = 99999F;
            this.cutNum.Minimum = 0F;
            this.cutNum.Name = "cutNum";
            this.cutNum.SetError = false;
            this.cutNum.SetWarn = false;
            this.cutNum.Size = new System.Drawing.Size(90, 30);
            this.cutNum.TabIndex = 2;
            this.cutNum.Text = "0";
            this.cutNum.Unit = "mm";
            this.cutNum.Value = 0F;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label18.Location = new System.Drawing.Point(392, 94);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 21);
            this.label18.TabIndex = 0;
            this.label18.Text = "循环次数: ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label20.Location = new System.Drawing.Point(205, 127);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 21);
            this.label20.TabIndex = 0;
            this.label20.Text = "Y 轴偏移: ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label21.Location = new System.Drawing.Point(11, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 21);
            this.label21.TabIndex = 0;
            this.label21.Text = "暂停刀数:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label22.Location = new System.Drawing.Point(11, 127);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 21);
            this.label22.TabIndex = 0;
            this.label22.Text = "划切方向:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label23.Location = new System.Drawing.Point(205, 94);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 21);
            this.label23.TabIndex = 0;
            this.label23.Text = "分度二: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(392, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "划切速度: ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label24.Location = new System.Drawing.Point(11, 94);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(78, 21);
            this.label24.TabIndex = 0;
            this.label24.Text = "暂停模式:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(205, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "旋转角度: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label25.Location = new System.Drawing.Point(392, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 21);
            this.label25.TabIndex = 0;
            this.label25.Text = "划切刀数: ";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label26.Location = new System.Drawing.Point(205, 60);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 21);
            this.label26.TabIndex = 0;
            this.label26.Text = "划切分度: ";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChannelCtr
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox);
            this.DoubleBuffered = true;
            this.Name = "ChannelCtr";
            this.Size = new System.Drawing.Size(578, 158);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private Ctr.NumberEdit tOffset;
        private Ctr.NumberEdit yOffset;
        private Ctr.NumberEdit cycleTime;
        private Ctr.NumberEdit pauseValue;
        private ComboBoxEx cutStyle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private ComboBoxEx pauseStyle;
        public NumberEdit cutNum;
        public NumberEdit stepEdit2;
        public NumberEdit stepEdit;
        public NumberEdit rotatePos;
        public NumberEdit cutSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
