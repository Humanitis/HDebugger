using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// HasFieldMarshall: 1 bit to encode tag
    /// </summary>
    public enum HasFieldMarshallTag
    {
        FIELD = 0,
        PARAM = 1,
    }
}
