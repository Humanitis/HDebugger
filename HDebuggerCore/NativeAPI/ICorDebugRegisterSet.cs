namespace HDebuggerCore.NativeAPI
{
    using System;
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
    [Guid("CC7BCB0B-8A68-11d2-983C-0000F808342D")]
    public interface ICorDebugRegisterSet
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.U8)]
         ulong GetRegistersAvailable();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.U8,SizeParamIndex=1)]
       ulong[] GetRegisters( 
            [In, MarshalAs(UnmanagedType.U8)]ulong mask,
            [In, MarshalAs(UnmanagedType.U4)]uint regCount);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetRegisters( 
            [In, MarshalAs(UnmanagedType.U8)]ulong mask,
            [In, MarshalAs(UnmanagedType.U4)]uint regCount,
            [In, MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.U8,SizeParamIndex=1)]ulong[] regBuffer);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.I1,SizeParamIndex=0)]
        byte[] GetThreadContext( 
            [In, MarshalAs(UnmanagedType.U4)]uint contextSize);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetThreadContext( 
            [In, MarshalAs(UnmanagedType.U4)]uint contextSize,
            [In, MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.I1,SizeParamIndex=0)] byte[] context);
    }
}
