#region description
/*
 * DeclSecurity : 0x0E
 * 
 * Security attributes, which derive from System.Security.Permissions.SecurityAttribute (see Partition IV),
can be attached to a TypeDef, a Method, or an Assembly. All constructors of this class shall take a
System.Security.Permissions.SecurityAction value as their first parameter, describing what should be
done with the permission on the type, method or assembly to which it is attached. Code access security
attributes, which derive from System.Security.Permissions. CodeAccessSecurityAttribute, can have any
of the security actions.
These different security actions are encoded in the DeclSecurity table as a 2-byte enum (see below). All
security custom attributes for a given security action on a method, type, or assembly shall be gathered together,
and one System.Security.PermissionSet instance shall be created, stored in the Blob heap, and referenced
from the DeclSecurity table.
[Note: The general flow from a compiler’s point of view is as follows. The user specifies a custom attribute
through some language-specific syntax that encodes a call to the attribute’s constructor. If the attribute’s type is
derived (directly or indirectly) from System.Security.Permissions.SecurityAttribute then it is a security
custom attribute and requires special treatment, as follows (other custom attributes are handled by simply
recording the constructor in the metadata as described in §22.10). The attribute object is constructed, and
provides a method (CreatePermission) to convert it into a security permission object (an object derived from
System.Security.Permission). All the permission objects attached to a given metadata item with the same
security action are combined together into a System.Security.PermissionSet. This permission set is
converted into a form that is ready to be stored in XML using its ToXML method to create a
System.Security.SecurityElement. Finally, the XML that is required for the metadata is created using the
ToString method on the security element. end note]
The DeclSecurity table has the following columns:
• Action (a 2-byte value)
• Parent (an index into the TypeDef, MethodDef, or Assembly table; more precisely, a
HasDeclSecurity (§24.2.6) coded index)
• PermissionSet (an index into the Blob heap)
Action is a 2-byte representation of Security Actions (see System.Security.SecurityAction in Partition IV).
The values 0–0xFF are reserved for future standards use. Values 0x20–0x7F and 0x100–0x07FF are for uses
where the action can be ignored if it is not understood or supported. Values 0x80–0xFF and 0x0800–0xFFFF
are for uses where the action shall be implemented for secure operation; in implementations where the action is
not available, no access to the assembly, type, or method shall be permitted.
 
 
 1. Action shall have only those values set that are specified [ERROR]
2. Parent shall be one of TypeDef, MethodDef, or Assembly. That is, it shall index a valid row in
the TypeDef table, the MethodDef table, or the Assembly table. [ERROR]
3. If Parent indexes a row in the TypeDef table, that row should not define an Interface. The
security system ignores any such parent; compilers should not emit such permissions sets.
[WARNING]
4. If Parent indexes a TypeDef, then its TypeDef.Flags.HasSecurity bit shall be set [ERROR]
5. If Parent indexes a MethodDef, then its MethodDef.Flags.HasSecurity bit shall be set [ERROR]
6. PermissionSet shall index a 'blob' in the Blob heap [ERROR]
7. The format of the 'blob' indexed by PermissionSet shall represent a valid, encoded CLI object
graph. (The encoded form of all standardized permissions is specified in Partition IV.) [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STDeclSecurityRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_ACTION = 0UL;
        private static readonly ulong OFFSET_PARENT = 2UL;
        private static readonly ulong OFFSET_PERMISSION_SET = 4UL;

        private ushort _action;
        private ushort _parent;
        private uint _permissionSet;
        private HasDeclSecurityTag _parentTable;

        public ushort Action
        {
            get { return _action; }
            private set { _action = value; }
        }
        public ushort Parent
        {
            get { return _parent; }
            private set { _parent = value; _parentTable = (HasDeclSecurityTag)(_parent >> 14); }
        }
        public uint PermissionSet
        {
            get { return _permissionSet; }
            private set { _permissionSet = value; }
        }
        public HasDeclSecurityTag ParentTable
        {
            get { return _parentTable; }
        }

        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STDeclSecurityRow(reader, beginOffset, mediator, heapSizes);
        }

        private STDeclSecurityRow()
        { }
        protected STDeclSecurityRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.DECL_SECURITY;

            Action = reader[BEGIN_OFFSET + OFFSET_ACTION];
            Parent = reader.getUShort(BEGIN_OFFSET + OFFSET_PARENT);


            ulong blobSizeIndex = HeapSizes.WideOfBlobHeap();
            PermissionSet = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_PERMISSION_SET, blobSizeIndex, blobSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_PERMISSION_SET + blobSizeIndex;
        }

    }
}
