using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// Flags for fields [FieldAttributes]
    /// </summary>
    [Flags()]
    public enum FieldAttributesFlag
    {
        /*FieldAccessMask 0x0007 These 3 bits contain one of the following values:*/
        COMPILER_CONTROLLED = 0x0000,// Member not referenceable
        PRIVATE = 0x0001,// Accessible only by the parent type
        FAM_AND_ASSEM = 0x0002,// Accessible by sub-types only in this Assembly
        ASSEMBLY = 0x0003,// Accessibly by anyone in the Assembly
        FAMILY = 0x0004,// Accessible only by type and sub-types
        FAM_OR_ASSEM = 0x0005,// Accessibly by sub-types anywhere, plus anyone in assembly
        PUBLIC = 0x0006,//Accessibly by anyone who has visibility to this scope field contract attributes
        STATIC = 0x0010,// Defined on type, else per instance
        INIT_ONLY = 0x0020,// Field can only be initialized, not written to after init
        LITERAL = 0x0040,// Value is compile time constant
        NOT_SERIALIZED = 0x0080,// Reserved (to indicate this field should not be serialized when type is remoted)
        SPECIAL_NAME = 0x0200,// Field is special
        /*Interop Attributes*/
        PINVOKE_IMPL = 0x2000,// Implementation is forwarded through PInvoke.
        /*Additional flags*/
        RT_SPECIAL_NAME = 0x0400,// CLI provides 'special' behavior, depending upon the name of the field
        HAS_FIELD_MARSHAL = 0x1000,// Field has marshalling information
        HAS_DEFAULT = 0x8000,// Field has default
        HAS_FIELD_RVA = 0x0100,// Field has RVA
    }
}
