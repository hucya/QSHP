namespace QSHP.UI
{
    partial class TopBar
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
            this.timeShow = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.sensorBt = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.alarmBt = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.buttonEx2 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.indexLable = new System.Windows.Forms.Label();
            this.logShow = new System.Windows.Forms.Label();
            this.logNum = new System.Windows.Forms.Label();
            this.buttonEx1 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.netStatus = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.spdStatus = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.spdRrogressBar = new QSHP.UI.Ctr.ProgressBarEx();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeShow
            // 
            this.timeShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeShow.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.timeShow.Location = new System.Drawing.Point(664, 2);
            this.timeShow.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.timeShow.Name = "timeShow";
            this.timeShow.Padding = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.timeShow.Size = new System.Drawing.Size(151, 33);
            this.timeShow.TabIndex = 5;
            this.timeShow.Text = "2017/7/6 20:03:56";
            this.timeShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 8;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel4.Controls.Add(this.sensorBt, 7, 0);
            this.tableLayoutPanel4.Controls.Add(this.alarmBt, 6, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonEx2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.timeShow, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.label9, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.indexLable, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.logShow, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.logNum, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonEx1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.netStatus, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.spdStatus, 5, 1);
            this.tableLayoutPanel4.Controls.Add(this.spdRrogressBar, 4, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1005, 74);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // sensorBt
            // 
            this.sensorBt.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.sensorBt.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.sensorBt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sensorBt.Flag = 0;
            this.sensorBt.FlatAppearance.BorderSize = 0;
            this.sensorBt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sensorBt.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sensorBt.ForeColor = System.Drawing.Color.White;
            this.sensorBt.LED = false;
            this.sensorBt.LedLocation = new System.Drawing.Point(4, -8);
            this.sensorBt.Location = new System.Drawing.Point(930, 2);
            this.sensorBt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sensorBt.Name = "sensorBt";
            this.sensorBt.NumText = null;
            this.sensorBt.Pressed = false;
            this.tableLayoutPanel4.SetRowSpan(this.sensorBt, 2);
            this.sensorBt.Size = new System.Drawing.Size(72, 70);
            this.sensorBt.TabIndex = 13;
            this.sensorBt.TabStop = false;
            this.sensorBt.Text = "日志查看";
            this.sensorBt.UsedLed = false;
            this.sensorBt.UseVisualStyleBackColor = false;
            this.sensorBt.Click += new System.EventHandler(this.SensorBt_Click);
            // 
            // alarmBt
            // 
            this.alarmBt.BackColor = System.Drawing.Color.Orange;
            this.alarmBt.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.alarmBt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alarmBt.Flag = 0;
            this.alarmBt.FlatAppearance.BorderSize = 0;
            this.alarmBt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.alarmBt.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.alarmBt.ForeColor = System.Drawing.Color.White;
            this.alarmBt.LED = false;
            this.alarmBt.LedLocation = new System.Drawing.Point(4, -8);
            this.alarmBt.Location = new System.Drawing.Point(852, 2);
            this.alarmBt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.alarmBt.Name = "alarmBt";
            this.alarmBt.NumText = null;
            this.alarmBt.Pressed = false;
            this.tableLayoutPanel4.SetRowSpan(this.alarmBt, 2);
            this.alarmBt.Size = new System.Drawing.Size(72, 70);
            this.alarmBt.TabIndex = 12;
            this.alarmBt.TabStop = false;
            this.alarmBt.Text = "报警消除";
            this.alarmBt.UsedLed = false;
            this.alarmBt.UseVisualStyleBackColor = false;
            this.alarmBt.Click += new System.EventHandler(this.AlarmBt_Click);
            // 
            // buttonEx2
            // 
            this.buttonEx2.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonEx2.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.buttonEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEx2.Flag = 0;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEx2.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.buttonEx2.ForeColor = System.Drawing.Color.White;
            this.buttonEx2.LED = false;
            this.buttonEx2.LedLocation = new System.Drawing.Point(4, -8);
            this.buttonEx2.Location = new System.Drawing.Point(81, 2);
            this.buttonEx2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.NumText = null;
            this.buttonEx2.Pressed = false;
            this.tableLayoutPanel4.SetRowSpan(this.buttonEx2, 2);
            this.buttonEx2.Size = new System.Drawing.Size(72, 70);
            this.buttonEx2.TabIndex = 11;
            this.buttonEx2.TabStop = false;
            this.buttonEx2.Text = "紧急停止";
            this.buttonEx2.UsedLed = false;
            this.buttonEx2.UseVisualStyleBackColor = false;
            this.buttonEx2.Click += new System.EventHandler(this.EmgBt_Click);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(248, 39);
            this.label9.Margin = new System.Windows.Forms.Padding(2);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label9.Size = new System.Drawing.Size(412, 33);
            this.label9.TabIndex = 9;
            this.label9.Text = "主界面";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // indexLable
            // 
            this.indexLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.indexLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indexLable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.indexLable.Location = new System.Drawing.Point(158, 39);
            this.indexLable.Margin = new System.Windows.Forms.Padding(2);
            this.indexLable.Name = "indexLable";
            this.indexLable.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.indexLable.Size = new System.Drawing.Size(86, 33);
            this.indexLable.TabIndex = 8;
            this.indexLable.Tag = ",";
            this.indexLable.Text = "(0,0,0)";
            this.indexLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logShow
            // 
            this.logShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.logShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logShow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logShow.Location = new System.Drawing.Point(248, 2);
            this.logShow.Margin = new System.Windows.Forms.Padding(2);
            this.logShow.Name = "logShow";
            this.logShow.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logShow.Size = new System.Drawing.Size(412, 33);
            this.logShow.TabIndex = 6;
            this.logShow.Text = "系统初始化成功";
            this.logShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logNum
            // 
            this.logNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.logNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logNum.ForeColor = System.Drawing.Color.Blue;
            this.logNum.Location = new System.Drawing.Point(158, 2);
            this.logNum.Margin = new System.Windows.Forms.Padding(2);
            this.logNum.Name = "logNum";
            this.logNum.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logNum.Size = new System.Drawing.Size(86, 33);
            this.logNum.TabIndex = 3;
            this.logNum.Text = "S0000";
            this.logNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEx1
            // 
            this.buttonEx1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonEx1.BackgroundImage = global::QSHP.Properties.Resources.logo;
            this.buttonEx1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEx1.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.buttonEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEx1.Flag = 0;
            this.buttonEx1.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEx1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEx1.LED = false;
            this.buttonEx1.LedLocation = new System.Drawing.Point(4, -4);
            this.buttonEx1.Location = new System.Drawing.Point(3, 2);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.NumText = null;
            this.buttonEx1.Pressed = false;
            this.tableLayoutPanel4.SetRowSpan(this.buttonEx1, 2);
            this.buttonEx1.Size = new System.Drawing.Size(72, 70);
            this.buttonEx1.TabIndex = 10;
            this.buttonEx1.TabStop = false;
            this.buttonEx1.UsedLed = false;
            this.buttonEx1.UseVisualStyleBackColor = false;
            this.buttonEx1.Click += new System.EventHandler(this.LogoButton_Click);
            // 
            // netStatus
            // 
            this.netStatus.BackColor = System.Drawing.SystemColors.Control;
            this.netStatus.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.netStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.netStatus.Enabled = false;
            this.netStatus.Flag = 0;
            this.netStatus.FlatAppearance.BorderSize = 0;
            this.netStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.netStatus.LED = false;
            this.netStatus.LedLocation = new System.Drawing.Point(4, 4);
            this.netStatus.Location = new System.Drawing.Point(818, 2);
            this.netStatus.Margin = new System.Windows.Forms.Padding(3, 2, 1, 2);
            this.netStatus.Name = "netStatus";
            this.netStatus.NumText = null;
            this.netStatus.Pressed = false;
            this.netStatus.Size = new System.Drawing.Size(30, 33);
            this.netStatus.TabIndex = 14;
            this.netStatus.TabStop = false;
            this.netStatus.UsedLed = false;
            this.netStatus.UseVisualStyleBackColor = false;
            // 
            // spdStatus
            // 
            this.spdStatus.BackColor = System.Drawing.SystemColors.Control;
            this.spdStatus.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.spdStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdStatus.Enabled = false;
            this.spdStatus.Flag = 0;
            this.spdStatus.FlatAppearance.BorderSize = 0;
            this.spdStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.spdStatus.Font = new System.Drawing.Font("QSHP", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdStatus.ForeColor = System.Drawing.Color.White;
            this.spdStatus.LED = false;
            this.spdStatus.LedLocation = new System.Drawing.Point(4, -9);
            this.spdStatus.Location = new System.Drawing.Point(818, 39);
            this.spdStatus.Margin = new System.Windows.Forms.Padding(3, 2, 1, 2);
            this.spdStatus.Name = "spdStatus";
            this.spdStatus.NumText = null;
            this.spdStatus.Pressed = false;
            this.spdStatus.Size = new System.Drawing.Size(30, 33);
            this.spdStatus.TabIndex = 14;
            this.spdStatus.TabStop = false;
            this.spdStatus.UsedLed = false;
            this.spdStatus.UseVisualStyleBackColor = false;
            // 
            // spdRrogressBar
            // 
            this.spdRrogressBar.BackColor = System.Drawing.Color.Pink;
            this.spdRrogressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdRrogressBar.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.spdRrogressBar.FontColor = System.Drawing.Color.DarkOrchid;
            this.spdRrogressBar.ForeColor = System.Drawing.Color.Aquamarine;
            this.spdRrogressBar.Location = new System.Drawing.Point(665, 40);
            this.spdRrogressBar.Name = "spdRrogressBar";
            this.spdRrogressBar.Size = new System.Drawing.Size(147, 31);
            this.spdRrogressBar.StringFormat = "{0}%";
            this.spdRrogressBar.TabIndex = 15;
            this.spdRrogressBar.Text = "0%";
            this.spdRrogressBar.Visible = false;
            this.spdRrogressBar.VisibleChanged += new System.EventHandler(this.progressBarEx1_VisibleChanged);
            // 
            // TopBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "TopBar";
            this.Size = new System.Drawing.Size(1005, 74);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label timeShow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label indexLable;
        private System.Windows.Forms.Label logShow;
        private System.Windows.Forms.Label logNum;
        private Ctr.ButtonEx buttonEx2;
        private Ctr.ButtonEx buttonEx1;
        private Ctr.ButtonEx alarmBt;
        private Ctr.ButtonEx sensorBt;
        private Ctr.ButtonEx netStatus;
        private Ctr.ButtonEx spdStatus;
        private Ctr.ProgressBarEx spdRrogressBar;
    }
}
