namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;



    /// <summary>
    /// 
    /// </summary>
    public abstract class CorDebugManagedCallbackBase : ICorDebugManagedCallback, ICorDebugManagedCallback2, ICorDebugManagedCallback3
    {
        #region Implement interface ICorDebugManagedCallback
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="breakpoint"></param>
        protected virtual void Breakpoint(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugBreakpoint breakpoint)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="stepper"></param>
        /// <param name="reason"></param>
        protected virtual void StepComplete(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugStepper stepper, CorDebugStepReason reason)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        protected virtual void Break(ICorDebugAppDomain appDomain, ICorDebugThread thread)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="unhandled"></param>
        protected virtual void Exception(ICorDebugAppDomain appDomain, ICorDebugThread thread, bool unhandled)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eval"></param>
        protected virtual void EvalComplete(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugEval eval)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eval"></param>
        protected virtual void EvalException(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugEval eval)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        protected virtual void CreateProcess(ICorDebugProcess process)
        {
            process.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        protected virtual void ExitProcess(ICorDebugProcess process)
        {
            process.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        protected virtual void CreateThread(ICorDebugAppDomain appDomain, ICorDebugThread thread)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        protected virtual void ExitThread(ICorDebugAppDomain appDomain, ICorDebugThread thread)
        {        
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        protected virtual void LoadModule(ICorDebugAppDomain appDomain, ICorDebugModule module)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        protected virtual void UnloadModule(ICorDebugAppDomain appDomain, ICorDebugModule module)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="class"></param>
        protected virtual void LoadClass(ICorDebugAppDomain appDomain, ICorDebugClass @class)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="class"></param>
        protected virtual void UnloadClass(ICorDebugAppDomain appDomain, ICorDebugClass @class)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="errorHR"></param>
        /// <param name="errorCode"></param>
        protected virtual void DebuggerError(ICorDebugProcess process, ulong errorHR, int errorCode)
        {
            process.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="level"></param>
        /// <param name="logSwitchName"></param>
        /// <param name="message"></param>
        protected virtual void LogMessage(ICorDebugAppDomain appDomain, ICorDebugThread thread, int level, string logSwitchName, string message)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="level"></param>
        /// <param name="reason"></param>
        /// <param name="logSwitchName"></param>
        /// <param name="parentName"></param>
        protected virtual void LogSwitch(ICorDebugAppDomain appDomain, ICorDebugThread thread, int level, LogSwitchCallReason reason, string logSwitchName, string parentName)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        protected virtual void CreateAppDomain(ICorDebugProcess process, ICorDebugAppDomain appDomain)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        protected virtual void ExitAppDomain(ICorDebugProcess process, ICorDebugAppDomain appDomain)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="assembly"></param>
        protected virtual void LoadAssembly(ICorDebugAppDomain appDomain, ICorDebugAssembly assembly)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="assembly"></param>
        protected virtual void UnloadAssembly(ICorDebugAppDomain appDomain, ICorDebugAssembly assembly)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        protected virtual void ControlCTrap(ICorDebugProcess process)
        {
            process.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        protected virtual void NameChange(ICorDebugAppDomain appDomain, ICorDebugThread thread)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        /// <param name="symbolStream"></param>
        protected virtual void UpdateModuleSymbols(ICorDebugAppDomain appDomain, ICorDebugModule module, System.Runtime.InteropServices.ComTypes.IStream symbolStream)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="function"></param>
        /// <param name="accurate"></param>
        protected virtual void EditAndContinueRemap(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFunction function, bool accurate)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="breakpoint"></param>
        /// <param name="dwError"></param>
        protected virtual void BreakpointSetError(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugBreakpoint breakpoint, int dwError)
        {
            appDomain.Continue(false);
        }
        #endregion











        #region Implement interface ICorDebugManagedCallback2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="oldFunction"></param>
        /// <param name="newFunction"></param>
        /// <param name="oldILOffset"></param>
        protected virtual void FunctionRemapOpportunity(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFunction oldFunction, ICorDebugFunction newFunction, uint oldILOffset)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="connectionId"></param>
        /// <param name="connName"></param>
        protected virtual void CreateConnection(ICorDebugProcess process, uint connectionId, string connName)
        {
            process.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="connectionId"></param>
        protected virtual void ChangeConnection(ICorDebugProcess process, uint connectionId)
        {
            process.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="connectionId"></param>
        protected virtual void DestroyConnection(ICorDebugProcess process, uint connectionId)
        {
            process.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="frame"></param>
        /// <param name="offset"></param>
        /// <param name="dwEventType"></param>
        /// <param name="dwFlags"></param>
        protected virtual void Exception(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFrame frame, uint offset, CorDebugExceptionCallbackType dwEventType, CorDebugExceptionFlags dwFlags)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eventType"></param>
        /// <param name="dwFlags"></param>
        protected virtual void ExceptionUnwind(ICorDebugAppDomain appDomain, ICorDebugThread thread, CorDebugExceptionUnwindCallbackType eventType, CorDebugExceptionFlags dwFlags)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="function"></param>
        protected virtual void FunctionRemapComplete(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFunction function)
        {
            appDomain.Continue(false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="thread"></param>
        /// <param name="MDA"></param>
        protected virtual void MDANotification(ICorDebugController controller, ICorDebugThread thread, ICorDebugMDA MDA)
        {
            controller.Continue(false);
        }
        #endregion








        #region Implement interface ICorDebugManagedCallback3
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        /// <param name="appDomain"></param>
        protected void CustomNotification(ICorDebugThread thread, ICorDebugAppDomain appDomain)
        {
            appDomain.Continue(false);
        }
        #endregion
    }
}
