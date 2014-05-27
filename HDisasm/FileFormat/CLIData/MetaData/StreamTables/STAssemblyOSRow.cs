#region description
/*The AssemblyOS table has the following columns:
• OSPlatformID (a 4-byte constant)
• OSMajorVersion (a 4-byte constant)
• OSMinorVersion (a 4-byte constant)
This record should not be emitted into any PE file. However,if present in a PE file, it shall be treated as if all
its fields were zero. It shall be ignored by the CLI.*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STAssemblyOSRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_OS_PLATFORM_ID = 0UL;
        private static readonly ulong OFFSET_OS_MAJOR_VERSION = 4UL;
        private static readonly ulong OFFSET_OS_MINOR_VERSION = 8UL;

        private uint _osPlatformID;
        private uint _osMajorVersion;
        private uint _osMinorVersion;

        public uint OSPlatformID
        {
            get { return _osPlatformID; }
            private set { _osPlatformID = value; }
        }
        public uint OSMajorVersion
        {
            get { return _osMajorVersion; }
            private set { _osMajorVersion = value; }
        }
        public uint OSMinorVersion
        {
            get { return _osMinorVersion; }
            private set { _osMinorVersion = value; }
        }

        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STAssemblyOSRow(reader, beginOffset, mediator, heapSizes);
        }

        private STAssemblyOSRow()
        { }
        protected STAssemblyOSRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.ASSEMBLY_OS;

            OSPlatformID = reader.getUInt(BEGIN_OFFSET+OFFSET_OS_PLATFORM_ID);
            OSMajorVersion = reader.getUInt(BEGIN_OFFSET + OFFSET_OS_MAJOR_VERSION);
            OSMinorVersion = reader.getUInt(BEGIN_OFFSET + OFFSET_OS_MINOR_VERSION);

            END_OFFSET = BEGIN_OFFSET + OFFSET_OS_MINOR_VERSION + 4;
        }
    }
}
