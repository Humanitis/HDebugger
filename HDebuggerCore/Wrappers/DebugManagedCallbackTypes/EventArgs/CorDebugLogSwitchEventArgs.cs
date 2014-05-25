namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugLogSwitchEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly int _level;
        private readonly string _logSwitchName;
        private readonly string _parentName;
        private readonly LogSwitchCallReason _reason;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="level"></param>
        /// <param name="reason"></param>
        /// <param name="logSwitchName"></param>
        /// <param name="parentName"></param>
        public CorDebugLogSwitchEventArgs(ICorDebugProcess process, 
                                        ICorDebugAppDomain appDomain, 
                                        ICorDebugThread thread, 
                                        int level, 
                                        LogSwitchCallReason reason, 
                                        string logSwitchName, 
                                        string parentName)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread), level, reason, logSwitchName, parentName)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="level"></param>
        /// <param name="reason"></param>
        /// <param name="logSwitchName"></param>
        /// <param name="parentName"></param>
        public CorDebugLogSwitchEventArgs(CorDebugProcess process, 
                                        CorDebugAppDomain appDomain, 
                                        CorDebugThread thread, 
                                        int level, 
                                        LogSwitchCallReason reason, 
                                        string logSwitchName, 
                                        string parentName)
            : base(process, appDomain, thread)
        {
            this._level = level;
            this._logSwitchName = logSwitchName;
            this._reason = reason;
            this._parentName = parentName;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Level
        {
            get { return this._level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public LogSwitchCallReason Reason {
            get { return this._reason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogSwitchName
        {
            get { return this._logSwitchName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ParentName
        {
            get { return this._parentName; }
        }
        #endregion
    }
}
