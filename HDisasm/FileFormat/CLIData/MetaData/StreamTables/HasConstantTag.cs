using System;


namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// HasConstant: 2 bits to encode tag
    /// </summary>
    public enum HasConstantTag
    {
        FIELD = 0x01,
        PARAM = 0x02,
        PROPERTY = 0x03,
    }
}
