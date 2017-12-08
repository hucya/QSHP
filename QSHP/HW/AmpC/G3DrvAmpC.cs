using DRV02CTLLib;
using QSHP.Data;
using System;
using System.ComponentModel;
using System.Threading;
using System.Xml.Serialization;
namespace QSHP.HW.AmpC
{
    [XmlType("G3DrvAmpC",Namespace="")]
    public class G3DrvAmpC : AmpCProvider
    {
        private DRV02CTLLib.AmpC motor;
        private KEY_CODE hpKeyCode;
        private RET_CODE hpRetCode = RET_CODE.RET_NG;
        private DATA_EXP hpExp;
        private KEY_CODE pKeyCode;
        private RET_CODE pRetCode;
        private short hpTopCode;
        private short hpMainCode;
        private short hpSubCode;
        private short hpCount;
        private short pTopCode;
        private short pMainCode;
        private short pSubCode;
        private CHANNEL moCh = CHANNEL.SINGLE_CH;
        private bool homeSuccessful;
        private bool isInPosition;
        private bool m_bNegLimit;
        private bool m_bPosLimit;
        private bool m_bHomeLimit;
        private bool motorReady;
        private bool ampCReady;
        private bool limit;
        float pos = 0;
        float speed = 0;
        public byte errCode=255;
        private volatile bool cycFlag = true;
        private int jogNum = -2;
        private int wpData;
        private int scalPos;
        private bool jogStop;//判断为Jog模式停止还是急停
        private G3DrvConnecter connecter;
        private BackgroundWorker cycleWorker;
        public override AxisParams Param
        {
            get;
            set;
        }
        public override bool Enabled
        {
            get
            {
                return ampCReady & motorReady;
            }
        }
        public override bool HomeIsSuccessful
        {
            get
            {
                return homeSuccessful;
            }
        }
        public override bool IsInPosition
        {
            get
            {
                return isInPosition;
            }
        }
        public override bool AmpCFault
        {
            get
            {
                return errCode > 0;
            }
        }
        public override bool OnPLimit
        {
            get
            {
                return m_bPosLimit;
            }
        }
        public override bool OnNLimit
        {
            get
            {
                return m_bNegLimit;
            }
        }
        public override float RealPos
        {
            get
            {
                if (Enabled)
                {
                    return pos;
                }
                return 0f;
            }
        }
        public override float Speed
        {
            get
            {
                if (Enabled)
                {
                    if (jogNum == -2)
                    {
                        motor.GetParam(moCh, 342, 0, out hpCount, out hpExp, out wpData, out pTopCode, out pMainCode, out pSubCode, out pKeyCode, out pRetCode);
                        if (pRetCode == RET_CODE.RET_OK)
                        {
                            speed=(float)wpData / perCTS;
                        }
                        else
                        {
                            errCode = 255;
                        }
                    }
                    return speed;
                }
                return 0f;
            }
        }
        public override float PhyPos
        {
            get
            {
                if (Enabled)
                {
                    cycFlag = false;
                    motor.GetParam(moCh, 371, 0, out hpCount, out hpExp, out wpData, out pTopCode, out pMainCode, out pSubCode, out pKeyCode, out pRetCode);
                    if (pRetCode == RET_CODE.RET_OK)
                    {
                        return(float)wpData / perCTS;
                    }
                    else
                    {
                        errCode = 255;
                    }
                    cycFlag = true;
                    return 0;
                }
                return 0f;
            }
        }
        public override bool Connected
        {
            get
            {
                if (connecter == null)
                {
                    connecter = G3DrvConnecter.GetInstance();
                }
                return connecter.Connected;
            }
        }
        
