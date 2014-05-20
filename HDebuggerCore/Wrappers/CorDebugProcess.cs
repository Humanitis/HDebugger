namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;





    /// <summary>
    /// 
    /// </summary>
    public sealed class CorDebugProcess : MarshalByRefObject
    {
        #region Fields
        private readonly ICorDebugProcess _comCorDebugProcess;
        private readonly ICorDebugProcess2 _comCorDebugProcess2;
        #endregion






        #region Constructors
        private CorDebugProcess()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comCorDebugProcess"></param>
        public CorDebugProcess(ICorDebugProcess comCorDebugProcess) 
        { 
            Debug.Assert(comCorDebugProcess!=null,"comCorDebugProcess is null");

            this._comCorDebugProcess = comCorDebugProcess;
            this._comCorDebugProcess2 = WrapperHelper.Cast<ICorDebugProcess2>(comCorDebugProcess);
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugProcess NativeCorDebugProcess {
            get { return this._comCorDebugProcess; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugProcess2 NativeCorDebugProcess2
        {
            get { return this._comCorDebugProcess2; }
        }
        #endregion







        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static CorDebugProcess GetDebugProcessFor(Process process) { 
        
        }
        #endregion

    }
}
