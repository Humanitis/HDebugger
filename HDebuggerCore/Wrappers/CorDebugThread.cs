namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebugThread : MarshalByRefObject
    {
        #region Fields
        private readonly ICorDebugThread _nativeCorDebugThread;
        private readonly ICorDebugThread2 _nativeCorDebugThread2;
        #endregion









        #region Constructors
        private CorDebugThread()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeCorDebugThread"></param>
        public CorDebugThread(ICorDebugThread nativeCorDebugThread)
        {
            Debug.Assert(nativeCorDebugThread != null, "nativeCorDebugThread is null");

            this._nativeCorDebugThread = nativeCorDebugThread;
            this._nativeCorDebugThread2 = WrapperHelper.Cast<ICorDebugThread2>(nativeCorDebugThread);
        }
        #endregion





        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugThread NativeCorDebugThread
        {
            get { return this._nativeCorDebugThread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugThread2 NativeCorDebugThread2
        {
            get { return this._nativeCorDebugThread2; }
        }
        #endregion
    }
}
