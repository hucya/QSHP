using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSHP.HW
{
    public static class DoDefine
    {
        public const int TAB_AIR = 0;   //吸台气压
        public const int WORK_AIR = 1;  //吸片气压
        public const int CUT_WATER = 2; //切割水

        public const int SPD_HALT = 3;  //主轴保护
        public const int SPD_SW = 3;    //主轴开关
        public const int SPD_LOCK = 3;    //主轴锁
        public const int SPD_RESET = 3;    //主轴开关

        public const int BUZZER = 4;    //蜂鸣器
        public const int LED_GREEN = 5; //绿灯
        public const int LED_YELL = 6;  //黄灯
        public const int LED_RED = 7;   //红灯
        

        public const int POWER_OFF = 8; //电源锁
        public const int LED_BELT = 9;  //灯带
        
        public const int TS_TEST = 10;  //碳刷检测
        public const int TAB_TEST = 11; //工作台检测

        public const int CUT_DOOR = 12; //切割仓门

        public const int WORK_DOOR = 13; //仓门开关

        public static string[] DOList =
        {
            "吸台",       //0
            "吸片",       //1
            "切割水",     //2
            "主轴保护",   //3
            "蜂鸣器",     //4
            "绿灯",       //5
            "黄灯",       //6
            "红灯",       //7
            "电源锁",     //8
            "灯带",       //9
            "碳刷检测",   //10
            "吸台检测",   //11
            "仓门一",     //12
            "仓门二",     //13
            "保留",
            "保留",

            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",

            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
        };
    }
    public static class DiDefine
    {
        public const int MAIN_AIR = 0;      //主气压
        public const int MAIN_WATER = 1;    //主水压

        public const int TAB_AIR = 2;   //吸台压力
        public const int WORK_AIR = 3;  //吸片压力
        public const int CUT_WATER = 4; //切割水

        public const int KEY_LOCK = 5; //钥匙开关
        public const int LEAK_WATER = 6;  //主轴故障 漏水检测
        public const int EMG_SIG = 7;  //急停信号

        public const int CUT_DOOR = 8; //切割仓门
        public const int CUT_DOOR_AIR_OPEN = 9;//仓门气压开
        public const int CUT_DOOR_AIR_CLOSE = 10;//仓门气压关

        public const int POWER_OFF = 11;//电源检测

        public static string[] DIList =
        {
            "主气压",       //0
            "主轴水压",       //1
            "吸台压力",   //2
            "吸片压力",     //3
            "切割水",     //4
            "钥匙开关",       //5
            "漏水检测",       //6
            "急停信号",       //7

            "仓门关",       //8
            "门气缸开",      //9
            "门气缸关",     //10
            "断电检测",     //11
            "保留",
            "保留",
            "保留",
            "保留",

            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",

            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
        };
    }

    public static class AiDefine
    {
        public static string[] AIList =
        {
            "BBD",
            "NCS",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留",
            "保留"
        };
    }
}
