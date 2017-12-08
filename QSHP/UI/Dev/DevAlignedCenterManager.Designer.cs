namespace QSHP.UI
{
    partial class AlignedCenterManager
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
            this.label9 = new System.Windows.Forms.Label();
            this.p3Y = new QSHP.UI.Ctr.NumberEdit();
            this.p2Y = new QSHP.UI.Ctr.NumberEdit();
            this.p3X = new QSHP.UI.Ctr.NumberEdit();
            this.p2X = new QSHP.UI.Ctr.NumberEdit();
            this.p1Y = new QSHP.UI.Ctr.NumberEdit();
            this.p1X = new QSHP.UI.Ctr.NumberEdit();
            this.tAdj = new QSHP.UI.Ctr.NumberEdit();
            this.cPosY = new QSHP.UI.Ctr.NumberEdit();
            this.cPosX = new QSHP.UI.Ctr.NumberEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBoxEx1.HeaderBackColor = System.Drawing.Color.DarkTurquoise;
            this.groupBoxEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.groupBoxEx1.HeaderForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBoxEx1.HeaderText = "操作提示";
            this.groupBoxEx1.Location = new System.Drawing.Point(590, 299);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(220, 193);
            this.groupBoxEx1.TabIndex = 6;
            this.groupBoxEx1.Text = "groupBoxEx1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 150);
            this.label1.TabIndex = 2;
            this.label1.Text = "该界面支持“两点求中心”\r\n“三点求中心”操作:\r\n\r\n1、选择图像上明显标记物，\r\n点击“位置拾取”按键;\r\n2、手动旋转T轴，大于30度;\r\n3、移动X、Y轴" +
    "将该标记物移\r\n动到图像中心，重复步骤一\r\n步骤二 操作一次。\r\n4、点击“计算中心”按键。";
            // 
            // groupBoxEx2
            // 
            this.groupBoxEx2.BoardWidth = 1;
            this.groupBoxEx2.Controls.Add(this.ccdMode);
            this.groupBoxEx2.Controls.Add(this.label9);
            this.groupBoxEx2.Controls.Add(this.p3Y);
            this.groupBoxEx2.Controls.Add(this.p2Y);
            this.groupBoxEx2.Controls.Add(this.p3X);
            this.groupBoxEx2.Controls.Add(this.p2X);
            this.groupBoxEx2.Controls.Add(this.p1Y);
            this.groupBoxEx2.Controls.Add(this.p1X);
            this.groupBoxEx2.Controls.Add(this.tAdj);
            this.groupBoxEx2.Controls.Add(this.cPosY);
            this.groupBoxEx2.Controls.Add(this.cPosX);
            this.groupBoxEx2.Controls.Add(this.label5);
            this.groupBoxEx2.Controls.Add(this.label6);
            this.groupBoxEx2.Controls.Add(this.label7);
            this.groupBoxEx2.Controls.Add(this.label4);
            this.groupBoxEx2.Controls.Add(this.label3);
            this.groupBoxEx2.Controls.Add(this.label2);
            this.groupBoxEx2.HeaderAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupBoxEx2.HeaderBackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBoxEx2.HeaderFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.groupBoxEx2.HeaderForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBoxEx2.HeaderText = "旋转中心矫正";
            this.groupBoxEx2.Location = new System.Drawing.Point(590, 5);
            this.groupBoxEx2.Name = "groupBoxEx2";
            this.groupBoxEx2.Size = new System.Drawing.Size(219, 288);
            this.groupBoxEx2.TabIndex = 9;
            this.groupBoxEx2.Text = "像素测量";
            // 
            // ccdMode
            // 
            this.ccdMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ccdMode.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.ccdMode.Location = new System.Drawing.Point(105, 32);
            this.ccdMode.Name = "ccdMode";
            this.ccdMode.Size = new System.Drawing.Size(102, 30);
            this.ccdMode.TabIndex = 5;
            this.ccdMode.Text = "高倍";
            this.ccdMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(18, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 4;
            this.label9.Text = "当前倍率：";
            // 
            // p3Y
            // 
            this.p3Y.BackColor = System.Drawing.SystemColors.Window;
            this.p3Y.DecPlaces = 3;
            this.p3Y.Enabled = false;
            this.p3Y.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.p3Y.Location = new System.Drawing.Point(133, 251);
            this.p3Y.Name = "p3Y";
            this.p3Y.SetError = false;
            this.p3Y.SetWarn = false;
            this.p3Y.Size = new System.Drawing.Size(74, 30);
            this.p3Y.TabIndex = 2;
            this.p3Y.Text = "0";
            this.p3Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p3Y.Unit = "mm";
            this.p3Y.Value = 0F;
            // 
            // p2Y
            // 
            this.p2Y.BackColor = System.Drawing.SystemColors.Window;
            this.p2Y.DecPlaces = 3;
            this.p2Y.Enabled = false;
            this.p2Y.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.p2Y.Location = new System.Drawing.Point(133, 216);
            this.p2Y.Name = "p2Y";
            this.p2Y.SetError = false;
            this.p2Y.SetWarn = false;
            this.p2Y.Size = new System.Drawing.Size(74, 30);
            this.p2Y.TabIndex = 2;
            this.p2Y.Text = "0";
            this.p2Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p2Y.Unit = "mm";
            this.p2Y.Value = 0F;
            // 
            // p3X
            // 
            this.p3X.BackColor = System.Drawing.SystemColors.Window;
            this.p3X.DecPlaces = 3;
            this.p3X.Enabled = false;
            this.p3X.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.p3X.Location = new System.Drawing.Point(51, 251);
            this.p3X.Name = "p3X";
            this.p3X.SetError = false;
            this.p3X.SetWarn = false;
            this.p3X.Size = new System.Drawing.Size(74, 30);
            this.p3X.TabIndex = 2;
            this.p3X.Text = "0";
            this.p3X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p3X.Unit = "mm";
            this.p3X.Value = 0F;
            // 
            // p2X
            // 
            this.p2X.BackColor = System.Drawing.SystemColors.Window;
            this.p2X.DecPlaces = 3;
            this.p2X.Enabled = false;
            this.p2X.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.p2X.Location = new System.Drawing.Point(51, 216);
            this.p2X.Name = "p2X";
            this.p2X.SetError = false;
            this.p2X.SetWarn = false;
            this.p2X.Size = new System.Drawing.Size(74, 30);
            this.p2X.TabIndex = 2;
            this.p2X.Text = "0";
            this.p2X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p2X.Unit = "mm";
            this.p2X.Value = 0F;
            // 
            // p1Y
            // 
            this.p1Y.BackColor = System.Drawing.SystemColors.Window;
            this.p1Y.DecPlaces = 3;
            this.p1Y.Enabled = false;
            this.p1Y.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.p1Y.Location = new System.Drawing.Point(133, 180);
            this.p1Y.Name = "p1Y";
            this.p1Y.SetError = false;
            this.p1Y.SetWarn = false;
            this.p1Y.Size = new System.Drawing.Size(74, 30);
            this.p1Y.TabIndex = 2;
            this.p1Y.Text = "0";
            this.p1Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p1Y.Unit = "mm";
            this.p1Y.Value = 0F;
            // 
            // p1X
            // 
            this.p1X.BackColor = System.Drawing.SystemColors.Window;
            this.p1X.DecPlaces = 3;
            this.p1X.Enabled = false;
            this.p1X.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.p1X.Location = new System.Drawing.Point(51, 180);
            this.p1X.Name = "p1X";
            this.p1X.SetError = false;
            this.p1X.SetWarn = false;
            this.p1X.Size = new System.Drawing.Size(74, 30);
            this.p1X.TabIndex = 2;
            this.p1X.Text = "0";
            this.p1X.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p1X.Unit = "mm";
            this.p1X.Value = 0F;
            // 
            // tAdj
            // 
            this.tAdj.BackColor = System.Drawing.SystemColors.Window;
            this.tAdj.DecPlaces = 3;
            this.tAdj.Enabled = false;
            this.tAdj.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.tAdj.Location = new System.Drawing.Point(105, 144);
            this.tAdj.Name = "tAdj";
            this.tAdj.SetError = false;
            this.tAdj.SetWarn = false;
            this.tAdj.Size = new System.Drawing.Size(102, 30);
            this.tAdj.TabIndex = 2;
            this.tAdj.Text = "0";
            this.tAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tAdj.Unit = "mm";
            this.tAdj.Value = 0F;
            // 
            // cPosY
            // 
            this.cPosY.BackColor = System.Drawing.SystemColors.Window;
            this.cPosY.DecPlaces = 3;
            this.cPosY.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.cPosY.Location = new System.Drawing.Point(105, 105);
            this.cPosY.Name = "cPosY";
            this.cPosY.SetError = false;
            this.cPosY.SetWarn = false;
            this.cPosY.Size = new System.Drawing.Size(102, 30);
            this.cPosY.TabIndex = 2;
            this.cPosY.Text = "0";
            this.cPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cPosY.Unit = "mm";
            this.cPosY.Value = 0F;
            // 
            // cPosX
            // 
            this.cPosX.BackColor = System.Drawing.SystemColors.Window;
            this.cPosX.DecPlaces = 3;
            this.cPosX.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.cPosX.Location = new System.Drawing.Point(105, 68);
            this.cPosX.Name = "cPosX";
            this.cPosX.SetError = false;
            this.cPosX.SetWarn = false;
            this.cPosX.Size = new System.Drawing.Size(102, 30);
            this.cPosX.TabIndex = 2;
            this.cPosX.Text = "0";
            this.cPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cPosX.Unit = "mm";
            this.cPosX.Value = 0F;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(10, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "P3：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(10, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "P2：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(8, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "T轴偏移值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(10, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "P1：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "中心坐标Y：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "中心坐标X：";
            // 
            // AlignedCenterManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BT0Content = "位置拾取";
            this.BT1Content = "计算中心";
            this.BT5Content = "位置清除";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.groupBoxEx2);
            this.Controls.Add(this.groupBoxEx1);
            this.Name = "AlignedCenterManager";
            this.Text = "中心点矫正";
            this.BT0Click += new System.EventHandler(this.AlignedCenterManager_BT0Click);
            this.BT1Click += new System.EventHandler(this.AlignedCenterManager_BT1Click);
            this.BT5Click += new System.EventHandler(this.AlignedCenterManager_BT5Click);
            this.CancelClick += new System.EventHandler(this.AlignedCenterManager_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.AlignedCenterManager_ConfirmClick);
            this.Load += new System.EventHandler(this.AlignedCenterManager_Load);
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
        private Ctr.NumberEdit p3Y;
        private Ctr.NumberEdit p2Y;
        private Ctr.NumberEdit p3X;
        private Ctr.NumberEdit p2X;
        private Ctr.NumberEdit p1Y;
        private Ctr.NumberEdit p1X;
        private Ctr.NumberEdit tAdj;
        private Ctr.NumberEdit cPosY;
        private Ctr.NumberEdit cPosX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ccdMode;
        private System.Windows.Forms.Label label9;
    }
}