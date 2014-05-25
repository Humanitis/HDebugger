namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebugAssembly
    {
        #region Fields
        private readonly ICorDebugAssembly _nativeCorDebugAssembly;
        #endregion









        #region Constructors
        private CorDebugAssembly()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeCorDebugAssembly"></param>
        public CorDebugAssembly(ICorDebugAssembly nativeCorDebugAssembly)
        {
            Debug.Assert(nativeCorDebugAssembly != null, "nativeCorDebugAssembly is null");

            this._nativeCorDebugAssembly = nativeCorDebugAssembly;
        }
        #endregion





        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugAssembly NativeCorDebugAssembly
        {
            get { return this._nativeCorDebugAssembly; }
        }
        #endregion
    }
}
