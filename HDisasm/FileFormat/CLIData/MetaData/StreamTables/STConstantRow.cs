#region description
/*The Constant table is used to store compile-time, constant values for fields, parameters, and properties.
The Constant table has the following columns:
• Type (a 1-byte constant, followed by a 1-byte padding zero); see §23.1.16 . The encoding of Type
for the nullref value for FieldInit in ilasm (§16.2) is ELEMENT_TYPE_CLASS with a Value of a 4-
byte zero. Unlike uses of ELEMENT_TYPE_CLASS in signatures, this one is not followed by a type
token.
• Parent (an index into the Param, Field, or Property table; more precisely, a HasConstant
(§24.2.6) coded index)
• Value (an index into the Blob heap)
Note that Constant information does not directly influence runtime behavior, although it is visible via
Reflection (and hence can be used to implement functionality such as that provided by
System.Enum.ToString). Compilers inspect this information, at compile time, when importing metadata, but
the value of the constant itself, if used, becomes embedded into the CIL stream the compiler emits. There are
no CIL instructions to access the Constant table at runtime.
A row in the Constant table for a parent is created whenever a compile-time value is specified for that parent.

 1. Type shall be exactly one of: ELEMENT_TYPE_BOOLEAN, ELEMENT_TYPE_CHAR, ELEMENT_TYPE_I1,
ELEMENT_TYPE_U1, ELEMENT_TYPE_I2, ELEMENT_TYPE_U2, ELEMENT_TYPE_I4, ELEMENT_TYPE_U4,
ELEMENT_TYPE_I8, ELEMENT_TYPE_U8, ELEMENT_TYPE_R4, ELEMENT_TYPE_R8, or
ELEMENT_TYPE_STRING; or ELEMENT_TYPE_CLASS with a Value of zero (§23.1.16) [ERROR]
2. Type shall not be any of: ELEMENT_TYPE_I1, ELEMENT_TYPE_U2, ELEMENT_TYPE_U4, or
ELEMENT_TYPE_U8 (§23.1.16) [CLS]
3. Parent shall index a valid row in the Field, Property, or Param table. [ERROR]
4. There shall be no duplicate rows, based upon Parent [ERROR]
5. Type shall match exactly the declared type of the Param, Field, or Property identified by Parent
(in the case where the parent is an enum, it shall match exactly the underlying type of that enum).
[CLS]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STConstantRow: AStreamTableRow
    {
        private static readonly ulong OFFSET_TYPE = 0UL;
        private static readonly ulong OFFSET_PARENT = 2UL;
        private static readonly ulong OFFSET_VALUE = 4UL;

        private ElementTypesFlag _type;
        private ushort _parent;
        private uint _value;
        private HasConstantTag _parentTable;

        public ElementTypesFlag Type
        {
            get { return _type; }
            private set { _type = value; }
        }
        public ushort Parent
        {
            get { return _parent; }
            private set { _parent = value; _parentTable = (HasConstantTag)(_parent >> 14); }
        }
        public uint Value
        {
            get { return _value; }
            private set { _value = value; }
        }
        public HasConstantTag ParentTable
        {
            get { return _parentTable; }
        }

        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STConstantRow(reader, beginOffset, mediator, heapSizes);
        }

        private STConstantRow()
        { }
        protected STConstantRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.CONSTANT;

            Type = (ElementTypesFlag)reader[BEGIN_OFFSET + OFFSET_TYPE];
            Parent = reader.getUShort(BEGIN_OFFSET + OFFSET_PARENT);


            ulong blobSizeIndex = HeapSizes.WideOfBlobHeap();
            Value = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_VALUE, blobSizeIndex, blobSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_VALUE + blobSizeIndex;
        }

    }
}
