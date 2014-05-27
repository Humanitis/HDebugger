#region description
/*
ManifestResource : 0x28
 * 
 * 
The ManifestResource table has the following columns:
• Offset (a 4-byte constant)
• Flags (a 4-byte bitmask of type ManifestResourceAttributes, §23.1.9)
• Name (an index into the String heap)
• Implementation (an index into a File table, a AssemblyRef table, or null; more precisely, an
Implementation (§24.2.6) coded index)
The Offset specifies the byte offset within the referenced file at which this resource record begins. The
Implementation specifies which file holds this resource. The rows in the table result from .mresource
directives on the Assembly (§6.2.2).

 * 
 * 
1. The ManifestResource table can contain zero or more rows
2. Offset shall be a valid offset into the target file, starting from the Resource entry in the CLI
header [ERROR]
3. Flags shall have only those values set that are specified [ERROR]
4. The VisibilityMask (§23.1.9) subfield of Flags shall be one of Public or Private [ERROR]
5. Name shall index a non-empty string in the String heap [ERROR]
6. Implementation can be null or non-null (if null, it means the resource is stored in the current file)
7. If Implementation is null, then Offset shall be a valid offset in the current file, starting from the
Resource entry in the CLI header [ERROR]
8. If Implementation is non-null, then it shall index a valid row in the File or AssemblyRef table
[ERROR]
9. There shall be no duplicate rows, based upon Name [ERROR]
10. If the resource is an index into the File table, Offset shall be zero [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STManifestResourceRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_OFFSET = 0UL;
        private static readonly ulong OFFSET_FLAGS = 4UL;
        private static readonly ulong OFFSET_NAME = 8UL;
        private static readonly ulong OFFSET_IMPLEMENTATION = 8UL;

        private uint _offset;
        private ManifestResourceAttributesFlag _flags;
        private uint _name;
        private ushort _implementation;
        private ImplementationTag _implementationTable;


        public uint Offset
        {
            get { return _offset; }
            private set { _offset = value; }
        }
        public ManifestResourceAttributesFlag Flags
        {
            get { return _flags; }
            private set { _flags = value; }
        }
        public uint Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public ushort Implementation
        {
            get { return _implementation; }
            private set { _implementation = value; _implementationTable = (ImplementationTag)(_implementation >> 14); }
        }
        public ImplementationTag ImplementationTable
        {
            get { return _implementationTable; }
        }


        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STManifestResourceRow(reader, beginOffset, mediator, heapSizes);
        }

        private STManifestResourceRow()
        { }
        protected STManifestResourceRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.MANIFEST_RESOURCE;

            Offset = reader.getUInt(BEGIN_OFFSET + OFFSET_OFFSET);
            Flags = (ManifestResourceAttributesFlag)reader.getUInt(BEGIN_OFFSET + OFFSET_FLAGS);

            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();
            Name = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_NAME, stringSizeIndex, stringSizeIndex);
            Implementation = reader.getUShort(BEGIN_OFFSET + OFFSET_IMPLEMENTATION + stringSizeIndex);


            END_OFFSET = BEGIN_OFFSET + OFFSET_IMPLEMENTATION + stringSizeIndex + 2;
        }
    }
}
