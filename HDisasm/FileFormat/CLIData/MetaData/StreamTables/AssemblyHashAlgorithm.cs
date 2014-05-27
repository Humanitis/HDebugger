using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public enum AssemblyHashAlgorithm : uint
    {
        NONE = 0x0000,
        RESERVED_MD5 = 0x8003,
        SHA1 = 0x8004,
    }
}
