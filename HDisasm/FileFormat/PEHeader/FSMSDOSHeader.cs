﻿#region description
///MS-DOS header
///The PE format starts with an MS-DOS stub of exactly the following 128 bytes to be placed at the front of the
///module. At offset 0x3c in the DOS header is a 4-byte unsigned integer offset, lfanew, to the PE signature (shall
///be “PE\0\0”), immediately followed by the PE file header.
///0x4d 0x5a 0x90 0x00 0x03 0x00 0x00 0x00
///0x04 0x00 0x00 0x00 0xFF 0xFF 0x00 0x00
///0xb8 0x00 0x00 0x00 0x00 0x00 0x00 0x00
///0x40 0x00 0x00 0x00 0x00 0x00 0x00 0x00
///0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00
///0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00
///0x00 0x00 0x00 0x00 0x00 0x00 0x00 0x00
///0x00 0x00 0x00 0x00 lfanew
///0x0e 0x1f 0xba 0x0e 0x00 0xb4 0x09 0xcd
///0x21 0xb8 0x01 0x4c 0xcd 0x21 0x54 0x68
///0x69 0x73 0x20 0x70 0x72 0x6f 0x67 0x72
///0x61 0x6d 0x20 0x63 0x61 0x6e 0x6e 0x6f
///0x74 0x20 0x62 0x65 0x20 0x72 0x75 0x6e
///0x20 0x69 0x6e 0x20 0x44 0x4f 0x53 0x20
///0x6d 0x6f 0x64 0x65 0x2e 0x0d 0x0d 0x0a
///0x24 0x00 0x00 0x00 0x00 0x00 0x00 0x00
#endregion
namespace PEFileFormat
{
    using System;
    using System.Text;



    /// <summary>
    /// 
    /// </summary>
    public sealed class FSMSDOSHeader : AFileStructure
    {
        #region Constants
        private static readonly long LENGTH_MSDOS_HEADER = 128L;
        private static readonly long OFFSET_LFANEW = 0x3cL;
        #endregion



        #region Fields
        private readonly byte[] _header;
        private readonly uint _lfanew = 0;
        #endregion




        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSMSDOSHeader(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._header = reader.GetRange(beginOffset, LENGTH_MSDOS_HEADER);
            this._lfanew = _header.getUInt(OFFSET_LFANEW);
        }
        #endregion




        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public byte[] Header
        {
            get
            {
                return _header;
            }
        }
        /// <summary>
        /// At offset 0x3c in the DOS header is a 4-byte unsigned integer offset, lfanew, to the PE signature
        /// </summary>
        public uint LFANEW
        {
            get { return _lfanew; }
        }
        #endregion

    }
}
