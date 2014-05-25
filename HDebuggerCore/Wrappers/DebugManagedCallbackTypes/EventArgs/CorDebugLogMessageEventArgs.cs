namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugLogMessageEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly int _level;
        private readonly string _logSwitchName;
        private readonly string _message;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="level"></param>
        /// <param name="logSwitchName"></param>
        /// <param name="message"></param>
        public CorDebugLogMessageEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugThread thread, int level, string logSwitchName, string message)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread), level, logSwitchName, message)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="level"></param>
        /// <param name="logSwitchName"></param>
        /// <param name="message"></param>
        public CorDebugLogMessageEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugThread thread, int level, string logSwitchName, string message)
            : base(process, appDomain, thread)
        {
            this._level = level;
            this._logSwitchName = logSwitchName;
            this._message = message;
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
        public string LogSwitchName
        {
            get { return this._logSwitchName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            get { return this._message; }
        }
        #endregion
    }
}
