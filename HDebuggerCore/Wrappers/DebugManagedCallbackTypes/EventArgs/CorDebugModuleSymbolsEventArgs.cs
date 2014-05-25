namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
using System.Runtime.InteropServices.ComTypes;





    /// <summary>
    /// 
    /// </summary>
    public class CorDebugModuleSymbolsEventArgs : CorDebugModuleEventArgs
    {
        #region Fields
        private readonly IStream _symbolStream;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        /// <param name="symbolStream"></param>
        public CorDebugModuleSymbolsEventArgs(ICorDebugProcess process, ICorDebugAppDomain appDomain, ICorDebugModule module, IStream symbolStream)
            : this(new CorDebugProcess(process), new CorDebugAppDomain(appDomain), new CorDebugModule(module), symbolStream)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        /// <param name="symbolStream"></param>
        public CorDebugModuleSymbolsEventArgs(CorDebugProcess process, CorDebugAppDomain appDomain, CorDebugModule module, IStream symbolStream)
            : base(process, appDomain, module)
        {
            this._symbolStream = symbolStream;
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public IStream Stream
        {
            get { return this._symbolStream; }
        }
        #endregion
    }
}
