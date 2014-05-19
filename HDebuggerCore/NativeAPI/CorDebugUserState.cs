namespace HDebuggerCore.NativeAPI
{
    using System;



    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum CorDebugUserState:int
    {
        USER_STOP_REQUESTED = 0x1,
        USER_SUSPEND_REQUESTED = 0x2,
        USER_BACKGROUND = 0x4,
        USER_UNSTARTED = 0x8,
        USER_STOPPED = 0x10,
        USER_WAIT_SLEEP_JOIN = 0x20,
        USER_SUSPENDED = 0x40,
        USER_UNSAFE_POINT = 0x80
    }
}
