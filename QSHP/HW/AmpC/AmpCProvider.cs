using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSHP.Data;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;

namespace QSHP.HW.AmpC
{
    [XmlType("AmpCProvider")]
    [XmlInclude(typeof(PmacAmpC)), XmlInclude(typeof(CopleyAmpC)), XmlInclude(typeof(G3DrvAmpC)),XmlInclude(typeof(DeltaAmpC))]
    public abstract class AmpCProvider : IAmpCProvider
    {
        /// <summary>
        /// 电机编号
        /// </summary>
        protected int ampCIndex = 1;
        protected float prePos = 0;
        protected float perCTS = 2000;
        const int WaitTime = 500;
        protected int devIndex=0;
        #region 继承属性

        /// <summary>
        /// 电机初始化配置参数
        /// </summary>
        public virtual AxisParams Param
        {
            get;
            set;
        }
        /// <summary>
        /// 连接设备Connecter索引
        /// </summary>
        [XmlAttribute("Driver")]
        public virtual int DevIndex
        {
            get
            {
                return devIndex;
            }
            set
            {
                devIndex = value;
            }
        }

        public virtual float Position
        {
            get
            {
                return RealPos;
            }
        }
        /// <summary>
        /// 驱动使能
        /// </summary>
        public abstract bool Enabled { get; }
        /// <summary>
        /// 回零成功
        /// </summary>
        public abstract bool HomeIsSuccessful { get; }
        /// <summary>
        /// 是否移动到位
        /// </summary>
        public abstract bool IsInPosition { get; }
        /// <summary>
        /// 电机错误
        /// </summary>
        public abstract bool AmpCFault { get; }
        /// <summary>
        /// 正限位
        /// </summary>
        public abstract bool OnPLimit { get; }
        /// <summary>
        /// 负限位
        /// </summary>
        public abstract bool OnNLimit { get; }
        /// <summary>
        /// 当前位置
        /// </summary>
        public abstract float RealPos { get; }
        /// <summary>
        /// 当前速度
        /// </summary>
        public abstract float Speed { get; }
        /// <summary>
        /// 正软限位
        /// </summary>
        public virtual bool SoftPLimit
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 负软限位
        /// </summary>
        public virtual bool SoftNLimit
        {
            get
            {
                return false;
            }
        }
        public virtual float Temp
        {
            get
            {
                return 25;
            }
        }
        public virtual float Current
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// 计数器物理位置
        /// </summary>
        public virtual float PhyPos
        {
            get
            {
                return 0;
            }
        }
        /// <summary>
        /// 驱动器硬件是否连接
        /// </summary>
        public virtual bool Connected
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 驱动器索引编号 注：在驱动器未连接前设置有效
        /// </summary>
        [XmlAttribute("Index")]
        public int AmpCIndex
        {
            get
            {
                return ampCIndex;
            }
            set
            {
                if (!Connected)
                {
                    this.ampCIndex = value;
                }
            }
        }
        #endregion

