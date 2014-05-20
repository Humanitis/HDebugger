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
    [Guid("AD1B3588-0EF0-4744-A496-AA09A9F80371")]
    public interface ICorDebugProcess2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
         ICorDebugThread2 GetThreadForTaskID( 
            [In, MarshalAs(UnmanagedType.U8)]ulong taskid);
        

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Struct)]
        COR_VERSION GetVersion();
        

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUnmanagedBreakpoint( 
            [In, MarshalAs(UnmanagedType.U8)]ulong address,
            [In, MarshalAs(UnmanagedType.U4)]uint bufsize,
            [Out,In, MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.I1,SizeParamIndex=1)]ref byte[] buffer,
            [Out, MarshalAs(UnmanagedType.U4)]out uint bufLen);
        

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ClearUnmanagedBreakpoint( 
            [In, MarshalAs(UnmanagedType.U8)]ulong address);
        

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDesiredNGENCompilerFlags( 
            [In, MarshalAs(UnmanagedType.I4)]CorDebugJITCompilerFlags  flags);
        

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.I4)]
        CorDebugJITCompilerFlags GetDesiredNGENCompilerFlags();


        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugReferenceValue GetReferenceValueFromGCHandle(
            [In, MarshalAs(UnmanagedType.I4)]UIntPtr handle);
    }
}
