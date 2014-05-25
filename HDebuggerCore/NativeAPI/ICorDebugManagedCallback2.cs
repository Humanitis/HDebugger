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
    [Guid("250E5EEA-DB5C-4C76-B6F3-8C46F12E3203")]
    public interface ICorDebugManagedCallback2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void FunctionRemapOpportunity(
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction oldFunction,
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction newFunction,
            [In, MarshalAs(UnmanagedType.U4)]uint oldILOffset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateConnection(
            [In, MarshalAs(UnmanagedType.Interface)]ICorDebugProcess process,
             [In, MarshalAs(UnmanagedType.U4)]uint connectionId,
            [In, MarshalAs(UnmanagedType.LPWStr)]string connName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ChangeConnection(
            [In, MarshalAs(UnmanagedType.Interface)]ICorDebugProcess process,
             [In, MarshalAs(UnmanagedType.U4)]uint connectionId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DestroyConnection(
            [In, MarshalAs(UnmanagedType.Interface)]ICorDebugProcess process,
             [In, MarshalAs(UnmanagedType.U4)]uint connectionId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Exception(
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFrame frame,
            [In, MarshalAs(UnmanagedType.U4)]uint offset,
            [In, MarshalAs(UnmanagedType.I4)] CorDebugExceptionCallbackType eventType,
            [In, MarshalAs(UnmanagedType.I4)] CorDebugExceptionFlags flags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ExceptionUnwind(
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In, MarshalAs(UnmanagedType.I4)] CorDebugExceptionUnwindCallbackType eventType,
            [In, MarshalAs(UnmanagedType.I4)] CorDebugExceptionFlags flags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void FunctionRemapComplete(
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction function);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void MDANotification(
            [In, MarshalAs(UnmanagedType.Interface)]ICorDebugController controller,
            [In, MarshalAs(UnmanagedType.Interface)]ICorDebugThread thread,
            [In, MarshalAs(UnmanagedType.Interface)]ICorDebugMDA MDA);
    }
}
