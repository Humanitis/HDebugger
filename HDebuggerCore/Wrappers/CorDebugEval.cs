namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;





    /// <summary>
    /// 
    /// </summary>
    public sealed class CorDebugEval : MarshalByRefObject
    {
        #region Fields
        private readonly ICorDebugEval _nativeCorDebugEval;
        #endregion






        #region Constructors
        private CorDebugEval()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeCorDebugEval"></param>
        public CorDebugEval(ICorDebugEval nativeCorDebugEval)
        {
            Debug.Assert(nativeCorDebugEval != null, "nativeCorDebugEval is null");

            this._nativeCorDebugEval = nativeCorDebugEval;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugEval NativeCorDebugEval
        {
            get { return this._nativeCorDebugEval; }
        }
        #endregion







        #region Methods
        #endregion

    }
}
