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
    [Guid("264EA0FC-2591-49AA-868E-835E6515323F")]
    public interface ICorDebugManagedCallback3
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CustomNotification(
           [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
           [In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain);
    }
}
