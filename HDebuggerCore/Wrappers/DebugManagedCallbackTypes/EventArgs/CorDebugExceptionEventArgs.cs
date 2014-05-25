namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugExceptionEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly bool _unhandled;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="unhandled"></param>
        public CorDebugExceptionEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugThread thread, bool unhandled)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread), unhandled)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eval"></param>
        public CorDebugExceptionEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugThread thread, bool unhandled)
            : base(process, appDomain, thread)
        {
            this._unhandled = unhandled;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public bool Unhandled
        {
            get { return this._unhandled; }
        }
        #endregion
    }
}
