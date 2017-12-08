using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Xml.Serialization;

namespace QSHP.HW.Spindle
{
    [XmlInclude(typeof(SMSpindleProvider)), XmlInclude(typeof(VFSpindleProvider))]
    public abstract class SpindleProvider : ISpindleProvider
    {
        #region 字段及属性
        protected int baudRate = 9600;
        /// <summary>
        /// 默认设置速度为0
        /// </summary>
        protected float setSpeed = 0;
        /// 默认运转速度为0rpm
        /// </summary>
        protected float workSpeed = 0;
        /// <summary>
        /// 默认工作电流
        /// </summary>
        protected float workCur = 0;
        /// <summary>
        /// 默认周期为100 ms
        /// </summary>
        private int samplingMs = 100;
        /// <summary>
        /// 周期性发送标志位
        /// </summary>
        protected bool cycleFlag = false;
        /// <summary>
        /// 等待标志位
        /// </summary>
        protected bool waitFlag = false;
        /// <summary>
        /// 硬件索引
        /// </summary>
        private int ampCIndex = 1;
        /// <summary>
        /// 是否初始化成功标志位
        /// </summary>
        protected bool isInit = false;
        /// <summary>
        /// 主轴是否开启标志位
        /// </summary>
        protected bool swFlag = false;
        /// <summary>
        /// 错误故障代码
        /// </summary>
        protected int errCode = 0xFD;
        /// <summary>
        /// 当前速度是否为0
        /// </summary>
        public virtual bool SpeedZore
        {
            get
            {
                return workSpeed == 0;
            }
        }
        public virtual float  SetSpeed
        {
            get
            {
                return setSpeed;
            }
        }
        [XmlAttribute("Baud")]
        public int BaudRate
        {
            get
            {
                return baudRate;
            }
            set
            {
                baudRate = value;
            }
        }
        /// <summary>
        /// 设置最小采样周期
        /// </summary>
        [XmlAttribute("Sampling")]
        public int SamplingMs
        {
            get
            {
                return samplingMs;
            }
            set
            {
                if (value < 5)
                {
                    value = 5;
                }
                if (value > 3000)
                {
                    value = 3000;
                }
                samplingMs = value;
            }
        }
        /// <summary>
        /// 循环工作线程
        /// </summary>
        BackgroundWorker cycleWorker;
        /// <summary>
        /// 当前运转速度稳定
        /// </summary>
        public bool SpeedStabled
        {
            get
            {
                return Math.Abs(workSpeed - setSpeed) < 50;
            }
        }
        /// <summary>
        /// 电机索引
        /// </summary>
        [XmlAttribute("Driver")]
        public int DevIndex
        {
            get
            {
                return ampCIndex;
            }
            set
            {
                if (!isInit)
                {
                    ampCIndex = value;
                }
            }
        }
        [XmlAttribute("Index")]
        public virtual int AmpCIndex
        {
            get;
            set;
        }
        /// <summary>
        /// 是否初始化
        /// </summary>
        public bool IsInit
        {
            get
            {
                return isInit;
            }
        }
        /// <summary>
        /// 错误代码
        /// </summary>
        public int ErrCode
        {
            get
            {
                return errCode;
            }
        }
        /// <summary>
        /// 实时接收数据事件
        /// </summary>
        public event SamplingEventHandler UpdateSamplingHander;

        #endregion

        #region 重构析构内部函数

        public bool IsRunning
        {
            get
            {
                return SpeedZore;
            }
        }

        protected abstract bool UpdateSampling();

        protected SpindleProvider()
        {
            cycleWorker = new BackgroundWorker();
            cycleWorker.WorkerReportsProgress = true;
            cycleWorker.WorkerSupportsCancellation = true;
            cycleWorker.DoWork += new DoWorkEventHandler(cycleWorker_DoWork);
        }

        void cycleWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateSamplingHander.Invoke(this, (SpindleEventArgs)e.UserState);
        }

        void cycleWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!cycleWorker.CancellationPending)
            {
                if (cycleFlag)
                {
                    UpdateSampling();
                    //bool flag = UpdateSampling();
                    //if (flag && UpdateSamplingHander != null)
                    //{
                    //    SpindleEventArgs args = new SpindleEventArgs();
                    //    args.Status = GetSpdStatusString();
                    //    args.WorkCur = workCur;
                    //    args.WorkSpeed = workSpeed;
                    //    args.UpdateSucessful = flag;
                    //    args.ErrCode = errCode;
                    //    cycleWorker.ReportProgress(0, args);
                    //}
                }
                Thread.Sleep(samplingMs);
            }
            isInit = false;
        }
        #endregion

        #region 接口方法
        /// <summary>
        /// 连接变频器并初始化
        /// </summary>
        public virtual bool InitSpd()
        {
            if (!cycleWorker.IsBusy && isInit)
                cycleWorker.RunWorkerAsync();
            errCode = (byte)(isInit ? 0 : 0xFD);
            return isInit;
        }

        /// <summary> 
        /// 关闭电机断开连接需重新初始化操作
        /// </summary>
        public virtual bool CloseSpd()
        {
            if (cycleWorker.IsBusy)
            {
                cycleWorker.CancelAsync();
            }
            Thread.Sleep(samplingMs);
            errCode = 0xFC;
            return !cycleWorker.IsBusy;
        }
        /// <summary>
        /// 停止变频器运转
        /// </summary>
        public virtual bool StopSpd()
        {
            return isInit;
        }

        /// <summary>
        /// 变频器指定速度运转
        /// </summary>
        /// <param name="speed">设置运转速度</param>
        public virtual bool RunSpd(Int32 speed)
        {
            if (isInit)
            {
                setSpeed = speed;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 复位变频器
        /// </summary>
        public virtual bool ResetSpd()
        {
            return isInit;
        }

        /// <summary>
        /// 获取当前电流
        /// </summary>
        public float GetSpdCurrent()
        {
            return workCur;
        }

        /// <summary>
        /// 获取电机当前转速
        /// </summary>
        public float GetSpdSpeed()
        {
            return workSpeed;
        }

        /// <summary>
        /// 判断主轴是否开启
        /// </summary>
        public virtual bool GetSpdSW()
        {
            return swFlag;
        }

        /// <summary>
        /// 获取主轴错误
        /// </summary>
        /// <returns></returns>
        public bool GetSpdRrr()
        {
            return errCode > 0;
        }

        /// <summary>
        /// 获取主轴错误描述
        /// </summary>
        /// <returns></returns>
        public virtual string GetSpdStatusString()
        {
            if (GetSpdRrr())
            {
                return "故障";
            }
            else
            {
                return "正常";
            }
        }

        /// <summary>
        /// 获取详细的状态描述字符串
        /// </summary>
        /// <returns></returns>
        public virtual string GetStatusDetailDescription()
        {
            return GetSpdStatusString();
        }

        public virtual void Dispose()
        {
            if (isInit)
            {
                if (!SpeedZore)
                {
                    StopSpd();
                }
                CloseSpd();
            }
            GC.Collect();
        }
        #endregion
    }
}
