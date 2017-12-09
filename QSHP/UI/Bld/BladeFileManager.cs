using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QSHP.Data;

namespace QSHP.UI.Bld
{
    public partial class BladeFileManager : BaseForm
    {
        private Dictionary<string, Data.BldData> bldDataList = new Dictionary<string, Data.BldData>();
        List<string> filePath = new List<string>();

        public BladeFileManager()
        {
            InitializeComponent();
        }

        private void BladeFileManager_Load(object sender, EventArgs e)
        {
            pathView.Nodes.Clear();
            ParserBladeFileToList();
            bkWorker.RunWorkerAsync();
        }

        private void ParserBladeFileToList()
        {

            string s = string.Empty;
            string ys = string.Empty;
            string ms = string.Empty;
            string fs = string.Empty;
            filePath.AddRange(Directory.GetFiles(Globals.AppCfg.BladeFilePath, "*.drs", SearchOption.AllDirectories));
            foreach (var item in filePath)
            {
                s = Path.GetFileNameWithoutExtension(item);
                ys = s.Substring(0, 6);
                ms = s.Substring(6, 2);
                fs = s.Substring(8);
                if (!pathView.Nodes.ContainsKey(ys))
                {
                    pathView.Nodes.Add(ys, ys).ImageIndex = 0;
                }
                TreeNode node = pathView.Nodes[ys];
                node.Tag = ys;
                if (!node.Nodes.ContainsKey(ms))
                {
                    TreeNode p = node.Nodes.Add(ms, ms);
                    p.ImageIndex = 1;
                    p.Tag = s.Substring(0, 8);
                }
                TreeNode n = node.Nodes[ms].Nodes.Add(fs, fs);
                n.Tag = s;
                n.ImageIndex = 2;
            }
            foreach (TreeNode item in pathView.Nodes)
            {
                item.Expand();
            }
        }

        private void BladeFileManager_BT0Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bldDataList.Values.ToArray<BldData>();
            tabControlEx1.SelectedIndex = 3;
            chart1.Series[0].Points.Clear();
            int c = bldDataList.Values.Where(v => v.ReplaceReason == 0).Count();
            chart1.Series[0].Points.AddXY(0,c );
            if (c != 0)
            {
                chart1.Series[0].Points[0].Label = "新刀";
            }
            c = bldDataList.Values.Where(v => v.ReplaceReason == 1).Count();
            chart1.Series[0].Points.AddXY(1, c);
            if (c != 0)
            {
                chart1.Series[0].Points[0].Label = "刀具破损";
            }
            c = bldDataList.Values.Where(v => v.ReplaceReason == 2).Count();
            chart1.Series[0].Points.AddXY(2, c);
            if (c != 0)
            {
                chart1.Series[0].Points[0].Label = "磨损超标";
            }
            c = bldDataList.Values.Where(v => v.ReplaceReason == 3).Count();
            chart1.Series[0].Points.AddXY(3, c);
            if (c != 0)
            {
                chart1.Series[0].Points[0].Label = "刀数超标";
            }
            c = bldDataList.Values.Where(v => v.ReplaceReason == 4).Count();
            chart1.Series[0].Points.AddXY(4, c);
            if (c != 0)
            {
                chart1.Series[0].Points[0].Label = "崩边过大";
            }
            c = bldDataList.Values.Where(v => v.ReplaceReason == 5).Count();
            chart1.Series[0].Points.AddXY(5, c);
            if (c != 0)
            {
                chart1.Series[0].Points[0].Label = "其他";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string s = string.Empty;

            foreach (var item in filePath)
            {
                s = Path.GetFileNameWithoutExtension(item);
                BldData d = Serialize.XmlDeSerialize<BldData>(File.ReadAllText(item));
                bldDataList.Add(s, d);
            }
        }

        private void pathView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.ImageIndex)
            {
                case 0:
                    {
                        if (e.Node.Tag != null)//显示当年刀具信息
                        {
                            tabControlEx1.SelectedIndex = 1;
                        }
                    }
                    break;
                case 1:
                    {
                        if (e.Node.Tag != null)//显示当月刀具信息
                        {
                            tabControlEx1.SelectedIndex = 2;
                        }
                    }
                    break;
                case 2:
                    {
                        if (e.Node.Tag != null)//显示当前刀具信息
                        {
                            BldData d = bldDataList[e.Node.Tag.ToString()];
                            this.bldDataBindingSource.DataSource = d;
                            //bldModel.Text = d.BldModel;
                            //bldType.SelectedIndex = d.BldType;
                            //bldDiameter.Text = d.BldDiameter.ToString();
                            //bldTickness.Text = d.BldTickness.ToString();
                            //bldTime.Text = d.ReplaceTime.ToString("yyyy/MM/dd HH:mm:ss");
                            //testHeightTick.Text = d.TestTick.ToString();
                            //testHeight.Text = d.TestHeightValue.ToString();
                            //bldLouchuValue.Text = d.SafetyMargin.ToString();
                            //piecesCut.Text = d.PieceAfterReplace.ToString();
                            //linesCut.Text = d.LinesAfterReplace.ToString();
                            //repalceResult.SelectedIndex = d.ReplaceReason;
                            //lengthCut.Text = d.LenAfterReplace.ToString();
                            //lossValue.Text = d.BldLossAfterRepalce.ToString();
                            //bldLouValue.Text = d.BldRemainder.ToString("0.###");
                            tabControlEx1.SelectedIndex = 0;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
