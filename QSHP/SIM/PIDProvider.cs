using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSHP.SIM
{
    /// <summary>
    /// 普通PID算法
    /// </summary>
    public class PIDProvider
    {
        protected float Kp=0f;
        protected float Ki=0.2f;
        protected float Kd=0f;
        protected float err = 0f;
        protected float errNext = 0f;
        protected float errLast = 0f;
        protected float intergral = 0f;
        protected float deadBand = 0.001f;
        protected float maxValue = float.MaxValue;
        protected float minValue = float.MinValue;
        protected float startValue = 0;
        protected float curValue = 0;
        protected float targeValue = 0;

        public float MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        public float Err
        {
            get
            {
                return targeValue - curValue;
            }
        }

        public float MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }

        public float KP
        {
            get { return Kp; }
            set { Kp = value; }
        }

        public float KI
        {
            get { return Ki; }
            set { Ki = value; }
        }

        public float KD
        {
            get { return Kd; }
            set { Kd = value; }
        }

        public float DeadBand
        {
            get { return deadBand; }
            set { deadBand = value; }
        }

        public float TargeValue
        {
            get
            {
                return targeValue;
            }
            set
            {
                targeValue=value;
            }
        }

        public float StartValue
        {
            get
            {
                return startValue;
            }
            set
            {
                startValue = value;
            }
        }

        public float Value
        {
            get 
            {
                return curValue;
            }
            set
            {
                this.curValue = value;
            }
        }

        public void Reset()
        {
            err = 0f;
            errNext = 0f;
            errLast = 0f;
            intergral = 0f;
            StartValue = 0;
            curValue = 0;
            targeValue = 0;
        }
        public void Reset(float targe)
        {
            err = 0f;
            errNext = 0f;
            errLast = 0f;
            intergral = 0f;
            StartValue = 0;
            curValue = 0;
            targeValue = targe;
        }

        public virtual float Realize()
        {
            err = targeValue - curValue;
            intergral += err;
            if (Math.Abs(err) > deadBand)
            {
                curValue = Kp * err + Ki * intergral + Kd * (err - errNext);
            }
            else
            {
                curValue = targeValue;
                err = 0;
                intergral = 0;
            }
           
            errNext = err;
            return curValue;
        }
    }
    /// <summary>
    /// 增量式PID
    /// </summary>
    public class IncPIDProvider : PIDProvider
    {
        public override float Realize()
        {
            err = targeValue - curValue;
            if (Math.Abs(err) > deadBand)
            {
                curValue += (Kp * (err - errNext) + Ki * err + Kd * (err - 2 * errNext + errLast));
            }
            else
            {
                curValue = targeValue;
                err = 0;
            }
            errNext = err;
            errLast = errNext;
            return curValue;
        }
    }

    /// <summary>
    /// 积分分离型PID
    /// </summary>
    public class SprPIDProvider : PIDProvider
    {
        float index = 0;

        public override float Realize()
        {

            err = targeValue - curValue;
            if (Math.Abs(err) > targeValue)
            {
                index = 0;
            }
            else
            {
                index = 1;
                intergral += err;
            }
            if (Math.Abs(err) > deadBand)
            {
                curValue = Kp * err + index * Ki * intergral + Kd * (err - errNext);
            }
            else
            {
                curValue = targeValue;
                err = 0;
            }
           
            errNext = err;
            errLast = errNext;
            return curValue;
        }
    }

    /// <summary>
    /// 抗积分饱和PID算法  I值较大
    /// </summary>
    public class StrPIDProvider : PIDProvider
    {
        float index = 0;
        public override float Realize()
        {

            err = targeValue - curValue;
            if (err > maxValue)
            {
                if (Math.Abs(err) > targeValue)
                {
                    index = 0;
                }
                else
                {
                    index = 1;
                    if (err < 0)
                    {
                        intergral += err;
                    }
                }
            }
            else if (err < minValue)
            {
                if (Math.Abs(err) > targeValue)
                {
                    index = 0;
                }
                else
                {
                    index = 0;
                    if (err > 0)
                    {
                        intergral += err;
                    }
                }
            }
            else
            {
                if (Math.Abs(err) > targeValue)
                {
                    index = 0;
                }
                else
                {
                    index = 1;
                    intergral += err;
                }
            }
            if (Math.Abs(err) > deadBand)
            {
                curValue = Kp * err + index * Ki * intergral + Kd * (err - errNext);
            }
            else
            {
                curValue = targeValue;
                err = 0;
            }
           
            errNext = err;
            errLast = errNext;
            return curValue;
        }
    }


    /// <summary>
    /// 可变积分PID算法  I值较大
    /// </summary>
    public class VarPIDProvider : PIDProvider
    {
        float index = 0;
        public override float Realize()
        {
            err = targeValue - curValue;
            if (Math.Abs(err) > targeValue)
            {
                index = 0;
            }
            else if (Math.Abs(err) < 0.8 * targeValue)
            {
                index = 1;
                intergral += err;
            }
            else
            {
                if (targeValue == Math.Abs(err))
                {
                    index = 1;
                }
                else
                {
                    index = (targeValue - Math.Abs(err)) / targeValue * 10;
                }
                intergral += err;
            }
            if (Math.Abs(err) > deadBand)
            {
                curValue = Kp * err + index * Ki * intergral + Kd * (err - errNext);
            }
            else
            {
                curValue = targeValue;
                err = 0;
            }
           
            errNext = err;
            errLast = errNext;
            return curValue;
        }
    }

}
