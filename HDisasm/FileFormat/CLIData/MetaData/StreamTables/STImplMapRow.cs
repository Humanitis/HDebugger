#region description
/*
ImplMap : 0x1C
 * 
 * 
The ImplMap table holds information about unmanaged methods that can be reached from managed code,
using PInvoke dispatch.
Each row of the ImplMap table associates a row in the MethodDef table (MemberForwarded) with the name of
a routine (ImportName) in some unmanaged DLL (ImportScope).
[Note: A typical example would be: associate the managed Method stored in row N of the Method table (so
MemberForwarded would have the value N) with the routine called “GetEnvironmentVariable” (the string
indexed by ImportName) in the DLL called “kernel32” (the string in the ModuleRef table indexed by
ImportScope). The CLI intercepts calls to managed Method number N, and instead forwards them as calls to
the unmanaged routine called “GetEnvironmentVariable” in “kernel32.dll” (including marshalling any
arguments, as required)
The CLI does not support this mechanism to access fields that are exported from a DLL, only methods. end
note]
The ImplMap table has the following columns:
• MappingFlags (a 2-byte bitmask of type PInvokeAttributes, §23.1.7)
• MemberForwarded (an index into the Field or MethodDef table; more precisely, a
MemberForwarded (§24.2.6) coded index). However, it only ever indexes the MethodDef table,
since Field export is not supported.
• ImportName (an index into the String heap)
• ImportScope (an index into the ModuleRef table)
A row is entered in the ImplMap table for each parent Method (§15.5) that is defined with a .pinvokeimpl
interoperation attribute specifying the MappingFlags, ImportName, and ImportScope.

 * 
 * 
 * 
1. ImplMap can contain zero or more rows
2. MappingFlags shall have only those values set that are specified [ERROR]
3. MemberForwarded shall index a valid row in the MethodDef table [ERROR]
4. The MappingFlags.CharSetMask (§23.1.7) in the row of the MethodDef table indexed by
MemberForwarded shall have at most one of the following bits set: CharSetAnsi,
CharSetUnicode, or CharSetAuto (if none is set, the default is CharSetNotSpec) [ERROR]
5. ImportName shall index a non-empty string in the String heap [ERROR]
6. ImportScope shall index a valid row in the ModuleRef table [ERROR]
7. The row indexed in the MethodDef table by MemberForwarded shall have its Flags.PinvokeImpl
= 1, and Flags.Static = 1 [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STImplMapRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_MAPPING_FLAGS = 0UL;
        private static readonly ulong OFFSET_MEMBER_FORWARDED = 2UL;
        private static readonly ulong OFFSET_IMPORT_NAME = 4UL;
        private static readonly ulong OFFSET_IMPORT_SCOPE = 4UL;

        private PInvokeAttributesFlag _mappingFlags;
        private ushort _memberForwarded;
        private uint _importName;
        private ushort _importScope;
        private MemberForwardedTag _memberForwardedTable;


        public PInvokeAttributesFlag MappingFlags
        {
            get { return _mappingFlags; }
            private set { _mappingFlags = value; }
        }
        public ushort MemberForwarded
        {
            get { return _memberForwarded; }
            private set { _memberForwarded = value; _memberForwardedTable = (MemberForwardedTag)(_memberForwarded >> 14); }
        }
        public uint ImportName
        {
            get { return _importName; }
            private set { _importName = value; }
        }
        public ushort ImportScope
        {
            get { return _importScope; }
            private set { _importScope = value; }
        }
        public MemberForwardedTag MemberForwardedTable
        {
            get { return _memberForwardedTable; }
        }


        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STImplMapRow(reader, beginOffset, mediator, heapSizes);
        }

        private STImplMapRow()
        { }
        protected STImplMapRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.IMPL_MAP;

            MappingFlags = (PInvokeAttributesFlag)reader.getUShort(BEGIN_OFFSET + OFFSET_MAPPING_FLAGS);
            MemberForwarded = reader.getUShort(BEGIN_OFFSET + OFFSET_MEMBER_FORWARDED);

            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();
            ImportName = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_IMPORT_NAME, stringSizeIndex, stringSizeIndex);
            ImportScope = reader.getUShort(BEGIN_OFFSET + OFFSET_IMPORT_SCOPE + stringSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_IMPORT_SCOPE + stringSizeIndex + 2;
        }

    }
}
