#region description
/*The CustomAttribute table has the following columns:
• Parent (an index into any metadata table, except the CustomAttribute table itself; more precisely,
a HasCustomAttribute (§24.2.6) coded index)
• Type (an index into the MethodDef or MemberRef table; more precisely, a CustomAttributeType
(§24.2.6) coded index)
• Value (an index into the Blob heap)
Partition II 111
The CustomAttribute table stores data that can be used to instantiate a Custom Attribute (more precisely, an
object of the specified Custom Attribute class) at runtime. The column called Type is slightly misleading—it
actually indexes a constructor method—the owner of that constructor method is the Type of the Custom
Attribute.
A row in the CustomAttribute table for a parent is created by the .custom attribute, which gives the value of
the Type column and optionally that of the Value column
 * 
 * 
 All binary values are stored in little-endian format (except for PackedLen items, which are used only as a count
for the number of bytes to follow in a UTF8 string).
1. No CustomAttribute is required; that is, Value is permitted to be null.
2. Parent can be an index into any metadata table, except the CustomAttribute table itself [ERROR]
3. Type shall index a valid row in the Method or MemberRef table. That row shall be a constructor
method (for the class of which this information forms an instance) [ERROR]
4. Value can be null or non-null.
5. If Value is non-null, it shall index a 'blob' in the Blob heap [ERROR]
6. The following rules apply to the overall structure of the Value 'blob' (§23.3):
o Prolog shall be 0x0001 [ERROR]
o There shall be as many occurrences of FixedArg as are declared in the Constructor
method [ERROR]
o NumNamed can be zero or more
o There shall be exactly NumNamed occurrences of NamedArg [ERROR]
o Each NamedArg shall be accessible by the caller [ERROR]
o If NumNamed = 0 then there shall be no further items in the CustomAttrib [ERROR]
7. The following rules apply to the structure of FixedArg (§23.3):
o If this item is not for a vector (a single-dimension array with lower bound of 0), then
there shall be exactly one Elem [ERROR]
o If this item is for a vector, then:
o NumElem shall be 1 or more [ERROR]
o This shall be followed by NumElem occurrences of Elem [ERROR]
8. The following rules apply to the structure of Elem (§23.3):
o If this is a simple type or an enum (see §23.3 for how this is defined), then Elem
consists simply of its value [ERROR]
o If this is a string or a Type, then Elem consists of a SerString – PackedLen count of
bytes, followed by the UTF8 characters [ERROR]
o If this is a boxed simple value type (bool, char, float32, float64, int8, int16,
int32, int64, unsigned int8, unsigned int16, unsigned int32, or unsigned
int64), then Elem consists of the corresponding type denoter (ELEMENT_TYPE_BOOLEAN,
ELEMENT_TYPE_CHAR, ELEMENT_TYPE_I1, ELEMENT_TYPE_U1, ELEMENT_TYPE_I2,
ELEMENT_TYPE_U2, ELEMENT_TYPE_I4, ELEMENT_TYPE_U4, ELEMENT_TYPE_I8,
ELEMENT_TYPE_U8, ELEMENT_TYPE_R4, or ELEMENT_TYPE_R8), followed by its value.
[ERROR]
9. The following rules apply to the structure of NamedArg (§23.3):
o The single byte FIELD (0x53) or PROPERTY (0x54) [ERROR]
o The type of the Field or Property is one of ELEMENT_TYPE_BOOLEAN,
ELEMENT_TYPE_CHAR, ELEMENT_TYPE_I1, ELEMENT_TYPE_U1, ELEMENT_TYPE_I2,
ELEMENT_TYPE_U2, ELEMENT_TYPE_I4, ELEMENT_TYPE_U4, ELEMENT_TYPE_I8,
ELEMENT_TYPE_U8, ELEMENT_TYPE_R4, ELEMENT_TYPE_R8, ELEMENT_TYPE_STRING, or the
constant 0x50 (for an argument of type System.Type) [ERROR]
o The name of the Field or Property, respectively with the previous item, as a SerString
– PackedLen count of bytes, followed by the UTF8 characters of the name [ERROR]
o A FixedArg (see above) [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STCustomAttributeRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_PARENT = 0UL;
        private static readonly ulong OFFSET_TYPE = 2UL;
        private static readonly ulong OFFSET_VALUE = 4UL;

        private ushort _parent;
        private ElementTypesFlag _type;
        private uint _value;
        private HasCustomAttributeTag _parentTable;

        public ushort Parent
        {
            get { return _parent; }
            private set { _parent = value; _parentTable = (HasCustomAttributeTag)(_parent >> 11); }
        }
        public ElementTypesFlag Type
        {
            get { return _type; }
            private set { _type = value; }
        }
        public uint Value
        {
            get { return _value; }
            private set { _value = value; }
        }
        public HasCustomAttributeTag ParentTable
        {
            get { return _parentTable; }
        }

        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STCustomAttributeRow(reader, beginOffset, mediator, heapSizes);
        }

        private STCustomAttributeRow()
        { }
        protected STCustomAttributeRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.CUSTOM_ATTRIBUTE;

            Parent = reader.getUShort(BEGIN_OFFSET + OFFSET_PARENT);
            Type = (ElementTypesFlag)reader[BEGIN_OFFSET + OFFSET_TYPE];


            ulong blobSizeIndex = HeapSizes.WideOfBlobHeap();
            Value = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_VALUE, blobSizeIndex, blobSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_VALUE + blobSizeIndex;
        }

    }
}
