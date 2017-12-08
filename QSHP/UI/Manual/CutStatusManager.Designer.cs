namespace QSHP.UI.Manual
{
    partial class CutStatusManager
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
            this.imgCtr = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.preTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.realTime = new System.Windows.Forms.Label();
            this.groupBoxEx1 = new QSHP.UI.Ctr.GroupBoxEx();
            this.cutStepAdj = new QSHP.UI.Ctr.NumberEdit();
            this.cutDeapthAdj = new QSHP.UI.Ctr.NumberEdit();
            this.cutSpeedAdj = new QSHP.UI.Ctr.NumberEdit();
            this.cutLineAdj = new QSHP.UI.Ctr.NumberEdit();
            this.cutProcess = new QSHP.UI.Ctr.ProgressBarEx();
            this.chipName = new System.Windows.Forms.Label();
            this.segName = new System.Windows.Forms.Label();
            this.curName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cutStep = new System.Windows.Forms.Label();
            this.cutDeapth = new System.Windows.Forms.Label();
            this.cutSpeed = new System.Windows.Forms.Label();
            this.cutMode = new System.Windows.Forms.Label();
            this.cutLeaveLines = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgCtr)).BeginInit();
            this.groupBoxEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgCtr
            // 
            this.imgCtr.BackColor = System.Drawing.Color.Cornsilk;
            this.imgCtr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCtr.Location = new System.Drawing.Point(5, 3);
            this.imgCtr.Margin = new System.Windows.Forms.Padding(5);
            this.imgCtr.Name = "imgCtr";
            this.imgCtr.Size = new System.Drawing.Size(491, 491);
            this.imgCtr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgCtr.TabIndex = 1;
            this.imgCtr.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "预计用时: ";
            // 
            // preTime
            // 
            this.preTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.preTime.Font = new System.Drawing.Font("QSHP", 20F);
            this.preTime.Location = new System.Drawing.Point(185, 408);
            this.preTime.Name = "preTime";
            this.preTime.Size = new System.Drawing.Size(112, 30);
            this.preTime.TabIndex = 4;
            this.preTime.Text = "00:00:00";
            this.preTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "实际用时: ";
            // 
            // realTime
            // 
            this.realTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.realTime.Font = new System.Drawing.Font("QSHP", 20F);
            this.realTime.Location = new System.Drawing.Point(185, 451);
            this.realTime.Name = "realTime";
            this.realTime.Size = new System.Drawing.Size(112, 30);
            this.realTime.TabIndex = 4;
            this.realTime.Text = "00:00:00";
            this.realTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.BoardWidth = 1;
            this.groupBoxEx1.Controls.Add(this.cutStepAdj);
            this.groupBoxEx1.Controls.Add(this.cutDeapthAdj);
            this.groupBoxEx1.Controls.Add(this.cutSpeedAdj);
            this.groupBoxEx1.Controls.Add(this.cutLineAdj);
            this.groupBoxEx1.Controls.Add(this.cutProcess);
            this.groupBoxEx1.Controls.Add(this.chipName);
            this.groupBoxEx1.Controls.Add(this.segName);
            this.groupBoxEx1.Controls.Add(this.curName);
            this.groupBoxEx1.Controls.Add(this.label13);
            this.groupBoxEx1.Controls.Add(this.label12);
            this.groupBoxEx1.Controls.Add(this.label11);
            this.groupBoxEx1.Controls.Add(this.label5);
            this.groupBoxEx1.Controls.Add(this.label6);
            this.groupBoxEx1.Controls.Add(this.label7);
            this.groupBoxEx1.Controls.Add(this.cutStep);
            this.groupBoxEx1.Controls.Add(this.cutDeapth);
            this.groupBoxEx1.Controls.Add(this.cutSpeed);
            this.groupBoxEx1.Controls.Add(this.preTime);
            this.groupBoxEx1.Controls.Add(this.realTime);
            this.groupBoxEx1.Controls.Add(this.label1);
            this.groupBoxEx1.Controls.Add(this.cutMode);
            this.groupBoxEx1.Controls.Add(this.cutLeaveLines);
            this.groupBoxEx1.Controls.Add(this.label14);
            this.groupBoxEx1.Controls.Add(this.label16);
            this.groupBoxEx1.Controls.Add(this.label4);
            this.groupBoxEx1.Controls.Add(this.label2);
            this.groupBoxEx1.Controls.Add(this.label10);
            this.groupBoxEx1.Controls.Add(this.label3);
            this.groupBoxEx1.Controls.Add(this.label8);
            this.groupBoxEx1.HeaderAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupBoxEx1.HeaderBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBoxEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.groupBoxEx1.HeaderForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBoxEx1.HeaderText = "划切状态";
            this.groupBoxEx1.Location = new System.Drawing.Point(501, 3);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(308, 491);
            this.groupBoxEx1.TabIndex = 5;
            this.groupBoxEx1.Text = "groupBoxEx1";
            // 
            // cutStepAdj
            // 
            this.cutStepAdj.BackColor = System.Drawing.SystemColors.Window;
            this.cutStepAdj.DecPlaces = 3;
            this.cutStepAdj.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutStepAdj.Location = new System.Drawing.Point(210, 151);
            this.cutStepAdj.Maximum = 100F;
            this.cutStepAdj.Minimum = -100F;
            this.cutStepAdj.Name = "cutStepAdj";
            this.cutStepAdj.SetError = false;
            this.cutStepAdj.SetWarn = false;
            this.cutStepAdj.Size = new System.Drawing.Size(87, 32);
            this.cutStepAdj.TabIndex = 8;
            this.cutStepAdj.Text = "0";
            this.cutStepAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cutStepAdj.Unit = "mm";
            this.cutStepAdj.Value = 0F;
            // 
            // cutDeapthAdj
            // 
            this.cutDeapthAdj.BackColor = System.Drawing.SystemColors.Window;
            this.cutDeapthAdj.DecPlaces = 3;
            this.cutDeapthAdj.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutDeapthAdj.Location = new System.Drawing.Point(210, 276);
            this.cutDeapthAdj.Maximum = 100F;
            this.cutDeapthAdj.Minimum = -100F;
            this.cutDeapthAdj.Name = "cutDeapthAdj";
            this.cutDeapthAdj.SetError = false;
            this.cutDeapthAdj.SetWarn = false;
            this.cutDeapthAdj.Size = new System.Drawing.Size(87, 32);
            this.cutDeapthAdj.TabIndex = 8;
            this.cutDeapthAdj.Text = "0";
            this.cutDeapthAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cutDeapthAdj.Unit = "mm";
            this.cutDeapthAdj.Value = 0F;
            // 
            // cutSpeedAdj
            // 
            this.cutSpeedAdj.BackColor = System.Drawing.SystemColors.Window;
            this.cutSpeedAdj.DecPlaces = 0;
            this.cutSpeedAdj.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutSpeedAdj.Location = new System.Drawing.Point(210, 235);
            this.cutSpeedAdj.Maximum = 1000F;
            this.cutSpeedAdj.Minimum = -1000F;
            this.cutSpeedAdj.Name = "cutSpeedAdj";
            this.cutSpeedAdj.SetError = false;
            this.cutSpeedAdj.SetWarn = false;
            this.cutSpeedAdj.Size = new System.Drawing.Size(87, 32);
            this.cutSpeedAdj.TabIndex = 8;
            this.cutSpeedAdj.Text = "0";
            this.cutSpeedAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cutSpeedAdj.Unit = "mm";
            this.cutSpeedAdj.Value = 0F;
            // 
            // cutLineAdj
            // 
            this.cutLineAdj.BackColor = System.Drawing.SystemColors.Window;
            this.cutLineAdj.DecPlaces = 0;
            this.cutLineAdj.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutLineAdj.Location = new System.Drawing.Point(210, 194);
            this.cutLineAdj.Maximum = 1000F;
            this.cutLineAdj.Minimum = -1000F;
            this.cutLineAdj.Name = "cutLineAdj";
            this.cutLineAdj.SetError = false;
            this.cutLineAdj.SetWarn = false;
            this.cutLineAdj.Size = new System.Drawing.Size(87, 32);
            this.cutLineAdj.TabIndex = 8;
            this.cutLineAdj.Text = "0";
            this.cutLineAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cutLineAdj.Unit = "mm";
            this.cutLineAdj.Value = 0F;
            // 
            // cutProcess
            // 
            this.cutProcess.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.cutProcess.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutProcess.FontColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cutProcess.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cutProcess.Location = new System.Drawing.Point(62, 70);
            this.cutProcess.Name = "cutProcess";
            this.cutProcess.Size = new System.Drawing.Size(235, 30);
            this.cutProcess.StringFormat = "{0}%";
            this.cutProcess.TabIndex = 7;
            this.cutProcess.Text = "0%";
            // 
            // chipName
            // 
            this.chipName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chipName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chipName.Location = new System.Drawing.Point(62, 32);
            this.chipName.Name = "chipName";
            this.chipName.Size = new System.Drawing.Size(90, 30);
            this.chipName.TabIndex = 5;
            this.chipName.Text = "Chip1";
            this.chipName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // segName
            // 
            this.segName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.segName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.segName.Location = new System.Drawing.Point(210, 109);
            this.segName.Name = "segName";
            this.segName.Size = new System.Drawing.Size(87, 30);
            this.segName.TabIndex = 5;
            this.segName.Text = "SG1";
            this.segName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // curName
            // 
            this.curName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.curName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.curName.Location = new System.Drawing.Point(62, 110);
            this.curName.Name = "curName";
            this.curName.Size = new System.Drawing.Size(90, 30);
            this.curName.TabIndex = 5;
            this.curName.Text = "CH1";
            this.curName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(158, 157);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 21);
            this.label13.TabIndex = 6;
            this.label13.Text = "调整:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(158, 282);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 21);
            this.label12.TabIndex = 6;
            this.label12.Text = "调整:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(158, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 21);
            this.label11.TabIndex = 6;
            this.label11.Text = "调整:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "调整:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "通段:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "通道:";
            // 
            // cutStep
            // 
            this.cutStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutStep.Font = new System.Drawing.Font("QSHP", 20F);
            this.cutStep.Location = new System.Drawing.Point(62, 152);
            this.cutStep.Name = "cutStep";
            this.cutStep.Size = new System.Drawing.Size(90, 30);
            this.cutStep.TabIndex = 4;
            this.cutStep.Text = "0";
            this.cutStep.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cutDeapth
            // 
            this.cutDeapth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutDeapth.Font = new System.Drawing.Font("QSHP", 20F);
            this.cutDeapth.Location = new System.Drawing.Point(62, 277);
            this.cutDeapth.Name = "cutDeapth";
            this.cutDeapth.Size = new System.Drawing.Size(90, 30);
            this.cutDeapth.TabIndex = 4;
            this.cutDeapth.Text = "0";
            this.cutDeapth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cutSpeed
            // 
            this.cutSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutSpeed.Font = new System.Drawing.Font("QSHP", 20F);
            this.cutSpeed.Location = new System.Drawing.Point(62, 236);
            this.cutSpeed.Name = "cutSpeed";
            this.cutSpeed.Size = new System.Drawing.Size(90, 30);
            this.cutSpeed.TabIndex = 4;
            this.cutSpeed.Text = "0";
            this.cutSpeed.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cutMode
            // 
            this.cutMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutMode.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutMode.Location = new System.Drawing.Point(158, 32);
            this.cutMode.Name = "cutMode";
            this.cutMode.Size = new System.Drawing.Size(139, 30);
            this.cutMode.TabIndex = 4;
            this.cutMode.Text = "标准双通道";
            this.cutMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cutLeaveLines
            // 
            this.cutLeaveLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutLeaveLines.Font = new System.Drawing.Font("QSHP", 20F);
            this.cutLeaveLines.Location = new System.Drawing.Point(62, 195);
            this.cutLeaveLines.Name = "cutLeaveLines";
            this.cutLeaveLines.Size = new System.Drawing.Size(90, 30);
            this.cutLeaveLines.TabIndex = 4;
            this.cutLeaveLines.Text = "0";
            this.cutLeaveLines.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 21);
            this.label14.TabIndex = 3;
            this.label14.Text = "分度: ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 21);
            this.label16.TabIndex = 3;
            this.label16.Text = "进度: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "模式: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "刀数: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 21);
            this.label10.TabIndex = 3;
            this.label10.Text = "高度: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "速度: ";
            // 
            // CutStatusManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BT0Content = "刀数调整";
            this.BT1Content = "速度调整";
            this.BT2Content = "高度调整";
            this.BT5Content = "预划切";
            this.BT6Content = "分度调整";
            this.CancelText = "暂  停";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.ConfirmText = "";
            this.Controls.Add(this.groupBoxEx1);
            this.Controls.Add(this.imgCtr);
            this.FmStyle = QSHP.FormStyle.PathModeCancel;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "CutStatusManager";
            this.NextText = "";
            this.Text = "自动划切";
            this.BT0Click += new System.EventHandler(this.ChangeCutLinesEventHander);
            this.BT1Click += new System.EventHandler(this.ChangeCutSpeedEventHander);
            this.BT2Click += new System.EventHandler(this.ChangeCutDeapthEventHnader);
            this.BT5Click += new System.EventHandler(this.ChangePreCutSpeedEventHander);
            this.BT6Click += new System.EventHandler(this.ChangeCutIndexStepEventHander);
            this.CancelClick += new System.EventHandler(this.CutStatusManager_CancelClick);
            this.AutoUpdateEventHander += new System.EventHandler(this.CutStatusManager_AutoUpdateEventHander);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CutStatusManager_FormClosing);
            this.Load += new System.EventHandler(this.CuttingManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCtr)).EndInit();
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCtr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label preTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label realTime;
        private Ctr.GroupBoxEx groupBoxEx1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cutLeaveLines;
        private System.Windows.Forms.Label curName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label cutStep;
        private System.Windows.Forms.Label cutDeapth;
        private System.Windows.Forms.Label cutSpeed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private Ctr.ProgressBarEx cutProcess;
        private System.Windows.Forms.Label cutMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label chipName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private Ctr.NumberEdit cutStepAdj;
        private Ctr.NumberEdit cutDeapthAdj;
        private Ctr.NumberEdit cutSpeedAdj;
        private Ctr.NumberEdit cutLineAdj;
        private System.Windows.Forms.Label segName;
    }
}