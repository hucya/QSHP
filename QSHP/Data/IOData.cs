using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.Data
{
    [XmlType("IOData", Namespace = "")]
    public class IOData
    {
        int dIMaxNum = 32;
        int dOMaxNum = 32;
        int aIMaxNum = 8;
       
        uint doMask = UInt32.MaxValue;
        uint doUsed = 0xFFFF;
        uint diMask = UInt32.MaxValue;
        uint diUsed = 0xFFFF;

        uint loadDOS = UInt32.MaxValue;//系统加载
        uint initDOS = UInt32.MaxValue;//系统初始化
        uint exitDOS= UInt32.MaxValue;//退出系统
        uint csDOS = UInt32.MaxValue;//CS测高
        uint ncsDOS = UInt32.MaxValue;//NCS测高
        uint alignDOS = UInt32.MaxValue;//对准
        uint cutDOS = UInt32.MaxValue;//切割
        uint stopDOS = UInt32.MaxValue;//停止
        uint pasueDOS = UInt32.MaxValue;//暂停

        int[] doList = new int[32];
        int[] diList = new int[32];
        AnalogArgs[] aiArgs = new AnalogArgs[8];

        public int DIMaxNum
        {
            get
            {
                return dIMaxNum;
            }

            set
            {
                dIMaxNum = value;
            }
        }

        public int DOMaxNum
        {
            get
            {
                return dOMaxNum;
            }

            set
            {
                dOMaxNum = value;
            }
        }

        public int AIMaxNum
        {
            get
            {
                return aIMaxNum;
            }

            set
            {
                aIMaxNum = value;
            }
        }

        public uint LoadDOS
        {
            get
            {
                return loadDOS;
            }

            set
            {
                loadDOS = value;
            }
        }

        public uint InitDOS
        {
            get
            {
                return initDOS;
            }

            set
            {
                initDOS = value;
            }
        }

        public uint ExitDOS
        {
            get
            {
                return exitDOS;
            }

            set
            {
                exitDOS = value;
            }
        }

        public uint CsDOS
        {
            get
            {
                return csDOS;
            }

            set
            {
                csDOS = value;
            }
        }

        public uint NcsDOS
        {
            get
            {
                return ncsDOS;
            }

            set
            {
                ncsDOS = value;
            }
        }

        public uint AlignDOS
        {
            get
            {
                return alignDOS;
            }

            set
            {
                alignDOS = value;
            }
        }

        public uint CutDOS
        {
            get
            {
                return cutDOS;
            }

            set
            {
                cutDOS = value;
            }
        }

        public uint StopDOS
        {
            get
            {
                return stopDOS;
            }

            set
            {
                stopDOS = value;
            }
        }

        public uint PasueDOS
        {
            get
            {
                return pasueDOS;
            }

            set
            {
                pasueDOS = value;
            }
        }

        public uint DoMask
        {
            get
            {
                return doMask;
            }

            set
            {
                doMask = value;
            }
        }

        public uint DoUsed
        {
            get
            {
                return doUsed;
            }

            set
            {
                doUsed = value;
            }
        }

        public uint DiMask
        {
            get
            {
                return diMask;
            }

            set
            {
                diMask = value;
            }
        }

        public uint DiUsed
        {
            get
            {
                return diUsed;
            }

            set
            {
                diUsed = value;
            }
        }

        public int[] DoList
        {
            get
            {
                return doList;
            }

            set
            {
                doList = value;
            }
        }

        public int[] DiList
        {
            get
            {
                return diList;
            }

            set
            {
                diList = value;
            }
        }

        public AnalogArgs[] AiArgs
        {
            get
            {
                return aiArgs;
            }

            set
            {
                aiArgs = value;
            }
        }

        public IOData()
        {
            for (int i = 0; i < aiArgs.Count(); i++)
            {
                aiArgs[i] = new AnalogArgs(i);
            }
            for (int i = 0; i < 32; i++)
            {
                doList[i] = i;
                diList[i] = i;
            }

        }
    }
    [XmlType("AnalogArgs", Namespace = "")]
    public class AnalogArgs
    {
        int index = 0;
        float scale = 1;
        float offset = 0;
        float maxValue = 5;
        float minValue = 0;
        float threshold = 2.5f;
        bool enable = true;

        public  AnalogArgs()
        {
        }
        public AnalogArgs(int inx,bool en=true)
        {
            index = inx;
            enable = en;
        }
        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }
        public bool Enable
        {
            get
            {
                return enable;
            }

            set
            {
                enable = value;
            }
        }
        public float Scale
        {
            get
            {
                return scale;
            }

            set
            {
                scale = value;
            }
        }

        public float Offset
        {
            get
            {
                return offset;
            }

            set
            {
                offset = value;
            }
        }

        public float MaxValue
        {
            get
            {
                return maxValue;
            }

            set
            {
                maxValue = value;
            }
        }

        public float MinValue
        {
            get
            {
                return minValue;
            }

            set
            {
                minValue = value;
            }
        }

        public float Threshold
        {
            get
            {
                return threshold;
            }

            set
            {
                threshold = value;
            }
        }

    }
}
