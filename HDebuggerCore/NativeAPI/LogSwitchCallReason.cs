namespace HDebuggerCore.NativeAPI
{
    /// <summary>
    /// 
    /// </summary>
    public enum LogSwitchCallReason:uint
    {
        SWITCH_CREATE = 0,
        SWITCH_MODIFY = (SWITCH_CREATE + 1),
        SWITCH_DELETE = (SWITCH_MODIFY + 1) 
    }
}
