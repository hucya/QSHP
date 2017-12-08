using QSHP.Data;
using QSHP.UI.Ctr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.Com;
using QSHP.HW;

namespace QSHP.UI
{
    public partial class SystemDigIOConfigManager : BaseForm
    {
        Color inputColor = Color.HotPink;
        Color outputColor = Color.DodgerBlue;
        string inputText = "输入";
        string outputText = "输出";

        bool isOutPut = true;
        int showMode = 0;//0输入 1 输出 2输入 输出
        List<Label> Masks = new List<Label>();
        List<NumberEdit> IDs = new List<NumberEdit>();
        List<NumberEdit> SGs = new List<NumberEdit>();
        MacData mac;
        bool saved = false;
        public SystemDigIOConfigManager(MacData m, int mode = 2)
        {
            InitializeComponent();
            LoadDefaultControl();
            if (!DesignMode)
            {
                showMode = mode;
                mac = m;
                LoadDefaultValue(mac.IoData);
                LoadDefaultEventHander();
            }
        }

        public bool IsOutPut
        {
            get
            {
                return isOutPut;
            }

            set
            {
                isOutPut = value;
            }
        }

        private void LoadDefaultValue(IOData d)
        {
            switch (showMode)
            {
                case 0:
                    {
                        group1.Text = inputText;
                        group2.Text = inputText;
                        group3.Text = inputText;
                        group4.Text = inputText;
                        group1.ForeColor = inputColor;
                        group2.ForeColor = inputColor;
                        group3.ForeColor = inputColor;
                        group4.ForeColor = inputColor;
                        for (int i = 0; i < 32; i++)
                        {
                            Masks[i].Text = DiDefine.DIList[i];
                            IDs[i].Value = d.DiList[i];
                            if (d.DiUsed.Bit(i))
                            {
                                SGs[i].Value = d.DiMask.Bit(i) ? 1 : 0;
                            }
                            else
                            {
                                SGs[i].Value = -1;
                            }
                        }
                        this.Text = SystemDataManager.diNames;
                        this.panelEx1.Text = this.Text;
                    }
                    break;
                case 1:
                    {
                        group1.Text = outputText;
                        group2.Text = outputText;
                        group3.Text = outputText;
                        group4.Text = outputText;
                        group1.ForeColor = outputColor;
                        group2.ForeColor = outputColor;
                        group3.ForeColor = outputColor;
                        group4.ForeColor = outputColor;
                        for (int i = 0; i < 32; i++)
                        {
                            Masks[i].Text = DoDefine.DOList[i];
                            IDs[i].Value = d.DoList[i];
                            if (d.DoUsed.Bit(i))
                            {
                                SGs[i].Value = d.DoMask.Bit(i) ? 1 : 0;
                            }
                            else
                            {
                                SGs[i].Value = -1;
                            }
                        }
                        this.Text = SystemDataManager.doNames;
                        this.panelEx1.Text = this.Text;
                    }
                    break;
                case 2://输入16 输出16
                    {
                        group1.Text = inputText;
                        group2.Text = inputText;
                        group3.Text = outputText;
                        group4.Text = outputText;
                        group1.ForeColor = inputColor;
                        group2.ForeColor = inputColor;
                        group3.ForeColor = outputColor;
                        group4.ForeColor = outputColor;
                        for (int i = 0; i < 32; i++)
                        {
                            if (i < 16)
                            {
                                Masks[i].Text = DiDefine.DIList[i]; ;
                                IDs[i].Value = d.DiList[i];
                                if (d.DiUsed.Bit(i))
                                {
                                    SGs[i].Value = d.DiMask.Bit(i) ? 1 : 0;
                                }
                                else
                                {
                                    SGs[i].Value = -1;
                                }
                            }
                            else
                            {
                                int m = i - 16;
                                Masks[i].Text = DoDefine.DOList[m];
                                IDs[i].Value = d.DoList[m];
                                if (d.DoUsed.Bit(m))
                                {
                                    SGs[i].Value = d.DoMask.Bit(m) ? 1 : 0; ;
                                }
                                else
                                {
                                    SGs[i].Value = -1;
                                }
                            }
                        }
                        this.Text = SystemDataManager.ioNames;
                        this.panelEx1.Text = this.Text;
                    }
                    break;
                default:
                    break;
            }
        }

