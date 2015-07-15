using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ennerbot
{
    public class MacroRoutineExecutor : IMacroRoutineExecutor
    {
        private readonly IMacroActionExecutor _actionExecutor;

        private int _depth = 0;

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroRoutineExecutor"/> class
        /// </summary>
        /// <param name="actionExecutor"></param>
        public MacroRoutineExecutor(IMacroActionExecutor actionExecutor)
        {
            this._actionExecutor = actionExecutor;
        }

        /// <summary>
        /// Executes the macro routine
        /// </summary>
        /// <param name="macro"></param>
        /// <param name="register"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="pauseToken"></param>
        public void Execute(IMacroRoutine macro, IMacroMethodRegister register,
            CancellationToken cancellationToken = new CancellationToken(), IPauseToken pauseToken = null)
        {
            this.DoExecute(macro, register, cancellationToken, pauseToken);
        }

        /// <summary>
        /// Executes the macro routine async
        /// </summary>
        /// <param name="macro"></param>
        /// <param name="register"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="pauseToken"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(IMacroRoutine macro, IMacroMethodRegister register, 
            CancellationToken cancellationToken = new CancellationToken(), IPauseToken pauseToken = null)
        {
            await Task.Factory.StartNew(() => this.DoExecute(macro, register, cancellationToken, pauseToken), cancellationToken);
        }

        /// <summary>
        /// Executes the macro routine
        /// </summary>
        /// <param name="macro"></param>
        /// <param name="register"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="pauseToken"></param>
        private void DoExecute(IMacroRoutine macro, IMacroMethodRegister register, CancellationToken cancellationToken, IPauseToken pauseToken)
        {
            if (this._depth > 25) throw new StackOverflowException("Recursive depth of the macro exceeded the limit");

            var context = new ExecutionContext(this, register, cancellationToken, pauseToken);

            // Increase the executor depth to prevent recursion
            this._depth++;

            for (var repetition = 1; repetition <= macro.Repetitions; repetition++)
            {
                // Fire repetition started event if this is the top level
                if (this._depth == 1)
                {
                    this.MacroRoutine_RepetitionStarted(context, repetition);
                }

                // Execute the actions
                foreach (var action in macro.Actions)
                {
                    // Cancel if requested
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    // Pause if requested
                    while (pauseToken.PauseRequested && !cancellationToken.IsCancellationRequested)
                    {
                        Thread.Sleep(500);
                    }

                    // Fire action started event
                    if (this._depth == 1)
                    {
                        this.MacroRoutine_OnActionStarted(context, action);
                    }

                    // Execute the action
                    action.Execute(this._actionExecutor, context);

                    // Fire action ended event
                    if (this._depth == 1)
                    {
                        this.MacroRoutine_OnActionEnded(context, action);
                    }
                }

                // Fire repetition ended event
                if (this._depth == 1)
                {
                    this.MacroRoutine_RepetitionEnded(context, repetition);
                }
            }

            // Reduce the executor depth
            this._depth--;
        }

        #region Events
        /// <summary>
        /// Delegate that handles repetition started events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="context"></param>
        /// <param name="repetition"></param>
        public delegate void RepetitionBoundaryEvent(IMacroRoutineExecutor sender, IExecutionContext context, int repetition);

        /// <summary>
        /// Fired when a new repetition has started
        /// </summary>
        public event RepetitionBoundaryEvent OnRepetitionStarted;

        /// <summary>
        /// Fired when a repetition has ended
        /// </summary>
        public event RepetitionBoundaryEvent OnRepetitionEnded;

        /// <summary>
        /// Fires the repetition started event
        /// </summary>
        /// <param name="context"></param>
        /// <param name="repetition"></param>
        protected virtual void MacroRoutine_RepetitionStarted(IExecutionContext context, int repetition)
        {
            var handler = OnRepetitionStarted;
            if (handler != null) handler(this, context, repetition);
        }

        /// <summary>
        /// Fires the repetition ended event
        /// </summary>
        /// <param name="context"></param>
        /// <param name="repetition"></param>
        protected virtual void MacroRoutine_RepetitionEnded(IExecutionContext context, int repetition)
        {
            var handler = OnRepetitionEnded;
            if (handler != null) handler(this, context, repetition);
        }

        /// <summary>
        /// Delegate that handles action started events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="context"></param>
        /// <param name="action"></param>
        public delegate void ActionBoundaryEvent(IMacroRoutineExecutor sender, IExecutionContext context, IMacroAction action);

        /// <summary>
        /// Fired when an action has started
        /// </summary>
        public event ActionBoundaryEvent OnActionStarted;

        /// <summary>
        /// Fired when an action has ended
        /// </summary>
        public event ActionBoundaryEvent OnActionEnded;

        /// <summary>
        /// Fires the action started event
        /// </summary>
        /// <param name="context"></param>
        /// <param name="action"></param>
        protected virtual void MacroRoutine_OnActionStarted(IExecutionContext context, IMacroAction action)
        {
            var handler = OnActionStarted;
            if (handler != null) handler(this, context, action);
        }

        /// <summary>
        /// Fires the action ended event
        /// </summary>
        /// <param name="context"></param>
        /// <param name="action"></param>
        protected virtual void MacroRoutine_OnActionEnded(IExecutionContext context, IMacroAction action)
        {
            var handler = OnActionEnded;
            if (handler != null) handler(this, context, action);
        }
        #endregion
    }
}
