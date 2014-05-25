namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugAssemblyEventArgs : CorDebugAppDomainEventArgs
    {
        #region Fields
        private readonly CorDebugAssembly _assembly;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="assembly"></param>
        public CorDebugAssemblyEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugAssembly assembly)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugAssembly(assembly))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="assembly"></param>
        public CorDebugAssemblyEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugAssembly assembly)
            : base(process, appDomain)
        {
            this._assembly = assembly;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugAssembly Assembly
        {
            get { return this._assembly; }
        }
        #endregion
    }
}
