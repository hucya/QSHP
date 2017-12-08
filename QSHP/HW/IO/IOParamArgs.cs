using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.HW.IO
{
    [XmlType("IOParamArgs",Namespace="")]
    [XmlInclude(typeof(PmacIOArgs))]
    public class IOParamArgs
    {
        
    }

   

}
