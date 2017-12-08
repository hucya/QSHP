using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using CMO;
using QSHP.Data;

namespace QSHP.HW.AmpC
{
    [XmlType("DeltaAmpC",Namespace="")]
    public class DeltaAmpC: AmpCProvider
    {
        private DeltaAmpObj motor;
        private CanOpenConnecter connecter = null;
        public DeltaAmpC()
        {
            connecter = CanOpenConnecter.GetInstance();
            motor = new DeltaAmpObj();
        }
        public DeltaAmpC(int index):this()
        {
            this.ampCIndex = index;
        }
        #region 属性

        /// <summary>
        /// 电机初始化配置参数
        /// </summary>
        //public override AxisParams Param
        //{
        //    get
        //    {
        //        return param;
        //    }
        //    set
        //    {
        //        param = value as CopleyAxisParams;
        //    }
        //}
        /// <summary>
        /// 驱动使能
        /// </summary>
        public override bool Enabled
        {
            get
            {
                if (Connected)
                {
                    return motor.Enabled;
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
                    return motor.HomeSucessful;
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
                    return motor.TargetReched;
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
                    return motor.Fault;
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
                    return (float)motor.Current;
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
                    return (float)motor.AmpTemp;
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
                    return false; 
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

                    return false;
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
                    return motor.GetMotorPosition();
                }
                else
                {
                    return 0;
                }
            }
        }

        public override float Position
        {
            get
            {
                if (Enabled)
                {
                    return motor.PositionActual;//PDO位置
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
                    return motor.GetMotorSpeed();
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
                    return false;
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
                    return false;
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
                    connecter = CanOpenConnecter.GetInstance();
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
                bool flag = motor.Initlize(connecter.Pcan, (short)ampCIndex);
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
                return (float)motor.PerCTS;
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
            motor.SetMotorPosLimit( mm );
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
            motor.SetMotorNegLimit(mm);
            return true;
        }
        /// <summary>
        /// 设置限位信号使能
        /// </summary>
        /// <param name="nLog"></param>
        /// <returns></returns>
        public override bool SetLimitSwitch(bool enable)
        {
            
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
                motor.PerCTS = fCts;
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
            return true;
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
                        motor.SetMotorHomeMethod(1);
                    }
                    break;
                case Limit.NLimit:
                    {
                        motor.SetMotorHomeMethod(2);
                    }
                    break;
                case Limit.HomeLimit:
                    {
                        motor.SetMotorHomeMethod(3);
                    }
                    break;
                case Limit.UserLimit:
                    {
                        motor.SetMotorHomeMethod(4);
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
            return motor.SetMotorHomeAcc(acc); ;
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
          
            return motor.SetMotorHomeSpeed(speed);
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
            return motor.SetMotorHomeOffset(offset);
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

            return motor.SetMotorSpeed(speed);
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
            motor.SetMotorAcc(acc);
            return motor.SetMotorDec(acc); ;
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
                motor.JogInc(fPos);
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
                SetLimitSwitch(true);
                return motor.GoHome();
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
                
                return motor.JogAbs(fPos); ;
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
                return motor.JogDir(nDir);
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
                return motor.JogStop();
            }
            else
            {
                return false;
            }
        }

        public override void Dispose()
        {
            motor.Dispose();
            base.Dispose();
        }
        #endregion
    }
}
