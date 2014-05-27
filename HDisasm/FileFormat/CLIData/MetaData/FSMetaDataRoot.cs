#region description
///The root of the physical metadata starts with a magic signature, several bytes of version and other
///miscellaneous information, followed by a count and an array of stream headers, one for each stream that is
///present. The actual encoded tables and heaps are stored in the streams, which immediately follow this array of
///headers.
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class FSMetaDataRoot : AFileStructure
    {
        private static readonly uint ALWAYS_SIGNATURE = 0x424A5342;
        private static readonly ushort ALWAYS_MAJOR_VERSION = 1;
        private static readonly ushort ALWAYS_MINOR_VERSION = 1;
        private static readonly uint ALWAYS_RESERVED = 0;
        //private static readonly ulong ALWAYS_LENGTH = 12UL;
        //private static readonly ulong ALWAYS_VERSION = 16UL;
        private static readonly ushort ALWAYS_FLAGS = 0;
        //private static readonly ulong ALWAYS_STREAMS = 18UL;
        //private static readonly ulong ALWAYS_STREAM_HEADERS = 20UL;

        private static readonly ulong OFFSET_SIGNATURE = 0UL;
        private static readonly ulong OFFSET_MAJOR_VERSION = 4UL;
        private static readonly ulong OFFSET_MINOR_VERSION = 6UL;
        private static readonly ulong OFFSET_RESERVED = 8UL;
        private static readonly ulong OFFSET_LENGTH = 12UL;
        private static readonly ulong OFFSET_VERSION = 16UL;
        private static readonly ulong OFFSET_FLAGS = 0UL;
        private static readonly ulong OFFSET_STREAMS = 2UL;
        private static readonly ulong OFFSET_STREAM_HEADERS = 4UL;

        private uint _signature;
        private ushort _majorVersion;
        private ushort _minorVersion;
        private uint _reserved;
        private ushort _length;
        private string _version;
        private ushort _flags;
        private ushort _streams;
        private FSStreamHeader _streamHeaders;

        /// <summary>
        /// Magic signature for physical metadata : 0x424A5342.
        /// </summary>
        public uint Signature
        {
            get { return _signature; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_SIGNATURE, "Signature");
                _signature = value;
            }
        }
        /// <summary>
        /// Major version, 1 (ignore on read)
        /// </summary>
        public ushort MajorVersion
        {
            get { return _majorVersion; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_MAJOR_VERSION, "MajorVersion");
                _majorVersion = value;
            }
        }
        /// <summary>
        /// Minor version, 1 (ignore on read)
        /// </summary>
        public ushort MinorVersion
        {
            get { return _minorVersion; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_MINOR_VERSION, "MinorVersion");
                _minorVersion = value;
            }
        }
        /// <summary>
        /// Reserved, always 0
        /// </summary>
        public uint Reserved
        {
            get { return _reserved; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_RESERVED, "Reserved");
                _reserved = value;
            }
        }
        /// <summary>
        /// Length of version string in bytes, say m less or equal  255, rounded
        /// up to a multiple of four.
        /// </summary>
        public ushort Length
        {
            get { return _length; }
            private set { _length = value; }
        }
        /// <summary>
        /// UTF8-encoded version string of length m (see below)
        /// </summary>
        public string Version
        {
            get { return _version; }
            private set { _version = value; }
        }
        /// <summary>
        /// Reserved, always 0
        /// </summary>
        public ushort Flags
        {
            get { return _flags; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_FLAGS, "Flags");
                _flags = value;
            }
        }
        /// <summary>
        /// Number of streams, say n.
        /// </summary>
        public ushort Streams
        {
            get { return _streams; }
            private set { _streams = value; }
        }
        /// <summary>
        /// Array of n StreamHdr structures.
        /// </summary>
        public FSStreamHeader StreamHeaders
        {
            get { return _streamHeaders; }
            private set { _streamHeaders = value; }
        }

        private FSMetaDataRoot()
        { }
        public FSMetaDataRoot(byte[] reader, ulong beginOffset, AFileFormatMediator mediator)
            : base(reader, beginOffset, mediator)
        {
            Signature = reader.getUInt(BEGIN_OFFSET + OFFSET_SIGNATURE);
            MajorVersion = reader.getUShort(BEGIN_OFFSET + OFFSET_MAJOR_VERSION);
            MinorVersion = reader.getUShort(BEGIN_OFFSET + OFFSET_MINOR_VERSION);
            Reserved = reader.getUInt(BEGIN_OFFSET + OFFSET_RESERVED);
            Length = reader.getUShort(BEGIN_OFFSET + OFFSET_LENGTH);
            Version = reader.getString(BEGIN_OFFSET + OFFSET_VERSION, Length);
            //Padding to next 4 byte boundary, say x.
            ulong padding = (BEGIN_OFFSET + OFFSET_VERSION + Length).BoundaryToMerge4Byte(); //(ulong)Math.Ceiling((double)(BEGIN_OFFSET + OFFSET_VERSION + Length) / 4) * 4;
            Flags = reader.getUShort(OFFSET_FLAGS + padding);
            Streams = reader.getUShort(OFFSET_STREAMS + padding);
            StreamHeaders = new FSStreamHeader(reader, OFFSET_STREAM_HEADERS + padding, mediator, Streams, BEGIN_OFFSET);
            END_OFFSET = StreamHeaders.END_OFFSET;
        }


    }
}
