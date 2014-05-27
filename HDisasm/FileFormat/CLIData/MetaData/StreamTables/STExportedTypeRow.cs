#region description
/*
 *ExportedType : 0x27
 *
 * 
 * 
The ExportedType table holds a row for each type, defined within other modules of this Assembly; that is
exported out of this Assembly. In essence, it stores TypeDef row numbers of all types that are marked public in
other modules that this Assembly comprises.
The actual target row in a TypeDef table is given by the combination of TypeDefId (in effect, row number) and
Implementation (in effect, the module that holds the target TypeDef table). Note that this is the only occurrence
in metadata of foreign tokens; that is, token values that have a meaning in another module. (A regular token
value is an index into a table in the current module)
The full name of the type need not be stored directly. Instead, it can be split into two parts at any included “.”
(although typically this is done at the last “.” in the full name). The part preceding the “.” is stored as the
TypeNamespace and that following the “.” is stored as the TypeName. If there is no “.” in the full name, then
the TypeNamespace shall be the index of the empty string.
The ExportedType table has the following columns:
• Flags (a 4-byte bitmask of type TypeAttributes, §23.1.15)
• TypeDefId (a 4-byte index into a TypeDef table of another module in this Assembly). This
column is used as a hint only. If the entry in the target TypeDef table matches the TypeName and
TypeNamespace entries in this table, resolution has succeeded. But if there is a mismatch, the
CLI shall fall back to a search of the target TypeDef table
• TypeName (an index into the String heap)
• TypeNamespace (an index into the String heap)
• Implementation. This is an index (more precisely, an Implementation (§24.2.6) coded index) into
either of the following tables:
o File table, where that entry says which module in the current assembly holds the
TypeDef
o ExportedType table, where that entry is the enclosing Type of the current nested Type
The rows in the ExportedType table are the result of the .class extern directive (§6.7).

 * 
 * 
The term “FullName” refers to the string created as follows: if the TypeNamespace is null, then use the
TypeName, otherwise use the concatenation of Typenamespace, “.”, and TypeName.
1. The ExportedType table can contain zero or more rows
2. There shall be no entries in the ExportedType table for Types that are defined in the current
module—just for Types defined in other modules within the Assembly [ERROR]
3. Flags shall have only those values set that are specified [ERROR]
4. If Implementation indexes the File table, then Flags.VisibilityMask shall be public (§23.1.15)
[ERROR]
5. If Implementation indexes the ExportedType table, then Flags.VisibilityMask shall be
NestedPublic (§23.1.15) [ERROR]
6. If non-null, TypeDefId should index a valid row in a TypeDef table in a module somewhere within
this Assembly (but not this module), and the row so indexed should have its Flags.Public = 1
(§23.1.15) [WARNING]
7. TypeName shall index a non-empty string in the String heap [ERROR]
8. TypeNamespace can be null, or non-null
9. If TypeNamespace is non-null, then it shall index a non-empty string in the String heap [ERROR]
10. FullName shall be a valid CLS identifier [CLS]
11. If this is a nested Type, then TypeNamespace should be null, and TypeName should represent the
unmangled, simple name of the nested Type [ERROR]
12. Implementation shall be a valid index into either of the following: [ERROR]
o the File table; that file shall hold a definition of the target Type in its TypeDef table
o a different row in the current ExportedType table—this identifies the enclosing Type of
the current, nested Type
13. FullName shall match exactly the corresponding FullName for the row in the TypeDef table
indexed by TypeDefId [ERROR]
14. Ignoring nested Types, there shall be no duplicate rows, based upon FullName [ERROR]
15. For nested Types, there shall be no duplicate rows, based upon TypeName and enclosing Type
[ERROR]
16. The complete list of Types exported from the current Assembly is given as the catenation of the
ExportedType table with all public Types in the current TypeDef table, where “public” means a
Flags.VisibilityMask of either Public or NestedPublic. There shall be no duplicate rows, in this
concatenated table, based upon FullName (add Enclosing Type into the duplicates check if this is
a nested Type) [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STExportedTypeRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_FLAGS = 0UL;
        private static readonly ulong OFFSET_TYPE_DEF_ID = 4UL;
        private static readonly ulong OFFSET_TYPE_NAME = 8UL;
        private static readonly ulong OFFSET_TYPE_NAMESPACE = 8UL;
        private static readonly ulong OFFSET_IMPLEMENTATION = 8UL;

        private TypeAttributesFlag _flags;
        private uint _typeDefId;
        private uint _typeName;
        private uint _typeNamespace;
        private ushort _implementation;
        private ImplementationTag _implementationTable;

        public TypeAttributesFlag Flags
        {
            get { return _flags; }
            private set { _flags = value; }
        }
        public uint TypeDefId
        {
            get { return _typeDefId; }
            private set { _typeDefId = value; }
        }
        public uint TypeName
        {
            get { return _typeName; }
            private set { _typeName = value; }
        }
        public uint TypeNamespace
        {
            get { return _typeNamespace; }
            private set { _typeNamespace = value; }
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
            return new STExportedTypeRow(reader, beginOffset, mediator, heapSizes);
        }

        private STExportedTypeRow()
        { }
        protected STExportedTypeRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.EXPORTED_TYPE;

            Flags = (TypeAttributesFlag)reader.getUInt(BEGIN_OFFSET + OFFSET_FLAGS);
            TypeDefId = reader.getUInt(BEGIN_OFFSET + OFFSET_TYPE_DEF_ID);

            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();
            TypeName = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_TYPE_NAME, stringSizeIndex, stringSizeIndex);
            TypeNamespace = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_TYPE_NAME + stringSizeIndex, stringSizeIndex, stringSizeIndex);
            Implementation = reader.getUShort(BEGIN_OFFSET + OFFSET_IMPLEMENTATION + 2 * stringSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_IMPLEMENTATION + 2 * stringSizeIndex + 2;
        }

    }
}
