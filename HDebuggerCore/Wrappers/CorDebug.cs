namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebug : CorDebugManagedCallbackEvents
    {
        #region Fields
        private ICLRMetaHost _clrMetaHost;
        private readonly object _lockObject = new object();
        private ICorDebug _nativeCorDebug;
        private readonly Process _process;
        private DebugState _state = DebugState.Ready;
        #endregion








        #region Constructors
        private CorDebug()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        public CorDebug(Process process)
        {
            this._process = process;
        }
        #endregion







        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebug NativeCorDebug
        {
            get { return this._nativeCorDebug; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DebugState State
        {
            get { return this._state; }
        }
        #endregion










        #region Methods


        /// <summary>
        /// 
        /// </summary>
        public void Debug()
        {
            lock (this._lockObject)
            {
                if (this._state != DebugState.Ready)
                    throw new InvalidOperationException("Debugging already active");
                this._state = DebugState.StartDebugging;
            }
            if (this._process != null)
                DebugActiveProcess();
            this._state = DebugState.Debug;
        }


        /// <summary>
        /// 
        /// </summary>
        private void DebugActiveProcess()
        {
            this._clrMetaHost = WrapperHelper.CLRCreateInstance<ICLRMetaHost>(Constants.CLSID_CLRMetaHost, Constants.IID_ICLMetaHost);

            IEnumUnknown runtimes = this._clrMetaHost.EnumerateLoadedRuntimes(this._process.Handle);
            ICLRRuntimeInfo runtime = WrapperHelper.GetRuntime(runtimes, null);

            IntPtr icorDebugPtr = runtime.GetInterface(Constants.CLSID_CLRDebuggingLegacy, Constants.IID_ICorDebug);
            this._nativeCorDebug = (ICorDebug)Marshal.GetTypedObjectForIUnknown(icorDebugPtr, typeof(ICorDebug));
            this._nativeCorDebug.Initialize();
            this._nativeCorDebug.SetManagedHandler(this);


            ICorDebugProcess nativeCorDebugProcess = this._nativeCorDebug.DebugActiveProcess(this._process.Id, false);

            this.DebugProcess = new CorDebugProcess(nativeCorDebugProcess);
        }


        /// <summary>
        /// 
        /// </summary>
        public void Terminate()
        {
            lock (this._lockObject)
            {
                if (this._state == DebugState.Debug)
                    throw new InvalidOperationException("Process is not debugging");
                this._state = DebugState.Terminating;
            }

            //TODO: write here some statements to terminate debugging process

            this._state = DebugState.Terminated;
        }
        #endregion





        #region Debug state
        /// <summary>
        /// 
        /// </summary>
        public enum DebugState
        {
            Ready,
            StartDebugging,
            Debug,
            Terminating,
            Terminated
        }
        #endregion
    }
}
