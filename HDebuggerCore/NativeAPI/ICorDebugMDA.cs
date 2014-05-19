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
    [Guid("CC726F2F-1DB7-459b-B0EC-05F01D841B42")]
    public interface ICorDebugMDA
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetName(
            [In, MarshalAs(UnmanagedType.U4)]uint bufferSize,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSize,
            [Out, In, MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 0)] StringBuilder name);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDescription(
            [In, MarshalAs(UnmanagedType.U4)]uint bufferSize,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSize,
            [Out, In, MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 0)] StringBuilder description);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetXML(
            [In, MarshalAs(UnmanagedType.U4)]uint bufferSize,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSize,
            [Out, In, MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 0)] StringBuilder xml);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFlags(
            [In, MarshalAs(UnmanagedType.I4)] CorDebugMDAFlags flags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.U4)]
        uint GetOSThreadId();
    }
}
