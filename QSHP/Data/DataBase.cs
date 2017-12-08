using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSHP.Data
{
    [Flags]
    public enum CutState:ushort
    {
        Abs = 0x8000,    //是否有效 true绝对位置 false 相对位置
        /// <summary>
        /// 单向划切
        /// </summary>
        SigDir = 0x4000,   //是否为单向划切 true 单向划切  false双向划切 
        /// <summary>
        /// 划切方向
        /// </summary>
        Dir = 0x2000,       //划切方向 true 正向划切 false 反向划切 
        /// <summary>
        /// 测高
        /// </summary>
        TestHeight = 0x1000, //是否测高 true测高 false不测高
        /// <summary>
        /// 暂停
        /// </summary>
        Pause = 0x800,      //是否暂停 true 暂停 false不暂停 
        /// <summary>
        /// 固定宽度
        /// </summary>
        Fixed = 0x400,     //固定宽度 圆片false  方片 true
        /// <summary>
        /// 划切中
        /// </summary>
        Cutting = 0x200,    //是否正在划切是否正在划切
        /// <summary>
        /// 向前切割
        /// </summary>
        Forward=0x100,        //向前或向后划切
        /// <summary>
        /// 第一刀划切
        /// </summary>
        FirstCut=0x80,      //是否为第一刀划切
        /// <summary>
        /// Z轴是否必须抬刀
        /// </summary>
        Order = 0x40,         //Z轴是否抬刀
        /// <summary>
        /// 划切完成
        /// </summary>
        Complate = 0x20,   //是否划切完成
        /// <summary>
        /// 使能 
        /// </summary>
        Enable=0x10,
        
    }

    public enum CutStep : byte
    {
        Ready = 0x00,  //准备OK
        ST1 = 0x1,     //第一步
        ST2 = 0x2,     //第二步
        ST3 = 0x3,     //第三步
        ST4 = 0x4,     //第四步
        ST5 = 0x5,     //第五步
        ST6 = 0x6,     //第六步
        ST7 = 0x7,     //第七步
        ST8 = 0x8,     //第八步
        CutStop = 0x09, //划切动作结束
        ST10 = 0x0A,    //
        KniefCheck = 0x0B,   //需要检测刀痕
        TestHeigh = 0x0C,//需要划切
        Pause = 0x0D,    //进入暂停
        Continue = 0x0E, //继续进行划切
        STEnd = 0xF,     //步骤结束
    }

    public enum CutDir
    {
        Positive = 0,//正向
        Negative = 1,//反向
        TwoWay=2,//双向
    }

    public enum CutMode
    {
        StandOnce,  //标准单通道
        Stand,      //标准双通道
        AnyStep,    //通道多步距
        AnyChannel, //任意通道
        Other,
    }

    public enum CutStyle
    {
        FrontToBack = 0,//从前往后
        BackToFront,//从后往前
        AlignToBack,//从对准点向后
        AlignToFront,//从对准点向前
    }
    public enum CutWorker
    {
        Circular = 0,
        Region = 1,
    }
}
