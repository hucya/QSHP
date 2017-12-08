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

namespace QSHP.UI
{
    public partial class SystemAnalogManager : BaseForm
    {
        List<Label> names = new List<Label>();
        List<NumberEdit> channels = new List<NumberEdit>();
        List<NumberEdit> scales = new List<NumberEdit>();
        List<NumberEdit> offsets = new List<NumberEdit>();
        List<NumberEdit> threshold = new List<NumberEdit>();
        List<NumberEdit> maxs = new List<NumberEdit>();
        List<NumberEdit> mins = new List<NumberEdit>();
        List<ComboBoxEx> enables = new List<ComboBoxEx>();
        MacData mac;
        bool saved = false;
        public SystemAnalogManager(MacData m)
        {
            InitializeComponent();
            LoadDefaultControl();
            if (!DesignMode)
            {
                mac = m;
                LoadeMacDataValue(mac);
                LoadDefaultEventHander();
            }
            
        }

        private void LoadDefaultControl()
        {
            names.Add(N1);
            names.Add(N2);
            names.Add(N3);
            names.Add(N4);
            names.Add(N5);
            names.Add(N6);
            names.Add(N7);
            names.Add(N8);

            channels.Add(I1);
            channels.Add(I2);
            channels.Add(I3);
            channels.Add(I4);
            channels.Add(I5);
            channels.Add(I6);
            channels.Add(I7);
            channels.Add(I8);

            scales.Add(S1);
            scales.Add(S2);
            scales.Add(S3);
            scales.Add(S4);
            scales.Add(S5);
            scales.Add(S6);
            scales.Add(S7);
            scales.Add(S8);

            offsets.Add(O1);
            offsets.Add(O2);
            offsets.Add(O3);
            offsets.Add(O4);
            offsets.Add(O5);
            offsets.Add(O6);
            offsets.Add(O7);
            offsets.Add(O8);

            threshold.Add(T1);
            threshold.Add(T2);
            threshold.Add(T3);
            threshold.Add(T4);
            threshold.Add(T5);
            threshold.Add(T6);
            threshold.Add(T7);
            threshold.Add(T8);

            maxs.Add(Max1);
            maxs.Add(Max2);
            maxs.Add(Max3);
            maxs.Add(Max4);
            maxs.Add(Max5);
            maxs.Add(Max6);
            maxs.Add(Max7);
            maxs.Add(Max8);

            mins.Add(Min1);
            mins.Add(Min2);
            mins.Add(Min3);
            mins.Add(Min4);
            mins.Add(Min5);
            mins.Add(Min6);
            mins.Add(Min7);
            mins.Add(Min8);

            enables.Add(E1);
            enables.Add(E2);
            enables.Add(E3);
            enables.Add(E4);
            enables.Add(E5);
            enables.Add(E6);
            enables.Add(E7);
            enables.Add(E8);

        }

        private void LoadeMacDataValue(MacData m)
        {
            for (int i = 0; i < 8; i++)
            {
                names[i].Text = HW.AiDefine.AIList[i];
                channels[i].Value = m.IoData.AiArgs[i].Index;
                scales[i].Value = m.IoData.AiArgs[i].Scale;
                offsets[i].Value = m.IoData.AiArgs[i].Offset;
                threshold[i].Value = m.IoData.AiArgs[i].Threshold;
                maxs[i].Value = m.IoData.AiArgs[i].MaxValue;
                mins[i].Value=m.IoData.AiArgs[i].MinValue;
                enables[i].SelectedIndex= m.IoData.AiArgs[i].Enable?1:0;
            }
        }
        private void SaveMacDataValue()
        {
            if (saved)
            {
                MacData m = mac;
                if (m != null)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        m.IoData.AiArgs[i].Index = channels[i].Int;
                        m.IoData.AiArgs[i].Scale = scales[i].Value;
                        m.IoData.AiArgs[i].Offset = offsets[i].Value;
                        m.IoData.AiArgs[i].Threshold = threshold[i].Value;
                        m.IoData.AiArgs[i].MaxValue = maxs[i].Value;
                        m.IoData.AiArgs[i].MinValue = mins[i].Value;
                        m.IoData.AiArgs[i].Enable = enables[i].SelectedIndex == 1;
                    }
                    SystemDataManager.saved = true;
                }
            }
        }

        private bool CheckAnalogValueIsValid()
        {
            bool flag = true;
            for (int i = 0; i < 8; i++)
            {
                if (threshold[i].Value < mins[i].Value)
                {
                    flag = false;
                    threshold[i].SetError = true;
                }
                if (threshold[i].Value > maxs[i].Value)
                {
                    flag = false;
                    threshold[i].SetError = true;
                }
                if (maxs[i].Value <= mins[i].Value)
                {
                    flag = false;
                    maxs[i].SetError = true;
                    mins[i].SetError = true;
                }
                if (scales[i].Value <= 0)
                {
                    flag = false;
                    scales[i].SetError = true;
                }
            }
            return flag;
        }


        private void SystemAnalogManager_ConfirmClick(object sender, EventArgs e)
        {
            saved = CheckAnalogValueIsValid();
            if (saved)
            {
                Common.ReportCmdKeyProgress(CmdKey.F0053);
            }
        }

        private void SystemAnalogManager_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveMacDataValue();
            }
            this.ParentForm.OnCancelClick();
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
            if (Globals.MajorIO)
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
                BT6Content = SystemDataManager.doNames;
                BT6Click += delegate (Object se, System.EventArgs arg)
                {
                    if (saved)
                    {
                        SaveMacDataValue();
                    }
                    ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac, 1));
                };
            }
            else
            {
                BT5Content = SystemDataManager.ioNames;
                BT5Click += delegate (Object se, System.EventArgs arg)
                {
                    if (saved)
                    {
                        SaveMacDataValue();
                    }
                    ParentForm.ReplaceChildForm(new SystemDigIOConfigManager(mac));
                };
            }

        }
    }

}
