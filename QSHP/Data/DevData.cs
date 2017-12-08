using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QSHP.Data
{
    public class DevData
    {
        DateTime saveTime = DateTime.Now;
        float xSpeed = 50;
        float xAcc = 5;
        float xLowSpeed = 2;
        float xLowAcc = 1;

        float ySpeed = 25;
        float yAcc = 0.5f;
        float yLowSpeed =0.05f;
        float yLowAcc = 0.1f;

        float zSpeed = 8;
        float zAcc = 1;
        float zLowSpeed = 1.5f;
        float zLowAcc = 0.5f;

        float tSpeed = 30;
        float tAcc = 2;
        float tLowSpeed = 2;
        float tLowAcc = 0.5f;

        float onceAlignLineAdj = 4;
        float maxAlignLineAdj = 10;
        float maxPosAdj = 5;
        float onceHeightAdj = 0.01f;
        float maxHeightAdj = 0.03f;
        float maxSpeedAdj = 30f;
        float maxStepAdj = 0.2f;

        float lowCenterX = 260;
        float lowCenterY = 202;
        float lowPixValue = 0.00266f;

        float highCenterX = 260;
        float highCenterY = 202;
        float highPixValue = 0.00133f;

        int testTime = 20;
        int cuttingTime = 20;
        float spindleReadyTime = 30;
        float spindleAxis = -10f;

        bool replaceBldXNoMove = false;
        float replaceBldXPos = 300;
        float replaceBldYPos = 270;
        float replaceBldZPos = 30;

        bool buzzerUsed = true;
        bool cutWaterChecked = true;
        bool leakWaterChecked = false;
        bool doorProtectUsed = false;
        bool testCheckAir = false;
        bool dualZlife = true;
        bool cutStopCloseWater = true;
        bool cutPauseCloseWater = true;
        bool resumeCloseBuzzer = true;
        bool cutStopUnloadVacuum = false;

        LedCmd loadLedCmd = new LedCmd();
        LedCmd idleLedCmd = new LedCmd();
        LedCmd initLedCmd = new LedCmd();
        LedCmd pauseLedCmd = new LedCmd();
        LedCmd stopLedCmd = new LedCmd();
        LedCmd workingLedCmd = new LedCmd();
        LedCmd testingLedCmd = new LedCmd();
        LedCmd errAirWaterLedCmd = new LedCmd();
        LedCmd emgLedCmd = new LedCmd();

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

        public float XLowSpeed
        {
            get
            {
                return xLowSpeed;
            }

            set
            {
                xLowSpeed = value;
            }
        }

        public float XLowAcc
        {
            get
            {
                return xLowAcc;
            }

            set
            {
                xLowAcc = value;
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

        public float YLowSpeed
        {
            get
            {
                return yLowSpeed;
            }

            set
            {
                yLowSpeed = value;
            }
        }

        public float YLowAcc
        {
            get
            {
                return yLowAcc;
            }

            set
            {
                yLowAcc = value;
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

        public float ZLowSpeed
        {
            get
            {
                return zLowSpeed;
            }

            set
            {
                zLowSpeed = value;
            }
        }

        public float ZLowAcc
        {
            get
            {
                return zLowAcc;
            }

            set
            {
                zLowAcc = value;
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

        public float TLowSpeed
        {
            get
            {
                return tLowSpeed;
            }

            set
            {
                tLowSpeed = value;
            }
        }

        public float TLowAcc
        {
            get
            {
                return tLowAcc;
            }

            set
            {
                tLowAcc = value;
            }
        }

        public float OnceAlignLineAdj
        {
            get
            {
                return onceAlignLineAdj;
            }

            set
            {
                onceAlignLineAdj = value;
            }
        }

        public float MaxAlignLineAdj
        {
            get
            {
                return maxAlignLineAdj;
            }

            set
            {
                maxAlignLineAdj = value;
            }
        }

        public float MaxPosAdj
        {
            get
            {
                return maxPosAdj;
            }

            set
            {
                maxPosAdj = value;
            }
        }


        public float OnceHeightAdj
        {
            get
            {
                return onceHeightAdj;
            }

            set
            {
                onceHeightAdj = value;
            }
        }

        public float MaxHeightAdj
        {
            get
            {
                return maxHeightAdj;
            }

            set
            {
                maxHeightAdj = value;
            }
        }

        public float MaxSpeedAdj
        {
            get
            {
                return maxSpeedAdj;
            }

            set
            {
                maxSpeedAdj = value;
            }
        }

        public float MaxStepAdj
        {
            get
            {
                return maxStepAdj;
            }

            set
            {
                maxStepAdj = value;
            }
        }

        public float LowCenterX
        {
            get
            {
                return lowCenterX;
            }

            set
            {
                lowCenterX = value;
            }
        }

        public float LowCenterY
        {
            get
            {
                return lowCenterY;
            }

            set
            {
                lowCenterY = value;
            }
        }

        public float CenterOffset
        {
            get
            {
                return HighCenterY - LowCenterY;
            }
        }

        public float LowPixValue
        {
            get
            {
                return lowPixValue;
            }

            set
            {
                lowPixValue = value;
            }
        }

        public float HighCenterX
        {
            get
            {
                return highCenterX;
            }

            set
            {
                highCenterX = value;
            }
        }

        public float HighCenterY
        {
            get
            {
                return highCenterY;
            }

            set
            {
                highCenterY = value;
            }
        }

        public float HighPixValue
        {
            get
            {
                return highPixValue;
            }

            set
            {
                highPixValue = value;
            }
        }

        public int TestTime
        {
            get
            {
                return testTime;
            }

            set
            {
                testTime = value;
            }
        }

        public int CuttingTime
        {
            get
            {
                return cuttingTime;
            }

            set
            {
                cuttingTime = value;
            }
        }

        public float SpindleReadyTime
        {
            get
            {
                return spindleReadyTime;
            }

            set
            {
                spindleReadyTime = value;
            }
        }

        public float SpindleAxis
        {
            get
            {
                return spindleAxis;
            }

            set
            {
                spindleAxis = value;
            }
        }
        public bool ReplaceBldXNoMove
        {
            get
            {
                return replaceBldXNoMove;
            }

            set
            {
                replaceBldXNoMove = value;
            }
        }

        public float ReplaceBldXPos
        {
            get
            {
                return replaceBldXPos;
            }

            set
            {
                replaceBldXPos = value;
            }
        }

        public float ReplaceBldYPos
        {
            get
            {
                return replaceBldYPos;
            }

            set
            {
                replaceBldYPos = value;
            }
        }

        public float ReplaceBldZPos
        {
            get
            {
                return replaceBldZPos;
            }

            set
            {
                replaceBldZPos = value;
            }
        }

        public bool BuzzerUsed
        {
            get
            {
                return buzzerUsed;
            }

            set
            {
                buzzerUsed = value;
            }
        }

        public bool CutWaterChecked
        {
            get
            {
                return cutWaterChecked;
            }

            set
            {
                cutWaterChecked = value;
            }
        }

        public bool LeakWaterChecked
        {
            get
            {
                return leakWaterChecked;
            }

            set
            {
                leakWaterChecked = value;
            }
        }

        public bool DoorProtectUsed
        {
            get
            {
                return doorProtectUsed;
            }

            set
            {
                doorProtectUsed = value;
            }
        }

        public bool TestCheckAir
        {
            get
            {
                return testCheckAir;
            }

            set
            {
                testCheckAir = value;
            }
        }

        public bool DualZlife
        {
            get
            {
                return dualZlife;
            }

            set
            {
                dualZlife = value;
            }
        }

        public bool CutStopCloseWater
        {
            get
            {
                return cutStopCloseWater;
            }

            set
            {
                cutStopCloseWater = value;
            }
        }

        public bool CutPauseCloseWater
        {
            get
            {
                return cutPauseCloseWater;
            }

            set
            {
                cutPauseCloseWater = value;
            }
        }

        public bool ResumeCloseBuzzer
        {
            get
            {
                return resumeCloseBuzzer;
            }

            set
            {
                resumeCloseBuzzer = value;
            }
        }
        public bool CutStopUnloadVacuum
        {
            get
            {
                return cutStopUnloadVacuum;
            }

            set
            {
                cutStopUnloadVacuum = value;
            }
        }
        public DateTime SaveTime
        {
            get
            {
                return saveTime;
            }

            set
            {
                saveTime = value;
            }
        }

        public LedCmd LoadLedCmd
        {
            get
            {
                return loadLedCmd;
            }

            set
            {
                loadLedCmd = value;
            }
        }

        public LedCmd IdleLedCmd
        {
            get
            {
                return idleLedCmd;
            }

            set
            {
                idleLedCmd = value;
            }
        }

        public LedCmd InitLedCmd
        {
            get
            {
                return initLedCmd;
            }

            set
            {
                initLedCmd = value;
            }
        }

        public LedCmd PauseLedCmd
        {
            get
            {
                return pauseLedCmd;
            }

            set
            {
                pauseLedCmd = value;
            }
        }

        public LedCmd StopLedCmd
        {
            get
            {
                return stopLedCmd;
            }

            set
            {
                stopLedCmd = value;
            }
        }

        public LedCmd WorkingLedCmd
        {
            get
            {
                return workingLedCmd;
            }

            set
            {
                workingLedCmd = value;
            }
        }

        public LedCmd TestingLedCmd
        {
            get
            {
                return testingLedCmd;
            }

            set
            {
                testingLedCmd = value;
            }
        }

        public LedCmd ErrAirWaterLedCmd
        {
            get
            {
                return errAirWaterLedCmd;
            }

            set
            {
                errAirWaterLedCmd = value;
            }
        }

        public LedCmd EmgLedCmd
        {
            get
            {
                return emgLedCmd;
            }

            set
            {
                emgLedCmd = value;
            }
        }



        public void SaveDevDataToFile(string path)
        {
            SaveTime = DateTime.Now;
            string s = Data.Serialize.XmlSerialize(this);
            File.WriteAllText(path, s);
        }
        public DevData CreateNewDevData(bool clone=true)
        {
            if (clone)
            {
                string s = Serialize.XmlSerialize(this);
                return Serialize.XmlDeSerialize<DevData>(s);
            }
            else
            {
                return new DevData();
            }
        }
        public void InitMacDataToHardWare()
        {
            if (Common.HwProvider.CreateSucessful)
            {
                AxisParams p = Common.X_Axis.Param;
                if (p != null)
                {
                    p.JogVelSlow = this.XLowSpeed;
                    p.JogAccSlow = this.XLowAcc;
                    p.JogVel = this.XSpeed;
                    p.JogAcc = this.XAcc;
                }
                p = Common.Y_Axis.Param;
                if (p != null)
                {
                    p.JogVelSlow = this.YLowSpeed;
                    p.JogAccSlow = this.YLowAcc;
                    p.JogVel = this.YSpeed;
                    p.JogAcc = this.YAcc;
                }
                p = Common.Z_Axis.Param;
                if (p != null)
                {
                    p.JogVelSlow = this.ZLowSpeed;
                    p.JogAccSlow = this.ZLowAcc;
                    p.JogVel = this.ZSpeed;
                    p.JogAcc = this.ZAcc;
                }
                p = Common.T_Axis.Param;
                if (p != null)
                {
                    p.JogVelSlow = this.TLowSpeed;
                    p.JogAccSlow = this.TLowAcc;
                    p.JogVel = this.TSpeed;
                    p.JogAcc = this.TAcc;
                }
                if (Common.Capture != null)
                {
                    if (Common.DoubleCap)
                    {
                        Common.Capture.Scale = LowPixValue;//低倍的倍率
                        Common.CaptureL.Scale = HighPixValue;//高倍倍率
                    }
                    else
                    {
                        Common.Capture.Scale = HighPixValue;//高倍倍率
                    }
                }
                Globals.ViewCenter.X = HighCenterX;
                Globals.ViewCenter.Y = HighCenterY;
            }
        }
    }
}
