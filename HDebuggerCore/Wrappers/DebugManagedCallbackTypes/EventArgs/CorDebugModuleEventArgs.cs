namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugModuleEventArgs : CorDebugAppDomainEventArgs
    {
        #region Fields
        private readonly CorDebugModule _module;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        public CorDebugModuleEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugModule module)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugModule(module))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        public CorDebugModuleEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugModule module)
            : base(process, appDomain)
        {
            this._module = module;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugModule Module
        {
            get { return this._module; }
        }
        #endregion
    }
}
