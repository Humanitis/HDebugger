﻿namespace HDebuggerCore.NativeAPI
{
    using System.Runtime.InteropServices;


    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=4)]
    public struct COR_DEBUG_IL_TO_NATIVE_MAP
    {
        public uint ilOffset;
        public uint nativeStartOffset;
        public uint nativeEndOffset;
    }
}
