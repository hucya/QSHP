using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.HW.Video
{
    [XmlType("AmpCProvider")]
    [XmlInclude(typeof(MVCCaptureProvider))]
    public interface IVideoProvider
    {
        [XmlIgnore]
        string SourceName
        {
            get;
        }
        /// <summary>
        /// 是否初始化
        /// </summary>
        /// 
        bool IsInit
        {
            get;
            set;
        }
        int Index
        {
            get;
            set;
        }
        /// <summary>
        /// 是否在运行
        /// </summary>
        bool IsRunning
        {
            get;
        }
        /// <summary>
        /// 采集图形尺寸
        /// </summary>
        Size Size
        {
            get;
            set;
        }
        int DataSize
        {
            get;
        }
        /// <summary>
        /// 曝光时间
        /// </summary>
        int Exposure
        {
            get;
            set;
        }
        /// <summary>
        /// 增益
        /// </summary>
        byte Gain
        {
            get;
            set;
        }
        byte AdcMode
        {
            get;
            set;
        }
        /// <summary>
        /// 物理系数 1像素代表的实际距离 mm
        /// </summary>
        float Scale
        {
            get;
            set;
        }

        float FrameRate
        {
            get;
        }
        /// <summary>
        /// 缩小模式
        /// </summary>
        bool BinningMode
        {
            get;
            set;
        }
        /// <summary>
        /// 初始化设备
        /// </summary>
        /// <returns></returns>
        bool InitDriver();
        /// <summary>
        /// 反初始化设备
        /// </summary>
        /// <returns></returns>
        bool UninitDriver();
        /// <summary>
        /// 开始采集图像
        /// </summary>
        /// <returns></returns>
        bool StartCapture();
        /// <summary>
        /// 停止采集图像
        /// </summary>
        /// <returns></returns>
        bool StopCapture();
        /// <summary>
        /// 获取采集数据
        /// </summary>
        /// <param name="dest">目标地址</param>
        /// <returns></returns>
        Bitmap GetCurrentFrame();
    }
}
