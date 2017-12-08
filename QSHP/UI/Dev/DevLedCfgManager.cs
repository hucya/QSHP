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
    public partial class DevLedCfgManager : BaseForm
    {
        List<ComboBoxEx> Bs = new List<ComboBoxEx>();
        List<ComboBoxEx> Gs = new List<ComboBoxEx>();
        List<ComboBoxEx> Ys = new List<ComboBoxEx>();
        List<ComboBoxEx> Rs = new List<ComboBoxEx>();
        List<LedCmd> cmds = new List<LedCmd>();
        bool saved = false;
        DevData dev;
        public DevLedCfgManager(DevData d)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                dev = d;
                InitDefaultCtr();
                LoadDefaultValue(dev);
            }
        }

        private void T1_Click(object sender, EventArgs e)
        {
            ButtonEx b = sender as ButtonEx;
            if (b != null)
            {
                int i = b.Flag;
                LedCmd cmd = new LedCmd();
                cmd.Buzzer = (byte)Bs[i].SelectedIndex;
                cmd.Green = (byte)Gs[i].SelectedIndex;
                cmd.Yellow = (byte)Ys[i].SelectedIndex;
                cmd.Red = (byte)Rs[i].SelectedIndex;
                Globals.LedCmd.Cmd = cmd.Cmd;
            }
        }

        private void SaveDefaultValue()
        {
            if (saved)
            {
                for (int i = 0; i < 9; i++)
                {
                    cmds[i].Buzzer = (byte)Bs[i].SelectedIndex;
                    cmds[i].Green = (byte)Gs[i].SelectedIndex;
                    cmds[i].Yellow = (byte)Ys[i].SelectedIndex;
                    cmds[i].Red = (byte)Rs[i].SelectedIndex;
                }
                DevDataManager.saved = true;
            }
        }

        private void LoadDefaultValue(DevData dev)
        {
            cmds.Clear();
            cmds.Add(dev.LoadLedCmd);
            cmds.Add(dev.IdleLedCmd);
            cmds.Add(dev.InitLedCmd);
            cmds.Add(dev.PauseLedCmd);
            cmds.Add(dev.StopLedCmd);
            cmds.Add(dev.WorkingLedCmd);
            cmds.Add(dev.TestingLedCmd);
            cmds.Add(dev.ErrAirWaterLedCmd);
            cmds.Add(dev.EmgLedCmd);
            for (int i = 0; i < 9; i++)
            {
                Bs[i].SelectedIndex = cmds[i].Buzzer;
                Gs[i].SelectedIndex = cmds[i].Green;
                Ys[i].SelectedIndex = cmds[i].Yellow;
                Rs[i].SelectedIndex = cmds[i].Red;
            }
        }
        private void InitDefaultCtr()
        {
            Bs.Add(B1);
            Bs.Add(B2);
            Bs.Add(B3);
            Bs.Add(B4);
            Bs.Add(B5);
            Bs.Add(B6);
            Bs.Add(B7);
            Bs.Add(B8);
            Bs.Add(B9);

            Gs.Add(G1);
            Gs.Add(G2);
            Gs.Add(G3);
            Gs.Add(G4);
            Gs.Add(G5);
            Gs.Add(G6);
            Gs.Add(G7);
            Gs.Add(G8);
            Gs.Add(G9);

            Ys.Add(Y1);
            Ys.Add(Y2);
            Ys.Add(Y3);
            Ys.Add(Y4);
            Ys.Add(Y5);
            Ys.Add(Y6);
            Ys.Add(Y7);
            Ys.Add(Y8);
            Ys.Add(Y9);

            Rs.Add(R1);
            Rs.Add(R2);
            Rs.Add(R3);
            Rs.Add(R4);
            Rs.Add(R5);
            Rs.Add(R6);
            Rs.Add(R7);
            Rs.Add(R8);
            Rs.Add(R9);

        }

        private void DevLedCfgManager_ConfirmClick(object sender, EventArgs e)
        {
            saved = true;
        }

        private void DevLedCfgManager_CancelClick(object sender, EventArgs e)
        {
            if (saved)
            {
                SaveDefaultValue();
            }
            this.ParentForm.OnCancelClick();
        }
    }
}
