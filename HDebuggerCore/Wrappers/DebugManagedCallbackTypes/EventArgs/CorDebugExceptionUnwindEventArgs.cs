namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugExceptionUnwindEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly CorDebugExceptionUnwindCallbackType _eventType;
        private readonly CorDebugExceptionFlags _flags;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eventType"></param>
        /// <param name="flags"></param>
        public CorDebugExceptionUnwindEventArgs(
                    ICorDebugProcess process, 
                    ICorDebugAppDomain appDomain, 
                    ICorDebugThread thread,
                    CorDebugExceptionUnwindCallbackType eventType, 
                    CorDebugExceptionFlags flags)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread), eventType, flags)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eventType"></param>
        /// <param name="flags"></param>
        public CorDebugExceptionUnwindEventArgs(
                    CorDebugProcess process, 
                    CorDebugAppDomain appDomain, 
                    CorDebugThread thread,
                    CorDebugExceptionUnwindCallbackType eventType, 
                    CorDebugExceptionFlags flags)
            : base(process, appDomain, thread)
        {
            this._eventType = eventType;
            this._flags = flags;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugExceptionUnwindCallbackType EventType
        {
            get { return this._eventType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CorDebugExceptionFlags Flags
        {
            get { return this._flags; }
        }
        #endregion
    }
}
