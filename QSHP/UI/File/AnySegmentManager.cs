using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.Data;
using QSHP.UI.User;

namespace QSHP.UI
{
    public partial class AnySegmentManager : BaseForm
    {
        bool saved = false;
        CutChip chip;
        CutChannel ch;
        bool repair = true;
        int startCount = 1;
        List<SegmentCtr> ctrs = new List<SegmentCtr>();
        bool load = false;
        //public AnySegmentManager()
        //{
        //    InitializeComponent();
        //}
        public AnySegmentManager(CutChip c,bool re=true)
        {
            InitializeComponent();
            chip = c;
            repair = re;
            panelEx1.Enabled = repair;
            if (!DesignMode)
            {
                ctrs.Add(segmentCtr1);
                ctrs.Add(segmentCtr2);
                ctrs.Add(segmentCtr3);
                ctrs.Add(segmentCtr4);
                ctrs.Add(segmentCtr5);
                ctrs.Add(segmentCtr6);
                ctrs.Add(segmentCtr7);
                ctrs.Add(segmentCtr8);
                ctrs.Add(segmentCtr9);
                ctrs.Add(segmentCtr10);
                LoadChipDataValue(chip);
            }
        }
        private void AnySegmentManager_ConfirmClick(object sender, EventArgs e)
        {
            if (CheckSegmentDataIsValid())
            {
                saved = true;
                CutDataManager.saved = true;
                Common.ReportCmdKeyProgress(CmdKey.F0038);
            }
            else
            {
                if (!ctrs[0].Enabled)
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0042);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0044);
                }
            }
        }
        private bool CheckSegmentDataIsValid()
        {
            bool flag = true;
            foreach (var item in ctrs)
            {
                flag &= item.CheckChannelDataIsValid();
            }
            if (!ctrs[0].Enabled)
            {
                flag = false;
            }
            return flag;
        }

        private void AnySegmentManager_CancelClick(object sender, EventArgs e)
        {
            if (repair& saved)
            {
                SaveChannelDataValue(ch);//保存当前通道值
                RemoveUnValidData();//移除无效的通道
            }
            else
            {
                RemoveUnValidData(false);//移除无效控件到进入时候的状态 
            }
            for (int i = 0; i < 4; i++)
            {
                this.UnderBar.BtList[i].Enabled = true;
            }
            ParentForm.OnCancelClick();
        }

        private void LoadChannelDataValue(CutChannel c,bool load=true)
        {
            saved = false;
            for (int i = c.Segs.Count; i < 10; i++)
            {
                CutSegment s = new CutSegment();
                s.Enable = false;
                c.Add(s);
            }
            if (load)
            {
                ch = c;
                chIndex.SelectedIndex = c.Index;
                yOffset.Value = c.YPosAdj;
                tOffset.Value = c.TPosAdj;
                tStartPos.Value = c.TRoatePos;
                cycTicks.Value = c.CycleCount;
                pauseLine.Value = c.PauseTick;
                pauseMode.SelectedIndex = c.PauseMode;
                cutDir.SelectedIndex = (int)c.Style;
                for (int i = 0; i < 10; i++)
                {
                    ctrs[i].Seg = c.Segs[i];
                }
            }
        }

        private void LoadChipDataValue(CutChip ch)
        {
            startCount = ch.Count;
            if (startCount < 2)
            {
                startCount = 2;
            }
            if (ch.Count < channelNum.Items.Count)
            {
                channelNum.SelectedIndex = ch.Count - 1;
            }
            else
            {
                channelNum.SelectedIndex = 3;
            }
            for (int i = ch.Count; i < channelNum.Items.Count; i++)
            {
                CutChannel c = new CutChannel();
                c.Enable = false;
                LoadChannelDataValue(c,false);
                ch.Add(c);
            }
            LoadChannelDataValue(ch[0]);
        }

        private void SaveChannelDataValue(CutChannel c)
        {
            c.Enable = true;
            c.YPosAdj = yOffset.Value;
            c.TPosAdj = tOffset.Value;
            c.TRoatePos = tStartPos.Value;
            c.CycleCount = cycTicks.Int;
            c.PauseTick = pauseLine.Int;
            c.PauseMode = pauseMode.SelectedIndex;
            c.Style = (CutStyle)cutDir.SelectedIndex;
            foreach (var item in ctrs)
            {
                item.SaveCutSegmentData();
            }
        }

        private void RemoveUnValidData(bool repair=true)
        {
            if(repair)//是否进行修改
            {
                while (channelNum.SelectedIndex < chip.Count - 1)//删除多余的通道
                {
                    chip.CHs.RemoveAt(chip.Count - 1);
                }
            }
            else
            {
                while(chip.CHs.Count>startCount)//移除新添加的通道
                {
                    chip.CHs.RemoveAt(chip.Count - 1);
                }
            }
            foreach (var item in chip.CHs)//删除所有不使能的Segment
            {
                item.Segs.RemoveAll(s => s.Enable == false);
            }
        }

        private void SegmentCtr_UserEnabledChanged(object sender, EventArgs e)
        {
            SegmentCtr s = sender as SegmentCtr;
            if (s != null)
            {
                foreach (var item in ctrs)
                {
                    if (s.Enabled)
                    {
                        if (item.SegIndex < s.SegIndex)
                        {
                            item.Enabled = true;
                        }
                    }
                    else
                    {
                        if (item.SegIndex > s.SegIndex)
                        {
                            item.Enabled = false;
                        }
                    }
                }
            }
        }

        private void AnySegmentManager_BT5Click(object sender, EventArgs e)
        {
            foreach (var item in ctrs)
            {
                item.ClearCutSegmentData();
            }
            Common.ReportCmdKeyProgress(CmdKey.F0039);
        }

        private void SetCurrentChannel(CutChannel c)
        {
            channelNum.Enabled = c.Index == 0;
            if (c.Index <= channelNum.SelectedIndex)
            {
                if (ch != c)
                {
                    if (repair & saved)
                    {
                        SaveChannelDataValue(ch);
                    }
                    LoadChannelDataValue(c);
                }
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.F0046);
            }
        }
        private void AnySegmentManager_BT0Click(object sender, EventArgs e)
        {
            SetCurrentChannel(chip[0]);
        }

        private void AnySegmentManager_BT1Click(object sender, EventArgs e)
        {
            SetCurrentChannel(chip[1]);
        }

        private void AnySegmentManager_BT2Click(object sender, EventArgs e)
        {
            SetCurrentChannel(chip[2]);
        }

        private void AnySegmentManager_BT3Click(object sender, EventArgs e)
        {
            SetCurrentChannel(chip[3]);
        }

        private void ChannelNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (load)
            {
                for (int i = 0; i < 4; i++)
                {
                    bool flag = i <= channelNum.SelectedIndex;
                    this.UnderBar.BtList[i].Enabled = flag;
                    if (chip != null)
                    {
                        chip.CHs[i].Enable = flag;
                    }
                }
                if (ch != null && ch.Index > channelNum.SelectedIndex)//超出当前值
                {
                    LoadChannelDataValue(chip.CHs[channelNum.SelectedIndex]);//加载当前的最后一项
                }
            }
            
        }

        public override bool FormLoadReady()
        {
            load = true;
            return base.FormLoadReady();
        }

        private void AnySegmentManager_Load(object sender, EventArgs e)
        {
            ChannelNum_SelectedIndexChanged(this, null);
        }
    }
}
