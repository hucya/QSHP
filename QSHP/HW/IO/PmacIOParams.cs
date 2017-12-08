using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.HW.IO
{
    [Serializable]
    [XmlType(TypeName = "PmacIOArgs", Namespace = "")]
    public class PmacIOArgs : IOParamArgs
    {
        private int baseAddress = 78400;
        private string[] inputBit = { "M0", "M1", "M2", "M3", "M4", "M5", "M6", "M7", "M8", "M9", "M10", "M11", "M12", "M13", "M14", "M15" };
        private string[] outputBit = { "M16", "M17", "M18", "M19", "M20", "M21", "M22", "M23", "M24", "M25", "M26", "M27", "M28", "M29", "M30", "M31" };
        private string[] initCmd = { @"M32=$00FF", @"M34=0" ,@"M40=0" ,@"M42=$FFFF" };
        private PmacAddress[] outPutByte= { new PmacAddress("M8111", 78400, 0, 8), new PmacAddress("M8110", 78402, 8, 8) };//高位在前
        private PmacAddress[] inPutByte = {  new PmacAddress("M8101", 78400, 8, 8), new PmacAddress("M8100", 78402, 0, 8) };
        public int BaseAddress
        {
            get
            {
                return baseAddress;
            }
            set
            {
                baseAddress = value;
            }
        }
        [XmlArray("InputBitCmd")]
        public string[] InputBit
        {
            get
            {
                return  inputBit;
            }
            set
            {
                inputBit = value;
            }
        }
        [XmlArray("OutputBitCmd")]
        public string[] OutputBit
        {
            get
            {
                return outputBit;
            }
            set
            {
                outputBit = value;
            }
        }
        public int MaxInNum
        {
            get
            {
                return inputBit.Length;
            }
        }
        public int MaxOutNum
        {
            get
            {
                return outputBit.Length;
            }
        }
        [XmlArray("InitCmd")]
        public string[] InitCmd
        {
            get
            {
                return initCmd;
            }
            set
            {
                initCmd = value;
            }
        }
        [XmlArray("OutputByte")]
        public PmacAddress[] OutPutByte
        {
            get
            {
                return outPutByte;
            }

            set
            {
                outPutByte = value;
            }
        }
        [XmlArray("InputByte")]
        public PmacAddress[] InPutByte
        {
            get
            {
                return inPutByte;
            }

            set
            {
                inPutByte = value;
            }
        }
    }
    [Serializable]
    [XmlRoot("PmacAddrArgs")]
    public class PmacAddress
    {
        string name = "P1000";
        string type = "Y";
        int address = 0;
        int start = 0;
        int length = 8;
        bool sign = false;
        uint mask = 0xFF;
        [XmlElement("Name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        [XmlElement()]
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        [XmlElement()]
        public int Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
        [XmlElement()]
        public int Start
        {
            get
            {
                return start;
            }

            set
            {
                start = value;
            }
        }
        [XmlElement()]
        public int Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
                mask=(uint)(Math.Pow(2,value)-1);
            }
        }
        [XmlElement()]
        public bool Sign
        {
            get
            {
                return sign;
            }

            set
            {
                sign = value;
            }
        }

        public UInt32 Mask
        {
            get
            {
                return mask;
            }
        }
        public PmacAddress()
        {

        }
        public PmacAddress(string n,int a,int s,int l,bool sig=false)
        {
            name = n;
            address = a;
            start = s;
            Length = l;
            Sign = sig;
        }
        public PmacAddress(string n, string t,int a,int s, int l, bool sig = false)
        {
            name = n;
            address = a;
            type = t;
            start = s;
            Length = l;
            Sign = sig;
        }
        public override string ToString()
        {
            if (Sign)
            {
                return string.Format("{0}->{1}:${2},{3},{4},S", Name, type, Address, Start, Length);
            }
            else
            {
                return string.Format("{0}->{1}:${2},{3},{4},U", Name, type, Address, Start, Length);
            }
        }
    }
}
