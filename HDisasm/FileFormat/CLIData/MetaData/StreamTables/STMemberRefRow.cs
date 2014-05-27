#region description
/*
MemberRef : 0x0A
 * 
 * 
The MemberRef table combines two sorts of references, to Methods and to Fields of a class, known as
‘MethodRef’ and ‘FieldRef’, respectively. The MemberRef table has the following columns:
• Class (an index into the MethodDef, ModuleRef,TypeDef, TypeRef, or TypeSpec tables; more
precisely, a MemberRefParent (§24.2.6) coded index)
• Name (an index into the String heap)
• Signature (an index into the Blob heap)
An entry is made into the MemberRef table whenever a reference is made in the CIL code to a method or field
which is defined in another module or assembly. (Also, an entry is made for a call to a method with a VARARG
signature, even when it is defined in the same module as the call site.)

 * 
 * 
1. Class shall be one of the following: [ERROR]
a. a TypeRef token, if the class that defines the member is defined in another module. (Note
that it is unusual, but valid, to use a TypeRef token when the member is defined in this same
module, in which case, its TypeDef token can be used instead.)
b. a ModuleRef token, if the member is defined, in another module of the same assembly, as a
global function or variable.
c. a MethodDef token, when used to supply a call-site signature for a vararg method that is
defined in this module. The Name shall match the Name in the corresponding MethodDef
row. The Signature shall match the Signature in the target method definition [ERROR]
d. a TypeSpec token, if the member is a member of a generic type
2. Class shall not be null (as this would indicate an unresolved reference to a global function or
variable) [ERROR]
3. Name shall index a non-empty string in the String heap [ERROR]
4. The Name string shall be a valid CLS identifier [CLS]
5. Signature shall index a valid field or method signature in the Blob heap. In particular, it shall
embed exactly one of the following ‘calling conventions’: [ERROR]
a. DEFAULT (0x0)
b. VARARG (0x5)
c. FIELD (0x6)
d. GENERIC (0x10)
6. The MemberRef table shall contain no duplicates, where duplicate rows have the same Class,
Name, and Signature [WARNING]
7. Signature shall not have the VARARG (0x5) calling convention [CLS]
8. There shall be no duplicate rows, where Name fields are compared using CLS conflictingidentifier-
rules. (In particular, note that the return type and whether parameters are marked
ELEMENT_TYPE_BYREF (§23.1.16) are ignored in the CLS. For example, .method int32 M()and
.method float64 M() result in duplicate rows by CLS rules. Similarly, .method void
N(int32 i)and .method void N(int32& i)also result in duplicate rows by CLS rules.) [CLS]
9. If Class and Name resolve to a field, then that field shall not have a value of CompilerControlled
(§23.1.5) in its Flags.FieldAccessMask subfield [ERROR]
10. If Class and Name resolve to a method, then that method shall not have a value of
CompilerControlled in its Flags.MemberAccessMask (§23.1.10) subfield [ERROR]
11. The type containing the definition of a MemberRef shall be a TypeSpec representing an
instantiated type.
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STMemberRefRow : AStreamTableRow
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
            return new STMemberRefRow(reader, beginOffset, mediator, heapSizes);
        }

        private STMemberRefRow()
        { }
        protected STMemberRefRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.MEMBER_REF;

            Offset = reader.getUInt(BEGIN_OFFSET + OFFSET_OFFSET);
            Flags = (ManifestResourceAttributesFlag)reader.getUInt(BEGIN_OFFSET + OFFSET_FLAGS);

            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();
            Name = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_NAME, stringSizeIndex, stringSizeIndex);
            Implementation = reader.getUShort(BEGIN_OFFSET + OFFSET_IMPLEMENTATION + stringSizeIndex);


            END_OFFSET = BEGIN_OFFSET + OFFSET_IMPLEMENTATION + stringSizeIndex + 2;
        }
    }
}
