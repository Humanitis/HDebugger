using System;


namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// Flags for ManifestResource [ManifestResourceAttributes]
    /// </summary>
    [Flags()]
    public enum ManifestResourceAttributesFlag : uint
    {
        /* VisibilityMask 0x0007 These 3 bits contain one of the following values:*/
        PUBLIC = 0x0001,// The Resource is exported from the Assembly
        PRIVATE = 0x0002,// The Resource is private to the Assembly
    }
}
