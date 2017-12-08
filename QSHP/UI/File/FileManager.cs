using QSHP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI
{
    public partial class FileManager : BaseForm
    {
        private string usedFileFullName = string.Empty;
        private TreeNode selectNode;
        private string fileAtt = "*.*";
        private string fileTag = "划切";

        private FileOpera fileOpera = FileOpera.None;


        public FileManager()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                usedFileFullName = Globals.AppCfg.CutFileFullName;
                LoadDefaultFile();
            }
        }
        public FileManager( FileStyle st,string path)
        {
            InitializeComponent();
            if (!DesignMode)
            {
               
                
                this.FileStyle = st;
                usedFileFullName = path;
                LoadDefaultFile();
            }
        }

        private void BrownMoveHardDiskEventHander(object sender, EventArgs e)
        {
             bool flag = ProcessCmd.HasMoveHardDisk();
            if (flag)
            {

            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.F0049);
            }
        }

        private FileStyle fileStyle = FileStyle.CutFile;

        public FileStyle FileStyle
        {
            get
            {
                return fileStyle;
            }
            set
            {
                fileStyle = value;
                switch (value)
                {
                    case FileStyle.Dress:
                        {
                            fileTag = "磨刀";
                            fileAtt = "*.drs";
                            label3.Visible = false;
                            curCuttingFileName.Visible = false;
                        }
                        break;
                    case FileStyle.Log:
                        {
                            fileAtt = "*.loger";
                            fileTag = "日志";
                            label3.Visible = false;
                            curCuttingFileName.Visible = false;
                        }
                        break;
                    default:
                        {
                            fileAtt = "*.ctd";
                            label1.Text = "当前选中文件:";
                            fileTag = "划切";
                            label3.Visible = true;
                            curCuttingFileName.Visible = true;
                        }
                        break;
                }
                groupBox.Text = string.Format("{0}文件", fileTag);
                this.Text = groupBox.Text;
            }
        }

        public bool LoadFilePath(TreeNode nodes, string path)
        {
            if (Directory.Exists(path))
            {
                string[] paths = Directory.GetDirectories(path);
                if (File.Exists(usedFileFullName))//如果用户名存在
                {
                    string pt = Path.GetDirectoryName(usedFileFullName);
                    if (pt.Equals(path))
                    {
                        selectNode = nodes;
                    }
                    foreach (var item in paths)
                    {
                        int index = Directory.GetDirectories(item).Count() > 0 ? 0 : 1;
                        TreeNode node = new TreeNode(Path.GetFileNameWithoutExtension(item), index, index);
                        node.Tag = item;
                        if (item.Equals(pt))
                        {
                            selectNode = node;
                        }
                        LoadFilePath(node, item);
                        nodes.Nodes.Add(node);
                    }
                }
                else
                {
                    foreach (var item in paths)
                    {
                        int index = Directory.GetDirectories(item).Count() > 0 ? 0 : 1;
                        TreeNode node = new TreeNode(Path.GetFileNameWithoutExtension(item), index, index);
                        node.Tag = item;
                        LoadFilePath(node, item);
                        nodes.Nodes.Add(node);
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoadFileName(string path)
        {
            fileListView.Items.Clear();
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, fileAtt);
                foreach (var item in files)
                {
                    ListViewItem subItem = new ListViewItem();
                    string name = Path.GetFileNameWithoutExtension(item);
                    subItem.SubItems.Add(name);
                    subItem.SubItems.Add(string.Empty);
                    subItem.SubItems.Add(File.GetLastWriteTime(item).ToShortDateString());
                    subItem.Tag = item;
                    fileListView.Items.Add(subItem);
                    if (selectFileName.Tag != null)
                    {
                        if (item.Equals(selectFileName.Tag.ToString()))
                        {
                            subItem.Selected = true;
                        }
                    }
                    else
                    {
                        if (item.Equals(usedFileFullName))
                        {
                            subItem.Selected = true;
                            curCuttingFileName.Text = Path.GetFileNameWithoutExtension(item);
                        }
                    }
                }
                return true;
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.F0001);//划切文件不存在
                return false;
            }
        }

        public bool LoadFiles(string name, string path)
        {
            if (!Directory.Exists(path))
            {
                Common.ReportCmdKeyProgress(CmdKey.F0001);
                return false;
            }
            TreeNode node = new TreeNode(name, 0, 0);
            node.Tag = path;
            selectNode = null;
            if (LoadFilePath(node, path))
            {
                try
                {
                    //pathView.BeginUpdate();
                    pathView.Nodes.Clear();
                    pathView.Nodes.Add(node);
                    pathView.ExpandAll();
                    //pathView.EndUpdate();
                    if (selectNode != null)
                    {
                        pathView.SelectedNode = selectNode;
                        return LoadFileName(selectNode.Tag.ToString());
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return LoadFileName(path);
        }

        private bool LoadDefaultFile()
        {
           
            funPanel.Visible = false;
            String path = string.Empty;
            string tab = "划切文件";
            switch (FileStyle)
            {
                case FileStyle.Dress://磨刀文件
                    {
                        tab = "磨刀文件";
                        path = Application.StartupPath + @"\Data\FCLOGDATA";
                    }
                    break;
                case FileStyle.Log://日志文件
                    {
                        tab = "日志文件";
                        path = Application.StartupPath + @"\Data\FCLOGDATA";
                        Common.ReportCmdKeyProgress(CmdKey.F0002);
                    }
                    break;
                default://划切文件
                    {
                        tab = "划切文件";
                        path = Path.GetDirectoryName( Globals.AppCfg.CutFilePath);
                    }
                    break;
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Common.ReportCmdKeyProgress(CmdKey.F0003);
            }
            return LoadFiles(tab, path);
        }

#region 事件处理
        private void PathView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null && e.Node.Tag != null)
            {
                LoadFileName(e.Node.Tag.ToString());
            }
        }

        private void FileListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            selectFileName.Text = Path.GetFileNameWithoutExtension(e.Item.Tag.ToString());
            selectFileName.Tag = e.Item.Tag;
        }

        private bool CheckFileNameExists(string path, string filename, string fileAtt = "*.*")
        {
            if (!Directory.Exists(path))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(filename))
            {
                return false;
            }
            string[] files = Directory.GetFiles(path, fileAtt);
            filename = filename.ToLower();
            foreach (var item in files)
            {
                if (Path.GetFileNameWithoutExtension(item.ToLower()).Equals(filename))
                {
                    return false;
                }
            }
            return true;
        }

        private void CreateFileButtonClick(object sender, EventArgs e)
        {
            if (!funPanel.Visible || fileOpera != FileOpera.CreatFile)
            {
                funPanel.Visible = true;
                fileOpera = FileOpera.CreatFile;
                operaLabel.Text = string.Format("新建{0}文件:", fileTag);
                nameTextBox.Text = selectFileName.Text;
                nameTextBox.Enabled = true;
                msgLabel.Text = "再次点击<新建文件>确认新建文件！";
                msgLabel.ForeColor = SystemColors.ActiveCaptionText;
                Common.ReportCmdKeyProgress(CmdKey.F0007);
            }
            else
            {
                string path = pathView.SelectedNode.Tag.ToString();
                if (CheckFileNameExists(path, nameTextBox.Text, fileAtt))
                {
                    if (pathView.SelectedNode != null && pathView.SelectedNode.Tag != null)
                    {
                        File.Create(string.Format("{0}\\{1}{2}", path, nameTextBox.Text, fileAtt.Remove(0, 1))).Close();
                        funPanel.Visible = false;
                        fileOpera = FileOpera.None;
                        LoadFileName(pathView.SelectedNode.Tag.ToString());
                        Common.ReportCmdKeyProgress(CmdKey.F0004);
                    }
                    else
                    {
                        msgLabel.Text = "请选择新建文件所属目录";
                        msgLabel.ForeColor = Color.Red;
                        Common.ReportCmdKeyProgress(CmdKey.F0005);
                    }
                }
                else
                {
                    msgLabel.Text = "新建文件名无效,请重新输入";
                    msgLabel.ForeColor = Color.Red;
                    Common.ReportCmdKeyProgress(CmdKey.F0006);
                }
            }
        }

        private void DeleteFileButtonClick(object sender, EventArgs e)
        {
            if (!funPanel.Visible || fileOpera != FileOpera.DeleteFile)
            {
                fileOpera = FileOpera.DeleteFile;
                funPanel.Visible = true;
                operaLabel.Text = string.Format("删除{0}文件:", fileTag);
                nameTextBox.Text = selectFileName.Text;
                nameTextBox.Enabled = false;
                msgLabel.Text = "再次点击<删除文件>确认删除文件！";
                msgLabel.ForeColor = SystemColors.ActiveCaptionText;
                Common.ReportCmdKeyProgress(CmdKey.F0008);
            }
            else
            {
                if (fileListView.SelectedItems.Count > 0)
                {
                    string fn = fileListView.SelectedItems[0].Tag.ToString();
                    if (fn.Equals(usedFileFullName))
                    {
                        msgLabel.Text = "无法删除当前选中的文件";
                        msgLabel.ForeColor = Color.Red;
                        Common.ReportCmdKeyProgress(CmdKey.F0009);
                    }
                    else
                    {
                        File.Delete(fn);
                        funPanel.Visible = false;
                        fileOpera = FileOpera.None;
                        Common.ReportCmdKeyProgress(CmdKey.F0010);
                        LoadFileName(pathView.SelectedNode.Tag.ToString());
                    }
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0011);
                    msgLabel.Text = "请选择要删除的文件";
                    msgLabel.ForeColor = Color.Red;
                }
            }
        }

        private void CopyFileButtonClick(object sender, EventArgs e)
        {
            if (!funPanel.Visible || fileOpera != FileOpera.CopyFile)
            {
                funPanel.Visible = true;
                fileOpera = FileOpera.CopyFile;
                operaLabel.Text = string.Format("复制{0}文件:", fileTag);
                nameTextBox.Text = selectFileName.Text;
                nameTextBox.Enabled = true;
                msgLabel.Text = "再次点击<复制文件>确认复制文件！";
                msgLabel.ForeColor = SystemColors.ActiveCaptionText;
                Common.ReportCmdKeyProgress(CmdKey.F0021);
            }
            else
            {
                string path = pathView.SelectedNode.Tag.ToString();
                if (selectFileName.Tag != null)
                {
                    if (CheckFileNameExists(path, nameTextBox.Text, fileAtt))
                    {
                        if (pathView.SelectedNode != null && pathView.SelectedNode.Tag != null)
                        {
                            string newName = string.Format("{0}\\{1}{2}", path, nameTextBox.Text, fileAtt.Remove(0, 1));
                            File.Copy(selectFileName.Tag.ToString(), newName);
                            funPanel.Visible = false;
                            fileOpera = FileOpera.None;
                            LoadFileName(pathView.SelectedNode.Tag.ToString());
                            Common.ReportCmdKeyProgress(CmdKey.F0013);
                        }
                        else
                        {
                            Common.ReportCmdKeyProgress(CmdKey.F0005);
                            msgLabel.Text = "请选择复制文件所属目录";
                            msgLabel.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        msgLabel.Text = "复制文件名无效,请重新输入";
                        msgLabel.ForeColor = Color.Red;
                        Common.ReportCmdKeyProgress(CmdKey.F0012);
                    }
                }
                else
                {
                    msgLabel.Text = "请先选择要复制的文件";
                    msgLabel.ForeColor = Color.Red;
                    Common.ReportCmdKeyProgress(CmdKey.F0011);
                }
            }
        }

        private void RenameFileButtonClick(object sender, EventArgs e)
        {
            if (!funPanel.Visible || fileOpera != FileOpera.Rename)
            {
                funPanel.Visible = true;
                fileOpera = FileOpera.Rename;
                operaLabel.Text = string.Format("重命名{0}文件:", fileTag);
                nameTextBox.Text = selectFileName.Text;
                nameTextBox.Enabled = true;
                msgLabel.Text = "再次点击<重命名文件>确认重命名文件！";
                msgLabel.ForeColor = SystemColors.ActiveCaptionText;
                Common.ReportCmdKeyProgress(CmdKey.F0022);
            }
            else
            {
                string path = pathView.SelectedNode.Tag.ToString();
                if (selectFileName.Tag != null)
                {
                    if (CheckFileNameExists(path, nameTextBox.Text, fileAtt))
                    {
                        if (pathView.SelectedNode != null && pathView.SelectedNode.Tag != null)
                        {
                            string newName = string.Format("{0}\\{1}{2}", path, nameTextBox.Text, fileAtt.Remove(0, 1));
                            File.Move(selectFileName.Tag.ToString(), newName);
                            funPanel.Visible = false;
                            fileOpera = FileOpera.None;
                            LoadFileName(pathView.SelectedNode.Tag.ToString());
                            Common.ReportCmdKeyProgress(CmdKey.F0014);
                        }
                        else
                        {
                            Common.ReportCmdKeyProgress(CmdKey.F0005);
                            msgLabel.Text = "请选择重命名文件所属目录";
                            msgLabel.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        Common.ReportCmdKeyProgress(CmdKey.F0012);
                        msgLabel.Text = "重命名文件名无效,请重新输入";
                        msgLabel.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0011);
                    msgLabel.Text = "请先选择要重命名的文件";
                    msgLabel.ForeColor = Color.Red;
                }

            }
        }

        private void CreateFolderButtonClick(object sender, EventArgs e)
        {
            if (!funPanel.Visible || fileOpera != FileOpera.CreateFolder)
            {
                funPanel.Visible = true;
                fileOpera = FileOpera.CreateFolder;
                operaLabel.Text = string.Format("新建{0}目录:", fileTag);
                nameTextBox.Text = "";
                nameTextBox.Enabled = true;
                msgLabel.Text = "再次点击<新建目录>确认新建目录！";
                msgLabel.ForeColor = SystemColors.ActiveCaptionText;
                Common.ReportCmdKeyProgress(CmdKey.F0023);
            }
            else
            {
                string path = pathView.SelectedNode.Tag.ToString();
                if (!string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    string newPath = string.Format("{0}\\{1}", path, nameTextBox.Text);
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                        funPanel.Visible = false;
                        fileOpera = FileOpera.None;
                        LoadDefaultFile();
                        Common.ReportCmdKeyProgress(CmdKey.F0016);
                    }
                    else
                    {
                        msgLabel.Text = "目录已存在,请重新输入";
                        msgLabel.ForeColor = Color.Red;
                        Common.ReportCmdKeyProgress(CmdKey.F0015);
                    }
                }
                else
                {
                    msgLabel.Text = "新建目录名无效,请重新输入";
                    msgLabel.ForeColor = Color.Red;
                    Common.ReportCmdKeyProgress(CmdKey.F0015);
                }
            }
        }

        private void DeleteFolderButtonClick(object sender, EventArgs e)
        {
            if (pathView.SelectedNode == null)
                return;
            if (!funPanel.Visible || fileOpera != FileOpera.DeleteFolder)
            {
                funPanel.Visible = true;
                fileOpera = FileOpera.DeleteFolder;
                operaLabel.Text = string.Format("删除{0}目录:", fileTag);
                nameTextBox.Text = pathView.SelectedNode.Text;
                nameTextBox.Enabled = false;
                msgLabel.Text = "再次点击<删除目录>确认删除目录！";
                msgLabel.ForeColor = SystemColors.ActiveCaptionText;
                Common.ReportCmdKeyProgress(CmdKey.F0024);
            }
            else
            {
                nameTextBox.Text = pathView.SelectedNode.Text;
                string folder = pathView.SelectedNode.Tag.ToString();
                if (Directory.Exists(folder))
                {
                    if (Directory.GetFiles(folder, fileAtt).Count() == 0)
                    {
                        Directory.Delete(folder);
                        funPanel.Visible = false;
                        fileOpera = FileOpera.None;
                        LoadDefaultFile();
                        Common.ReportCmdKeyProgress(CmdKey.F0018);
                    }
                    else
                    {
                        msgLabel.Text = "该目录无法删除，请先删除目录下文件";
                        msgLabel.ForeColor = Color.Red;
                        Common.ReportCmdKeyProgress(CmdKey.F0017);
                    }
                }
                else
                {
                    msgLabel.Text = "请先选择要删除的目录";
                    msgLabel.ForeColor = Color.Red;
                    Common.ReportCmdKeyProgress(CmdKey.F0005);
                }
            }
        }

#endregion
        private void FileManager_CancelClick(object sender, EventArgs e)
        {
            if (funPanel.Visible || fileOpera != FileOpera.None)
            {
                funPanel.Visible = false;
                fileOpera = FileOpera.None;
            }
            else
            {
                if (this.Parent != null)
                {
                    this.ParentForm.OnCancelClick();
                }
            }
        }

        private void FileManager_ConfirmClick(object sender, EventArgs e)
        {
            switch (FileStyle)
            {
                case FileStyle.Dress://磨刀文件
                    {

                    }
                    break;
                case FileStyle.Log://日志文件
                    {

                    }
                    break;
                default://划切文件
                    {
                        if (selectFileName.Tag == null)
                        {
                            Common.ReportCmdKeyProgress(CmdKey.F0001);
                            return;
                        }
                        if (!string.IsNullOrWhiteSpace(selectFileName.Tag.ToString()))
                        {
                            CutDataManager manager = new CutDataManager();
                            manager.FilePath = selectFileName.Tag.ToString();
                            Common.ReportCmdKeyProgress(CmdKey.F0019);
                            ParentForm.PushChildForm(manager);
                        }
                        else
                        {
                            if (File.Exists(usedFileFullName))
                            {
                                CutDataManager manager = new CutDataManager();
                                manager.FilePath = usedFileFullName;
                                Common.ReportCmdKeyProgress(CmdKey.F0019);
                                ParentForm.PushChildForm(manager);
                            }
                            else
                            {
                                Common.ReportCmdKeyProgress(CmdKey.F0001);
                            }
                        }
                    }
                    break;
            }

        }

        private void FileManager_NextClick(object sender, EventArgs e)
        {
            if (selectFileName.Tag == null)
            {
                Common.ReportCmdKeyProgress(CmdKey.F0001);
                return;
            }
            string usedName = selectFileName.Tag.ToString();
            if (File.Exists(usedName) && !usedName.Equals(usedFileFullName))//当前文件存在 且不与选中文件相等
            {
                usedFileFullName = selectFileName.Tag.ToString();
                Globals.AppCfg.CutFileName = usedName.Replace(Globals.AppCfg.CutFilePath, string.Empty);
                curCuttingFileName.Text = Globals.AppCfg.CutFileNameWithoutExtension;
                Globals.AppCfg.SaveDefaultSysConfigFile();
                if (File.Exists(Globals.AppCfg.CutFileFullName))
                {
                    Globals.Group = Serialize.XmlDeSerialize<CutGroup>(File.ReadAllText(Globals.AppCfg.CutFileFullName));   //加载划切文件
                    Common.ReportCmdKeyProgress(CmdKey.F0020);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0015);
                }
            }
        }

        private void FileListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = fileListView.Columns[e.ColumnIndex].Width;
        }
    }

    public enum FileStyle
    {
        Single = 0x00,//标准单通道
        Stand = 0x01, //标准双通道
        AnyCh = 0x02, //任意通道
        MulStep = 0x03, //通道多步距
        QFN = 0x04,     //QFN
        PreCut = 0x05,  //预划切
        CutFile = 0x0F, //通道多步距
        Dress = 0x10,   //磨刀
        Log = 0x20      //日志
    }

    public enum FileOpera
    {
        None = 0,
        CreatFile = 1,
        CopyFile = 2,
        Rename = 3,
        DeleteFile = 4,
        CreateFolder = 5,
        DeleteFolder = 6,
    }
}
