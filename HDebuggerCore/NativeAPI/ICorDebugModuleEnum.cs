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
    [Guid("CC7BCB09-8A68-11d2-983C-0000F808342D")]
    public interface ICorDebugModuleEnum : ICorDebugEnum
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Next(
            [In, MarshalAs(UnmanagedType.U4)]uint bufferSize,
            [Out, In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ref ICorDebugModule[] buffer,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSize);
    }
}
