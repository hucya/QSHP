using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.UI.Ctr;
using QSHP.Com;
using QSHP.HW;

namespace QSHP.UI
{
    public partial class SystemIOControlManager : BaseForm
    {
        Font textFont = new Font("微软雅黑",12F);
        Color enForeColor = Color.Yellow;
        Color diForeColor = Color.White;
        Color enBkColor = Color.Red;
        Color diBkColor = Color.Green;
        uint inputValue;
        uint outputValue;
        ButtonEx[] opBtList = new ButtonEx[32];
        ButtonEx[] ipBtList = new ButtonEx[32];
        bool update = false;
        int ioCount = 32;
        public SystemIOControlManager()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                LoadDefaultForm(Globals.MajorIO);
                update = true;
            }

        }

        private void LoadDefaultForm(bool larger = true)
        {
            int max = larger ? 4 : 2;
            ioCount = max*8;
            this.inputPannel.RowStyles.Clear();
            this.inputPannel.ColumnStyles.Clear();
            this.outPutPannel.RowStyles.Clear();
            this.outPutPannel.ColumnStyles.Clear();

            this.inputPannel.ColumnCount = 8;
            this.inputPannel.RowCount = max;
            this.outPutPannel.ColumnCount = 8;
            this.outPutPannel.RowCount = max;
            
            for (int i = 0; i < 8; i++)
            {
                this.outPutPannel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
                this.inputPannel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            }
            for (int j = 0; j < max; j++)
            {
                this.outPutPannel.RowStyles.Add(new RowStyle(SizeType.Percent, 100/max));
                this.inputPannel.RowStyles.Add(new RowStyle(SizeType.Percent, 100/max));
            }
            int m = 0;
            int n = 0;
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    n= i * 8 + j;
                    m = Common.DO.IOList[n];
                    ButtonEx bt = new ButtonEx();
                    bt.Name = string.Format("BT{0}",n);
                    bt.Text = DoDefine.DOList[n];
                    bt.Flag = m;
                    bt.Dock = DockStyle.Fill;
                    bt.Font = textFont;
                    bt.Enabled = Common.DO.Used.Bit(m);
                    outputValue = Common.DO.Status;
                    if (bt.Enabled)
                    {
                        bt.Click += Bt_Click;
                        bool flag = Common.DO.Status.Bit(m);
                        bt.BackColor = flag ? enBkColor : diBkColor;
                        bt.ForeColor = flag ? enForeColor : diForeColor;
                    }
                    this.outPutPannel.Controls.Add(bt, j, i);
                    opBtList[m]=bt;

                    ButtonEx it = new ButtonEx();
                    m = Common.DI.IOList[n];
                    it.Name = string.Format("In{0}", n);
                    it.Text = DiDefine.DIList[n];
                    it.Flag = m;
                    it.FlatStyle = FlatStyle.Flat;
                    it.FlatAppearance.BorderSize = 0;
                    it.Dock = DockStyle.Fill;
                    it.Font = textFont;
                    it.Enabled = Common.DI.Used.Bit(m);
                    inputValue = Common.DI.Status;
                    if (it.Enabled)
                    {
                        bool flag = Common.DI.Status.Bit(m);
                        it.BackColor = flag ? enBkColor : diBkColor;
                        it.ForeColor = flag ? enForeColor : diForeColor;
                    }
                    this.inputPannel.Controls.Add(it, j, i);
                    ipBtList[m]=it;
                }
            }
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            ButtonEx bt = sender as ButtonEx;
            if (bt != null)
            {
                if (Common.DO != null)
                {
                    Common.DO[bt.Flag] = !Common.DO[bt.Flag];
                    //bool flag = Common.DO[bt.Flag];
                    //bt.BackColor = flag ? enBkColor : diBkColor;
                    //bt.ForeColor = flag ? enForeColor : diForeColor;
                }
            }
        }
        private void SystemIOControlManager_AutoUpdateEventHander(object sender, EventArgs e)
        {
            if (update)
            {
                uint input = Common.DI.Status;
                uint output = Common.DO.Status;
                int n = 0;
                if (inputValue != input)
                {
                    UInt32 v = inputValue ^ input;
                    for (int i = 0; i < ioCount; i++)
                    {
                        n = Common.DI.IOList[i];
                        if (v.Bit(n))
                        {
                            bool flag = input.Bit(n);
                            ipBtList[n].BackColor = flag ? enBkColor : diBkColor;
                            ipBtList[n].ForeColor = flag ? enForeColor : diForeColor;
                        }
                    }
                    inputValue = input;
                }
                if (outputValue != output)
                {
                    UInt32 v = outputValue ^ output;
                    
                    for (int i = 0; i < ioCount; i++)
                    {
                        n = Common.DO.IOList[i];
                        if (v.Bit(n))
                        {
                            bool flag = output.Bit(n);
                            opBtList[n].BackColor = flag ? enBkColor : diBkColor;
                            opBtList[n].ForeColor = flag ? enForeColor : diForeColor;
                        }
                    }
                    outputValue = output;
                }
            }
        }
    }
}
