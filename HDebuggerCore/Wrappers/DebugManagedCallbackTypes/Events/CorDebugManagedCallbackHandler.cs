namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="debug"></param>
    /// <param name="args"></param>
    public delegate void CorDebugManagedCallbackHandler(ICorDebug debug, CorDebugEventArgs args);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEventArgs"></typeparam>
    /// <param name="debug"></param>
    /// <param name="args"></param>
    public delegate void CorDebugManagedCallbackHandler<TEventArgs>(ICorDebug debug, TEventArgs args) where TEventArgs : CorDebugEventArgs;
}
