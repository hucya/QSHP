using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.Data
{
    [XmlRoot("CutChannel")]
    public class CutChannel: CutSegment
    {
        List<CutSegment> segs = new List<CutSegment>();

        bool rotated = false;   //图像是否已旋转

        float width = 50;
        float tPosAdj = 0;      //t轴偏移
        float tRoatePos = 30;    //t轴旋转偏移
        float yPosAdj = 0;      //y轴偏移
        float alignT = 30;      //对准后T轴位置
        float indexStep2 = 0;   //分度2

        int cycleTick = 0;      //循环计次
        int cycleCount = 0;     //循环总数
        int testHeightTick = 0; //测高数值
        int pauseTick = 0;      //暂停数值
        int keirfLineWidth = 30;//默认刀痕宽度   

        int pauseMode = 0;//暂停模式
        public int KnieffLineWidth
        {
            get { return keirfLineWidth; }
            set { keirfLineWidth = value; }
        }
        bool aligned = false;   //是否已对准
        bool tAligned = false; //T轴是否调整
        bool standMode = true;  //是否为标准模式
        CutStyle style = CutStyle.BackToFront;//从后往前切割
        [XmlIgnore]
        public PointF StartPoint = new PointF(250, 200);//开始位置

        public PointF AlignPoint = new PointF(250, 200);//对准位置
        [XmlIgnore]
        public PointF PausePos = new PointF(250,200);//暂停位置
        CutChip chip;

        public CutChannel()
        {
            CH = this;
        }
       
        public CutChannel(float rot)
        {
            TRoatePos = rot;
            CH = this;
        }
        public override float PreTime
        {
            get
            {
                float time = 0;
                foreach (var item in Lines)//预计划切时间
                {
                    time += item.PreTime;
                }
                time += (cycleCount * time);//
                return time;
            }
        }
          
        /// <summary>
        /// 划切已完成
        /// </summary>
        public new string Name
        {
            get
            {
                return string.Format("CH{0}", index+1);
            }
        }
        public float IndexStep2
        {
            get
            {
                return indexStep2;
            }

            set
            {
                if(value>=0)
                {
                    indexStep2 = value;
                }
            }
        }
        /// <summary>
        /// Y轴偏移
        /// </summary>
        public float YPosAdj
        {
            get
            {
                return yPosAdj;
            }

            set
            {
                yPosAdj = value;
            }
        }
        /// <summary>
        /// T轴偏移
        /// </summary>
        public float TPosAdj
        {
            get
            {
                return tPosAdj;
            }
            set
            {
                tPosAdj = value;
            }
        }
        /// <summary>
        /// 循环计次
        /// </summary>
        [XmlIgnore]
        public int CycleTick
        {
            get
            {
                return cycleTick;
            }

            set
            {
                cycleTick = value;
            }
        }
        /// <summary>
        /// 对准后T 轴位置 
        /// </summary>
        public float AlignT
        {
            get
            {
                return alignT;
            }

            set
            {
                alignT = value;
            }
        }
        /// <summary>
        /// 划切步距
        /// </summary>
        [XmlArrayItem("Channel")]
        public new CutSegment this[int index]
        {
            get
            {
                return Segs[index];
            }
            set
            {
                Segs[index] = value;
            }
        }

        /// <summary>
        /// 测高次数（每隔  累计）
        /// </summary>
        public int TestHeightTick
        {
            get
            {
                return testHeightTick;
            }

            set
            {
                testHeightTick = value;
            }
        }
        /// <summary>
        /// 暂停次数 
        /// </summary>
        public int PauseTick
        {
            get
            {
                return pauseTick;
            }

            set
            {
                pauseTick = value;
            }
        }
        /// <summary>
        /// 切割通道
        /// </summary>
        public List<CutSegment> Segs
        {
            get
            {
                return segs;
            }
            set
            {
                segs = value;
            }
        }
        /// <summary>
        /// 已经对准
        /// </summary>
        [XmlIgnore]
        public bool Aligned
        {
            get
            {
                return aligned;
            }

            set
            {
                aligned = value;
            }
        }
        //public override int Count
        //{
        //    get
        //    {
        //        return Segs.Count;
        //    }
        //}
        /// <summary>
        /// 已进行T轴调整
        /// </summary>
        [XmlIgnore]
        public bool TAligned
        {
            get
            {
                return tAligned;
            }

            set
            {
                tAligned = value;
            }
        }
       /// <summary>
       /// 标准模式
       /// </summary>
       [XmlIgnore]
        public bool StandMode
        {
            get
            {
                return standMode;
            }

            set
            {
                standMode = value;
            }
        }
        /// <summary>
        /// 切割模式
        /// </summary>
        public CutStyle Style
        {
            get
            {
                return style;
            }

            set
            {
                style = value;
            }
        }
        /// <summary>
        /// 高度
        /// </summary>
        [XmlIgnore]
        public float Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }
        /// <summary>
        /// 循环次数
        /// </summary>
        public int CycleCount
        {
            get
            {
                return cycleCount;
            }

            set
            {
                cycleCount = value;
            }
        }
        [XmlIgnore]
        public CutChip Chip
        {
            get
            {
                return chip;
            }

            set
            {
                chip = value;
            }
        }
        //[XmlIgnore]
        public float TRoatePos
        {
            get
            {
                return tRoatePos;
            }

            set
            {
                tRoatePos = value;
            }
        }
        [XmlIgnore]
        public bool Rotated
        {
            get
            {
                return rotated;
            }

            set
            {
                rotated = value;
            }
        }

        public int PauseMode
        {
            get
            {
                return pauseMode;
            }

            set
            {
                pauseMode = value;
            }
        }

        public void Add(CutSegment s)
        {
            if (s == null)
                return;
            if (!Segs.Contains(s))
            {
                s.Index = Segs.Count;
                s.CH = this;
                Segs.Add(s);
            }
        }

        public bool Remove(CutSegment s)
        {
            return Segs.Remove(s);
        }
        public override string ToString()
        {
            return string.Format("CH{0}", index+1);
        }

        public override void InitCutRunData(bool create = true)
        {
            cycleTick = 0;          //循环计次清零
            InitCutRunningData(create);
        }
        public void InitCutRunningData(bool create, bool reInit = true)
        {
            SetStyle(CutState.Cutting | CutState.Complate | CutState.Pause, false);
            cuttingIndex = 0;       //划切刀数计次清零
            if (StandMode)          //标准模式
            {
                if (reInit)
                {
                    rotated = false;
                    CalculateYStartPos();
                }
                CH = this;
                base.InitCutRunData(create);//分度一 分度二 划切分度 划切刀数
            }
            else  //多分度划切
            {
                if (reInit)
                {
                    rotated = false;
                    CalculateYStartPos();               //计算出XY 起始位置
                }
                Lines.Clear();
                float ypos = 0;
                bool dir = this.Dir;                //统一划切方向
                int lineNum = 0;
                for(int i=0; i<segs.Count; i++)
                {
                    if (segs[i].Enable)
                    {
                        if (i == 0)
                        {
                            IndexStep = Segs[i].IndexStep;//表示为第一步距的分度值
                        }
                        var item = Segs[i];
                        lineNum += item.TotalLine;
                        item.CH = this;
                        item.PreWidth = this.preWidth;  //单边预留
                        item.BackSpeed = this.BackSpeed;//返回速度
                        item.Length = this.length;      //切割宽度
                        item.Forward = this.Forward;    //切割方向
                        item.Fixed = this.Fixed;     //圆片还是方片
                        item.Center = this.Center;   //中心位置
                        item.SinDir = this.SinDir;   //是否单向划切
                        item.SelfPos = this.SelfPos; //安全位置
                        if (Dual || SinDir)//如果为双刀或者单向划切
                        {
                            item.Dir = this.Dir;             //划切方向一致
                        }
                        else
                        {
                            item.Dir = dir;
                            if (item.TotalLine % 2 == 1)//奇数刀 改变划切方向
                            {
                                dir = !dir; //方向取反
                            }
                            item.Dir = dir; //赋值划切方向
                        }
                        item.StartPos.X = this.StartPos.X;          //起点位置
                        item.StartPos.Y = this.StartPos.Y + ypos;   //起点位置 
                        item.InitCutRunData(create);//
                        if (Forward)//Y轴进行偏移重新计算Y的值
                        {
                            if (item.Count > 0)//实际总刀数不为0
                            {
                                ypos += (item.Count + 1) * item.IndexStep;//多通道时候需要重新校验Y 的步进值+本身的偏移值
                                if (i > 0)
                                {
                                    item[0].StartPos.Y = item.IndexStep;//需要将其他通道进行跳格
                                }
                            }
                        }
                        else
                        {
                            if (item.Count > 0)//实际总刀数 不为0
                            {
                                ypos -= (item.Count + 1) * item.IndexStep;//多通道时候需要重新校验Y 的步进值+本身的偏移值
                                if (i > 0)
                                {
                                    item[0].StartPos.Y = -item.IndexStep;//需要将其他通道进行跳格
                                }
                            }
                        }
                        Lines.AddRange(item.Lines);
                    }
                }
                TotalLine = lineNum;
            }
            switch (pauseMode)
            {
                case 1://起止暂停
                    {
                        if(PauseTick>0&&PauseTick<Lines.Count)//暂停计数大于0 并且小于刀数
                        {
                            Lines[PauseTick-1].Pause = true;//当前刀划切完成暂停
                            if(PauseTick < Lines.Count/2)
                            {
                                Lines[Lines.Count - PauseTick-1].Pause = true;//划切完成暂停
                            }
                        }
                    }break;
                    case 2://每隔暂停
                    {
                        if(PauseTick>0)
                        {
                            int i = PauseTick - 1;
                            while (i <Lines.Count)
                            {
                                Lines[i].Pause = true;
                                i += PauseTick;
                            }
                        }
                    }break;
                case 3://累计暂停
                    {
                        if(PauseTick>0&&PauseTick<Lines.Count)
                        {
                            Lines[PauseTick-1].Pause = true;
                        }
                    }break;

                default:
                    break;
            }
            if (Lines.Count > 0)
            {
                PausePos.X = Lines[0].StartPos.X;//起始位置为第一刀的位置
            }
            else
            {
                PausePos.X = this.StartPos.X;//暂停时X位置为工作台中心位置
            }
            PausePos.Y = this.StartPos.Y;
        }

        private void CalculateYStartPos()
        {
            float f = Globals.TabCenter.X - Center.X;
            if (Dir)
            {
                this.StartPos.X = Globals.TabCenter.X+f+width/2;//正向划切
            }
            else
            {
                this.StartPos.X = Globals.TabCenter.X + f - width / 2;//反向划切
            }
            float x = (int)Math.Truncate(Width / 2 / IndexStep);//预计单向划切刀数
            float y = (AlignPoint.Y - Center.Y) % IndexStep;    //获取偏移值
            switch (Style)
            {
                case CutStyle.FrontToBack://从前向后
                    {
                        this.Forward = false;
                        this.StartPos.Y = Center.Y + y + x * IndexStep- YPosAdj;    //加上偏移值和响应刀数的距离
                    }
                    break;
                case CutStyle.BackToFront://从后向前
                    {
                        this.Forward = true;
                        this.StartPos.Y = Center.Y + y - x * IndexStep+ YPosAdj;
                    }
                    break;
                case CutStyle.AlignToBack:
                    {
                        this.Forward = false;
                        this.StartPos.Y = AlignPoint.Y - YPosAdj;//起始位置等于对准位置
                    }
                    break;
                case CutStyle.AlignToFront:
                    {
                        this.Forward = true;
                        this.StartPos.Y = AlignPoint.Y+ YPosAdj;//起始位置等于对准Y位置
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
