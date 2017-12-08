using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using QSHP.Com;
using System.Xml.Serialization;

namespace QSHP.HW.Spindle
{
    public class VFSpindleProvider : SpindleProvider
    {
        SerialPort Port;
        byte addr = 1;
        object synLocker = new object();
        int readBufferNum = 0;//读取接收字节个数
        AutoResetEvent mNotifyEventt = new AutoResetEvent(false);
        public VFSpindleProvider()
        {
            Port = new SerialPort();
        }

        public VFSpindleProvider(int index)
        {
            Port = new SerialPort();
            DevIndex = index;
        }
        public override void Dispose()
        {
            base.Dispose();
            if (Port.IsOpen)
            {
                Port.Close();
            }
        }

        #region 重构
        [XmlAttribute("Index")]
        public override int AmpCIndex
        {
            get
            {
                return addr;
            }

            set
            {
                addr = (byte)value;
            }
        }

        public override bool SpeedZore
        {
            get
            {
                return !swFlag;
            }
        }

        protected override bool UpdateSampling()
        {
            ushort[] data = null;
            if (cycleFlag)
            {
                if (ReadRegisterValues(0x2100, out data, 5))
                {
                    if (data[0] != 0)
                    {
                        errCode = (byte)(0x80 + data[0]);
                    }
                    workCur = (float)data[4] / 10;
                    swFlag = ((data[1] >> 12) & 0x01) > 0;
                    workSpeed = (float)data[3] * 6;
                }
            }
            return isInit && cycleFlag;
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
                Port.Parity = Parity.None;
                Port.ReceivedBytesThreshold = 1;
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
                isInit &= TestCommunicationCircuit();//测试通讯
                if (!isInit)//初始化失败
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
            if (swFlag)
            {
                StopSpd();
            }
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
                cycleFlag = false;
                UInt16[] cmdValue = new ushort[2];
                cmdValue[0] = 0x02;
                cmdValue[1] = (UInt16)((float)speed / 6);
                setSpeed = speed;
                bool flag = WriteMultipleRegisterValues(0x2000, cmdValue, 2);
                cycleFlag = true;
                return flag;
            }
        }

        public override bool StopSpd()
        {
            if (!isInit)
                return false;
            cycleFlag = false;
            lock (synLocker)
            {
                setSpeed = 0;
                bool flag = WriteOneRegisterValue(0x2000, 0x01);
                cycleFlag = true;
                return flag;
            }
        }

        public override bool ResetSpd()
        {
            if (!isInit)
                return false;
            cycleFlag = false;
            lock (synLocker)
            {
                setSpeed = 0;
                bool flag = WriteOneRegisterValue(0x2002, 0x02);
                cycleFlag = true;
                return flag;
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
                case 0x01:
                    {
                        return "功能码未识别";
                    }
                case 0x02:
                    {
                        return "地址错误";
                    }
                case 0x03:
                    {
                        return "参数超限";
                    }
                case 0x04:
                    {
                        return "无法执行";
                    }
                case 0x10:
                    {
                        return "传输超时";
                    }
                case 0xFF:
                    {
                        return "接收超时";
                    }
                case 0xFE:
                    {
                        return "通讯超时";
                    }
                case 0xFD:
                    {
                        return "连接失败";
                    }
                case 0xFC:
                    {
                        return "断开连接";
                    }
                default:
                    {
                        return "故障";
                    }
            }

        }

        public override String GetStatusDetailDescription()
        {
            if (errCode < 0x80 || errCode > 0xF0)
            {
                return GetSpdStatusString();
            }
            else
            {
                switch (errCode & 0x7F)
                {
                    case 1:
                        {
                            return "过流OC";
                        }
                    case 2:
                        {
                            return "过压OV";
                        }
                    case 3:
                        {
                            return "过热OH";
                        }
                    case 4:
                        {
                            return "驱动器过负载Ol";
                        }
                    case 5:
                        {
                            return "电机过负载Ol1";
                        }
                    case 6:
                        {
                            return "外部异常";
                        };
                    case 7:
                        {
                            return "IGBT短路保护启动OCC";
                        }
                    case 8:
                        {
                            return "CPU或模拟电路有问题 Cf3";
                        }
                    case 9:
                        {
                            return "硬件数字保护线路有问题HPF";
                        }
                    case 10:
                        {
                            return "加速中过流ocA";
                        }
                    case 11:
                        {
                            return "减速中过流ocd";
                        }
                    case 12:
                        {
                            return "恒速中过流ocn";
                        }
                    case 13:
                        {
                            return "对地短路GFF";
                        }
                    case 14:
                        {
                            return "低电压LV";
                        }
                    case 15:
                        {
                            return "CPU写入有问题";
                        }
                    case 16:
                        {
                            return "CPU读出有问题";
                        }
                    case 17:
                        {
                            return "b.b.";
                        }
                    case 18:
                        {
                            return "过转矩ol2";
                        }
                    case 19:
                        {
                            return "不适用自动加减速设定cFA";
                        }
                    case 20:
                        {
                            return "软件与参数密码保护codE";
                        }
                    case 21:
                        {
                            return "EF1紧急停止";
                        }
                    case 22:
                        {
                            return "输入电源欠相PHL";
                        }
                    case 23:
                        {
                            return "指定计数值达到EF";
                        }
                    case 24:
                        {
                            return "低电流Lc";
                        }
                    case 25:
                        {
                            return "模拟回授信号错误AnLEr";
                        }
                    case 26:
                        {
                            return "PG回授信号错误";
                        }
                    default:
                        {
                            return "未识别错误";
                        }
                }
            }
        }

