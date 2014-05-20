namespace HDebuggerCore.NativeAPI
{
    using System.Runtime.InteropServices;


    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_VERSION
    {
        public uint Major;
        public uint Minor;
        public uint Build;
        public uint SubBuild;
    }
}
