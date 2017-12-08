using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using QSHP.HW.AmpC;

namespace QSHP.Data
{
    [Serializable]
    [XmlType(TypeName = "AxisParams", Namespace = "")]
    [XmlInclude(typeof(PmacAxisParams)),XmlInclude(typeof(CopleyAxisParams))]
    public class AxisParams
    {
        float maxAcc = 50f;     //最大加速度
        float maxVel = 400f;    //最大速度
        float maxPos = 400f;    //最大位置
        float jogVel = 10f;     //JOG速度
        float jogAcc = 4f;      //Jog加速度
        float jogAccSlow = 1f;    //JOG低加速度
        float jogVelSlow = 3f;    //JOG低速度
        float workVel = 5f;     //工作速度
        float workAcc = 2f;     //工作加速度
        float homeVel = 5f;     //回零速度
        float homeAcc = 2f;     //回零加速度
        float homeOffset = 0f;  //回零偏移
        float startPos = 0f;    //回零起始位置
        float stepPos = 10;        //单次步进距离
        float perCTS = 2000f;
        float nlimit = 0;
        float plimit = 0;
        Limit homeMode = Limit.PLimit;
        float posAccuracy = 5;  //到位精度
        float maxError = 10;    //最大允许误差
        //[XmlElement("MaxAcc")]  
        public float StepPos
        {
            get
            {
                return stepPos;
            }
            set
            {
                stepPos = value;
            }
        }

        public float MaxAcc
        {
            get { return maxAcc; }
            set { maxAcc = value; }
        }
        //[XmlElement("MaxVel")]  
        public float MaxVel
        {
            get { return maxVel; }
            set { maxVel = value; }
        }
        //[XmlElement("MaxPos")]  
        public float MaxPos
        {
            get { return maxPos; }
            set { maxPos = value; }
        }

        //[XmlElement("StartPos")]  
        public float StartPos
        {
            get { return startPos; }
            set { startPos = value; }
        }
        //[XmlElement("HomeOffset")] 
        public float HomeOffset
        {
            get { return homeOffset; }
            set { homeOffset = value; }
        }
        //[XmlElement("HomeAcc")] 
        public float HomeAcc
        {
            get { return homeAcc; }
            set { homeAcc = value; }
        }
        //[XmlElement("HomeVel")] 
        public float HomeVel
        {
            get { return homeVel; }
            set { homeVel = value; }
        }
        //[XmlElement("WorkAcc")] 
        public float WorkAcc
        {
            get { return workAcc; }
            set { workAcc = value; }
        }
        //[XmlElement("WorkVel")] 
        public float WorkVel
        {
            get { return workVel; }
            set { workVel = value; }
        }
        //[XmlElement("JogVel")] 
        public float JogVel
        {
            get { return jogVel; }
            set { jogVel = value; }
        }
        //[XmlElement("JogAcc")] 
        public float JogAcc
        {
            get { return jogAcc; }
            set { jogAcc = value; }
        }
        //[XmlElement("JogVelSlow")] 
        public float JogVelSlow
        {
            get { return jogVelSlow; }
            set { jogVelSlow = value; }
        }
        //[XmlElement("JogAccSlow")] 
        public float JogAccSlow
        {
            get { return jogAccSlow; }
            set { jogAccSlow = value; }
        }
        public float PerCTS
        {
            get { return perCTS; }
            set { perCTS = value; }
        }
        public float SoftNlimit
        {
            get { return nlimit; }
            set { nlimit = value; }
        }
        public float SoftPlimit
        {
            get { return plimit; }
            set { plimit = value; }
        }
        public Limit HomeMode
        {
            get { return homeMode; }
            set { homeMode = value; }
        }

        public float PosAccuracy
        {
            get
            {
                return posAccuracy;
            }

            set
            {
                posAccuracy = value;
            }
        }

        public float MaxError
        {
            get
            {
                return maxError;
            }

            set
            {
                maxError = value;
            }
        }
    }
}
