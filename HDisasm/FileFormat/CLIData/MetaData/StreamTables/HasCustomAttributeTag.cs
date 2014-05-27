using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// HasCustomAttribute: 5 bits to encode tag
    /// </summary>
    public enum HasCustomAttributeTag
    {
        METHOD_DEF = 0,
        FIELD = 1,
        TYPE_REF = 2,
        TYPE_DEF = 3,
        PARAM = 4,
        INTERFACE_IMPL = 5,
        MEMBER_REF = 6,
        MODULE = 7,
        PERMISSION = 8,
        PROPERTY = 9,
        EVENT = 10,
        STAND_ALONE_SIG = 11,
        MODULE_REF = 12,
        TYPE_SPEC = 13,
        ASSEMBLY = 14,
        ASSEMBLY_REF = 15,
        FILE = 16,
        EXPORTED_TYPE = 17,
        MANIFEST_RESOURCE = 18,
    }
}
