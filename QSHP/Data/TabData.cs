using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace QSHP.Data
{
    public class TabData
    {
        List<TabArgs> rotateTabArgs = new List<TabArgs>();
        List<TabArgs> squareTabArgs = new List<TabArgs>();
        //SizeF[] tabSizes = 
        //{
        //    new SizeF(76.2f, 76.2f),
        //    new SizeF(101.6F, 101.6F),
        //    new SizeF(152.4F, 152.4F),
        //    new SizeF(203.2F, 203.2F),
        //    new SizeF(304.8F, 304.8F)
        //};
        int spdSpeed = 10000;   //测高主轴转速
        int testTick = 3;       //重复次数
        int tabIndex = 0;       //工作台号索引
        bool rotateType = true; //默认圆形工作台
        bool toolBarCsMode = true;  //默认接触式测高
        bool checkAirTest = true;   //默认检测气压进行测高

        float minTpos = 30;     //T轴旋转最大值
        float maxTpos = 380;    //T轴旋转最小值

        float csMaxErrValue = 0.01f;//接触式测高最大误差
        float ncsMaxErrValue = 0.01f;//非接触式测高最大误差

        float ncsXpos = 216;    //Ncs测高X位置
        float ncsYpos = 200;    //NCS测高Y位置
        float ncsZlowPos = 18;  //NCS测高Z低速位置
        float ncsTestValue = 16;//NCS测高值
        float csTestValue = 17; //CS测高值
        float ncsOffset = 1;    //NCS测高偏差

        int ncsBlowingWaterTime = 10;   //NCS吹水时间
        int ncsBlowingAirTime = 10;     //NCS吹气时间
        int ncsWaitTime = 5;            //NCS等待时间
        int ncsRepeatTick = 2;          //重复次数
        int ncsAutoMode = 0;            //自动测高模式

        public int SpdSpeed
        {
            get
            {
                return spdSpeed;
            }

            set
            {
                spdSpeed = value;
            }
        }

        public int TestTick
        {
            get
            {
                return testTick;
            }

            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                testTick = value;
            }
        }

        public int TabIndex
        {
            get
            {
                return tabIndex;
            }

            set
            {
                tabIndex = value;
            }
        }

        public float CsMaxErrValue
        {
            get
            {
                return csMaxErrValue;
            }

            set
            {
                csMaxErrValue = value;
            }
        }

        public float NcsMaxErrValue
        {
            get
            {
                return ncsMaxErrValue;
            }

            set
            {
                ncsMaxErrValue = value;
            }
        }

        public float NcsXpos
        {
            get
            {
                return ncsXpos;
            }

            set
            {
                ncsXpos = value;
            }
        }

        public float NcsYpos
        {
            get
            {
                return ncsYpos;
            }

            set
            {
                ncsYpos = value;
            }
        }

        public float NcsZlowPos
        {
            get
            {
                return ncsZlowPos;
            }

            set
            {
                ncsZlowPos = value;
            }
        }

        public float NcsTestValue
        {
            get
            {
                return ncsTestValue;
            }

            set
            {
                ncsTestValue = value;
            }
        }

        public float NcsOffset
        {
            get
            {
                return ncsOffset;
            }

            set
            {
                ncsOffset = value;
            }
        }

        public int NcsBlowingWaterTime
        {
            get
            {
                return ncsBlowingWaterTime;
            }

            set
            {
                ncsBlowingWaterTime = value;
            }
        }

        public int NcsBlowingAirTime
        {
            get
            {
                return ncsBlowingAirTime;
            }

            set
            {
                ncsBlowingAirTime = value;
            }
        }

        public int NcsWaitTime
        {
            get
            {
                return ncsWaitTime;
            }

            set
            {
                ncsWaitTime = value;
            }
        }

        public int NcsRepeatTick
        {
            get
            {
                return ncsRepeatTick;
            }

            set
            {
                ncsRepeatTick = value;
            }
        }

        public int NcsAutoMode
        {
            get
            {
                return ncsAutoMode;
            }

            set
            {
                ncsAutoMode = value;
            }
        }

        public float CsTestValue
        {
            get
            {
                return csTestValue;
            }

            set
            {
                csTestValue = value;
            }
        }

        public float MinTpos
        {
            get
            {
                return minTpos;
            }

            set
            {
                minTpos = value;
            }
        }

        public float MaxTpos
        {
            get
            {
                return maxTpos;
            }

            set
            {
                maxTpos = value;
            }
        }

        public List<TabArgs> RotateTabArgs
        {
            get
            {
                return rotateTabArgs;
            }

            set
            {
                rotateTabArgs = value;
            }
        }

        public List<TabArgs> SquareTabArgs
        {
            get
            {
                return squareTabArgs;
            }

            set
            {
                squareTabArgs = value;
            }
        }

        public TabArgs UsedTable
        {
            get
            {
                if (RotateType)
                {
                    return RotateTabArgs[tabIndex];
                }
                else
                {
                    return SquareTabArgs[tabIndex];
                }
            }

        }

        public bool ToolBarCsMode
        {
            get
            {
                return toolBarCsMode;
            }

            set
            {
                toolBarCsMode = value;
            }
        }

        public bool CheckAirTest
        {
            get
            {
                return checkAirTest;
            }

            set
            {
                checkAirTest = value;
            }
        }

        public bool RotateType
        {
            get
            {
                return rotateType;
            }

            set
            {
                rotateType = value;
            }
        }

        public SizeF UsedTabSize
        {
            get
            {
                return UsedTable.TabSize;
            }
        }

        public void InitTabData()
        {
            if (rotateTabArgs.Count < 5)
            {
                int j = rotateTabArgs.Count;
                for (int i = j; i < 5; i++)
                {
                    rotateTabArgs.Add(new TabArgs(i, true));
                }
            }
            if (squareTabArgs.Count < 5)
            {
                int j = squareTabArgs.Count;
                for (int i = j; i < 5; i++)
                {
                    squareTabArgs.Add(new TabArgs(i, false));
                }
            }
        }
        public void SaveTabDataFile(string path)
        {
            string s = Serialize.XmlSerialize(this);
            File.WriteAllText(path, s);
        }

        public TabData CreateNewTabData(bool clone = true)
        {
            if (clone)
            {
                string s = Serialize.XmlSerialize(this);
                var t = Serialize.XmlDeSerialize<TabData>(s) as TabData;
                t.InitTabData();
                return t;
            }
            else
            {
                var t = new TabData();
                t.InitTabData();
                return t;
            }
        }
    }

    public class TabArgs
    {
        int tabNum = 0;     //工作台编号
        bool rotateType = true;    //工作台类型
        float startXpos = 216;//开始X位置
        float startYpos = 200;//开始Y位置
        float startTpos = 30;//开始时T轴位置

        float length = 150;//结束Y位置
        
        float zLowPos = 18;//Z轴低速点
        float curTpos = 30;//T轴当前值
        float curXpos = 216;//当前X位置
        float curYpos = 200;//当前Y位置

        SizeF tabSize = new SizeF(152.4F, 152.4F);

        public int TabNum
        {
            get
            {
                return tabNum;
            }

            set
            {
                tabNum = value;
            }
        }

        public bool RotateType
        {
            get
            {
                return rotateType;
            }

            set
            {
                rotateType = value;
            }
        }

        public float CurXpos
        {
            get
            {
                return curXpos;
            }

            set
            {
                curXpos = value;
            }
        }

        public float CurYpos
        {
            get
            {
                return curYpos;
            }

            set
            {
                curYpos = value;
            }
        }
        public float CurTpos
        {
            get
            {
                return curTpos;
            }

            set
            {
                curTpos = value;
            }
        }

        public float StartXpos
        {
            get
            {
                return startXpos;
            }

            set
            {
                startXpos = value;
                CurXpos = value;
            }
        }

        public float StartYpos
        {
            get
            {
                return startYpos;
            }

            set
            {
                startYpos = value;
                if (curYpos < startYpos)
                {
                    curYpos = startYpos;
                }
            }
        }

        public float StartTpos
        {
            get
            {
                return startTpos;
            }

            set
            {
                startTpos = value;
            }
        }


        public float ZLowPos
        {
            get
            {
                return zLowPos;
            }

            set
            {
                zLowPos = value;
            }
        }

        public SizeF TabSize
        {
            get
            {
                return tabSize;
            }

            set
            {
                tabSize = value;
            }
        }

        public float Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }

        public TabArgs()
        { }

        public TabArgs(int index, bool type)
        {
            TabNum = index;
            RotateType = type;
        }
    }
}
