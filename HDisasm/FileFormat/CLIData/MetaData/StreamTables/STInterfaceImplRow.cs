#region description
/*
InterfaceImpl : 0x09
 * 
 * 
The InterfaceImpl table has the following columns:
• Class (an index into the TypeDef table)
• Interface (an index into the TypeDef, TypeRef, or TypeSpec table; more precisely, a TypeDefOrRef
(§24.2.6) coded index)
The InterfaceImpl table records the interfaces a type implements explicitly. Conceptually, each row in the
InterfaceImpl table indicates that Class implements Interface.

 * 
 * 
1. The InterfaceImpl table can contain zero or more rows
2. Class shall be non-null [ERROR]
3. If Class is non-null, then:
a. Class shall index a valid row in the TypeDef table [ERROR]
b. Interface shall index a valid row in the TypeDef or TypeRef table [ERROR]
c. The row in the TypeDef, TypeRef, or TypeSpec table indexed by Interface shall be an
interface (Flags.Interface = 1), not a Class or ValueType [ERROR]
4. There should be no duplicates in the InterfaceImpl table, based upon non-null Class and Interface
values [WARNING]
5. There can be many rows with the same value for Class (since a class can implement many
interfaces)
6. There can be many rows with the same value for Interface (since many classes can implement the
same interface)
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STInterfaceImplRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_CLASS = 0UL;
        private static readonly ulong OFFSET_INTERFACE = 2UL;

        private ushort _class;
        private ushort _interface;
        private TypeDefOrRefTag _interfaceTable;


        public ushort Class
        {
            get { return _class; }
            private set { _class = value; }
        }
        public ushort Interface
        {
            get { return _interface; }
            private set { _interface = value; _interfaceTable = (TypeDefOrRefTag)(_interface >> 14); }
        }
        public TypeDefOrRefTag InterfaceTable
        {
            get { return _interfaceTable; }
        }


        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STInterfaceImplRow(reader, beginOffset, mediator, heapSizes);
        }

        private STInterfaceImplRow()
        { }
        protected STInterfaceImplRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.INTERFACE_IMPL;

            Class = reader.getUShort(BEGIN_OFFSET + OFFSET_CLASS);
            Interface = reader.getUShort(BEGIN_OFFSET + OFFSET_INTERFACE);

            END_OFFSET = BEGIN_OFFSET + OFFSET_INTERFACE + 2;
        }
    }
}
