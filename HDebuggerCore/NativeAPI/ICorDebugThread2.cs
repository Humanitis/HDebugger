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
    [Guid("2BD956D9-7B07-4bef-8A98-12AA862417C5")]
    public interface ICorDebugThread2
    {
       [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetActiveFunctions( 
            [In, MarshalAs(UnmanagedType.U4)]uint bufferSize,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSize,
            [Out,In, MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.Struct,SizeParamIndex=0)]ref COR_ACTIVE_FUNCTION[] functions);
        

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.I4)]
        int GetConnectionID();
        

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.U8)]
        ulong GetTaskID();
        

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.I4)]
        int GetVolatileOSThreadID();
        

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void InterceptCurrentException(
            [In, MarshalAs(UnmanagedType.Interface)]ICorDebugFrame frame);
    }
}
