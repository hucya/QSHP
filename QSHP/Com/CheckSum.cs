using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;

namespace QSHP.Com
{
    public static class Checksum
    {
        static string iv = "12345678";
        static string key = "12345678";
        /// <summary>
        /// 对文件内容进行DES加密
        /// </summary>
        /// <param name="sourceFile">待加密的文件绝对路径</param>
        /// <param name="destFile">加密后的文件保存的绝对路径</param>
        public static void EncryptFile(string sourceFile, string destFile)
        {

            if (!File.Exists(sourceFile)) throw new FileNotFoundException("指定的文件路径不存在！", sourceFile);

            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] btFile = File.ReadAllBytes(sourceFile);

            using (FileStream fs = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (CryptoStream cs = new CryptoStream(fs, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(btFile, 0, btFile.Length);
                        cs.FlushFinalBlock();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 对文件内容进行DES加密，加密后覆盖掉原来的文件
        /// </summary>
        /// <param name="sourceFile">待加密的文件的绝对路径</param>
        public static void EncryptFile(string sourceFile)
        {
            EncryptFile(sourceFile, sourceFile);
        }

        /// <summary>
        /// 对文件内容进行DES解密
        /// </summary>
        /// <param name="sourceFile">待解密的文件绝对路径</param>
        /// <param name="destFile">解密后的文件保存的绝对路径</param>
        public static void DecryptFile(string sourceFile, string destFile)
        {

            if (!File.Exists(sourceFile))
                throw new FileNotFoundException("指定的文件路径不存在！", sourceFile);

            byte[] btKey = Encoding.Default.GetBytes(key);
            byte[] btIV = Encoding.Default.GetBytes(iv);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] btFile = File.ReadAllBytes(sourceFile);


            using (FileStream fs = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (CryptoStream cs = new CryptoStream(fs, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(btFile, 0, btFile.Length);
                        cs.FlushFinalBlock();
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 对文件内容进行DES解密，解密后覆盖掉原来的文件
        /// </summary>
        /// <param name="sourceFile">待解密的文件的绝对路径</param>
        public static void DecryptFile(string sourceFile)
        {
            DecryptFile(sourceFile, sourceFile);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string EncryptWithMD5(string source)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string str = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(source)), 4, 8);
            return str.Replace("-", "").ToLower();
        }

        private static readonly uint[] mCRC32Table;
        private static readonly ushort[] mCRC16Table = 
        {
                0X0000, 0XC0C1, 0XC181, 0X0140, 0XC301, 0X03C0, 0X0280, 0XC241,
                0XC601, 0X06C0, 0X0780, 0XC741, 0X0500, 0XC5C1, 0XC481, 0X0440,
                0XCC01, 0X0CC0, 0X0D80, 0XCD41, 0X0F00, 0XCFC1, 0XCE81, 0X0E40,
                0X0A00, 0XCAC1, 0XCB81, 0X0B40, 0XC901, 0X09C0, 0X0880, 0XC841,
                0XD801, 0X18C0, 0X1980, 0XD941, 0X1B00, 0XDBC1, 0XDA81, 0X1A40,
                0X1E00, 0XDEC1, 0XDF81, 0X1F40, 0XDD01, 0X1DC0, 0X1C80, 0XDC41,
                0X1400, 0XD4C1, 0XD581, 0X1540, 0XD701, 0X17C0, 0X1680, 0XD641,
                0XD201, 0X12C0, 0X1380, 0XD341, 0X1100, 0XD1C1, 0XD081, 0X1040,
                0XF001, 0X30C0, 0X3180, 0XF141, 0X3300, 0XF3C1, 0XF281, 0X3240,
                0X3600, 0XF6C1, 0XF781, 0X3740, 0XF501, 0X35C0, 0X3480, 0XF441,
                0X3C00, 0XFCC1, 0XFD81, 0X3D40, 0XFF01, 0X3FC0, 0X3E80, 0XFE41,
                0XFA01, 0X3AC0, 0X3B80, 0XFB41, 0X3900, 0XF9C1, 0XF881, 0X3840,
                0X2800, 0XE8C1, 0XE981, 0X2940, 0XEB01, 0X2BC0, 0X2A80, 0XEA41,
                0XEE01, 0X2EC0, 0X2F80, 0XEF41, 0X2D00, 0XEDC1, 0XEC81, 0X2C40,
                0XE401, 0X24C0, 0X2580, 0XE541, 0X2700, 0XE7C1, 0XE681, 0X2640,
                0X2200, 0XE2C1, 0XE381, 0X2340, 0XE101, 0X21C0, 0X2080, 0XE041,
                0XA001, 0X60C0, 0X6180, 0XA141, 0X6300, 0XA3C1, 0XA281, 0X6240,
                0X6600, 0XA6C1, 0XA781, 0X6740, 0XA501, 0X65C0, 0X6480, 0XA441,
                0X6C00, 0XACC1, 0XAD81, 0X6D40, 0XAF01, 0X6FC0, 0X6E80, 0XAE41,
                0XAA01, 0X6AC0, 0X6B80, 0XAB41, 0X6900, 0XA9C1, 0XA881, 0X6840,
                0X7800, 0XB8C1, 0XB981, 0X7940, 0XBB01, 0X7BC0, 0X7A80, 0XBA41,
                0XBE01, 0X7EC0, 0X7F80, 0XBF41, 0X7D00, 0XBDC1, 0XBC81, 0X7C40,
                0XB401, 0X74C0, 0X7580, 0XB541, 0X7700, 0XB7C1, 0XB681, 0X7640,
                0X7200, 0XB2C1, 0XB381, 0X7340, 0XB101, 0X71C0, 0X7080, 0XB041,
                0X5000, 0X90C1, 0X9181, 0X5140, 0X9301, 0X53C0, 0X5280, 0X9241,
                0X9601, 0X56C0, 0X5780, 0X9741, 0X5500, 0X95C1, 0X9481, 0X5440,
                0X9C01, 0X5CC0, 0X5D80, 0X9D41, 0X5F00, 0X9FC1, 0X9E81, 0X5E40,
                0X5A00, 0X9AC1, 0X9B81, 0X5B40, 0X9901, 0X59C0, 0X5880, 0X9841,
                0X8801, 0X48C0, 0X4980, 0X8941, 0X4B00, 0X8BC1, 0X8A81, 0X4A40,
                0X4E00, 0X8EC1, 0X8F81, 0X4F40, 0X8D01, 0X4DC0, 0X4C80, 0X8C41,
                0X4400, 0X84C1, 0X8581, 0X4540, 0X8701, 0X47C0, 0X4680, 0X8641,
                0X8201, 0X42C0, 0X4380, 0X8341, 0X4100, 0X81C1, 0X8081, 0X4040 
            };

        public static string GetRegiterKeys(bool register = true)
        {
            try
            {
                MachineInfo info = new MachineInfo();
                StringBuilder s = new StringBuilder();
                string id = info.GetCPUID();
                s.Append(id.Substring(12, 4));
                s.Append(id.Substring(0, 4));
                s.Append(id.Substring(4, 4));
                s.Append(id.Substring(8, 4));
                if (register)
                {
                   return EncryptWithMD5(s.ToString()).Substring(8,8).ToUpper();
                }
                else
                {
                    char[] c = s.ToString().ToCharArray();
                    s.Clear();
                    for (int i = 0; i < c.Count(); i += 3)
                    {
                        s.Append(c[i]);
                    }
                    s.Append(c.Last());
                    return s.ToString().ToUpper();
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool CheckRegiterKeysIsValid(string keys, bool register = true)
        {
            try
            {
                string s = GetRegiterKeys(register);
                StringBuilder b = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                    s = EncryptWithMD5(s).ToUpper();
                }
                s = s.Substring(5, 6);
                if (s.Equals(keys.ToUpper()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckRegiterKeysIsValid(string keys, string value)
        {
            try
            {
                string s = value.ToUpper();
                StringBuilder b = new StringBuilder();
                for (int i = 0; i < s.Length; i++)
                {
                    s = EncryptWithMD5(s).ToUpper();
                }
                s = s.Substring(5, 6);
                if (s.Equals(keys.ToUpper()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        static Checksum()
        {
            Checksum.mCRC32Table = new uint[256];
            uint num = 0u;
            while ((ulong)num < (ulong)((long)Checksum.mCRC32Table.Length))
            {
                uint num2 = num;
                for (int i = 8; i > 0; i--)
                {
                    if ((num2 & 1u) == 1u)
                    {
                        num2 = (num2 >> 1 ^ 3988292384u);
                    }
                    else
                    {
                        num2 >>= 1;
                    }
                }
                Checksum.mCRC32Table[(int)((UIntPtr)num)] = num2;
                num += 1u;
            }
        }
        public static ushort CRC16(byte[] data, int fromOffset, int length)
        {
            ushort num = 0;
            for (int i = fromOffset; i < length; i++)
            {
                num = (ushort)((int)Checksum.mCRC16Table[(int)((num ^ (ushort)data[i]) & 255)] ^ (num >> 8 & 255));
            }
            return num;
        }
        public static ushort CRC16(IntPtr data, int fromOffset, int length)
        {
            ushort num = 0;
            for (int i = fromOffset; i < length; i++)
            {
                num = (ushort)((int)Checksum.mCRC16Table[(int)((num ^ (ushort)Marshal.ReadByte(data, i)) & 255)] ^ (num >> 8 & 255));
            }
            return num;
        }
        public static byte[] CRC16(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            ushort crc = ushort.MaxValue;

            foreach (byte b in data)
            {
                byte tableIndex = (byte)(crc ^ b);
                crc >>= 8;
                crc ^= mCRC16Table[tableIndex];
            }
            return BitConverter.GetBytes(crc);
        }
        public static byte[] CRC16(byte[] data, int num)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (data.Length < num)
                num = data.Length;
            ushort crc = ushort.MaxValue;
            for (int i = 0; i < num; i++)
            {
                byte tableIndex = (byte)(crc ^ data[i]);
                crc >>= 8;
                crc ^= mCRC16Table[tableIndex];
            }
            return BitConverter.GetBytes(crc);
        }
        public static ushort CRC16CCITT(byte[] data, int fromOffset, int length)
        {
            ushort num = 65535;
            for (int i = fromOffset; i < length; i++)
            {
                ushort num2 = (ushort)(data[i] << 8);
                for (int j = 0; j < 8; j++)
                {
                    num = ((((num ^ num2) & 32768) > 0) ? ((ushort)((int)num << 1 ^ 4129)) : ((ushort)(num << 1)));
                    num2 = (ushort)(num2 << 1);
                }
            }
            return num;
        }
        public static uint CRC32(byte[] data, int fromOffset, int length)
        {
            uint num = 4294967295u;
            uint num2 = (uint)fromOffset;
            while ((ulong)num2 < (ulong)((long)length))
            {
                num = (Checksum.mCRC32Table[(int)((UIntPtr)((num ^ (uint)data[(int)((UIntPtr)num2)]) & 255u))] ^ num >> 8);
                num2 += 1u;
            }
            return num ^ 4294967295u;
        }
        public static uint CRC32(IntPtr data, int fromOffset, int length)
        {
            uint num = 4294967295u;
            uint num2 = (uint)fromOffset;
            while ((ulong)num2 < (ulong)((long)length))
            {
                num = (Checksum.mCRC32Table[(int)((UIntPtr)((num ^ (uint)Marshal.ReadByte(data, (int)((long)fromOffset + (long)((ulong)num2)))) & 255u))] ^ num >> 8);
                num2 += 1u;
            }
            return num ^ 4294967295u;
        }
        public static ushort CRC16CCITT(IntPtr data, int fromOffset, int length)
        {
            ushort num = 65535;
            for (int i = fromOffset; i < length; i++)
            {
                ushort num2 = (ushort)(Marshal.ReadByte(data, i) << 8);
                for (int j = 0; j < 8; j++)
                {
                    num = ((((num ^ num2) & 32768) > 0) ? ((ushort)((int)num << 1 ^ 4129)) : ((ushort)(num << 1)));
                    num2 = (ushort)(num2 << 1);
                }
            }
            return num;
        }
        public static uint BuildCheckSum(ChecksumType type, IntPtr data, int fromOffset, int length)
        {
            uint result;
            switch (type)
            {
                case ChecksumType.ADD_11:
                    {
                        byte b = 0;
                        for (int i = fromOffset; i < length; i++)
                        {
                            b += Marshal.ReadByte(data, i);
                        }
                        result = (uint)b;
                        break;
                    }
                case ChecksumType.ADD_12:
                    {
                        ushort num = 0;
                        for (int j = fromOffset; j < length; j++)
                        {
                            num += (ushort)Marshal.ReadByte(data, j);
                        }
                        result = (uint)num;
                        break;
                    }
                case ChecksumType.ADD_14:
                    {
                        uint num2 = 0u;
                        for (int k = fromOffset; k < length; k++)
                        {
                            num2 += (uint)Marshal.ReadByte(data, k);
                        }
                        result = num2;
                        break;
                    }
                case ChecksumType.CRC_8:
                    result = 0u;
                    break;
                case ChecksumType.CRC_16:
                    result = Checksum.CRC16(data, fromOffset, length);
                    break;
                case ChecksumType.CRC_32:
                    result = Checksum.CRC32(data, fromOffset, length);
                    break;
                case ChecksumType.CRC_2_16:
                    result = 0u;
                    break;
                case ChecksumType.ADD_22:
                    {
                        ushort num = 0;
                        for (int l = fromOffset; l < length; l += 2)
                        {
                            num += (ushort)Marshal.ReadInt16(data, l);
                        }
                        result = (uint)num;
                        break;
                    }
                case ChecksumType.ADD_24:
                    {
                        uint num2 = 0u;
                        for (int m = fromOffset; m < length; m += 2)
                        {
                            num2 += (uint)((ushort)Marshal.ReadInt16(data, m));
                        }
                        result = num2;
                        break;
                    }
                case ChecksumType.ADD_44:
                    {
                        uint num2 = 0u;
                        for (int n = fromOffset; n < length; n += 4)
                        {
                            num2 += (uint)Marshal.ReadInt32(data, n);
                        }
                        result = num2;
                        break;
                    }
                case ChecksumType.USER_DEFINED:
                    result = 0u;
                    break;
                case ChecksumType.CRC_16_CITT:
                    result = (uint)Checksum.CRC16CCITT(data, fromOffset, length);
                    break;
                default:
                    throw new NotSupportedException(type.ToString());
            }
            return result;
        }

    }
    public enum ChecksumType : byte
    {
        NotSet,
        ADD_11,
        ADD_12,
        ADD_14,
        CRC_8,
        CRC_16,
        CRC_32,
        CRC_2_16,
        ADD_22,
        ADD_24,
        ADD_44,
        USER_DEFINED,
        CRC_16_CITT
    }
}
