using HDebuggerCore.NativeAPI;
using HDebuggerCore.Wrappers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestDebugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Process powershell = Process.GetProcessesByName("powershell").First();


            ICLRMetaHost clrMetaHost = WrapperHelper.CLRCreateInstance<ICLRMetaHost>(Constants.CLSID_CLRMetaHost, Constants.IID_ICLMetaHost);


            IEnumUnknown runtimes = clrMetaHost.EnumerateLoadedRuntimes(powershell.Handle);

            ICLRRuntimeInfo runtime = WrapperHelper.GetRuntime(runtimes, null);

            IntPtr icorDebugPtr = runtime.GetInterface(Constants.CLSID_CLRDebuggingLegacy, Constants.IID_ICorDebug);
            ICorDebug corDebug = (ICorDebug)Marshal.GetTypedObjectForIUnknown(icorDebugPtr, typeof(ICorDebug));
            corDebug.Initialize();
            corDebug.SetManagedHandler(new TestManagedCallback());


            ICorDebugProcess corDebugProcess = corDebug.DebugActiveProcess(powershell.Id, false);

            Console.Read();
        }




















        /// <summary>
        /// 
        /// </summary>
        private sealed class TestManagedCallback : CorDebugManagedCallbackBase
        {


            public override void CreateProcess(ICorDebugProcess process)
            {
                Console.WriteLine("Create process with id {0}",process.GetID());

                process.Continue(false);
            }


            public override void CreateThread(ICorDebugAppDomain appDomain, ICorDebugThread thread)
            {
                Console.WriteLine("Create thread with id {0}",thread.GetID());

                appDomain.Continue(false);
            }


            public override void LoadModule(ICorDebugAppDomain appDomain, ICorDebugModule module)
            {
                Console.WriteLine("Load module");

                appDomain.Continue(false);
            }



            public override void CreateAppDomain(ICorDebugProcess process, ICorDebugAppDomain appDomain)
            {
                Console.WriteLine("Create app domain");

                process.Continue(false);
            }


            public override void LoadAssembly(ICorDebugAppDomain appDomain, ICorDebugAssembly assembly)
            {
                StringBuilder assemblyName = new StringBuilder(256);
                uint resultSizeOfassemblyName;
                assembly.GetName((uint)assemblyName.Capacity + 1, out resultSizeOfassemblyName, assemblyName);

                Console.WriteLine("Load assembly {0}", assemblyName.ToString());

                appDomain.Continue(false);
            }
        }
    }
}
