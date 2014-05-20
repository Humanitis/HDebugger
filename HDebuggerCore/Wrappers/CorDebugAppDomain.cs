namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebugAppDomain
    {
        #region Fields
        private readonly ICorDebugAppDomain _nativeCorDebugAppDomain;
        #endregion









        #region Constructors
        private CorDebugAppDomain() {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeCorDebugAppDomain"></param>
        public CorDebugAppDomain(ICorDebugAppDomain nativeCorDebugAppDomain) {
            Debug.Assert(nativeCorDebugAppDomain != null, "nativeCorDebugAppDomain is null");

            this._nativeCorDebugAppDomain = nativeCorDebugAppDomain;
        }
        #endregion





        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugAppDomain NativeCorDebugAppDomain {
            get { return this._nativeCorDebugAppDomain; }
        }
        #endregion
    }
}
