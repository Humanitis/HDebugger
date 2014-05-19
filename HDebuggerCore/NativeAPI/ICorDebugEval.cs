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
    [Guid("CC7BCAF6-8A68-11d2-983C-0000F808342D")]
    public interface ICorDebugEval
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CallFunction( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugFunction function,
            [In,MarshalAs(UnmanagedType.I4)] uint argsCount,
            [In,MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.Interface,SizeParamIndex=1)] ICorDebugValue[] args);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewObject( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugFunction function,
            [In,MarshalAs(UnmanagedType.I4)] uint argsCount,
            [In,MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.Interface,SizeParamIndex=1)] ICorDebugValue[] args);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return:MarshalAs(UnmanagedType.Interface)]
        ICorDebugClass NewObjectNoConstructor();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewString( 
            [In,MarshalAs(UnmanagedType.LPWStr)]string newString);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NewArray( 
            [In,MarshalAs(UnmanagedType.Interface)] CorElementType elementType,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugClass elementClass,
            [In,MarshalAs(UnmanagedType.I4)] uint rank,
            [In,MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.U4,SizeParamIndex=2)] uint[] dims,
            [In,MarshalAs(UnmanagedType.LPArray,ArraySubType=UnmanagedType.U4,SizeParamIndex=2)] uint[] lowBounds);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return:MarshalAs(UnmanagedType.Bool)]
        bool IsActive();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Abort();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return:MarshalAs(UnmanagedType.Interface)]
        ICorDebugValue GetResult();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return:MarshalAs(UnmanagedType.Interface)]
        ICorDebugThread GetThread();
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return:MarshalAs(UnmanagedType.Interface)]
        ICorDebugValue CreateValue( 
            [In,MarshalAs(UnmanagedType.Interface)] CorElementType elementType,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugClass elementClass);
    }
}
