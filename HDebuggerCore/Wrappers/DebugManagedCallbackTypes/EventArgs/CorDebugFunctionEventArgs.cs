namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugFunctionEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly CorDebugFunction _function;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="function"></param>
        public CorDebugFunctionEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFunction function)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread), new CorDebugFunction(function))
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="function"></param>
        public CorDebugFunctionEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugThread thread, CorDebugFunction function)
            : base(process, appDomain, thread)
        {
            this._function = function;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugFunction Function
        {
            get { return this._function; }
        }
        #endregion
    }
}
