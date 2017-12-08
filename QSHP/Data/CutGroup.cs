using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.Data
{
    [Serializable]
    public class CutGroup : CutChip
    {
        int spdSpeed = 30000; //主轴转速
        bool spdStabled = false;//主轴预热稳定
        bool multiple = false;   //多片
        bool oncePiece = false; //一次划切一整片
        int exitPosMode = 0;    //退出划切位置
        float exitXpos = 300;   //X退出位置
        float exitYpos = 200;   //Y退出位置
        float exitTpos = 30;    //T退出位置
        List<CutChip> chipS = new List<CutChip>();
        List<CutChannel> chipChannel = new List<CutChannel>();
        PreData preCut = new PreData();
        public new float PreTime
        {
            get
            {
                float time = 0;
                foreach (var item in chipChannel)
                {
                    if (item.Enable)
                    {
                        time += item.PreTime;
                    }
                }
                return time;
            }
        }
        public new bool Aligned
        {
            get
            {
                bool flag = true;
                if (!multiple)
                {
                    return base.Aligned;
                }
                else
                {
                    foreach (var item in chipS)
                    {
                        if (item.Enable)
                        {
                            flag &= item.Aligned;
                        }
                    }
                }
                return flag;
            }
        }

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
        /// <summary>
        /// 多片加工
        /// </summary>
        public bool Multiple
        {
            get
            {
                return multiple;
            }

            set
            {
                multiple = value;
            }
        }
        /// <summary>
        /// 每次划切一整片
        /// </summary>
        public bool OncePiece
        {
            get
            {
                return oncePiece;
            }

            set
            {
                oncePiece = value;
            }
        }
        public new int Count
        {
            get
            {
                return ChipS.Count;
            }
        }
        /// <summary>
        /// 多片划切工艺
        /// </summary>
        public List<CutChip> ChipS
        {
            get
            {
                return chipS;
            }

            set
            {
                chipS = value;
            }
        }
        [XmlIgnore]
        public List<CutChannel> ChipCHs
        {
            get
            {
                return chipChannel;
            }

            set
            {
                chipChannel = value;
            }
        }
        public int ExitPosMode
        {
            get
            {
                return exitPosMode;
            }

            set
            {
                exitPosMode = value;
            }
        }

        public float ExitXpos
        {
            get
            {
                return exitXpos;
            }

            set
            {
                exitXpos = value;
            }
        }

        public float ExitYpos
        {
            get
            {
                return exitYpos;
            }

            set
            {
                exitYpos = value;
            }
        }

        public float ExitTpos
        {
            get
            {
                return exitTpos;
            }

            set
            {
                exitTpos = value;
            }
        }

        public bool SpdStabled
        {
            get
            {
                return spdStabled;
            }

            set
            {
                spdStabled = value;
            }
        }

        public PreData PreCut
        {
            get
            {
                return preCut;
            }

            set
            {
                preCut = value;
            }
        }

        public CutChannel this[int p, int index]
        {
            get
            {
                if (multiple)
                {
                    return ChipS[Count % index][index];
                }
                else
                {
                    return this[index];
                }
            }
            set
            {
                if (multiple)
                {
                    ChipS[Count % index][index] = value;
                }
                else
                {
                    this[index] = value;
                }
            }
        }

        public void Add(CutChip s)
        {
            if (s == null)
                return;
            if (!ChipS.Contains(s))
            {
                s.Index = Count;
                ChipS.Add(s);
            }
        }
        public bool Remove(CutChip c)
        {
            return ChipS.Remove(c);
        }

        public override void InitCutRunData(bool create = true)
        {
            this.Center = Globals.TabCenter;
            SetStyle(CutState.Complate | CutState.Cutting | CutState.Pause, false);
            chipChannel.Clear();
            if (create)
            {
                preCut.InitPreDataSpeed();//初始化预划切速度
            }
            if (!Multiple)//加工一片
            {
                ChipS.Clear();
                this.LeftTopPoint.X = Center.X - Length / 2; //配置左上角坐标X
                this.LeftTopPoint.Y = Center.Y - Width / 2;  //配置
                base.InitCutRunData(create);
                chipChannel.AddRange(CHs);  //任意通道模式
                if (!Order)
                {
                    chipChannel.Reverse();  //逆序
                }
            }
            else//加工多片
            {
                foreach (var item in chipS)//多片划切
                {
                    item.CutDir = CutDir;
                    item.CutMode = item.CutMode;//切割模式
                    item.Order = Order;
                    item.BackSpeed = BackSpeed;
                    item.InitCutRunData(create);
                    if (OncePiece)//一次划切一片
                    {
                        if (Order)// 顺序
                        {
                            chipChannel.Add(item.CH1);
                            chipChannel.Add(item.CH2);
                        }
                        else//逆序
                        {
                            chipChannel.Add(item.CH2);
                            chipChannel.Add(item.CH1);
                        }
                    }
                    else    //一次划切多通道
                    {
                        if (Order)
                        {
                            chipChannel.Add(item.CH1);
                        }
                        else
                        {
                            chipChannel.Add(item.CH2);
                        }
                    }
                }
                if (!OncePiece)// 每次划切通整个通道
                {
                    foreach (var item in chipS)//添加所有片的第二通道
                    {
                        if (Order)
                        {
                            chipChannel.Add(item.CH2);
                        }
                        else
                        {
                            chipChannel.Add(item.CH1);
                        }
                    }
                }
            }
            chipChannel.RemoveAll(c => c.Enable == false);//实际划切片数要移除未使能的通道
        }

        public void AddBladeCutedPieces()
        {
            if (Multiple)
            {
                foreach (var item in ChipS)
                {
                    if (item.Complate && !base.ReadyCuted)
                    {
                        Globals.BldData.AddOnePieceCutted();//增加累计划切刀数
                        base.ReadyCuted = true;
                    }
                }
            }
            else
            {
                if (IsComplated && !ReadyCuted)
                {
                    Globals.BldData.AddOnePieceCutted();//增加划切刀数
                    ReadyCuted = true;
                }
            }
        }

        public void ClearAllChannelInfo()
        {
            foreach (var item in CHs)
            {
                item.TAligned = false;
                item.Aligned = false;
            }
        }
        public CutGroup CreateNewCutGroup(bool clone = true)
        {
            if (clone)
            {
                string s = Serialize.XmlSerialize(this);
                return Serialize.XmlDeSerialize<CutGroup>(s);
            }
            else
            {
                return new CutGroup();
            }
        }

        public override string ToString()
        {

            return string.Format("Group: SpedSpeed={0},filmHeight={1},WorkHeight={2},ReDepth={3}", SpdSpeed, FilmHeight, WorkerHeight, ReDepth);
        }
    }
}
