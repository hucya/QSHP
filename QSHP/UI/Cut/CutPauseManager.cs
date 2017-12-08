using QSHP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI.Manual
{
    public partial class CutPauseManager : AlignFormBase
    {
        CutSegment seg;
       // float adjPos = 0;
        PointF pausePos = new PointF(0, 0);
        string format="#.###";
        public CutPauseManager()
        {
            InitializeComponent();
        }

        private void PauseManager_NextClick(object sender, EventArgs e)//继续开始划切
        {
            if (ParentForm != null)
            {
                ParentForm.PopChildForm();
                Globals.Paused = false;                         //取消系统暂停功能
                if (Globals.Cutting)
                {
                    Common.SetSystemWorkMode(SysFunState.Cutting);//继续开始划切  可以进行断点续划
                }
            }
        }

        private void PauseManager_Load(object sender, EventArgs e)
        {
            Common.ProgressWorkingChanged += new ProgressChangedEventHandler(BackWorker_ProgressChanged);
            CaptureView.ChangeCaptureViewModeHander += CaptureView_ChangeCaptureViewModeHander;
        }

        private void CaptureView_ChangeCaptureViewModeHander(object sender, EventArgs e)
        {
            ccdMode.Text = CCDName;
        }

        void BackWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == ProcessCmd.CutSopCmd)
            {
                if (ParentForm != null)
                {
                    Common.ProgressWorkingChanged -= new ProgressChangedEventHandler(BackWorker_ProgressChanged);
                    ParentForm.PopChildForm(this);
                }
            }
        }

        private void PauseManager_ConfirmClick(object sender, EventArgs e)
        {
            Globals.CutStop = true;
        }

        public override bool FormLoadReady()
        {
            base.FormLoadReady();
            this.UnderBar.BtList[5].UsedLed = true;
            pausePos = Globals.AxisPoint;//暂停时对准位置
            seg = Globals.Segment;
            if (pausePos.X <= 0 || pausePos.Y <= 0)
            {
                pausePos = Globals.Channel.PausePos;
                pausePos.Y = Globals.Channel.PausePos.Y + Globals.KniefAdj;//划切位置+偏移位置
            }
            if (CHs.Contains(Globals.Channel))
            {
                for (int i = 0; i < CHs.Count; i++)
                {
                    if (CHs[i] == Globals.Channel)
                    {
                        ChannlIndex = i;
                        SetCurrentChannel();
                        break;
                    }
                }
            }
            LoadDefaultValue(seg);
            return true;
        }

        public override bool FormUnloadReady()
        {
            this.UnderBar.BtList[5].UsedLed = false;
            return base.FormUnloadReady();
        }

        private void CutPauseManager_AutoUpdateEventHander(object sender, EventArgs e)
        {
            this.UnderBar.BtList[5].LED = Globals.PreCut;
            cutLineWidth.Text = CaptureView.GuidesLineWidth.ToString(format);
        }

        private void ChangePreCutSpeedEventHander(object sender, EventArgs e)
        {
            if (Globals.Cutting)
            {
                Globals.PreCut = !Globals.PreCut;
                if (Globals.PreCut)
                {
                    Common.ReportCmdKeyProgress(CmdKey.P0126);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.P0127);
                }
            }
        }

        private void ChangeCutLinesEventHander(object sender, EventArgs e)
        {
            if (seg != null && !seg.Complate)
            {
                Common.RepairCutChannelValue(seg, 1, cutLineAdj.Value);
                cutProcess.StringFormat = string.Format("{0}/{1}", seg.CuttingIndex, seg.Lines.Count) + "{0}%";
                cutProcess.Value = (int)(seg.CuttingIndex / seg.Lines.Count);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
            cutLineAdj.Value = 0;
        }

        private void ChangeCutSpeedEventHander(object sender, EventArgs e)
        {
            if (seg != null && !seg.Complate)
            {
                Common.RepairCutChannelValue(seg, 0, cutSpeedAdj.Value);
                cutSpeed.Text = seg[seg.CuttingIndex].Speed.ToString();
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
            cutSpeedAdj.Value = 0;
        }

        private void ChangeCutDeapthEventHnader(object sender, EventArgs e)
        {
            if (seg != null && !seg.Complate)
            {
                var line = seg.Lines.Last();
                Common.RepairCutChannelValue(seg, 2, cutDeapthAdj.Value);
                cutDeapth.Text = line.Dual ? line.ReDepth2.ToString() : line.ReDepth.ToString();
                cutDeapthAdj.Value = 0;
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
        }

        private void ChangeCutIndexStepEventHander(object sender, EventArgs e)
        {
            if (seg != null && !seg.Complate)
            {
                Common.RepairCutChannelValue(seg, 3, cutStepAdj.Value);
                cutStep.Text = Math.Abs(seg.Lines.Last().StartPos.Y).ToString(format);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
            cutStepAdj.Value = 0;
        }
        //对准线校正
        private void ChangeAlignLineEventHander(object sender, EventArgs e)
        {
            float pos = Common.Y_Axis.RealPos;
            if (seg != null && !seg.Complate)
            {
                Common.RepairCutChannelValue(seg, 4, pos-pausePos.Y);//基准线矫正
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
            cutStepAdj.Value = 0;
        }
        //位置校正
        private void ChangeCutPosEventHander(object sender, EventArgs e)
        {
            float pos = Common.Y_Axis.RealPos;
            if (seg != null && !seg.Complate)
            {
                Common.RepairCutChannelValue(seg, 5, pos - pausePos.Y);//位置调整
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
            }
        }

        private void LoadDefaultValue(CutSegment s)
        {
            if (!Group.Multiple)
            {
                Chip.Text = "Chip1";
            }
            else
            {
                Chip.Text = s.CH.Chip.Name;
            }
            var line = s.Lines.Last();
            curName.Text = s.CH.Name;
            cutStep.Text = Math.Abs(line.StartPos.Y) .ToString(format);
            cutLine.Text = s.Lines.Count.ToString();
            cutSpeed.Text = line.Speed.ToString();
            cutDeapth.Text = line.Dual ? line.ReDepth2.ToString() : line.ReDepth.ToString();
            cutProcess.StringFormat = string.Format("{0}/{1}",s.CuttingIndex,s.Lines.Count)+"{0}%";
            cutProcess.Value = (int)(s.CuttingIndex/ s.Lines.Count);
            cutLineWidth.Text = CaptureView.GuidesLineWidth.ToString(format);
        }

        private void CutPauseManager_ChangeCutChannelHander(object sender, CutChannel e)
        {
            Common.ReportCmdKeyProgress(CmdKey.S0036);//不支持当前操作 暂停模式下 不支持通道切换操作
        }

        private void CutPauseManager_CancelClick(object sender, EventArgs e)
        {
            //添加此事件，避免使用默认的退出程序
        }
    }
}
