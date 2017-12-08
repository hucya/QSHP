using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSHP.SIM
{
    public class SimModel
    {
        protected bool connected = true;
        [Browsable(true),Category("配置")]
        public virtual AskMode Mode
        {
            get;
            set;
        }

        public bool Connected
        {
            get
            {
                return connected;
            }
            //set { connected = value; }
        }

        public virtual bool RunProgram()
        {
            return connected;
        }
    }
   
    public enum AskMode
    { 
        Default=0,//默认为AUTO
        Auto=0,//自动模式
        Manual=1,//手动模式
        Trigger=2,//触发模式
        Preset=3,//预设模式
    }
   
}
