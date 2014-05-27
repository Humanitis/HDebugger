using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// Implementation: 2 bits to encode tag
    /// </summary>
    public enum ImplementationTag
    {
        FILE = 0,
        ASSEMBLY_REF = 1,
        EXPORTED_TYPE = 2,
    }
}
