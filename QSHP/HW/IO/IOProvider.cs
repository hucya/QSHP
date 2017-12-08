using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QSHP.HW.IO
{
    [XmlType("IOProvider",Namespace="")]
    [XmlInclude(typeof(PmacIOProvider))]
    public class IOProvider
    {
        [XmlAttribute("Index")]
        public virtual int DevIndex
        {
            get;
            set;
        }
        public virtual IOParamArgs Params
        {
            get;
            set;
        }
        public virtual bool Connected
        {
            get
            {
                return true;
            }
        }
        public virtual bool Enabled
        {
            get
            {
                return true;
            }
        }
        public virtual bool GetDigIn(int ch,out bool bValue)
        {
            bValue = false;
            if (Connected)
            {

            }
            return Connected;
        }

        public virtual bool GetDigOut(int ch, out bool bValue)
        {
            bValue = false;
            if (Connected)
            {

            }
            return Connected;
        }

        public virtual bool SetDigOut(int ch, bool bValue)
        {
            if (Connected)
            {

            }
            return Connected;
        }

        public virtual bool GetDigIn(out uint bValue)
        {
            bValue = 0;
            if (Connected)
            {

            }
            return Connected;
        }

        public virtual bool GetDigOut(out uint bValue)
        {
            bValue = 0;
            if (Connected)
            {

            }
            return Connected;
        }

        public virtual bool SetDigOut(uint bValue)
        {
            bValue = 0;
            if (Connected)
            {

            }
            return Connected;
        }

        public virtual bool SetAlgOut(int ch, float bValue)
        {
            if (Connected)
            {

            }
            return Connected;
        }

        public virtual bool GetAlgOut(int ch, out float bValue)
        {
            bValue = 0;
            if (Connected)
            {

            }
            return Connected;
        }

        public virtual bool GetAlgIn(int ch, out float bValue)
        {
            bValue = 0;
            if (Connected)
            {

            }
            return Connected;
        }

        public virtual bool InitController()
        {
            return Connected;
        }

    }

    public enum IOMode : byte
    {
        DI=0,
        DO=1,
        AI=2,
        AO=3
    }
}
