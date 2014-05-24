namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebugAppDomainEventArgs : CorDebugProcessEventArgs
    {
        #region Fields
        private readonly CorDebugAppDomain _appDomain;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        public CorDebugAppDomainEventArgs(ICorDebugAppDomain appDomain)
            : this(appDomain.GetProcess(),appDomain)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        public CorDebugAppDomainEventArgs(ICorDebugProcess process,ICorDebugAppDomain appDomain)
            : this(new CorDebugProcess(process),new CorDebugAppDomain(appDomain))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        public CorDebugAppDomainEventArgs(CorDebugAppDomain appDomain)
            : this(new CorDebugProcess(appDomain.NativeCorDebugAppDomain.GetProcess()), appDomain)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        public CorDebugAppDomainEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain)
            : base(process)
        {
            this._appDomain = appDomain;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugAppDomain AppDomain
        {
            get { return this._appDomain; }
        }
        #endregion
    }
}
