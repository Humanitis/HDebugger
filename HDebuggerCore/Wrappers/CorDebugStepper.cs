namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebugStepper
    {
        #region Fields
        private readonly ICorDebugStepper _nativeCorDebugStepper;
        #endregion









        #region Constructors
        private CorDebugStepper()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeCorDebugStepper"></param>
        public CorDebugStepper(ICorDebugStepper nativeCorDebugStepper)
        {
            Debug.Assert(nativeCorDebugStepper != null, "nativeCorDebugStepper is null");

            this._nativeCorDebugStepper = nativeCorDebugStepper;
        }
        #endregion





        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugStepper NativeCorDebugStepper
        {
            get { return this._nativeCorDebugStepper; }
        }
        #endregion
    }
}
