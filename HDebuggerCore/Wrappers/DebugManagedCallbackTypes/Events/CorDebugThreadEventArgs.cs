namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugThreadEventArgs : CorDebugAppDomainEventArgs
    {
        #region Fields
        private readonly CorDebugThread _thread;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        public CorDebugThreadEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugThread thread)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        public CorDebugThreadEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugThread thread)
            : base(process, appDomain)
        {
            this._thread = thread;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugThread Thread
        {
            get { return this._thread; }
        }
        #endregion
    }
}
