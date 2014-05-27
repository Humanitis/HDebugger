#region description
/*
 FieldRVA : 0x1D
 * 
 * 
The FieldRVA table has the following columns:
• RVA (a 4-byte constant)
• Field (an index into Field table)
Conceptually, each row in the FieldRVA table is an extension to exactly one row in the Field table, and records
the RVA (Relative Virtual Address) within the image file at which this field’s initial value is stored.
A row in the FieldRVA table is created for each static parent field that has specified the optional data
label §16). The RVA column is the relative virtual address of the data in the PE file (§16.3).

 * 
 * 
 * 
1. RVA shall be non-zero [ERROR]
2. RVA shall point into the current module’s data area (not its metadata area) [ERROR]
3. Field shall index a valid row in the Field table [ERROR]
4. Any field with an RVA shall be a ValueType (not a Class or an Interface). Moreover, it shall not
have any private fields (and likewise for any of its fields that are themselves ValueTypes). (If
any of these conditions were breached, code could overlay that global static and access its private
fields.) Moreover, no fields of that ValueType can be Object References (into the GC heap)
[ERROR]
5. So long as two RVA-based fields comply with the previous conditions, the ranges of memory
spanned by the two ValueTypes can overlap, with no further constraints. This is not actually an
additional rule; it simply clarifies the position with regard to overlapped RVA-based fields
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STFieldRVARow : AStreamTableRow
    {
        private static readonly ulong OFFSET_RVA = 0UL;
        private static readonly ulong OFFSET_FIELD = 4UL;

        private uint _rva;
        private ushort _field;


        public uint RVA
        {
            get { return _rva; }
            private set { _rva = value;}
        }
        public ushort Field
        {
            get { return _field; }
            private set { _field = value; }
        }



        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STFieldRVARow(reader, beginOffset, mediator, heapSizes);
        }

        private STFieldRVARow()
        { }
        protected STFieldRVARow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.FIELD_MARSHAL;

            RVA = reader.getUInt(BEGIN_OFFSET + OFFSET_RVA);
            Field = reader.getUShort(BEGIN_OFFSET + OFFSET_FIELD);

            END_OFFSET = BEGIN_OFFSET + OFFSET_FIELD+2;
        }

    }
}
