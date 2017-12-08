using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSHP
{
    /*S系统， A对准  H测高 B刀具  F文件 I输入输出 P程序
     * N1 N2 N3 N4   
     * 1:*/
    public enum CmdLeave : byte
    {
        Debug,
        Info,
        Warn,
        Error,
        Fault,
    }
    [Serializable]
    public class CmdValue
    {
        CmdKey key = CmdKey.None;
        CmdLeave leave = CmdLeave.Info;
        string description = string.Empty;
        public CmdValue()
        { }
        public CmdValue(CmdKey k, CmdLeave l)
        {
            key = k;
            leave = l;
        }
        public CmdValue(CmdKey k, CmdLeave l, string s = "")
        {
            Key = k;
            Leave = l;
            Description = s;
        }

        public CmdKey Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public CmdLeave Leave
        {
            get
            {
                return leave;
            }

            set
            {
                leave = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}\t->{1}\t-> \"{2}\"\r\n", key, leave, description);
        }
    }

    public class CmdOles
    {
        int index = 0;
        CmdValue value;
        DateTime time = DateTime.Now;

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }


        public DateTime Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public CmdValue Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
        public CmdKey Key
        {
            get
            {
                return Value.Key;
            }

            set
            {
                Value.Key = value;
            }
        }

        public CmdLeave Leave
        {
            get
            {
                return Value.Leave;
            }

            set
            {
                Value.Leave = value;
            }
        }

        public string Description
        {
            get
            {
                return Value.Description;
            }

            set
            {
                Value.Description = value;
            }
        }
    }

    public enum CmdKey : int
    {
        None = 0,
        S0000,
        S0001,
        S0002,
        S0003,
        S0004,
        S0005,
        S0006,
        S0007,
        S0008,
        S0009,
        S0010,
        S0011,
        S0012,
        S0013,
        S0014,
        S0015,
        S0016,
        S0017,
        S0018,
        S0019,
        S0020,
        S0021,
        S0022,
        S0023,
        S0024,
        S0025,
        S0026,
        S0027,
        S0028,
        S0029,
        S0030,
        S0031,
        S0032,
        S0033,
        S0034,
        S0035,
        S0036,
        S0037,
        S0038,
        S0039,
        S0040,
        S0041,
        S0042,
        S0043,
        S0044,
        S0045,
        S0046,
        S0047,
        S0048,
        S0049,
        S0050,
        S0051,
        S0052,
        S0053,
        S0054,
        S0055,
        S0056,
        S0057,
        S0058,
        S0059,
        S0060,
        S0061,
        S0062,
        S0063,
        S0064,
        S0065,
        S0066,
        S0067,
        S0068,
        S0069,
        S0070,
        S0071,
        S0072,
        S0073,
        S0074,
        S0075,
        S0076,
        S0077,
        S0088,
        S0089,
        S0090,
        S0091,
        S0092,
        S0093,
        S0094,
        S0095,
        S0096,
        S0097,
        S0098,
        S0099,

        S0100,
        S0101,
        S0102,
        S0103,
        S0104,
        S0105,
        S0106,
        S0107,
        S0108,
        S0109,
        S0110,
        S0111,
        S0200,
        S0201,
        S0202,
        S0203,
        S0204,
        S0205,
        S0206,
        S0207,
        S0208,
        S0209,
        S0210,
        S0211,
        S0212,
        S0213,
        S0214,
        S0215,
        S0216,
        S0217,
        S0218,
        S0219,
        S0220,

        S0300,
        S0301,
        S0302,
        S0303,
        S0304,
        S0305,
        S0306,
        S0307,
        S0308,
        S0309,
        S0310,
        S0311,
        S0312,
        S0313,
        S0314,
        S0315,
        S0316,
        S0317,
        S0318,
        S0319,
        S0320,

        S0400,
        S0401,
        S0402,
        S0403,
        S0404,
        S0405,
        S0406,
        S0407,
        S0408,
        S0409,
        S0410,
        S0411,
        S0412,
        S0413,
        S0414,
        S0415,
        S0416,
        S0417,
        S0418,
        S0419,
        S0420,

        S0500,
        S0501,
        S0502,
        S0503,
        S0504,
        S0505,
        S0506,
        S0507,
        S0508,
        S0509,
        S0510,
        S0511,
        S0512,
        S0513,
        S0514,
        S0515,
        S0516,
        S0517,
        S0518,
        S0519,
        S0520,

        S0600,
        S0601,
        S0602,
        S0603,
        S0604,
        S0605,
        S0606,
        S0607,
        S0608,
        S0609,
        S0610,
        S0611,
        S0612,
        S0613,
        S0614,
        S0615,
        S0616,
        S0617,
        S0618,
        S0619,
        S0620,
        S0700,
        S0701,
        S0702,
        S0703,
        S0704,
        S0705,
        S0800,
        S0801,
        S0802,
        S0803,
        S0804,
        S0805,
        S0806,
        S0807,
        S0808,
        S0809,
        S0810,

        S0850,
        S0851,
        S0852,

        P0100,
        P0101,
        P0102,
        P0103,
        P0104,
        P0105,
        P0106,
        P0107,
        P0108,
        P0109,
        P0110,
        P0111,
        P0112,
        P0113,
        P0114,
        P0115,
        P0116,
        P0117,
        P0118,
        P0119,
        P0120,
        P0121,
        P0122,
        P0123,
        P0124,
        P0125,
        P0126,
        P0127,
        P0128,
        P0129,
        P0130,
        P0131,
        P0132,
        P0133,
        P0134,
        P0135,
        P0136,
        P0137,
        P0138,
        P0139,
        P0140,

        P0200,
        P0201,
        P0202,
        P0203,
        P0204,
        P0205,
        P0206,
        P0207,
        P0208,
        P0209,
        P0210,

        P0300,
        P0301,
        P0302,
        P0303,
        P0304,
        P0305,
        P0306,
        P0307,
        P0308,
        P0309,
        P0310,
        P0311,

        H0000,
        H0001,
        H0002,
        H0003,
        H0004,
        H0005,
        H0006,
        H0007,
        H0008,
        H0009,
        H0010,

        F0001,
        F0002,
        F0003,
        F0004,
        F0005,
        F0006,
        F0007,
        F0008,
        F0009,
        F0010,
        F0011,
        F0012,
        F0013,
        F0014,
        F0015,
        F0016,
        F0017,
        F0018,
        F0019,
        F0020,
        F0021,
        F0022,
        F0023,
        F0024,
        F0025,
        F0026,
        F0027,
        F0028,
        F0029,
        F0030,
        F0031,
        F0032,
        F0033,
        F0034,
        F0035,
        F0036,
        F0037,
        F0038,
        F0039,
        F0040,
        F0041,
        F0042,
        F0043,
        F0044,
        F0045,
        F0046,
        F0047,
        F0048,
        F0049,
        F0050,
        F0051,
        F0052,
        F0053,
        F0054,
        F0055,

        B0001,//刀具
        B0002,
        B0003,
        B0004,
        B0005,
        B0006,
        B0007,
        B0008,
        B0009,
        B0010,
        B0011,
        B0012,
        B0013,
        B0014,
        B0015,
        B0016,
        B0017,
        B0018,
        B0019,
        B0020,
        B0021,

        A0001,//对准
        A0002,
        A0003,
        A0004,
        A0005,
        A0006,
        A0007,
        A0008,
        A0009,
        A0010,
        A0011,
        A0012,
        A0013,
        A0014,
        A0015,
        A0016,
        A0017,
        A0018,
        A0019,
        A0020,
        A0021,
        A0022,
        A0023,
        A0024,
        A0025,
        A0026,
        A0027,
        A0028,
        A0029,
        A0030,

    }
}
