#region description
/*
 File : 0x26
 * 
 * 
The File table has the following columns:
• Flags (a 4-byte bitmask of type FileAttributes, §23.1.6)
• Name (an index into the String heap)
• HashValue (an index into the Blob heap)
The rows of the File table result from .file directives in an Assembly (§6.2.3)

 * 
 * 
1. Flags shall have only those values set that are specified (all combinations valid) [ERROR]
2. Name shall index a non-empty string in the String heap. It shall be in the format
<filename>.<extension> (e.g., “foo.dll”, but not “c:\utils\foo.dll”) [ERROR]
3. HashValue shall index a non-empty 'blob' in the Blob heap [ERROR]
4. There shall be no duplicate rows; that is, rows with the same Name value [ERROR]
5. If this module contains a row in the Assembly table (that is, if this module “holds the manifest”)
then there shall not be any row in the File table for this module; i.e., no self-reference [ERROR]
6. If the File table is empty, then this, by definition, is a single-file assembly. In this case, the
ExportedType table should be empty [WARNING]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STFileRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_FLAGS = 0UL;
        private static readonly ulong OFFSET_NAME = 4UL;
        private static readonly ulong OFFSET_HASH_VALUE = 4UL;

        private FileAttributesFlag _flags;
        private uint _name;
        private uint _hashValue;


        public FileAttributesFlag Flags
        {
            get { return _flags; }
            private set { _flags = value; }
        }
        public uint Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public uint HashValue
        {
            get { return _hashValue; }
            private set { _hashValue = value; }
        }


        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STFileRow(reader, beginOffset, mediator, heapSizes);
        }

        private STFileRow()
        { }
        protected STFileRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.FILE;

            Flags = (FileAttributesFlag)reader.getUInt(BEGIN_OFFSET + OFFSET_FLAGS);

            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();
            ulong blobSizeIndex = HeapSizes.WideOfBlobHeap();
            Name = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_NAME, stringSizeIndex, stringSizeIndex);
            HashValue = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_HASH_VALUE + stringSizeIndex, blobSizeIndex, blobSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_HASH_VALUE + blobSizeIndex + stringSizeIndex;
        }

    }
}
