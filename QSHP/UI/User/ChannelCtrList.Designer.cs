namespace QSHP.UI.User
{
    partial class ChannelCtrList
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.enableBt = new System.Windows.Forms.CheckBox();
            this.panelEx1 = new QSHP.UI.Ctr.PanelEx();
            this.cutDir = new QSHP.UI.Ctr.ComboBoxEx();
            this.pauseMode = new QSHP.UI.Ctr.ComboBoxEx();
            this.pauseLine = new QSHP.UI.Ctr.NumberEdit();
            this.tStartPos = new QSHP.UI.Ctr.NumberEdit();
            this.tOffset = new QSHP.UI.Ctr.NumberEdit();
            this.yOffset = new QSHP.UI.Ctr.NumberEdit();
            this.cutLeave2 = new QSHP.UI.Ctr.NumberEdit();
            this.cutLine = new QSHP.UI.Ctr.NumberEdit();
            this.cutStep = new QSHP.UI.Ctr.NumberEdit();
            this.cutLeave = new QSHP.UI.Ctr.NumberEdit();
            this.cutSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // enableBt
            // 
            this.enableBt.AutoSize = true;
            this.enableBt.Dock = System.Windows.Forms.DockStyle.Top;
            this.enableBt.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.enableBt.Location = new System.Drawing.Point(0, 0);
            this.enableBt.Name = "enableBt";
            this.enableBt.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.enableBt.Size = new System.Drawing.Size(70, 26);
            this.enableBt.TabIndex = 0;
            this.enableBt.Text = "CH1";
            this.enableBt.UseVisualStyleBackColor = true;
            this.enableBt.CheckedChanged += new System.EventHandler(this.enableBt_CheckedChanged);
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.cutDir);
            this.panelEx1.Controls.Add(this.pauseMode);
            this.panelEx1.Controls.Add(this.pauseLine);
            this.panelEx1.Controls.Add(this.tStartPos);
            this.panelEx1.Controls.Add(this.tOffset);
            this.panelEx1.Controls.Add(this.yOffset);
            this.panelEx1.Controls.Add(this.cutLeave2);
            this.panelEx1.Controls.Add(this.cutLine);
            this.panelEx1.Controls.Add(this.cutStep);
            this.panelEx1.Controls.Add(this.cutLeave);
            this.panelEx1.Controls.Add(this.cutSpeed);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Enabled = false;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 18F);
            this.panelEx1.LeftMode = false;
            this.panelEx1.Location = new System.Drawing.Point(0, 26);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(70, 390);
            this.panelEx1.TabIndex = 2;
            // 
            // cutDir
            // 
            this.cutDir.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cutDir.FormattingEnabled = true;
            this.cutDir.Items.AddRange(new object[] {
            "F→B",
            "B→F",
            "A→F",
            "A→B"});
            this.cutDir.Location = new System.Drawing.Point(3, 356);
            this.cutDir.Margin = new System.Windows.Forms.Padding(0);
            this.cutDir.Name = "cutDir";
            this.cutDir.Size = new System.Drawing.Size(63, 29);
            this.cutDir.TabIndex = 10;
            this.cutDir.Text = "B→F";
            // 
            // pauseMode
            // 
            this.pauseMode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pauseMode.FormattingEnabled = true;
            this.pauseMode.Items.AddRange(new object[] {
            "无",
            "起止",
            "每隔",
            "累计"});
            this.pauseMode.Location = new System.Drawing.Point(3, 321);
            this.pauseMode.Margin = new System.Windows.Forms.Padding(0);
            this.pauseMode.Name = "pauseMode";
            this.pauseMode.Size = new System.Drawing.Size(63, 29);
            this.pauseMode.TabIndex = 9;
            this.pauseMode.Text = "起止";
            // 
            // pauseLine
            // 
            this.pauseLine.BackColor = System.Drawing.SystemColors.Window;
            this.pauseLine.DecPlaces = 0;
            this.pauseLine.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pauseLine.Location = new System.Drawing.Point(3, 286);
            this.pauseLine.Margin = new System.Windows.Forms.Padding(0);
            this.pauseLine.Maximum = 1000F;
            this.pauseLine.Minimum = 0F;
            this.pauseLine.Name = "pauseLine";
            this.pauseLine.SetError = false;
            this.pauseLine.SetWarn = false;
            this.pauseLine.Size = new System.Drawing.Size(63, 29);
            this.pauseLine.TabIndex = 8;
            this.pauseLine.Text = "0";
            this.pauseLine.Unit = "mm";
            this.pauseLine.Value = 0F;
            // 
            // tStartPos
            // 
            this.tStartPos.BackColor = System.Drawing.SystemColors.Window;
            this.tStartPos.DecPlaces = 3;
            this.tStartPos.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tStartPos.Location = new System.Drawing.Point(3, 251);
            this.tStartPos.Margin = new System.Windows.Forms.Padding(0);
            this.tStartPos.Maximum = 380F;
            this.tStartPos.Minimum = 0F;
            this.tStartPos.Name = "tStartPos";
            this.tStartPos.SetError = false;
            this.tStartPos.SetWarn = false;
            this.tStartPos.Size = new System.Drawing.Size(63, 29);
            this.tStartPos.TabIndex = 7;
            this.tStartPos.Text = "0";
            this.tStartPos.Unit = "mm";
            this.tStartPos.Value = 0F;
            // 
            // tOffset
            // 
            this.tOffset.BackColor = System.Drawing.SystemColors.Window;
            this.tOffset.DecPlaces = 3;
            this.tOffset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tOffset.Location = new System.Drawing.Point(3, 216);
            this.tOffset.Margin = new System.Windows.Forms.Padding(0);
            this.tOffset.Maximum = 380F;
            this.tOffset.Minimum = 0F;
            this.tOffset.Name = "tOffset";
            this.tOffset.SetError = false;
            this.tOffset.SetWarn = false;
            this.tOffset.Size = new System.Drawing.Size(63, 29);
            this.tOffset.TabIndex = 6;
            this.tOffset.Text = "0";
            this.tOffset.Unit = "mm";
            this.tOffset.Value = 0F;
            // 
            // yOffset
            // 
            this.yOffset.BackColor = System.Drawing.SystemColors.Window;
            this.yOffset.DecPlaces = 3;
            this.yOffset.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.yOffset.Location = new System.Drawing.Point(3, 181);
            this.yOffset.Margin = new System.Windows.Forms.Padding(0);
            this.yOffset.Maximum = 1000F;
            this.yOffset.Minimum = 0F;
            this.yOffset.Name = "yOffset";
            this.yOffset.SetError = false;
            this.yOffset.SetWarn = false;
            this.yOffset.Size = new System.Drawing.Size(63, 29);
            this.yOffset.TabIndex = 5;
            this.yOffset.Text = "0";
            this.yOffset.Unit = "mm";
            this.yOffset.Value = 0F;
            // 
            // cutLeave2
            // 
            this.cutLeave2.BackColor = System.Drawing.SystemColors.Window;
            this.cutLeave2.DecPlaces = 3;
            this.cutLeave2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cutLeave2.Location = new System.Drawing.Point(3, 76);
            this.cutLeave2.Margin = new System.Windows.Forms.Padding(0);
            this.cutLeave2.Maximum = 30F;
            this.cutLeave2.Minimum = 0F;
            this.cutLeave2.Name = "cutLeave2";
            this.cutLeave2.SetError = false;
            this.cutLeave2.SetWarn = false;
            this.cutLeave2.Size = new System.Drawing.Size(63, 29);
            this.cutLeave2.TabIndex = 2;
            this.cutLeave2.Text = "0";
            this.cutLeave2.Unit = "mm";
            this.cutLeave2.Value = 0F;
            // 
            // cutLine
            // 
            this.cutLine.BackColor = System.Drawing.SystemColors.Window;
            this.cutLine.DecPlaces = 0;
            this.cutLine.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cutLine.Location = new System.Drawing.Point(3, 146);
            this.cutLine.Margin = new System.Windows.Forms.Padding(0);
            this.cutLine.Maximum = 1000F;
            this.cutLine.Minimum = 0F;
            this.cutLine.Name = "cutLine";
            this.cutLine.SetError = false;
            this.cutLine.SetWarn = false;
            this.cutLine.Size = new System.Drawing.Size(63, 29);
            this.cutLine.TabIndex = 4;
            this.cutLine.Text = "10";
            this.cutLine.Unit = "mm";
            this.cutLine.Value = 10F;
            // 
            // cutStep
            // 
            this.cutStep.BackColor = System.Drawing.SystemColors.Window;
            this.cutStep.DecPlaces = 3;
            this.cutStep.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cutStep.Location = new System.Drawing.Point(3, 111);
            this.cutStep.Margin = new System.Windows.Forms.Padding(0);
            this.cutStep.Maximum = 300F;
            this.cutStep.Minimum = 0F;
            this.cutStep.Name = "cutStep";
            this.cutStep.SetError = false;
            this.cutStep.SetWarn = false;
            this.cutStep.Size = new System.Drawing.Size(63, 29);
            this.cutStep.TabIndex = 3;
            this.cutStep.Text = "2";
            this.cutStep.Unit = "mm";
            this.cutStep.Value = 2F;
            // 
            // cutLeave
            // 
            this.cutLeave.BackColor = System.Drawing.SystemColors.Window;
            this.cutLeave.DecPlaces = 3;
            this.cutLeave.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cutLeave.Location = new System.Drawing.Point(3, 41);
            this.cutLeave.Margin = new System.Windows.Forms.Padding(0);
            this.cutLeave.Maximum = 30F;
            this.cutLeave.Minimum = 0F;
            this.cutLeave.Name = "cutLeave";
            this.cutLeave.SetError = false;
            this.cutLeave.SetWarn = false;
            this.cutLeave.Size = new System.Drawing.Size(63, 29);
            this.cutLeave.TabIndex = 1;
            this.cutLeave.Text = "2";
            this.cutLeave.Unit = "mm";
            this.cutLeave.Value = 2F;
            // 
            // cutSpeed
            // 
            this.cutSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.cutSpeed.DecPlaces = 0;
            this.cutSpeed.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cutSpeed.Location = new System.Drawing.Point(3, 6);
            this.cutSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.cutSpeed.Maximum = 600F;
            this.cutSpeed.Minimum = 0F;
            this.cutSpeed.Name = "cutSpeed";
            this.cutSpeed.SetError = false;
            this.cutSpeed.SetWarn = false;
            this.cutSpeed.Size = new System.Drawing.Size(63, 29);
            this.cutSpeed.TabIndex = 0;
            this.cutSpeed.Text = "50";
            this.cutSpeed.Unit = "mm";
            this.cutSpeed.Value = 50F;
            // 
            // ChannelCtrList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.enableBt);
            this.Name = "ChannelCtrList";
            this.Size = new System.Drawing.Size(70, 416);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox enableBt;
        private Ctr.PanelEx panelEx1;
        private Ctr.ComboBoxEx cutDir;
        private Ctr.ComboBoxEx pauseMode;
        private Ctr.NumberEdit pauseLine;
        private Ctr.NumberEdit tStartPos;
        private Ctr.NumberEdit tOffset;
        private Ctr.NumberEdit yOffset;
        private Ctr.NumberEdit cutLeave2;
        private Ctr.NumberEdit cutLine;
        private Ctr.NumberEdit cutStep;
        private Ctr.NumberEdit cutLeave;
        private Ctr.NumberEdit cutSpeed;
    }
}
