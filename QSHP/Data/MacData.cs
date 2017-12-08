using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace QSHP.Data
{
    public class MacData
    {
        string devKey = "c01142c350050245";//qshp
        string adminKey = "c01142c350050245";//QSHP
        string userKey = "c01142c350050245";
        string lockKey = "c01142c350050245";
        string romoteKey = "c01142c350050245";
        int logDropMode = 1;// 0禁止删除 1 手动授权 2 自动删除
        int logDropTime = 2;// 0 一个月 1 一季度 2 半年 3一年

        int spdIndex=1;
        int spdBaud = 9600;
        DateTime time = DateTime.Now;

        float xStartPos = 300;
        float xOffset = 40;
        float xHomeSpeed = 50;
        float xHomeAcc = 2;

        float yStartPos = 200;
        float yOffset = 80;
        float yHomeSpeed = 25;
        float yHomeAcc = 2;

        float zStartPos = 30;
        float zOffset = 5;
        float zHomeSpeed = 5;
        float zHomeAcc = 0.5f;

        float tStartPos = 30;
        float tOffset = 25;
        float tHomeSpeed = 30;
        float tHomeAcc = 1;

        float xResolution = 10000;
        float yResolution = 10000;
        float zResolution = 5000;
        float tResolution = 500;

        float xLead = 10;
        float yLead = 10;
        float zLead = 10;
        float tLead = 10;

        float xAccuracy = 5;
        float yAccuracy = 3;
        float zAccuracy = 2;
        float tAccuracy = 4;

        float xMaxError = 10;
        float yMaxError = 10;
        float zMaxError = 10;
        float tMaxError = 10;

        float xSpeed = 30;
        float xAcc = 0.5f;
        float ySpeed = 20;
        float yAcc = 0.5f;
        float zSpeed = 8;
        float zAcc = 1;
        float tSpeed = 80;
        float tAcc = 0.5f;

        PointF centerPos = new PointF(140.908f, 205.799f);
        float xPLimit = 337;
        float xNLimit = 62;
        float yPLimit = 300;
        float yNLimit = 120;

        float tAdjSpeed = 100;
        float tAdjAcc = 2;

        float pickXPos = 300;
        float pickYPos = 125;
        float pickZPos = 30;
        float pickTPos = 30;

        PointF p1Pos = new PointF(300, 200);
        PointF p2Pos = new PointF(300, 125);

        float zTestSpeed = 0.1f;
        float zTestAcc = 0.1f;
        float zRiseValue = 0.5f;
        float zCutSpeed = 5;
        float zCutAcc = 1;
        float zSelfPos = 0.5f;
        float xCutAcc = 2;
        float xCutBackAcc = 2;
        float tStep = 90;
        float tMaxPos = 320;
        float tTestOffset = 0.5f;
        float yTestOffset = 0.5f;

        float xFollowSpeed = 60;
        float xFollowAcc = 2;
        float yFollowSpeed = 40;
        float yFollowAcc = 1;

        IOData ioData = new IOData();
        public float XStartPos
        {
            get
            {
                return xStartPos;
            }

            set
            {
                xStartPos = value;
            }
        }

        public float XOffset
        {
            get
            {
                return xOffset;
            }

            set
            {
                xOffset = value;
            }
        }

        public float XHomeSpeed
        {
            get
            {
                return xHomeSpeed;
            }

            set
            {
                xHomeSpeed = value;
            }
        }

        public float XHomeAcc
        {
            get
            {
                return xHomeAcc;
            }

            set
            {
                xHomeAcc = value;
            }
        }

        public float YStartPos
        {
            get
            {
                return yStartPos;
            }

            set
            {
                yStartPos = value;
            }
        }

        public float YOffset
        {
            get
            {
                return yOffset;
            }

            set
            {
                yOffset = value;
            }
        }

        public float YHomeSpeed
        {
            get
            {
                return yHomeSpeed;
            }

            set
            {
                yHomeSpeed = value;
            }
        }

        public float YHomeAcc
        {
            get
            {
                return yHomeAcc;
            }

            set
            {
                yHomeAcc = value;
            }
        }

        public float ZStartPos
        {
            get
            {
                return zStartPos;
            }

            set
            {
                zStartPos = value;
            }
        }

        public float ZOffset
        {
            get
            {
                return zOffset;
            }

            set
            {
                zOffset = value;
            }
        }

        public float ZHomeSpeed
        {
            get
            {
                return zHomeSpeed;
            }

            set
            {
                zHomeSpeed = value;
            }
        }

        public float ZHomeAcc
        {
            get
            {
                return zHomeAcc;
            }

            set
            {
                zHomeAcc = value;
            }
        }

        public float TStartPos
        {
            get
            {
                return tStartPos;
            }

            set
            {
                tStartPos = value;
            }
        }

        public float TOffset
        {
            get
            {
                return tOffset;
            }

            set
            {
                tOffset = value;
            }
        }

        public float THomeSpeed
        {
            get
            {
                return tHomeSpeed;
            }

            set
            {
                tHomeSpeed = value;
            }
        }

        public float THomeAcc
        {
            get
            {
                return tHomeAcc;
            }

            set
            {
                tHomeAcc = value;
            }
        }

        public float XResolution
        {
            get
            {
                return xResolution;
            }

            set
            {
                xResolution = value;
            }
        }

        public float YResolution
        {
            get
            {
                return yResolution;
            }

            set
            {
                yResolution = value;
            }
        }

        public float ZResolution
        {
            get
            {
                return zResolution;
            }

            set
            {
                zResolution = value;
            }
        }

        public float TResolution
        {
            get
            {
                return tResolution;
            }

            set
            {
                tResolution = value;
            }
        }

        public float XLead
        {
            get
            {
                return xLead;
            }

            set
            {
                xLead = value;
            }
        }

        public float YLead
        {
            get
            {
                return yLead;
            }

            set
            {
                yLead = value;
            }
        }

        public float ZLead
        {
            get
            {
                return zLead;
            }

            set
            {
                zLead = value;
            }
        }

        public float TLead
        {
            get
            {
                return tLead;
            }

            set
            {
                tLead = value;
            }
        }

        public float XAccuracy
        {
            get
            {
                return xAccuracy;
            }

            set
            {
                xAccuracy = value;
            }
        }

        public float YAccuracy
        {
            get
            {
                return yAccuracy;
            }

            set
            {
                yAccuracy = value;
            }
        }

        public float ZAccuracy
        {
            get
            {
                return zAccuracy;
            }

            set
            {
                zAccuracy = value;
            }
        }

        public float TAccuracy
        {
            get
            {
                return tAccuracy;
            }

            set
            {
                tAccuracy = value;
            }
        }

        public float XMaxError
        {
            get
            {
                return xMaxError;
            }

            set
            {
                xMaxError = value;
            }
        }

        public float YMaxError
        {
            get
            {
                return yMaxError;
            }

            set
            {
                yMaxError = value;
            }
        }

        public float ZMaxError
        {
            get
            {
                return zMaxError;
            }

            set
            {
                zMaxError = value;
            }
        }

        public float TMaxError
        {
            get
            {
                return tMaxError;
            }

            set
            {
                tMaxError = value;
            }
        }

        public float XSpeed
        {
            get
            {
                return xSpeed;
            }

            set
            {
                xSpeed = value;
            }
        }

        public float XAcc
        {
            get
            {
                return xAcc;
            }

            set
            {
                xAcc = value;
            }
        }

        public float YSpeed
        {
            get
            {
                return ySpeed;
            }

            set
            {
                ySpeed = value;
            }
        }

        public float YAcc
        {
            get
            {
                return yAcc;
            }

            set
            {
                yAcc = value;
            }
        }

        public float ZSpeed
        {
            get
            {
                return zSpeed;
            }

            set
            {
                zSpeed = value;
            }
        }

        public float ZAcc
        {
            get
            {
                return zAcc;
            }

            set
            {
                zAcc = value;
            }
        }

        public float TSpeed
        {
            get
            {
                return tSpeed;
            }

            set
            {
                tSpeed = value;
            }
        }

        public float TAcc
        {
            get
            {
                return tAcc;
            }

            set
            {
                tAcc = value;
            }
        }

        public PointF CenterPos
        {
            get
            {
                return centerPos;
            }

            set
            {
                centerPos = value;
            }
        }

        public float XPLimit
        {
            get
            {
                return xPLimit;
            }

            set
            {
                xPLimit = value;
            }
        }

        public float XNLimit
        {
            get
            {
                return xNLimit;
            }

            set
            {
                xNLimit = value;
            }
        }

        public float YPLimit
        {
            get
            {
                return yPLimit;
            }

            set
            {
                yPLimit = value;
            }
        }

        public float YNLimit
        {
            get
            {
                return yNLimit;
            }

            set
            {
                yNLimit = value;
            }
        }

        public float TAdjSpeed
        {
            get
            {
                return tAdjSpeed;
            }

            set
            {
                tAdjSpeed = value;
            }
        }

        public float TAdjAcc
        {
            get
            {
                return tAdjAcc;
            }

            set
            {
                tAdjAcc = value;
            }
        }

        public float PickXPos
        {
            get
            {
                return pickXPos;
            }

            set
            {
                pickXPos = value;
            }
        }

        public float PickYPos
        {
            get
            {
                return pickYPos;
            }

            set
            {
                pickYPos = value;
            }
        }

        public float PickZPos
        {
            get
            {
                return pickZPos;
            }

            set
            {
                pickZPos = value;
            }
        }

        public float PickTPos
        {
            get
            {
                return pickTPos;
            }

            set
            {
                pickTPos = value;
            }
        }

        public PointF P1Pos
        {
            get
            {
                return p1Pos;
            }

            set
            {
                p1Pos = value;
            }
        }

        public PointF P2Pos
        {
            get
            {
                return p2Pos;
            }

            set
            {
                p2Pos = value;
            }
        }

        public string DevKey
        {
            get
            {
                return devKey;
            }

            set
            {
                devKey = value;
            }
        }

        public string AdminKey
        {
            get
            {
                return adminKey;
            }

            set
            {
                adminKey = value;
            }
        }
        public string UserKey
        {
            get
            {
                return userKey;
            }

            set
            {
                userKey = value;
            }
        }

        public string LockKey
        {
            get
            {
                return lockKey;
            }

            set
            {
                lockKey = value;
            }
        }

        public string RomoteKey
        {
            get
            {
                return romoteKey;
            }

            set
            {
                romoteKey = value;
            }
        }
        public DateTime SaveTime
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

        public float ZTestSpeed
        {
            get
            {
                return zTestSpeed;
            }

            set
            {
                zTestSpeed = value;
            }
        }

        public float ZTestAcc
        {
            get
            {
                return zTestAcc;
            }

            set
            {
                zTestAcc = value;
            }
        }

        public float ZRiseValue
        {
            get
            {
                return zRiseValue;
            }

            set
            {
                zRiseValue = value;
            }
        }

        public float ZCutSpeed
        {
            get
            {
                return zCutSpeed;
            }

            set
            {
                zCutSpeed = value;
            }
        }

        public float ZCutAcc
        {
            get
            {
                return zCutAcc;
            }

            set
            {
                zCutAcc = value;
            }
        }

        public float XCutAcc
        {
            get
            {
                return xCutAcc;
            }

            set
            {
                xCutAcc = value;
            }
        }

        public float XCutBackAcc
        {
            get
            {
                return xCutBackAcc;
            }

            set
            {
                xCutBackAcc = value;
            }
        }

        public float ZSelfPos
        {
            get
            {
                return zSelfPos;
            }

            set
            {
                zSelfPos = value;
            }
        }

        public float TStep
        {
            get
            {
                return tStep;
            }

            set
            {
                tStep = value;
            }
        }

        public float TMaxPos
        {
            get
            {
                return tMaxPos;
            }

            set
            {
                tMaxPos = value;
            }
        }

        public float TTestOffset
        {
            get
            {
                return tTestOffset;
            }

            set
            {
                tTestOffset = value;
            }
        }

        public float YTestOffset
        {
            get
            {
                return yTestOffset;
            }

            set
            {
                yTestOffset = value;
            }
        }

        public float XFollowSpeed
        {
            get
            {
                return xFollowSpeed;
            }

            set
            {
                xFollowSpeed = value;
            }
        }

        public float XFollowAcc
        {
            get
            {
                return xFollowAcc;
            }

            set
            {
                xFollowAcc = value;
            }
        }

        public float YFollowSpeed
        {
            get
            {
                return yFollowSpeed;
            }

            set
            {
                yFollowSpeed = value;
            }
        }

        public float YFollowAcc
        {
            get
            {
                return yFollowAcc;
            }

            set
            {
                yFollowAcc = value;
            }
        }
        public int SpdIndex
        {
            get
            {
                return spdIndex;
            }

            set
            {
                spdIndex = value;
            }
        }

        public int SpdBaud
        {
            get
            {
                return spdBaud;
            }

            set
            {
                spdBaud = value;
            }
        }
        public int LogDropMode
        {
            get
            {
                return logDropMode;
            }

            set
            {
                logDropMode = value;
            }
        }

        public int LogDropTime
        {
            get
            {
                return logDropTime;
            }

            set
            {
                logDropTime = value;
            }
        }
        public IOData IoData
        {
            get
            {
                return ioData;
            }

            set
            {
                ioData = value;
            }
        }


        public MacData CreateNewMacData(bool clone = true)
        {
            if (clone)
            {
                string s = Data.Serialize.XmlSerialize(this);
                return Serialize.XmlDeSerialize<MacData>(s);
            }
            else
            {
                return new MacData();
            }
        }

        public void SaveMacDataToFile(string path)
        {
            SaveTime = DateTime.Now;
            string s = Data.Serialize.XmlSerialize(this);
            File.WriteAllText(path,s);
        }
        public void InitMacDataToHardWare()
        {
            if (Common.HwProvider.CreateSucessful)
            {
                AxisParams p = Common.X_Axis.Param;
                if (p != null)
                {
                    p.HomeAcc =this.XHomeAcc;
                    p.HomeOffset =this.XOffset;
                    p.StartPos =this.XStartPos;
                    p.HomeVel =this.XHomeSpeed;
                    p.PerCTS =this.XResolution /this.XLead;
                    p.WorkAcc =this.XAcc;
                    p.WorkVel =this.XSpeed;
                    p.SoftPlimit =this.XPLimit;
                    p.SoftNlimit =this.XNLimit;
                    p.PosAccuracy =this.XAccuracy;
                    p.MaxError =this.XMaxError;
                }
                p = Common.Y_Axis.Param;
                if (p != null)
                {
                    p.HomeAcc =this.YHomeAcc;
                    p.HomeOffset =this.YOffset;
                    p.StartPos =this.YStartPos;
                    p.HomeVel =this.YHomeSpeed;
                    p.PerCTS =this.YResolution /this.YLead;
                    p.WorkAcc =this.YAcc;
                    p.WorkVel =this.YSpeed;
                    p.SoftPlimit =this.YPLimit;
                    p.SoftNlimit =this.YNLimit;
                    p.PosAccuracy =this.YAccuracy;
                    p.MaxError =this.YMaxError;
                }
                p = Common.Z_Axis.Param;
                if (p != null)
                {
                    p.HomeAcc =this.ZHomeAcc;
                    p.HomeOffset =this.ZOffset;
                    p.StartPos =this.ZStartPos;
                    p.HomeVel =this.ZHomeSpeed;
                    p.PerCTS =this.ZResolution /this.ZLead;
                    p.WorkAcc =this.ZAcc;
                    p.WorkVel =this.ZSpeed;
                    p.PosAccuracy =this.ZAccuracy;
                    p.MaxError =this.ZMaxError;
                }
                p = Common.T_Axis.Param;
                if (p != null)
                {
                    p.HomeAcc =this.THomeAcc;
                    p.HomeOffset =this.TOffset;
                    p.StartPos =this.TStartPos;
                    p.HomeVel =this.THomeSpeed;
                    p.PerCTS =this.TResolution /this.TLead;
                    p.WorkAcc =this.TAcc;
                    p.WorkVel =this.TSpeed;
                    p.PosAccuracy =this.TAccuracy;
                    p.MaxError =this.TMaxError;
                    p.MaxPos = this.TMaxPos;
                    p.StepPos = this.TStep;
                }
                Globals.TabCenter.X = centerPos.X;
                Globals.TabCenter.Y= centerPos.Y;
                CutChip.SelfTickness = this.ZSelfPos;
                Globals.IsInit = false;
                if (Common.DI != null)
                {
                    Common.DI.IOList = ioData.DiList;
                    Common.DI.Mask = ioData.DiMask;
                    Common.DI.Used = ioData.DiUsed;
                }
                if (Common.DO != null)
                {
                    Common.DO.IOList = ioData.DoList;
                    Common.DO.Mask = ioData.DoMask;
                    Common.DO.Used = ioData.DoUsed;
                }
                if (Common.SPD != null)
                {
                    Common.SPD.DevIndex = spdIndex;
                    Common.SPD.BaudRate = spdBaud;
                }
            }
        }
    }
}