        public G3DrvAmpC()
        {
            connecter = G3DrvConnecter.GetInstance();
            motor = connecter.AmpDriver;
            this.Param = new AxisParams();
            cycleWorker = new BackgroundWorker();
            cycleWorker.WorkerSupportsCancellation = true;
            cycleWorker.DoWork += new DoWorkEventHandler(cycleWorker_DoWork);
        }
        private void GetMotorStatusThread()
        {
            try
            {
                if (Connected && cycFlag)
                {
                    motor.GetParam(moCh, 320, 0, out hpCount, out hpExp, out wpData, out pTopCode, out pMainCode, out pSubCode, out pKeyCode, out pRetCode);
                    if (pRetCode == RET_CODE.RET_OK)
                    {
                        isInPosition = ((wpData >> 17 & 1) > 0);
                        homeSuccessful = ((wpData >> 18 & 1) > 0);
                        motorReady = ((wpData >> 9 & 1) > 0);
                        ampCReady = ((wpData >> 8 & 1) > 0);
                        if ((wpData >> 19 & 1) > 0)
                        {
                            errCode = (byte)(wpData >> 24 & 255);
                            if (errCode == 42 || errCode == 43 || errCode == 23)
                            {
                                motor.ClearError(moCh, out pTopCode, out pMainCode, out pSubCode, out pKeyCode, out pRetCode);
                            }
                        }
                        else
                        {
                            errCode = 0;
                        }
                    }
                    else
                    {
                        errCode = 255;
                    }
                }
                if (Connected && cycFlag)
                {
                    motor.GetParam(moCh, 321, 0, out hpCount, out hpExp, out wpData, out pTopCode, out pMainCode, out pSubCode, out pKeyCode, out pRetCode);
                    if (pRetCode == RET_CODE.RET_OK)
                    {
                        m_bNegLimit = ((wpData >> 29 & 1) > 0);
                        m_bPosLimit = ((wpData >> 30 & 1) > 0);
                        m_bHomeLimit = ((wpData >> 28 & 1) > 0);
                    }
                    else
                    {
                        errCode = 255;
                    }
                }
                if (Connected && cycFlag)
                {
                    motor.GetParam(moCh, 376, 0, out hpCount, out hpExp, out wpData, out pTopCode, out pMainCode, out pSubCode, out pKeyCode, out pRetCode);
                    pos = (float)wpData / perCTS;
                }
            }
            catch
            {
            }
        }
        private void SetMotorMoveThread()
        {
            try
            {
                if (Connected && Enabled && cycFlag)
                {
                    switch (jogNum)
                    {
                        case -1:
                            motor.MoveJog(moCh, JOG_DIR.DIR_CCW, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                            if (jogNum == -1)
                            {
                                jogNum = -2;
                            }
                            jogStop = true;
                            break;
                        case 0:
                            if (jogStop)
                            {
                                motor.MoveJog(moCh, JOG_DIR.DIR_STOP, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                            }
                            else
                            {
                                motor.MoveAbort(moCh, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                            }
                            if (jogNum == 0)
                            {
                                jogNum = -2;
                            }
                            jogStop = false;
                            break;
                        case 1:
                            motor.MoveJog(moCh, JOG_DIR.DIR_CW, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                            if (jogNum == 1)
                            {
                                jogNum = -2;
                            }
                            jogStop = true;
                            break;
                        case 3:
                            SetLimitSwitch(false);
                            //motor.MoveStartEv(moCh, 3, out hpKeyCode);
                            motor.MoveStart(moCh, 3, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                            SetLimitSwitch(true);
                            if (jogNum == 3)
                            {
                                jogNum = -2;
                            }
                            jogStop = false;
                            break;
                        case 5:
                            SetMotorRegisterPara(100, scalPos);
                            //motor.MoveStartEv(moCh, 5, out hpKeyCode);
                            motor.MoveStart(moCh, 5, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                            if (jogNum == 5)
                            {
                                jogNum = -2;
                            }
                            jogStop = false;
                            break;
                        case 7:
                            SetMotorRegisterPara(100, scalPos);
                            motor.MoveStart(moCh, 7, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                            if (jogNum == 7)
                            {
                                jogNum = -2;
                            }
                            jogStop = false;
                            break;
                    }
                }
            }
            catch
            {
            }
        }
        private void cycleWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!cycleWorker.CancellationPending)
            {
                GetMotorStatusThread();
                SetMotorMoveThread();
                Thread.Sleep(10);
            }
        }
        private bool SetMotorRegisterPara(int num, int data)
        {
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    cycFlag = false;
                    motor.SetParam(moCh, num, data, 0, 0, 1, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                    cycFlag = true;
                    result = (hpRetCode == 0);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        private bool SetMotorRegisterPara(int num, int data, bool ready)
        {
            bool result;
            try
            {
                if (ready)
                {
                    if (Enabled)
                    {
                        cycFlag = false;
                        motor.SetParam(moCh, num, data, 0, 0, 1, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                        cycFlag = true;
                        result = (hpRetCode == 0);
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    cycFlag = false;
                    motor.SetParam(moCh, num, data, 0, 0, 1, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                    cycFlag = true;
                    result = (hpRetCode == 0);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool InitAmpC()
        {
            bool result;
            try
            {
                if (!Connected)
                {
                    connecter.DevIndex = devIndex;
                    connecter.ConnectDriver();
                }
                if (Connected && motor.OpenCh(moCh) == RET_CODE.RET_OK)
                {
                    cycFlag = false;
                    motor.ChangeMode(moCh, 0, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                    bool flag = hpRetCode == 0;
                    flag &= EnableAmpC();
                    flag &= SetMotorRegisterPara(110, -234877005, false);
                    flag &= SetMotorRegisterPara(99, 8413399, false);
                    cycFlag = true;
                    if (flag && !cycleWorker.IsBusy)
                    {
                        cycleWorker.RunWorkerAsync();
                    }
                    flag &= ClearAmpCFault();
                    result = flag;
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool ResetAmpC()
        {
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    motor.Reset(moCh, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                    motor.ChangeMode(moCh, 0, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                    bool flag = hpRetCode == 0;
                    flag &= EnableAmpC();
                    flag &= ClearAmpCFault();
                    flag &= SetMotorRegisterPara(110, -234877005, false);
                    flag &= SetMotorRegisterPara(99, 8413399, false);
                    flag &= SetLimitSwitch(true);
                    result = (hpRetCode == 0);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool CloseAmpC()
        {
            if (Connected)
            {
                if (cycleWorker.IsBusy)
                {
                    cycleWorker.CancelAsync();
                }
                RET_CODE rET_CODE = motor.CloseCh(moCh);
                return rET_CODE == 0;
            }
            return true;
        }
        public override bool ClearAmpCFault()
        {
            bool result;
            try
            {
                if (!Connected)
                {
                    result = false;
                }
                else
                {
                    DisableAmpC();
                    motor.ResetError(moCh, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
                    EnableAmpC();
                    result = (hpRetCode == 0);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool EnableAmpC()
        {
            if (!Connected)
            {
                return false;
            }
            cycFlag = false;
            motor.ServoControl(moCh, 1, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
            cycFlag = true;
            return hpRetCode == 0;
        }
        public override bool DisableAmpC()
        {
            if (!Connected)
            {
                return false;
            }
            cycFlag = false;
            motor.ServoControl(moCh, 0, out hpTopCode, out hpMainCode, out hpSubCode, out hpKeyCode, out hpRetCode);
            cycFlag = true;
            return hpRetCode == 0;
        }
        public override bool SetPrePosition(float fPos)
        {
            if (!Connected)
            {
                return false;
            }
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    SetMotorRegisterPara(57, (int)Math.Abs(fPos * perCTS));
                    result = (hpRetCode == 0);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool SetSoftPLimit(float mm)
        {
            if (!Connected)
            {
                return false;
            }
            bool result;
            try
            {
                result = SetMotorRegisterPara(42, (int)(mm * perCTS));
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool SetSoftNLimit(float mm)
        {
            if (!Connected)
            {
                return false;
            }
            bool result;
            try
            {
                result = SetMotorRegisterPara(43, (int)(mm * perCTS));
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool SetLimitSwitch(bool enable)
        {
            if (!Connected)
            {
                return false;
            }
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    if (enable)
                    {
                        limit = SetMotorRegisterPara(39, -1440609605, false);
                    }
                    else
                    {
                        limit = !SetMotorRegisterPara(39, 572656315, false);
                    }
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool SetCountsPerCTS(float fCts)
        {
            if (Connected)
            {
                perCTS = fCts;
                SetMotorRegisterPara(320, (int)fCts);
                return true;
            }
            return false;
        }
        public override bool GetLimitSwitch()
        {
            return limit;
        }
        public override bool SetHomeMode(Limit mode)
        {
            return Connected;
        }
        public override bool SetHomeAcc(float acc)
        {
            if (!Connected)
            {
                return false;
            }
            bool result;
            try
            {
                bool flag = SetMotorRegisterPara(72, (int)acc);
                result = (flag & SetMotorRegisterPara(76, (int)acc));
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool SetHomeSpeed(float speed)
        {
            if (!Connected)
            {
                return false;
            }
            bool result;
            try
            {
                result = SetMotorRegisterPara(70, (int)(speed * perCTS));
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool SetHomeOffset(float offset)
        {
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    bool flag = SetMotorRegisterPara(56, (int)Math.Abs(offset * perCTS));
                    result = flag;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool SetSpeed(float speed)
        {
            if (!Connected)
            {
                return false;
            }
            bool result;
            try
            {
                result = SetMotorRegisterPara(70, (int)(speed * perCTS));
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool SetAcc(float acc)
        {
            if (!Connected)
            {
                return false;
            }
            bool result;
            try
            {
                bool flag = SetMotorRegisterPara(79, (int)acc);
                result = (flag & SetMotorRegisterPara(73, (int)acc));
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool JogInc(float fPos)
        {
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    scalPos = (int)(fPos * perCTS);
                    jogNum = 7;
                    result = (hpRetCode == 0);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool GoHome()
        {
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    scalPos = (int)prePos;
                    jogNum = 3;
                    result = (hpRetCode == 0);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool JogAbs(float fPos)
        {
            bool result;
            try
            {
                scalPos = (int)(fPos * perCTS);
                jogNum = 5;
                result = (hpRetCode == 0);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool JogDir(int nDir)
        {
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    if (nDir == 1 || nDir == -1 || nDir == 0)
                    {
                        jogNum = nDir;
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool JogStop()
        {
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    jogNum = 0;
                    result = (hpRetCode == 0);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override bool JogDir(float fVel, float fAcc, int nDir)
        {
            bool result;
            try
            {
                if (!Enabled)
                {
                    result = false;
                }
                else
                {
                    if (nDir == 1 || nDir == -1 || nDir == 0)
                    {
                        SetMotorJogAcc(fAcc);
                        SetMotorJogSpeed(fVel);
                        jogNum = nDir;
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public bool SetMotorJogAcc(float acc)
        {
            bool result;
            try
            {
                bool flag = SetMotorRegisterPara(79, (int)acc);
                result = (flag & SetMotorRegisterPara(73, (int)acc));
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public bool SetMotorJogSpeed(float speed)
        {
            bool result;
            try
            {
                result = SetMotorRegisterPara(71, (int)(speed * perCTS));
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public override void Dispose()
        {
            if (cycleWorker.IsBusy)
            {
                cycleWorker.CancelAsync();
            }
            CloseAmpC();
            cycleWorker.Dispose();
            connecter.Dispose();
            base.Dispose();
        }
    }
}
