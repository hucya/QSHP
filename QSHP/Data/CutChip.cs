using QSHP.Com;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.Data
{
    [XmlInclude(typeof(CutChip)), XmlInclude(typeof(CutGroup))]
    public class CutChip
    {
        List<CutChannel> cHs = new List<CutChannel>();
        CutState state = CutState.Enable | CutState.Dir | CutState.SigDir | CutState.Fixed | CutState.Order;//使能/正向/单向/第一次划切/必须抬刀//固定宽度
        int index = 0;
        bool readyCuted = false;
        float backSpeed = 200;
        float reDepth = 1;
        float reDepth2 = 0;
        float filmHeight = 0.07f;
        float workerHeight = 1f;
        float width = 100;
        float length = 100;
        float preWidth = 0;

        CutDir cutDir = CutDir.Positive;
        CutMode cutMode = CutMode.StandOnce;

        public static float SelfTickness = 0.5f;
        [XmlIgnore]
        public PointF Center;//中心坐标位置
        //[XmlIgnore]
        public PointF LeftTopPoint = new PointF(100, 100);

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
        public bool Complate
        {
            get
            {
                return (state & CutState.Complate) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.Complate;
                }
                else
                {
                    state &= (~CutState.Complate);
                }
            }
        }
        [XmlIgnore]
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

        public bool Order
        {
            get
            {
                return (state & CutState.Order) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.Order;
                }
                else
                {
                    state &= (~CutState.Order);
                }
            }
        }

        public float PreTime
        {
            get
            {
                float time = 0;
                foreach (var item in cHs)
                {
                    if (item.Enable)
                    {
                        time += item.PreTime;
                    }
                }
                return time;
            }
        }
        public bool Aligned
        {
            get
            {
                bool flag = true;
                foreach (var item in cHs)
                {
                    if (item.Enable)
                    {
                        flag &= item.TAligned;
                    }
                }
                return flag;
            }
        }

        public string Name
        {
            get
            {
                return string.Format("Chip{0}", Index+1);
            }
        }

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
        public bool Cutting
        {
            get
            {
                return (state & CutState.Cutting) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.Cutting;
                }
                else
                {
                    state &= (~CutState.Cutting);
                }
            }
        }

        public CutChannel this[int index]
        {
            get
            {
                return CHs[index % Count];
            }
            set
            {
                CHs[index % Count] = value;
            }
        }
        public int Count
        {
            get
            {
                return CHs.Count;
            }
        }
        public float BackSpeed
        {
            get
            {
                return backSpeed;
            }

            set
            {
                backSpeed = value;
            }
        }



        public CutDir CutDir
        {
            get
            {
                return cutDir;
            }

            set
            {
                cutDir = value;
            }
        }

        public CutMode CutMode
        {
            get
            {
                return cutMode;
            }
            set
            {
                cutMode = value;
            }
        }
        public float ReDepth
        {
            get
            {
                return reDepth;
            }

            set
            {
                reDepth = value;
            }
        }

        public float ReDepth2
        {
            get
            {
                return reDepth2;
            }

            set
            {
                reDepth2 = value;
            }
        }

        public float FilmHeight
        {
            get
            {
                return filmHeight;
            }

            set
            {
                filmHeight = value;
            }
        }

        public float WorkerHeight
        {
            get
            {
                return workerHeight;
            }

            set
            {
                workerHeight = value;
            }
        }

        public float Width
        {
            get
            {
                return width;
            }

            set
            {
                if (value > 0)
                {
                    width = value;
                }
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
                if (value > 0)
                {
                    length = value;
                }
            }
        }
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
        [XmlIgnore]
        public CutChannel CH1
        {
            get
            {
                if (Count < 1)
                {
                    Add(new CutChannel(30));
                }
                return cHs[0];
            }
        }
        [XmlIgnore]
        public CutChannel CH2
        {
            get
            {
                if (cHs.Count < 2)
                {
                    if (cHs.Count < 1)
                    {
                        Add(new CutChannel(30));
                    }
                    Add(new CutChannel(120));
                    cHs[1].Enable = false;
                }
                
                return cHs[1];
            }
        }
        [XmlIgnore]
        public bool ReadyCuted
        {
            get
            {
                return readyCuted;
            }
            set
            {
                readyCuted = value;
            }
        }
        public List<CutChannel> CHs
        {
            get
            {
                return cHs;
            }
            set
            {
                cHs = value;
            }
        }

        public void Add(CutChannel s)
        {
            if (s == null)
                return;
            if (!CHs.Contains(s))
            {
                s.Index = CHs.Count;
                s.Chip = this;
                CHs.Add(s);
            }
        }

        public bool Remove(CutChannel c)
        {
            return CHs.Remove(c);
        }
        public bool IsComplated
        {
            get
            {
                bool flag = true;
                foreach (var item in CHs)
                {
                    if (item.Enable)
                    {
                        flag &= item.Complate;
                    }
                }
                return flag;
            }
        }

        private void InitCutChannelData(CutChannel c, bool create, bool res = true)
        {
            if (c.Enable)
            {
                if (c.Fixed)
                {
                    if (res)//长度宽度反转
                    {
                        c.Length = length;
                        c.Width = width;
                    }
                    else
                    {
                        c.Length = width;
                        c.Width = length;
                    }
                }
                else
                {
                    c.Length = length;
                    c.Width = length;
                }
                c.PreWidth = PreWidth;//设置预划切宽度
                c.BackSpeed = backSpeed;
                switch (CutMode)
                {
                    case CutMode.StandOnce:
                    case CutMode.Stand:
                        {
                            c.StandMode = true;
                            c.ReDepth = ReDepth;    //划切预留一
                            c.ReDepth2 = ReDepth2;  //配置预留二
                        }
                        break;
                    case CutMode.AnyChannel://任意通道
                        {
                            c.StandMode = true;
                        }
                        break;
                    case CutMode.AnyStep:
                        {
                            c.StandMode = false;
                        }
                        break;
                    default:
                        {
                            c.StandMode = false;
                        }
                        break;
                }
                
                float angle = c.TRoatePos + c.TPosAdj;
                if (Center != Globals.TabCenter)
                {
                    c.Center = RotateMath.PointRotate(Globals.TabCenter, Center, -angle);
                }
                else
                {
                    c.Center = Center;
                }
                c.Fixed = this.Fixed;//圆片还是方片
                c.BackSpeed = backSpeed;
                c.SelfPos = Globals.TestHeightValue + filmHeight + workerHeight + SelfTickness;//当前测高值+工件厚度+膜厚 + 安全预留
                switch (cutDir)
                {
                    case CutDir.Positive:
                        {
                            c.SinDir = true;
                            c.Dir = true;
                        }
                        break;
                    case CutDir.Negative:
                        {
                            c.SinDir = true;
                            c.Dir = false;
                        }
                        break;
                    case CutDir.TwoWay:
                        {
                            c.SinDir = false;
                            c.Dir = true;
                        }
                        break;
                    default:
                        break;
                }
                c.InitCutRunData(create);
            }
        }

        public virtual void InitCutRunData(bool create = true)
        {
            SetStyle(CutState.Complate | CutState.Cutting | CutState.Pause, false);
            ReadyCuted = false;
            Center.X = LeftTopPoint.X + Length / 2; //中心坐标=左上角坐标-长度/2
            Center.Y = LeftTopPoint.Y + Width / 2;  //中心坐标 左上角坐标+长度/2
            if (Count < 1)//当前无切割通道，新建切割通道 hucya 
            {
                Add(new CutChannel(30));
            }
            for (int i = 0; i < CHs.Count; i++)
            {
                CHs[i].Chip = this;
                InitCutChannelData(CHs[i], create, i % 2 == 0);
            }
        }

        public void SetStyle(CutState style, bool enable = true)
        {
            if (enable)
            {
                state |= style;
            }
            else
            {
                state &= (~style);
            }
        }

        public override string ToString()
        {
            return string.Format("Chip{0}", index);
        }
    }
}
