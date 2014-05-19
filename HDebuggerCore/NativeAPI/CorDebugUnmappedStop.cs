namespace HDebuggerCore.NativeAPI
{
    /// <summary>
    /// 
    /// </summary>
    [System.Flags]
    public enum CorDebugUnmappedStop:int
    {
        STOP_NONE = 0x0,
        STOP_PROLOG = 0x01,
        STOP_EPILOG = 0x02,
        STOP_NO_MAPPING_INFO = 0x04,
        STOP_OTHER_UNMAPPED = 0x08,
        STOP_UNMANAGED = 0x10,
        STOP_ALL = 0xffff,
    }
}
