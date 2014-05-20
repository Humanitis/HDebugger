namespace HDebuggerCore.NativeAPI
{
    using System.Runtime.InteropServices;


    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_ACTIVE_FUNCTION
    {
        public ICorDebugAppDomain AppDomain;
        public ICorDebugModule Module;
        public ICorDebugFunction2 Function;
        public uint Offset;
        public uint Flags;
    }
}
