using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSHP.Data;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace QSHP.HW.AmpC
{
    [XmlRoot("IAmpCProvider")]
    [XmlType("AmpCProvider")]
    [XmlInclude(typeof(PmacAmpC)), XmlInclude(typeof(CopleyAmpC)), XmlInclude(typeof(G3DrvAmpC))]
    public interface IAmpCProvider : IDisposable
    {

        #region 属性

        /// <summary>
        /// 电机初始化配置参数
        /// </summary>
        AxisParams Param
        {
            get;
            set;
        }
        /// <summary>
        /// 连接设备Connecter索引
        /// </summary>
        int DevIndex { get; set; }
        /// <summary>
        /// 驱动使能
        /// </summary>
        bool Enabled { get; }
        /// <summary>
        /// 回零成功
        /// </summary>
        bool HomeIsSuccessful { get; }
        /// <summary>
        /// 是否移动到位
        /// </summary>
        bool IsInPosition { get; }
        /// <summary>
        /// 电机错误
        /// </summary>
        bool AmpCFault { get; }
        /// <summary>
        /// 正限位
        /// </summary>
        bool OnPLimit { get; }
        /// <summary>
        /// 负限位
        /// </summary>
        bool OnNLimit { get; }
        /// <summary>
        /// 当前位置
        /// </summary>
        float RealPos { get; }
        /// <summary>
        /// 当前速度
        /// </summary>
        float Speed { get; }
        /// <summary>
        /// 电机温度
        /// </summary>
        float Temp { get; }
        /// <summary>
        /// 电机电流
        /// </summary>
        float Current { get; }
        /// <summary>
        /// 正软限位
        /// </summary>
        bool SoftPLimit
        {
            get;
        }
        /// <summary>
        /// 负软限位
        /// </summary>
        bool SoftNLimit
        {
            get;
        }
        /// <summary>
        /// 计数器物理位置
        /// </summary>
        float PhyPos
        {
            get;
        }
        /// <summary>
        /// 驱动器硬件是否连接
        /// </summary>
        bool Connected
        {
            get;
        }
        /// <summary>
        /// 驱动器索引编号 注：在驱动器未连接前设置有效
        /// </summary>
        int AmpCIndex
        {
            get;
            set;
        }

        float Position
        {
            get;
        }
        #endregion

        #region 抽象方法
        /// <summary>
        /// 初始化驱动器
        /// </summary>
        /// <returns></returns>
        bool InitAmpC();
        /// <summary>
        /// 关闭驱动器
        /// </summary>
        /// <returns></returns>
        bool CloseAmpC();
        /// <summary>
        /// 驱动器复位
        /// </summary>
        /// <returns></returns>
        bool ResetAmpC();
        /// <summary>
        /// 使能驱动器
        /// </summary>
        /// <returns></returns>
        bool EnableAmpC();
        /// <summary>
        /// 失能驱动器
        /// </summary>
        /// <returns></returns>
        bool DisableAmpC();
        /// <summary>
        /// 设置坐标位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        bool SetPrePosition(float fPos);
        /// <summary>
        /// 设置软件正限位位置
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        bool SetSoftPLimit(float mm);
        /// <summary>
        /// 设置软件负限位位置
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        bool SetSoftNLimit(float mm);
        /// <summary>
        /// 设置限位信号使能
        /// </summary>
        /// <param name="nLog"></param>
        /// <returns></returns>
        bool SetLimitSwitch(bool enable);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        bool GetLimitSwitch();
        /// <summary>
        /// 设置回零方式
        /// </summary>
        /// <param name="mode">-1 到负限位</param>
        /// <returns></returns>
        bool SetHomeMode(Limit mode);
        /// <summary>
        /// 设置回零加速度
        /// </summary>
        /// <param name="acc">mm/s2</param>
        /// <returns></returns>
        bool SetHomeAcc(float acc);
        /// <summary>
        /// 设置回零速度
        /// </summary>
        /// <param name="speed">mm/s</param>
        /// <returns></returns>
        bool SetHomeSpeed(float speed);
        /// <summary>
        /// 设置回零偏移(绝对值)
        /// </summary>
        /// <param name="offset">mm</param>
        /// <returns></returns>
        bool SetHomeOffset(float offset);
        /// <summary>
        /// 设置工作速度
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        bool SetSpeed(float speed);
        /// <summary>
        /// 设置电机加速度
        /// </summary>
        /// <param name="acc">mm/ss</param>
        /// <returns></returns>
        bool SetAcc(float acc);
        /// <summary>
        /// 电机回零操作
        /// </summary>
        /// <returns></returns>
        bool GoHome();
        /// <summary>
        /// 电机运动到相对位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        bool JogInc(float fPos);
        /// <summary>
        /// 电机移动到绝对位置
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        bool JogAbs(float fPos);
        /// <summary>
        /// 电机Jog运动
        /// </summary>
        /// <param name="nDir">0：停止运动 1 正向运动 -1 反向运动</param>
        /// <returns></returns>
        bool JogDir(int nDir);
        /// <summary>
        /// 停止移动
        /// </summary>
        /// <returns></returns>
        bool JogStop();

        #endregion

        #region 虚方法
        /// <summary>
        /// 初始化驱动器
        /// </summary>
        /// <returns></returns>
        bool InitAmpC(int num);
        /// <summary>
        /// 设置编码器计数
        /// </summary>
        /// <param name="fCts"></param>
        /// <returns></returns>
        bool SetCountsPerCTS(float fCts);
        /// <summary>
        /// 获取编码器计数
        /// </summary>
        /// <returns></returns>
        float GetCountsPerCTS();
        /// <summary>
        /// 清除错误
        /// </summary>
        /// <returns></returns>
        bool ClearAmpCFault();
        /// <summary>
        /// 回零
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="fVel"></param>
        /// <param name="fAcc"></param>
        /// <param name="fOffSet"></param>
        /// <returns></returns>
        bool GoHome(Limit flag, float fVel, float fAcc, float fOffSet);
        /// <summary>
        /// 相对增量式移动位置
        /// </summary>
        /// <param name="fVel"></param>
        /// <param name="fAcc"></param>
        /// <param name="fInc"></param>
        /// <returns></returns>
        bool JogInc(float fVel, float fAcc, float fInc);
        /// <summary>
        /// 绝对值方式移动位置
        /// </summary>
        /// <param name="fVel"></param>
        /// <param name="fAcc"></param>
        /// <param name="fAbsPos"></param>
        /// <returns></returns>
        bool JogAbs(float fVel, float fAcc, float fAbsPos);
        /// <summary>
        /// 持续定向运动
        /// </summary>
        /// <param name="fVel"></param>
        /// <param name="fAcc"></param>
        /// <param name="nDir"></param>
        /// <returns></returns>
        bool JogDir(float fVel, float fAcc, int nDir);
        /// <summary>
        /// 初始化系统参数
        /// </summary>
        /// <returns></returns>
        bool InitSystemParam();
        /// <summary>
        /// 慢速JOG运动
        /// </summary>
        /// <param name="dir">方向</param>
        /// <returns></returns>
        bool AxisJogDirSlow(int dir);
        /// <summary>
        /// Jog运动
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        bool AxisJogDir(int dir);
        /// <summary>
        /// 移动绝对位置
        /// </summary>
        /// <param name="abs"></param>
        /// <returns></returns>
        bool AxisJogAbsWork(float abs, bool wait = false);
        /// <summary>
        /// 移动相对位置
        /// </summary>
        /// <param name="inc"></param>
        /// <returns></returns>
        bool AxisJogIncWork(float inc,bool wait=false);
        /// <summary>
        /// 回零
        /// </summary>
        /// <param name="wait">等待回零完成</param>
        /// <returns></returns>
        bool AxisGoHomeWork(bool wait = false);
        /// <summary>
        /// 自动脱离限位
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        bool AxisAotoEscapeLimit(float mm = 10);

        #endregion

    }

    public enum Limit
    {
        [Description("正常模式对回零偏移和速度方向不做判断")]
        None = -2,
        [Description("负限位")]
        NLimit = -1,
        [Description("Home限位")]
        HomeLimit = 0,
        [Description("正限位限位")]
        PLimit = 1,
        [Description("自定义信号限位")]
        UserLimit = 2,
    }

}
