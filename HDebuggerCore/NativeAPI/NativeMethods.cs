namespace HDebuggerCore.NativeAPI
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;


    /// <summary>
    /// 
    /// </summary>
    public static class NativeMethods
    {
        #region Debugger Api
        /// <summary>
        /// Provides one of three interfaces: ICLRMetaHost, ICLRMetaHostPolicy, or ICLRDebugging.
        /// </summary>
        /// <param name="clsid"></param>
        /// <param name="riid"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        [DllImport("MSCorEE", CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern IntPtr CLRCreateInstance([In, MarshalAs(UnmanagedType.LPStruct)]Guid clsid, [In, MarshalAs(UnmanagedType.LPStruct)]Guid riid);
        #endregion


        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);

    }
}
