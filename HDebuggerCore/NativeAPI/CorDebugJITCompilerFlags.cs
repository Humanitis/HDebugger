﻿namespace HDebuggerCore.NativeAPI
{
    /// <summary>
    /// 
    /// </summary>
    [System.Flags]
    public enum CorDebugJITCompilerFlags:int
    {
        CORDEBUG_JIT_DEFAULT = 0x1,
        CORDEBUG_JIT_DISABLE_OPTIMIZATION = 0x3,
        CORDEBUG_JIT_ENABLE_ENC = 0x7
    }
}
