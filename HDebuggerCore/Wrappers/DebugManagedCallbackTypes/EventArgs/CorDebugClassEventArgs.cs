namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugClassEventArgs : CorDebugAppDomainEventArgs
    {
        #region Fields
        private readonly CorDebugClass _class;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="class"></param>
        public CorDebugClassEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugClass @class)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugClass(@class))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="class"></param>
        public CorDebugClassEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugClass @class)
            : base(process, appDomain)
        {
            this._class = @class;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugClass Class
        {
            get { return this._class; }
        }
        #endregion
    }
}
