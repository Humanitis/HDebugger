namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugConnectionEventArgs : CorDebugProcessEventArgs
    {
        #region Fields
        private readonly uint _connectionId;
        private readonly string _connectionName;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="connectionId"></param>
        /// <param name="connectionName"></param>
        public CorDebugConnectionEventArgs(ICorDebugProcess process, uint connectionId, string connectionName)
            : this(new CorDebugProcess(process), connectionId, connectionName)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="connectionId"></param>
        /// <param name="connectionName"></param>
        public CorDebugConnectionEventArgs(CorDebugProcess process, uint connectionId, string connectionName)
            : base(process)
        {
            this._connectionId = connectionId;
            this._connectionName = connectionName;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public uint ConnectionId
        {
            get { return this._connectionId; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionName
        {
            get { return this._connectionName; }
        }
        #endregion
    }
}