        #region 抽象方法
        /// <summary>
        /// 初始化驱动器
        /// </summary>
        /// <returns></returns>
        public abstract bool InitAmpC();
        /// <summary>
        /// 驱动器复位
        /// </summary>
        /// <returns></returns>
        public abstract bool ResetAmpC();
        /// <summary>
        /// 使能驱动器
        /// </summary>
        /// <returns></returns>
        public abstract bool EnableAmpC();
        /// <summary>
        /// 失能驱动器
        /// </summary>
        /// <returns></returns>
        public abstract bool DisableAmpC();
        /// <summary>
        /// 设置软件正限位位置
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public abstract bool SetSoftPLimit(float mm);
        /// <summary>
        /// 设置软件负限位位置
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        public abstract bool SetSoftNLimit(float mm);
        /// <summary>
        /// 设置限位信号使能
        /// </summary>
        /// <param name="nLog"></param>
        /// <returns></returns>
        public abstract bool SetLimitSwitch(bool enable);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public abstract bool GetLimitSwitch();
        /// <summary>
        /// 设置回零方式
        /// </summary>
        /// <param name="mode">-1 到负限位</param>
        /// <returns></returns>
        public abstract bool SetHomeMode(Limit mode);
        /// <summary>
        /// 设置回零加速度
        /// </summary>
        /// <param name="acc">mm/s2</param>
        /// <returns></returns>
        public abstract bool SetHomeAcc(float acc);
        /// <summary>
        /// 设置回零速度
        /// </summary>
        /// <param name="speed">mm/s</param>
        /// <returns></returns>
        public abstract bool SetHomeSpeed(float speed);
        /// <summary>
        /// 设置回零偏移(绝对值)
        /// </summary>
        /// <param name="offset">mm</param>
        /// <returns></returns>
        public abstract bool SetHomeOffset(float offset);
        /// <summary>
        /// 设置工作速度
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public abstract bool SetSpeed(float speed);
        /// <summary>
        /// 设置电机加速度
        /// </summary>
        /// <param name="acc">mm/ss</param>
        /// <returns></returns>
        public abstract bool SetAcc(float acc);
        /// <summary>
        /// 电机回零操作
        /// </summary>
        /// <returns></returns>
        public abstract bool GoHome();
        /// <summary>
        /// 电机运动到相对位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        public abstract bool JogInc(float fPos);
        /// <summary>
        /// 电机移动到绝对位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        public abstract bool JogAbs(float fPos);
        /// <summary>
        /// 电机Jog运动
        /// </summary>
        /// <param name="nDir">0：停止运动 1 正向运动 -1 反向运动</param>
        /// <returns></returns>
        public abstract bool JogDir(int nDir);
        /// <summary>
        /// 停止移动
        /// </summary>
        /// <returns></returns>
        public abstract bool JogStop();

        #endregion

