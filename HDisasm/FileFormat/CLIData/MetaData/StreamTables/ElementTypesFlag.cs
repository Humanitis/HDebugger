﻿#region description
/*The following table lists the values for ELEMENT_TYPE constants. These are used extensively in metadata
signature blobs*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public enum ElementTypesFlag
    {
        ELEMENT_TYPE_END = 0x00, //Marks end of a list
        ELEMENT_TYPE_VOID = 0x01,
        ELEMENT_TYPE_BOOLEAN = 0x02,
        ELEMENT_TYPE_CHAR = 0x03,
        ELEMENT_TYPE_I1 = 0x04,
        ELEMENT_TYPE_U1 = 0x05,
        ELEMENT_TYPE_I2 = 0x06,
        ELEMENT_TYPE_U2 = 0x07,
        ELEMENT_TYPE_I4 = 0x08,
        ELEMENT_TYPE_U4 = 0x09,
        ELEMENT_TYPE_I8 = 0x0a,
        ELEMENT_TYPE_U8 = 0x0b,
        ELEMENT_TYPE_R4 = 0x0c,
        ELEMENT_TYPE_R8 = 0x0d,
        ELEMENT_TYPE_STRING = 0x0e,
        ELEMENT_TYPE_PTR = 0x0f, // Followed by type
        ELEMENT_TYPE_BYREF = 0x10, // Followed by type
        ELEMENT_TYPE_VALUETYPE = 0x11, // Followed by TypeDef or TypeRef token
        ELEMENT_TYPE_CLASS = 0x12, // Followed by TypeDef or TypeRef token
        ELEMENT_TYPE_VAR = 0x13, // Generic parameter in a generic type definition,represented as number
        ELEMENT_TYPE_ARRAY = 0x14, // type rank boundsCount bound1 … loCount lo1 …
        ELEMENT_TYPE_GENERICINST = 0x15, // Generic type instantiation. Followed by type typearg-count type-1 ... type-n
        ELEMENT_TYPE_TYPEDBYREF = 0x16,
        ELEMENT_TYPE_I = 0x18, // System.IntPtr
        ELEMENT_TYPE_U = 0x19, // System.UIntPtr
        ELEMENT_TYPE_FNPTR = 0x1b, // Followed by full method signature
        ELEMENT_TYPE_OBJECT = 0x1c, // System.Object
        ELEMENT_TYPE_SZARRAY = 0x1d, // Single-dim array with 0 lower bound
        ELEMENT_TYPE_MVAR = 0x1e,// Generic parameter in a generic method definition,represented as number
        ELEMENT_TYPE_CMOD_REQD = 0x1f,// Required modifier : followed by a TypeDef or TypeRef token
        ELEMENT_TYPE_CMOD_OPT = 0x20,// Optional modifier : followed by a TypeDef or TypeRef token
        ELEMENT_TYPE_INTERNAL = 0x21,// Implemented within the CLI
        ELEMENT_TYPE_MODIFIER = 0x40,// Or’d with following element types
        ELEMENT_TYPE_SENTINEL = 0x41,// Sentinel for vararg method signature
        ELEMENT_TYPE_PINNED = 0x45,// Denotes a local variable that points at a pinned object
        ELEMENT_SYSTEM_TYPE = 0x50,// Indicates an argument of type System.Type.
        ELEMENT_BOXED_OBJECT = 0x51,// Used in custom attributes to specify a boxed object.
        RESERVED = 0x52,// Reserved
        ELEMENT_FIELD = 0x53,// Used in custom attributes to indicate a FIELD
        ELEMENT_PROPERTY = 0x54,// Used in custom attributes to indicate a PROPERTY
        ELEMENT_ENUM = 0x55,// Used in custom attributes to specify an enum
    }
}
