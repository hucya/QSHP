using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSHP.Com;
using PCOMMSERVERLib;

namespace QSHP.HW
{
    internal class PmacConnecter : IDisposable
    {
        private static PmacConnecter uniqueInstance = null;
        private string answer = string.Empty;
        private static readonly object locker = new object();

        private bool connected = false;

        private int devIndex = 0;

        private byte errCode = 0;

        public PmacDeviceClass Pmac = null;

        public int DevIndex
        {
            get { return devIndex; }
            set { devIndex = value; }
        }

        public bool Connected
        {
            get
            {
                return connected;
            }
        }

        PmacConnecter()
        {
            Pmac = new PmacDeviceClass();

        }

        public static PmacConnecter GetInstance()
        {
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new PmacConnecter();
                    }
                }
            }
            return uniqueInstance;
        }

        public bool ConnectDriver()
        {
            if (connected && devIndex != -1)
            {
                return true;
            }
            bool flag = false;
            try
            {
                if (devIndex != -1)
                {
                    Pmac.Open(devIndex, out flag);
                    connected = flag;
                    if (!flag)
                    {
                        //devIndex = -1;
                        return false;
                    }
                    else
                    {
                        return SendCommand("#1J/#2J/#3J/#4J/");
                    }
                }
                else
                {
                    Pmac.SelectDevice(0, out devIndex, out flag);
                    if (flag)
                    {
                        Pmac.Open(devIndex, out flag);
                        if (!flag)
                        {
                            devIndex = -1;
                            return false;
                        }
                        else
                        {
                            return SendCommand("#1J/#2J/#3J/#4J/");
                        }
                    }
                    else
                    {
                        devIndex = -1;
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

        }

        public bool DisConnectDriver()
        {
            try
            {
                if (devIndex != -1)
                {
                    SendCommand("A");
                    ResetPmac();
                    Pmac.Abort(devIndex);
                    Pmac.Close(devIndex);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SendCommand(string cmd)
        {
            if (Connected)
            {
                try
                {
                    lock (locker)
                    {
                        string answer = string.Empty;
                        int status = 0;
                        Pmac.GetResponseEx(DevIndex, cmd, false, out answer, out status);
                        errCode = (byte)(status >> 56);
                    }
                    return errCode == 0x80;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public float GetFloatValue(string cmd)
        {
            answer = string.Empty;
            Double result = 0;
            if (Connected)
            {
                try
                {
                    lock (locker)
                    {
                        int status = 0;
                        Pmac.GetResponseEx(DevIndex, cmd, false, out answer, out status);
                        Pmac.strto32f(answer, out result);
                        errCode = (byte)(status >> 56);
                    }
                    return (float)result;
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public UInt32 GetUInt32Value(string cmd)
        {
            answer = string.Empty;
            Double result = 0;
            if (Connected)
            {
                try
                {
                    lock (locker)
                    {
                        int status = 0;
                        Pmac.GetResponseEx(DevIndex, cmd, false, out answer, out status);
                        Pmac.strto32f(answer, out result);
                        errCode = (byte)(status >> 56);
                    }
                    return (UInt32)result;
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public bool SelectPmac()
        {
            try
            {
                if (connected)
                {
                    Pmac.Close(devIndex);
                }
                bool flag = false;
                Pmac.SelectDevice(NativeMethods.GetForegroundWindow().ToInt32(), out devIndex, out flag);
                return flag;
            }
            catch
            {
                return false;
            }
        }

        public bool ResetPmac()
        {
            try
            {
                if (connected && devIndex != -1)
                {
                    int status;
                    Pmac.PmacReset(devIndex, "$$$", false, out status);
                    errCode = (byte)(status >> 56);
                    return errCode == 0x80;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public void Dispose()
        {
            if (Connected)
            {
                DisConnectDriver();
            }
        }
    }
}
