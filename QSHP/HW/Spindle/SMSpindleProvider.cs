using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Xml.Serialization;
namespace QSHP.HW.Spindle
{
    public class SMSpindleProvider : SpindleProvider
    {
        const int SD2MaxSpeed = 60000;
        const int SD2MaxNum = 0x3FFF;
        const int SD2MinSpeed = 3000;
        const int SD2MaxCurrent = 25;
        #region 私有字段属性
        public const byte UART_ZORE = 0;
        public const byte UART_DEST = 0x1;
        public byte UART_SOURCE = 0x2;
        public const byte UART_RX_CMD = 0x90;
        SMRxStatus uart_rx_status = SMRxStatus.UART_ZERO;
        volatile int u16_uart_rcv_head = 0;
        volatile byte[] u8_uart_rcv_data = null;
        volatile int u8_uart_rcv_len = 0;
        volatile byte u8_check_sum = 0;
        SerialPort Port;
        object synLocker = new object();
        AutoResetEvent mNotifyEventt = new AutoResetEvent(false);
        byte[] sendData = { 0, 13, 2, 1, 0x10, 1, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0xd8 };
        bool speedZero = true;
        bool fault = false;
        [XmlIgnore]
        private ushort ControlCMD
        {
            get
            {
                return BitConverter.ToUInt16(sendData, 7);
            }
            set
            {
                sendData[7] = (byte)(value & 0xFF);
                sendData[8] = (byte)(value >> 8 & 0xFF);
            }
        }
         [XmlIgnore]
        private short CMDSpeed
        {
            get
            {
                return BitConverter.ToInt16(sendData, 9);
            }
            set
            {
                sendData[9] = (byte)(value & 0xFF);
                sendData[10] = (byte)(value >> 8 & 0xFF);
            }
        }
         [XmlIgnore]
        private int ControlSpeed
        {
            set
            {
                if (value > SD2MaxSpeed)
                {
                    value = (int)SD2MaxSpeed;
                }
                CMDSpeed = (short)((float)value / SD2MaxSpeed * SD2MaxNum);
            }
        }

        #endregion

        #region 重构
        [XmlAttribute("Index")]
        public override int AmpCIndex
        {
            get
            {
                return sendData[2];
            }

            set
            {
                sendData[2] = (byte)(value+2);
                UART_SOURCE = sendData[2];
            }
        }
        public override bool SpeedZore
        {
            get
            {
                return speedZero;
            }
        }

        public SMSpindleProvider()
        {
            Port = new SerialPort();
        }

        public SMSpindleProvider(int index)
        {
            DevIndex = index;
            baudRate = 57600;
            Port = new SerialPort();
        }

        public override bool InitSpd()
        {
            lock (synLocker)
            {
                if (isInit)
                {
                    return true;
                }
                if (Port.IsOpen)
                {
                    Port.Close();
                }
                Port.PortName = String.Format("COM{0}", DevIndex);
                Port.BaudRate = baudRate;
                Port.ReadTimeout = 2000;
                Port.WriteTimeout = 2000;
                Port.WriteBufferSize = 4096;
                Port.ReadBufferSize = 4096;
                Port.StopBits = StopBits.One;
                Port.ReceivedBytesThreshold = 16;
                waitFlag = false;
                Port.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
                try
                {
                    if (!Port.IsOpen)
                    {
                        Port.Open();
                    }
                    isInit = Port.IsOpen;
                }
                catch
                {
                    isInit = false;
                }
                SwitchOnSpd();
                if (!isInit)
                {
                    CloseSpd();
                    cycleFlag = false;
                }
                else
                {
                    cycleFlag = true;
                }
            }
            return base.InitSpd();
        }

        public override bool CloseSpd()
        {
            base.CloseSpd();//关闭主轴
            Thread.Sleep(SamplingMs);
            if (Port.IsOpen)
            {
                Port.Close();
            }
            isInit = false;
            Port.DataReceived -= Port_DataReceived;
            return !Port.IsOpen;
        }

        public override bool RunSpd(int speed)
        {
            if (!isInit)
                return false;
            lock (synLocker)
            {
                ControlSpeed = speed;
                setSpeed = speed;
                bool flag = SendControlCMDResponse(SMSpindleCMD.EnOperation);
                return flag & (!fault);
            }
        }

        public override bool StopSpd()
        {
            if (!isInit)
                return false;
            lock (synLocker)
            {
                setSpeed = 0;
                ControlSpeed = 0;
                bool flag = SendControlCMDResponse(SMSpindleCMD.QuickStop);
                return flag & (!fault);
            }
        }

        public override bool ResetSpd()
        {
            if (!isInit)
                return false;
            lock (synLocker)
            {
                setSpeed = 0;
                ControlSpeed = 0;
                int tick = 3;
                while (fault && tick > 0)
                {
                    tick--;
                    SendControlCMDResponse(SMSpindleCMD.FaultReset, false);
                    Thread.Sleep(50);
                    SendControlCMDResponse(SMSpindleCMD.DisVoltage, false);
                    Thread.Sleep(50);
                }
                SendControlCMDResponse(SMSpindleCMD.ShotDown, false);
                Thread.Sleep(50);
                return SwitchOnSpd();
            }
        }

