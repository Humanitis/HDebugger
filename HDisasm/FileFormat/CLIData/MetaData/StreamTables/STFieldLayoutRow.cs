#region description
/*
 *FieldLayout : 0x10
 *
 * 
The FieldLayout table has the following columns:
• Offset (a 4-byte constant)
• Field (an index into the Field table)
Note that each Field in any Type is defined by its Signature. When a Type instance (i.e., an object) is laid out
by the CLI, each Field is one of four kinds:
• Scalar: for any member of built-in type, such as int32. The size of the field is given by the size
of that intrinsic, which varies between 1 and 8 bytes
• ObjectRef: for ELEMENT_TYPE_CLASS, ELEMENT_TYPE_STRING, ELEMENT_TYPE_OBJECT,
ELEMENT_TYPE_ARRAY, ELEMENT_TYPE_SZARRAY
• Pointer: for ELEMENT_TYPE_PTR, ELEMENT_TYPE_FNPTR
• ValueType: for ELEMENT_TYPE_VALUETYPE. The instance of that ValueType is actually laid out in
this object, so the size of the field is the size of that ValueType
Note that metadata specifying explicit structure layout can be valid for use on one platform but not on another,
since some of the rules specified here are dependent on platform-specific alignment rules.
A row in the FieldLayout table is created if the .field directive for the parent field has specified a field
offset (§16).

 * 
 * 
1. A FieldLayout table can contain zero or more or rows
2. The Type whose Fields are described by each row of the FieldLayout table shall have
Flags.ExplicitLayout (§23.1.15) set [ERROR]
3. Offset shall be zero or more [ERROR]
4. Field shall index a valid row in the Field table [ERROR]
5. Flags.Static for the row in the Field table indexed by Field shall be non-static (i.e., zero 0)
[ERROR]
6. Among the rows owned by a given Type there shall be no duplicates, based upon Field. That is, a
given Field of a Type cannot be given two offsets. [ERROR]
7. Each Field of kind ObjectRef shall be naturally aligned within the Type [ERROR]
8. Among the rows owned by a given Type it is perfectly valid for several rows to have the same
value of Offset. ObjectRef and a valuetype cannot have the same offset [ERROR]
9. Every Field of an ExplicitLayout Type shall be given an offset; that is, it shall have a row in the
FieldLayout table [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STFieldLayoutRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_OFFSET = 0UL;
        private static readonly ulong OFFSET_FIELD = 4UL;

        private uint _offset;
        private ushort _field;


        public uint Offset
        {
            get { return _offset; }
            private set { _offset = value; }
        }
        public ushort Field
        {
            get { return _field; }
            private set { _field = value; }
        }



        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STFieldLayoutRow(reader, beginOffset, mediator, heapSizes);
        }

        private STFieldLayoutRow()
        { }
        protected STFieldLayoutRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.FIELD_LAYOUT;

            Offset = reader.getUInt(BEGIN_OFFSET + OFFSET_OFFSET);
            Field = reader.getUShort(BEGIN_OFFSET + OFFSET_FIELD);

            END_OFFSET = BEGIN_OFFSET + OFFSET_FIELD + 2;
        }

    }
}
