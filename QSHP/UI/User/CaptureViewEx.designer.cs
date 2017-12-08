using QSHP.UI.Ctr;
namespace QSHP.UI
{
    partial class CaptureViewEx
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Axis = new QSHP.UI.Ctr.AxisControlEx();
            this.VC1 = new QSHP.UI.Ctr.VideoControlEx();
            this.imageCtr = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BT8 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.BT7 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.BT6 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.BT5 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.BT4 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.BT3 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.BT2 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.BT1 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCtr)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 522F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 488);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Axis);
            this.panel5.Controls.Add(this.VC1);
            this.panel5.Controls.Add(this.imageCtr);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(2, 2);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(518, 484);
            this.panel5.TabIndex = 43;
            // 
            // Axis
            // 
            this.Axis.AutoScroll = true;
            this.Axis.AutoScrollMinSize = new System.Drawing.Size(150, 150);
            this.Axis.AutoSize = true;
            this.Axis.BackColor = System.Drawing.Color.Transparent;
            this.Axis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Axis.Font = new System.Drawing.Font("QSHP", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Axis.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.Axis.Location = new System.Drawing.Point(360, 324);
            this.Axis.Margin = new System.Windows.Forms.Padding(0);
            this.Axis.MaximumSize = new System.Drawing.Size(157, 157);
            this.Axis.MinimumSize = new System.Drawing.Size(157, 157);
            this.Axis.Name = "Axis";
            this.Axis.Size = new System.Drawing.Size(157, 157);
            this.Axis.TabIndex = 8;
            this.Axis.Visible = false;
            // 
            // VC1
            // 
            this.VC1.BackColor = System.Drawing.Color.Transparent;
            this.VC1.CaptureProvider = null;
            this.VC1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VC1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VC1.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.VC1.Location = new System.Drawing.Point(360, -1);
            this.VC1.Name = "VC1";
            this.VC1.Size = new System.Drawing.Size(157, 157);
            this.VC1.TabIndex = 7;
            this.VC1.Visible = false;
            // 
            // imageCtr
            // 
            this.imageCtr.BackColor = System.Drawing.SystemColors.Control;
            this.imageCtr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageCtr.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imageCtr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageCtr.ErrorImage = null;
            this.imageCtr.InitialImage = null;
            this.imageCtr.Location = new System.Drawing.Point(0, 0);
            this.imageCtr.Margin = new System.Windows.Forms.Padding(0);
            this.imageCtr.Name = "imageCtr";
            this.imageCtr.Size = new System.Drawing.Size(518, 484);
            this.imageCtr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageCtr.TabIndex = 6;
            this.imageCtr.TabStop = false;
            this.imageCtr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageCtr_MouseDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BT8, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.BT7, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.BT6, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.BT5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.BT4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.BT3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.BT2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.BT1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(522, 1);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(60, 485);
            this.tableLayoutPanel2.TabIndex = 42;
            // 
            // BT8
            // 
            this.BT8.AutoSize = true;
            this.BT8.BackColor = System.Drawing.SystemColors.Control;
            this.BT8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BT8.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.BT8.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.BT8.FlatAppearance.BorderSize = 0;
            this.BT8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT8.LED = false;
            this.BT8.LedLocation = new System.Drawing.Point(4, 4);
            this.BT8.Location = new System.Drawing.Point(1, 427);
            this.BT8.Margin = new System.Windows.Forms.Padding(1, 2, 3, 2);
            this.BT8.Name = "BT8";
            this.BT8.NumText = "";
            this.BT8.Pressed = false;
            this.BT8.Size = new System.Drawing.Size(56, 56);
            this.BT8.TabIndex = 7;
            this.BT8.TabStop = false;
            this.BT8.Text = "运动控制";
            this.BT8.UsedLed = false;
            this.BT8.UseVisualStyleBackColor = false;
            this.BT8.Click += new System.EventHandler(this.BT8_Click);
            // 
            // BT7
            // 
            this.BT7.AutoSize = true;
            this.BT7.BackColor = System.Drawing.SystemColors.Control;
            this.BT7.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.BT7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT7.FlatAppearance.BorderSize = 0;
            this.BT7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT7.LED = false;
            this.BT7.LedLocation = new System.Drawing.Point(4, 4);
            this.BT7.Location = new System.Drawing.Point(1, 366);
            this.BT7.Margin = new System.Windows.Forms.Padding(1, 2, 3, 2);
            this.BT7.Name = "BT7";
            this.BT7.NumText = "";
            this.BT7.Pressed = false;
            this.BT7.Size = new System.Drawing.Size(56, 57);
            this.BT7.TabIndex = 6;
            this.BT7.TabStop = false;
            this.BT7.Text = "调窄基线";
            this.BT7.UsedLed = false;
            this.BT7.UseVisualStyleBackColor = false;
            // 
            // BT6
            // 
            this.BT6.AutoSize = true;
            this.BT6.BackColor = System.Drawing.SystemColors.Control;
            this.BT6.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.BT6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT6.FlatAppearance.BorderSize = 0;
            this.BT6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT6.LED = false;
            this.BT6.LedLocation = new System.Drawing.Point(4, 4);
            this.BT6.Location = new System.Drawing.Point(1, 305);
            this.BT6.Margin = new System.Windows.Forms.Padding(1, 2, 3, 2);
            this.BT6.Name = "BT6";
            this.BT6.NumText = "";
            this.BT6.Pressed = false;
            this.BT6.Size = new System.Drawing.Size(56, 57);
            this.BT6.TabIndex = 5;
            this.BT6.TabStop = false;
            this.BT6.Text = "调宽基线";
            this.BT6.UsedLed = false;
            this.BT6.UseVisualStyleBackColor = false;
            // 
            // BT5
            // 
            this.BT5.AutoSize = true;
            this.BT5.BackColor = System.Drawing.SystemColors.Control;
            this.BT5.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.BT5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT5.FlatAppearance.BorderSize = 0;
            this.BT5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT5.LED = false;
            this.BT5.LedLocation = new System.Drawing.Point(4, 4);
            this.BT5.Location = new System.Drawing.Point(1, 244);
            this.BT5.Margin = new System.Windows.Forms.Padding(1, 2, 3, 2);
            this.BT5.Name = "BT5";
            this.BT5.NumText = "";
            this.BT5.Pressed = false;
            this.BT5.Size = new System.Drawing.Size(56, 57);
            this.BT5.TabIndex = 4;
            this.BT5.TabStop = false;
            this.BT5.Tag = "";
            this.BT5.Text = "缩小基线";
            this.BT5.UsedLed = false;
            this.BT5.UseVisualStyleBackColor = false;
            // 
            // BT4
            // 
            this.BT4.AutoSize = true;
            this.BT4.BackColor = System.Drawing.SystemColors.Control;
            this.BT4.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.BT4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT4.FlatAppearance.BorderSize = 0;
            this.BT4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT4.LED = false;
            this.BT4.LedLocation = new System.Drawing.Point(4, 4);
            this.BT4.Location = new System.Drawing.Point(1, 183);
            this.BT4.Margin = new System.Windows.Forms.Padding(1, 2, 3, 2);
            this.BT4.Name = "BT4";
            this.BT4.NumText = "";
            this.BT4.Pressed = false;
            this.BT4.Size = new System.Drawing.Size(56, 57);
            this.BT4.TabIndex = 3;
            this.BT4.TabStop = false;
            this.BT4.Text = "扩大基线";
            this.BT4.UsedLed = false;
            this.BT4.UseVisualStyleBackColor = false;
            // 
            // BT3
            // 
            this.BT3.AutoSize = true;
            this.BT3.BackColor = System.Drawing.SystemColors.Control;
            this.BT3.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.BT3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT3.FlatAppearance.BorderSize = 0;
            this.BT3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT3.LED = false;
            this.BT3.LedLocation = new System.Drawing.Point(4, 4);
            this.BT3.Location = new System.Drawing.Point(1, 122);
            this.BT3.Margin = new System.Windows.Forms.Padding(1, 2, 3, 2);
            this.BT3.Name = "BT3";
            this.BT3.NumText = "";
            this.BT3.Pressed = false;
            this.BT3.Size = new System.Drawing.Size(56, 57);
            this.BT3.TabIndex = 2;
            this.BT3.TabStop = false;
            this.BT3.Text = "保存图片";
            this.BT3.UsedLed = false;
            this.BT3.UseVisualStyleBackColor = false;
            this.BT3.Click += new System.EventHandler(this.BT3_Click);
            // 
            // BT2
            // 
            this.BT2.AutoSize = true;
            this.BT2.BackColor = System.Drawing.SystemColors.Control;
            this.BT2.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.BT2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT2.FlatAppearance.BorderSize = 0;
            this.BT2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT2.LED = false;
            this.BT2.LedLocation = new System.Drawing.Point(4, 4);
            this.BT2.Location = new System.Drawing.Point(1, 62);
            this.BT2.Margin = new System.Windows.Forms.Padding(1, 2, 3, 2);
            this.BT2.Name = "BT2";
            this.BT2.NumText = "";
            this.BT2.Pressed = false;
            this.BT2.Size = new System.Drawing.Size(56, 56);
            this.BT2.TabIndex = 1;
            this.BT2.TabStop = false;
            this.BT2.Text = "倍率 切换 ";
            this.BT2.UsedLed = false;
            this.BT2.UseVisualStyleBackColor = false;
            this.BT2.Click += new System.EventHandler(this.BT2_Click);
            // 
            // BT1
            // 
            this.BT1.AutoSize = true;
            this.BT1.BackColor = System.Drawing.SystemColors.Control;
            this.BT1.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.BT1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT1.FlatAppearance.BorderSize = 0;
            this.BT1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT1.LED = false;
            this.BT1.LedLocation = new System.Drawing.Point(4, 4);
            this.BT1.Location = new System.Drawing.Point(1, 2);
            this.BT1.Margin = new System.Windows.Forms.Padding(1, 2, 3, 2);
            this.BT1.Name = "BT1";
            this.BT1.NumText = "";
            this.BT1.Pressed = false;
            this.BT1.Size = new System.Drawing.Size(56, 56);
            this.BT1.TabIndex = 0;
            this.BT1.TabStop = false;
            this.BT1.Text = "相机设置";
            this.BT1.UsedLed = false;
            this.BT1.UseVisualStyleBackColor = false;
            this.BT1.Click += new System.EventHandler(this.BT1_Click);
            // 
            // CaptureViewEx
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CaptureViewEx";
            this.Size = new System.Drawing.Size(584, 488);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCtr)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private AxisControlEx Axis;
        private VideoControlEx VC1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox imageCtr;
        private ButtonEx BT8;
        private ButtonEx BT7;
        private ButtonEx BT6;
        private ButtonEx BT5;
        private ButtonEx BT4;
        private ButtonEx BT3;
        private ButtonEx BT2;
        private ButtonEx BT1;
    }
}
