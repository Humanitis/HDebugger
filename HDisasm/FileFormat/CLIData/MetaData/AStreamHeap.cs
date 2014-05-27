using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public abstract class AStreamHeap : AFileStructure
    {
        private static readonly ulong OFFSET_OFFSET = 0UL;
        private static readonly ulong OFFSET_SIZE = 4UL;
        public static readonly ulong OFFSET_NAME = 8UL;

        private uint _offset;
        private ulong _offsetFromMetaData;
        private uint _size;
        private string _name;

        /// <summary>
        /// Memory offset to start of this stream from start of the
        ///metadata root
        /// </summary>
        public uint Offset { get { return _offset; } private set { _offset=value;} }
        public ulong OffsetFromMetaData { get { return _offsetFromMetaData; } private set { _offsetFromMetaData = value; } }
        /// <summary>
        /// Size of this stream in bytes, shall be a multiple of 4.
        /// </summary>
        public uint Size { get { return _size; } private set{ _size=value;} }
        /// <summary>
        /// Name of the stream as null-terminated variable length array
        ///of ASCII characters, padded to the next 4-byte boundary
        ///with \0 characters. The name is limited to 32 characters.
        /// </summary>
        public string Name { get { return _name; } private set{ _name=value;} }

        /// <summary>
        /// Build StreamHeap.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        /// <param name="offsetFromMetaData"></param>
        /// <param name="mediator"></param>
        /// <param name="name">name of heap</param>
        /// <returns></returns>
        public static AStreamHeap BuidStreamHeap(byte[] reader, ulong beginOffset, ulong offsetFromMetaData, AFileFormatMediator mediator, string name)
        {
            switch (name)
            {
                case "#Strings": return new SHString(reader, beginOffset, offsetFromMetaData, mediator);
                case "#GUID": return new SHGuid(reader, beginOffset, offsetFromMetaData, mediator);
                case "#Blob": return new SHBlob(reader, beginOffset, offsetFromMetaData, mediator);
                case "#US": return new SHUserString(reader, beginOffset, offsetFromMetaData, mediator);
                case "#~": return new SHStream(reader, beginOffset, offsetFromMetaData, mediator);
                default: throw new NotImplementedException();
            }
        }

        protected void OffsetSizeSctualDataInBlobHeap(byte[] reader, int beginOffset, ref int offsetActualData, ref int countByte)
        {
            if ((reader[beginOffset] & 0x80) == 0)
            {
                offsetActualData = 1;
                countByte = reader[beginOffset];
            }
            else
            {
                if ((reader[beginOffset] & 0x40) == 0)
                {
                    offsetActualData = 2;
                    countByte = ((reader[beginOffset] & 0x3F) << 8) + reader[beginOffset + 1];
                }
                else
                {
                    offsetActualData = 4;
                    countByte = ((reader[beginOffset] & 0x1F) << 24) +
                        (reader[beginOffset + 1] << 16) +
                        (reader[beginOffset + 2] << 8) +
                        reader[beginOffset + 3];
                }
            }
        }

        protected AStreamHeap()
        { }
        public AStreamHeap(byte[] reader, ulong beginOffset,ulong offsetFromMetaData, AFileFormatMediator mediator)
            : base(reader, beginOffset, mediator)
        {
            Offset = reader.getUInt(BEGIN_OFFSET + OFFSET_OFFSET);
            OffsetFromMetaData = Offset + offsetFromMetaData;
            Size = reader.getUInt(BEGIN_OFFSET + OFFSET_SIZE);
            Name = reader.getStringWithNullEnd(BEGIN_OFFSET + OFFSET_NAME);
            END_OFFSET = (BEGIN_OFFSET + OFFSET_NAME + (ulong)Name.Length + 1UL).BoundaryToMerge4Byte();
        }
    }
}
