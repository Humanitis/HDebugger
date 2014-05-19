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
    [Guid("3d6f5f64-7538-11d3-8d5b-00104b35e7ef")]
    public interface ICorDebugProcess :  ICorDebugController
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.U4)]
        uint GetID();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.U4)]
        uint GetHandle();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ClearCurrentException(
            [In, MarshalAs(UnmanagedType.U4)]uint threadId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugValue GetObject();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugThread GetThread(
            [In, MarshalAs(UnmanagedType.U4)]uint threadId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugObjectEnum EnumerateObjects();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsTransitionStub(
            [In, MarshalAs(UnmanagedType.U8)]ulong address);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsOSSuspended(
            [In, MarshalAs(UnmanagedType.U4)]uint threadId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetThreadContext(
            [In, MarshalAs(UnmanagedType.U4)]uint threadId,
            [In, MarshalAs(UnmanagedType.U4)]uint contextSize,
            [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]ref byte[] context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetThreadContext(
            [In, MarshalAs(UnmanagedType.U4)]uint threadId,
            [In, MarshalAs(UnmanagedType.U4)]uint contextSize,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]byte[] context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.I4)]
        int ReadMemory(
            [In, MarshalAs(UnmanagedType.U8)]ulong address,
            [In, MarshalAs(UnmanagedType.I4)]int size,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]out byte[] buffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.I4)]
        int WriteMemory(
            [In, MarshalAs(UnmanagedType.U8)]ulong address,
            [In, MarshalAs(UnmanagedType.I4)]int size,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]byte[] buffer);


        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnableLogMessages(
            [In, MarshalAs(UnmanagedType.Bool)]bool onOff);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ModifyLogSwitch(
            [In, MarshalAs(UnmanagedType.LPStr)]string logSwitchName,
             [In, MarshalAs(UnmanagedType.I8)]long lLevel);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugAppDomainEnum EnumerateAppDomains();


        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugThread ThreadForFiberCookie(
            [In, MarshalAs(UnmanagedType.U4)]uint fiberCookie);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.U4)]
        uint GetHelperThreadID();
    }
}
