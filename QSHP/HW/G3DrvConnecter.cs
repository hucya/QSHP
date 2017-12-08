using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DRV02CTLLib;
namespace QSHP.HW
{
    internal class G3DrvConnecter : IDisposable
    {
        private static G3DrvConnecter uniqueInstance = null;
        private string answer = string.Empty;
        private static readonly object locker = new object();

        private bool connected = false;

        private int devIndex = 3;

        internal DRV02CTLLib.AmpC AmpDriver = null;

        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }

        public int DevIndex
        {
            get { return devIndex; }
            set { devIndex = value; }
        }
        public static G3DrvConnecter GetInstance()
        {
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new G3DrvConnecter();
                    }
                }
            }
            return uniqueInstance;
        }
        public G3DrvConnecter()
        {
            AmpDriver = new AmpCClass();
        }

        public bool ConnectDriver(int num)
        { 
            devIndex=num;
            return ConnectDriver();
        }

        public bool ConnectDriver()
        {
            try
            {
                if (!connected)
                {
                    RET_CODE code = AmpDriver.OpenPort((PORT)devIndex);
                    connected = code == RET_CODE.RET_OK;
                    return connected;
                }
            }
            catch
            {
                connected = false;
            }
            return connected;
        }

        public bool DisConnectDriver()
        {
            try
            {
                if (connected)
                {
                    AmpDriver.ClosePort();
                }
                connected = false;
                return true;
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
