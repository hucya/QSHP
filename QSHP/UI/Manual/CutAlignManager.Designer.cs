namespace QSHP.UI.Manual
{
    partial class CutAlignManager
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
            this.curChannel = new QSHP.UI.Ctr.ComboBoxEx();
            this.curLines = new System.Windows.Forms.Label();
            this.curStep = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.BoardWidth = 1;
            this.groupBoxEx1.Controls.Add(this.curChannel);
            this.groupBoxEx1.Controls.Add(this.curLines);
            this.groupBoxEx1.Controls.Add(this.curStep);
            this.groupBoxEx1.Controls.Add(this.label3);
            this.groupBoxEx1.Controls.Add(this.label2);
            this.groupBoxEx1.Controls.Add(this.label1);
            this.groupBoxEx1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxEx1.HeaderAligment = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupBoxEx1.HeaderBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBoxEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.groupBoxEx1.HeaderForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBoxEx1.HeaderText = "手动对准";
            this.groupBoxEx1.Location = new System.Drawing.Point(590, 5);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(220, 488);
            this.groupBoxEx1.TabIndex = 3;
            this.groupBoxEx1.Text = "手动对准";
            // 
            // curChannel
            // 
            this.curChannel.BackColor = System.Drawing.SystemColors.Control;
            this.curChannel.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.curChannel.FormattingEnabled = true;
            this.curChannel.Location = new System.Drawing.Point(105, 36);
            this.curChannel.Name = "curChannel";
            this.curChannel.Size = new System.Drawing.Size(100, 33);
            this.curChannel.TabIndex = 4;
            this.curChannel.SelectedIndexChanged += new System.EventHandler(this.CurChannel_SelectedIndexChanged);
            // 
            // curLines
            // 
            this.curLines.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.curLines.Font = new System.Drawing.Font("QSHP", 20F);
            this.curLines.Location = new System.Drawing.Point(105, 80);
            this.curLines.Name = "curLines";
            this.curLines.Size = new System.Drawing.Size(100, 30);
            this.curLines.TabIndex = 2;
            this.curLines.Text = "1";
            this.curLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // curStep
            // 
            this.curStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.curStep.Font = new System.Drawing.Font("QSHP", 20F);
            this.curStep.Location = new System.Drawing.Point(105, 123);
            this.curStep.Name = "curStep";
            this.curStep.Size = new System.Drawing.Size(100, 30);
            this.curStep.TabIndex = 2;
            this.curStep.Text = "1";
            this.curStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "划切刀数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "分度(mm):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "当前通道:";
            // 
            // CutAlignManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BT5Content = "预划切";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.groupBoxEx1);
            this.FmStyle = QSHP.FormStyle.NextOKCancel;
            this.Name = "CutAlignManager";
            this.Text = "手动对准";
            this.ChangeCutChannelHander += new System.EventHandler<QSHP.Data.CutChannel>(this.CutAlignManager_ChangeCutChannelHander);
            this.BT5Click += new System.EventHandler(this.ChangeCutPreCutEventHander);
            this.CancelClick += new System.EventHandler(this.CutAlignManager_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.CutAlignManager_ConfirmClick);
            this.NextClick += new System.EventHandler(this.CutAlignManager_NextClick);
            this.AutoUpdateEventHander += new System.EventHandler(this.CutAlignManager_AutoUpdateEventHander);
            this.Load += new System.EventHandler(this.CutAlignManager_Load);
            this.Controls.SetChildIndex(this.groupBoxEx1, 0);
            this.groupBoxEx1.ResumeLayout(false);
            this.groupBoxEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctr.GroupBoxEx groupBoxEx1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label curStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label curLines;
        private Ctr.ComboBoxEx curChannel;
    }
}