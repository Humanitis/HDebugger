using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// Flags for files [FileAttributes]
    /// </summary>
    [Flags()]
    public enum FileAttributesFlag : uint
    {
        CONTAINS_META_DATA = 0x0000, //This is not a resource file
        CONTAINS_NO_META_DATA = 0x0001,// This is a resource file or other non-metadata-containing file
    }
}
