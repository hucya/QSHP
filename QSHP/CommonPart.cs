using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSHP.HW.AmpC;
using QSHP.HW.Video;
using QSHP.Com;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using QSHP.Data;
using QSHP.HW;

namespace QSHP
{
    public static partial class Common
    {
        #region 状态检测

        public static bool StartCuttingIsReady(int speed)
        {
            Common.DO[DoDefine.CUT_WATER] = true;//打开切割水
            Common.DO[DoDefine.TAB_AIR] = true; //打开工作台其他
            Common.DO[DoDefine.WORK_AIR] = true;//打开吸片气压
            Globals.LedCmd.Cmd = Globals.DevData.WorkingLedCmd.Cmd;
            Thread.Sleep(100);
            bool flag= CuttingCheckStatus();
            if (flag)
            {
              flag=  RunSpd(speed, Globals.DevData.CuttingTime);
            }
            return flag;
        }
        public static bool CuttingCheckStatus()
        {
            if (!Globals.DebugMode)
            {
                uint inputData = DI.Status;
                int m = DI.IOList[DiDefine.MAIN_WATER];
                if (!inputData.Bit(m))//主气压不足
                {

                }
                m = DI.IOList[DiDefine.MAIN_AIR];
                if (!inputData.Bit(m))//主气压不足
                {

                }
                m = DI.IOList[DiDefine.EMG_SIG];
                if (!inputData.Bit(m))//急停被按下
                {

                }
                m = DI.IOList[DiDefine.CUT_WATER];
                if (Globals.DevData.CutWaterChecked && !inputData.Bit(m))//切割水不足
                {

                }
                m = DI.IOList[DiDefine.LEAK_WATER];
                if (Globals.DevData.LeakWaterChecked && !inputData.Bit(m))//漏水检测
                {

                }
                if (Globals.BldData.BldRemainder < Globals.BldData.SafetyMargin)//刀具露出量小于安全余量
                {
 
                }
                if (Globals.BldData.LenAfterReplace > Globals.BldData.MaxSafeLength)//长度超标
                {

                }
                if (Globals.BldData.LinesAfterReplace > Globals.BldData.MaxSafeLines)//刀数超标 
                {

                }
                //刀破检测
                //
            }
            return true;
        }
        public static bool SystemCheckStatus()
        {
            CuttingCheckStatus();
            return true;
        }
        private static bool SystemInitCheckStatus()
        {
            if (!Globals.Load)
            {
                ReportCmdKeyProgress(CmdKey.S0106);
                return false;
            }
            if (!X_Axis.Enabled)
            {
                X_Axis.EnableAmpC();
            }
            if (!Y_Axis.Enabled)
            {
                Y_Axis.EnableAmpC();
            }
            if (!Z_Axis.Enabled)
            {
                Z_Axis.EnableAmpC();
            }
            if (!T_Axis.Enabled)
            {
                T_Axis.EnableAmpC();
            }
            if (!X_Axis.Enabled)
            {
                ReportCmdKeyProgress(CmdKey.S0209);
                return false;
            }
            if (!Y_Axis.Enabled)
            {
                ReportCmdKeyProgress(CmdKey.S0309);
                return false;
            }
            if (!Z_Axis.Enabled)
            {
                ReportCmdKeyProgress(CmdKey.S0409);
                return false;
            }
            if (!T_Axis.Enabled)
            {
                ReportCmdKeyProgress(CmdKey.S0509);
                return false;
            }
            return true;
        }
        private static bool TesttingCheckStatus(bool touch=false)
        {
            if (Globals.EMG)
            {
                return false;
            }
            if (Globals.TestCancel)
            {
                ReportCmdKeyProgress(CmdKey.H0009);
                return false;
            }
            if (Z_Axis.AmpCFault)
            {
                ReportCmdKeyProgress(CmdKey.S0402);
                return false;
            }
            DO[DoDefine.TAB_AIR] = true;//打开吸台
            DO[DoDefine.CUT_WATER] = false;//关闭切割水
            DO[DoDefine.BUZZER] = false;//关闭蜂鸣器
            DO[DoDefine.LED_YELL] = true;
            DO[DoDefine.LED_GREEN] = true;
            DO[DoDefine.LED_RED] = true;
            Thread.Sleep(500);
            
            return true;
        }

        #endregion

        #region 应用功能

