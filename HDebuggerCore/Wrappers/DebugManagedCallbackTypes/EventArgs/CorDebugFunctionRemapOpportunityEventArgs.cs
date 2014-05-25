namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugFunctionRemapOpportunityEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly CorDebugFunction _newFunction;
        private readonly CorDebugFunction _oldFunction;
        private readonly uint _oldILOffset;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="newFunction"></param>
        /// <param name="oldFunction"></param>
        /// <param name="oldILOffset"></param>
        public CorDebugFunctionRemapOpportunityEventArgs(
                    ICorDebugProcess process,
                    ICorDebugAppDomain appDomain,
                    ICorDebugThread thread,
                    ICorDebugFunction newFunction,
                    ICorDebugFunction oldFunction,
                    uint oldILOffset)
            : this(new CorDebugProcess(process),
                    new CorDebugAppDomain(appDomain),
                    new CorDebugThread(thread),
                    new CorDebugFunction(newFunction),
                    new CorDebugFunction(oldFunction),
                    oldILOffset)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="function"></param>
        public CorDebugFunctionRemapOpportunityEventArgs(
                    CorDebugProcess process,
                    CorDebugAppDomain appDomain,
                    CorDebugThread thread,
                    CorDebugFunction newFunction,
                    CorDebugFunction oldFunction,
                    uint oldILOffset)
            : base(process, appDomain, thread)
        {
            this._newFunction = newFunction;
            this._oldFunction = oldFunction;
            this._oldILOffset = oldILOffset;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugFunction NewFunction
        {
            get { return this._newFunction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CorDebugFunction OldFunction
        {
            get { return this._oldFunction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public uint OldILOffset
        {
            get { return this._oldILOffset; }
        }
        #endregion
    }
}
