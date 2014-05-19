namespace HDebuggerCore.NativeAPI
{
    using System;
    using System.Runtime.InteropServices;



    /// <summary>
    /// 
    /// </summary>
    [ComImport]
    [Guid("00000100-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumUnknown
    {
        [PreserveSig]
        HRESULT Next([In, MarshalAs(UnmanagedType.U4)] uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IntPtr[] rgelt, [Out, MarshalAs(UnmanagedType.U4)] out uint pceltFetched);

        [PreserveSig]
        HRESULT Skip([In] int celt);

        [PreserveSig]
        HRESULT Reset();

        IEnumUnknown Clone();
    }
}
