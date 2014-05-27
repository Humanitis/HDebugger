using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// Flags for ImplMap [PInvokeAttributes]
    /// </summary>
    [Flags()]
    public enum PInvokeAttributesFlag
    {
        NO_MANGLE = 0x0001,// PInvoke is to use the member name as specified
        /*Character set
        CharSetMask 0x0006 This is a resource file or other non-metadata-containing file.
        These 2 bits contain one of the following values:*/
        CHAR_SET_NOT_SPEC = 0x0000,
        CHAR_SET_ANSI = 0x0002,
        CHAR_SET_UNICODE = 0x0004,
        CHAR_SET_AUTO = 0x0006,
        /**/
        Supports_Last_Error = 0x0040,// Information about target function. Not relevant for fields
        /*Calling convention
        CallConvMask 0x0700 These 3 bits contain one of the following values:*/
        CALL_CONV_WINAPI = 0x0100,
        CALL_CONV_CDECL = 0x0200,
        CALL_CONV_STDCALL = 0x0300,
        CALL_CONV_THISCALL = 0x0400,
        CALL_CONV_FASTCALL = 0x0500,
    }
}
