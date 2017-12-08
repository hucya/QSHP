using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSHP.Data;
using QSHP.HW;
using System.Xml.Serialization;

namespace QSHP.HW.AmpC
{
    [XmlType("PmacAmpC",Namespace="")]
    public class PmacAmpC : AmpCProvider
    {
        private PmacConnecter connecter = null;
        private double pos = 0.0f;
        private double speed = 0.0f;
        private uint modeControl = 1;
        private PmacAxisParams param;
        private bool limit = false;
        public PmacAmpC()
        {
            if (param == null)
            {
                param = new PmacAxisParams();
            }
        }

        #region 属性
        /// <summary>
        /// 电机初始化配置参数
        /// </summary>
        public override AxisParams Param
        {
            get
            {
                return param;
            }
            set
            {
                param = value as PmacAxisParams;
            }
        }

        /// <summary>
        /// 驱动使能
        /// </summary>
        public override bool Enabled
        {
            get
            {
                if (Connected)
                {
                    return connecter.Pmac.MotorEnabled[DevIndex, AmpCIndex - 1];
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 回零成功
        /// </summary>
        public override bool HomeIsSuccessful
        {
            get
            {
                if (Connected)
                {
                    return connecter.Pmac.MotorHomeComplete[DevIndex, AmpCIndex - 1] && IsInPosition;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 是否移动到位
        /// </summary>
        public override bool IsInPosition
        {
            get
            {
                if (Connected)
                {
                    return connecter.Pmac.MotorInPosition[DevIndex, AmpCIndex - 1];
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 电机错误
        /// </summary>
        public override bool AmpCFault
        {
            get
            {
                if (Connected)
                {
                    return connecter.Pmac.MotorAmpFault[DevIndex, AmpCIndex - 1] || connecter.Pmac.MotorWarnFError[DevIndex, AmpCIndex - 1];
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 正限位
        /// </summary>
        public override bool OnPLimit
        {
            get
            {
                if (Connected)
                {
                    return connecter.Pmac.MotorOnPosLimit[DevIndex, AmpCIndex - 1];
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 负限位
        /// </summary>
        public override bool OnNLimit
        {
            get
            {
                if (Connected)
                {
                    return connecter.Pmac.MotorOnNegLimit[DevIndex, AmpCIndex - 1];
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 当前位置
        /// </summary>
        public override float RealPos
        {
            get
            {
                if (Connected)
                {
                    connecter.Pmac.GetCommandedPos(DevIndex, AmpCIndex - 1, perCTS, out pos);//与设置值一致无误差
                    //connecter.Pmac.GetPosition(DevIndex, AmpCIndex - 1, perCTS, out pos);
                    return (float)(pos + prePos);
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 当前速度
        /// </summary>
        public override float Speed
        {
            get
            {
                if (Connected)
                {
                    connecter.Pmac.GetVelocity(DevIndex, AmpCIndex - 1, 0.4, out speed);
                    return (float)speed;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 当前电流
        /// </summary>
        public override float Current
        {
           get
            {
                if (Connected)
                {
                    return connecter.GetFloatValue(string.Format("M{0}76", AmpCIndex));
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 正软限位
        /// </summary>
        public override bool SoftPLimit
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 负软限位
        /// </summary>
        public override bool SoftNLimit
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 计数器物理位置
        /// </summary>
        public override float PhyPos
        {
            get
            {
                if (Connected)
                {
                    float pos = connecter.GetFloatValue(string.Format("M{0}01", AmpCIndex));
                    pos /= perCTS;
                    return pos;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 驱动器硬件是否连接
        /// </summary>
        public override bool Connected
        {
            get
            {
                if (connecter == null)
                {
                    connecter = PmacConnecter.GetInstance();
                }
                return connecter.Connected;
            }
        }

        #endregion

        #region 抽象方法
        /// <summary>
        /// 初始化驱动器
        /// </summary>
        /// <returns></returns>
        public override bool InitAmpC()
        {
            if (!Connected)
            {
                connecter.DevIndex = devIndex;
                connecter.ConnectDriver();
            }
            if (Connected)
            {
                bool flag = connecter.SendCommand(string.Format("#{0}J/", AmpCIndex));//设置为闭环控制
                return flag;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 驱动器复位
        /// </summary>
        /// <returns></returns>
        public override bool ResetAmpC()
        {
            return connecter.ResetPmac();
        }
        /// <summary>
        /// 使能驱动器
        /// </summary>
        /// <returns></returns>
        public override bool EnableAmpC()
        {
            return connecter.SendCommand(string.Format("I{0}00=1", AmpCIndex));
        }
        /// <summary>
        /// 失能驱动器
        /// </summary>
        /// <returns></returns>
        public override bool DisableAmpC()
        {
            return connecter.SendCommand(string.Format("I{0}00=0", AmpCIndex));
        }
        /// <summary>
        /// 设置坐标位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        public override bool SetPrePosition(float fPos)
        {
            prePos = fPos;
            bool flag = true;
            if (Connected)
            {
                string str = string.Format("M{0}64={1}*{2}*3072", AmpCIndex, fPos, perCTS);
                flag = connecter.SendCommand(str);
            }
            //str = string.Format("M{0}62=0", AmpCIndex, fPos, perCTS);
            //flag = connecter.SendCommand(str);
            return flag;
        }
        /// <summary>
        /// 设置软件正限位位置
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public override bool SetSoftPLimit(float mm)
        {
            return connecter.SendCommand(string.Format("I{0}13={1}*{2}", AmpCIndex, limit? mm - prePos: 0 , perCTS));
        }
        /// <summary>
        /// 设置软件负限位位置
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public override bool SetSoftNLimit(float mm)
        {
            return connecter.SendCommand(string.Format("I{0}14={1}*{2}", AmpCIndex, limit ? mm - prePos : 0, perCTS));
        }
        /// <summary>
        /// 设置限位信号使能
        /// </summary>
        /// <param name="nLog"></param>
        /// <returns></returns>
        public override bool SetLimitSwitch(bool enable)
        {
            if (param != null)
            {
                modeControl = param.ModeControl;
            }
            if (!enable)
            {
                modeControl |= 0x20001;
            }
            else
            {
                modeControl &= 0xFFFDFFFF;
            }
            limit = enable;
            return connecter.SendCommand(string.Format("I{0}24={1}", AmpCIndex, modeControl));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public override bool GetLimitSwitch()
        {
            return (modeControl & 0x20000) > 0;
        }
        /// <summary>
        /// 设置回零方式
        /// </summary>
        /// <param name="mode">-1 到负限位</param>
        /// <returns></returns>
        public override bool SetHomeMode(Limit mode)
        {
            bool flag =true;//= connecter.SendCommand(string.Format("I70{0}2=2", AmpCIndex));//设置捕捉模式
            int value = 0;
            switch (mode)
            {
                case Limit.PLimit:
                    {
                        value = 1;
                        connecter.SendCommand(string.Format("I70{0}2={1}", AmpCIndex,param.PosLimitCaptureMode));//设置捕捉模式
                    } break;
                case Limit.NLimit:
                    {
                        value = 2;
                        connecter.SendCommand(string.Format("I70{0}2={1}", AmpCIndex, param.NegLimitCaptureMode));//设置捕捉模式
                    } break;
                case Limit.HomeLimit:
                    {
                        value = 0;
                        connecter.SendCommand(string.Format("I70{0}2={1}", AmpCIndex, param.HomeLimitCaptureMode));//设置捕捉模式
                    } break;
                case Limit.UserLimit:
                    {
                        value = 3;
                        connecter.SendCommand(string.Format("I70{0}2={1}", AmpCIndex, param.UserLimitCaptureMode));//设置捕捉模式
                    }; break;
                default:
                    {
                        value = 0;
                    } break;
            }
            return flag & connecter.SendCommand(string.Format("I70{0}3={1}", AmpCIndex, value));
        }
        /// <summary>
        /// 设置回零加速度
        /// </summary>
        /// <param name="acc">mm/s2</param>
        /// <returns></returns>
        public override bool SetHomeAcc(float acc)
        {
            //return connecter.SendCommand(string.Format("I{0}19={1}*{2}/10000", AmpCIndex, acc, perCTS));
            return connecter.SendCommand(string.Format("I{0}19={1}", AmpCIndex, acc));
        }
        /// <summary>
        /// 设置回零速度
        /// </summary>
        /// <param name="speed">mm/s</param>
        /// <returns></returns>
        public override bool SetHomeSpeed(float speed)
        {
            return connecter.SendCommand(string.Format("I{0}23={1}*{2}/1000", AmpCIndex, speed, perCTS));
        }
        /// <summary>
        /// 设置回零偏移(绝对值)
        /// </summary>
        /// <param name="offset">mm</param>
        /// <returns></returns>
        public override bool SetHomeOffset(float offset)
        {
            return connecter.SendCommand(string.Format("I{0}26={1}*{2}*16", AmpCIndex, offset, perCTS));
        }
        /// <summary>
        /// 设置工作速度
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public override bool SetSpeed(float speed)
        {
            return connecter.SendCommand(string.Format("I{0}22={1}*{2}/1000", AmpCIndex, speed, perCTS));
        }
        /// <summary>
        /// 设置电机加速度
        /// </summary>
        /// <param name="acc">mm/ss</param>
        /// <returns></returns>
        public override bool SetAcc(float acc)
        {
            connecter.SendCommand(string.Format("I{0}15={1}*{2}/10000", AmpCIndex, acc, perCTS));
            return connecter.SendCommand(string.Format("I{0}19={1}*{2}/10000", AmpCIndex, acc, perCTS));
            //connecter.SendCommand(string.Format("I{0}15={1}", AmpCIndex, acc));
            //return connecter.SendCommand(string.Format("I{0}19={1}", AmpCIndex, acc));
        }
        /// <summary>
        /// 设置电机轴比系数
        /// </summary>
        /// <param name="fCts"></param>
        /// <returns></returns>
        public override bool SetCountsPerCTS(float fCts)
        {
            if (connecter.Connected)
            {
                if (fCts < 1)
                    fCts = 1;
                perCTS = fCts;
                switch (ampCIndex)
                {
                    case 1://   X-Axis
                        {
                            return connecter.SendCommand(string.Format("M191={0}", perCTS));
                        }
                    case 2://   Y-Axis
                        {
                            return connecter.SendCommand(string.Format("M292={0}", perCTS));
                        }
                    case 3://   Z-Axis
                        {
                            return connecter.SendCommand(string.Format("M393={0}", perCTS));
                        }
                    case 4://   A-Axis
                        {
                            return connecter.SendCommand(string.Format("M491={0}", perCTS));
                        }
                    default:
                        { } break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 电机回零操作
        /// </summary>
        /// <returns></returns>
        public override bool GoHome()
        {
            if (Enabled)
            {
                return connecter.SendCommand(string.Format("#{0}HM", AmpCIndex));
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 电机运动到相对位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        public override bool JogInc(float fPos)
        {
            if (Enabled)
            {
                return connecter.SendCommand(string.Format("#{0}J:{1}", AmpCIndex, fPos * perCTS));
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 电机移动到绝对位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        public override bool JogAbs(float fPos)
        {
            if (Enabled)
            {
                
                return connecter.SendCommand(string.Format("#{0}J={1}", AmpCIndex, fPos * perCTS));
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 电机Jog运动
        /// </summary>
        /// <param name="nDir">0：停止运动 1 正向运动 -1 反向运动</param>
        /// <returns></returns>
        public override bool JogDir(int nDir)
        {
            if (Enabled)
            {
                if (nDir == 1)
                {
                    return connecter.SendCommand(string.Format("#{0}J+", AmpCIndex));
                }
                else if (nDir == -1)
                {
                    return connecter.SendCommand(string.Format("#{0}J-", AmpCIndex));
                }
                else
                {
                    return connecter.SendCommand(string.Format("#{0}J/", AmpCIndex));
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 停止移动
        /// </summary>
        /// <returns></returns>
        public override bool JogStop()
        {
            if (Enabled)
            {
                return connecter.SendCommand(string.Format("#{0}J/", AmpCIndex));
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
