using QSHP.UI;

namespace QSHP
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.funTab = new QSHP.UI.Ctr.TabControlEx();
            this.funPage = new System.Windows.Forms.TabPage();
            this.nextBt = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.confirmBt = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.pathPage = new System.Windows.Forms.TabPage();
            this.tableLPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileDir = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cancelBt = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.monitorEx1 = new QSHP.UI.MonitorEx();
            this.underBar1 = new QSHP.UI.UnderBar();
            this.topBar1 = new QSHP.UI.TopBar();
            this.panel5.SuspendLayout();
            this.funTab.SuspendLayout();
            this.funPage.SuspendLayout();
            this.pathPage.SuspendLayout();
            this.tableLPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 768);
            this.panel1.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 758);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1014, 10);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1015, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(9, 758);
            this.panel4.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 8);
            this.panel2.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.funTab);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.monitorEx1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(825, 82);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(190, 500);
            this.panel5.TabIndex = 28;
            // 
            // funTab
            // 
            this.funTab.Controls.Add(this.funPage);
            this.funTab.Controls.Add(this.pathPage);
            this.funTab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.funTab.ItemSize = new System.Drawing.Size(1, 1);
            this.funTab.Location = new System.Drawing.Point(0, 274);
            this.funTab.Name = "funTab";
            this.funTab.SelectedIndex = 0;
            this.funTab.Size = new System.Drawing.Size(186, 149);
            this.funTab.TabIndex = 30;
            this.funTab.SelectedIndexChanged += new System.EventHandler(this.FunTab_SelectedIndexChanged);
            // 
            // funPage
            // 
            this.funPage.BackColor = System.Drawing.SystemColors.Control;
            this.funPage.Controls.Add(this.nextBt);
            this.funPage.Controls.Add(this.confirmBt);
            this.funPage.Location = new System.Drawing.Point(4, 5);
            this.funPage.Margin = new System.Windows.Forms.Padding(0);
            this.funPage.Name = "funPage";
            this.funPage.Padding = new System.Windows.Forms.Padding(3);
            this.funPage.Size = new System.Drawing.Size(178, 140);
            this.funPage.TabIndex = 0;
            // 
            // nextBt
            // 
            this.nextBt.BackColor = System.Drawing.Color.LimeGreen;
            this.nextBt.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.nextBt.Flag = 0;
            this.nextBt.FlatAppearance.BorderSize = 0;
            this.nextBt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextBt.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nextBt.ForeColor = System.Drawing.Color.White;
            this.nextBt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nextBt.LED = false;
            this.nextBt.LedLocation = new System.Drawing.Point(4, -8);
            this.nextBt.Location = new System.Drawing.Point(20, 4);
            this.nextBt.Name = "nextBt";
            this.nextBt.NumText = null;
            this.nextBt.Pressed = false;
            this.nextBt.Size = new System.Drawing.Size(137, 62);
            this.nextBt.TabIndex = 3;
            this.nextBt.TabStop = false;
            this.nextBt.Text = "开  始";
            this.nextBt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.nextBt.UsedLed = false;
            this.nextBt.UseVisualStyleBackColor = false;
            // 
            // confirmBt
            // 
            this.confirmBt.BackColor = System.Drawing.Color.RoyalBlue;
            this.confirmBt.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.confirmBt.Flag = 0;
            this.confirmBt.FlatAppearance.BorderSize = 0;
            this.confirmBt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.confirmBt.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.confirmBt.ForeColor = System.Drawing.Color.White;
            this.confirmBt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.confirmBt.LED = false;
            this.confirmBt.LedLocation = new System.Drawing.Point(4, -8);
            this.confirmBt.Location = new System.Drawing.Point(20, 75);
            this.confirmBt.Name = "confirmBt";
            this.confirmBt.NumText = null;
            this.confirmBt.Pressed = false;
            this.confirmBt.Size = new System.Drawing.Size(137, 62);
            this.confirmBt.TabIndex = 4;
            this.confirmBt.TabStop = false;
            this.confirmBt.Text = "确  认";
            this.confirmBt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.confirmBt.UsedLed = false;
            this.confirmBt.UseVisualStyleBackColor = false;
            // 
            // pathPage
            // 
            this.pathPage.BackColor = System.Drawing.SystemColors.Control;
            this.pathPage.Controls.Add(this.tableLPanel);
            this.pathPage.Location = new System.Drawing.Point(4, 5);
            this.pathPage.Name = "pathPage";
            this.pathPage.Padding = new System.Windows.Forms.Padding(3);
            this.pathPage.Size = new System.Drawing.Size(178, 140);
            this.pathPage.TabIndex = 2;
            // 
            // tableLPanel
            // 
            this.tableLPanel.ColumnCount = 1;
            this.tableLPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLPanel.Controls.Add(this.fileName, 0, 3);
            this.tableLPanel.Controls.Add(this.label1, 0, 0);
            this.tableLPanel.Controls.Add(this.label2, 0, 2);
            this.tableLPanel.Controls.Add(this.fileDir, 0, 1);
            this.tableLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLPanel.Name = "tableLPanel";
            this.tableLPanel.RowCount = 4;
            this.tableLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLPanel.Size = new System.Drawing.Size(172, 134);
            this.tableLPanel.TabIndex = 0;
            // 
            // fileName
            // 
            this.fileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileName.Location = new System.Drawing.Point(17, 96);
            this.fileName.Margin = new System.Windows.Forms.Padding(17, 0, 58, 0);
            this.fileName.Name = "fileName";
            this.fileName.Padding = new System.Windows.Forms.Padding(3);
            this.fileName.Size = new System.Drawing.Size(138, 38);
            this.fileName.TabIndex = 10;
            this.fileName.Tag = "";
            this.fileName.Text = "File_3.2*3.2";
            this.fileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "目录：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(13, 3, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "文件：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fileDir
            // 
            this.fileDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fileDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileDir.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileDir.Location = new System.Drawing.Point(17, 30);
            this.fileDir.Margin = new System.Windows.Forms.Padding(17, 0, 58, 0);
            this.fileDir.Name = "fileDir";
            this.fileDir.Padding = new System.Windows.Forms.Padding(3);
            this.fileDir.Size = new System.Drawing.Size(138, 36);
            this.fileDir.TabIndex = 9;
            this.fileDir.Tag = "";
            this.fileDir.Text = "Path_Dir";
            this.fileDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cancelBt);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 423);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3);
            this.panel6.Size = new System.Drawing.Size(186, 73);
            this.panel6.TabIndex = 31;
            // 
            // cancelBt
            // 
            this.cancelBt.BackColor = System.Drawing.Color.Gold;
            this.cancelBt.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.cancelBt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBt.Flag = 0;
            this.cancelBt.FlatAppearance.BorderSize = 0;
            this.cancelBt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelBt.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cancelBt.ForeColor = System.Drawing.Color.White;
            this.cancelBt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBt.LED = false;
            this.cancelBt.LedLocation = new System.Drawing.Point(4, -8);
            this.cancelBt.Location = new System.Drawing.Point(24, 2);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.NumText = null;
            this.cancelBt.Pressed = false;
            this.cancelBt.Size = new System.Drawing.Size(137, 62);
            this.cancelBt.TabIndex = 2;
            this.cancelBt.TabStop = false;
            this.cancelBt.Text = "返  回";
            this.cancelBt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelBt.UsedLed = false;
            this.cancelBt.UseVisualStyleBackColor = false;
            // 
            // monitorEx1
            // 
            this.monitorEx1.Location = new System.Drawing.Point(2, 0);
            this.monitorEx1.Name = "monitorEx1";
            this.monitorEx1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.monitorEx1.Size = new System.Drawing.Size(186, 274);
            this.monitorEx1.Style = QSHP.UI.MonitorStyle.Default;
            this.monitorEx1.TabIndex = 5;
            // 
            // underBar1
            // 
            this.underBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.underBar1.Location = new System.Drawing.Point(10, 582);
            this.underBar1.Moitor = null;
            this.underBar1.Name = "underBar1";
            this.underBar1.Size = new System.Drawing.Size(1005, 176);
            this.underBar1.Style = QSHP.UI.UnderStyle.Default;
            this.underBar1.TabIndex = 27;
            // 
            // topBar1
            // 
            this.topBar1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.topBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar1.Location = new System.Drawing.Point(10, 8);
            this.topBar1.Name = "topBar1";
            this.topBar1.Size = new System.Drawing.Size(1005, 74);
            this.topBar1.TabIndex = 16;
            this.topBar1.SensorClick += new System.EventHandler(this.TopBar_SensorClick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.ControlBox = false;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.underBar1);
            this.Controls.Add(this.topBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel5.ResumeLayout(false);
            this.funTab.ResumeLayout(false);
            this.funPage.ResumeLayout(false);
            this.pathPage.ResumeLayout(false);
            this.tableLPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private TopBar topBar1;
        private System.Windows.Forms.Panel panel2;
        private UnderBar underBar1;
        private System.Windows.Forms.Panel panel5;
        private MonitorEx monitorEx1;
        private QSHP.UI.Ctr.ButtonEx cancelBt;
        private System.Windows.Forms.Panel panel6;
        private UI.Ctr.TabControlEx funTab;
        private System.Windows.Forms.TabPage funPage;
        private UI.Ctr.ButtonEx nextBt;
        private UI.Ctr.ButtonEx confirmBt;
        private System.Windows.Forms.TabPage pathPage;
        private System.Windows.Forms.TableLayoutPanel tableLPanel;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fileDir;
    }
}