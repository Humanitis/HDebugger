#region description
/*The ClassLayout table has the following columns:
• PackingSize (a 2-byte constant)
• ClassSize (a 4-byte constant)
• Parent (an index into the TypeDef table)
The rows of the ClassLayout table are defined by placing .pack and .size directives on the body of the type
declaration in which this type is declared (§10.2). When either of these directives is omitted, its corresponding
value is zero. (See §10.7.)
ClassSize of zero does not mean the class has zero size. It means that no .size directive was specified at
definition time, in which case, the actual size is calculated from the field types, taking account of packing size
(default or specified) and natural alignment on the target, runtime platform.
 
 1. A ClassLayout table can contain zero or more rows
2. Parent shall index a valid row in the TypeDef table, corresponding to a Class or ValueType (but
not to an Interface) [ERROR]
3. The Class or ValueType indexed by Parent shall be SequentialLayout or ExplicitLayout
(§23.1.15). (That is, AutoLayout types shall not own any rows in the ClassLayout table.)
[ERROR]
4. If Parent indexes a SequentialLayout type, then:
o PackingSize shall be one of {0, 1, 2, 4, 8, 16, 32, 64, 128}. (0 means use the default
pack size for the platform on which the application is running.) [ERROR]
o If Parent indexes a ValueType, then ClassSize shall be less than 1 MByte (0x100000
bytes). [ERROR]
5. If Parent indexes an ExplicitLayout type, then
o if Parent indexes a ValueType, then ClassSize shall be less than 1 MByte (0x100000
bytes) [ERROR]
o PackingSize shall be 0. (It makes no sense to provide explicit offsets for each field, as
well as a packing size.) [ERROR]
110 Partition II
6. Note that an ExplicitLayout type might result in a verifiable type, provided the layout does not
create a type whose fields overlap.
7. Layout along the length of an inheritance chain shall follow the rules specified above (starting at
‘highest’ Type, with no ‘holes’, etc.) [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STClassLayoutRow: AStreamTableRow
    {
        private static readonly ulong OFFSET_PACKING_SIZE = 0UL;
        private static readonly ulong OFFSET_CLASS_CIZE = 2UL;
        private static readonly ulong OFFSET_PARENT = 6UL;

        private ushort _packingSize;
        private uint _classSize;
        private ushort _parent;

        public ushort PackingSize
        {
            get { return _packingSize; }
            private set { _packingSize = value; }
        }
        public uint ClassSize
        {
            get { return _classSize; }
            private set { _classSize = value; }
        }
        /// <summary>
        /// an index into the TypeDef table
        /// </summary>
        public ushort Parent
        {
            get { return _parent; }
            private set { _parent = value; }
        }

        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STClassLayoutRow(reader, beginOffset, mediator, heapSizes);
        }

        private STClassLayoutRow()
        { }
        protected STClassLayoutRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.CLASS_LAYOUT;

            PackingSize = reader.getUShort(BEGIN_OFFSET + OFFSET_PACKING_SIZE);
            ClassSize = reader.getUInt(BEGIN_OFFSET + OFFSET_CLASS_CIZE);
            Parent = reader.getUShort(BEGIN_OFFSET + OFFSET_PARENT);

            END_OFFSET = BEGIN_OFFSET + OFFSET_PARENT + 2;
        }
    }
}