        #endregion

        #region 内部函数
        internal bool WriteOneRegisterValue(ushort address, ushort value)
        {
            if (!Port.IsOpen)
                return false;
            lock (synLocker)
            {
                byte[] data = new byte[8];
                data[0] = addr;
                data[1] = 0x06;
                data[2] = (byte)(address >> 8 & 0xFF);
                data[3] = (byte)(address & 0xFF);
                data[4] = (byte)(value >> 8 & 0xFF);
                data[5] = (byte)(value & 0xFF);
                byte[] crc = Checksum.CRC16(data, 6);
                data[6] = crc[0];
                data[7] = crc[1];
                if (InitTransArgs(8))
                {
                    Port.Write(data, 0, 8);
                    if (WaitForResponse(2000))
                    {
                        byte[] recvData = new byte[8];
                        Port.Read(recvData, 0, 8);
                        return BitConverter.ToUInt64(recvData, 0) == BitConverter.ToUInt64(data, 0);
                    }
                }
                return false;
            }
        }

        internal bool ReadRegisterValues(ushort address, out ushort[] value, int num = 1)
        {
            if (num > 20)
            {
                num = 20;
            }
            value = new ushort[num];
            if (!Port.IsOpen)
                return false;
            lock (synLocker)
            {
                byte[] data = new byte[8];
                data[0] = addr;
                data[1] = 0x03;
                data[2] = (byte)(address >> 8 & 0xFF);
                data[3] = (byte)(address & 0xFF);
                data[4] = (byte)(num >> 8 & 0xFF);
                data[5] = (byte)(num & 0xFF);
                byte[] crc = Checksum.CRC16(data, 6);
                data[6] = crc[0];
                data[7] = crc[1];
                waitFlag = true;
                if (InitTransArgs(5 + num * 2))
                {
                    Port.Write(data, 0, 8);
                    if (WaitForResponse(500 * num))
                    {
                        byte[] recvData = new byte[readBufferNum];
                        Port.Read(recvData, 0, readBufferNum);
                        if (recvData[2] == 2 * num)
                        {
                            for (int i = 0; i < num; i++)
                            {
                                value[i] = recvData[3 + i * 2];
                                value[i] <<= 8;
                                value[i] += recvData[4 + i * 2];
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        internal bool WriteMultipleRegisterValues(ushort address, ushort[] value, int num)
        {
            if (!Port.IsOpen)
                return false;
            if (value.Length < num)
            {
                num = value.Length;
            }
            lock (synLocker)
            {
                byte[] data = new byte[9 + num * 2];
                data[0] = addr;
                data[1] = 0x10;
                data[2] = (byte)(address >> 8 & 0xFF);
                data[3] = (byte)(address & 0xFF);
                data[4] = 0x00;
                data[5] = (byte)(num);
                data[6] = (byte)(data[5] * 2);
                for (int i = 0; i < data[6]; i += 2)
                {
                    data[7 + i] = (byte)(value[i / 2] >> 8 & 0xFF);
                    data[8 + i] = (byte)(value[i / 2] & 0xFF);
                }
                byte[] crc = Checksum.CRC16(data, 7 + num * 2);
                data[7 + num * 2] = crc[0];
                data[8 + num * 2] = crc[1];
                if (InitTransArgs(8))
                {
                    Port.Write(data, 0, data.Length);
                    if (WaitForResponse(2000))
                    {
                        byte[] recvData = new byte[8];
                        Port.Read(recvData, 0, 8);
                        return BitConverter.ToUInt32(data, 2) == BitConverter.ToUInt32(recvData, 2);
                    }
                }
                return false;
            }
        }

        internal bool TestCommunicationCircuit()
        {
            if (!Port.IsOpen)
                return false;
            lock (synLocker)
            {
                byte[] data = new byte[8];
                data[0] = addr;
                data[1] = 0x08;
                data[2] = 0x00;
                data[3] = 0x00;
                data[4] = 0x17;
                data[5] = 0x70;
                byte[] crc = Checksum.CRC16(data, 6);
                data[6] = crc[0];
                data[7] = crc[1];
                if (InitTransArgs(8))
                {
                    Port.Write(data, 0, 8);
                    if (WaitForResponse(1000))
                    {
                        byte[] recvData = new byte[8];
                        Port.Read(recvData, 0, 8);
                        return recvData[1] == 0x08;
                    }
                }
                return false;
            }
        }

        private bool InitTransArgs(int num)
        {
            if (!Port.IsOpen)
            {
                return false;
            }
            waitFlag = true;
            readBufferNum = num;
            while (Port.BytesToRead != 0)
            {
                Port.DiscardInBuffer();
                Thread.Sleep(1);
            }
            Port.ReceivedBytesThreshold = num;
            return true;
        }

        private bool WaitForResponse(int waitTime = 500)
        {
            if (mNotifyEventt.WaitOne(waitTime) && Port.BytesToRead != 5)
            {
                errCode = 0;
                waitFlag = false;
                return true;
            }
            else
            {
                if (Port.IsOpen && Port.BytesToRead == 5)
                {
                    byte[] recvData = new byte[Port.BytesToRead];
                    Port.Read(recvData, 0, Port.BytesToRead);
                    if (recvData[1] > 0x80)
                    {
                        errCode = recvData[2];
                    }
                    else
                    {
                        errCode = 0xFF;//接收超时
                    }
                }
                else
                {
                    errCode = 0xFF;//接收超时
                }
                waitFlag = false;
                return false;
            }
        }

        void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (waitFlag)
            {
                mNotifyEventt.Set();
            }
        }

        #endregion
    }
}
