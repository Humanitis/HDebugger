using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// TypeOrMethodDef: 1 bit to encode tag
    /// </summary>
    public enum TypeOrMethodDefTag
    {
        TYPE_DEF = 0,
        METHOD_DEF = 1,
    }
}
