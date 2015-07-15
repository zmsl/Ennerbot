using System;
using System.Threading;

namespace Ennerbot
{
    public class ConsoleMacroActionExecutor : IMacroActionExecutor
    {
        /// <summary>
        /// Executes the call method action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Execute(CallMethodAction action, IExecutionContext context)
        {
            Console.WriteLine("Method {0} entered", action.MethodName);

            var routine = new MacroRoutine(1, context.MethodRegister.Get(action.MethodName).Actions);
            context.RoutineExecutor.Execute(routine, context.MethodRegister, context.CancellationToken, context.PauseToken);

            Console.WriteLine("Method {0} exited", action.MethodName);
        }

        /// <summary>
        /// Executes the send text action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Execute(SendTextAction action, IExecutionContext context)
        {
            Console.WriteLine("Text sent: {0}", action.Text);
        }

        /// <summary>
        /// Executes the simulate key action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Execute(SimulateKeyAction action, IExecutionContext context)
        {
            Console.WriteLine("Key pressed: {0}", action.Key.ToString());
        }

        /// <summary>
        /// Executes the wait action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        public void Execute(WaitAction action, IExecutionContext context)
        {
            context.CancellationToken.WaitHandle.WaitOne(action.WaitSpan);
            Console.WriteLine("Waited: {0}", action.WaitSpan.ToString());
        }
    }
}
