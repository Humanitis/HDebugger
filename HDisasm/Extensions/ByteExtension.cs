namespace PEFileFormat
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;





    /// <summary>
    /// 
    /// </summary>
    public static class ByteExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int getInt(this byte[] arr, long offset)
        {
            return (int)arr.getValue(offset, 4, 4);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int getInt(this byte[] arr, long offset, long count)
        {
            return (int)arr.getValue(offset, count, 4);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static long getLong(this byte[] arr, long offset)
        {
            return (long)arr.getValue(offset, 8, 8);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static long getLong(this byte[] arr, long offset, long count)
        {
            return (long)arr.getValue(offset, count, 8);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] GetRange(this byte[] arr, long startIndex, long length)
        {
            byte[] result = new byte[length];

            for (long index = 0; index < length; ++index)
                result[index] = arr[startIndex + index];

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static short getShort(this byte[] arr, long offset)
        {
            return (short)arr.getValue(offset, 2, 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static short getShort(this byte[] arr, long offset, long count)
        {
            return (short)arr.getValue(offset, count, 2);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static ulong getValue(this byte[] arr, long offset, long count, long size)
        {
            if (offset < 0 || size < 0 || count > size || count < 0)
                throw new ArgumentException();
            if (arr.LongLength <= offset - count)
                throw new ArgumentOutOfRangeException();
            ulong result = 0;
            while (count-- != 0)
            {
                result |= (ulong)arr[offset + count] << (8 * (int)count);
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static uint getUInt(this byte[] arr, long offset)
        {
            return (uint)arr.getValue(offset, 4, 4);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static uint getUInt(this byte[] arr, long offset, long count)
        {
            return (uint)arr.getValue(offset, count, 4);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ulong getULong(this byte[] arr, long offset)
        {
            return (ulong)arr.getValue(offset, 8, 8);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static ulong getULong(this byte[] arr, long offset, long count)
        {
            return (ulong)arr.getValue(offset, count, 8);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static ushort getUShort(this byte[] arr, long offset)
        {
            return (ushort)arr.getValue(offset, 2, 2);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static ushort getUShort(this byte[] arr, long offset, long count)
        {
            return (ushort)arr.getValue(offset, count, 2);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string getString(this byte[] arr, long offset, long count)
        {
            if (offset < 0 || count < 0)
                throw new ArgumentException();
            if (arr.LongLength <= offset - count)
                throw new ArgumentOutOfRangeException();

            StringBuilder result = new StringBuilder((int)count);
            for (long index = 0; index < count; ++index)
            {
                result.Append((char)arr[index + offset]);
            }
            return result.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string getStringEx(this byte[] arr, long offset, long count)
        {
            if (offset < 0 || count < 0)
                throw new ArgumentException();
            if (arr.LongLength <= offset - count)
                throw new ArgumentOutOfRangeException();

            StringBuilder result = new StringBuilder((int)count);
            count *= 2;
            for (long index = 0; index < count; index += 2)
            {
                result.Append((char)((arr[index + offset + 1] << 8) + arr[index + offset]));
            }
            return result.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static string getStringWithNullEnd(this byte[] arr, long offset)
        {
            Debug.Assert(offset >= 0, "offset < 0");
            Debug.Assert(arr.LongLength > offset, "arr.LongLength <= offset");

            StringBuilder result = new StringBuilder();
            long stop = arr.LongLength;
            while (offset < stop && arr[offset] != 0)
            {
                result.Append((char)arr[offset++]);
            }
            return result.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static string getStringWithNullEndEx(this byte[] arr, ulong offset)
        {
            if (offset < 0)
                throw new ArgumentException();
            if ((ulong)arr.Length <= offset)
                throw new ArgumentOutOfRangeException();

            StringBuilder result = new StringBuilder();
            ulong stop = (ulong)arr.Length;
            while (offset < stop && !(arr[offset] == 0 && arr[offset + 1] == 0))
            {
                result.Append((char)((arr[offset] << 8) + arr[offset + 1]));
                offset += 2;
            }
            return result.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="fndBA"></param>
        /// <param name="startOffset"></param>
        /// <returns></returns>
        public static long FindByteArray(this byte[] arr, byte[] fndBA, long startOffset)
        {
            if (fndBA.LongLength == 0 || arr.LongLength < fndBA.LongLength || (arr.Length - fndBA.LongLength) < startOffset)
                throw new ArgumentException();
            long result = startOffset;
            long stopSearch = arr.LongLength - fndBA.LongLength;
            for (long strIndex = 0; result < stopSearch; ++result)
            {
                if (fndBA[0] == arr[result])
                {
                    for (strIndex = 1; strIndex < fndBA.Length; ++strIndex)
                    {
                        if (fndBA[strIndex] != arr[result + strIndex])
                        {
                            strIndex = 0;
                            break;
                        }
                    }
                    if (strIndex != 0)
                        return result;
                }
            }
            return -1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="fndStr"></param>
        /// <param name="startOffset"></param>
        /// <returns></returns>
        public static long FindString(this byte[] arr, string fndStr, long startOffset)
        {
            if (fndStr.Length == 0 || arr.LongLength < fndStr.Length || (arr.LongLength - fndStr.LongLength) < startOffset)
                throw new ArgumentException();
            long result = startOffset;
            long stopSearch = arr.Length - fndStr.Length;
            for (int strIndex = 0; result < stopSearch; ++result)
            {
                if (fndStr[0] == (char)arr[result])
                {
                    for (strIndex = 1; strIndex < fndStr.Length; ++strIndex)
                    {
                        if (fndStr[strIndex] != (char)arr[result + strIndex])
                        {
                            strIndex = 0;
                            break;
                        }
                    }
                    if (strIndex != 0)
                        return result;
                }
            }
            return -1;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bt"></param>
        /// <returns></returns>
        public static string toHex(this byte bt)
        {
            byte major = (byte)(bt / 16);
            byte minor = (byte)(bt % 16);
            char hex = (char)55;
            return (major > 9 ? ((char)(major + hex)).ToString() : major.ToString()) + (minor > 9 ? ((char)(minor + hex)).ToString() : minor.ToString());
        }
    }
}
