using QSHP.Data;
using QSHP.UI.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI
{
    public partial class AnyChannelManager : BaseForm
    {
        List<ChannelCtrList> ctrs = new List<ChannelCtrList>();
        CutChip chip = new CutChip();
        bool rePair = true;
        bool saved = false;
        public AnyChannelManager()
        {
            InitializeComponent();
        }
        public AnyChannelManager(CutChip c,bool re=true)
        {
            InitializeComponent();
            this.Enabled = re;
            rePair = re;
            if (c != null)
            {
                chip = c;
            }
        }
        private void LoadCutChipData(CutChip c)
        {
            ctrs.Add(channelCtrList1);
            ctrs.Add(channelCtrList2);
            ctrs.Add(channelCtrList3);
            ctrs.Add(channelCtrList4);
            ctrs.Add(channelCtrList5);
            ctrs.Add(channelCtrList6);
            ctrs.Add(channelCtrList7);
            ctrs.Add(channelCtrList8);
            ctrs.Add(channelCtrList9);
            ctrs.Add(channelCtrList10);
            for (int i = c.Count; i < 10; i++)//增加模板
            {
                CutChannel ch = new CutChannel();
                ch.Enable = false;
                c.Add(ch);
            }
            for (int i = 0; i < 10; i++)
            {
                ctrs[i].CH = c.CHs[i];
            }

        }

        private void ChannelCtrList_UserEnabledChanged(object sender, EventArgs e)
        {
            ChannelCtrList c = sender as ChannelCtrList;
            if (c != null)
            {
                foreach (var item in ctrs)
                {
                    if (c.Enabled)
                    {
                        if (item.CHIndex < c.CHIndex)
                        {
                            item.Enabled = true;
                        }
                    }
                    else
                    {
                        if (item.CHIndex > c.CHIndex)
                        {
                            item.Enabled = false;
                        }
                    }
                }
            }
        }

        private void AnyChannelManager_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadCutChipData(chip);
            }
        }

        private void AnyChannelManager_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                foreach (var item in ctrs)
                {
                    if (!item.Enabled)
                    {
                        chip.CHs.Remove(item.CH);
                    }
                    else
                    {
                        item.SaveCutChannelData();//保存当前数据
                    }
                }
            }
            if (this.ParentForm != null)
            {
                this.ParentForm.OnCancelClick();
            }
        }

        private void AnyChannelManager_ConfirmClick(object sender, EventArgs e)
        {
            if (CheckChannelDataIsValid())
            {
                saved = true;
                CutDataManager.saved = true;
                Common.ReportCmdKeyProgress(CmdKey.F0036);
            }
            else
            {
                if (!channelCtrList1.Enabled)//需要最少使能一个通道
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0043);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0044);
                }
            }
        }
        private bool CheckChannelDataIsValid()
        {
            bool flag = true;
            foreach (var item in ctrs)
            {
                flag &= item.CheckChannelDataIsValid();
            }
            if (!channelCtrList1.Enabled)//需要最少使能一个通道
            {
                flag = false;
            }
            return flag;
        }
        private void AnyChannelManager_BT0Click(object sender, EventArgs e)
        {
            foreach (var item in ctrs)
            {
                item.ClearCutChannelData();
            }
            Common.ReportCmdKeyProgress(CmdKey.F0037);
        }
    }
}
