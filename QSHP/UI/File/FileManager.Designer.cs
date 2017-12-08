namespace QSHP.UI
{
    partial class FileManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.fileImageList = new System.Windows.Forms.ImageList(this.components);
            this.tPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pathView = new QSHP.UI.Ctr.TreeViewEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.funPanel = new System.Windows.Forms.TableLayoutPanel();
            this.operaLabel = new System.Windows.Forms.Label();
            this.msgLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new QSHP.UI.Ctr.TextBoxEx();
            this.curCuttingFileName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox = new QSHP.UI.Ctr.PanelEx();
            this.tPanel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.funPanel.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileImageList
            // 
            this.fileImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileImageList.ImageStream")));
            this.fileImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileImageList.Images.SetKeyName(0, "folder_open.png");
            this.fileImageList.Images.SetKeyName(1, "folder_closed.png");
            // 
            // tPanel1
            // 
            this.tPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tPanel1.ColumnCount = 1;
            this.tPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tPanel1.Controls.Add(this.Panel2, 0, 0);
            this.tPanel1.Controls.Add(this.funPanel, 0, 1);
            this.tPanel1.Location = new System.Drawing.Point(3, 56);
            this.tPanel1.Name = "tPanel1";
            this.tPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tPanel1.RowCount = 2;
            this.tPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tPanel1.Size = new System.Drawing.Size(796, 436);
            this.tPanel1.TabIndex = 5;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.Panel2.ColumnCount = 2;
            this.Panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.83436F));
            this.Panel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.16563F));
            this.Panel2.Controls.Add(this.pathView, 0, 0);
            this.Panel2.Controls.Add(this.panel1, 1, 0);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(3, 0);
            this.Panel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.Panel2.Name = "Panel2";
            this.Panel2.RowCount = 1;
            this.Panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Panel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 386F));
            this.Panel2.Size = new System.Drawing.Size(790, 397);
            this.Panel2.TabIndex = 0;
            // 
            // pathView
            // 
            this.pathView.BackColor = System.Drawing.Color.White;
            this.pathView.CollapseImage = ((System.Drawing.Image)(resources.GetObject("pathView.CollapseImage")));
            this.pathView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.pathView.ExpandImage = ((System.Drawing.Image)(resources.GetObject("pathView.ExpandImage")));
            this.pathView.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.pathView.FullRowSelect = true;
            this.pathView.HideSelection = false;
            this.pathView.HotTracking = true;
            this.pathView.ImageIndex = 0;
            this.pathView.ImageList = this.fileImageList;
            this.pathView.Location = new System.Drawing.Point(3, 3);
            this.pathView.Name = "pathView";
            this.pathView.Scrollable = false;
            this.pathView.SelectedImageIndex = 0;
            this.pathView.ShowBootImage = true;
            this.pathView.ShowLines = false;
            this.pathView.ShowRootLines = false;
            this.pathView.Size = new System.Drawing.Size(198, 391);
            this.pathView.TabIndex = 4;
            this.pathView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.PathView_NodeMouseClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.fileListView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(204, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 391);
            this.panel1.TabIndex = 5;
            // 
            // fileListView
            // 
            this.fileListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.fileListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.fileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileListView.FullRowSelect = true;
            this.fileListView.GridLines = true;
            this.fileListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.fileListView.HideSelection = false;
            this.fileListView.LabelWrap = false;
            this.fileListView.Location = new System.Drawing.Point(0, 0);
            this.fileListView.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.fileListView.MultiSelect = false;
            this.fileListView.Name = "fileListView";
            this.fileListView.Scrollable = false;
            this.fileListView.ShowGroups = false;
            this.fileListView.Size = new System.Drawing.Size(581, 389);
            this.fileListView.TabIndex = 4;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            this.fileListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.FileListView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 27;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "划切文件名";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 242;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "划切文件类型";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 173;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "修改日期";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 157;
            // 
            // funPanel
            // 
            this.funPanel.ColumnCount = 3;
            this.funPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.85315F));
            this.funPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.14685F));
            this.funPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.funPanel.Controls.Add(this.operaLabel, 0, 0);
            this.funPanel.Controls.Add(this.msgLabel, 2, 0);
            this.funPanel.Controls.Add(this.nameTextBox, 1, 0);
            this.funPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.funPanel.Location = new System.Drawing.Point(3, 398);
            this.funPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.funPanel.Name = "funPanel";
            this.funPanel.RowCount = 1;
            this.funPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.funPanel.Size = new System.Drawing.Size(790, 35);
            this.funPanel.TabIndex = 2;
            this.funPanel.Visible = false;
            // 
            // operaLabel
            // 
            this.operaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operaLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.operaLabel.Location = new System.Drawing.Point(3, 0);
            this.operaLabel.Name = "operaLabel";
            this.operaLabel.Size = new System.Drawing.Size(195, 35);
            this.operaLabel.TabIndex = 4;
            this.operaLabel.Text = "新建划切文件:";
            this.operaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // msgLabel
            // 
            this.msgLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.msgLabel.Location = new System.Drawing.Point(432, 0);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(355, 35);
            this.msgLabel.TabIndex = 4;
            this.msgLabel.Text = "提示信息";
            this.msgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nameTextBox.Location = new System.Drawing.Point(204, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.SetError = false;
            this.nameTextBox.SetWarn = false;
            this.nameTextBox.Size = new System.Drawing.Size(222, 29);
            this.nameTextBox.TabIndex = 5;
            this.nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // curCuttingFileName
            // 
            this.curCuttingFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.curCuttingFileName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.curCuttingFileName.Location = new System.Drawing.Point(478, 24);
            this.curCuttingFileName.Name = "curCuttingFileName";
            this.curCuttingFileName.Size = new System.Drawing.Size(174, 29);
            this.curCuttingFileName.TabIndex = 3;
            this.curCuttingFileName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label3.Location = new System.Drawing.Point(325, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "当前划切文件:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // selectFileName
            // 
            this.selectFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.selectFileName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.selectFileName.Location = new System.Drawing.Point(154, 25);
            this.selectFileName.Name = "selectFileName";
            this.selectFileName.Size = new System.Drawing.Size(174, 29);
            this.selectFileName.TabIndex = 1;
            this.selectFileName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前选中文件:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.curCuttingFileName);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.selectFileName);
            this.groupBox.Controls.Add(this.tPanel1);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox.HeaderFont = new System.Drawing.Font("微软雅黑", 18F);
            this.groupBox.LeftMode = false;
            this.groupBox.Location = new System.Drawing.Point(5, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(805, 495);
            this.groupBox.TabIndex = 0;
            this.groupBox.Text = "划切文件";
            // 
            // FileManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BT0Content = "新建文件";
            this.BT1Content = "复制文件";
            this.BT2Content = "重命名文件";
            this.BT3Content = "删除文件";
            this.BT5Content = "新建目录";
            this.BT6Content = "删除目录";
            this.BT9Content = "存储介质";
            this.CancelText = "取  消";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.ConfirmText = "编  辑";
            this.Controls.Add(this.groupBox);
            this.FmStyle = QSHP.FormStyle.NextOKCancel;
            this.Name = "FileManager";
            this.NextText = "启  用";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Text = "文件管理";
            this.BT0Click += new System.EventHandler(this.CreateFileButtonClick);
            this.BT1Click += new System.EventHandler(this.CopyFileButtonClick);
            this.BT2Click += new System.EventHandler(this.RenameFileButtonClick);
            this.BT3Click += new System.EventHandler(this.DeleteFileButtonClick);
            this.BT5Click += new System.EventHandler(this.CreateFolderButtonClick);
            this.BT6Click += new System.EventHandler(this.DeleteFolderButtonClick);
            this.BT9Click += new System.EventHandler(this.BrownMoveHardDiskEventHander);
            this.CancelClick += new System.EventHandler(this.FileManager_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.FileManager_ConfirmClick);
            this.NextClick += new System.EventHandler(this.FileManager_NextClick);
            this.tPanel1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.funPanel.ResumeLayout(false);
            this.funPanel.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList fileImageList;
        private System.Windows.Forms.TableLayoutPanel tPanel1;
        private System.Windows.Forms.TableLayoutPanel Panel2;
        private Ctr.TreeViewEx pathView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label curCuttingFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label selectFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel funPanel;
        private System.Windows.Forms.Label operaLabel;
        private System.Windows.Forms.Label msgLabel;
        private Ctr.TextBoxEx nameTextBox;
        private Ctr.PanelEx groupBox;
    }
}