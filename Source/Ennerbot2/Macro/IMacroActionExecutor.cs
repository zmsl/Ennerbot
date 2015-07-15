namespace Ennerbot
{
    public interface IMacroActionExecutor
    {
        /// <summary>
        /// Executes a call method action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        void Execute(CallMethodAction action, IExecutionContext context);

        /// <summary>
        /// Executes a send text action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        void Execute(SendTextAction action, IExecutionContext context);

        /// <summary>
        /// Executes a simulate key action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        void Execute(SimulateKeyAction action, IExecutionContext context);

        /// <summary>
        /// Executes a wait action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        void Execute(WaitAction action, IExecutionContext context);
    }
}
