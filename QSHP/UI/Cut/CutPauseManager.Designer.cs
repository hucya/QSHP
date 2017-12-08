namespace QSHP.UI.Manual
{
    partial class CutPauseManager
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
            this.cutDeapthAdj = new QSHP.UI.Ctr.NumberEdit();
            this.cutDeapth = new System.Windows.Forms.Label();
            this.cutSpeedAdj = new QSHP.UI.Ctr.NumberEdit();
            this.cutSpeed = new System.Windows.Forms.Label();
            this.cutLineAdj = new QSHP.UI.Ctr.NumberEdit();
            this.cutLine = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cutStepAdj = new QSHP.UI.Ctr.NumberEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.cutLineWidth = new System.Windows.Forms.Label();
            this.cutStep = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Chip = new System.Windows.Forms.Label();
            this.curName = new System.Windows.Forms.Label();
            this.cutProcess = new QSHP.UI.Ctr.ProgressBarEx();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cutMode = new System.Windows.Forms.Label();
            this.ccdMode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.BoardWidth = 1;
            this.groupBoxEx1.Controls.Add(this.ccdMode);
            this.groupBoxEx1.Controls.Add(this.label7);
            this.groupBoxEx1.Controls.Add(this.cutDeapthAdj);
            this.groupBoxEx1.Controls.Add(this.cutDeapth);
            this.groupBoxEx1.Controls.Add(this.cutSpeedAdj);
            this.groupBoxEx1.Controls.Add(this.cutSpeed);
            this.groupBoxEx1.Controls.Add(this.cutLineAdj);
            this.groupBoxEx1.Controls.Add(this.cutLine);
            this.groupBoxEx1.Controls.Add(this.label8);
            this.groupBoxEx1.Controls.Add(this.cutStepAdj);
            this.groupBoxEx1.Controls.Add(this.label6);
            this.groupBoxEx1.Controls.Add(this.cutLineWidth);
            this.groupBoxEx1.Controls.Add(this.cutStep);
            this.groupBoxEx1.Controls.Add(this.label4);
            this.groupBoxEx1.Controls.Add(this.label12);
            this.groupBoxEx1.Controls.Add(this.label3);
            this.groupBoxEx1.Controls.Add(this.label14);
            this.groupBoxEx1.Controls.Add(this.Chip);
            this.groupBoxEx1.Controls.Add(this.curName);
            this.groupBoxEx1.Controls.Add(this.cutProcess);
            this.groupBoxEx1.Controls.Add(this.label10);
            this.groupBoxEx1.Controls.Add(this.label2);
            this.groupBoxEx1.Controls.Add(this.label1);
            this.groupBoxEx1.Controls.Add(this.cutMode);
            this.groupBoxEx1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxEx1.HeaderAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupBoxEx1.HeaderBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBoxEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.groupBoxEx1.HeaderForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBoxEx1.HeaderText = "划切状态";
            this.groupBoxEx1.Location = new System.Drawing.Point(591, 5);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(220, 488);
            this.groupBoxEx1.TabIndex = 4;
            this.groupBoxEx1.Text = "划切状态";
            // 
            // cutDeapthAdj
            // 
            this.cutDeapthAdj.BackColor = System.Drawing.SystemColors.Window;
            this.cutDeapthAdj.DecPlaces = 3;
            this.cutDeapthAdj.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutDeapthAdj.Location = new System.Drawing.Point(144, 296);
            this.cutDeapthAdj.Maximum = 100F;
            this.cutDeapthAdj.Minimum = -100F;
            this.cutDeapthAdj.Name = "cutDeapthAdj";
            this.cutDeapthAdj.SetError = false;
            this.cutDeapthAdj.SetWarn = false;
            this.cutDeapthAdj.Size = new System.Drawing.Size(67, 32);
            this.cutDeapthAdj.TabIndex = 11;
            this.cutDeapthAdj.Text = "0";
            this.cutDeapthAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cutDeapthAdj.Unit = "mm";
            this.cutDeapthAdj.Value = 0F;
            // 
            // cutDeapth
            // 
            this.cutDeapth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutDeapth.Font = new System.Drawing.Font("QSHP", 20F);
            this.cutDeapth.Location = new System.Drawing.Point(63, 297);
            this.cutDeapth.Name = "cutDeapth";
            this.cutDeapth.Size = new System.Drawing.Size(75, 30);
            this.cutDeapth.TabIndex = 10;
            this.cutDeapth.Text = "0";
            this.cutDeapth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cutSpeedAdj
            // 
            this.cutSpeedAdj.BackColor = System.Drawing.SystemColors.Window;
            this.cutSpeedAdj.DecPlaces = 3;
            this.cutSpeedAdj.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutSpeedAdj.Location = new System.Drawing.Point(144, 256);
            this.cutSpeedAdj.Maximum = 100F;
            this.cutSpeedAdj.Minimum = -100F;
            this.cutSpeedAdj.Name = "cutSpeedAdj";
            this.cutSpeedAdj.SetError = false;
            this.cutSpeedAdj.SetWarn = false;
            this.cutSpeedAdj.Size = new System.Drawing.Size(67, 32);
            this.cutSpeedAdj.TabIndex = 11;
            this.cutSpeedAdj.Text = "0";
            this.cutSpeedAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cutSpeedAdj.Unit = "mm";
            this.cutSpeedAdj.Value = 0F;
            // 
            // cutSpeed
            // 
            this.cutSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutSpeed.Font = new System.Drawing.Font("QSHP", 20F);
            this.cutSpeed.Location = new System.Drawing.Point(63, 257);
            this.cutSpeed.Name = "cutSpeed";
            this.cutSpeed.Size = new System.Drawing.Size(75, 30);
            this.cutSpeed.TabIndex = 10;
            this.cutSpeed.Text = "0";
            this.cutSpeed.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cutLineAdj
            // 
            this.cutLineAdj.BackColor = System.Drawing.SystemColors.Window;
            this.cutLineAdj.DecPlaces = 3;
            this.cutLineAdj.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutLineAdj.Location = new System.Drawing.Point(144, 216);
            this.cutLineAdj.Maximum = 100F;
            this.cutLineAdj.Minimum = -100F;
            this.cutLineAdj.Name = "cutLineAdj";
            this.cutLineAdj.SetError = false;
            this.cutLineAdj.SetWarn = false;
            this.cutLineAdj.Size = new System.Drawing.Size(67, 32);
            this.cutLineAdj.TabIndex = 11;
            this.cutLineAdj.Text = "0";
            this.cutLineAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cutLineAdj.Unit = "mm";
            this.cutLineAdj.Value = 0F;
            // 
            // cutLine
            // 
            this.cutLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutLine.Font = new System.Drawing.Font("QSHP", 20F);
            this.cutLine.Location = new System.Drawing.Point(63, 217);
            this.cutLine.Name = "cutLine";
            this.cutLine.Size = new System.Drawing.Size(75, 30);
            this.cutLine.TabIndex = 10;
            this.cutLine.Text = "0";
            this.cutLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 21);
            this.label8.TabIndex = 9;
            this.label8.Text = "高度: ";
            // 
            // cutStepAdj
            // 
            this.cutStepAdj.BackColor = System.Drawing.SystemColors.Window;
            this.cutStepAdj.DecPlaces = 3;
            this.cutStepAdj.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutStepAdj.Location = new System.Drawing.Point(144, 176);
            this.cutStepAdj.Maximum = 100F;
            this.cutStepAdj.Minimum = -100F;
            this.cutStepAdj.Name = "cutStepAdj";
            this.cutStepAdj.SetError = false;
            this.cutStepAdj.SetWarn = false;
            this.cutStepAdj.Size = new System.Drawing.Size(67, 32);
            this.cutStepAdj.TabIndex = 11;
            this.cutStepAdj.Text = "0";
            this.cutStepAdj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cutStepAdj.Unit = "mm";
            this.cutStepAdj.Value = 0F;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "速度: ";
            // 
            // cutLineWidth
            // 
            this.cutLineWidth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutLineWidth.Font = new System.Drawing.Font("QSHP", 20F);
            this.cutLineWidth.Location = new System.Drawing.Point(96, 376);
            this.cutLineWidth.Name = "cutLineWidth";
            this.cutLineWidth.Size = new System.Drawing.Size(115, 30);
            this.cutLineWidth.TabIndex = 10;
            this.cutLineWidth.Text = "0";
            this.cutLineWidth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cutStep
            // 
            this.cutStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutStep.Font = new System.Drawing.Font("QSHP", 20F);
            this.cutStep.Location = new System.Drawing.Point(63, 177);
            this.cutStep.Name = "cutStep";
            this.cutStep.Size = new System.Drawing.Size(75, 30);
            this.cutStep.TabIndex = 10;
            this.cutStep.Text = "0";
            this.cutStep.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "刀数: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 381);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 21);
            this.label12.TabIndex = 9;
            this.label12.Text = "刀痕宽度: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "进度: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 21);
            this.label14.TabIndex = 9;
            this.label14.Text = "分度: ";
            // 
            // Chip
            // 
            this.Chip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Chip.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.Chip.Location = new System.Drawing.Point(63, 67);
            this.Chip.Name = "Chip";
            this.Chip.Size = new System.Drawing.Size(148, 30);
            this.Chip.TabIndex = 8;
            this.Chip.Text = "Chip1";
            this.Chip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // curName
            // 
            this.curName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.curName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.curName.Location = new System.Drawing.Point(63, 104);
            this.curName.Name = "curName";
            this.curName.Size = new System.Drawing.Size(148, 30);
            this.curName.TabIndex = 8;
            this.curName.Text = "CH1";
            this.curName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cutProcess
            // 
            this.cutProcess.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.cutProcess.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutProcess.FontColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cutProcess.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.cutProcess.Location = new System.Drawing.Point(63, 140);
            this.cutProcess.Name = "cutProcess";
            this.cutProcess.Size = new System.Drawing.Size(148, 30);
            this.cutProcess.StringFormat = "{0}%";
            this.cutProcess.TabIndex = 7;
            this.cutProcess.Text = "0%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "工件:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "模式:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "通道:";
            // 
            // cutMode
            // 
            this.cutMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutMode.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.cutMode.Location = new System.Drawing.Point(63, 29);
            this.cutMode.Name = "cutMode";
            this.cutMode.Size = new System.Drawing.Size(148, 30);
            this.cutMode.TabIndex = 4;
            this.cutMode.Text = "标准双通道";
            this.cutMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ccdMode
            // 
            this.ccdMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ccdMode.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.ccdMode.Location = new System.Drawing.Point(96, 336);
            this.ccdMode.Name = "ccdMode";
            this.ccdMode.Size = new System.Drawing.Size(115, 30);
            this.ccdMode.TabIndex = 13;
            this.ccdMode.Text = "高倍";
            this.ccdMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(4, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "当前倍率：";
            // 
            // CutPauseManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BT0Content = "刀数调整";
            this.BT1Content = "速度调整";
            this.BT2Content = "高度调整";
            this.BT3Content = "对准线校正";
            this.BT4Content = "T 轴调整";
            this.BT5Content = "预划切";
            this.BT6Content = "分度调整";
            this.BT7Content = "崩边检测";
            this.BT8Content = "位置调整";
            this.CancelText = "取  消";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.ConfirmText = "停  止";
            this.Controls.Add(this.groupBoxEx1);
            this.CycTime = 5;
            this.FmStyle = QSHP.FormStyle.NextOK;
            this.Name = "CutPauseManager";
            this.NextText = "继  续";
            this.Text = "暂  停";
            this.ChangeCutChannelHander += new System.EventHandler<QSHP.Data.CutChannel>(this.CutPauseManager_ChangeCutChannelHander);
            this.BT0Click += new System.EventHandler(this.ChangeCutLinesEventHander);
            this.BT1Click += new System.EventHandler(this.ChangeCutSpeedEventHander);
            this.BT2Click += new System.EventHandler(this.ChangeCutDeapthEventHnader);
            this.BT3Click += new System.EventHandler(this.ChangeAlignLineEventHander);
            this.BT5Click += new System.EventHandler(this.ChangePreCutSpeedEventHander);
            this.BT6Click += new System.EventHandler(this.ChangeCutIndexStepEventHander);
            this.BT8Click += new System.EventHandler(this.ChangeCutPosEventHander);
            this.CancelClick += new System.EventHandler(this.CutPauseManager_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.PauseManager_ConfirmClick);
            this.NextClick += new System.EventHandler(this.PauseManager_NextClick);
            this.AutoUpdateEventHander += new System.EventHandler(this.CutPauseManager_AutoUpdateEventHander);
            this.Load += new System.EventHandler(this.PauseManager_Load);
            this.Controls.SetChildIndex(this.groupBoxEx1, 0);
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctr.GroupBoxEx groupBoxEx1;
        private System.Windows.Forms.Label label1;
        private Ctr.ProgressBarEx cutProcess;
        private System.Windows.Forms.Label curName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label cutMode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label cutStep;
        private Ctr.NumberEdit cutStepAdj;
        private System.Windows.Forms.Label label3;
        private Ctr.NumberEdit cutDeapthAdj;
        private System.Windows.Forms.Label cutDeapth;
        private Ctr.NumberEdit cutSpeedAdj;
        private System.Windows.Forms.Label cutSpeed;
        private Ctr.NumberEdit cutLineAdj;
        private System.Windows.Forms.Label cutLine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Chip;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label cutLineWidth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label ccdMode;
        private System.Windows.Forms.Label label7;
    }
}