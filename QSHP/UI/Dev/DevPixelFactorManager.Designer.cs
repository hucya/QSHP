namespace QSHP.UI
{
    partial class PixelFactorManager
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
            this.groupBoxEx1 = new QSHP.UI.Ctr.GroupBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxEx2 = new QSHP.UI.Ctr.GroupBoxEx();
            this.ccdMode = new System.Windows.Forms.Label();
            this.y2Pos = new QSHP.UI.Ctr.NumberEdit();
            this.y1Pos = new QSHP.UI.Ctr.NumberEdit();
            this.yLenth = new QSHP.UI.Ctr.NumberEdit();
            this.yPix = new QSHP.UI.Ctr.NumberEdit();
            this.pixScale = new QSHP.UI.Ctr.NumberEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxEx1.SuspendLayout();
            this.groupBoxEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.BoardWidth = 1;
            this.groupBoxEx1.Controls.Add(this.label1);
            this.groupBoxEx1.HeaderAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupBoxEx1.HeaderBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBoxEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.groupBoxEx1.HeaderForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBoxEx1.HeaderText = "操作提示";
            this.groupBoxEx1.Location = new System.Drawing.Point(589, 265);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(219, 228);
            this.groupBoxEx1.TabIndex = 5;
            this.groupBoxEx1.Text = "groupBoxEx1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 200);
            this.label1.TabIndex = 1;
            this.label1.Text = "该界面不支持倍率切换、基\r\n准线调宽、基准线调窄操作；\r\n\r\n1、选择图像上明显标记点\r\n并移动到底部基线位置；\r\n\r\n2、点击“设置起点”;\r\n\r\n3、将该标记" +
    "点移动到顶部\r\n基准线位置;点击“设置终点”";
            // 
            // groupBoxEx2
            // 
            this.groupBoxEx2.BoardWidth = 1;
            this.groupBoxEx2.Controls.Add(this.ccdMode);
            this.groupBoxEx2.Controls.Add(this.y2Pos);
            this.groupBoxEx2.Controls.Add(this.y1Pos);
            this.groupBoxEx2.Controls.Add(this.yLenth);
            this.groupBoxEx2.Controls.Add(this.yPix);
            this.groupBoxEx2.Controls.Add(this.pixScale);
            this.groupBoxEx2.Controls.Add(this.label6);
            this.groupBoxEx2.Controls.Add(this.label5);
            this.groupBoxEx2.Controls.Add(this.label4);
            this.groupBoxEx2.Controls.Add(this.label3);
            this.groupBoxEx2.Controls.Add(this.label7);
            this.groupBoxEx2.Controls.Add(this.label2);
            this.groupBoxEx2.HeaderAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupBoxEx2.HeaderBackColor = System.Drawing.Color.BlueViolet;
            this.groupBoxEx2.HeaderFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.groupBoxEx2.HeaderForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBoxEx2.HeaderText = "像素测量";
            this.groupBoxEx2.Location = new System.Drawing.Point(589, 5);
            this.groupBoxEx2.Name = "groupBoxEx2";
            this.groupBoxEx2.Size = new System.Drawing.Size(219, 254);
            this.groupBoxEx2.TabIndex = 8;
            this.groupBoxEx2.Text = "像素测量";
            // 
            // ccdMode
            // 
            this.ccdMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ccdMode.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.ccdMode.Location = new System.Drawing.Point(101, 32);
            this.ccdMode.Name = "ccdMode";
            this.ccdMode.Size = new System.Drawing.Size(100, 30);
            this.ccdMode.TabIndex = 3;
            this.ccdMode.Text = "高倍";
            this.ccdMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // y2Pos
            // 
            this.y2Pos.BackColor = System.Drawing.SystemColors.Window;
            this.y2Pos.DecPlaces = 3;
            this.y2Pos.Enabled = false;
            this.y2Pos.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.y2Pos.Location = new System.Drawing.Point(101, 217);
            this.y2Pos.Name = "y2Pos";
            this.y2Pos.ReadOnly = true;
            this.y2Pos.SetError = false;
            this.y2Pos.SetWarn = false;
            this.y2Pos.Size = new System.Drawing.Size(102, 30);
            this.y2Pos.TabIndex = 2;
            this.y2Pos.Text = "0";
            this.y2Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.y2Pos.Unit = "mm";
            this.y2Pos.Value = 0F;
            // 
            // y1Pos
            // 
            this.y1Pos.BackColor = System.Drawing.SystemColors.Window;
            this.y1Pos.DecPlaces = 3;
            this.y1Pos.Enabled = false;
            this.y1Pos.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.y1Pos.Location = new System.Drawing.Point(101, 182);
            this.y1Pos.Name = "y1Pos";
            this.y1Pos.ReadOnly = true;
            this.y1Pos.SetError = false;
            this.y1Pos.SetWarn = false;
            this.y1Pos.Size = new System.Drawing.Size(102, 30);
            this.y1Pos.TabIndex = 2;
            this.y1Pos.Text = "0";
            this.y1Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.y1Pos.Unit = "mm";
            this.y1Pos.Value = 0F;
            // 
            // yLenth
            // 
            this.yLenth.BackColor = System.Drawing.SystemColors.Window;
            this.yLenth.DecPlaces = 3;
            this.yLenth.Enabled = false;
            this.yLenth.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.yLenth.Location = new System.Drawing.Point(101, 144);
            this.yLenth.Name = "yLenth";
            this.yLenth.ReadOnly = true;
            this.yLenth.SetError = false;
            this.yLenth.SetWarn = false;
            this.yLenth.Size = new System.Drawing.Size(102, 30);
            this.yLenth.TabIndex = 2;
            this.yLenth.Text = "0";
            this.yLenth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yLenth.Unit = "mm";
            this.yLenth.Value = 0F;
            // 
            // yPix
            // 
            this.yPix.BackColor = System.Drawing.SystemColors.Window;
            this.yPix.DecPlaces = 3;
            this.yPix.Enabled = false;
            this.yPix.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.yPix.Location = new System.Drawing.Point(101, 106);
            this.yPix.Name = "yPix";
            this.yPix.ReadOnly = true;
            this.yPix.SetError = false;
            this.yPix.SetWarn = false;
            this.yPix.Size = new System.Drawing.Size(102, 30);
            this.yPix.TabIndex = 2;
            this.yPix.Text = "0";
            this.yPix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yPix.Unit = "mm";
            this.yPix.Value = 0F;
            // 
            // pixScale
            // 
            this.pixScale.BackColor = System.Drawing.SystemColors.Window;
            this.pixScale.DecPlaces = 6;
            this.pixScale.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.pixScale.Location = new System.Drawing.Point(101, 69);
            this.pixScale.Name = "pixScale";
            this.pixScale.SetError = false;
            this.pixScale.SetWarn = false;
            this.pixScale.Size = new System.Drawing.Size(102, 30);
            this.pixScale.TabIndex = 2;
            this.pixScale.Text = "0";
            this.pixScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pixScale.Unit = "mm";
            this.pixScale.Value = 0F;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(8, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Y2坐标值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Y1坐标值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(22, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "ΔY距离：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(22, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "ΔY像素：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(11, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "当前倍率：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "像素系数：";
            // 
            // PixelFactorManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BT0Content = "设置起点";
            this.BT5Content = "设置终点";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.groupBoxEx2);
            this.Controls.Add(this.groupBoxEx1);
            this.Name = "PixelFactorManager";
            this.Text = "像素测量";
            this.BT0Click += new System.EventHandler(this.PixelFactorManager_BT0Click);
            this.BT5Click += new System.EventHandler(this.PixelFactorManager_BT5Click);
            this.CancelClick += new System.EventHandler(this.PixelFactorManager_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.PixelFactorManager_ConfirmClick);
            this.Load += new System.EventHandler(this.PixelFactorManager_Load);
            this.Controls.SetChildIndex(this.groupBoxEx1, 0);
            this.Controls.SetChildIndex(this.groupBoxEx2, 0);
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            this.groupBoxEx2.ResumeLayout(false);
            this.groupBoxEx2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctr.GroupBoxEx groupBoxEx1;
        private System.Windows.Forms.Label label1;
        private Ctr.GroupBoxEx groupBoxEx2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Ctr.NumberEdit y2Pos;
        private Ctr.NumberEdit y1Pos;
        private Ctr.NumberEdit yLenth;
        private Ctr.NumberEdit yPix;
        private Ctr.NumberEdit pixScale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ccdMode;
    }
}