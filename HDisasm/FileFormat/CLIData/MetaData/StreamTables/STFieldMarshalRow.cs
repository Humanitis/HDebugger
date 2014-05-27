#region description
/*
 FieldMarshal : 0x0D
 * 
 * 
The FieldMarshal table has two columns. It ‘links’ an existing row in the Field or Param table, to information
in the Blob heap that defines how that field or parameter (which, as usual, covers the method return, as
parameter number 0) shall be marshalled when calling to or from unmanaged code via PInvoke dispatch.
Note that FieldMarshal information is used only by code paths that arbitrate operation with unmanaged code.
In order to execute such paths, the caller, on most platforms, would be installed with elevated security
permission. Once it invokes unmanaged code, it lies outside the regime that the CLI can check—it is simply
trusted not to violate the type system.
The FieldMarshal table has the following columns:
• Parent (an index into Field or Param table; more precisely, a HasFieldMarshal (§24.2.6) coded
index)
• NativeType (an index into the Blob heap)
For the detailed format of the 'blob', see §23.4
A row in the FieldMarshal table is created if the .field directive for the parent field has specified a
marshal attribute (§16.1).

 * 
 * 
1. A FieldMarshal table can contain zero or more rows
2. Parent shall index a valid row in the Field or Param table (Parent values are encoded to say
which of these two tables each refers to) [ERROR]
3. NativeType shall index a non-null 'blob' in the Blob heap [ERROR]
4. No two rows shall point to the same parent. In other words, after the Parent values have been
decoded to determine whether they refer to the Field or the Param table, no two rows can point to
the same row in the Field table or in the Param table [ERROR]
5. The following checks apply to the MarshalSpec 'blob' (§23.4):
a. NativeIntrinsic shall be exactly one of the constant values in its production (§23.4)
[ERROR]
b. If ARRAY, then ArrayElemType shall be exactly one of the constant values in its production
[ERROR]
c. If ARRAY, then ParamNum can be zero
d. If ARRAY, then ParamNum cannot be < 0 [ERROR]
e. If ARRAY, and ParamNum > 0, then Parent shall point to a row in the Param table, not in the
Field table [ERROR]
f. If ARRAY, and ParamNum > 0, then ParamNum cannot exceed the number of parameters
supplied to the MethodDef (or MethodRef if a VARARG call) of which the parent Param is a
member [ERROR]
g. If ARRAY, then ElemMult shall be >= 1 [ERROR]
h. If ARRAY and ElemMult != 1 issue a warning, because it is probably a mistake [WARNING]
i. If ARRAY and ParamNum = 0, then NumElem shall be >= 1 [ERROR]
j. If ARRAY and ParamNum != 0 and NumElem != 0 then issue a warning, because it is
probably a mistake [WARNING]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STFieldMarshalRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_PARENT = 0UL;
        private static readonly ulong OFFSET_NATIVE_TYPE = 2UL;

        private ushort _parent;
        private uint _nativeType;
        private HasFieldMarshallTag _parentTable;


        public ushort Parent
        {
            get { return _parent; }
            private set { _parent = value; _parentTable = (HasFieldMarshallTag)(_parent >> 14); }
        }
        public uint NativeType
        {
            get { return _nativeType; }
            private set { _nativeType = value; }
        }
        public HasFieldMarshallTag ParentTable
        {
            get { return _parentTable; }
        }



        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STFieldMarshalRow(reader, beginOffset, mediator, heapSizes);
        }

        private STFieldMarshalRow()
        { }
        protected STFieldMarshalRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.FIELD_MARSHAL;

            Parent = reader.getUShort(BEGIN_OFFSET + OFFSET_PARENT);

            ulong blobSizeIndex = HeapSizes.WideOfBlobHeap();
            NativeType = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_NATIVE_TYPE, blobSizeIndex, blobSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_NATIVE_TYPE + blobSizeIndex;
        }

    }
}