        protected override bool UpdateSampling()
        {
            if (isInit & cycleFlag)
            {
                return SendControlData();
            }
            else
            {
                return fault;
            }
        }

        public override string GetSpdStatusString()
        {
            switch (errCode)
            {
                case 0:
                    {
                        return "正常";
                    }
                case 0xFD:
                    {
                        return "连接失败";
                    }
                case 0xFC:
                    {
                        return "断开连接";
                    }
                case 0xFF:
                    {
                        return "通讯超时";
                    }
                case 0xFE:
                    {
                        return "校验失败";
                    }
                default:
                    {
                        return "故障";
                    }
            }
        }

        public override String GetStatusDetailDescription()
        {

            return GetSpdStatusString();
        }

        public override void Dispose()
        {
            base.Dispose();
            if (Port.IsOpen)
            {
                Port.Close();
            }
        }
        #endregion

        #region 私有方法

        private bool SwitchOnSpd()
        {
            if (!isInit)
            {
                return false;
            }
            bool flag = SendControlCMDResponse(SMSpindleCMD.ShotDown);
            return flag;
        }

        private bool SendControlCMDResponse(SMSpindleCMD cmd, bool cycle = true)
        {
            if (!isInit)
            {
                return false;
            }
            cycleFlag = false;
            ControlCMD = (ushort)cmd;
            sendData[15] = GetCheckSum(sendData, 15);
            bool flag = SendControlData();
            cycleFlag = cycle;
            return flag;
        }

        private bool SendControlData()
        {
            if (!isInit)
            {
                return false;
            }
            lock (synLocker)
            {
                InitTransArgs();//初始化数据
                Port.Write(sendData, 0, sendData.Length);
                if (WaitForResponse(2000))
                {
                    byte[] rv_buf = new byte[16];
                    Port.Read(rv_buf, 0, 16);
                    return Analyse(rv_buf);//进行数据分析
                }
                else
                {
                    return false;
                }
            }
        }

        void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (Port.BytesToRead >= 16)
            {
                if (waitFlag)
                {
                    mNotifyEventt.Set();
                }
            }
        }

        private void InitTransArgs()
        {
            waitFlag = true;
            Port.DiscardInBuffer();
        }

        private bool WaitForResponse(int waitTime = 500)
        {
            if (mNotifyEventt.WaitOne(waitTime))
            {
                errCode = 0;
                waitFlag = false;
                return true;
            }
            else
            {
                errCode = 0xFF;//接收超时
                waitFlag = false;
                return false;
            }
        }

        protected bool Analyse(byte[] uart_data) //对数据进行分析
        {
            bool flag = false;
            foreach (var rv_data in uart_data)
            {
                switch (uart_rx_status)
                {
                    case SMRxStatus.UART_ZERO:
                        {
                            if (rv_data == UART_ZORE)
                            {
                                uart_rx_status = SMRxStatus.UART_DATA_LEN;
                            }
                            u8_uart_rcv_len = 0;
                            u16_uart_rcv_head = 0;
                        } break;
                    case SMRxStatus.UART_DATA_LEN:
                        {
                            if (rv_data > 3)//长度小于2自动过滤
                            {
                                u8_uart_rcv_len = rv_data - 3;
                                u8_uart_rcv_data = new byte[u8_uart_rcv_len];//当前数据帧长度 该系统中默认为13-3 =10 数据
                                u8_check_sum = rv_data;
                                u16_uart_rcv_head = 0;
                                uart_rx_status = SMRxStatus.UART_DEST;
                            }
                            else
                            {
                                uart_rx_status = SMRxStatus.UART_ZERO;
                            }
                        } break;
                    case SMRxStatus.UART_DEST:
                        {
                            if (rv_data == UART_DEST)//1 for pc
                            {
                                u8_check_sum += rv_data;
                                uart_rx_status = SMRxStatus.UART_SOURCE;
                            }
                            else
                            {
                                uart_rx_status = SMRxStatus.UART_ZERO;
                            }
                        } break;
                    case SMRxStatus.UART_SOURCE:
                        {
                            if (rv_data == UART_SOURCE)
                            {
                                u8_check_sum += rv_data;
                                uart_rx_status = SMRxStatus.UART_CMD;
                            }
                            else
                            {
                                uart_rx_status = SMRxStatus.UART_ZERO;
                            }
                        } break;
                    case SMRxStatus.UART_CMD:
                        {
                            if (rv_data == UART_RX_CMD)
                            {
                                uart_rx_status = SMRxStatus.UART_DATA;
                                u8_check_sum += rv_data;
                            }
                            else
                            {
                                uart_rx_status = SMRxStatus.UART_ZERO;
                            }
                        } break;
                    case SMRxStatus.UART_DATA:
                        {
                            u8_uart_rcv_data[u16_uart_rcv_head++] = rv_data;
                            u8_check_sum += rv_data;
                            if (u16_uart_rcv_head >= u8_uart_rcv_len)
                            {
                                uart_rx_status = SMRxStatus.UART_SUM;
                            }
                        } break;
                    case SMRxStatus.UART_SUM:
                        {
                            if (0xFF - u8_check_sum == rv_data)
                            {
                                SMRecvEventArgs e = new SMRecvEventArgs(u8_uart_rcv_data);
                                workCur = (float)e.ReadCurrent;
                                workSpeed = e.ReadSpeed;
                                speedZero = e.SpeedZero;
                                errCode = (byte)e.DriverError;
                                fault = e.Fault;
                                swFlag = e.EnOperation;
                                flag = true;
                            }
                            else
                            {
                                errCode = 0xFE;//数据校验错误
                            }
                            uart_rx_status = SMRxStatus.UART_ZERO;//结束标志
                        } break;
                    default:
                        {
                            uart_rx_status = SMRxStatus.UART_ZERO;
                        } break;
                }
            }
            return flag;
        }

