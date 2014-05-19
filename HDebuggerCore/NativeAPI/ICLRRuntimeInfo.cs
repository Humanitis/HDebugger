namespace HDebuggerCore.NativeAPI
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;




    /// <summary>
    /// 
    /// </summary>
    [ComImport]
    [SecurityCritical]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BD39D1D2-BA2F-486a-89B0-B4B0CB466891")]
    public interface ICLRRuntimeInfo
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetVersionString([Out, MarshalAs(UnmanagedType.LPWStr,SizeParamIndex=1)] StringBuilder buffer,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint bufferLength);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetRuntimeDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder buffer,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint bufferLength);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return:MarshalAs(UnmanagedType.Bool)]
        bool IsLoaded(IntPtr processId);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LoadErrorString( 
            [In,  MarshalAs(UnmanagedType.U4)]uint resourceId,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder buffer,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint bufferLength,
            [In,  MarshalAs(UnmanagedType.I8)]long localeID);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Assembly LoadLibrary([In, MarshalAs(UnmanagedType.LPWStr)] string dllName);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr GetProcAddress([In,MarshalAs(UnmanagedType.LPWStr)]string procName);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr GetInterface([In, MarshalAs(UnmanagedType.LPStruct)]Guid clsid, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return:MarshalAs(UnmanagedType.Bool)]
        bool IsLoadable();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDefaultStartupFlags( 
            [In,MarshalAs(UnmanagedType.I4)] int startupFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string hostConfigFile);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDefaultStartupFlags( 
            [Out,MarshalAs(UnmanagedType.I4)] out int startupFlags,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder hostConfigFile,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint hostConfigFileLengt);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        bool BindAsLegacyV2Runtime();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [PreserveSig]
        bool IsStarted([Out]out bool started,
            [Out,MarshalAs(UnmanagedType.I4)] out int startupFlags);
    }
}
