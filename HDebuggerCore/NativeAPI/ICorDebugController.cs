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
    [Guid("3d6f5f62-7538-11d3-8d5b-00104b35e7ef")]
    public interface ICorDebugController
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Stop(
            [In, MarshalAs(UnmanagedType.I4)]int timeoutIgnored = -1);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Continue(
            [In, MarshalAs(UnmanagedType.Bool)]bool isOutOfBand);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsRunning();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool HasQueuedCallbacks(
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ICorDebugThreadEnum EnumerateThreads();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetAllThreadsDebugState(
            [In, MarshalAs(UnmanagedType.I4)] CorDebugThreadState state,
            [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread exceptThisThread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Detach();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Terminate(
            [In, MarshalAs(UnmanagedType.U4)]uint exitCode);

#if NET35
        virtual HRESULT STDMETHODCALLTYPE CanCommitChanges( 
            /* [in] */ ULONG cSnapshots,
            /* [size_is][in] */ ICorDebugEditAndContinueSnapshot *pSnapshots[  ],
            /* [out] */ ICorDebugErrorInfoEnum **pError) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CommitChanges( 
            /* [in] */ ULONG cSnapshots,
            /* [size_is][in] */ ICorDebugEditAndContinueSnapshot *pSnapshots[  ],
            /* [out] */ ICorDebugErrorInfoEnum **pError) = 0;
#endif
    }
}
