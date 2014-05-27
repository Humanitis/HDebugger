#region description
/*
GenericParam : 0x2A
 * 
 * 
The GenericParam table has the following columns:
• Number (the 2-byte index of the generic parameter, numbered left-to-right, from zero)
• Flags (a 2-byte bitmask of type GenericParamAttributes, §23.1.7)
• Owner (an index into the TypeDef or MethodDef table, specifying the Type or Method to which
this generic parameter applies; more precisely, a TypeOrMethodDef (§24.2.6) coded index)
• Name (a non-null index into the String heap, giving the name for the generic parameter. This is
purely descriptive and is used only by source language compilers and by Reflection)
The GenericParam table stores the generic parameters used in generic type definitions and generic method
definitions. These generic parameters can be constrained (i.e., generic arguments shall extend some class
and/or implement certain interfaces) or unconstrained. (Such constraints are stored in the
GenericParamConstraint table.)
Conceptually, each row in the GenericParam table is owned by one, and only one, row in either the TypeDef or
MethodDef tables.
[Example:
.class Dict`2<([mscorlib]System.IComparable) K, V>
The generic parameter K of class Dict is constrained to implement System.IComparable.
.method static void ReverseArray<T>(!!0[] 'array')
There is no constraint on the generic parameter T of the generic method ReverseArray.
end example]

 * 
 * 
1. GenericParam table can contain zero or more rows
2. Each row shall have one, and only one, owner row in the TypeDef or MethodDef table (i.e., no
row sharing) [ERROR]
3. Every generic type shall own one row in the GenericParam table for each of its generic
parameters [ERROR]
4. Every generic method shall own one row in the GenericParam table for each of its generic
parameters [ERROR]
Flags:
• Can hold the value Covariant or Contravariant, but only if the owner row corresponds to a
generic interface, or a generic delegate class. [ERROR]
• Otherwise, shall hold the value NonVariant (i.e., where the owner is a non delegate class, a valuetype,
or a generic method) [ERROR]
If Flags == Covariant then the corresponding generic parameter can appear in a type definition only as
[ERROR]:
• The result type of a method
• A generic parameter to an inherited interface
If Flags == Contravariant then the corresponding generic parameter can appear in a type definition only
as the argument to a method [ERROR]
Number shall have a value >= 0 and < the number of generic parameters in owner type or method.
[ERROR]
Successive rows of the GenericParam table that are owned by the same method shall be ordered by
increasing Number value; there shall be no gaps in the Number sequence [ERROR]
Name shall be non-null and index a string in the String heap [ERROR]
[Rationale: Otherwise, Reflection output is not fully usable. end rationale]
There shall be no duplicate rows based upon Owner+Name [ERROR] [Rationale: Otherwise, code
using Reflection cannot disambiguate the different generic parameters. end rationale]
There shall be no duplicate rows based upon Owner+Number [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STGenericParamRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_NUMBER = 0UL;
        private static readonly ulong OFFSET_FLAGS = 2UL;
        private static readonly ulong OFFSET_OWNER = 4UL;
        private static readonly ulong OFFSET_NAME = 6UL;

        private ushort _number;
        private GenericParamAttributesFlag _flags;
        private ushort _owner;
        private uint _name;
        private TypeOrMethodDefTag _ownerTable;



        public ushort Number
        {
            get { return _number; }
            private set { _number = value; }
        }
        public GenericParamAttributesFlag Flags
        {
            get { return _flags; }
            private set { _flags = value; }
        }
        public ushort Owner
        {
            get { return _owner; }
            private set { _owner = value; _ownerTable = (TypeOrMethodDefTag)(_owner >> 14); }
        }
        public uint Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public TypeOrMethodDefTag OwnerTable
        {
            get { return _ownerTable; }
        }


        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STGenericParamRow(reader, beginOffset, mediator, heapSizes);
        }

        private STGenericParamRow()
        { }
        protected STGenericParamRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.GENERIC_PARAM;

            Number = reader.getUShort(BEGIN_OFFSET + OFFSET_NUMBER);
            Flags = (GenericParamAttributesFlag)reader.getUShort(BEGIN_OFFSET + OFFSET_FLAGS);
            Owner = reader.getUShort(BEGIN_OFFSET + OFFSET_OWNER);

            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();
            Name = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_NAME, stringSizeIndex, stringSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_NAME + stringSizeIndex;
        }

    }
}
