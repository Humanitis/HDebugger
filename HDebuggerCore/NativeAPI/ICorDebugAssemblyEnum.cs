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
    [Guid("4a2a1ec9-85ec-4bfb-9f15-a89fdfe0fe83")]
    public interface ICorDebugAssemblyEnum : ICorDebugEnum
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Next( 
            [In,MarshalAs(UnmanagedType.U4)]uint bufferSize,
            [Out, In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ref  ICorDebugAssembly[] buffer,
            [Out,MarshalAs(UnmanagedType.U4)]out uint resultSize);
    }
}
