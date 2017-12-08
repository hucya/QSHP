namespace QSHP.UI
{
    partial class AlignFormBase
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
            this.cap = new QSHP.UI.CaptureViewEx();
            this.SuspendLayout();
            // 
            // cap
            // 
            this.cap.ApplyBinning = true;
            this.cap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cap.CaptureProvider = null;
            this.cap.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cap.Location = new System.Drawing.Point(4, 5);
            this.cap.MouseFollow = true;
            this.cap.Name = "cap";
            this.cap.ShowMode = QSHP.UI.VideoMode.Logo;
            this.cap.Size = new System.Drawing.Size(584, 488);
            this.cap.TabIndex = 2;
            this.cap.XGuidesWidth = 30;
            this.cap.XStep = 2F;
            this.cap.YGuidesWidth = 258;
            this.cap.YStep = 2F;
            // 
            // AlignFormBase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.cap);
            this.Name = "AlignFormBase";
            this.Text = "AlignFormBase";
            this.Load += new System.EventHandler(this.AlignFormBase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CaptureViewEx cap;
    }
}