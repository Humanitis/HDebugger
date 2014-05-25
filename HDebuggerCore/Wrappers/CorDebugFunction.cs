namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;





    /// <summary>
    /// 
    /// </summary>
    public sealed class CorDebugFunction : MarshalByRefObject
    {
        #region Fields
        private readonly ICorDebugFunction _nativeCorDebugFunction;
        private readonly Lazy<ICorDebugFunction2> _nativeCorDebugFunction2;
        #endregion






        #region Constructors
        private CorDebugFunction()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nativeCorDebugFunction"></param>
        public CorDebugFunction(ICorDebugFunction nativeCorDebugFunction)
        {
            Debug.Assert(nativeCorDebugFunction != null, "nativeCorDebugFunction is null");

            this._nativeCorDebugFunction = nativeCorDebugFunction;
            this._nativeCorDebugFunction2 = new Lazy<ICorDebugFunction2>(() => WrapperHelper.Cast<ICorDebugFunction2>(this._nativeCorDebugFunction), true);
        }
        #endregion








        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugFunction NativeCorDebugFunction
        {
            get { return this._nativeCorDebugFunction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public ICorDebugFunction2 NativeCorDebugFunction2
        {
            get { return this._nativeCorDebugFunction2.Value; }
        }
        #endregion







        #region Methods
        #endregion

    }
}
