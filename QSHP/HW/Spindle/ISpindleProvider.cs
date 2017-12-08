using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSHP.HW.Spindle
{
    public delegate void SamplingEventHandler(object sender, SpindleEventArgs e = null);
    public interface ISpindleProvider:IDisposable
    {
        /// <summary>
        /// 关闭当前主轴
        /// </summary>
        /// <returns></returns>
        bool CloseSpd();
        /// <summary>
        /// 获取当前主轴电流
        /// </summary>
        /// <returns></returns>
        float GetSpdCurrent();
        /// <summary>
        /// 获取当前主轴转速
        /// </summary>
        /// <returns></returns>
        float GetSpdSpeed();
        /// <summary>
        /// 获取主轴是否开启
        /// </summary>
        /// <returns></returns>
        bool GetSpdSW();
        /// <summary>
        /// 获取主轴错误
        /// </summary>
        /// <returns></returns>
        bool GetSpdRrr();
        /// <summary>
        /// 获取主轴错误描述
        /// </summary>
        /// <returns></returns>
        string GetSpdStatusString();
        /// <summary>
        /// 初始化并连接主轴
        /// </summary>
        /// <returns></returns>
        bool InitSpd();
        /// <summary>
        /// 复位变频器
        /// </summary>
        /// <returns></returns>
        bool ResetSpd();
        /// <summary>
        /// 电机按照指定的速度运行
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        bool RunSpd(int speed);
        /// <summary>
        /// 停止电机运行
        /// </summary>
        /// <returns></returns>
        bool StopSpd();
        /// <summary>
        /// 实时更新数据事件
        /// </summary>
        event SamplingEventHandler UpdateSamplingHander;
        /// <summary>
        /// 电机运行稳定
        /// </summary>
        bool SpeedStabled { get; }
        /// <summary>
        /// 电机运动速度为零
        /// </summary>
        bool SpeedZore { get; }
        /// <summary>
        /// 设置最小采样周期
        /// </summary>
        int SamplingMs { get; set; }
        /// <summary>
        /// 是否初始化成功
        /// </summary>
        bool IsInit { get; }
        /// <summary>
        /// 错误代码
        /// </summary>
        int ErrCode { get; }
        /// <summary>
        /// 设备索引
        /// </summary>
        int DevIndex { get; set; }
        /// <summary>
        /// 设备索引
        /// </summary>
        int AmpCIndex { get; set; }
        
        int BaudRate { get; set; }

        float SetSpeed { get; }
    }
}
