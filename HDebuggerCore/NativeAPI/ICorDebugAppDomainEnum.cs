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
    [Guid("63ca1b24-4359-4883-bd57-13f815f58744")]
    public interface ICorDebugAppDomainEnum : ICorDebugEnum
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Next(
            [In, MarshalAs(UnmanagedType.U4)]uint bufferSize,
            [Out, In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] ref  ICorDebugAppDomain[] buffer,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSize);
    }
}
