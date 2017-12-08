using QSHP.UI.Ctr;
namespace QSHP.UI
{
    partial class MonitorEx
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.spdPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.spdStatus = new System.Windows.Forms.Label();
            this.spdSpeed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.clearBT = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.dy = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dx = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.xSpeed = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tPos = new System.Windows.Forms.Label();
            this.zPos = new System.Windows.Forms.Label();
            this.yPos = new System.Windows.Forms.Label();
            this.xPos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tNlimit = new System.Windows.Forms.Label();
            this.zNlimit = new System.Windows.Forms.Label();
            this.yNlimit = new System.Windows.Forms.Label();
            this.xNlimit = new System.Windows.Forms.Label();
            this.tPlimit = new System.Windows.Forms.Label();
            this.zPlimit = new System.Windows.Forms.Label();
            this.yPlimit = new System.Windows.Forms.Label();
            this.xPlimit = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tErr = new QSHP.UI.Ctr.LedEx();
            this.yErr = new QSHP.UI.Ctr.LedEx();
            this.zErr = new QSHP.UI.Ctr.LedEx();
            this.xErr = new QSHP.UI.Ctr.LedEx();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.mainAIR = new System.Windows.Forms.Label();
            this.mainWater = new System.Windows.Forms.Label();
            this.cutWater = new System.Windows.Forms.Label();
            this.workAir = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tabAir = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlot)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.tabControl1.ItemSize = new System.Drawing.Size(43, 43);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(186, 275);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.spdPlot);
            this.tabPage2.Controls.Add(this.spdStatus);
            this.tabPage2.Controls.Add(this.spdSpeed);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabPage2.Location = new System.Drawing.Point(4, 47);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(178, 224);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "主轴";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // spdPlot
            // 
            this.spdPlot.BackColor = System.Drawing.SystemColors.Control;
            this.spdPlot.BorderlineColor = System.Drawing.SystemColors.ActiveBorder;
            this.spdPlot.CausesValidation = false;
            chartArea6.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea6.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea6.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea6.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea6.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea6.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea6.AxisX.IsMarginVisible = false;
            chartArea6.AxisX.LabelStyle.Enabled = false;
            chartArea6.AxisX.MajorGrid.Enabled = false;
            chartArea6.AxisX.MajorTickMark.Enabled = false;
            chartArea6.AxisX.MaximumAutoSize = 0F;
            chartArea6.AxisX.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            chartArea6.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea6.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea6.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea6.AxisY.InterlacedColor = System.Drawing.Color.WhiteSmoke;
            chartArea6.AxisY.IsLabelAutoFit = false;
            chartArea6.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea6.AxisY.Maximum = 2D;
            chartArea6.AxisY.Minimum = 0D;
            chartArea6.IsSameFontSizeForAllAxes = true;
            chartArea6.Name = "ChartArea1";
            chartArea6.Position.Auto = false;
            chartArea6.Position.Height = 94F;
            chartArea6.Position.Width = 94F;
            chartArea6.Position.Y = 3F;
            this.spdPlot.ChartAreas.Add(chartArea6);
            this.spdPlot.Location = new System.Drawing.Point(4, 57);
            this.spdPlot.Name = "spdPlot";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Color = System.Drawing.Color.DarkCyan;
            series6.IsVisibleInLegend = false;
            series6.IsXValueIndexed = true;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.spdPlot.Series.Add(series6);
            this.spdPlot.Size = new System.Drawing.Size(170, 140);
            this.spdPlot.TabIndex = 10;
            this.spdPlot.Text = "主轴电流";
            title6.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            title6.DockedToChartArea = "ChartArea1";
            title6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            title6.ForeColor = System.Drawing.Color.Blue;
            title6.Name = "Title1";
            title6.Text = "I = 0.0 A";
            this.spdPlot.Titles.Add(title6);
            // 
            // spdStatus
            // 
            this.spdStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.spdStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spdStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.spdStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.spdStatus.Location = new System.Drawing.Point(71, 32);
            this.spdStatus.Margin = new System.Windows.Forms.Padding(3);
            this.spdStatus.Name = "spdStatus";
            this.spdStatus.Size = new System.Drawing.Size(92, 25);
            this.spdStatus.TabIndex = 9;
            this.spdStatus.Text = "未连接";
            this.spdStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spdSpeed
            // 
            this.spdSpeed.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.spdSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spdSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.spdSpeed.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdSpeed.Location = new System.Drawing.Point(71, 7);
            this.spdSpeed.Margin = new System.Windows.Forms.Padding(3);
            this.spdSpeed.Name = "spdSpeed";
            this.spdSpeed.Size = new System.Drawing.Size(92, 25);
            this.spdSpeed.TabIndex = 8;
            this.spdSpeed.Text = "0";
            this.spdSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(9, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "变频器";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(25, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "转速";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.clearBT);
            this.tabPage3.Controls.Add(this.dy);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.dx);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.xSpeed);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.tPos);
            this.tabPage3.Controls.Add(this.zPos);
            this.tabPage3.Controls.Add(this.yPos);
            this.tabPage3.Controls.Add(this.xPos);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabPage3.Location = new System.Drawing.Point(4, 47);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(178, 224);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "坐标";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // clearBT
            // 
            this.clearBT.BackColor = System.Drawing.SystemColors.Control;
            this.clearBT.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.clearBT.FlatAppearance.BorderSize = 0;
            this.clearBT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearBT.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearBT.LED = false;
            this.clearBT.LedLocation = new System.Drawing.Point(4, 1);
            this.clearBT.Location = new System.Drawing.Point(65, 189);
            this.clearBT.Name = "clearBT";
            this.clearBT.NumText = null;
            this.clearBT.Pressed = false;
            this.clearBT.Size = new System.Drawing.Size(98, 30);
            this.clearBT.TabIndex = 14;
            this.clearBT.TabStop = false;
            this.clearBT.Text = "清  零";
            this.clearBT.UsedLed = false;
            this.clearBT.UseVisualStyleBackColor = false;
            this.clearBT.Click += new System.EventHandler(this.ClearPosition_Click);
            // 
            // dy
            // 
            this.dy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dy.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dy.Location = new System.Drawing.Point(66, 157);
            this.dy.Margin = new System.Windows.Forms.Padding(3);
            this.dy.Name = "dy";
            this.dy.Size = new System.Drawing.Size(97, 25);
            this.dy.TabIndex = 13;
            this.dy.Text = "0.000";
            this.dy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(30, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 21);
            this.label14.TabIndex = 12;
            this.label14.Text = "Dy";
            // 
            // dx
            // 
            this.dx.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dx.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dx.Location = new System.Drawing.Point(66, 132);
            this.dx.Margin = new System.Windows.Forms.Padding(3);
            this.dx.Name = "dx";
            this.dx.Size = new System.Drawing.Size(97, 25);
            this.dx.TabIndex = 11;
            this.dx.Text = "0.000";
            this.dx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(30, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 21);
            this.label12.TabIndex = 10;
            this.label12.Text = "Dx";
            // 
            // xSpeed
            // 
            this.xSpeed.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.xSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xSpeed.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xSpeed.Location = new System.Drawing.Point(66, 107);
            this.xSpeed.Margin = new System.Windows.Forms.Padding(3);
            this.xSpeed.Name = "xSpeed";
            this.xSpeed.Size = new System.Drawing.Size(97, 25);
            this.xSpeed.TabIndex = 9;
            this.xSpeed.Text = "0.000";
            this.xSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(8, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 21);
            this.label9.TabIndex = 8;
            this.label9.Text = "X速度";
            // 
            // tPos
            // 
            this.tPos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tPos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tPos.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPos.Location = new System.Drawing.Point(66, 82);
            this.tPos.Margin = new System.Windows.Forms.Padding(3);
            this.tPos.Name = "tPos";
            this.tPos.Size = new System.Drawing.Size(97, 25);
            this.tPos.TabIndex = 7;
            this.tPos.Text = "0.000";
            this.tPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // zPos
            // 
            this.zPos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.zPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zPos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zPos.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zPos.Location = new System.Drawing.Point(66, 57);
            this.zPos.Margin = new System.Windows.Forms.Padding(3);
            this.zPos.Name = "zPos";
            this.zPos.Size = new System.Drawing.Size(97, 25);
            this.zPos.TabIndex = 6;
            this.zPos.Text = "0.000";
            this.zPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yPos
            // 
            this.yPos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.yPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.yPos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yPos.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yPos.Location = new System.Drawing.Point(66, 32);
            this.yPos.Margin = new System.Windows.Forms.Padding(3);
            this.yPos.Name = "yPos";
            this.yPos.Size = new System.Drawing.Size(97, 25);
            this.yPos.TabIndex = 5;
            this.yPos.Text = "0.000";
            this.yPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xPos
            // 
            this.xPos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.xPos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xPos.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPos.Location = new System.Drawing.Point(66, 7);
            this.xPos.Margin = new System.Windows.Forms.Padding(3);
            this.xPos.Name = "xPos";
            this.xPos.Size = new System.Drawing.Size(97, 25);
            this.xPos.TabIndex = 4;
            this.xPos.Text = "0.000";
            this.xPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Z坐标";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "T坐标";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y坐标";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "X坐标";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tabPage4.Location = new System.Drawing.Point(4, 47);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(178, 224);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "限位";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tNlimit);
            this.groupBox2.Controls.Add(this.zNlimit);
            this.groupBox2.Controls.Add(this.yNlimit);
            this.groupBox2.Controls.Add(this.xNlimit);
            this.groupBox2.Controls.Add(this.tPlimit);
            this.groupBox2.Controls.Add(this.zPlimit);
            this.groupBox2.Controls.Add(this.yPlimit);
            this.groupBox2.Controls.Add(this.xPlimit);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 131);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轴限位状态";
            // 
            // tNlimit
            // 
            this.tNlimit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tNlimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tNlimit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tNlimit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNlimit.Location = new System.Drawing.Point(113, 98);
            this.tNlimit.Margin = new System.Windows.Forms.Padding(3);
            this.tNlimit.Name = "tNlimit";
            this.tNlimit.Size = new System.Drawing.Size(48, 25);
            this.tNlimit.TabIndex = 56;
            this.tNlimit.Text = "---";
            this.tNlimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zNlimit
            // 
            this.zNlimit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.zNlimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zNlimit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zNlimit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zNlimit.Location = new System.Drawing.Point(113, 73);
            this.zNlimit.Margin = new System.Windows.Forms.Padding(3);
            this.zNlimit.Name = "zNlimit";
            this.zNlimit.Size = new System.Drawing.Size(48, 25);
            this.zNlimit.TabIndex = 55;
            this.zNlimit.Text = "---";
            this.zNlimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yNlimit
            // 
            this.yNlimit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.yNlimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.yNlimit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yNlimit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yNlimit.Location = new System.Drawing.Point(113, 48);
            this.yNlimit.Margin = new System.Windows.Forms.Padding(3);
            this.yNlimit.Name = "yNlimit";
            this.yNlimit.Size = new System.Drawing.Size(48, 25);
            this.yNlimit.TabIndex = 54;
            this.yNlimit.Text = "---";
            this.yNlimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xNlimit
            // 
            this.xNlimit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xNlimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.xNlimit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xNlimit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xNlimit.Location = new System.Drawing.Point(113, 23);
            this.xNlimit.Margin = new System.Windows.Forms.Padding(3);
            this.xNlimit.Name = "xNlimit";
            this.xNlimit.Size = new System.Drawing.Size(48, 25);
            this.xNlimit.TabIndex = 53;
            this.xNlimit.Text = "---";
            this.xNlimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tPlimit
            // 
            this.tPlimit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tPlimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tPlimit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tPlimit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPlimit.Location = new System.Drawing.Point(58, 98);
            this.tPlimit.Margin = new System.Windows.Forms.Padding(3);
            this.tPlimit.Name = "tPlimit";
            this.tPlimit.Size = new System.Drawing.Size(48, 25);
            this.tPlimit.TabIndex = 52;
            this.tPlimit.Text = "---";
            this.tPlimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zPlimit
            // 
            this.zPlimit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.zPlimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.zPlimit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zPlimit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zPlimit.Location = new System.Drawing.Point(58, 73);
            this.zPlimit.Margin = new System.Windows.Forms.Padding(3);
            this.zPlimit.Name = "zPlimit";
            this.zPlimit.Size = new System.Drawing.Size(48, 25);
            this.zPlimit.TabIndex = 51;
            this.zPlimit.Text = "---";
            this.zPlimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yPlimit
            // 
            this.yPlimit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.yPlimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.yPlimit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.yPlimit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yPlimit.Location = new System.Drawing.Point(58, 48);
            this.yPlimit.Margin = new System.Windows.Forms.Padding(3);
            this.yPlimit.Name = "yPlimit";
            this.yPlimit.Size = new System.Drawing.Size(48, 25);
            this.yPlimit.TabIndex = 50;
            this.yPlimit.Text = "---";
            this.yPlimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPlimit
            // 
            this.xPlimit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.xPlimit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.xPlimit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.xPlimit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xPlimit.Location = new System.Drawing.Point(58, 23);
            this.xPlimit.Margin = new System.Windows.Forms.Padding(3);
            this.xPlimit.Name = "xPlimit";
            this.xPlimit.Size = new System.Drawing.Size(48, 25);
            this.xPlimit.TabIndex = 49;
            this.xPlimit.Text = "---";
            this.xPlimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(8, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 20);
            this.label13.TabIndex = 48;
            this.label13.Text = "Z限位";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(9, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 20);
            this.label15.TabIndex = 47;
            this.label15.Text = "T限位";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(8, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 20);
            this.label16.TabIndex = 46;
            this.label16.Text = "Y限位";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(8, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 20);
            this.label17.TabIndex = 45;
            this.label17.Text = "X限位";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tErr);
            this.groupBox1.Controls.Add(this.yErr);
            this.groupBox1.Controls.Add(this.zErr);
            this.groupBox1.Controls.Add(this.xErr);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 80);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "驱动器状态";
            // 
            // tErr
            // 
            this.tErr.BackColor = System.Drawing.Color.Transparent;
            this.tErr.BorderColor = System.Drawing.Color.Gray;
            this.tErr.BorderWidth = 1;
            this.tErr.CenterColor = System.Drawing.Color.Salmon;
            this.tErr.CircleColor = System.Drawing.Color.Red;
            this.tErr.Location = new System.Drawing.Point(133, 54);
            this.tErr.Name = "tErr";
            this.tErr.Size = new System.Drawing.Size(20, 20);
            this.tErr.Switch = false;
            this.tErr.TabIndex = 17;
            // 
            // yErr
            // 
            this.yErr.BackColor = System.Drawing.Color.Transparent;
            this.yErr.BorderColor = System.Drawing.Color.Gray;
            this.yErr.BorderWidth = 1;
            this.yErr.CenterColor = System.Drawing.Color.Salmon;
            this.yErr.CircleColor = System.Drawing.Color.Red;
            this.yErr.Location = new System.Drawing.Point(133, 27);
            this.yErr.Name = "yErr";
            this.yErr.Size = new System.Drawing.Size(20, 20);
            this.yErr.Switch = false;
            this.yErr.TabIndex = 17;
            // 
            // zErr
            // 
            this.zErr.BackColor = System.Drawing.Color.Transparent;
            this.zErr.BorderColor = System.Drawing.Color.Gray;
            this.zErr.BorderWidth = 1;
            this.zErr.CenterColor = System.Drawing.Color.Salmon;
            this.zErr.CircleColor = System.Drawing.Color.Red;
            this.zErr.Location = new System.Drawing.Point(57, 54);
            this.zErr.Name = "zErr";
            this.zErr.Size = new System.Drawing.Size(20, 20);
            this.zErr.Switch = false;
            this.zErr.TabIndex = 17;
            // 
            // xErr
            // 
            this.xErr.BackColor = System.Drawing.Color.Transparent;
            this.xErr.BorderColor = System.Drawing.Color.Gray;
            this.xErr.BorderWidth = 1;
            this.xErr.CenterColor = System.Drawing.Color.Salmon;
            this.xErr.CircleColor = System.Drawing.Color.Red;
            this.xErr.Location = new System.Drawing.Point(57, 27);
            this.xErr.Name = "xErr";
            this.xErr.Size = new System.Drawing.Size(20, 20);
            this.xErr.Switch = false;
            this.xErr.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(90, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "T 轴";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(89, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 21);
            this.label11.TabIndex = 11;
            this.label11.Text = "Y 轴";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(11, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Z 轴";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(11, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "X 轴";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(9, 59);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 21);
            this.label27.TabIndex = 10;
            this.label27.Text = "主气压";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(9, 84);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(58, 21);
            this.label26.TabIndex = 11;
            this.label26.Text = "冷却水";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(25, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 21);
            this.label25.TabIndex = 12;
            this.label25.Text = "吸片";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(9, 109);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 21);
            this.label24.TabIndex = 13;
            this.label24.Text = "切割水";
            // 
            // mainAIR
            // 
            this.mainAIR.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainAIR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainAIR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainAIR.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainAIR.Location = new System.Drawing.Point(71, 57);
            this.mainAIR.Margin = new System.Windows.Forms.Padding(3);
            this.mainAIR.Name = "mainAIR";
            this.mainAIR.Size = new System.Drawing.Size(92, 25);
            this.mainAIR.TabIndex = 14;
            this.mainAIR.Text = "0";
            this.mainAIR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainWater
            // 
            this.mainWater.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mainWater.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainWater.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainWater.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainWater.Location = new System.Drawing.Point(71, 82);
            this.mainWater.Margin = new System.Windows.Forms.Padding(3);
            this.mainWater.Name = "mainWater";
            this.mainWater.Size = new System.Drawing.Size(92, 25);
            this.mainWater.TabIndex = 15;
            this.mainWater.Text = "0";
            this.mainWater.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cutWater
            // 
            this.cutWater.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cutWater.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutWater.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cutWater.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutWater.Location = new System.Drawing.Point(71, 107);
            this.cutWater.Margin = new System.Windows.Forms.Padding(3);
            this.cutWater.Name = "cutWater";
            this.cutWater.Size = new System.Drawing.Size(92, 25);
            this.cutWater.TabIndex = 16;
            this.cutWater.Text = "0";
            this.cutWater.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // workAir
            // 
            this.workAir.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.workAir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.workAir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.workAir.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workAir.Location = new System.Drawing.Point(71, 7);
            this.workAir.Margin = new System.Windows.Forms.Padding(3);
            this.workAir.Name = "workAir";
            this.workAir.Size = new System.Drawing.Size(92, 25);
            this.workAir.TabIndex = 17;
            this.workAir.Text = "0";
            this.workAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(25, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 21);
            this.label19.TabIndex = 18;
            this.label19.Text = "吸台";
            // 
            // tabAir
            // 
            this.tabAir.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabAir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabAir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tabAir.Font = new System.Drawing.Font("QSHP", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAir.Location = new System.Drawing.Point(71, 32);
            this.tabAir.Margin = new System.Windows.Forms.Padding(3);
            this.tabAir.Name = "tabAir";
            this.tabAir.Size = new System.Drawing.Size(92, 25);
            this.tabAir.TabIndex = 19;
            this.tabAir.Text = "0";
            this.tabAir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabAir);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.workAir);
            this.tabPage1.Controls.Add(this.cutWater);
            this.tabPage1.Controls.Add(this.mainWater);
            this.tabPage1.Controls.Add(this.mainAIR);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 47);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(178, 224);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "水气";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MonitorEx
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "MonitorEx";
            this.Size = new System.Drawing.Size(186, 275);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdPlot)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart spdPlot;
        private System.Windows.Forms.Label spdStatus;
        private System.Windows.Forms.Label spdSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private ButtonEx clearBT;
        private System.Windows.Forms.Label dy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label dx;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label xSpeed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label tPos;
        private System.Windows.Forms.Label zPos;
        private System.Windows.Forms.Label yPos;
        private System.Windows.Forms.Label xPos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label tNlimit;
        private System.Windows.Forms.Label zNlimit;
        private System.Windows.Forms.Label yNlimit;
        private System.Windows.Forms.Label xNlimit;
        private System.Windows.Forms.Label tPlimit;
        private System.Windows.Forms.Label zPlimit;
        private System.Windows.Forms.Label yPlimit;
        private System.Windows.Forms.Label xPlimit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private LedEx tErr;
        private LedEx yErr;
        private LedEx zErr;
        private LedEx xErr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label tabAir;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label workAir;
        private System.Windows.Forms.Label cutWater;
        private System.Windows.Forms.Label mainWater;
        private System.Windows.Forms.Label mainAIR;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
    }
}
