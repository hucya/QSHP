using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace QSHP.Data
{
    [Serializable]
    [XmlType("CutLine")]
    [XmlInclude(typeof(CutLine)), XmlInclude(typeof(CutSegment)), XmlInclude(typeof(CutChannel))]
    public class CutLine:EventArgs
    {
        static float backSpeed = 200;//所有的返回速度 均调用该速度

        static float selfPos = 30;  //所有的安全位置均调用该位置 默认为测高数值 + 工件厚度 +蓝膜厚度 +0.5

        static float useTime = 2f;//划切调度浪费时间

        protected CutSegment seg;

        protected int index = 0;

        protected float speed = 50;
        
        [XmlIgnore]
        public PointF StartPos = new PointF();

        protected float length = 100;

        protected CutState state = CutState.Enable|CutState.Abs | CutState.Dir| CutState.SigDir | CutState.Fixed| CutState.Forward;//使能/正向/单向/第一次划切/必须抬刀//固定宽度

        protected CutStep cutStep = CutStep.Ready;

        protected float reDepth = 5;

        protected float reDepth2 = 0;
        
        /// <summary>
        /// 索引号
        /// </summary>
        [XmlAttribute]
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        /// <summary>
        /// 切割速度
        /// </summary>
        public float Speed
        {
            get { return speed; }
            set 
            {
                if (value > 0)
                {
                    speed = value; 
                }
            }
        }
        /// <summary>
        /// 切割宽度
        /// </summary>
        [XmlIgnore]
        public float Length
        {
            get { return length; }
            set 
            {
                if (value >= 0)
                {
                    length = value; 
                }
            }
        }
        /// <summary>
        /// 绝对位置
        /// </summary>
        [XmlIgnore]
        public bool Abs
        {
            get
            {
                return (state & CutState.Abs) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.Abs;
                }
                else
                {
                    state &= (~CutState.Abs);
                }
            }
        }
        /// <summary>
        /// 是否暂停
        /// </summary>
        [XmlIgnore]
        public bool Pause
        {
            get
            {
                return (state&CutState.Pause) >0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.Pause;
                }
                else
                {
                    state &= (~CutState.Pause);
                }
            }
        }
        /// <summary>
        /// 是否要测高
        /// </summary>
        [XmlIgnore]
        public bool TestHeight
        {
            get
            {
                return (state & CutState.TestHeight) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.TestHeight;
                }
                else
                {
                    state &= (~CutState.TestHeight);
                }
            }
        }
        /// <summary>
        /// 切割状态
        /// </summary>
        [XmlIgnore()]
        public CutState State
        {
            get { return state; }
            set { state = value; }
        }

        [XmlIgnore]
        public CutSegment Seg
        {
            get
            {
                return seg;
            }

            set
            {
                seg = value;
            }
        }
        /// <summary>
        /// 切割耗时
        /// </summary>
        [XmlIgnore()]
        public virtual float PreTime
        {
            get
            {
                if (SinDir)//单向划切
                {
                    if (Dual)//划切多刀
                    {
                        return 2 * (length / Speed + length / this.BackSpeed+ useTime);
                    }
                    else
                    {
                        return length / Speed + length / this.BackSpeed+ useTime;
                    }
                }
                else//双向划切
                {
                    if (Dual)//划切多刀
                    {
                        return 2 * (length / Speed+useTime);
                    }
                    else
                    {
                        return length / Speed+useTime;
                    }
                }
            }
        }
        /// <summary>
        /// 切割方向
        /// </summary>
        [XmlIgnore]
        public bool Dir
        {
            get
            {
                return (state & CutState.Dir) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.Dir;
                }
                else
                {
                    state &= (~CutState.Dir);
                }
            }
        }
        /// <summary>
        /// 预留1
        /// </summary>
        [XmlElement("ReDepth")]
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
        /// <summary>
        /// 是否划切多刀
        /// </summary>
        [XmlIgnore]
        public bool Dual
        {
            get
            {
                return reDepth2 > 0;
            }
        }
        /// <summary>
        /// 预留2
        /// </summary>
        public float ReDepth2
        {
            get
            {
                return reDepth2;
            }
            set
            {
                if (value >= 0)
                {
                    reDepth2 = value;
                }
            }
        }
        /// <summary>
        /// 划切已完成
        /// </summary>
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
        /// <summary>
        /// 正在划切
        /// </summary>
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
        /// <summary>
        /// 第一刀划切
        /// </summary>
        [XmlIgnore]
        public bool FirstCut
        {
            get
            {
                return (state & CutState.FirstCut) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.FirstCut;
                }
                else
                {
                    state &= (~CutState.FirstCut);
                }
            }
        }
        /// <summary>
        /// 单向划切
        /// </summary>
        [XmlIgnore]
        public bool SinDir
        {
            get
            {
                return (state & CutState.SigDir) > 0;
            }
            set
            {
                if (value)
                {
                    state |= CutState.SigDir;
                }
                else
                {
                    state &= (~CutState.SigDir);
                }
            }
        }
        [XmlIgnore]
        public CutStep CutStep
        {
            get
            {
                return cutStep;
            }
            set
            {
                cutStep = value;
            }
        }

        [XmlIgnore]
        public virtual float SelfPos
        {
            get
            {
                return selfPos;
            }
            
            set
            {
                if (value > 5)
                {
                    selfPos = value;
                }
            }
        }
        [XmlIgnore]
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

        public void SetStyle(CutState style, bool enable=true)
        {
            if (enable)
            {
                state |= style;
            }
            else
            {
                state&=(~style);
            }
        }
        
        public override string ToString()
        {
            return string.Format("L{0}:Speed={1},Length={2},Dir={3},Pos={4}",index,speed,length,Dir,StartPos);
        }
    }
}
