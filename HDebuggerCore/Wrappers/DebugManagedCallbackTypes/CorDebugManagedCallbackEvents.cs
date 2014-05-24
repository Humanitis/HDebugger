namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;









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
        public event CorDebugManagedCallbackHandler<CorDebugConnectionEventArgs> DestroyConnectionEvent;
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
        /// <param name="process"></param>
        /// <param name="errorHR"></param>
        /// <param name="errorCode"></param>
        public override void DebuggerError(ICorDebugProcess process, ulong errorHR, int errorCode)
        {
            base.DebuggerError(process, errorHR, errorCode);
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
        #endregion
    }
}
