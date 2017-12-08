using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSHP.HW
{
    /// <summary>
    /// 运动轴分配0x01 -0x1F CCD 0x21-0x3F SPD 0x41-0x4F LH 0x51-0x5F LD 0x61-0x6F 
    /// </summary>
    public enum HardwareType : byte
    {
        /// <summary>
        /// X轴
        /// </summary>
        X_Axis = 0x01,
        /// <summary>
        /// Y轴
        /// </summary>
        Y_Axis = 0x02,
        /// <summary>
        /// Z轴
        /// </summary>
        Z_Axis = 0x03,
        /// <summary>
        /// T轴
        /// </summary>
        T_Axis = 0x04,
        /// <summary>
        /// CCD1
        /// </summary>
        CCD = 0x21,
        /// <summary>
        /// CCD2
        /// </summary>
        CCD2 = 0x22,
        /// <summary>
        /// SPD1
        /// </summary>
        SPD = 0x41,
        /// <summary>
        /// 环光1
        /// </summary>
        LH = 0x51,
        /// <summary>
        /// 点光1
        /// </summary>
        LD = 0x61,
        /// <summary>
        /// 模拟输入
        /// </summary>
        AI = 0x71,
        /// <summary>
        /// 模拟输出
        /// </summary>
        AO = 0X91,
        /// <summary>
        /// 数字输入
        /// </summary>
        DI = 0xA1,
        /// <summary>
        /// 数字输出
        /// </summary>
        DO = 0xC1,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 0xF1,
    };
    internal class HW<T, U> : Dictionary<T, U>
        where T : struct
        where U : class,new()
    {

    }
}
