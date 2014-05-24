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
    [Guid("3D6F5F60-7538-11D3-8D5B-00104B35E7EF")]
    public interface ICorDebugManagedCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Breakpoint( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugBreakpoint breakpoint);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void  StepComplete( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugStepper stepper,
            [In,MarshalAs(UnmanagedType.I4)] CorDebugStepReason reason);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void  Break( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void  Exception( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In,MarshalAs(UnmanagedType.Bool)]bool unhandled);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void  EvalComplete( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugEval eval);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void   EvalException( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugEval eval);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void   CreateProcess( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugProcess process);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void   ExitProcess( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugProcess process);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void   CreateThread( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void   ExitThread( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void   LoadModule( 
            [In,MarshalAs(UnmanagedType.Interface)]  ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)]  ICorDebugModule module);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void   UnloadModule( 
            [In,MarshalAs(UnmanagedType.Interface)]  ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)]  ICorDebugModule module);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void   LoadClass( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)]  ICorDebugClass @class);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void   UnloadClass( 
            [In,MarshalAs(UnmanagedType.Interface)]  ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)]  ICorDebugClass @class);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    DebuggerError( 
            [In,MarshalAs(UnmanagedType.Interface)]  ICorDebugProcess process,
            [In,MarshalAs(UnmanagedType.U8)]  ulong errorHR,
            [In,MarshalAs(UnmanagedType.I4)]  int errorCode);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    LogMessage( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In,MarshalAs(UnmanagedType.I4)] int level,
            [In,MarshalAs(UnmanagedType.LPStr)] string logSwitchName,
             [In,MarshalAs(UnmanagedType.LPStr)] string message) ;
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    LogSwitch( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In,MarshalAs(UnmanagedType.I4)] int level,
            [In,MarshalAs(UnmanagedType.U4)] LogSwitchCallReason reason,
            [In,MarshalAs(UnmanagedType.LPStr)] string logSwitchName,
            [In,MarshalAs(UnmanagedType.LPStr)] string parentName);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    CreateAppDomain( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugProcess process,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    ExitAppDomain( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugProcess process,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    LoadAssembly( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAssembly assembly);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    UnloadAssembly( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAssembly assembly) ;
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    ControlCTrap( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugProcess process);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    NameChange( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    UpdateModuleSymbols( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugModule module,
            [In,MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IStream symbolStream);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    EditAndContinueRemap( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugFunction function,
            [In,MarshalAs(UnmanagedType.Bool)] bool accurate);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void    BreakpointSetError( 
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain appDomain,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread,
            [In,MarshalAs(UnmanagedType.Interface)] ICorDebugBreakpoint breakpoint,
            [In,MarshalAs(UnmanagedType.I4)] int error);
    }
}
