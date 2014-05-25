namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugBreakpointEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly ICorDebugBreakpoint _breakpoint;
        private readonly int _error;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="breakpoint"></param>
        /// <param name="error"></param>
        public CorDebugBreakpointEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugBreakpoint breakpoint, int error = 0)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread), breakpoint, error)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="breakpoint"></param>
        /// <param name="error"></param>
        public CorDebugBreakpointEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugThread thread, ICorDebugBreakpoint breakpoint, int error = 0)
            : base(process, appDomain, thread)
        {
            this._breakpoint = breakpoint;
            this._error = error;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugBreakpoint Breakpoint
        {
            get { return this._breakpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Error
        {
            get { return this._error; }
        }
        #endregion
    }
}
