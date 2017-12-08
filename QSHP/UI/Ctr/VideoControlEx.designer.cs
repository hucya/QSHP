namespace QSHP.UI.Ctr
{
    partial class VideoControlEx
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
            this.panelEx1 = new QSHP.UI.Ctr.PanelEx();
            this.TV = new System.Windows.Forms.Label();
            this.RV = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Rbar = new QSHP.UI.Ctr.TrackBarEx();
            this.Tbar = new QSHP.UI.Ctr.TrackBarEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lrb = new System.Windows.Forms.RadioButton();
            this.Mrb = new System.Windows.Forms.RadioButton();
            this.Hrb = new System.Windows.Forms.RadioButton();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.TV);
            this.panelEx1.Controls.Add(this.RV);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.Rbar);
            this.panelEx1.Controls.Add(this.Tbar);
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 18F);
            this.panelEx1.LeftMode = false;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(157, 157);
            this.panelEx1.TabIndex = 0;
            // 
            // TV
            // 
            this.TV.AutoSize = true;
            this.TV.BackColor = System.Drawing.Color.Transparent;
            this.TV.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TV.Location = new System.Drawing.Point(84, 40);
            this.TV.Name = "TV";
            this.TV.Size = new System.Drawing.Size(29, 17);
            this.TV.TabIndex = 29;
            this.TV.Text = "300";
            this.TV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RV
            // 
            this.RV.AutoSize = true;
            this.RV.BackColor = System.Drawing.Color.Transparent;
            this.RV.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RV.Location = new System.Drawing.Point(87, 3);
            this.RV.Name = "RV";
            this.RV.Size = new System.Drawing.Size(22, 17);
            this.RV.TabIndex = 28;
            this.RV.Text = "30";
            this.RV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "曝光:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "增益:";
            // 
            // Rbar
            // 
            this.Rbar.AutoSize = false;
            this.Rbar.Location = new System.Drawing.Point(39, 19);
            this.Rbar.Maximum = 63;
            this.Rbar.Name = "Rbar";
            this.Rbar.Size = new System.Drawing.Size(122, 32);
            this.Rbar.TabIndex = 25;
            this.Rbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Rbar.Value = 30;
            this.Rbar.ValueChanged += new System.EventHandler(this.Rbar_ValueChanged);
            // 
            // Tbar
            // 
            this.Tbar.AutoSize = false;
            this.Tbar.Location = new System.Drawing.Point(39, 59);
            this.Tbar.Maximum = 1000;
            this.Tbar.Minimum = 50;
            this.Tbar.Name = "Tbar";
            this.Tbar.Size = new System.Drawing.Size(122, 32);
            this.Tbar.TabIndex = 31;
            this.Tbar.TickFrequency = 10;
            this.Tbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Tbar.Value = 300;
            this.Tbar.ValueChanged += new System.EventHandler(this.Tbar_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Hrb);
            this.groupBox1.Controls.Add(this.Mrb);
            this.groupBox1.Controls.Add(this.Lrb);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(1, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 65);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模式:";
            // 
            // Lrb
            // 
            this.Lrb.AutoSize = true;
            this.Lrb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lrb.Location = new System.Drawing.Point(109, 29);
            this.Lrb.Name = "Lrb";
            this.Lrb.Size = new System.Drawing.Size(38, 21);
            this.Lrb.TabIndex = 0;
            this.Lrb.Text = "低";
            this.Lrb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lrb.UseVisualStyleBackColor = true;
            this.Lrb.CheckedChanged += new System.EventHandler(this.Lrb_CheckedChanged);
            // 
            // Mrb
            // 
            this.Mrb.AutoSize = true;
            this.Mrb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Mrb.Location = new System.Drawing.Point(61, 29);
            this.Mrb.Name = "Mrb";
            this.Mrb.Size = new System.Drawing.Size(38, 21);
            this.Mrb.TabIndex = 0;
            this.Mrb.Text = "中";
            this.Mrb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Mrb.UseVisualStyleBackColor = true;
            this.Mrb.CheckedChanged += new System.EventHandler(this.Mrb_CheckedChanged);
            // 
            // Hrb
            // 
            this.Hrb.AutoSize = true;
            this.Hrb.Checked = true;
            this.Hrb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Hrb.Location = new System.Drawing.Point(13, 29);
            this.Hrb.Name = "Hrb";
            this.Hrb.Size = new System.Drawing.Size(38, 21);
            this.Hrb.TabIndex = 0;
            this.Hrb.TabStop = true;
            this.Hrb.Text = "高";
            this.Hrb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Hrb.UseVisualStyleBackColor = true;
            this.Hrb.CheckedChanged += new System.EventHandler(this.Hrb_CheckedChanged);
            // 
            // VideoControlEx
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelEx1);
            this.Name = "VideoControlEx";
            this.Size = new System.Drawing.Size(157, 157);
            this.VisibleChanged += new System.EventHandler(this.VideoControlEx_VisibleChanged);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Rbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tbar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PanelEx panelEx1;
        private System.Windows.Forms.Label TV;
        private System.Windows.Forms.Label RV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private TrackBarEx Rbar;
        private TrackBarEx Tbar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Hrb;
        private System.Windows.Forms.RadioButton Mrb;
        private System.Windows.Forms.RadioButton Lrb;
    }
}
