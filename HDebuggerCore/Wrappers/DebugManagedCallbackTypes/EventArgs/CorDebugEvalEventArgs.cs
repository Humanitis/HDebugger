namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugEvalEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly CorDebugEval _eval;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eval"></param>
        public CorDebugEvalEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugThread thread,ICorDebugEval eval)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread),new CorDebugEval(eval))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eval"></param>
        public CorDebugEvalEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugThread thread, CorDebugEval eval)
            : base(process, appDomain,thread)
        {
            this._eval = eval;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugEval Eval
        {
            get { return this._eval; }
        }
        #endregion
    }
}
