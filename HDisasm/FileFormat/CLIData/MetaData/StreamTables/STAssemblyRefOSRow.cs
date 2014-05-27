#region description
/*The AssemblyRefOS table has the following columns:
• OSPlatformId (a 4-byte constant)
• OSMajorVersion (a 4-byte constant)
• OSMinorVersion (a 4-byte constant)
• AssemblyRef (an index into the AssemblyRef table)
These records should not be emitted into any PE file. However, if present in a PE file, they should be treated
as-if their fields were zero. They should be ignored by the CLI.*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STAssemblyRefOSRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_OS_PLATFORM_ID = 0UL;
        private static readonly ulong OFFSET_OS_MAJOR_VERSION = 4UL;
        private static readonly ulong OFFSET_OS_MINOR_VERSION = 8UL;
        private static readonly ulong OFFSET_ASSEMBLY_REF = 12UL;

        private uint _osPlatformID;
        private uint _osMajorVersion;
        private uint _osMinorVersion;
        private uint _assemblyRef;

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
        /// <summary>
        /// an index into the AssemblyRef table
        /// </summary>
        public uint AssemblyRef
        {
            get { return _assemblyRef; }
            set { _assemblyRef = value; }
        }

        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STAssemblyRefOSRow(reader, beginOffset, mediator, heapSizes);
        }

        private STAssemblyRefOSRow()
        { }
        protected STAssemblyRefOSRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.ASSEMBLY_REF_OS;

            OSPlatformID = reader.getUInt(BEGIN_OFFSET + OFFSET_OS_PLATFORM_ID);
            OSMajorVersion = reader.getUInt(BEGIN_OFFSET + OFFSET_OS_MAJOR_VERSION);
            OSMinorVersion = reader.getUInt(BEGIN_OFFSET + OFFSET_OS_MINOR_VERSION);
            AssemblyRef = reader.getUShort(BEGIN_OFFSET + OFFSET_ASSEMBLY_REF);

            END_OFFSET = BEGIN_OFFSET + OFFSET_ASSEMBLY_REF + 2;
        }
    }
}
