using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public enum TypeMetaData:int
    {
        ASSEMBLY=0x20,
        ASSEMBLY_OS=0x22,
        ASSEMBLY_PROCESSOR=0x21,
        ASSEMBLY_REF=0x23,
        ASSEMBLY_REF_OS=0x25,
        ASSEMBLY_REF_PROCESSOR=0x24,
        CLASS_LAYOUT=0x0F,
        CONSTANT=0x0B,
        CUSTOM_ATTRIBUTE=0x0C,
        DECL_SECURITY=0x0E,
        EVENT_MAP=0x12,
        EVENT=0x14,
        EXPORTED_TYPE=0x27,
        FIELD=0x04,
        FIELD_LAYOUT=0x10,
        FIELD_MARSHAL=0x0D,
        FIELD_RVA=0x1D,
        FILE=0x26,
        GENERIC_PARAM=0x2A,
        GENERIC_PARAM_CONSTRAINT=0x2C,
        IMPL_MAP=0x1C,
        INTERFACE_IMPL=0x09,
        MANIFEST_RESOURCE=0x28,
        MEMBER_REF=0x0A,
    }
}
