﻿namespace HDebuggerCore.NativeAPI
{
    /// <summary>
    /// 
    /// </summary>
    [System.Flags]
    public enum CorDebugChainReason:int
    {
        CHAIN_NONE = 0x000,
        CHAIN_CLASS_INIT = 0x001,
        CHAIN_EXCEPTION_FILTER = 0x002,
        CHAIN_SECURITY = 0x004,
        CHAIN_CONTEXT_POLICY = 0x008,
        CHAIN_INTERCEPTION = 0x010,
        CHAIN_PROCESS_START = 0x020,
        CHAIN_THREAD_START = 0x040,
        CHAIN_ENTER_MANAGED = 0x080,
        CHAIN_ENTER_UNMANAGED = 0x100,
        CHAIN_DEBUGGER_EVAL = 0x200,
        CHAIN_CONTEXT_SWITCH = 0x400,
        CHAIN_FUNC_EVAL = 0x800
    }
}
