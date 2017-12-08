using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QSHP.Data;
using System.Xml.Serialization;
namespace QSHP.HW.AmpC
{
    [XmlType(TypeName = "CopleyAxisCArgs", Namespace = "")]
    public class CopleyAxisParams : AxisParams
    {
        int pLimitMode = 4;
        int nLimitMode = 6;
        int hLimitMode = 14;

        private bool dualEncoder = false;

        public bool DualEncoder
        {
            get { return dualEncoder; }
            set { dualEncoder = value; }
        }
        public int HLimitMode
        {
            get { return hLimitMode; }
            set { hLimitMode = value; }
        }

        public int NLimitMode
        {
            get { return nLimitMode; }
            set { nLimitMode = value; }
        }

        public int PLimitMode
        {
            get { return pLimitMode; }
            set { pLimitMode = value; }
        }
    }
}
