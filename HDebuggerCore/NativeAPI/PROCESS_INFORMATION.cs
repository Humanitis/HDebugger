namespace HDebuggerCore.NativeAPI
{
    using Microsoft.Win32.SafeHandles;
    using System;
    using System.Runtime.InteropServices;




    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }
}