        public static bool TouchTestingHeight()
        {
            TabData data = Globals.TabData;
            int tick = 30;
            ReportCmdKeyProgress(CmdKey.H0001);
            Globals.TestCancel = false;
            Globals.Testing = true;
            Globals.TestedHeight = false;   //清零系统标志位
            RunSpd(Globals.TabData.SpdSpeed, Globals.DevData.TestTime);
            Globals.LedCmd.Cmd = Globals.DevData.TestingLedCmd.Cmd;
            Z_Axis.AxisJogAbsWork(Z_Axis.Param.StartPos,true);   //Z轴先返回到最高点
            if (data.UsedTable.RotateType)//圆盘测高 
            {
                data.UsedTable.CurTpos += Globals.MacData.TTestOffset;
                if (data.UsedTable.CurTpos > data.MaxTpos)
                {
                    data.UsedTable.CurTpos = data.UsedTable.StartTpos;
                }
            }
            else//方盘测高 
            {
                data.UsedTable.CurYpos += Globals.MacData.YTestOffset;
                data.UsedTable.CurTpos = data.UsedTable.StartTpos;
                if (data.UsedTable.CurYpos- data.UsedTable.StartYpos > data.UsedTable.Length)
                {
                    data.UsedTable.CurYpos = data.UsedTable.StartYpos;
                }
            }
            X_Axis.AxisJogAbsWork(data.UsedTable.CurXpos);    //X值坐标位置
            Y_Axis.AxisJogAbsWork(data.UsedTable.CurYpos);    //Y值坐标位置
             WaitAxisMoveDone();                             //等待X Y T移动到位
            Z_Axis.AxisJogAbsWork(data.UsedTable.ZLowPos);    //Z轴移动到高速位置
            ReportCmdKeyProgress(CmdKey.H0003);
            do
            {
                if (!TesttingCheckStatus())
                {
                    return false;
                }
                Thread.Sleep(50);
            } while (!Z_Axis.IsInPosition);                 //等待Z轴到位
            Z_Axis.SetLimitSwitch(false);
            float[] num = new float[data.TestTick];
            float startPos = 30;
            float homeOffset = Globals.MacData.ZRiseValue;//Z轴上升高度
            float counterPos = Z_Axis.PhyPos;
            for (int i = 0; i < data.TestTick; i++)
            {
                ReportCmdKeyProgress((CmdKey)((int)CmdKey.H0004 + i));
                Z_Axis.GoHome(Limit.UserLimit, Globals.MacData.ZTestSpeed, Globals.MacData.ZTestAcc, homeOffset); //Z轴开始向下测高操作 ，每次操作限时60S
                tick = 600;
                do
                {
                    if (!TesttingCheckStatus())
                    {
                        return false;
                    }
                    tick--;
                    Thread.Sleep(100);
                } while (!Z_Axis.HomeIsSuccessful && tick > 0); //等待回零完成
                startPos = (Z_Axis.PhyPos - counterPos) + data.UsedTable.ZLowPos; //计算当前实际位置
                Z_Axis.SetPrePosition(startPos);    //设置起始位置
                num[i] = startPos - homeOffset;
                ReportWorkingProgress(ProcessCmd.CsTestingTickCmd, num[i]);
            }
            if (num.Max() - num.Min() > data.CsMaxErrValue)//测高误差过大
            {
                ReportCmdKeyProgress(CmdKey.H0007);
                return false;
            }
            else
            {
                data.CsTestValue = num.Average();
                Globals.TestHeightValue = data.CsTestValue;
                Globals.TestedHeight = true;//系统测高标志位
                ReportCmdKeyProgress(CmdKey.H0008);
                return true;
            }
        }

        public static bool EmergencyStop()
        {
            try
            {
                Globals.LedCmd.Cmd = Globals.DevData.EmgLedCmd.Cmd;
                ReportCmdKeyProgress(CmdKey.S0093);
                bool flag = X_Axis.JogStop();
                flag &= Y_Axis.JogStop();
                flag &= T_Axis.JogStop();
                flag &= Z_Axis.JogStop();
                flag &= Z_Axis.AxisJogAbsWork(Globals.MacData.ZStartPos);
                Globals.EMG = false;
                return flag;
            }
            catch
            {
                Common.ReportCmdKeyProgress(CmdKey.S0091);
                return false;
            }
        }

        public static PointF AlignT(PointF p1, PointF p2, PointF center, out float angle)
        {
            angle = (float)RotateMath.GetPointsAngle(p1, p2);
            try
            {
                if (!Globals.IsInit)
                {
                    Common.ReportCmdKeyProgress(CmdKey.A0005);
                    return p1;
                }
                //PointF p = Com.RotateMath.PointRotate(center, new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2), a);
                PointF p = RotateMath.PointRotate(center, p1, angle);
                T_Axis.AxisJogIncWork(angle);
                X_Axis.JogAbs(Globals.MacData.TAdjSpeed,Globals.MacData.TAdjAcc,p.X);
                Y_Axis.AxisJogAbsWork(p.Y);
                return p;
            }
            catch
            {
                Common.ReportCmdKeyProgress(CmdKey.S0091);
                return p1;
            }
        }

