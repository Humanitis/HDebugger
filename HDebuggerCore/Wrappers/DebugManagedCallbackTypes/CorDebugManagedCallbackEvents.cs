namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Runtime.InteropServices.ComTypes;









    /// <summary>
    /// 
    /// </summary>
    public class CorDebugManagedCallbackEvents : CorDebugManagedCallbackBase
    {
        #region Fields
        private CorDebugProcess _debugProcess;
        #endregion






        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public CorDebugProcess DebugProcess
        {
            get { return this._debugProcess; }
            protected set { this._debugProcess = value; }
        }
        #endregion







        #region Events
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugThreadEventArgs> BreakEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugBreakpointEventArgs> BreakpointEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugBreakpointEventArgs> BreakpointSetErrorEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugConnectionEventArgs> ChangeConnectionEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugProcessEventArgs> ControlCTrapEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugAppDomainEventArgs> CreateAppDomainEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugConnectionEventArgs> CreateConnectionEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugProcessEventArgs> CreateProcessEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugThreadEventArgs> CreateThreadEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugThreadEventArgs> CustomNotificationEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebuggerErrorEventArgs> DebuggerErrorEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugConnectionEventArgs> DestroyConnectionEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugEvalEventArgs> EvalCompleteEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugEvalEventArgs> EvalExceptionEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugExceptionEventArgs> ExceptionEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugExceptionHandlerEventArgs> ExceptionStartSearchHandlerEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugExceptionUnwindEventArgs> ExceptionUnwindEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugAppDomainEventArgs> ExitAppDomainEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugProcessEventArgs> ExitProcessEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugThreadEventArgs> ExitThreadEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugFunctionEventArgs> FunctionRemapEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugFunctionRemapOpportunityEventArgs> FunctionRemapOpportunityEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugAssemblyEventArgs> LoadAssemblyEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugClassEventArgs> LoadClassEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugModuleEventArgs> LoadModuleEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugLogMessageEventArgs> LogMessageEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugLogSwitchEventArgs> LogSwitchEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugThreadEventArgs> NameChangeEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugStepEventArgs> StepCompleteEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugAssemblyEventArgs> UnloadAssemblyEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugClassEventArgs> UnloadClassEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugModuleEventArgs> UnloadModuleEvent;
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugModuleSymbolsEventArgs> UpdateModuleSymbolsEvent;
        #endregion






        #region Methods

        #region Helper methods


        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="eventArgs"></param>
        private void Continue(ICorDebugController controller, CorDebugEventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                controller.Continue(false);
            }
            else
            {
                if (eventArgs.Continue)
                    controller.Continue(eventArgs.OutOfBand);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEventsArgs"></typeparam>
        /// <param name="event"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private TEventsArgs FireEvent<TEventsArgs>(CorDebugManagedCallbackHandler<TEventsArgs> @event, TEventsArgs args) where TEventsArgs : CorDebugEventArgs
        {
            if (@event != null)
                @event(null, args);

            return args;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEventsArgs"></typeparam>
        /// <param name="event"></param>
        /// <param name="argsGetter"></param>
        private TEventsArgs FireEvent<TEventsArgs>(CorDebugManagedCallbackHandler<TEventsArgs> @event, Func<TEventsArgs> argsGetter) where TEventsArgs : CorDebugEventArgs
        {
            if (@event != null)
            {
                TEventsArgs args = argsGetter();
                @event(null, args);

                return args;
            }

            return null;
        }
        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        public override void Break(ICorDebugAppDomain appDomain, ICorDebugThread thread)
        {
            var eventArgs = FireEvent(this.BreakEvent, () => new CorDebugThreadEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread)));
            Continue(appDomain, eventArgs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="breakpoint"></param>
        public override void Breakpoint(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugBreakpoint breakpoint)
        {
            var eventArgs = FireEvent(this.BreakpointEvent, () => new CorDebugBreakpointEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread), breakpoint));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="breakpoint"></param>
        /// <param name="error"></param>
        public override void BreakpointSetError(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugBreakpoint breakpoint, int error)
        {
            var eventArgs = FireEvent(this.BreakpointSetErrorEvent, () => new CorDebugBreakpointEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread), breakpoint, error));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="connectionId"></param>
        public override void ChangeConnection(ICorDebugProcess process, uint connectionId)
        {
            var eventArgs = FireEvent(this.ChangeConnectionEvent, () => new CorDebugConnectionEventArgs(this.DebugProcess, connectionId, null));
            Continue(process, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        public override void ControlCTrap(ICorDebugProcess process)
        {
            var eventArgs = FireEvent(this.ControlCTrapEvent, () => new CorDebugProcessEventArgs(this.DebugProcess));
            Continue(process, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        public override void CreateAppDomain(ICorDebugProcess process, ICorDebugAppDomain appDomain)
        {
            var eventArgs = FireEvent(this.CreateAppDomainEvent, () => new CorDebugAppDomainEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="connectionId"></param>
        /// <param name="connName"></param>
        public override void CreateConnection(ICorDebugProcess process, uint connectionId, string connName)
        {
            var eventArgs = FireEvent(this.CreateConnectionEvent, () => new CorDebugConnectionEventArgs(this.DebugProcess, connectionId, connName));
            Continue(process, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        public override void CreateProcess(ICorDebugProcess process)
        {
            this._debugProcess = new CorDebugProcess(process);
            var eventArgs = FireEvent(this.CreateProcessEvent, () => new CorDebugProcessEventArgs(this.DebugProcess));
            Continue(process, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        public override void CreateThread(ICorDebugAppDomain appDomain, ICorDebugThread thread)
        {
            var eventArgs = FireEvent(this.CreateThreadEvent, () => new CorDebugThreadEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thread"></param>
        /// <param name="appDomain"></param>
        public override void CustomNotification(ICorDebugThread thread, ICorDebugAppDomain appDomain)
        {
            var eventArgs = FireEvent(this.CustomNotificationEvent, () => new CorDebugThreadEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="errorHR"></param>
        /// <param name="errorCode"></param>
        public override void DebuggerError(ICorDebugProcess process, ulong errorHR, int errorCode)
        {
            var eventArgs = FireEvent(this.DebuggerErrorEvent, () => new CorDebuggerErrorEventArgs(this.DebugProcess, errorHR, errorCode));
            Continue(process, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="connectionId"></param>
        public override void DestroyConnection(ICorDebugProcess process, uint connectionId)
        {
            var eventArgs = FireEvent(this.DestroyConnectionEvent, () => new CorDebugConnectionEventArgs(this.DebugProcess, connectionId, null));
            Continue(process, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="function"></param>
        /// <param name="accurate"></param>
        public override void EditAndContinueRemap(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFunction function, bool accurate)
        {
            Continue(appDomain, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eval"></param>
        public override void EvalComplete(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugEval eval)
        {
            var eventArgs = FireEvent(this.EvalCompleteEvent, () => new CorDebugEvalEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread), new CorDebugEval(eval)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eval"></param>
        public override void EvalException(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugEval eval)
        {
            var eventArgs = FireEvent(this.EvalExceptionEvent, () => new CorDebugEvalEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread), new CorDebugEval(eval)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="unhandled"></param>
        public override void Exception(ICorDebugAppDomain appDomain, ICorDebugThread thread, bool unhandled)
        {
            var eventArgs = FireEvent(this.ExceptionEvent, () => new CorDebugExceptionEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread), unhandled));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="frame"></param>
        /// <param name="offset"></param>
        /// <param name="eventType"></param>
        /// <param name="flags"></param>
        public override void Exception(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFrame frame, uint offset, CorDebugExceptionCallbackType eventType, CorDebugExceptionFlags flags)
        {
            var eventArgs = FireEvent(this.ExceptionStartSearchHandlerEvent, () => new CorDebugExceptionHandlerEventArgs(this.DebugProcess,
                                                                                                                    new CorDebugAppDomain(appDomain),
                                                                                                                    new CorDebugThread(thread),
                                                                                                                    new CorDebugFrame(frame),
                                                                                                                    offset,
                                                                                                                    eventType,
                                                                                                                    flags));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="eventType"></param>
        /// <param name="flags"></param>
        public override void ExceptionUnwind(ICorDebugAppDomain appDomain, ICorDebugThread thread, CorDebugExceptionUnwindCallbackType eventType, CorDebugExceptionFlags flags)
        {
            var eventArgs = FireEvent(this.ExceptionUnwindEvent, () => new CorDebugExceptionUnwindEventArgs(this.DebugProcess,
                                                                                                                    new CorDebugAppDomain(appDomain),
                                                                                                                    new CorDebugThread(thread),
                                                                                                                    eventType,
                                                                                                                    flags));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        /// <param name="appDomain"></param>
        public override void ExitAppDomain(ICorDebugProcess process, ICorDebugAppDomain appDomain)
        {
            var eventArgs = FireEvent(this.ExitAppDomainEvent, () => new CorDebugAppDomainEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
        public override void ExitProcess(ICorDebugProcess process)
        {
            var eventArgs = FireEvent(this.ExitProcessEvent, () => new CorDebugProcessEventArgs(this.DebugProcess));
            Continue(process, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        public override void ExitThread(ICorDebugAppDomain appDomain, ICorDebugThread thread)
        {
            var eventArgs = FireEvent(this.ExitThreadEvent, () => new CorDebugThreadEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="function"></param>
        public override void FunctionRemapComplete(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFunction function)
        {
            var eventArgs = FireEvent(this.FunctionRemapEvent, () => new CorDebugFunctionEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread), new CorDebugFunction(function)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="oldFunction"></param>
        /// <param name="newFunction"></param>
        /// <param name="oldILOffset"></param>
        public override void FunctionRemapOpportunity(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugFunction oldFunction, ICorDebugFunction newFunction, uint oldILOffset)
        {
            var eventArgs = FireEvent(this.FunctionRemapOpportunityEvent, () => new CorDebugFunctionRemapOpportunityEventArgs(this.DebugProcess,
                                                                                                                new CorDebugAppDomain(appDomain),
                                                                                                                new CorDebugThread(thread),
                                                                                                                new CorDebugFunction(newFunction),
                                                                                                                new CorDebugFunction(oldFunction),
                                                                                                                oldILOffset));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="assembly"></param>
        public override void LoadAssembly(ICorDebugAppDomain appDomain, ICorDebugAssembly assembly)
        {
            var eventArgs = FireEvent(this.LoadAssemblyEvent, () => new CorDebugAssemblyEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugAssembly(assembly)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="class"></param>
        public override void LoadClass(ICorDebugAppDomain appDomain, ICorDebugClass @class)
        {
            var eventArgs = FireEvent(this.LoadClassEvent, () => new CorDebugClassEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugClass(@class)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        public override void LoadModule(ICorDebugAppDomain appDomain, ICorDebugModule module)
        {
            var eventArgs = FireEvent(this.LoadModuleEvent, () => new CorDebugModuleEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugModule(module)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="level"></param>
        /// <param name="logSwitchName"></param>
        /// <param name="message"></param>
        public override void LogMessage(ICorDebugAppDomain appDomain, ICorDebugThread thread, int level, string logSwitchName, string message)
        {
            var eventArgs = FireEvent(this.LogMessageEvent, () => new CorDebugLogMessageEventArgs(this.DebugProcess,
                                                                                                        new CorDebugAppDomain(appDomain),
                                                                                                        new CorDebugThread(thread),
                                                                                                        level,
                                                                                                        logSwitchName,
                                                                                                        message));
            Continue(appDomain, eventArgs);
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
        public override void LogSwitch(ICorDebugAppDomain appDomain, ICorDebugThread thread, int level, LogSwitchCallReason reason, string logSwitchName, string parentName)
        {
            var eventArgs = FireEvent(this.LogSwitchEvent, () => new CorDebugLogSwitchEventArgs(this.DebugProcess,
                                                                                                        new CorDebugAppDomain(appDomain),
                                                                                                        new CorDebugThread(thread),
                                                                                                        level,
                                                                                                        reason,
                                                                                                        logSwitchName,
                                                                                                        parentName));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="thread"></param>
        /// <param name="MDA"></param>
        public override void MDANotification(ICorDebugController controller, ICorDebugThread thread, ICorDebugMDA MDA)
        {
            base.MDANotification(controller, thread, MDA);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        public override void NameChange(ICorDebugAppDomain appDomain, ICorDebugThread thread)
        {
            var eventArgs = FireEvent(this.NameChangeEvent, () => new CorDebugThreadEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="stepper"></param>
        /// <param name="reason"></param>
        public override void StepComplete(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugStepper stepper, CorDebugStepReason reason)
        {
            var eventArgs = FireEvent(this.StepCompleteEvent, () => new CorDebugStepEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugThread(thread), new CorDebugStepper(stepper), reason));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="assembly"></param>
        public override void UnloadAssembly(ICorDebugAppDomain appDomain, ICorDebugAssembly assembly)
        {
            var eventArgs = FireEvent(this.UnloadAssemblyEvent, () => new CorDebugAssemblyEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugAssembly(assembly)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="class"></param>
        public override void UnloadClass(ICorDebugAppDomain appDomain, ICorDebugClass @class)
        {
            var eventArgs = FireEvent(this.UnloadClassEvent, () => new CorDebugClassEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugClass(@class)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        public override void UnloadModule(ICorDebugAppDomain appDomain, ICorDebugModule module)
        {
            var eventArgs = FireEvent(this.UnloadModuleEvent, () => new CorDebugModuleEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugModule(module)));
            Continue(appDomain, eventArgs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="module"></param>
        /// <param name="symbolStream"></param>
        public override void UpdateModuleSymbols(ICorDebugAppDomain appDomain, ICorDebugModule module, IStream symbolStream)
        {
            var eventArgs = FireEvent(this.UpdateModuleSymbolsEvent, () => new CorDebugModuleSymbolsEventArgs(this.DebugProcess, new CorDebugAppDomain(appDomain), new CorDebugModule(module), symbolStream));
            Continue(appDomain, eventArgs);
        }
        #endregion
    }
}