        private byte GetCheckSum(byte[] data, int num)
        {
            byte sum = 0;
            if (num > data.Length)
            {
                num = data.Length;
            }
            for (int i = 0; i < num; i++)
            {
                sum += data[i];
            }
            sum = (byte)(255 - sum);
            return sum;
        }
        #endregion

        #region 内部类
        enum SMSpindleCMD : byte
        {
            ShotDown = 6,
            WitchOn = 7,
            DisVoltage = 0,
            QuickStop = 2,
            DisOperation = 7,
            EnOperation = 15,
            FaultReset = 128
        }
        enum SMRxStatus : byte
        {
            UART_ZERO,
            UART_DATA_LEN,
            UART_DEST,
            UART_SOURCE,
            UART_CMD,
            UART_DATA,
            UART_SUM
        }
        class SMRecvEventArgs : EventArgs
        {
            private UInt16 pDOHeader = 0;
            private UInt16 statusWord = 0;
            private Int16 actualSpeed = 0;
            private UInt16 driverError = 0;


            public UInt16 actualCurrent = 0;

            #region 属性
            public bool Ready
            {
                get
                {
                    return (statusWord & 0x01) > 0;
                }
            }

            public bool SwitchedOn
            {
                get
                {
                    return ((statusWord >> 1) & 0x01) > 0;
                }
            }

            public UInt16 DriverError
            {
                get { return driverError; }
                set { driverError = value; }
            }
            public bool EnOperation
            {
                get
                {
                    return ((statusWord >> 2) & 0x01) > 0;
                }
            }

            public bool Fault
            {
                get
                {
                    return ((statusWord >> 3) & 0x01) > 0;
                }
            }

            public bool EnVoltage
            {
                get
                {
                    return ((statusWord >> 4) & 0x01) > 0;
                }
            }

            public bool QuickStop
            {
                get
                {
                    return ((statusWord >> 5) & 0x01) > 0;
                }
            }

            public bool DisSwitchOn
            {
                get
                {
                    return ((statusWord >> 6) & 0x01) > 0;
                }
            }

            public bool Warning
            {
                get
                {
                    return ((statusWord >> 7) & 0x01) > 0;
                }
            }

            public bool Remote
            {
                get
                {
                    return ((statusWord >> 9) & 0x01) > 0;
                }
            }

            public bool TargetReached
            {
                get
                {
                    return ((statusWord >> 10) & 0x01) > 0;
                }
            }

            public bool LimitActive
            {
                get
                {
                    return ((statusWord >> 11) & 0x01) > 0;
                }
            }

            public bool SpeedZero
            {
                get
                {
                    return ((statusWord >> 12) & 0x01) > 0;
                }
            }

            public bool MaxTaget
            {
                get
                {
                    return ((statusWord >> 12) & 0x01) > 0;
                }
            }

            public float ReadSpeed
            {
                get
                {
                    if (actualSpeed > SD2MaxNum)
                    {
                        return SD2MaxSpeed;
                    }
                    else
                    {
                        float value = (float)actualSpeed / SD2MaxNum;
                        return value * SD2MaxSpeed;
                    }
                }
            }

            public float ReadCurrent
            {
                get
                {
                    return (float)actualCurrent * SD2MaxCurrent / SD2MaxNum;
                }
            }
            #endregion
            public SMRecvEventArgs(byte[] data)
            {
                if (data.Length > 9)
                {
                    pDOHeader = BitConverter.ToUInt16(data, 0);
                    statusWord = BitConverter.ToUInt16(data, 2);
                    actualSpeed = BitConverter.ToInt16(data, 4);
                    driverError = BitConverter.ToUInt16(data, 6);
                    actualCurrent = BitConverter.ToUInt16(data, 8);
                }
            }
        }
        #endregion
    }

}
