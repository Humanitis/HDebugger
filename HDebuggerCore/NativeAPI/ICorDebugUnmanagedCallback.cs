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
    [Guid("5263E909-8CB5-11d3-BD2F-0000F80849BD")]
    public interface ICorDebugUnmanagedCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DebugEvent(
            [In, MarshalAs(UnmanagedType.LPStruct)]UIntPtr debugEvent,
            [In, MarshalAs(UnmanagedType.Bool)]bool outOfBand);
    }
}
