namespace HDebuggerCore.NativeAPI
{
    using System;


    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum CorDebugThreadState:int
    {
        THREAD_RUN = 0,
        THREAD_SUSPEND = (THREAD_RUN + 1)
    }
}
