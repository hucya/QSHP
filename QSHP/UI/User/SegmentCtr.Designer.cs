namespace QSHP.UI.User
{
    partial class SegmentCtr
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
            this.panelEx1 = new QSHP.UI.Ctr.PanelEx();
            this.cutLeave2 = new QSHP.UI.Ctr.NumberEdit();
            this.cutLine = new QSHP.UI.Ctr.NumberEdit();
            this.cutStep = new QSHP.UI.Ctr.NumberEdit();
            this.cutLeave = new QSHP.UI.Ctr.NumberEdit();
            this.cutSpeed = new QSHP.UI.Ctr.NumberEdit();
            this.enableBt = new System.Windows.Forms.CheckBox();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
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
            this.panelEx1.Size = new System.Drawing.Size(70, 184);
            this.panelEx1.TabIndex = 4;
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
            this.cutSpeed.Maximum = 1000F;
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
            // enableBt
            // 
            this.enableBt.AutoSize = true;
            this.enableBt.Dock = System.Windows.Forms.DockStyle.Top;
            this.enableBt.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.enableBt.Location = new System.Drawing.Point(0, 0);
            this.enableBt.Name = "enableBt";
            this.enableBt.Padding = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.enableBt.Size = new System.Drawing.Size(70, 26);
            this.enableBt.TabIndex = 3;
            this.enableBt.Text = "SG";
            this.enableBt.UseVisualStyleBackColor = true;
            this.enableBt.CheckedChanged += new System.EventHandler(this.EnableBt_CheckedChanged);
            // 
            // SegmentCtr
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.enableBt);
            this.Name = "SegmentCtr";
            this.Size = new System.Drawing.Size(70, 210);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctr.PanelEx panelEx1;
        private Ctr.NumberEdit cutLeave2;
        private Ctr.NumberEdit cutLine;
        private Ctr.NumberEdit cutStep;
        private Ctr.NumberEdit cutLeave;
        private Ctr.NumberEdit cutSpeed;
        private System.Windows.Forms.CheckBox enableBt;
    }
}
