using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using QSHP.Properties;
using System.ComponentModel;

namespace QSHP.UI.Ctr
{
    [ToolboxItem(true)]
    public class TreeViewEx : TreeView
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public Image CollapseImage
        {
            get;
            set;
        }
        public Image ExpandImage
        {
            get;
            set;
        }
        public TreeViewEx()
        {
            treeView1 = this;
            treeView1.HotTracking = true;
            treeView1.HideSelection = false;
            treeView1.SelectedImageIndex = treeView1.ImageIndex;
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.treeView1.FullRowSelect = true;
            this.treeView1.ShowLines = false;
            this.treeView1.DrawMode = TreeViewDrawMode.Normal;
            if (CollapseImage == null)
            {
                this.CollapseImage = Resources.CollapseImage;
            }
            if (ExpandImage == null)
            {
                this.ExpandImage = Resources.ExpandImage;
            }

            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
        }

        #region DrawNode


        public bool ShowBootImage { get; set; }
        /*1节点被选中 ,TreeView有焦点*/
        private SolidBrush brush1 = new SolidBrush(Color.FromArgb(209, 232, 255));//填充颜色
        private Pen pen1 = new Pen(Color.FromArgb(102, 167, 232), 1);//边框颜色

        /*2节点被选中 ,TreeView没有焦点*/
        private SolidBrush brush2 = new SolidBrush(Color.FromArgb(247, 247, 247));
        private Pen pen2 = new Pen(Color.FromArgb(222, 222, 222), 1);
        private Pen pen4 = new Pen(Color.FromArgb(150, 200, 200), 1);
        /*3 MouseMove的时候 画光标所在的节点的背景*/
        private SolidBrush brush3 = new SolidBrush(Color.FromArgb(229, 243, 251));
        private Pen pen3 = new Pen(Color.FromArgb(112, 192, 231), 1);

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            #region 1     选中的节点背景=========================================
            Rectangle nodeRect = new Rectangle(1,
                                                e.Bounds.Top + 1,
                                                e.Bounds.Width - 3,
                                                e.Bounds.Height - 2);

