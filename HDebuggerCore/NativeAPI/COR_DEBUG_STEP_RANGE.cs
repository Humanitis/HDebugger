namespace HDebuggerCore.NativeAPI
{
    using System.Runtime.InteropServices;


    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=4)]
    public struct COR_DEBUG_STEP_RANGE
    {
        public uint startOffset;
        public uint endOffset;
    }
}
