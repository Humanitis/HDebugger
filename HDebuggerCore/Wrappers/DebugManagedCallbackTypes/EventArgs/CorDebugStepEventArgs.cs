namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugStepEventArgs : CorDebugThreadEventArgs
    {
        #region Fields
        private readonly CorDebugStepReason _reason;
        private readonly CorDebugStepper _stepper;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="stepper"></param>
        /// <param name="reason"></param>
        public CorDebugStepEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugStepper stepper, CorDebugStepReason reason)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugThread(thread), new CorDebugStepper(stepper),reason)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="stepper"></param>
        /// <param name="reason"></param>
        public CorDebugStepEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugThread thread, CorDebugStepper stepper, CorDebugStepReason reason)
            : base(process, appDomain, thread)
        {
            this._reason = reason;
            this._stepper = stepper;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugStepReason Reason {
            get { return this._reason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CorDebugStepper Stepper
        {
            get { return this._stepper; }
        }
        #endregion
    }
}
