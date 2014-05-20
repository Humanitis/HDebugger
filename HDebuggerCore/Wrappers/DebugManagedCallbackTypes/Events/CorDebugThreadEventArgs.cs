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
        public CorDebugThreadEventArgs(ICorDebugAppDomain appDomain,ICorDebugThread thread)
            :this(new CorDebugAppDomain(appDomain),new CorDebugThread(thread))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        public CorDebugThreadEventArgs(CorDebugAppDomain appDomain,CorDebugThread thread)
            :base(appDomain)
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