        #region 虚方法
        /// <summary>
        /// 初始化驱动器
        /// </summary>
        /// <returns></returns>
        public bool InitAmpC(int num)
        {
            ampCIndex = num;
            return InitAmpC();
        }
        /// <summary>
        /// 关闭驱动器
        /// </summary>
        /// <returns></returns>
        public virtual bool CloseAmpC()
        {
            if (Connected)
            {
                return JogStop();
                //return DisableAmpC();
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 设置坐标位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        public virtual bool SetPrePosition(float fPos)
        {
            if (Connected)
            {
                prePos = fPos;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 设置编码器计数
        /// </summary>
        /// <param name="fCts"></param>
        /// <returns></returns>
        public virtual bool SetCountsPerCTS(float fCts)
        {
            if (Connected)
            {
                perCTS = fCts;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取编码器计数
        /// </summary>
        /// <returns></returns>
        public virtual float GetCountsPerCTS()
        {
            return perCTS;
        }
        /// <summary>
        /// 清除错误
        /// </summary>
        /// <returns></returns>
        public virtual bool ClearAmpCFault()
        {
            return true;
        }
        /// <summary>
        /// 回零
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="fVel"></param>
        /// <param name="fAcc"></param>
        /// <param name="fOffSet"></param>
        /// <returns></returns>
        public bool GoHome(Limit flag, float fVel, float fAcc, float fOffSet)
        {
            bool ret = SetHomeMode(flag);
            ret &= SetHomeAcc(fAcc);
            switch (flag)
            {
                case Limit.PLimit:
                    {
                        ret &= SetHomeSpeed(fVel);
                        ret &= SetHomeOffset(-fOffSet);
                    } break;
                case Limit.NLimit:
                    {
                        ret &= SetHomeSpeed(-fVel);
                        ret &= SetHomeOffset(fOffSet);
                    } break;
                case Limit.HomeLimit:
                    {
                        ret &= SetHomeSpeed(-fVel);
                        ret &= SetHomeOffset(fOffSet);
                    } break;
                case Limit.UserLimit:
                    {
                        ret &= SetHomeSpeed(-fVel);
                        ret &= SetHomeOffset(fOffSet);
                    } break;
                default:
                    {
                        ret &= SetHomeSpeed(fVel);
                        ret &= SetHomeOffset(fOffSet);
                    } break;
            }
            ret &= GoHome();
            return ret;
        }
        /// <summary>
        /// 相对增量式移动位置
        /// </summary>
        /// <param name="fVel"></param>
        /// <param name="fAcc"></param>
        /// <param name="fInc"></param>
        /// <returns></returns>
        public bool JogInc(float fVel, float fAcc, float fInc)
        {
            bool flag = SetSpeed(fVel);
            flag &= SetAcc(fAcc);
            flag &= JogInc(fInc);
            return flag;
        }
        /// <summary>
        /// 绝对值方式移动位置
        /// </summary>
        /// <param name="fVel"></param>
        /// <param name="fAcc"></param>
        /// <param name="fAbsPos"></param>
        /// <returns></returns>
        public bool JogAbs(float fVel, float fAcc, float fAbsPos)
        {
            bool flag = SetSpeed(fVel);
            flag &= SetAcc(fAcc);
            flag &= JogAbs(fAbsPos);
            return flag;
        }
        /// <summary>
        /// 持续定向运动
        /// </summary>
        /// <param name="fVel"></param>
        /// <param name="fAcc"></param>
        /// <param name="nDir"></param>
        /// <returns></returns>
        public virtual bool JogDir(float fVel, float fAcc, int nDir)
        {
            bool flag = SetSpeed(fVel);
            flag &= SetAcc(fAcc);
            flag &= JogDir(nDir);
            return flag;
        }
        /// <summary>
        /// 初始化系统参数
        /// </summary>
        /// <returns></returns>
        public bool InitSystemParam()
        {
            if (Param != null)
            {
                bool flag = true;
                prePos = Param.StartPos;
                flag &= SetCountsPerCTS(Param.PerCTS);
                flag &= EnableAmpC();
                //flag &= SetPrePosition(Param.StartPos);
                flag &= SetAcc(Param.WorkVel);
                flag &= SetSpeed(Param.WorkVel);
                flag &= JogStop();
                return flag;
            }
            return true;
        }
        public bool AxisJogDirSlow(int dir)
        {
            if (Param != null)
            {
                return JogDir(Param.JogVelSlow, Param.JogAccSlow, dir); ;
            }
            else
            {
                return false;
            }
        }

        public bool AxisJogDir(int dir)
        {
            if (Param != null)
            {
                return JogDir(Param.JogVel, Param.JogAcc, dir);
            }
            else
            {
                return false;
            }
        }
        public bool AxisJogAbsWork(float abs, bool wait = false)
        {
            if (Param != null)
            {
                if (JogAbs(Param.WorkVel, Param.WorkAcc, abs))
                {
                    if (wait)
                    {
                        int i = WaitTime;
                        do
                        {
                            i--;
                            System.Threading.Thread.Sleep(20);
                        } while (!IsInPosition && i > 0);
                        return IsInPosition;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool AxisJogIncWork(float inc, bool wait = false)
        {
            if (Param != null)
            {
                if (JogInc(Param.WorkVel, Param.WorkAcc, inc))
                {
                    if (wait)
                    {
                        int i = WaitTime;
                        do
                        {
                            i--;
                            System.Threading.Thread.Sleep(20);
                        } while (!IsInPosition && i > 0);
                        return IsInPosition;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool AxisGoHomeWork(bool wait = false)
        {
            if (Param != null)
            {
                bool flag = JogStop();
                flag &= SetLimitSwitch(false);
                flag &= SetSoftNLimit(0);
                flag &= SetSoftPLimit(0);
                if (wait)
                {
                    flag &= GoHome(Param.HomeMode, Param.HomeVel, Param.HomeAcc, Param.HomeOffset);
                    int i = WaitTime;
                    do
                    {
                        i--;
                        System.Threading.Thread.Sleep(20);
                    } while (!HomeIsSuccessful && i > 0);
                    flag &= SetPrePosition(Param.StartPos);
                    flag &= SetLimitSwitch(true);
                    flag &= SetSoftPLimit(Param.SoftPlimit);
                    flag &= SetSoftNLimit(Param.SoftNlimit);
                    return flag;
                }
                else
                {
                    return flag &= GoHome(Param.HomeMode, Param.HomeVel, Param.HomeAcc, Param.HomeOffset);
                }
            }
            else
            {
                return false;
            }
        }

        public bool AxisAotoEscapeLimit(float mm = 10)
        {
            if (Enabled)
            {
                if (OnNLimit)
                {
                   return AxisJogIncWork(mm);
                }
                if (OnPLimit)
                {
                    return AxisJogIncWork(-mm);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 释放对象
        /// </summary>
        public virtual void Dispose()
        {
            if (Enabled)
            {
                CloseAmpC();
            }
        }
    
        #endregion

    }
           
}
