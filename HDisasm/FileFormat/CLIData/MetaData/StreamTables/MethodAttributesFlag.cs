using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// Flags for methods [MethodAttributes]
    /// </summary>
    [Flags()]
    public enum MethodAttributesFlag
    {
        /* MemberAccessMask 0x0007 These 3 bits contain one of the following values:*/
        COMPILER_CONTROLLED = 0x0000,// Member not referenceable
        PRIVATE = 0x0001,// Accessible only by the parent type
        FAM_AND_ASSEM = 0x0002,// Accessible by sub-types only in this Assembly
        ASSEM = 0x0003,// Accessibly by anyone in the Assembly
        FAMILY = 0x0004,// Accessible only by type and sub-types
        FAM_OR_ASSEM = 0x0005,// Accessibly by sub-types anywhere, plus anyone in assembly
        PUBLIC = 0x0006,// Accessibly by anyone who has visibility to this scope
        STATIC = 0x0010,// Defined on type, else per instance
        FINAL = 0x0020,// Method cannot be overridden
        VIRTUAL = 0x0040,// Method is virtual
        HIDE_BY_SIG = 0x0080,// Method hides by name+sig, else just by name
        /*VtableLayoutMask 0x0100 Use this mask to retrieve vtable attributes. This bit contains
        one of the following values:*/
        REUSE_SLOT = 0x0000,// Method reuses existing slot in vtable
        NEW_SLOT = 0x0100,// Method always gets a new slot in the vtable
        STRICT = 0x0200,// Method can only be overriden if also accessible
        ABSTRACT = 0x0400,// Method does not provide an implementation
        SPECIAL_NAME = 0x0800,// Method is special
        /*Interop attributes*/
        PINVOKE_IMPL = 0x2000,// Implementation is forwarded through PInvoke
        UNMANAGED_EXPORT = 0x0008,// Reserved: shall be zero for conforming implementations
        /*Additional flags*/
        RT_SPECIAL_NAME = 0x1000,// CLI provides 'special' behavior, depending upon the name of the method
        HAS_SECURITY = 0x4000,// Method has security associate with it
        REQUIRE_SEC_OBJECT = 0x8000,// Method calls another method containing security code.
    }
}