        public static PointF GetCenterPoint(PointF p1, PointF p2, float angle)
        {
            try
            {
                T_Axis.AxisJogIncWork(angle);
                PointF center = Com.RotateMath.RotateCenterPoint(p1, p2, angle);
                X_Axis.AxisJogAbsWork(center.X);
                Y_Axis.AxisJogAbsWork(center.Y);
                return center;
            }
            catch
            {
                return p1;
            }
        }

        public static bool AutoFocus(IVideoProvider provider, float maxPos, float minPos, float step = 0.2f)
        {
            try
            {
                if (provider == null)
                    return false;
                bool isCapture = provider.IsRunning;
                Dictionary<double, float> pos = new Dictionary<double, float>();
                Z_Axis.AxisJogAbsWork(maxPos);
                if (!WaitAxisMoveDone())
                {
                    return false;
                }
                if (!isCapture)
                {
                    provider.StartCapture();
                }
                int stepTick = (int)((maxPos - minPos) / step);
                double scalValue = 0;
                int tick = 0;
                for (int i = 0; i < stepTick; i++)
                {
                    Z_Axis.AxisJogIncWork(-step, true);
                    Thread.Sleep(20);
                    Bitmap map = provider.GetCurrentFrame();
                    double qua = map.GetLinearQuality();
                    if (!pos.ContainsKey(qua))
                    {
                        if (qua < scalValue)
                        {
                            if (tick++ > 3)
                                break;
                        }
                        else
                        {
                            tick = 0;
                        }
                        scalValue = qua;
                        pos.Add(qua, z_Axis.RealPos);
                    }
                }
                double maxKey = pos.Max(r => r.Key);
                float desPos = pos[maxKey];
                Z_Axis.AxisJogAbsWork(desPos);
                if (!isCapture)
                {
                    provider.StopCapture();
                }
                pos.Clear();
                GC.Collect();
                if (step / 20 < 0.005)
                {
                    return true;
                }
                else
                {
                    return AutoFocus(provider, desPos + step, desPos - step, step / 10);
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 运动控制

        public static bool MoveToWorkPos(PointF viewPos,bool hiCCD=true)
        {
            if (Globals.IsInit)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool MoveToViewPos(PointF workPos,bool hiCCD=true)
        {
            if (Globals.IsInit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool RunSpd(int speed, int waitTime = -1)
        {
            if (SPD != null)
            {
                if (!Globals.DebugMode)
                {
                    if (!DI[DiDefine.MAIN_AIR])
                    {
                        Common.ReportCmdKeyProgress(CmdKey.S0613);
                        return false;
                    }
                    if (!DI[DiDefine.MAIN_WATER])
                    {
                        Common.ReportCmdKeyProgress(CmdKey.S0614);
                        return false;
                    }
                    if (DO[DoDefine.SPD_LOCK])
                    {
                        Common.ReportCmdKeyProgress(CmdKey.S0615);
                    }
                    if (Globals.DevData.DoorProtectUsed)
                    {
                        DO[DoDefine.CUT_DOOR] = true;//关闭舱门锁
                        Thread.Sleep(500);
                        if (!DI[DiDefine.CUT_DOOR])//判断舱门状态
                        {
                            return false;
                        }
                    }
                    if (waitTime != -1)
                    {
                        int i = 30;
                        Common.ReportCmdKeyProgress(CmdKey.S0608);
                        do
                        {
                            i--;
                            SPD.RunSpd(speed);
                            Thread.Sleep(1000);
                        } while (!SPD.SpeedStabled && i > 0);//开启转动主轴
                        if (!Globals.SpdStable)
                        {
                            if (ProgressSpdEventChanged != null)
                            {
                                ProgressSpdEventChanged(ProcessCmd.SpdWaitCmd, 0);
                            }
                            for (float t = 0; t < waitTime; t++)
                            {
                                Thread.Sleep(1000);//暂停延迟时间
                                if (ProgressSpdEventChanged != null)
                                {
                                    float v=t / waitTime*100;
                                    ProgressSpdEventChanged(ProcessCmd.SpdWaitReportCmd, v);
                                }
                            }
                            if (ProgressSpdEventChanged != null)
                            {
                                ProgressSpdEventChanged(ProcessCmd.SpdWaitReadyCmd, 100);
                            }
                            Globals.SpdStable = true;
                        }
                        Common.ReportCmdKeyProgress(CmdKey.S0609);
                        return true;
                    }
                    else
                    {
                        return SPD.RunSpd(speed);
                    }
                }
                else
                {
                    ReportCmdKeyProgress(CmdKey.S0620);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool AxisJogStep(IAmpCProvider ampC, int dir)
        {
            if (ampC != null && ampC.IsInPosition)
            {
                return ampC.AxisJogIncWork(ampC.Param.StepPos * dir);//向前或向后移动固定距离 后期进行更改
            }
            else
            {
                return false;
            }
        }

        public static bool WaitAxisMoveDone(IAmpCProvider ampC, int timeout = 600)
        {
            if (ampC == null)
            {
                return false;
            }
            do
            {
                if (Globals.EMG)
                {
                    return false;
                }
                //if (ampC.AmpCFault)
                //{
                //    return false;
                //}
                if (timeout != -1 && timeout-- < 0)
                {
                    ReportCmdKeyProgress(CmdKey.S0094);
                    return false;
                }
                Thread.Sleep(50);
            } while (!ampC.IsInPosition);
            return true;
        }

        public static bool WaitAxisMoveDone(int timeout = -1)
        {
            if (!Globals.Load)
            {
                return false;
            }
            do
            {
                if (Globals.EMG)
                {
                    return false;
                }
                if (timeout != -1 && timeout-- < 0)
                {
                    ReportCmdKeyProgress(CmdKey.S0094);
                    return false;
                }
                //if (X_Axis.AmpCFault)
                //{
                //    ReportCmdKeyProgress(CmdKey.S0202);
                //    return false;
                //}
                //if (Y_Axis.AmpCFault)
                //{
                //    ReportCmdKeyProgress(CmdKey.S0302);
                //    return false;
                //}
                //if (Z_Axis.AmpCFault)
                //{
                //    ReportCmdKeyProgress(CmdKey.S0402);
                //    return false;
                //}
                //if (T_Axis.AmpCFault)
                //{
                //    ReportCmdKeyProgress(CmdKey.S0502);
                //    return false;
                //}
                Thread.Sleep(50);
            }
            while (!X_Axis.IsInPosition || !Y_Axis.IsInPosition || !Z_Axis.IsInPosition || !T_Axis.IsInPosition);
            return true;
        }
        #endregion

        #region 划切控制

        public static bool RepairCutChannelValue(CutSegment seg,int mode,float inc)
        {
            if (seg == null)
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
                return false;
            }
            if (!Globals.Cutting||!seg.Cutting || seg.Complate)//不在切割状态 或者切割完成
            {
                Common.ReportCmdKeyProgress(CmdKey.P0120);
                return false;
            }
            if (inc == 0)
            {
                Common.ReportCmdKeyProgress(CmdKey.P0119);
                return true;
            }
            switch (mode)
            {
                case 0://改变速度
                    {
                        if (Globals.PreCut)//需要手动关闭预划切后才能进行速度调节
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0136);
                            return false;
                        }
                        float value = seg.Speed + inc;
                        if (Math.Abs(inc) > Globals.DevData.MaxSpeedAdj)
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0121);
                        }
                        if (value <= 0 || value >= 500)
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0111);
                            return false;
                        }
                        seg.RepairCutSpeed(value);
                        Common.ReportCmdKeyProgress(CmdKey.P0115);
                    }
                    break;
                case 1://改变刀数
                    {
                        int value = (int)inc + seg.Count;
                        if (Math.Abs(value * seg.IndexStep) > Globals.TabData.UsedTabSize.Width) 
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0135);
                        }
                        if (value < seg.CuttingIndex)//小于当前已经划切刀数
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0112);
                            return false;
                        }
                        //需要重新进行数据有效性判定
                        seg.RepairCutLines(value);
                        Common.ReportCmdKeyProgress(CmdKey.P0116);
                    }
                    break;
                case 2://改变深度
                    {
                        float value = seg.Dual ? seg.ReDepth2 : seg.ReDepth;
                        float height = seg.SelfPos - Globals.TestHeightValue - Globals.MacData.ZSelfPos;//获取到当前工件的有效厚度
                        value += inc;
                        if (Math.Abs(inc) > Globals.DevData.OnceHeightAdj)//单次变更值大于0.1
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0123);
                            return false;
                        }
                        height -= value;
                        if (height > 0 && height > Globals.BldData.SafetyRemainder)//可划切但是超出刀具安全值
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0125);
                            return false;
                        }
                        else
                        {
                            if (height < 0 && Math.Abs(height) > Globals.MacData.ZSelfPos)//划切不到且超过抬刀位置
                            {
                                Common.ReportCmdKeyProgress(CmdKey.P0113);
                                return false;
                            }
                            else
                            {
                                seg.RepairCutDeapth(value);
                                Common.ReportCmdKeyProgress(CmdKey.P0117);
                            }
                        }
                    }
                    break;
                case 3://改变分度
                    {
                        float value = seg.IndexStep + inc;
                        if (Math.Abs(inc) > Globals.DevData.MaxStepAdj)
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0124);
                            return false;
                        }
                        if (value>300)
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0114);
                        }
                        seg.RepairCutIndexStep(value);//变更分度值
                        Common.ReportCmdKeyProgress(CmdKey.P0118);
                    }
                    break;
                case 4://基准线矫正
                    {
                        if (Globals.DoubleCap && !Globals.HighCCD)//双镜头模式只支持在高倍下设置
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0128);
                            return false;
                        }
                        if (inc > Globals.DevData.OnceAlignLineAdj)
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0131);
                            return false;
                        }
                        float adjPos = Globals.BldData.KnifeMarksOffsetHi;//需要统一规则 选择高倍
                        adjPos += inc;
                        if (adjPos > Globals.DevData.MaxAlignLineAdj)
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0130);
                            return false;
                        }
                        Globals.KniefAdj += inc;//调节对准线
                        Common.ReportCmdKeyProgress(CmdKey.P0134);
                    }
                    break;
                case 5://位置调整
                    {
                        if (Globals.DoubleCap && !Globals.HighCCD)//双镜头模式只支持在高倍镜下设置
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0129);
                            return false;
                        }
                        if (Math.Abs(inc) > Globals.DevData.MaxPosAdj)
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0130);
                            return false;
                        }
                        if (seg.CH != null && seg.CH.Cutting)
                        {
                            float offset = 0;
                            if (seg.WaitCutNum > 0)//当前方案为减去offset 可替换为变更Y的对准位置为0
                            {
                                offset = seg[seg.CuttingIndex].StartPos.Y;
                            }
                            seg.CH.PausePos.Y = Common.Y_Axis.RealPos - Globals.KniefAdj - offset;
                            Common.ReportCmdKeyProgress(CmdKey.P0133);
                        }
                        else
                        {
                            Common.ReportCmdKeyProgress(CmdKey.P0120);
                        }
                    }
                    break;
                default:
                    {
                        return false;
                    }
            }
            return true;
        }

        public static bool RunLineCut(CutLine line, bool preCut = false)
        {
            do
            {
                switch (line.CutStep)
                {
                    case CutStep.Ready://等待各轴移动到位
                        {
                            if (line.SinDir || !line.Dual || (line.Dual && Globals.DevData.DualZlife))//如果为单项划切或者必须返回
                            {
                                Z_Axis.AxisJogAbsWork(line.SelfPos);//划切一刀 必须Z轴上升到安全位
                            }
                            if (WaitAxisMoveDone())//判断各轴是否到位
                            {
                                line.Cutting = true;//开始切割
                                line.FirstCut = true;
                                if (line.Seg != null&&!line.Abs)
                                {
                                    line.Seg.RepairXPosAndLength(Y_Axis.RealPos + line.StartPos.Y, line);//修正起始位置和长度
                                }
                                if (preCut)//根据是否预划切 修正划切速度
                                {
                                    float s = Globals.Group.PreCut.GetPreDataSpeed();
                                    if (s > 0 && s < line.Speed)//预划切值有效且小于当前划切速度
                                    {
                                        line.Speed = s;
                                    }
                                    else
                                    {
                                        Globals.PreCut = false;
                                    }
                                }
                                line.CutStep = CutStep.ST1;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case CutStep.ST1://X 轴移动到划切位置  需要根据当前Y轴位置重新计算X轴起点和划切长度
                        {
                            
                            X_Axis.JogAbs(line.BackSpeed, Globals.MacData.XCutBackAcc, line.StartPos.X);//设置X返回加速度
                            if (line.Abs)
                            {
                                Y_Axis.AxisJogAbsWork(line.StartPos.Y);
                            }
                            else
                            {
                                //float v = Math.Abs(line.StartPos.Y / line.Length * line.BackSpeed);
                                //Y_Axis.JogInc(v, 0.1f, line.StartPos.Y);
                                Y_Axis.AxisJogIncWork(line.StartPos.Y);//相对位置
                            }
                            WaitAxisMoveDone(Y_Axis);
                            if (WaitAxisMoveDone(X_Axis))
                            {
                                line.CutStep = CutStep.ST2;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case CutStep.ST2://Z轴下落到划切位置1
                        {
                            float pos = line.ReDepth + Globals.TestHeightValue - Globals.BldData.RealCompensatedValue;
                            if (pos < Globals.TestHeightValue)//防止切割到工作台
                            {
                                pos = Globals.TestHeightValue;
                            }
                            Z_Axis.JogAbs(Globals.MacData.ZCutSpeed, Globals.MacData.ZCutAcc,pos );//Z轴下落到位 必须等候Z到位
                            if (WaitAxisMoveDone(Z_Axis))
                            {
                                line.CutStep = CutStep.ST3;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case CutStep.ST3://X轴进行划切操作
                        {
                            X_Axis.JogInc(line.Speed, Globals.MacData.XCutAcc, line.Dir ? -line.Length : line.Length);//X轴开始缓慢划切  判断划切方向
                            if (WaitAxisMoveDone(X_Axis))
                            {
                                line.CutStep = CutStep.ST4;
                                Globals.BldData.AddCutedLinesAndLength(1, line.Length / 1000);   //已划切刀数
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case CutStep.ST4://Z轴是否抬刀
                        {
                            if (line.SinDir || !line.Dual || (line.Dual && Globals.DevData.DualZlife))//如果为单项划切或者必须返回
                            {
                                Z_Axis.AxisJogAbsWork(line.SelfPos);//划切一刀 必须Z轴上升到安全位
                                if (!WaitAxisMoveDone(Z_Axis))
                                {
                                    return false;
                                }
                            }
                            if (line.Dual)
                            {
                                line.CutStep = CutStep.ST5;
                            }
                            else
                            {
                                line.CutStep = CutStep.CutStop;
                            }
                        }
                        break;
                    case CutStep.ST5://X轴返回到划切位置
                        {
                            line.FirstCut = false;
                            if (line.SinDir)//如果是单向划切X轴必须返回到划切位置
                            {
                                X_Axis.JogAbs(line.BackSpeed, Globals.MacData.XCutBackAcc, line.StartPos.X);//需要重新设置X划切返回速度
                                if (!WaitAxisMoveDone(X_Axis))
                                {
                                    return false;
                                }
                            }
                            line.CutStep = CutStep.ST6;
                        }
                        break;
                    case CutStep.ST6://Z轴下落到划切位置
                        {
                            if (preCut)//根据是否预划切 修正划切速度
                            {
                                float s = Globals.Group.PreCut.GetPreDataSpeed();
                                if (s > 0 && s < line.Speed)//预划切值有效且小于当前划切速度
                                {
                                    line.Speed = s;
                                }
                                else
                                {
                                    Globals.PreCut = false;
                                }
                            }
                            float pos = line.ReDepth2 + Globals.TestHeightValue - Globals.BldData.RealCompensatedValue;
                            if (pos < Globals.TestHeightValue)
                            {
                                pos = Globals.TestHeightValue;
                            }
                            Z_Axis.JogAbs(Globals.MacData.ZCutSpeed, Globals.MacData.ZCutAcc, pos);//Z轴下落到位置2
                            if (WaitAxisMoveDone(Z_Axis))
                            {
                                line.CutStep = CutStep.ST7;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case CutStep.ST7://X轴开始划切
                        {
                            if (line.SinDir)
                            {
                                X_Axis.JogInc(line.Speed, Globals.MacData.XCutAcc, line.Dir ? -line.Length : line.Length);//需要设置返回加速度
                            }
                            else
                            {
                                X_Axis.JogInc(line.Speed, Globals.MacData.XCutAcc, line.Dir ? line.Length : -line.Length);
                            }
                            if (WaitAxisMoveDone(X_Axis))
                            {
                                line.CutStep = CutStep.ST8;
                                Globals.BldData.AddCutedLinesAndLength(1, line.Length / 1000);   //已划切刀数
                            }
                            else
                            {
                                return false;
                            }
                        }
                        break;
                    case CutStep.ST8://Z轴进行抬刀操作
                        {
                            if (line.SinDir || !line.Dual)//如果为单项划切或者必须返回
                            {
                                Z_Axis.AxisJogAbsWork(line.SelfPos);//划切一刀 必须Z轴上升到安全位
                            }
                            line.Cutting = false;
                            line.CutStep = CutStep.CutStop;
                        }
                        break;
                    case CutStep.CutStop://划切结束
                        {
                            if (line.Pause)
                            {
                                line.CutStep = CutStep.Pause;
                            }
                            else
                            {
                                line.CutStep = CutStep.STEnd;//当前先判断为切割完成 后续需要判断是否暂停 刀痕检测  和测高
                            }
                            ReportWorkingProgress(ProcessCmd.CutLineCmd, line);
                        }
                        break;
                    case CutStep.KniefCheck://进行刀痕检测
                        {

                        }
                        break;
                    case CutStep.TestHeigh://进行非接触式测高
                        {

                        }
                        break;
                    case CutStep.Pause:
                        {
                            ReportCmdKeyProgress(CmdKey.P0105);
                            line.CutStep = CutStep.STEnd;   //配置为划切完成
                            return false;                   //中断当前划切操作
                        }
                    case CutStep.STEnd:
                        {
                            line.Complate = true;
                        }
                        break;
                    default:
                        {
                        }
                        break;
                }
                if (Globals.CutStop)
                {
                    return false;
                }
                ReportWorkingProgress(ProcessCmd.CutLineCmd, line);
                CuttingCheckStatus();
                Thread.Sleep(10);
            } while (!line.Complate);//没有完成就一直循环
            return true;
        }//划切线

        public static bool RunSegmentCut(CutSegment s)
        {
            bool flag = true;
            Globals.Segment = s;
            for (int i = 0; i < s.Count; i++)//划切每一分度 
            {
                s.Cutting = true;
                if (!s[i].Complate)
                {
                    Globals.Line = s[i];
                    if (RunLineCut(s[i], Globals.PreCut))
                    {
                        s.CuttingIndex++;
                    }
                    else
                    {
                        if (s[i].CutStep < CutStep.STEnd)//如果当前非正常划切完成 暂停的情况为等于STEnd
                        {
                            if (s[i].CutStep >CutStep.ST1&& !s[i].Abs)//如果Y已经移动清除当前步进的移动位置
                            {
                                s[i].StartPos.Y = 0;
                            }
                            s[i].CutStep = CutStep.Ready;//其他情况该刀需要重新划切
                        }
                        flag = false;
                        break;
                    }
                }
                flag &= s[i].Complate;
            }
            if (flag)//如果当前分度划切完成
            {
                if (s is CutChannel==false)//如果当前位CutChannel模式
                {
                    ReportCmdKeyProgress(CmdKey.P0108);//当前分度划切完成
                    ReportWorkingProgress(ProcessCmd.CutSegEndCmd, s);
                }
                s.Cutting = false;
            }
            s.Complate = flag;
            return s.Complate;
        }//划切分度

        private static bool RunningChannelCut(CutChannel c)
        {
            bool flag = true;
            Globals.Channel = c;
            Z_Axis.AxisJogAbsWork(c.SelfPos);             //Z轴移动到安全位置
            WaitAxisMoveDone(Z_Axis);
            T_Axis.AxisJogAbsWork(c.AlignT + c.TPosAdj);  //T轴移动到偏移位置
            X_Axis.AxisJogAbsWork(c.PausePos.X);          //X轴移动到暂停位置
            Y_Axis.AxisJogAbsWork(c.PausePos.Y);          //Y轴移动到暂停位置(第一次划切默认为起始位置)
            WaitAxisMoveDone();                           //等待各轴运动成功
            c.Cutting = true;
            if (!c.Rotated)
            {
                ReportWorkingProgress(ProcessCmd.CutChStartCmd, c); //开始划切当前通道
                c.Rotated = true;
            }
            if (c.StandMode)
            {
                flag = RunSegmentCut(c);//标准模式划切
            }
            else
            {
                foreach (var item in c.Segs)
                {
                    if (!item.Complate)
                    {
                        ReportWorkingProgress(ProcessCmd.CutSegStartCmd, c); //进行通道划切完成
                        item.Complate = RunSegmentCut(item);
                        if( item.Complate)
                        {
                            c.CuttingIndex += item.Count;
                        }
                        else
                        {
                            flag = false;
                            break;//退出当前循环
                        }
                    }
                    flag &= item.Complate;
                }
            }
            if (flag)
            {
                c.Cutting = false;
                ReportCmdKeyProgress(CmdKey.P0109);
                ReportWorkingProgress(ProcessCmd.CutChEndCmd, c); //当前通道划切完成
            }
            else
            {
                c.PausePos.Y = Y_Axis.RealPos;                //设置Y暂停位置为当前的位置
                c.PausePos.X = Globals.ViewCenter.X;          //设置X暂停位置为显微镜中心位置
                Z_Axis.AxisJogAbsWork(c.SelfPos);             //Z轴移动到安全位置
                WaitAxisMoveDone(Z_Axis);
                X_Axis.AxisJogAbsWork(Globals.ViewCenter.X);         //移动到显微镜视野
                Y_Axis.AxisJogIncWork(Globals.KniefAdj);//划切位置+刀痕偏移值 将线移动到显微镜下面
                WaitAxisMoveDone();//等待移动停止
                if (!Globals.CutStop)//判断是因为暂停导致的返回
                {
                    ReportWorkingProgress(ProcessCmd.CutPauseCmd, c);
                }
            }
            c.Complate = flag;
            return c.Complate;
        }

        public static bool RunChannelCut(CutChannel c)//通道
        {
            c.Complate = RunningChannelCut(c);       //划切当前
            if (c.Complate)                          //如果划切完成
            {
                for (; c.CycleTick < c.CycleCount; )    //判断是否需要循环操作
                {
                    float st = 0;
                    c.CycleTick++;
                    if (c.IndexStep2 > 0)
                    {
                        st = c.Forward ? c.IndexStep2 : -c.IndexStep2; //Y轴向前移动固定距离2
                    }
                    else
                    {
                        st = c.Forward ? c.IndexStep : -c.IndexStep; //Y轴向前移动固定距离1
                    }
                    c.StartPos.Y = Y_Axis.RealPos + st;             //重新开始计算划切起始位置
                    c.InitCutRunningData(true, false);                     //清除切割完成标志
                    if (!RunningChannelCut(c))                       //划切暂停或者失败返回
                    {
                        return false;
                    }
                }
            }
            return c.Complate;
        }

        public static bool RunGroupCut(CutGroup g)
        {
            if (StartCuttingIsReady(g.SpdSpeed))
            {
                bool flag = true;
                if (!g.Cutting)
                {
                    g.Cutting = true;
                    ReportWorkingProgress(ProcessCmd.CutGroupCmd, g);
                }
                foreach (var item in g.ChipCHs)
                {
                    if (item.Enable && !item.Complate)
                    {
                        item.Complate = RunChannelCut(item);
                        flag &= item.Complate;
                        if (flag)
                        {
                            foreach (var c in g.ChipS)//划切完当前片子判断当前片是否完成划切
                            {
                                c.Complate = c.IsComplated;
                            }
                            if (!g.IsComplated)
                            {
                                ReportCmdKeyProgress(CmdKey.P0110);
                            }
                        }
                    }
                    if (!flag)
                    {
                        return false;
                    }
                }
                g.Complate = flag;
                if (flag)
                {
                    g.Cutting = false;
                    Globals.SpdStable = false;//重新进行稳定主轴
                    Globals.Line = null;//清除当前划切线
                    ReportWorkingProgress(ProcessCmd.CutGroupCmd, g);
                    switch (g.ExitPosMode)
                    {
                        case 0://对准位置
                            {
                                X_Axis.AxisJogAbsWork(g.ChipCHs[0].AlignPoint.X);
                                Y_Axis.AxisJogAbsWork(g.ChipCHs[0].AlignPoint.Y + Globals.KniefAdj);//划切完成移动到对准 划切位置+偏移值
                                T_Axis.AxisJogAbsWork(g.ChipCHs[0].AlignT);
                            }
                            break;
                        case 1://中心位置
                            {
                                X_Axis.AxisJogAbsWork(Globals.ViewCenter.X);
                                Y_Axis.AxisJogAbsWork(Globals.ViewCenter.Y);
                            }
                            break;
                        case 2://起始位置
                            {
                                X_Axis.AxisJogAbsWork(x_Axis.Param.StartPos);
                                Y_Axis.AxisJogAbsWork(y_Axis.Param.StartPos);
                                T_Axis.AxisJogAbsWork(z_Axis.Param.StartPos);
                            }
                            break;
                        case 3://自定义位置
                            {
                                X_Axis.AxisJogAbsWork(g.ExitXpos);
                                Y_Axis.AxisJogAbsWork(g.ExitYpos);
                                T_Axis.AxisJogAbsWork(g.ExitTpos);
                            }
                            break;
                    }
                    WaitAxisMoveDone();//等待移动停止
                    ReportCmdKeyProgress(CmdKey.P0107);
                }
                return g.Complate;
            }
            else
            {
                ReportCmdKeyProgress(CmdKey.P0106);
                return false;
            }
        }
        #endregion
    }
}
