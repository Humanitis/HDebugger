namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;




    /// <summary>
    /// 
    /// </summary>
    public class CorDebuggerErrorEventArgs : CorDebugProcessEventArgs
    {
        #region Fields
         private readonly int _errorCode;
        private readonly ulong _errorHR;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="errorHR"></param>
        /// <param name="errorCode"></param>
        public CorDebuggerErrorEventArgs(ICorDebugProcess process, ulong errorHR, int errorCode)
            : this(new CorDebugProcess(process), errorHR,errorCode)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="errorHR"></param>
        /// <param name="errorCode"></param>
        public CorDebuggerErrorEventArgs(CorDebugProcess process, ulong errorHR, int errorCode)
            : base(process)
        {
            this._errorCode = errorCode;
            this._errorHR = errorHR;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int ErrorCode
        {
            get { return this._errorCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ulong ErrorHR
        {
            get { return this._errorHR; }
        }
        #endregion
    }
}
