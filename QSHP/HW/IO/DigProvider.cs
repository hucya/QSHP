using QSHP.Com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.HW.IO
{
    [Serializable]
    [XmlType("DigitalProvider",Namespace="")]
    public class DigProvider
    {
        uint realStatus = 0; //当前状态 1 Enable 0 Disable
        uint mask = 0;   //掩码  1 反转 0 正常
        uint used = UInt32.MaxValue;   //是否使用 used 1 noUsed 0
        uint status = 0;

        bool enabled = false;
        bool isOutPut = true;
        int[] list = { 0, 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31};
        [NonSerialized]
        IOProvider provider;
        [XmlElement("IsOutput")]
        public bool IsOutput
        {
            get { return isOutPut; }
            set 
            { 
                if(!enabled)
                {
                    isOutPut = value;
                }
            }
        }
        public uint RealStatus
        {
            get
            {
                if (enabled)
                {
                    if (isOutPut)
                    {
                        provider.GetDigOut(out realStatus);
                    }
                    else
                    {
                         provider.GetDigIn(out realStatus);
                    }
                }
                return realStatus;
            }
        }
        [XmlElement("Mask")]
        public uint Mask
        {
            get { return mask; }
            set { mask = value; }
        }
        [XmlElement("Used")]
        public uint Used
        {
            get { return used; }
            set { used = value; }
        }

        [XmlElement("Status")]

        public uint Status
        {
            get
            {
                if (enabled)
                {
                    status = used & (mask ^ RealStatus);
                }
                return status;
            }
            set
            {
                status = value;
                if (isOutPut&&enabled)
                {
                    provider.SetDigOut(used & (mask ^ status));
                }
            }
        }

        [XmlArray("List")]
        public int[] IOList
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
            }
        }

        [XmlIgnoreAttribute]
        public IOProvider Provider
        {
            get
            {
                return provider;
            }

            set
            {
                if (provider != value)
                {
                    provider = value;
                    enabled = false;
                }
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
        }
        public bool this[int index]
        {
            get
            {
                index = list[index];
                if (enabled && used.Bit(index))
                {
                    bool flag;
                    if (isOutPut)
                    {
                        provider.GetDigOut(index, out flag);
                    }
                    else
                    {
                        provider.GetDigIn(index, out flag);
                    }
                    flag = (mask.Bit(index) ^ flag);
                    return flag;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                index = list[index];
                if (isOutPut&&enabled && used.Bit(index))
                {
                    bool flag = mask.Bit(index);
                    flag ^= value;
                    provider.SetDigOut(index, flag);
                }
            }
        }

        public bool InitHardWare()
        {
            if (provider != null)
            {
                enabled = provider.InitController();
                return enabled;
            }
            else
            {
                enabled = false;
                return false;
            }
        }

        public DigProvider()
        {
        }
        public DigProvider(IOProvider p)
        {
            provider = p;
        }
        public DigProvider(IOProvider p,bool isOut)
        {
            provider = p;
            IsOutput = isOut;
        }

        public override string ToString()
        {
            uint value = RealStatus;//真实值
            StringBuilder b = new StringBuilder();
            for (int i = 31; i >= 0; i--)
            {
                b.Append(((value >> i) & 0x01) == 0 ? "0" : "1");
                if (i % 4 == 0)
                {
                    b.Append(" ");
                }
            }
            return b.ToString();
        }
    }
}
