#region description
/*The AssemblyRefProcessor table has the following columns:
• Processor (a 4-byte constant)
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
    public sealed class STAssemblyRefProcessorRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_PROCESSOR = 0UL;
        private static readonly ulong OFFSET_ASSEMBLY_REF = 4UL;

        private uint _processor;
        private uint _assemblyRef;

        public uint Processor
        {
            get { return _processor; }
            private set { _processor = value; }
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
            return new STAssemblyRefProcessorRow(reader, beginOffset, mediator, heapSizes);
        }

        private STAssemblyRefProcessorRow()
        { }
        protected STAssemblyRefProcessorRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.ASSEMBLY_REF_PROCESSOR;

            Processor = reader.getUInt(BEGIN_OFFSET + OFFSET_PROCESSOR);
            AssemblyRef = reader.getUShort(BEGIN_OFFSET + OFFSET_ASSEMBLY_REF);

            END_OFFSET = BEGIN_OFFSET + OFFSET_ASSEMBLY_REF + 2;
        }
    }
}
