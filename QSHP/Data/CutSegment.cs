using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.Data
{
    [XmlRoot("CutSegment")]
    public class CutSegment : CutLine
    {
        private List<CutLine> lines = new List<CutLine>();
        private CutChannel ch;
        protected int totalLine = 0;      //划切总数
        protected int cuttingIndex = 0;  //正在划切编号
        protected float preWidth = 0;     //单边预留宽度
        protected float indexStep = 1;  //分度1
        [XmlIgnore]
        public PointF Center = Globals.TabCenter;
        public string Name
        {
            get
            {
                return string.Format("SG{0}", index + 1);
            }
        }
        public bool Enable
        {
            get
            {
                return (state & CutState.Enable) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.Enable;
                }
                else
                {
                    state &= (~CutState.Enable);
                }
            }
        }
        [XmlIgnore]
        public CutChannel CH
        {
            get
            {
                return ch;
            }
            set
            {
                ch = value;
            }
        }
        /// <summary>
        /// 单边预留
        /// </summary>
        [XmlIgnore]
        public float PreWidth
        {
            get
            {
                return preWidth;
            }

            set
            {
                preWidth = value;
            }
        }
        /// <summary>
        /// 分度
        /// </summary>
        public float IndexStep
        {
            get
            {
                return indexStep;
            }

            set
            {
                indexStep = Math.Abs(value);
            }
        }
        public CutLine CuttingLine
        {
            get
            {
                if (cuttingIndex < Lines.Count)
                {
                    return Lines[cuttingIndex];
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 已切割数
        /// </summary>
        [XmlIgnore()]
        public int WaitCutNum
        {
            get
            {
                return Count - cuttingIndex;
            }
        }
        /// <summary>
        /// 切割总数
        /// </summary>
        [XmlElement("TotalNum")]
        public int TotalLine
        {
            get { return totalLine; }
            set { totalLine = value; }
        }
        /// <summary>
        /// 正在切割编号
        /// </summary>
        [XmlIgnore]
        public int CuttingIndex
        {
            get { return cuttingIndex; }
            set { cuttingIndex = value; }
        }
        [XmlIgnore]
        public bool Fixed
        {
            get
            {
                return (state & CutState.Fixed) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.Fixed;
                }
                else
                {
                    state &= (~CutState.Fixed);
                }
            }
        }
        [XmlIgnore]
        public bool Forward
        {
            get
            {
                return (state & CutState.Forward) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.Forward;
                }
                else
                {
                    state &= (~CutState.Forward);
                }
            }
        }
        public override float PreTime
        {
            get
            {
                float time = 0;
                foreach (var item in Lines)
                {
                    time += item.PreTime;
                }
                return time;
            }
        }

        public CutSegment()
        {

        }
        [XmlArrayItem("Segment")]
        public CutLine this[int index]
        {
            get
            {
                return Lines[index];
            }
            set
            {
                Lines[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return Lines.Count;
            }
        }
        [XmlIgnore]
        public List<CutLine> Lines
        {
            get
            {
                return lines;
            }

            set
            {
                lines = value;
            }
        }

        public void Add(CutLine item)
        {
            item.Index = Lines.Count;
            item.Seg = this;
            Lines.Add(item);
        }

        public bool Remove(CutLine item)
        {
            return Lines.Remove(item);
        }
        public override string ToString()
        {
            return string.Format("SEG{0}:Speed={1},Number={2},Length={3},Step={4},Pos={5}", index + 1, speed, Count, length, IndexStep, StartPos);
        }
        public void RepairXPosAndLength(float ypos, CutLine line)
        {
            if (!Fixed)//圆形工件
            {
                float offsetX = 2 * Globals.TabCenter.X - Center.X;
                float r = Length / 2;                           //为圆形的半径
                float a = Math.Abs(ypos - Center.Y) % Length;   //相对距离对直径求余数
                if (a > r)                                      //如果距离在半径和直径中间
                {
                    a = Length - a;                             //直接求剩余距离
                }
                float b = 0;
                if (a != r)
                {
                    b = (float)Math.Sqrt(r * r - a * a);
                }
                line.Length = b * 2 + PreWidth * 2;             //双边预留
                if (line.Dir)
                {
                    line.StartPos.X = offsetX + (b + PreWidth);// //正向划切 E|<------------<--|S
                }
                else
                {
                    line.StartPos.X = offsetX - (b + PreWidth);////反向划切 S|-->------------>|E
                }
            }
        }

        public void RepairXPosAndLength(float ypos)//重新修正所有未划切的位置和距离
        {
            float pos = ypos;
            for (int i = 0; i < totalLine; i++)
            {
                if (!Lines[i].Complate && !lines[i].Cutting)
                {
                    RepairXPosAndLength(pos, Lines[i]);
                    pos += IndexStep;//Y 加上当前的分度
                }
            }
        }
        public void RepairCutLines(int num)
        {
            if (num > cuttingIndex)
            {
                if (num < Count)
                {
                    //totalLine = num;
                    var ls = lines.Where(c => c.Index >= num).ToList();
                    foreach (var item in ls)
                    {
                        lines.Remove(item);
                        if (this.CH != null && this.CH.StandMode == false)//非标准模式
                        {
                            this.CH.Lines.Remove(item);
                        }
                    }
                }
                else
                {
                    int max = num - Count;
                    bool dir = this.Lines.Last().Dir;
                    float offsetX = 2 * Globals.TabCenter.X - Center.X;
                    int index = 0;
                    if (this.CH != null)
                    {
                        index = this.CH.Lines.IndexOf(this.Lines.Last());
                    }
                    for (int i = 0; i < max; i++)
                    {
                        CutLine line = new CutLine();
                        line.CutStep = CutStep.Ready;
                        line.ReDepth = this.ReDepth;
                        line.ReDepth2 = this.ReDepth2;
                        line.SinDir = this.SinDir;
                        line.Abs = false;//走相对运动
                        line.Speed = this.Speed;
                        line.BackSpeed = this.BackSpeed;
                        line.SelfPos = this.SelfPos;
                        line.Length = this.Length + PreWidth * 2;
                        if (SinDir || Dual)//单向划切或者多刀划切
                        {
                            line.Dir = this.Dir;
                        }
                        else//双向划切
                        {
                            dir = !dir;//方向取反
                            line.Dir = dir;
                        }
                        line.StartPos.Y = Forward ? indexStep : -indexStep;
                        line.StartPos.X = line.Dir ? (offsetX + line.Length / 2) : (offsetX - line.Length / 2);//暂时不修正划切起始位置 等划切开始时修正
                        Add(line);
                        if (this.CH != null && this.CH.StandMode == false)
                        {
                            this.CH.Lines.Insert(index++, line);
                        }
                    }
                }
            }
        }

        public void RepairCutDeapth(float deap)
        {
            float dep1 = ReDepth;
            float dep2 = ReDepth2;
            bool flag = this.Dual;
            if (this.Dual)
            {
                if (deap>=dep1)//变更预留值大于预留一直接将预留一设置为变更值
                {
                    dep1 = deap;
                    dep2 = 0;
                }
                else
                {
                    dep2 = deap;
                }
            }
            else
            {
                dep1 = deap;
                dep2 = 0;
            }
            foreach (var item in lines)
            {
                if (!item.Cutting && !item.Complate)
                {
                    item.ReDepth = dep1;
                    item.ReDepth2 = dep2;
                }
            }
        }

        public void RepairCutIndexStep(float step)
        {
            foreach (var item in lines)
            {
                if (!item.Cutting && !item.Complate)
                {
                    item.StartPos.Y = step;
                }
            }
        }
        public virtual void RepairCutSpeed(float speed)
        {
            if (speed <= 0)
            {
                speed = 0.1f;
            }
            //this.speed = speed;
            foreach (var item in Lines)
            {
                if (!item.Complate && !item.Cutting)//当前没有切割完成并且也不在切割过程中
                {
                    item.Speed = speed;
                }
            }
        }

        public virtual void InitCutRunData(bool create = true)
        {
            this.Lines.Clear();
            bool dir = this.Dir;    //正向还是反向
            float offsetX = 2 * Globals.TabCenter.X - Center.X;
            SetStyle(CutState.Cutting | CutState.Complate | CutState.Pause, false);
            cuttingIndex = 0;
            if (create)
            {
                for (int i = 0; i < totalLine; i++)
                {
                    float h = 0;//距离工作台中心距离
                    CutLine line = new CutLine();
                    line.CutStep = CutStep.Ready;
                    line.ReDepth = this.ReDepth;
                    line.ReDepth2 = this.ReDepth2;
                    line.SinDir = this.SinDir;
                    line.Abs = false;//走相对运动
                    line.Speed = this.Speed;
                    line.BackSpeed = this.BackSpeed;
                    line.SelfPos = this.SelfPos;
                    if (SinDir || Dual)//单向划切或者多刀划切
                    {
                        line.Dir = this.Dir;
                    }
                    else//双向划切
                    {
                        line.Dir = dir;
                        dir = !dir;
                    }
                    float step = 0;
                    if (Forward)//向前划切
                    {
                        step = indexStep;
                    }
                    else
                    {
                        step = -indexStep;
                    }
                    h = StartPos.Y + step * i;
                    if (line.Abs)
                    {
                        line.StartPos.Y = h;    //Y轴的位置为当前位置+乘以偏移位置*i
                    }
                    else
                    {
                        if (i == 0)
                        {
                            line.StartPos.Y = 0;    //第一刀分度配置为0
                        }
                        else
                        {
                            line.StartPos.Y = step;
                        }
                    }
                    if (Fixed)                                                      //方片处理
                    {
                        line.Length = this.Length + PreWidth * 2;                   //为双边预留
                        if (line.Dir)                                               //正向划切 E|<------------<--|S
                        {
                            line.StartPos.X = offsetX + line.Length / 2;           //起始位置-单边预留
                        }
                        else                                                        //反向划切 S|-->------------>|E
                        {
                            line.StartPos.X = offsetX - line.Length / 2;           //起始位置-宽度-单边预留
                        }
                    }
                    else                                                //宽度进行处理
                    {
                        float r = Length / 2;                           //为圆形的半径
                        float a = Math.Abs(h - Center.Y) % Length;      //相对距离对直径求余数
                        if (a > r)                                      //如果距离在半径和直径中间
                        {
                            a = Length - a;                             //直接求剩余距离
                        }
                        float b = 0;
                        if (a != r)
                        {
                            b = (float)Math.Sqrt(r * r - a * a);
                        }
                        line.Length = b * 2 + PreWidth * 2;             //双边预留
                        if (line.Dir)
                        {
                            line.StartPos.X = offsetX + (b + PreWidth);// //正向划切 E|<------------<--|S
                        }
                        else
                        {
                            line.StartPos.X = offsetX - (b + PreWidth);////反向划切 S|-->------------>|E
                        }
                    }
                    this.Add(line);
                }
                totalLine = this.Lines.Count;
            }
        }


    }
}
