#region description
/*
GenericParamConstraint : 0x2C
 * 
 * 
The GenericParamConstraint table has the following columns:
• Owner (an index into the GenericParam table, specifying to which generic parameter this row
refers)
• Constraint (an index into the TypeDef, TypeRef, or TypeSpec tables, specifying from which class
this generic parameter is constrained to derive; or which interface this generic parameter is
constrained to implement; more precisely, a TypeDefOrRef (§24.2.6) coded index)
The GenericParamConstraint table records the constraints for each generic parameter. Each generic parameter
can be constrained to derive from zero or one class. Each generic parameter can be constrained to implement
zero or more interfaces.
Conceptually, each row in the GenericParamConstraint table is ‘owned’ by a row in the GenericParam table.
All rows in the GenericParamConstraint table for a given Owner shall refer to distinct constraints.
Note that if Constraint is a TypeRef to System.ValueType, then it means the constraint type shall be
System.ValueType, or one of its sub types. However, since System.ValueType itself is a reference type, this
particular mechanism does not guarantee that the type is a non-reference type.

 * 
 * 
1. The GenericParamConstraint table can contain zero or more rows
2. Each row shall have one, and only one, owner row in the GenericParam table (i.e., no row sharing)
[ERROR]
3. Each row in the GenericParam table shall ‘own’ a separate row in the GenericParamConstraint
table for each constraint that generic parameter has [ERROR]
4. All of the rows in the GenericParamConstraint table that are owned by a given row in the
GenericParam table shall form a contiguous range (of rows) [ERROR]
5. Any generic parameter (corresponding to a row in the GenericParam table) shall own zero or one
row in the GenericParamConstraint table corresponding to a class constraint. [ERROR]
6. Any generic parameter (corresponding to a row in the GenericParam table) shall own zero or more
rows in the GenericParamConstraint table corresponding to an interface constraint. [ERROR]
7. There shall be no duplicate rows based upon Owner+Constraint [ERROR]
8. Constraint shall not reference System.Void. [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STGenericParamConstraintRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_OWNER = 0UL;
        private static readonly ulong OFFSET_CONSTRAINT = 2UL;

        private ushort _owner;
        private ushort _constraint;
        private TypeDefOrRefTag _constraintTable;


        public ushort Owner
        {
            get { return _owner; }
            private set { _owner = value; }
        }
        public ushort Constraint
        {
            get { return _constraint; }
            private set { _constraint = value; _constraintTable = (TypeDefOrRefTag)(_constraint >> 14); }
        }


        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STGenericParamConstraintRow(reader, beginOffset, mediator, heapSizes);
        }

        private STGenericParamConstraintRow()
        { }
        protected STGenericParamConstraintRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.GENERIC_PARAM_CONSTRAINT;

            Owner = reader.getUShort(BEGIN_OFFSET + OFFSET_OWNER);
            Constraint = reader.getUShort(BEGIN_OFFSET + OFFSET_CONSTRAINT);

            END_OFFSET = BEGIN_OFFSET + OFFSET_CONSTRAINT + 2;
        }


    }
}
