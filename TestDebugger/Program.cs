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

            CorDebug debug = new CorDebug(powershell);

            debug.CreateAppDomainEvent += debug_CreateAppDomain;
            debug.CreateThreadEvent += debug_CreateThread;


            debug.Debug();

            Console.Read();
        }

        static void debug_CreateThread(ICorDebug debug, CorDebugThreadEventArgs args)
        {
            Console.WriteLine("Create thread");
        }

        static void debug_CreateAppDomain(ICorDebug debug, CorDebugAppDomainEventArgs args)
        {
            Console.WriteLine("Create domain");
        }

    }
}
