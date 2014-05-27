#region description
/*The HeapSizes field is a bitvector that encodes the width of indexes into the various heaps. If bit 0 is set,
indexes into the “#String” heap are 4 bytes wide; if bit 1 is set, indexes into the “#GUID” heap are 4 bytes
wide; if bit 2 is set, indexes into the “#Blob” heap are 4 bytes wide. Conversely, if the HeapSize bit for a
particular heap is not set, indexes into that heap are 2 bytes wide.*/
#endregion
using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    [Flags()]
    public enum HeapSizeFlag
    {
        STRING_4BYTE_WIDE = 0x01,
        GUID_4BYTE_WIDE = 0x02,
        BLOB_4BYTE_WIDE = 0x04,
    }

    public static class ExtensionForHeapSizeFlag
    {
        public static ulong WideOfStringHeap(this Enum flag)
        {
            return ((HeapSizeFlag)flag & HeapSizeFlag.STRING_4BYTE_WIDE) > 0 ? 4UL : 2UL;
        }

        public static ulong WideOfBlobHeap(this Enum flag)
        {
            return ((HeapSizeFlag)flag & HeapSizeFlag.BLOB_4BYTE_WIDE) > 0 ? 4UL : 2UL;
        }

        public static ulong WideOfGuidHeap(this Enum flag)
        {
            return ((HeapSizeFlag)flag & HeapSizeFlag.GUID_4BYTE_WIDE) > 0 ? 4UL : 2UL;
        }
    }
}
