using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMO;
using QSHP.Data;
using System.Xml.Serialization;

namespace QSHP.HW.AmpC
{
    [XmlType("CopleyAmpC",Namespace="")]
    public class CopleyAmpC : AmpCProvider
    {
        const int IN_PLIMIT = 1;
        const int IN_NLIMIT = 2;
        const int IN_HLIMIT = 3;
        private CopleyAmpObj motor;
        private CopleyConnecter connecter = null;
        HomeSettingsObj home;
        ProfileSettingsObj proJog ;
        CML_AMP_EVENT e;
        CML_EVENT_STATUS status;
        CML_AMP_FAULT err;
        CopleyAxisParams param;
        public CopleyAmpC()
        {
            connecter = CopleyConnecter.GetInstance();
            motor = new CopleyAmpObj();
            home = new HomeSettingsObj();
            proJog = new ProfileSettingsObj();
            e = new CML_AMP_EVENT();
            status = new CML_EVENT_STATUS();
            param = new CopleyAxisParams();
            err = new CML_AMP_FAULT();
        }
        public CopleyAmpC(int index):this()
        {
            this.ampCIndex = index;
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
                param = value as CopleyAxisParams;
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
                    return motor.IsHardwareEnabled && motor.IsSoftwareEnabled;
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
                if (Enabled)
                {
                    return motor.IsReferenced && IsInPosition;
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
                if (Enabled)
                {
                    motor.ReadEventMask(ref e);
                    return (e & CML_AMP_EVENT.AMPEVENT_MOVE_DONE) == CML_AMP_EVENT.AMPEVENT_MOVE_DONE;
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
                if (Enabled)
                {
                    motor.ReadFaults(ref err);
                    return (uint)err > 0;
                }
                else
                {
                    return true;
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
                if (Enabled)
                {
                    return (float)motor.CurrentActual/100;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// 当前温度
        /// </summary>
        public override float Temp
        {
            get
            {
                if (Enabled)
                {
                    return (float) motor.AmpTemp;
                }
                else
                {
                    return 0;
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
                if (Enabled)
                {
                    motor.ReadEventStatus(ref status);
                    return (status & CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT) == CML_EVENT_STATUS.EVENT_STATUS_POSITIVE_LIMIT;
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
                if (Enabled)
                {
                    motor.ReadEventStatus(ref status);
                    return (status & CML_EVENT_STATUS.EVENT_STATUS_NEGATIVE_LIMIT) == CML_EVENT_STATUS.EVENT_STATUS_NEGATIVE_LIMIT;
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
                if (Enabled)
                {
                    return (float)motor.PositionActual;
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
                if (Enabled)
                {
                    return (float)motor.VelocityActual;
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
                if (Enabled)
                {
                    motor.ReadEventMask(ref e);
                    return (e & CML_AMP_EVENT.AMPEVENT_SOFTWARE_LIMIT_POSITIVE) == CML_AMP_EVENT.AMPEVENT_SOFTWARE_LIMIT_POSITIVE;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 负软限位
        /// </summary>
        public override bool SoftNLimit
        {
            get
            {
                if (Enabled)
                {
                    motor.ReadEventMask(ref e);
                    return (e & CML_AMP_EVENT.AMPEVENT_SOFTWARE_LIMIT_NEGATIVE) == CML_AMP_EVENT.AMPEVENT_SOFTWARE_LIMIT_NEGATIVE;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 计数器物理位置
        /// </summary>
        public override float PhyPos
        {
            get
            {
                if (Enabled)
                {
                    return (float)motor.PositionActual;
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
                    connecter = CopleyConnecter.GetInstance();
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
                bool flag = motor.Initialize(connecter.Pcan, (short)ampCIndex);
                motor.HomeSettings = home;
                motor.ProfileSettings = proJog;
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
            if (!Connected)
            {
                return false;
            }
            motor.Reset();
            return true;
        }
        /// <summary>
        /// 关闭反初始化电机
        /// </summary>
        /// <returns></returns>
        public override bool CloseAmpC()
        {
            if (!Connected)
            {
                return false;
            }
            DisableAmpC();
            motor.ReInit();
            return true;
        }
        /// <summary>
        /// 获取电机分辨率
        /// </summary>
        /// <returns></returns>
        public override float GetCountsPerCTS()
        {
            if (!Connected)
            {
                return base.GetCountsPerCTS();
            }
            else
            {
                return (float)motor.CountsPerUnit;
            }
        }
        /// <summary>
        /// 清除驱动器故障
        /// </summary>
        /// <returns></returns>
        public override bool ClearAmpCFault()
        {
            if (!Connected)
            {
                return false;
            }
            motor.ClearFaults();
            return true;
        }
        /// <summary>
        /// 使能驱动器
        /// </summary>
        /// <returns></returns>
        public override bool EnableAmpC()
        {
            if (!Connected)
            {
                return false;
            }
            motor.Enable();
            return true;
        }
        /// <summary>
        /// 失能驱动器
        /// </summary>
        /// <returns></returns>
        public override bool DisableAmpC()
        {
            if (!Connected)
            {
                return false;
            }
            motor.Disable();
            return true;
        }
        /// <summary>
        /// 设置坐标位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        public override bool SetPrePosition(float fPos)
        {
            if (!Connected)
            {
                return false;
            }
            motor.PositionActual = fPos;
            return true;
        }
        /// <summary>
        /// 设置软件正限位位置
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public override bool SetSoftPLimit(float mm)
        {
            if (!Connected)
            {
                return false;
            }
            motor.SoftPositionPosLimit = mm * perCTS;
            return true;
        }
        /// <summary>
        /// 设置软件负限位位置
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public override bool SetSoftNLimit(float mm)
        {
            if (!Connected)
            {
                return false;
            }
            motor.SoftPositionNegLimit = mm * perCTS;
            return true;
        }
        /// <summary>
        /// 设置限位信号使能
        /// </summary>
        /// <param name="nLog"></param>
        /// <returns></returns>
        public override bool SetLimitSwitch(bool enable)
        {
            if (!Connected)
            {
                return false;
            }
            if (enable)
            {
                if (param != null)
                {
                    motor.WriteInputConfig(IN_PLIMIT, (CML_INPUT_PIN_CONFIG)param.PLimitMode);
                    motor.WriteInputConfig(IN_NLIMIT, (CML_INPUT_PIN_CONFIG)param.NLimitMode);
                }
                else
                {
                    motor.WriteInputConfig(IN_PLIMIT, CML_INPUT_PIN_CONFIG.INPUT_CONFIGURATION_POSITIVE_LIMIT_HIGH);
                    motor.WriteInputConfig(IN_NLIMIT, CML_INPUT_PIN_CONFIG.INPUT_CONFIGURATION_NEGATIVE_LIMIT_HIGH);
                }
            }
            else
            {
                motor.WriteInputConfig(IN_PLIMIT, CML_INPUT_PIN_CONFIG.INPUT_CONFIGURATION_NONE);
                motor.WriteInputConfig(IN_NLIMIT, CML_INPUT_PIN_CONFIG.INPUT_CONFIGURATION_NONE);
            }
            return true;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fCts"></param>
        /// <returns></returns>
        public override bool SetCountsPerCTS(float fCts)
        {
            if (Connected)
            {
                motor.CountsPerUnit = fCts;
                perCTS = fCts;
                return true;
            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public override bool GetLimitSwitch()
        {
            CML_INPUT_PIN_CONFIG cfg=CML_INPUT_PIN_CONFIG.INPUT_CONFIGURATION_NONE;
            motor.ReadInputConfig(IN_NLIMIT,ref cfg);
            return cfg!= CML_INPUT_PIN_CONFIG.INPUT_CONFIGURATION_NONE;
        }
        /// <summary>
        /// 设置回零方式
        /// </summary>
        /// <param name="mode">-1 到负限位</param>
        /// <returns></returns>
        public override bool SetHomeMode(Limit mode)
        {
            if (!Connected)
            {
                return false;
            }
            switch (mode)
            {
                case Limit.PLimit:
                    {
                        home.HomeMethod = CML_HOME_METHOD.CHOME_POSITIVE_LIMIT;
                    } break;
                case Limit.NLimit:
                    {
                        home.HomeMethod = CML_HOME_METHOD.CHOME_NEGATIVE_LIMIT;
                    } break;
                case Limit.HomeLimit:
                    {
                        home.HomeMethod = CML_HOME_METHOD.CHOME_POSITIVE_HOME;
                    } break;
                case Limit.UserLimit:
                    {
                        home.HomeMethod = CML_HOME_METHOD.CHOME_NEGATIVE_HOME;
                    }; break;
            }
            return true;
        }
        /// <summary>
        /// 设置回零加速度
        /// </summary>
        /// <param name="acc">mm/s2</param>
        /// <returns></returns>
        public override bool SetHomeAcc(float acc)
        {
            if (!Connected)
            {
                return false;
            }
            home.HomeAccel = acc;
            return true;
        }
        /// <summary>
        /// 设置回零速度
        /// </summary>
        /// <param name="speed">mm/s</param>
        /// <returns></returns>
        public override bool SetHomeSpeed(float speed)
        {
            if (!Connected)
            {
                return false;
            }
            home.HomeVelFast = Math.Abs(speed);
            home.HomeVelSlow = home.HomeVelFast;
            return true;
        }
        /// <summary>
        /// 设置回零偏移(绝对值)
        /// </summary>
        /// <param name="offset">mm</param>
        /// <returns></returns>
        public override bool SetHomeOffset(float offset)
        {
            if (!Connected)
            {
                return false;
            }
            home.HomeOffset = offset;
            return true;
        }
        /// <summary>
        /// 设置工作速度
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public override bool SetSpeed(float speed)
        {
            if (!Connected)
            {
                return false;
            }

            proJog.ProfileVel = Math.Abs(speed);
            return true;
        }
        /// <summary>
        /// 设置电机加速度
        /// </summary>
        /// <param name="acc">mm/ss</param>
        /// <returns></returns>
        public override bool SetAcc(float acc)
        {
            if (!Connected)
            {
                return false;
            }
            proJog.ProfileAccel = acc;
            proJog.ProfileDecel = acc;
            proJog.ProfileAbort = acc;
            return true;
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
                proJog.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
                motor.ProfileSettings = proJog;
                motor.MoveRel(fPos);
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
            if (!Connected)
            {
                return false;
            }
            if (Enabled)
            {
                motor.HomeSettings = home;
                SetLimitSwitch(true);
                motor.GoHome();
                return true;
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
                proJog.ProfileType = CML_PROFILE_TYPE.PROFILE_TRAP;
                motor.ProfileSettings = proJog;
                motor.MoveAbs(fPos);
                return true;
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
                proJog.ProfileType = CML_PROFILE_TYPE.PROFILE_VELOCITY;
                motor.ProfileSettings = proJog;
                if (nDir == 1)
                {
                    motor.MoveAbs(1);
                }
                else if (nDir == -1)
                {
                    motor.MoveAbs(-1);
                }
                else
                {
                    motor.HaltMode = CML_HALT_MODE.HALT_DECEL;
                    motor.HaltMove();
                }
                return true;
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
                motor.HaltMode = CML_HALT_MODE.HALT_DECEL;
                motor.HaltMove();
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Dispose()
        {
            motor.Dispose();
            proJog.Dispose();
            base.Dispose();
        }
        #endregion
    }
}
