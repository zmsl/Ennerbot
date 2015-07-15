namespace Ennerbot
{
    public class WindowMacroActionExecutor : IMacroActionExecutor
    {
        private readonly IWindow _window;

        /// <summary>
        /// Instantiates a new instance of the <see cref="WindowMacroActionExecutor"/> class
        /// </summary>
        /// <param name="window"></param>
        public WindowMacroActionExecutor(IWindow window)
        {
            this._window = window;
        }

        /// <summary>
        /// Executes the call method action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Execute(CallMethodAction action, IExecutionContext context)
        {
            var method = context.MethodRegister.Get(action.MethodName);
            context.RoutineExecutor.Execute(new MacroRoutine(1, method.Actions), context.MethodRegister, context.CancellationToken, context.PauseToken);
        }

        /// <summary>
        /// Executes the send text action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Execute(SendTextAction action, IExecutionContext context)
        {
            this._window.SendText(action.Text);
        }

        /// <summary>
        /// Executes the simulate key action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Execute(SimulateKeyAction action, IExecutionContext context)
        {
            this._window.SendKey((ushort) action.Key);
        }

        /// <summary>
        /// Executes the wait action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Execute(WaitAction action, IExecutionContext context)
        {
            context.CancellationToken.WaitHandle.WaitOne(action.WaitSpan);
        }
    }
}
