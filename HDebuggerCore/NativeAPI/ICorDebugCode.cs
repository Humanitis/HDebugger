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
    [Guid("CC7BCAF4-8A68-11d2-983C-0000F808342D")]
    public interface ICorDebugCode
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsIL();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugFunction GetFunction();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.U8)]
        ulong GetAddress();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.U4)]
        uint GetSize();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugFunctionBreakpoint CreateBreakpoint(
            [In, MarshalAs(UnmanagedType.U4)]uint offset);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCode(
            [In, MarshalAs(UnmanagedType.U4)]uint startOffset,
            [In, MarshalAs(UnmanagedType.U4)]uint endOffset,
            [In, MarshalAs(UnmanagedType.U4)]uint bufferAlloc,
            [Out, In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 2)]ref byte[] buffer,
            [Out, MarshalAs(UnmanagedType.U4)]out uint bufferSize);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.U4)]
        uint GetVersionNumber();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetILToNativeMapping(
            [In, MarshalAs(UnmanagedType.U4)]uint bufferSize,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSize,
            [Out, In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 0)]ref COR_DEBUG_IL_TO_NATIVE_MAP[] buffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetEnCRemapSequencePoints(
            [In, MarshalAs(UnmanagedType.U4)]uint bufferSize,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSize,
            [Out, In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4, SizeParamIndex = 0)]ref uint[] offsets);
    }
}
