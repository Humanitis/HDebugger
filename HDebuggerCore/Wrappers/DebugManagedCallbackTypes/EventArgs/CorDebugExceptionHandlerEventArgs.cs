namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugExceptionHandlerEventArgs : CorDebugFrameEventArgs
    {
        #region Fields
        private readonly CorDebugExceptionCallbackType _eventType;
        private readonly CorDebugExceptionFlags _flags;
        private readonly uint _offset;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="frame"></param>
        /// <param name="offset"></param>
        /// <param name="eventType"></param>
        /// <param name="flags"></param>
        public CorDebugExceptionHandlerEventArgs(
                    ICorDebugProcess process, 
                    ICorDebugAppDomain appDomain, 
                    ICorDebugThread thread, 
                    ICorDebugFrame frame, 
                    uint offset, 
                    CorDebugExceptionCallbackType eventType, 
                    CorDebugExceptionFlags flags)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread), new CorDebugFrame(frame), offset, eventType, flags)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="frame"></param>
        /// <param name="offset"></param>
        /// <param name="eventType"></param>
        /// <param name="flags"></param>
        public CorDebugExceptionHandlerEventArgs(
                    CorDebugProcess process, 
                    CorDebugAppDomain appDomain, 
                    CorDebugThread thread, 
                    CorDebugFrame frame, 
                    uint offset, 
                    CorDebugExceptionCallbackType eventType, 
                    CorDebugExceptionFlags flags)
            : base(process, appDomain, thread, frame)
        {
            this._eventType = eventType;
            this._flags = flags;
            this._offset = offset;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugExceptionCallbackType EventType
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
        /// <summary>
        /// 
        /// </summary>
        public uint Offset
        {
            get { return this._offset; }
        }
        #endregion
    }
}
