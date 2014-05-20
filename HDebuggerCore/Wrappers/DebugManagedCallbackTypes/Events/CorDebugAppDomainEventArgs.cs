namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebugAppDomainEventArgs:CorDebugEventArgs
    {
        #region Fields
        private readonly CorDebugAppDomain _appDomain;
        #endregion







        #region Constructors
        private CorDebugAppDomainEventArgs() 
        { 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        public CorDebugAppDomainEventArgs(ICorDebugAppDomain appDomain)
            :this(new CorDebugAppDomain(appDomain))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        public CorDebugAppDomainEventArgs(CorDebugAppDomain appDomain) {
            this._appDomain = appDomain;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugAppDomain AppDomain {
            get { return this._appDomain; }
        }
        #endregion
    }
}
