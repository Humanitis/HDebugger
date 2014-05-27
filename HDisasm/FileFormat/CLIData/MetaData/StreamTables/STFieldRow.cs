#region description
/*
 *Field : 0x04
 *
 * 
The Field table has the following columns:
• Flags (a 2-byte bitmask of type FieldAttributes, §23.1.5)
• Name (an index into the String heap)
• Signature (an index into the Blob heap)
Conceptually, each row in the Field table is owned by one, and only one, row in the TypeDef table. However,
the owner of any row in the Field table is not stored anywhere in the Field table itself. There is merely a
‘forward-pointer’ from each row in the TypeDef table (the FieldList column)
 * 
 * 
 * 1. The Field table can contain zero or more rows
2. Each row shall have one, and only one, owner row in the TypeDef table [ERROR]
3. The owner row in the TypeDef table shall not be an Interface [CLS]
4. Flags shall have only those values set that are specified [ERROR]
5. The FieldAccessMask subfield of Flags shall contain precisely one of CompilerControlled,
Private, FamANDAssem, Assembly, Family, FamORAssem, or Public (§23.1.5) [ERROR]
6. Flags can set either or neither of Literal or InitOnly, but not both (§23.1.5) [ERROR]
7. If Flags.Literal = 1 then Flags.Static shall also be 1 (§23.1.5) [ERROR]
8. If Flags.RTSpecialName = 1, then Flags.SpecialName shall also be 1 (§23.1.5) [ERROR]
9. If Flags.HasFieldMarshal = 1, then this row shall ‘own’ exactly one row in the FieldMarshal
table (§23.1.5) [ERROR]
10. If Flags.HasDefault = 1, then this row shall ‘own’ exactly one row in the Constant table
(§23.1.5) [ERROR]
11. If Flags.HasFieldRVA = 1, then this row shall ‘own’ exactly one row in the Field’s RVA table
(§23.1.5) [ERROR]
12. Name shall index a non-empty string in the String heap [ERROR]
13. The Name string shall be a valid CLS identifier [CLS]
14. Signature shall index a valid field signature in the Blob heap [ERROR]
15. If Flags.CompilerControlled = 1 (§23.1.5), then this row is ignored completely in duplicate
checking.
16. If the owner of this field is the internally-generated type called <Module>, it denotes that this field
is defined at module scope (commonly called a global variable). In this case:
o Flags.Static shall be 1 [ERROR]
o Flags.MemberAccessMask subfield shall be one of Public, CompilerControlled, or
Private (§23.1.5) [ERROR]
o module-scope fields are not allowed [CLS]
17. There shall be no duplicate rows in the Field table, based upon owner+Name+Signature (where
owner is the owning row in the TypeDef table, as described above) (Note however that if
Flags.CompilerControlled = 1, then this row is completely excluded from duplicate checking)
[ERROR]
18. There shall be no duplicate rows in the Field table, based upon owner+Name, where Name fields
are compared using CLS conflicting-identifier-rules. So, for example,"int i" and "float i"
would be considered CLS duplicates. (Note however that if Flags.CompilerControlled = 1, then
this row is completely excluded from duplicate checking, as noted above) [CLS]
19. If this is a field of an Enum, and Name string = "value__" then:
a. RTSpecialName shall be 1 [ERROR]
b. owner row in TypeDef table shall derive directly from System.Enum [ERROR]
c. the owner row in TypeDef table shall have no other instance fields [CLS]
d. its Signature shall be one of ELEMENT_TYPE_U1, ELEMENT_TYPE_I2, ELEMENT_TYPE_I4, or
ELEMENT_TYPE_I8 (§23.1.16 ): [CLS]
20. its Signature shall be an integral type. [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STFieldRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_FLAGS = 0UL;
        private static readonly ulong OFFSET_NAME = 2UL;
        private static readonly ulong OFFSET_SIGNATURE = 2UL;

        private FieldAttributesFlag _flags;
        private uint _name;
        private uint _signature;

        public FieldAttributesFlag Flags
        {
            get { return _flags; }
            private set { _flags = value; }
        }
        public uint Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public uint Signature
        {
            get { return _signature; }
            private set { _signature = value; }
        }



        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STFieldRow(reader, beginOffset, mediator, heapSizes);
        }

        private STFieldRow()
        { }
        protected STFieldRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.FIELD;

            Flags = (FieldAttributesFlag)reader.getUShort(BEGIN_OFFSET + OFFSET_FLAGS);

            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();
            Name = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_NAME, stringSizeIndex, stringSizeIndex);
            Signature = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_SIGNATURE + stringSizeIndex, stringSizeIndex, stringSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_SIGNATURE + 2 * stringSizeIndex;
        }

    }
}