            if (e.Node.IsSelected)
            {
                //TreeView有焦点的时候 画选中的节点
                if (treeView1.Focused)
                {
                    e.Graphics.FillRectangle(brush1, nodeRect);
                    e.Graphics.DrawRectangle(pen1, nodeRect);
                }
                /*TreeView失去焦点的时候 */
                else
                {
                    e.Graphics.FillRectangle(brush2, nodeRect);
                    e.Graphics.DrawRectangle(pen2, nodeRect);
                }
            }
            else if ((e.State & TreeNodeStates.Hot) != 0 && e.Node.Text != "")//|| currentMouseMoveNode == e.Node)
            {
                e.Graphics.FillRectangle(brush3, nodeRect);
                e.Graphics.DrawRectangle(pen3, nodeRect);
            }
            else
            {
                if (e.Node.BackColor.Name != "0")
                {
                    e.Graphics.FillRectangle(new SolidBrush(e.Node.BackColor), e.Bounds);
                    if (e.Node.Parent == null)
                        e.Graphics.DrawRectangle(pen4, nodeRect);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(treeView1.BackColor), e.Bounds);
                    if (e.Node.Parent == null)
                        e.Graphics.DrawRectangle(pen4, nodeRect);
                }
            }
            #endregion

            #region 2     画节点文本=========================================
            int xLeft = e.Node.Bounds.Left;
            Rectangle nodeTextRect = new Rectangle(
                                                    xLeft+24,
                                                    e.Node.Bounds.Top + 2,
                                                    e.Node.Bounds.Width + 2,
                                                    e.Node.Bounds.Height
                                                    );
            nodeTextRect.Width += 4;
            nodeTextRect.Height -= 4;

            if (e.Node.ForeColor.Name != "0")
            {
                e.Graphics.DrawString(e.Node.Text,
                                      e.Node.TreeView.Font,
                                      new SolidBrush(e.Node.ForeColor),
                                      nodeTextRect);
            }
            else
            {
                e.Graphics.DrawString(e.Node.Text,
                                      e.Node.TreeView.Font,
                                      new SolidBrush(Color.Black),
                                      nodeTextRect);
            }
            //画子节点个数 (111)
            if (e.Node.Nodes.Count > 0)
            {
                e.Graphics.DrawString(string.Format("({0})", e.Node.GetNodeCount(true)),
                                        new Font("Arial", 8),
                                        Brushes.Gray,
                                        nodeTextRect.Right - 4,
                                        nodeTextRect.Top + 2);
            }

            #endregion

            #region 3   画IImageList 中的图标===================================================================

            int currt_X = e.Node.Bounds.X;
            if (e.Node.Parent != null || ShowBootImage)
            {
                if (treeView1.ImageList != null && treeView1.ImageList.Images.Count > 0)
                {
                    //图标大小16*16
                    int x = e.Node.Bounds.Left;
                    Rectangle imagebox = new Rectangle(
                        x+3,
                        e.Node.Bounds.Y + (treeView1.ItemHeight- treeView1.ImageList.ImageSize.Height)/2,
                        treeView1.ImageList.ImageSize.Width,//IMAGELIST IMAGE WIDTH
                        treeView1.ImageList.ImageSize.Height);//HEIGHT
                    int index = e.Node.ImageIndex;
                    string imagekey = e.Node.ImageKey;
                    if (imagekey != "" && treeView1.ImageList.Images.ContainsKey(imagekey))
                    {
                        e.Graphics.DrawImage(treeView1.ImageList.Images[imagekey], imagebox);
                    }
                    else
                    {
                        if (e.Node.ImageIndex < 0)
                            index = 0;
                        else if (index > treeView1.ImageList.Images.Count - 1)
                            index = 0;
                        e.Graphics.DrawImage(treeView1.ImageList.Images[index], imagebox);
                    }
                    currt_X -= 19;
                }
            }
            #endregion

            #region 4  展开收缩图标绘制=========================================
            int i = 18;
            Rectangle plusRect = new Rectangle(e.Node.Bounds.Left - i, nodeRect.Top + 7, this.ExpandImage.Width, this.ExpandImage.Height); // +-号的大小 是9 * 9
            Rectangle plusRect1 = new Rectangle(e.Node.Bounds.Left - i, nodeRect.Top + 7, this.CollapseImage.Width, this.CollapseImage.Height);
            if (e.Node.TreeView.ShowPlusMinus)
            {
                if (e.Node.IsExpanded && this.ExpandImage != null)
                    e.Graphics.DrawImage(this.ExpandImage, plusRect);
                else if (e.Node.IsExpanded == false && e.Node.Nodes.Count > 0 && this.CollapseImage != null)
                    e.Graphics.DrawImage(this.CollapseImage, plusRect1);
            }
            #endregion
        }
        #endregion

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node != null)
            {
                //禁止选中空白项
                if (e.Node.Text == "")
                {
                    //响应上下键
                    if (ArrowKeyUp)
                    {
                        if (e.Node.PrevNode != null && e.Node.PrevNode.Text != "")
                            treeView1.SelectedNode = e.Node.PrevNode;
                    }

                    if (ArrowKeyDown)
                    {
                        if (e.Node.NextNode != null && e.Node.NextNode.Text != "")
                            treeView1.SelectedNode = e.Node.NextNode;
                    }

                    e.Cancel = true;
                }
            }
        }
        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            ArrowKeyUp = (e.KeyCode == Keys.Up);
            if (e.KeyCode == Keys.Down)
            {
                Text = "Down";
            }

            ArrowKeyDown = (e.KeyCode == Keys.Down);
            if (e.KeyCode == Keys.Up)
            {
                Text = "UP";
            }

        }
        private bool ArrowKeyUp = false;
        private bool ArrowKeyDown = false;
        private TreeView treeView1;
    }

}
