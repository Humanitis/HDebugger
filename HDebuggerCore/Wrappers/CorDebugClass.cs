namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebugClass
    {
        #region Fields
        private readonly ICorDebugClass _nativeCorDebugClass;
        #endregion









        #region Constructors
        private CorDebugClass()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeCorDebugClass"></param>
        public CorDebugClass(ICorDebugClass nativeCorDebugClass)
        {
            Debug.Assert(nativeCorDebugClass != null, "nativeCorDebugClass is null");

            this._nativeCorDebugClass = nativeCorDebugClass;
        }
        #endregion





        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugClass NativeCorDebugClass
        {
            get { return this._nativeCorDebugClass; }
        }
        #endregion
    }
}
