namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;









    /// <summary>
    /// 
    /// </summary>
    public class CorDebugManagedCallbackEvents : CorDebugManagedCallbackBase
    {
        #region Events
        /// <summary>
        /// 
        /// </summary>
        public event CorDebugManagedCallbackHandler<CorDebugThreadEventArgs> Break;
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
        protected override void Break(ICorDebugAppDomain appDomain, ICorDebugThread thread)
        {
            var eventArgs = FireEvent(this.Break, () => new CorDebugThreadEventArgs(appDomain, thread));
            Continue(appDomain, eventArgs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appDomain"></param>
        /// <param name="thread"></param>
        /// <param name="breakpoint"></param>
        protected override void Breakpoint(ICorDebugAppDomain appDomain, ICorDebugThread thread, ICorDebugBreakpoint breakpoint)
        {
            base.Breakpoint(appDomain, thread, breakpoint);
        }

        #endregion
    }
}
