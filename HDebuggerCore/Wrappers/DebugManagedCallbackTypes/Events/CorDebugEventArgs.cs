namespace HDebuggerCore.Wrappers
{

    /// <summary>
    /// 
    /// </summary>
    public class CorDebugEventArgs
    {
        #region Fields
        private bool _continue = true;
        private bool _outOfBand = false;
        #endregion





        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public bool Continue {
            get { return this._continue; }
            set { this._continue = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool OutOfBand
        {
            get { return this._outOfBand; }
            set { this._outOfBand = value; }
        }
        #endregion
    }
}
