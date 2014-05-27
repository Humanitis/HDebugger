using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    [Flags()]
    public enum EventAttributesFlag
    {
        SPECIAL_NAME = 0x0200,// Event is special.
        RT_SPECIAL_NAME = 0x0400,// CLI provides 'special' behavior, depending upon the name of the event
    }
}
