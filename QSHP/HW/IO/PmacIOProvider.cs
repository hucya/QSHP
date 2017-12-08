using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.HW.IO
{
    [XmlType("PmacIOProvider",Namespace="")]
    public class PmacIOProvider : IOProvider
    {
        private PmacConnecter connecter = null;
        PmacIOArgs param = new PmacIOArgs();
        private static bool enabled = false;
        private object locker = new object();
        public PmacIOProvider()
        {
            connecter = PmacConnecter.GetInstance();
        }
        public override bool Connected
        {
            get
            {
                if (connecter == null)
                {
                    connecter = PmacConnecter.GetInstance();
                }
                return connecter.Connected;
            }
        }
        public override bool Enabled
        {
            get
            {
                return enabled;
            }
        }
        public override IOParamArgs Params
        {
            get
            {
                return param;
            }
            set
            {
                param = value as PmacIOArgs;
            }
        }
        public bool SetValueMapAddress(PmacAddress addr)
        {
            if (addr != null)
            {
                return connecter.SendCommand(addr.ToString());
            }
            else
            {
                return false;
            }
        }

        public override  bool InitController()
        {
            if (!Connected)
            {
                connecter.DevIndex = DevIndex;
                connecter.ConnectDriver();
            }
            if (Connected&&!enabled)
            {
                bool flag = true;
                foreach (var item in param.InitCmd)
                {
                    flag &= connecter.SendCommand(item);
                }
                foreach (var item in param.OutPutByte)
                {
                    flag &= SetValueMapAddress(item);
                }
                foreach (var item in param.InPutByte)
                {
                    flag &= SetValueMapAddress(item);
                }
                enabled = flag;
                return flag;
            }
            else
            {
                return enabled;
            }
        }

        public override bool GetDigIn(int ch, out bool bValue)
        {
            bValue = false;
            if (enabled)
            {
                if (ch < param.MaxInNum && ch >= 0)
                {
                    lock (locker)
                    {
                        bValue = connecter.GetUInt32Value(param.OutputBit[ch]) > 0;
                    }
                }
                else
                {
                    return false;
                }
            }
            return enabled;
        }

        public override bool GetDigOut(int ch, out bool bValue)
        {
            bValue = false;
            if (enabled)
            {
                if (ch < param.MaxOutNum && ch >= 0)
                {
                    lock (locker)
                    {
                        bValue = connecter.GetUInt32Value(param.OutputBit[ch]) > 0;
                    }
                }
                else
                {
                    return false;
                }
            }
            return enabled;
        }

        public override bool SetDigOut(int ch, bool bValue)
        {
            if (enabled)
            {
                if (ch < param.MaxOutNum && ch >= 0)
                {
                    return connecter.SendCommand(string.Format("{0}={1}", param.OutputBit[ch], bValue ? 1 : 0));
                }
                else
                {
                    return false;
                }
            }
            return enabled;
        }

        public override bool GetDigIn(out uint bValue)
        {
            bValue = 0;
            if (enabled)
            {
                lock (locker)
                {
                    foreach (var item in param.InPutByte)//先处理高位，
                    {
                        bValue <<= item.Length;
                        bValue += connecter.GetUInt32Value(item.Name);
                    }
                }
            }
            return enabled;
        }

        public override bool GetDigOut(out uint bValue)
        {
            bValue = 0;
            if (enabled)
            {
                lock (locker)
                {
                    foreach (var item in param.OutPutByte)
                    {
                        bValue <<= item.Length;
                        bValue += connecter.GetUInt32Value(item.Name);
                    }
                }
            }
            return enabled;
        }

        public override bool SetDigOut(uint bValue)
        {
            if (enabled)
            {
                lock (locker)
                {
                    for (int i = param.OutPutByte.Length - 1; i >= 0; i--)
                    {
                        connecter.SendCommand(string.Format("{0}={1}", param.OutPutByte[i].Name, bValue & param.OutPutByte[i].Mask));
                        bValue >>= param.OutPutByte[i].Length;
                    }
                }
            }
            return enabled;
        }
    }
}
