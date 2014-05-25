namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebugModule
    {
        #region Fields
        private readonly ICorDebugModule _nativeCorDebugModule;
        #endregion









        #region Constructors
        private CorDebugModule()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeCorDebugModule"></param>
        public CorDebugModule(ICorDebugModule nativeCorDebugModule)
        {
            Debug.Assert(nativeCorDebugModule != null, "nativeCorDebugModule is null");

            this._nativeCorDebugModule = nativeCorDebugModule;
        }
        #endregion





        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugModule NativeCorDebugModule
        {
            get { return this._nativeCorDebugModule; }
        }
        #endregion
    }
}
