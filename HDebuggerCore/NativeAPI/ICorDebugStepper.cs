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
    [Guid("CC7BCAEC-8A68-11d2-983C-0000F808342D")]
    public interface ICorDebugStepper
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsActive();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Deactivate();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetInterceptMask(
                    [In, MarshalAs(UnmanagedType.I4)]CorDebugIntercept mask);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUnmappedStopMask(
            [In, MarshalAs(UnmanagedType.I4)]CorDebugUnmappedStop mask);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Step(
            [In, MarshalAs(UnmanagedType.Bool)]bool stepIn);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void StepRange(
            [In, MarshalAs(UnmanagedType.Bool)]bool stepIn,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] COR_DEBUG_STEP_RANGE[] ranges,
            [In, MarshalAs(UnmanagedType.U4)]uint rangeCount);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void StepOut();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetRangeIL(
            [In, MarshalAs(UnmanagedType.Bool)]bool il);
    }
}
