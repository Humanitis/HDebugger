namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;





    /// <summary>
    /// 
    /// </summary>
    public sealed class CorDebugFrame : MarshalByRefObject
    {
        #region Fields
        private readonly ICorDebugFrame _nativeCorDebugFrame;
        #endregion






        #region Constructors
        private CorDebugFrame()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeCorDebugFrame"></param>
        public CorDebugFrame(ICorDebugFrame nativeCorDebugFrame)
        {
            Debug.Assert(nativeCorDebugFrame != null, "nativeCorDebugFrame is null");

            this._nativeCorDebugFrame = nativeCorDebugFrame;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugFrame NativeCorDebugFrame
        {
            get { return this._nativeCorDebugFrame; }
        }
        #endregion







        #region Methods
        #endregion

    }
}
