namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugFrameEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly CorDebugFrame _frame;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="frame"></param>
        public CorDebugFrameEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFrame frame)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread), new CorDebugFrame(frame))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="frame"></param>
        public CorDebugFrameEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugThread thread, CorDebugFrame frame)
            : base(process, appDomain, thread)
        {
            this._frame = frame;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugFrame Frame
        {
            get { return this._frame; }
        }
        #endregion
    }
}
