using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    [Flags()]
    public enum TypeAttributesFlag
    {
        /*Visibility attributes
        VisibilityMask 0x00000007 Use this mask to retrieve visibility information.
        These 3 bits contain one of the following
        values:*/
        NOT_PUBLIC = 0x00000000,// Class has no public scope
        PUBLIC = 0x00000001,// Class has public scope
        NESTED_PUBLIC = 0x00000002,// Class is nested with public visibility
        NESTED_PRIVATE = 0x00000003,// Class is nested with private visibility
        NESTED_FAMILY = 0x00000004,// Class is nested with family visibility
        NESTED_ASSEMBLY = 0x00000005,// Class is nested with assembly visibility
        NESTED_FAM_AND_ASSEM = 0x00000006,// Class is nested with family and assembly visibility
        NESTED_FAM_OR_ASSEM = 0x00000007,// Class is nested with family or assembly visibility
        /*Class layout attributes
        LayoutMask 0x00000018 Use this mask to retrieve class layout
        information. These 2 bits contain one of the
        following values:*/
        AUTO_LAYOUT = 0x00000000,// Class fields are auto-laid out
        SEQUENTIAL_LAYOUT = 0x00000008,// Class fields are laid out sequentially
        EXPLICIT_LAYOUT = 0x00000010,// Layout is supplied explicitly
        /*Class semantics attributes
        ClassSemanticsMask 0x00000020 Use this mask to retrive class semantics
        information. This bit contains one of the
        following values:*/
        CLASS = 0x00000000,// Type is a class
        INTERFACE = 0x00000020,// Type is an interface Special semantics in addition to class semantics
        ABSTRACT = 0x00000080,// Class is abstract
        SEALED = 0x00000100,// Class cannot be extended
        SPECIAL_NAME = 0x00000400,// Class name is special Implementation Attributes
        IMPORT = 0x00001000,// Class/Interface is imported
        SERIALIZABLE = 0x00002000,// Reserved (Class is serializable)
        /*String formatting Attributes
        StringFormatMask 0x00030000 Use this mask to retrieve string information for
        native interop. These 2 bits contain one of the
        following values:*/
        ANSI_CLASS = 0x00000000,// LPSTR is interpreted as ANSI
        UNICODE_CLASS = 0x00010000,// LPSTR is interpreted as Unicode
        AUTO_CLASS = 0x00020000,// LPSTR is interpreted automatically
        CUSTOM_FORMAT_CLASS = 0x00030000,// A non-standard encoding specified by
        /*CustomStringFormatMask
        CustomStringFormatMask 0x00C00000 Use this mask to retrieve non-standard
        encoding information for native interop. The
        meaning of the values of these 2 bits is
        unspecified.*/
        /*Class Initialization Attributes*/
        BEFORE_FIELD_INIT = 0x00100000,// Initialize the class before first static field access
        /*Additional Flags*/
        RT_SPECIAL_NAME = 0x00000800,// CLI provides 'special' behavior, depending upon the name of the Type
        HAS_SECURITY = 0x00040000,// Type has security associate with it
    }
}
