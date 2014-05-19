namespace HDebuggerCore.NativeAPI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security;




    /// <summary>
    /// 
    /// </summary>
    [ComImport]
    [SecurityCritical]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3d6f5f61-7538-11d3-8d5b-00104b35e7ef")]
    public interface ICorDebug
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool Initialize();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool Terminate();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool SetManagedHandler([In, MarshalAs(UnmanagedType.Interface)]ICorDebugManagedCallback callback);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool SetUnmanagedHandler([In, MarshalAs(UnmanagedType.Interface)]ICorDebugUnmanagedCallback callback);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugProcess CreateProcess(
            [In, MarshalAs(UnmanagedType.LPWStr)]string applicationName,
            [In, MarshalAs(UnmanagedType.LPWStr)]string commandLine,
            [In, MarshalAs(UnmanagedType.Struct)]SECURITY_ATTRIBUTES processAttributes,
            [In, MarshalAs(UnmanagedType.Struct)]SECURITY_ATTRIBUTES threadAttributes,
            [In, MarshalAs(UnmanagedType.Bool)]bool inheritHandles,
            [In, MarshalAs(UnmanagedType.I4)] ProcessCreationFlags dwCreationFlags,
            [In]  IntPtr environment,
            [In, MarshalAs(UnmanagedType.LPWStr)]string currentDirectory,
            [In, MarshalAs(UnmanagedType.Struct)]STARTUPINFO startupInfo,
            [In, MarshalAs(UnmanagedType.Struct)]PROCESS_INFORMATION processInformation,
            [In, MarshalAs(UnmanagedType.I4)]CorDebugCreateProcessFlags debuggingFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugProcess DebugActiveProcess(
            [In, MarshalAs(UnmanagedType.I4)] int processId,
            [In, MarshalAs(UnmanagedType.Bool)]bool win32Attach);
   

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugProcessEnum EnumerateProcesses();


        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugProcess GetProcess(
            [In, MarshalAs(UnmanagedType.I4)] int processId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool CanLaunchOrAttach(
            [In, MarshalAs(UnmanagedType.I4)] int processId,
            [In, MarshalAs(UnmanagedType.Bool)]bool win32DebuggingEnabled);
    }
}
