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
    [Guid("df59507c-d47a-459e-bce2-6427eac8fd06")]
    public interface ICorDebugAssembly 
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugProcess GetProcess();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugAppDomain GetAppDomain();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugModuleEnum EnumerateModules();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCodeBase(
            [In, MarshalAs(UnmanagedType.U4)]uint nameSize,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSizeName,
            [Out, MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 0)] StringBuilder name);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetName(
            [In, MarshalAs(UnmanagedType.U4)]uint nameSize,
            [Out, MarshalAs(UnmanagedType.U4)]out uint resultSizeName,
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 0)] StringBuilder name);
    }
}
