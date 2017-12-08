using QSHP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI
{
    public partial class CutDataManager : BaseForm
    {
        CutGroup cutGroupData;
        string filePath = string.Empty;
        bool rePair = true;
        public static bool saved = false;
        bool load = false;
        public CutGroup CutGroupData
        {
            get
            {
                return cutGroupData;
            }
            set
            {
                cutGroupData = value;
                if (value != null)
                {
                    LoadCutGroupData(cutGroupData);
                }
            }
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }

            set
            {
                filePath = value;
                if (File.Exists(filePath))
                {
                    CutGroupData = Data.Serialize.XmlDeSerialize<Data.CutGroup>(File.ReadAllText(filePath));
                }
            }
        }

        public bool RePair
        {
            get
            {
                return rePair;
            }

            set
            {
                rePair = value;
                if (!value)
                {
                    FmStyle = FormStyle.Cancel;
                }
                panelEx1.Enabled = rePair;
            }
        }

        public CutDataManager()
        {
            InitializeComponent();
        }

        private void PreCutDataButtonClick(object sender, EventArgs e)
        {
            PreCutDataManager manager = new PreCutDataManager(cutGroupData.PreCut, rePair);
            this.ParentForm.PushChildForm(manager, rePair);
        }

        private void AnyStepButtonClick(object sender, EventArgs e)
        {
            if (cutModeList.SelectedIndex == 2)
            {
                AnySegmentManager manager = new AnySegmentManager(cutGroupData, rePair);
                this.ParentForm.PushChildForm(manager, rePair);
            }
            else
            {

            }
        }

        private void AnyChButtonClick(object sender, EventArgs e)
        {
            if (cutModeList.SelectedIndex == 3)
            {
                AnyChannelManager manager = new AnyChannelManager(cutGroupData, rePair);
                this.ParentForm.PushChildForm(manager, rePair);
            }
            else
            {

            }
        }

        private void QFNButtonClick(object sender, EventArgs e)
        {

        }

        private void CutDataManager_CancelClick(object sender, EventArgs e)
        {
            if (tabControlEx1.SelectedIndex == 0)
            {
                if (saved)
                {
                    SaveCutGroupData();
                    if (rePair && File.Exists(FilePath))
                    {
                        string s = Data.Serialize.XmlSerialize(CutGroupData);
                        File.WriteAllText(FilePath, s);
                        if (FilePath == Globals.AppCfg.CutFileFullName)
                        {
                            Globals.Group = CutGroupData;
                        }
                    }
                    saved = false;
                } 
                if(this.ParentForm!=null)
                {
                    ParentForm.OnCancelClick();
                }
            }
            else
            {
                if (tabControlEx1.SelectedIndex == 1)
                {
                    tabControlEx1.SelectedIndex = 0;
                    BT4Content = "高级参数";
                }
            }
        }

        private void ExDataButtonClick(object sender, EventArgs e)
        {
            if (tabControlEx1.SelectedIndex == 0)
            {
                tabControlEx1.SelectedIndex = 1;
                BT4Content = "基本参数";
            }
            else
            {
                tabControlEx1.SelectedIndex = 0;
                BT4Content = "高级参数";
            }
        }

        private void WpShapeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wpShapeList.SelectedIndex == 0)
            {
                wpWidthEdit.Enabled = false;
                label29.Text = "工件直径: ";
            }
            else
            {
                label29.Text = "工件长度: ";
                wpWidthEdit.Enabled = true;
            }
            WpLengthEdit_ValueChanged(null, null);
        }

        private void RepairModeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (exitPos.SelectedIndex == 3)
            {
                xExitPosEdit.Enabled = true;
                tExitPosEdit.Enabled = true;
                yExitPosEdit.Enabled = true;
            }
            else
            {
                xExitPosEdit.Enabled = false;
                tExitPosEdit.Enabled = false;
                yExitPosEdit.Enabled = false;
            }
        }

        private void CutDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CutGroupData != null)
            {
                this.CutGroupData.CutDir = (CutDir)cutDir.SelectedIndex;
            }
        }

        private void CutModeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CutGroupData != null)
            {
                this.CutGroupData.CutMode = (CutMode)cutModeList.SelectedIndex;
            }
            if (cutModeList.SelectedIndex == 0)
            {
                channelCtr1.Enabled = true;
                channelCtr2.Enabled = false;
            }
            else if (cutModeList.SelectedIndex == 1)
            {
                channelCtr1.Enabled = true;
                channelCtr2.Enabled = true;
            }
            else
            {
                channelCtr1.Enabled = false;
                channelCtr2.Enabled = false;
            }
        }

        private void CutDataManager_ConfirmClick(object sender, EventArgs e)
        {
            if (rePair)
            {
                saved = CheckVauleIsValid();
                if (saved)
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0031);
                }
            }
        }

        private bool CheckVauleIsValid()
        {
            bool flag = true;
            if (spdSpeedEdit.Value > 60000 || spdSpeedEdit.Value < 3000)
            {
                Common.ReportCmdKeyProgress(CmdKey.F0026);
                spdSpeedEdit.SetError = true;
                flag &= false;
            }
            if (leaveEdit.Value <= secLeaveEdit.Value && secLeaveEdit.Value != 0)//一次预留小于二次预留值
            {
                Common.ReportCmdKeyProgress(CmdKey.F0027);
                leaveEdit.SetError = true;
                secLeaveEdit.SetError = true;
                flag &= false;
            }
            if (secLeaveEdit.Value > wpTicknessEdit.Value + firmTicknessEdit.Value + 0.5)//落刀位置小于抬刀位置
            {
                Common.ReportCmdKeyProgress(CmdKey.F0028);
                secLeaveEdit.SetError = false;
                flag &= false;
            }
            if (leaveEdit.Value > wpTicknessEdit.Value + firmTicknessEdit.Value + 0.5)//落刀位置小于抬刀位置
            {
                Common.ReportCmdKeyProgress(CmdKey.F0028);
                leaveEdit.SetError = false;
                flag &= false;
            }
            if (channelCtr1.Enabled)
            {
                flag &= channelCtr1.CheckValueIsValid();
            }
            if (channelCtr2.Enabled)
            {
                flag &= channelCtr2.CheckValueIsValid();
            }
            return flag;
        }

        private void WpLengthEdit_ValueChanged(object sender, EventArgs e)
        {
            if (load& cutModeList.SelectedIndex<2)
            {
                if (wpShapeList.SelectedIndex == 0)//圆形
                {
                    wpWidthEdit.Value = wpLengthEdit.Value;
                    cutGroupData.Width = wpLengthEdit.Value;
                    WpWidthEdit_ValueChanged(null, null);
                }
                channelCtr2.Length = wpLengthEdit.Value;
            }
        }

        private void WpWidthEdit_ValueChanged(object sender, EventArgs e)
        {
            if (load&cutModeList.SelectedIndex <2)
            {
                channelCtr1.Length = wpWidthEdit.Value;
            }
        }

        private void LoadCutGroupData(CutGroup g)
        {
            load = false;
            channelCtr1.CH = cutGroupData.CH1;
            channelCtr2.CH = cutGroupData.CH2;
            cutDir.SelectedIndex =(int) g.CutDir;
            sideEdit.Value = g.PreWidth;
            firmTicknessEdit.Value = g.FilmHeight;
            cutModeList.SelectedIndex = (int)g.CutMode;
            leaveEdit.Value = g.ReDepth;
            secLeaveEdit.Value = g.ReDepth2;
            backSpeedEdit.Value= g.BackSpeed;
            cutOrder.SelectedIndex = g.Order ? 0 : 1;
            spdSpeedEdit.Value = g.SpdSpeed;
            wpShapeList.SelectedIndex = g.Fixed ? 1 : 0;
            wpTicknessEdit.Value = g.WorkerHeight;
            wpLengthEdit.Value = g.Length;
            wpWidthEdit.Value = g.Width;
            exitPos.SelectedIndex = g.ExitPosMode;
            xExitPosEdit.Value = g.ExitXpos;
            yExitPosEdit.Value = g.ExitYpos;
            tExitPosEdit.Value = g.ExitTpos;
            saved = false;
            Common.ReportCmdKeyProgress(CmdKey.F0025);
            load = true;
        }

        private void SaveCutGroupData()
        {
            CutGroup g = cutGroupData;
            if (g != null)
            {
                g.CutDir = (CutDir)cutDir.SelectedIndex;
                g.PreWidth = sideEdit.Value;
                g.FilmHeight = firmTicknessEdit.Value;
                g.CutMode = (CutMode)cutModeList.SelectedIndex;
                g.ReDepth = leaveEdit.Value;
                g.ReDepth2 = secLeaveEdit.Value;
                g.BackSpeed = backSpeedEdit.Value;
                g.Order = cutOrder.SelectedIndex==0;
                g.SpdSpeed=spdSpeedEdit.Int ;
                g.Fixed = wpShapeList.SelectedIndex>0;
                g.WorkerHeight = wpTicknessEdit.Value;
                g.Length = wpLengthEdit.Value;
                if (g.Fixed)
                {
                    g.Width = wpWidthEdit.Value;
                }
                else
                {
                    g.Width = wpLengthEdit.Value;
                }
                g.ExitPosMode = exitPos.SelectedIndex;
                g.ExitXpos = xExitPosEdit.Value;
                g.ExitYpos = yExitPosEdit.Value;
                g.ExitTpos = tExitPosEdit.Value;
                if (cutModeList.SelectedIndex < 2)
                {
                    channelCtr1.SaveChannelDataValue();
                    channelCtr2.SaveChannelDataValue();
                }
            }
        }
    }
}
