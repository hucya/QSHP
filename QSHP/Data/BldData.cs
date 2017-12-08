using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.Data
{
    public class BldData
    {
        DateTime replaceTime = DateTime.Now;       //换刀时间
        DateTime lastDateTime = DateTime.Now;
        bool readyTest = false;     //是否已测高
        bool usedHandTest = false;  //是否使用手动测高值
        int number = 1;             //编号
        int testTick = 0;
        string bldModel = "HT-RM-08";  //刀具型号 
        string bldNum = string.Format("{0}0001", DateTime.Now.ToString("yy-MM-dd"));      //刀具编号 
        byte bldType = 0;              // 0 软刀、1、硬刀
        byte replaceReason = 0;        //换刀原因

        float firstTestValue = 25f;         //首次测高值
        float testHeightValue = 25f;        //当前测高值
        float testValueAfterClear = 25f;    //清零时的测高值
        float lastTestValue = 25f;          //最后一次测高值

        int pieceAfterReplace = 0;  //换刀后划切片数
        int pieceAfterClear = 0;    //换刀后划切片数
        int pieceAfterToday = 0;    //当天划切片数
        int pieceAfterTest = 0;     //测高后已划切片数

        int linesAfterReplace = 0;  //换刀后划切刀数
        int linesAfterClear = 0;    //清零后划切刀数
        int linesAfterTest = 0;     //测高后划切刀数

        float lenAfterReplace = 0;  //换刀后划切长度
        float lenAfterClear = 0;    //清零后划切长度
        float lenAfterTest = 0;     //测高后划切长度
        float safetyMargin = 1;     //安全余量

        float bldDiameter = 56f;        //刀具直径
        float bldTickness = 0.03f;       //刀具厚度
        float flangeDiameter = 49.4f;   //法兰直径

        int maxSafeLines = 100000;      //最大划切距离
        float maxSafeLength = 10000;    //最大划切长度

        float knifeMarksOffsetLo = 0;     //刀痕偏移值Low低倍显微镜
        float knifeMarksOffsetHi = 0;   //刀痕偏移值Hi高倍显微镜

        byte depthCompensatedMode = 0;       //深度补偿模式 0 关闭补偿 1 按刀数补偿 2 按距离补偿 3 经验补偿
        float depthCompensatedValue = 0;    //深度补偿值
        float depthCompensatedLines = 0;     //深度补偿刀数
        float depthCompensatedLen = 0;      //深度补偿距离
        float realCompensatedValue = 0;     //实际补偿值
        float  compensatedTick = 0;         //补偿临时变量
        float compensatedLinesTick = 0;     //刀数临时变量
        float compensatedLenTick = 0;       //长度补偿临时变量

        /// <summary>
        /// 换刀时间
        /// </summary>
        public DateTime ReplaceTime
        {
            get
            {
                return replaceTime;
            }

            set
            {
                replaceTime = value;
            }
        }
        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public DateTime LastDateTime
        {
            get
            {
                return lastDateTime;
            }

            set
            {
                lastDateTime = value;
            }
        }
        /// <summary>
        /// 刀具编号
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }
        /// <summary>
        /// 换刀原因
        /// </summary>
        public byte ReplaceReason
        {
            get
            {
                return replaceReason;
            }

            set
            {
                replaceReason = value;
            }
        }
        /// <summary>
        /// 刀具型号
        /// </summary>
        public string BldModel
        {
            get
            {
                return bldModel;
            }

            set
            {
                bldModel = value;
            }
        }
        /// <summary>
        /// 刀具编号
        /// </summary>
        public string BldNum
        {
            get
            {
                return bldNum;
            }
            set
            {
                bldNum = value;
            }
        }

        /// <summary>
        /// 换刀后划切片数
        /// </summary>
        public int PieceAfterReplace
        {
            get
            {
                return pieceAfterReplace;
            }

            set
            {
                pieceAfterReplace = value;
            }
        }
        /// <summary>
        /// 清零后划切片数
        /// </summary>
        public int PieceAfterClear
        {
            get
            {
                return pieceAfterClear;
            }

            set
            {
                pieceAfterClear = value;
            }
        }
        /// <summary>
        /// 当天划切片数
        /// </summary>
        public int PieceAfterToday
        {
            get
            {
                if (lastDateTime.Date != DateTime.Now.Date)
                {
                    pieceAfterToday = 0;
                }
                return pieceAfterToday;
            }

            set
            {
                pieceAfterToday = value;
            }
        }
        /// <summary>
        /// 换刀后划切刀数
        /// </summary>
        public int LinesAfterReplace
        {
            get
            {
                return linesAfterReplace;
            }

            set
            {
                linesAfterReplace = value;
            }
        }
        /// <summary>
        /// 清零后划切刀数
        /// </summary>
        public int LinesAfterClear
        {
            get
            {
                return linesAfterClear;
            }

            set
            {
                linesAfterClear = value;
            }
        }
        /// <summary>
        /// 测高后划切长度
        /// </summary>
        public int LinesAfterTest
        {
            get
            {
                return linesAfterTest;
            }

            set
            {
                linesAfterTest = value;
            }
        }
        /// <summary>
        /// 换刀后划切长度
        /// </summary>
        public float LenAfterReplace
        {
            get
            {
                return lenAfterReplace;
            }

            set
            {
                lenAfterReplace = value;
            }
        }
        /// <summary>
        /// 清零后划切长度
        /// </summary>
        public float LenAfterClear
        {
            get
            {
                return lenAfterClear;
            }

            set
            {
                lenAfterClear = value;
            }
        }
        /// <summary>
        /// 测高后划切长度
        /// </summary>
        public float LenAfterTest
        {
            get
            {
                return lenAfterTest;
            }

            set
            {
                lenAfterTest = value;
            }
        }
        /// <summary>
        /// 换刀后刀具磨损量
        /// </summary>
        public float BldLossAfterRepalce
        {
            get
            {
                return firstTestValue - testHeightValue;
            }

        }
        /// <summary>
        /// 清零后刀具磨损量
        /// </summary>
        public float BldLossAfterClear
        {
            get
            {
                return testValueAfterClear - testHeightValue;
            }
        }
        /// <summary>
        /// 测高后刀具磨损量
        /// </summary>
        public float BldLossAfterTest
        {
            get
            {
                return lastTestValue - testHeightValue;
            }
        }
        /// <summary>
        /// 安全余量
        /// </summary>
        public float SafetyMargin
        {
            get
            {
                return safetyMargin;
            }

            set
            {
                safetyMargin = value;
            }
        }
        /// <summary>
        /// 可划切安全值
        /// </summary>
        public float SafetyRemainder
        {
            get
            {
                return BldRemainder - SafetyMargin;
            }
        }
        /// <summary>
        /// 刀具类型
        /// </summary>
        public byte BldType
        {
            get
            {
                return bldType;
            }

            set
            {
                bldType = value;
            }
        }
        /// <summary>
        /// 刀具漏出量
        /// </summary>
        public float BldRemainder
        {
            get
            {
                if (readyTest)//已经进行过初次测高
                {
                    return (this.bldDiameter - this.flangeDiameter) / 2 - BldLossAfterRepalce;//刀具漏出量减去磨损量
                }
                else
                {
                    return (this.bldDiameter - this.flangeDiameter) / 2;
                }
            }
        }
        /// <summary>
        /// 刀具直径
        /// </summary>
        public float BldDiameter
        {
            get
            {
                return bldDiameter;
            }

            set
            {
                bldDiameter = value;
            }
        }
        /// <summary>
        /// 刀具厚度
        /// </summary>
        public float BldTickness
        {
            get
            {
                return bldTickness;
            }

            set
            {
                bldTickness = value;
            }
        }
        /// <summary>
        /// 法兰直径
        /// </summary>
        public float FlangeDiameter
        {
            get
            {
                return flangeDiameter;
            }

            set
            {
                flangeDiameter = value;
            }
        }
        /// <summary>
        /// 最大划切刀数
        /// </summary>
        public int MaxSafeLines
        {
            get
            {
                return maxSafeLines;
            }

            set
            {
                maxSafeLines = value;
            }
        }
        /// <summary>
        /// 最大划切长度
        /// </summary>
        public float MaxSafeLength
        {
            get
            {
                return maxSafeLength;
            }

            set
            {
                maxSafeLength = value;
            }
        }
        /// <summary>
        /// 刀痕偏移量Lo
        /// </summary>
        public float KnifeMarksOffsetLo
        {
            get
            {
                if (Common.DoubleCap)//双摄像头
                {
                    return knifeMarksOffsetLo;
                }
                else
                {
                    return knifeMarksOffsetHi;
                }
            }
            set
            {
                knifeMarksOffsetLo = value;
            }
        }
        /// <summary>
        /// 刀痕偏移量Hi
        /// </summary>
        public float KnifeMarksOffsetHi
        {
            get
            {
                return knifeMarksOffsetHi;
            }
            set
            {
                knifeMarksOffsetHi = value;
            }
        }
        /// <summary>
        /// 深度补偿模式
        /// </summary>
        public byte DepthCompensatedMode
        {
            get
            {
                return depthCompensatedMode;
            }

            set
            {
                depthCompensatedMode = value;
            }
        }
        /// <summary>
        /// 深度补偿值 超过安全值的话（漏出量-安全值)
        /// </summary>
        public float DepthCompensatedValue
        {
            get
            {
                return depthCompensatedValue;
            }

            set
            {
                if (value < BldRemainder - SafetyMargin)
                {
                    depthCompensatedValue = value;
                }
                else
                {
                    depthCompensatedValue = BldRemainder - SafetyMargin;
                }

            }
        }
        /// <summary>
        /// 补偿每隔划切刀数
        /// </summary>
        public float DepthCompensatedLines
        {
            get
            {
                return depthCompensatedLines;
            }

            set
            {
                depthCompensatedLines = value;
            }
        }
        /// <summary>
        /// 补偿每隔划切距离
        /// </summary>
        public float DepthCompensatedLen
        {
            get
            {
                return depthCompensatedLen;
            }

            set
            {
                depthCompensatedLen = value;
            }
        }
        /// <summary>
        /// 新刀已经进行测高
        /// </summary>
        public bool ReadyTest
        {
            get
            {
                return readyTest;
            }

            set
            {
                readyTest = value;
            }
        }
        /// <summary>
        /// 第一次测高值
        /// </summary>
        public float FirstTestValue
        {
            get
            {
                return firstTestValue;
            }

            set
            {
                firstTestValue = value;
                testValueAfterClear = value;
            }
        }
        /// <summary>
        /// 测高后划切片数
        /// </summary>
        public int PieceAfterTest
        {
            get
            {
                return pieceAfterTest;
            }

            set
            {
                pieceAfterTest = value;
            }
        }
        /// <summary>
        /// 当前测高值
        /// </summary>
        public float TestHeightValue
        {
            get
            {
                return testHeightValue;
            }
            set
            {
                testHeightValue = value;
            }
        }
        /// <summary>
        /// 清零后测高值
        /// </summary>
        public float TestValueAfterClear
        {
            get
            {
                return testValueAfterClear;
            }

            set
            {
                testValueAfterClear = value;
            }
        }
        /// <summary>
        /// 上一次测高值
        /// </summary>
        public float LastTestValue
        {
            get
            {
                return lastTestValue;
            }

            set
            {
                lastTestValue = value;
            }
        }
        /// <summary>
        /// 用户手动测高
        /// </summary>
        public bool UsedHandTest
        {
            get
            {
                return usedHandTest;
            }

            set
            {
                usedHandTest = value;
            }
        }
        /// <summary>
        /// 测高次数
        /// </summary>
        public int TestTick
        {
            get
            {
                return testTick;
            }

            set
            {
                testTick = value;
            }
        }
        [XmlIgnore]
        public float RealCompensatedValue
        {
            get
            {
                return realCompensatedValue;
            }

            set
            {
                realCompensatedValue = value;
            }
        }

        public BldData CreateNewBladeData(bool clone = false)
        {
            if (clone)
            {
                string s = Serialize.XmlSerialize(this);
                return Serialize.XmlDeSerialize<BldData>(s);
            }
            else
            {
                BldData bld = new BldData();
                bld.ReplaceTime = DateTime.Now;//更换时间等于创建的时间
                if (ReplaceTime.Month != DateTime.Now.Month)
                {
                    bld.Number = 1;
                }
                else
                {
                    bld.Number = Number + 1;
                }
                bld.bldNum = string.Format(string.Format("{0}{1}", DateTime.Now.ToString("yy-MM-"), bld.Number.ToString("D4")));
                bld.pieceAfterReplace = 0;  //换刀后划切片数
                bld.pieceAfterClear = 0;    //换刀后划切片数
                bld.pieceAfterToday = 0;    //当天划切片数

                bld.linesAfterReplace = 0;  //换刀后划切刀数
                bld.linesAfterClear = 0;    //清零后划切刀数
                bld.linesAfterTest = 0;     //测高后划切刀数

                bld.lenAfterReplace = 0;  //换刀后划切长度
                bld.lenAfterClear = 0;    //清零后划切长度
                bld.lenAfterTest = 0;     //测高后划切长度

                bld.KnifeMarksOffsetLo = KnifeMarksOffsetLo;
                bld.KnifeMarksOffsetHi = KnifeMarksOffsetHi;

                bld.BldModel = BldModel;
                bld.BldDiameter = bldDiameter;

                bld.FlangeDiameter = FlangeDiameter;
                bld.BldTickness = BldTickness;
                bld.BldType = BldType;

                bld.MaxSafeLength = MaxSafeLength;
                bld.MaxSafeLines = MaxSafeLines;
                bld.SafetyMargin = SafetyMargin;
                bld.ReplaceReason = ReplaceReason;

                bld.DepthCompensatedLen = DepthCompensatedLen;
                bld.DepthCompensatedLines = DepthCompensatedLines;
                bld.DepthCompensatedValue = DepthCompensatedValue;
                bld.DepthCompensatedMode = DepthCompensatedMode;
                bld.UsedHandTest = UsedHandTest;

                bld.knifeMarksOffsetLo = this.knifeMarksOffsetLo + (bld.bldTickness - bldTickness) / 2;     //刀痕偏移值Low低倍显微镜
                bld.knifeMarksOffsetHi = this.knifeMarksOffsetHi + (bld.bldTickness - bldTickness) / 2;   //刀痕偏移值Hi高倍显微镜
                return bld;
            }
        }
        public void AddCutedLinesAndLength(int line,float len)
        {
            LinesAfterClear += line;
            LinesAfterReplace += line;
            LinesAfterTest += line;
            lenAfterClear += len;
            LenAfterReplace += len;
            lenAfterTest += len;
            if (depthCompensatedValue != 0)   //深度补偿值
            {
                switch (depthCompensatedMode)
                {
                    case 1://刀数补偿
                        {
                            if (DepthCompensatedLines > 0)
                            {
                                compensatedLinesTick += line;//补偿计数+line
                                int v = (int)(compensatedLinesTick / DepthCompensatedLines);
                                if (v > 0 && v != compensatedTick)
                                {
                                    compensatedTick = v;
                                    realCompensatedValue += depthCompensatedValue;//实际的补偿值
                                }
                            }
                        }
                        break;
                    case 2://距离补偿
                        {
                            compensatedLenTick += len;
                            int v = (int)(compensatedLenTick / DepthCompensatedLen);
                            if (v > 0 && v != compensatedTick)
                            {
                                compensatedTick = v;
                                realCompensatedValue += depthCompensatedValue;//实际的补偿值
                            }
                        }
                        break;
                    case 3://经验补偿
                        {
                            compensatedTick = 0;         //补偿临时变量
                            compensatedLinesTick = 0;     //刀数临时变量
                            compensatedLenTick = 0;       //长度补偿临时变量
                            realCompensatedValue = 0;     //实际的补偿值为0
                        }
                        break;
                    default:
                        {
                            compensatedTick = 0;         //补偿临时变量
                            compensatedLinesTick = 0;     //刀数临时变量
                            compensatedLenTick = 0;       //长度补偿临时变量
                            realCompensatedValue = 0;     //实际的补偿值为0
                        }
                        break;
                }
            }
            
        }

        public void ResetDepthCompensatedValue(bool reset)
        {
            if (reset)
            {
                compensatedTick = 0;         //补偿临时变量
                compensatedLinesTick = 0;     //刀数临时变量
                compensatedLenTick = 0;       //长度补偿临时变量
                realCompensatedValue = 0;     //实际的补偿值为0
            }
        }
        public void AddOnePieceCutted()
        {
            PieceAfterClear++;
            PieceAfterReplace++;
            PieceAfterTest++;
            PieceAfterToday = PieceAfterToday + 1;
            Globals.BldData.ResetDepthCompensatedValue(true);//取消深度补偿信息
        }
        public void SaveBladeDataFile(string path)
        {
            this.lastDateTime = DateTime.Now;
            string s = Serialize.XmlSerialize(this);
            File.WriteAllText(path, s);
        }

        public void SetCurrentTestValue(float value, string path)
        {
            if (!ReadyTest)              //如果为新刀具
            {
                FirstTestValue = value;  //刀具的第一次测高值
                ReadyTest = true;        //已经进行过第一次测高操作
                TestTick = 1;
            }
            ResetDepthCompensatedValue(true);//恢复所有计数值
            LastTestValue = TestHeightValue;
            PieceAfterTest = 0;
            LenAfterTest = 0;
            LinesAfterTest = 0;
            TestTick++;
            TestHeightValue = value;       //上次测高值
            this.SaveBladeDataFile(path);//保存当前刀具信息值
        }

        public void SetCurrentOffsetValue(float hi ,float low,string path)
        {
            knifeMarksOffsetHi = hi;
            knifeMarksOffsetLo = low;
            this.SaveBladeDataFile(path);//保存当前刀具信息值
        }
        public void SetCurrentValueClear()
        {
            lenAfterClear = 0;
            pieceAfterClear = 0;
            linesAfterClear = 0;
            testValueAfterClear = TestHeightValue;
        }
    }
}
