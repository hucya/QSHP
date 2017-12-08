using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSHP.Data;
using System.Xml.Serialization;

namespace QSHP.HW.AmpC
{
    [Serializable]
    [XmlType(TypeName = "PmacAmpCArgs",Namespace ="")]
    public class PmacAxisParams : AxisParams
    {
        uint modeControl = 0x820001;
        byte posLimitCaptureMode = 2;
        byte negLimitCaptureMode = 2;
        byte homeLimitCaptureMode = 10;
        byte userLimitCaptureMode = 10;
        public byte PosLimitCaptureMode
        {
            get { return posLimitCaptureMode; }
            set { posLimitCaptureMode = value; }
        }

        public byte NegLimitCaptureMode
        {
            get { return negLimitCaptureMode; }
            set { negLimitCaptureMode = value; }
        }

        public byte HomeLimitCaptureMode
        {
            get { return homeLimitCaptureMode; }
            set { homeLimitCaptureMode = value; }
        }

        public byte UserLimitCaptureMode
        {
            get { return userLimitCaptureMode; }
            set { userLimitCaptureMode = value; }
        }
        
        public uint ModeControl
        {
            get { return modeControl; }
            set { modeControl = value; }
        }
    }
}
