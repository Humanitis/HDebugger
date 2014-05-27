#region description
/*The AssemblyProcessor table has the following column:
• Processor (a 4-byte constant)
This record should not be emitted into any PE file. However, if present in a PE file, it should be treated as if its
field were zero. It should be ignored by the CLI.*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STAssemblyProcessorRow: AStreamTableRow
    {
        private static readonly ulong OFFSET_PROCESSOR = 0UL;

        private uint _processor;

        public uint Processor
        {
            get { return _processor; }
            private set { _processor = value; }
        }

        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STAssemblyProcessorRow(reader, beginOffset, mediator, heapSizes);
        }

        private STAssemblyProcessorRow()
        { }
        protected STAssemblyProcessorRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.ASSEMBLY_PROCESSOR;

            Processor = reader.getUInt(BEGIN_OFFSET + OFFSET_PROCESSOR);

            END_OFFSET = BEGIN_OFFSET + OFFSET_PROCESSOR + 4;
        }
    }
}