        private void SaveMacDataValue()
        {
                IOData d = mac.IoData;
                switch (showMode)
                {
                    case 0:
                        {
                            for (int i = 0; i < 32; i++)
                            {
                                d.DiList[i] = IDs[i].Int;
                                if (SGs[i].Value == 1)
                                {
                                    d.DiMask = d.DiMask.Bit(i, true);
                                    d.DiUsed = d.DiUsed.Bit(i, true);
                                }
                                else if (SGs[i].Value == 0)
                                {
                                    d.DiMask = d.DiMask.Bit(i, false);
                                    d.DiUsed = d.DiUsed.Bit(i, true);
                                }
                                else
                                {
                                    d.DiUsed = d.DiUsed.Bit(i, false);
                                }
                            }
                        }
                        break;
                    case 1:
                        {
                            for (int i = 0; i < 32; i++)
                            {
                                d.DoList[i] = IDs[i].Int;
                                if (SGs[i].Value == 1)
                                {
                                    d.DoMask = d.DoMask.Bit(i, true);
                                    d.DoUsed = d.DoUsed.Bit(i, true);
                                }
                                else if (SGs[i].Value == 0)
                                {
                                    d.DoMask = d.DoMask.Bit(i, false);
                                    d.DoUsed = d.DoUsed.Bit(i, true);
                                }
                                else
                                {
                                    d.DoUsed = d.DoUsed.Bit(i, false);
                                }
                            }
                        }
                        break;
                    case 2://输入16 输出16
                        {
                            for (int i = 0; i < 32; i++)
                            {
                                if (i < 16)
                                {
                                    d.DiList[i] = IDs[i].Int;
                                    if (SGs[i].Value == 1)
                                    {
                                        d.DiMask = d.DiMask.Bit(i, true);
                                        d.DiUsed = d.DiUsed.Bit(i, true);
                                    }
                                    else if (SGs[i].Value == 0)
                                    {
                                        d.DiMask = d.DiMask.Bit(i, false);
                                        d.DiUsed = d.DiUsed.Bit(i, true);
                                    }
                                    else
                                    {
                                        d.DiUsed = d.DiUsed.Bit(i, false);
                                    }
                                }
                                else
                                {
                                    int m = i - 16;
                                    d.DoList[m] = IDs[i].Int;
                                    if (SGs[i].Value == 1)
                                    {
                                        d.DoMask = d.DoMask.Bit(m, true);
                                        d.DoUsed = d.DoUsed.Bit(m, true);
                                    }
                                    else if (SGs[i].Value == 0)
                                    {
                                        d.DoMask = d.DoMask.Bit(m, false);
                                        d.DoUsed = d.DoUsed.Bit(m, true);
                                    }
                                    else
                                    {
                                        d.DoUsed = d.DoUsed.Bit(m, false);
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                SystemDataManager.saved = true;
        }

        private void LoadDefaultControl()
        {
            Masks.Add(N0);
            Masks.Add(N1);
            Masks.Add(N2);
            Masks.Add(N3);
            Masks.Add(N4);
            Masks.Add(N5);
            Masks.Add(N6);
            Masks.Add(N7);
            Masks.Add(N8);
            Masks.Add(N9);
            Masks.Add(N10);
            Masks.Add(N11);
            Masks.Add(N12);
            Masks.Add(N13);
            Masks.Add(N14);
            Masks.Add(N15);
            Masks.Add(N16);
            Masks.Add(N17);
            Masks.Add(N18);
            Masks.Add(N19);
            Masks.Add(N20);
            Masks.Add(N21);
            Masks.Add(N22);
            Masks.Add(N23);
            Masks.Add(N24);
            Masks.Add(N25);
            Masks.Add(N26);
            Masks.Add(N27);
            Masks.Add(N28);
            Masks.Add(N29);
            Masks.Add(N30);
            Masks.Add(N31);

            IDs.Add(ID0);
            IDs.Add(ID1);
            IDs.Add(ID2);
            IDs.Add(ID3);
            IDs.Add(ID4);
            IDs.Add(ID5);
            IDs.Add(ID6);
            IDs.Add(ID7);
            IDs.Add(ID8);
            IDs.Add(ID9);
            IDs.Add(ID10);
            IDs.Add(ID11);
            IDs.Add(ID12);
            IDs.Add(ID13);
            IDs.Add(ID14);
            IDs.Add(ID15);
            IDs.Add(ID16);
            IDs.Add(ID17);
            IDs.Add(ID18);
            IDs.Add(ID19);
            IDs.Add(ID20);
            IDs.Add(ID21);
            IDs.Add(ID22);
            IDs.Add(ID23);
            IDs.Add(ID24);
            IDs.Add(ID25);
            IDs.Add(ID26);
            IDs.Add(ID27);
            IDs.Add(ID28);
            IDs.Add(ID29);
            IDs.Add(ID30);
            IDs.Add(ID31);

            SGs.Add(S0);
            SGs.Add(S1);
            SGs.Add(S2);
            SGs.Add(S3);
            SGs.Add(S4);
            SGs.Add(S5);
            SGs.Add(S6);
            SGs.Add(S7);
            SGs.Add(S8);
            SGs.Add(S9);
            SGs.Add(S10);
            SGs.Add(S11);
            SGs.Add(S12);
            SGs.Add(S13);
            SGs.Add(S14);
            SGs.Add(S15);
            SGs.Add(S16);
            SGs.Add(S17);
            SGs.Add(S18);
            SGs.Add(S19);
            SGs.Add(S20);
            SGs.Add(S21);
            SGs.Add(S22);
            SGs.Add(S23);
            SGs.Add(S24);
            SGs.Add(S25);
            SGs.Add(S26);
            SGs.Add(S27);
            SGs.Add(S28);
            SGs.Add(S29);
            SGs.Add(S30);
            SGs.Add(S31);

        }

        private void SystemDigIOConfigManager_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveMacDataValue();
            }
            this.ParentForm.OnCancelClick();
        }

        private void SystemDigIOConfigManager_ConfirmClick(object sender, EventArgs e)
        {
            Common.ReportCmdKeyProgress(CmdKey.F0052);
            saved = true;
        }

        private void LoadDefaultEventHander()
        {
            BT0Content = SystemDataManager.specNames;
            BT0Click += delegate (Object se, System.EventArgs arg)
            {
                if (saved)
                {
                    SaveMacDataValue();
                }
                this.ParentForm.ReplaceChildForm(new SystemSpeParamsManager(mac));
            };
            BT4Content = SystemDataManager.cfgNames;
            BT4Click += delegate (Object se, System.EventArgs arg)
            {
                if (saved)
                {
                    SaveMacDataValue();
                }
                ParentForm.ReplaceChildForm(new SystemConfigManger(mac));
            };
            switch (showMode)
            {
                case 0:
                    {
                        BT6Content = SystemDataManager.doNames;
                        BT6Click += delegate (Object se, System.EventArgs arg)
                        {
                            if (saved)
                            {
                                SaveMacDataValue();
                            }
                            ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac, 1));
                        };
                        if (Globals.ApplayAI)
                        {
                            if (saved)
                            {
                                SaveMacDataValue();
                            }
                            BT7Content = SystemDataManager.aiNames;
                            BT7Click += delegate (Object se, System.EventArgs arg)
                            {
                                ParentForm.ReplaceChildForm(new SystemAnalogManager(mac));
                            };
                        }
                    }
                    break;
                case 1:
                    {
                        BT5Content = SystemDataManager.diNames;
                        BT5Click += delegate (Object se, System.EventArgs arg)
                        {
                            if (saved)
                            {
                                SaveMacDataValue();
                            }
                            ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac, 0));
                        };
                        if (Globals.ApplayAI)
                        {
                            if (saved)
                            {
                                SaveMacDataValue();
                            }
                            BT7Content = SystemDataManager.aiNames;
                            BT7Click += delegate (Object se, System.EventArgs arg)
                            {
                                ParentForm.ReplaceChildForm(new SystemAnalogManager(mac));
                            };
                        }
                    }
                    break;
                case 2:
                    {
                        if (Globals.ApplayAI)
                        {
                            BT6Content = SystemDataManager.aiNames;
                            BT6Click += delegate (Object se, System.EventArgs arg)
                            {
                                if (saved)
                                {
                                    SaveMacDataValue();
                                }
                                ParentForm.ReplaceChildForm(new SystemAnalogManager(mac));
                            };
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
