using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace QSHP.Com
{
    [SecuritySafeCritical]
    public static class DataConverter
    {
        public static bool IsLittleEndian = true;
        public static char SpiltChar = ' ';
        public static DataUnion dataUnion = new DataUnion();
        public static object locker = new object();
        [SecuritySafeCritical]
        public static unsafe long DoubleToInt64Bits(double value)
        {
            return *(((long*)&value));
        }

        public static byte[] GetBytes(bool value)
        {
            return new byte[] { (value ? ((byte)1) : ((byte)0)) };
        }

        public static byte[] GetBytes(char value)
        {
            return GetBytes((short)value);
        }

        [SecuritySafeCritical]
        public static unsafe byte[] GetBytes(double value)
        {
            return GetBytes(*((long*)&value));
        }

        [SecuritySafeCritical]
        public static unsafe byte[] GetBytes(short value)
        {
            byte[] buffer1 = new byte[2];
            fixed (byte* numRef = buffer1)
            {
                if (IsLittleEndian)
                {
                    *((short*)numRef) = value;
                }
                else
                {
                    buffer1[1] = (byte)(value & 0xFF);
                    buffer1[0] = (byte)(value >> 8 & 0xFF);
                }
            }
            return buffer1;
        }

        [SecuritySafeCritical]
        public static unsafe byte[] GetBytes(int value)
        {
            byte[] buffer1 = new byte[4];
            fixed (byte* numRef = buffer1)
            {
                if (IsLittleEndian)
                {
                    *((int*)numRef) = value;
                }
                else
                {
                    buffer1[3] = (byte)(value & 0xFF);
                    buffer1[2] = (byte)(value >> 8 & 0xFF);
                    buffer1[1] = (byte)(value >> 16 & 0xFF);
                    buffer1[0] = (byte)(value >> 24 & 0xFF);
                }
            }
            return buffer1;
        }

        [SecuritySafeCritical]
        public static unsafe byte[] GetBytes(long value)
        {
            byte[] buffer1 = new byte[8];
            fixed (byte* numRef = buffer1)
            {
                if (IsLittleEndian)
                {
                    *((long*)numRef) = value;
                }
                else
                {
                    buffer1[7] = (byte)(value & 0xFF);
                    buffer1[6] = (byte)(value >> 8 & 0xFF);
                    buffer1[5] = (byte)(value >> 16 & 0xFF);
                    buffer1[4] = (byte)(value >> 24 & 0xFF);
                    buffer1[3] = (byte)(value >> 32 & 0xFF);
                    buffer1[2] = (byte)(value >> 40 & 0xFF);
                    buffer1[1] = (byte)(value >> 48 & 0xFF);
                    buffer1[0] = (byte)(value >> 56 & 0xFF);
                }
            }
            return buffer1;
        }

        [SecuritySafeCritical]
        public static unsafe byte[] GetBytes(float value)
        {
            return GetBytes(*((int*)&value));
        }

        public static byte[] GetBytes(ushort value)
        {
            return GetBytes((short)value);
        }

        public static byte[] GetBytes(uint value)
        {
            return GetBytes((int)value);
        }

        public static byte[] GetBytes(ulong value)
        {
            return GetBytes((long)value);
        }

        public static char GetHexValue(int i)
        {
            if (i < 10)
            {
                return (char)(i + 0x30);
            }
            return (char)((i - 10) + 0x41);
        }

        [SecuritySafeCritical]
        public static unsafe double Int64BitsToDouble(long value)
        {
            return *(((double*)&value));
        }

        public static bool ToBoolean(byte[] value, int startIndex)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (startIndex > (value.Length - 1))
            {
                throw new IndexOutOfRangeException();
            }
            return (value[startIndex] != 0);
        }

        public static char ToChar(byte[] value, int startIndex)
        {
            return (char)((ushort)ToInt16(value, startIndex));
        }

        [SecuritySafeCritical]
        public static unsafe double ToDouble(byte[] value, int startIndex)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (startIndex > (value.Length - 8))
            {
                throw new IndexOutOfRangeException();
            }
            fixed (byte* numRef = &(value[startIndex]))
            {
                if (IsLittleEndian)
                {
                    return *((double*)numRef);
                }
                return (double)((ulong)((((numRef[0] << 0x18) | (numRef[1] << 0x10)) | (numRef[2] << 8)) | numRef[3]) << 0x20 | (uint)((((numRef[4] << 0x18) | (numRef[5] << 0x10)) | (numRef[6] << 8)) | numRef[7]));
            }
        }

        [SecuritySafeCritical]
        public static unsafe short ToInt16(byte[] value, int startIndex)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (startIndex > (value.Length - 2))
            {
                throw new IndexOutOfRangeException();
            }
            fixed (byte* numRef = &(value[startIndex]))
            {
                if (IsLittleEndian)
                {
                    return *(short*)numRef;
                }
                return (short)((numRef[0] << 8) | numRef[1]);
            }
        }

        [SecuritySafeCritical]
        public static unsafe int ToInt32(byte[] value, int startIndex)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (startIndex > (value.Length - 4))
            {
                throw new IndexOutOfRangeException();
            }
            fixed (byte* numRef = &(value[startIndex]))
            {
                if (IsLittleEndian)
                {
                    return *(int*)numRef;
                }
                return ((((numRef[0] << 0x18) | (numRef[1] << 0x10)) | (numRef[2] << 8)) | numRef[3]);
            }
        }

        [SecuritySafeCritical]
        public static unsafe long ToInt64(byte[] value, int startIndex)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (startIndex > (value.Length - 8))
            {
                throw new IndexOutOfRangeException();
            }
            fixed (byte* numRef = &(value[startIndex]))
            {
                if (IsLittleEndian)
                {
                    return *((long*)numRef);
                }
                return (long)((ulong)((((numRef[0] << 0x18) | (numRef[1] << 0x10)) | (numRef[2] << 8)) | numRef[3]) << 0x20 | (uint)((((numRef[4] << 0x18) | (numRef[5] << 0x10)) | (numRef[6] << 8)) | numRef[7]));
            }
        }

        [SecuritySafeCritical]
        public static unsafe Single ToSingle(byte[] value, int startIndex)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (startIndex > (value.Length - 4))
            {
                throw new IndexOutOfRangeException();
            }
            fixed (byte* numRef = &(value[startIndex]))
            {
                if (IsLittleEndian)
                {
                    return *((float*)numRef);
                }
                return (Single)((((numRef[4] << 0x18) | (numRef[5] << 0x10)) | (numRef[6] << 8)) | numRef[7]);
            }
        }

        [SecuritySafeCritical]
        public static unsafe void Reverse(byte[] value, int startIndex, int lenth)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (startIndex > (value.Length - lenth))
            {
                throw new IndexOutOfRangeException();
            }
            byte[] data = new byte[lenth];
            Buffer.BlockCopy(value, startIndex, data, 0, lenth);
            int len = lenth - 1;
            fixed (byte* numRef = &(value[startIndex]))
            {
                for (int i = 0; i < lenth; i++)
                {
                    numRef[i] = data[len - i];
                }
            }
        }

        public static string ToString(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            return ToString(value, 0, value.Length);
        }

        public static string ToString(byte[] value, int startIndex)
        {
            return ToString(value, startIndex, value.Length - startIndex);
        }

        public static string ToString(byte[] value, int startIndex, int length)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (startIndex > (value.Length - length))
            {
                throw new IndexOutOfRangeException();
            }
            if (length == 0)
            {
                return string.Empty;
            }
            int num = length * 3;
            char[] chArray = new char[num];
            if (IsLittleEndian)
            {
                int num3 = startIndex;
                for (int index = 0; index < num; index += 3)
                {
                    byte num4 = value[num3++];
                    chArray[index] = GetHexValue(num4 / 0x10);
                    chArray[index + 1] = GetHexValue(num4 % 0x10);
                    chArray[index + 2] = SpiltChar;
                }
            }
            else
            {
                int num3 = startIndex + length;
                for (int index = 0; index < num; index += 3)
                {
                    byte num4 = value[--num3];
                    chArray[index] = GetHexValue(num4 / 0x10);
                    chArray[index + 1] = GetHexValue(num4 % 0x10);
                    chArray[index + 2] = SpiltChar;
                }
            }
            return new string(chArray, 0, chArray.Length - 1);
        }

        public static ushort ToUInt16(byte[] value, int startIndex)
        {
            return (ushort)ToInt16(value, startIndex);
        }

        public static uint ToUInt32(byte[] value, int startIndex)
        {
            return (uint)ToInt32(value, startIndex);
        }

        public static ulong ToUInt64(byte[] value, int startIndex)
        {
            return (ulong)ToInt64(value, startIndex);
        }

        public static string ToHexString(this byte[] value)
        {
            int num = value.Length * 3;
            char[] chArray = new char[num];
            int num3 = 0;
            for (int index = 0; index < num; index += 3)
            {
                byte num4 = value[num3++];
                chArray[index] = GetHexValue(num4 / 0x10);
                chArray[index + 1] = GetHexValue(num4 % 0x10);
                chArray[index + 2] = SpiltChar;
            }
            return new string(chArray, 0, chArray.Length - 1);
        }
        public static UInt64 ToBigEndian(this UInt64 data)
        {
            lock (locker)
            {
                dataUnion.B0 = (byte)(data >> 56 & 0xFF);
                dataUnion.B1 = (byte)(data >> 48 & 0xFF);
                dataUnion.B2 = (byte)(data >> 40 & 0xFF);
                dataUnion.B3 = (byte)(data >> 32 & 0xFF);
                dataUnion.B4 = (byte)(data >> 24 & 0xFF);
                dataUnion.B5 = (byte)(data >> 16 & 0xFF);
                dataUnion.B6 = (byte)(data >> 8 & 0xFF);
                dataUnion.B7 = (byte)(data & 0xFF);
            }
            return dataUnion.UL0;
        }
        public static Int64 ToBigEndian(this Int64 data)
        {
            lock (locker)
            {
                dataUnion.B0 = (byte)(data >> 56 & 0xFF);
                dataUnion.B1 = (byte)(data >> 48 & 0xFF);
                dataUnion.B2 = (byte)(data >> 40 & 0xFF);
                dataUnion.B3 = (byte)(data >> 32 & 0xFF);
                dataUnion.B4 = (byte)(data >> 24 & 0xFF);
                dataUnion.B5 = (byte)(data >> 16 & 0xFF);
                dataUnion.B6 = (byte)(data >> 8 & 0xFF);
                dataUnion.B7 = (byte)(data & 0xFF);
            }
            return dataUnion.L0;
        }
        public static UInt32 ToBigEndian(this UInt32 data)
        {
            lock (locker)
            {
                dataUnion.B4 = (byte)(data >> 24 & 0xFF);
                dataUnion.B5 = (byte)(data >> 16 & 0xFF);
                dataUnion.B6 = (byte)(data >> 8 & 0xFF);
                dataUnion.B7 = (byte)(data & 0xFF);
            }
            return dataUnion.U1;
        }
        public static Int32 ToBigEndian(this Int32 data)
        {
            lock (locker)
            {
                dataUnion.B4 = (byte)(data >> 24 & 0xFF);
                dataUnion.B5 = (byte)(data >> 16 & 0xFF);
                dataUnion.B6 = (byte)(data >> 8 & 0xFF);
                dataUnion.B7 = (byte)(data & 0xFF);
            }
            return dataUnion.I1;
        }
        public static float ToBigEndian(this float data)
        {
            lock (locker)
            {
                dataUnion.F0 = data;
                dataUnion.B4 = dataUnion.B3;
                dataUnion.B5 = dataUnion.B2;
                dataUnion.B6 = dataUnion.B1;
                dataUnion.B7 = dataUnion.B0;
            }
            return dataUnion.I1;
        }
        public static double ToBigEndian(this double data)
        {
            lock (locker)
            {
                DataUnion p = new DataUnion();
                p.D0 = data;
                dataUnion.B0 = p.B7;
                dataUnion.B1 = p.B6;
                dataUnion.B2 = p.B5;
                dataUnion.B3 = p.B4;
                dataUnion.B4 = p.B3;
                dataUnion.B5 = p.B2;
                dataUnion.B6 = p.B1;
                dataUnion.B7 = p.B0;
            }
            return dataUnion.D0;
        }
        public static Int16 ToBigEndian(this Int16 data)
        {
            lock (locker)
            {
                dataUnion.B6 = (byte)(data >> 8 & 0xFF);
                dataUnion.B7 = (byte)(data & 0xFF);
            }
            return dataUnion.S3;
        }
        public static UInt16 ToBigEndian(this UInt16 data)
        {
            lock (locker)
            {
                dataUnion.B6 = (byte)(data >> 8 & 0xFF);
                dataUnion.B7 = (byte)(data & 0xFF);
            }
            return dataUnion.W3;
        }
        public static byte ToBigEndian(this byte data)
        {
            return data;
        }

        public static bool Bit(this uint data, int index)
        {
            if (index < 0 && index > 31)
            {
                return false;
            }
            return (data >> index & 1) > 0;
        }
        public static uint Bit(this uint data, int index,bool enable)
        {
            if (index < 0 && index > 31)
            {
                return data;
            }
            if (enable)
            {
                data |= (1U << index);
                return data;
            }
            else
            {
                data &= ~(1U << index);
                return data;
            }
        }

        public static bool Bit(this int data, int index)
        {
            if (index < 0 && index > 31)
            {
                return false;
            }
            return (data >> index & 1) > 0;
        }
        public static int Bit(this int data, int index, bool enable)
        {
            if (index < 0 && index > 31)
            {
                return data;
            }
            if (enable)
            {
                data |= (1 << index);
                return data;
            }
            else
            {
                data &= ~(1 << index);
                return data;
            }
        }
        public static bool Bit(this byte data, int index)
        {
            if (index < 0 && index > 7)
            {
                return false;
            }
            return (data >> index & 1) > 0;
        }
        public static byte Bit(this byte data, int index, bool enable)
        {
            if (index < 0 && index > 7)
            {
                return data;
            }
            if (enable)
            {
                data |= (byte)(1 << index);
                return data;
            }
            else
            {
                data &= (byte)~(1 << index);
                return data;
            }
        }
        public static bool Bit(this UInt16 data, int index)
        {
            if (index < 0 && index > 15)
            {
                return false;
            }
            return (data >> index & 1) > 0;
        }
        public static UInt16 Bit(this UInt16 data, int index, bool enable)
        {
            if (index < 0 && index > 15)
            {
                return data;
            }
            if (enable)
            {
                data |= (UInt16)(1 << index);
                return data;
            }
            else
            {
                data &= (UInt16)~(1 << index);
                return data;
            }
        }

        public static bool Bit(this Int16 data, int index)
        {
            if (index < 0 && index > 15)
            {
                return false;
            }
            return (data >> index & 1) > 0;
        }
        public static Int16 Bit(this Int16 data, int index, bool enable)
        {
            if (index < 0 && index > 15)
            {
                return data;
            }
            if (enable)
            {
                data |= (Int16)(1 << index);
                return data;
            }
            else
            {
                data &= (Int16)~(1 << index);
                return data;
            }
        }

        public static bool Bit(this ulong data, int index)
        {
            if (index < 0 && index > 15)
            {
                return false;
            }
            return (data >> index & 1) > 0;
        }
        public static ulong Bit(this ulong data, int index, bool enable)
        {
            if (index < 0 && index > 63)
            {
                return data;
            }
            if (enable)
            {
                data |= (ulong)(1U << index);
                return data;
            }
            else
            {
                data &= (ulong)~(1U << index);
                return data;
            }
        }

        public static bool Bit(this long data, int index)
        {
            if (index < 0 && index > 63)
            {
                return false;
            }
            return (data >> index & 1) > 0;
        }
        public static long Bit(this long data, int index, bool enable)
        {
            if (index < 0 && index > 63)
            {
                return data;
            }
            if (enable)
            {
                data |= (long)(1U << index);
                return data;
            }
            else
            {
                data &= (long)~(1U << index);
                return data;
            }
        }

    }
    [StructLayout(LayoutKind.Explicit, Size = 8, CharSet = CharSet.Ansi), SecuritySafeCritical]
    public class DataUnion
    {
        [DefaultValue(0)]
        [FieldOffset(0)]
        public byte B0;
        [FieldOffset(1)]
        public byte B1;
        [FieldOffset(2)]
        public byte B2;
        [FieldOffset(3)]
        public byte B3;
        [FieldOffset(4)]
        public byte B4;
        [FieldOffset(5)]
        public byte B5;
        [FieldOffset(6)]
        public byte B6;
        [FieldOffset(7)]
        public byte B7;
        [FieldOffset(0)]
        public UInt16 W0;
        [FieldOffset(2)]
        public UInt16 W1;
        [FieldOffset(4)]
        public UInt16 W2;
        [FieldOffset(6)]
        public UInt16 W3;
        [FieldOffset(0)]
        public Int16 S0;
        [FieldOffset(2)]
        public Int16 S1;
        [FieldOffset(4)]
        public Int16 S2;
        [FieldOffset(6)]
        public Int16 S3;
        [FieldOffset(0)]
        public UInt32 U0;
        [FieldOffset(4)]
        public UInt32 U1;
        [FieldOffset(0)]
        public Int32 I0;
        [FieldOffset(4)]
        public Int32 I1;
        [FieldOffset(0)]
        public float F0;
        [FieldOffset(4)]
        public float F1;
        [FieldOffset(0)]
        public Int64 L0;
        [FieldOffset(0)]
        public UInt64 UL0;
        [FieldOffset(0)]
        public double D0;
        [SecuritySafeCritical]
        public unsafe byte[] GetBytes()
        {
            byte[] buffer = new byte[8];
            fixed (byte* ptr = buffer)
            {
                *((ulong*)ptr) = this.UL0;
            }
            return buffer;
        }
        [SecuritySafeCritical]
        public unsafe void SetBytes(byte[] data)
        {
            fixed (byte* ptr = data)
            {
                this.UL0 = *(UInt64*)ptr;
            }
        }
        public unsafe byte this[int index]
        {
            get
            {
                fixed (byte* ptr = &this.B0)
                {
                    return ptr[index];
                }
            }
            set
            {
                fixed (byte* ptr = &this.B0)
                {
                    ptr[index] = value;
                }
            }
        }
        //public static bool operator !=(DataUnion left, DataUnion right)
        //{
        //    return left.UL0 != right.UL0;
        //}

        public static bool operator <(DataUnion left, DataUnion right)
        {
            return left.UL0 < right.UL0;
        }
        public static bool operator <=(DataUnion left, DataUnion right)
        {
            return left.UL0 <= right.UL0;
        }
        //public static bool operator ==(DataUnion left, DataUnion right)
        //{
        //    return left.UL0 == right.UL0;
        //}
        public static bool operator >(DataUnion left, DataUnion right)
        {
            return left.UL0 > right.UL0;
        }
        public static bool operator >=(DataUnion left, DataUnion right)
        {
            return left.UL0 >= right.UL0;
        }
        public static DataUnion operator ^(DataUnion left, DataUnion right)
        {
            DataUnion data = new DataUnion();
            data.UL0 = left.UL0 ^ right.UL0;
            return data;
        }
        public static DataUnion operator |(DataUnion left, DataUnion right)
        {
            DataUnion data = new DataUnion();
            data.UL0 = left.UL0 | right.UL0;
            return data;
        }
        public static DataUnion operator &(DataUnion left, DataUnion right)
        {
            DataUnion data = new DataUnion();
            data.UL0 = left.UL0 & right.UL0;
            return data;
        }
        public static DataUnion operator ~(DataUnion left)
        {
            DataUnion data = new DataUnion();
            data.UL0 = ~left.UL0;
            return data;
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 4, CharSet = CharSet.Ansi), SecuritySafeCritical]
    public class DataUnion32
    {
        [DefaultValue(0)]
        [FieldOffset(0)]
        public byte B0;
        [FieldOffset(1)]
        public byte B1;
        [FieldOffset(2)]
        public byte B2;
        [FieldOffset(3)]
        public byte B3;

        [FieldOffset(0)]
        public UInt16 W0;
        [FieldOffset(2)]
        public UInt16 W1;

        [FieldOffset(0)]
        public Int16 S0;
        [FieldOffset(2)]
        public Int16 S1;

        [FieldOffset(0)]
        public UInt32 U0;

        [FieldOffset(0)]
        public Int32 I0;

        [FieldOffset(0)]
        public float F0;
        

        public DataUnion32()
        {
        }
        public DataUnion32(float value)
        {
            F0 = value;
        }
        public DataUnion32(int value)
        {
            I0 = value;
        }
        public DataUnion32(UInt32 value)
        {
            U0 = value;
        }
        public unsafe byte[] GetBytes()
        {
            byte[] buffer = new byte[4];
            fixed (byte* ptr = buffer)
            {
                *((uint*)ptr) = this.U0;
            }
            return buffer;
        }
        [SecuritySafeCritical]
        public unsafe void SetBytes(byte[] data)
        {
            fixed (byte* ptr = data)
            {
                this.U0 = *(UInt32*)ptr;
            }
        }

        public unsafe byte this[int i]
        {
            get
            {
                byte v = 0;
                fixed (byte* ptr = &B0)
                {
                    v = *(ptr + i);
                }
                return v;
            }
            set
            {
                fixed (byte* ptr = &B0)
                {
                    *(ptr + i) = value;
                }
            }
        }
    }


}
