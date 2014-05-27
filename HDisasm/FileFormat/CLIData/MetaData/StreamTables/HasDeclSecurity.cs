using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// HasDeclSecurity: 2 bits to encode tag
    /// </summary>
    public enum HasDeclSecurityTag
    {
        TYPE_DEF = 0,
        METHOD_DEF = 1,
        ASSEMBLY = 2,
    }
}
