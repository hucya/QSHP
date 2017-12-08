using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace QSHP.SIM
{
    public class MotorModel : SimModel
    {
        public const float LimitDistance = 0.5f;
        public event ProgressChangedEventHandler ProgressChanged;
        PIDProvider PIDVel;
        PIDProvider PIDPos;
        MotorStatus status;
        public int dir = 1;
        public const float Tr = 0.1f;
        #region 定义变量
        //DispatcherTimer timer = new DispatcherTimer(); .
        private BackgroundWorker bkWorker;//工作线程
        private bool enabled = false;     //使能
        private int index = 0;            //编号
        private bool inPosition = true;   //是否到位
        private bool ampCFault = false;   //驱动器故障
        private bool pLimit = false;      //正限位
        private bool nLimit = false;      //负限位
        private bool pSoftLimit = false;  //正软件限位
        private bool nSoftLimit = false;  //负软件限位
        private bool limitEnable = true;  //限位使能
        private float startPosition = 0;  //运动开始位置
        private float position = 0;       //当前位置
        private float speed = 0;          //当前速度
        private float accSpeed = 0;       //加速度
        private float perCTS = 1;         //轴比系数
        private float hwDistance = 1000;  //轴长度
        private bool homeSucessful = false;//回零成功
        private float homeOffset = 0;      //回零偏移
        private float homeSpeed = 0;       //回零速度
        private float homeAcc = 0;         //回零加速度
        private HomeMode homeMode = HomeMode.Default;   //回零模式
        private float homePos = 0;          //回零位置
        private float targetSpeed = 0;      //目标速度
        private float targetPos = 0;        //目标位置
        private float posSoftLimit = 0;     //正软限位位置
        private float negSoftLimit = 0;     //负软限位位置
        private float posHwLimit = 0;       //正硬限位位置
        private float negHwLimit = 0;       //负应限位位置
        private float posLimit = 0;         //正限位位置
        private float negLimit = 0;         //负限位位置
        private float allowErr = 0;         //最大允许误差
        private bool stop = false;
        #endregion

        public MotorModel()
        {
            bkWorker = new BackgroundWorker();
            bkWorker.WorkerSupportsCancellation = true;
            bkWorker.DoWork += CycleWorker_DoWork;
            bkWorker.WorkerReportsProgress = true;
            bkWorker.ProgressChanged += CycleWorker_ProgressChanged;
            PIDVel = new PIDProvider();
            PIDPos = new IncPIDProvider();
            PIDVel.Reset();
            PIDPos.Reset();
            PIDVel.MaxValue = 400;
            PIDVel.MinValue = -400;
            PIDPos.KI = 0.6f;
        }

        private void CycleWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
            {
                if (stop)
                {
                    speed = 0;
                }
                ProgressChanged(sender, e);
            }
        }

        private void CycleWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bkWorker.CancellationPending && !stop)
            {
                if (connected && enabled )
                {
                    float pos = Math.Abs(PIDVel.TargeValue * Tr);
                    if (Math.Abs(PIDPos.Err) > 2 * pos && pos < Math.Abs(PIDPos.TargeValue))
                    {
                        PIDVel.Realize();
                        PIDPos.Value += (float)((PIDVel.Value + PIDVel.StartValue) / 2 * Tr);
                        PIDVel.StartValue = PIDVel.Value;
                        PIDPos.StartValue = PIDPos.Value;
                    }
                    else
                    {
                        PIDPos.Value = PIDPos.Realize();
                        PIDVel.Value = (PIDPos.Value - PIDPos.StartValue) / Tr;
                        PIDVel.StartValue = PIDVel.Value;
                        PIDPos.StartValue = PIDPos.Value;
                    }
                    position = startPosition + PIDPos.Value;
                    speed = PIDVel.Value;
                    if (PIDPos.Err == 0)
                    {
                        PIDVel.Reset();
                        speed = PIDVel.Value;
                        bkWorker.CancelAsync();
                    }
                    bkWorker.ReportProgress(0);
                }
                Thread.Sleep((int)(Tr * 1000));
            }
            bkWorker.ReportProgress(0);
        }

        #region 属性

        public override AskMode Mode
        {
            get
            {
                return base.Mode;
            }
            set
            {
                if (base.Mode != value)
                {
                    base.Mode = value;
                    InitAmpcStatus();
                }
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (connected)
                {
                    enabled = value;
                }
            }
        }

        public int Index
        {
            get { return index; }
            set
            {
                if (connected && !enabled)
                {
                    index = value;
                }
            }
        }

        public bool InPosition
        {
            get
            {
                if (Mode != AskMode.Auto)
                {
                    return inPosition;
                }
                return inPosition | Math.Abs(targetPos - position) < allowErr;
            }
            set
            {
                inPosition = value;
            }
        }

        public bool AmpCFault
        {
            get
            {
                if (Mode != AskMode.Auto)
                {
                    return ampCFault;
                }
                else
                {
                    return ampCFault | position > posHwLimit | position < negHwLimit;
                }
            }
            set
            {
                ampCFault = value;
            }
        }

        public bool PLimit
        {
            get
            {
                if (Mode != AskMode.Auto)
                {
                    return pLimit;
                }
                else
                {
                    return pLimit | Math.Abs(posHwLimit - position) < (LimitDistance + allowErr);
                }
            }
            set
            {
                pLimit = value;
            }
        }

        public bool NLimit
        {
            get
            {
                if (Mode != AskMode.Auto)
                {
                    return nLimit;
                }
                else
                {
                    return nLimit | Math.Abs(negHwLimit - position) < (LimitDistance + allowErr);
                }
            }
            set
            {
                nLimit = value;
            }
        }

        public bool PSoftLimit
        {
            get
            {
                if (Mode != AskMode.Auto)
                {
                    return pSoftLimit;
                }
                else
                {
                    return pSoftLimit | Math.Abs(posSoftLimit - position) < (LimitDistance + allowErr);
                }
            }
            set
            {
                pSoftLimit = value;
            }
        }

        public bool NSoftLimit
        {
            get
            {
                if (Mode != AskMode.Auto)
                {
                    return nSoftLimit;
                }
                else
                {
                    return Math.Abs(negSoftLimit - position) < (LimitDistance + allowErr);
                }
            }
            set
            {
                nSoftLimit = value;
            }
        }

        public float Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public float AccSpeed
        {
            get { return accSpeed; }
            set { accSpeed = value; }

        }

        public float PerCTS
        {
            get { return perCTS; }
            set { perCTS = value; }
        }

        public float HwDistance
        {
            get { return hwDistance; }
            set { hwDistance = value; }
        }

        public bool HomeSucessful
        {
            get { return homeSucessful; }
            set { homeSucessful = value; }
        }

        public float HomeOffset
        {
            get { return homeOffset; }
            set { homeOffset = value; }
        }

        public float HomeSpeed
        {
            get { return homeSpeed; }
            set { homeSpeed = value; }
        }

        public float HomeAcc
        {
            get { return homeAcc; }
            set { homeAcc = value; }
        }

        public HomeMode HomeMode
        {
            get { return homeMode; }
            set { homeMode = value; }
        }

        public float HomePos
        {
            get
            {
                return homePos;
            }
            set
            {
                homePos = value;
            }
        }

        public float TargetSpeed
        {
            get
            {
                return targetSpeed;
            }
            set
            {
                targetSpeed = value;
            }
        }

        public float TargetPos
        {
            get
            {
                return targetPos;
            }
            set
            {
                targetPos = value;
                PIDPos.Reset();
                PIDVel.Reset();
            }
        }

        public float PosSoftLimit
        {
            get { return posSoftLimit; }
            set { posSoftLimit = value; }
        }

        public float NegSoftLimit
        {
            get { return negSoftLimit; }
            set { negSoftLimit = value; }
        }

        public float PosHwLimit
        {
            get { return posHwLimit; }
            set { posHwLimit = value; }
        }

        public float NegHwLimit
        {
            get { return negHwLimit; }
            set { negHwLimit = value; }
        }

        public float PosLimit
        {
            get { return posLimit; }
            set { posLimit = value; }
        }

        public float NegLimit
        {
            get { return negLimit; }
            set { negLimit = value; }
        }

        public float AllowErr
        {
            get { return allowErr; }
            set { allowErr = value; }
        }

        public bool LimitEnable
        {
            get
            {
                return limitEnable;
            }
            set
            {
                limitEnable = value;
            }
        }

        public MotorStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }


        #endregion

        #region 配置方法
        public override bool RunProgram()
        {
            if (connected && enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InitAmpcStatus()
        {
            if (connected)
            {
                ampCFault = false;
                pSoftLimit = false;
                nSoftLimit = false;
                pLimit = false;
                nLimit = false;
                inPosition = true;
                homeSucessful = true;
                Status = MotorStatus.Ready;
                return true;
            }
            else
            {
                Status = MotorStatus.DisConnect;
                return false;
            }
        }

        public bool InitAmpC()
        {
            connected = true;
            InitAmpcStatus();
            EnableAmpC();
            Status = MotorStatus.Connect;
            return connected;
        }

        public bool CloseAmpC()
        {
            connected = false;
            enabled = false;
            Status = MotorStatus.Disable;
            return connected;
        }
        public bool ResetAmpC()
        {
            enabled = false;
            InitAmpC();
            Status = MotorStatus.Connect;
            PIDVel.Reset();
            PIDPos.Reset();
            EnableAmpC();
            return enabled;
        }
        public bool EnableAmpC()
        {
            if (connected)
            {
                enabled = true;
                Status = MotorStatus.Enable;
                bkWorker.RunWorkerAsync();
            }
            else
            {
                enabled = false;
            }
            return enabled;
        }

        public bool DisableAmpC()
        {
            if (connected)
            {
                Status = MotorStatus.Disable;
                bkWorker.CancelAsync();
                enabled = false;
            }
            else
            {
                enabled = true;
            }
            return !enabled;
        }

        public bool SetPrePosition(float fPos)
        {
            if (connected)
            {
                targetPos = fPos;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetSoftPLimit(float mm)
        {
            if (connected)
            {
                PosSoftLimit = mm;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetSoftNLimit(float mm)
        {
            if (connected)
            {
                NegSoftLimit = mm;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetLimitSwitch(bool enable)
        {
            if (connected)
            {
                limitEnable = enable;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GetLimitSwitch()
        {
            return limitEnable & connected;
        }
        public bool SetHomeMode(HomeMode mode)
        {
            if (connected)
            {
                homeMode = mode;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetHomeAcc(float acc)
        {
            if (connected)
            {
                HomeAcc = acc;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetHomeSpeed(float speed)
        {
            if (connected)
            {
                homeSpeed = speed;
                targetSpeed = speed;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetHomeOffset(float offset)
        {
            if (connected)
            {
                HomeOffset = offset;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetSpeed(float speed)
        {
            if (connected)
            {
                targetSpeed = speed;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetAcc(float acc)
        {
            if (connected)
            {
                accSpeed = acc;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ClearAmpCFault()
        {
            if (connected)
            {
                ampCFault = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetCountsPerCTS(float fCts)
        {
            if (connected)
            {
                perCTS = fCts;
                return true;
            }
            else
            {
                return false;
            }
        }

        public float GetCountsPerCTS()
        {
            return perCTS;
        }
        #endregion

        private bool ResetMoveValue(float pos)
        {
            if (pos > 0)
            {
                PIDVel.Reset(Math.Abs(targetSpeed));       //速度调节为目标速度
            }
            else
            {
                PIDVel.Reset(-Math.Abs(targetSpeed));       //速度调节为目标速度
            }
            PIDPos.Reset(pos);             //目标位置为移动fpos个距离
            return true;
        }
        private bool ResetMoveValue()
        {
            PIDVel.Reset(0);
            PIDPos.Reset(0);
            if (bkWorker.IsBusy)
            {
                bkWorker.CancelAsync();
            }
            return true;
        }
        #region 运动方法
        public bool GoHome()
        {
            if (enabled)
            {
                speed = 0;
            }
            return enabled;
        }
        /// <summary>
        /// 移动相对距离
        /// </summary>
        /// <param name="fPos"></param>
        /// <returns></returns>
        public bool JogInc(float fPos)
        {
            if (enabled)
            {
                startPosition = position;        //将起始位置赋值为当前位置
                targetPos = startPosition + fPos;//计算出运动的目标位置
                ResetMoveValue(fPos);
                Status = MotorStatus.JogMove;
                if (!bkWorker.IsBusy)
                {
                    stop = false;
                    bkWorker.RunWorkerAsync();
                }
            }
            return enabled;
        }

        public bool JogAbs(float fPos)
        {
            if (enabled)
            {
                startPosition = position;
                targetPos = fPos;//移动到的目标位置
                ResetMoveValue(fPos - startPosition);
                if (!bkWorker.IsBusy)
                {
                    stop = false;
                    bkWorker.RunWorkerAsync();
                }
            }
            return enabled;
        }

        public bool JogDir(int nDir)
        {
            if (enabled)
            {
                if (nDir > 0)
                {
                    JogAbs(2000);
                }
                else if (nDir < 0)
                {
                    JogAbs(-2000);
                }
                else
                {
                    JogStop();
                }
            }
            return enabled;
        }

        public bool JogStop()
        {
            if (enabled)
            {
                startPosition = position;
                ResetMoveValue();
                stop = true;
            }
            return enabled;
        }

        #endregion
    }

    public enum HomeMode
    {
        Default = 0,
        Pos = 0,
        Neg = 1,
        Home = 2,
        User = 3
    }

    public enum MotorStatus
    {
        DisConnect=-1,
        Connect=0,
        DisEnable=1,
        Enable=2,
        Disable=3,
        Ready=4,
        PosMove=5,
        HomeMove=6,
        JogMove=7,
        AbsMove=8,
        Default=9
    }
}

