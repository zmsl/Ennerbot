using System.Threading;

namespace Ennerbot
{
    public class ExecutionContext : IExecutionContext
    {
        private readonly IMacroRoutineExecutor _routineExecutor;
        private readonly IMacroMethodRegister _methodRegister;
        private readonly CancellationToken _cancellationToken;
        private readonly IPauseToken _pauseToken;

        /// <summary>
        /// Instantiates a new instance of the <see cref="ExecutionContext"/> class
        /// </summary>
        /// <param name="routineExecutor"></param>
        /// <param name="methodRegister"></param>
        public ExecutionContext(IMacroRoutineExecutor routineExecutor, IMacroMethodRegister methodRegister)
        {
            this._routineExecutor = routineExecutor;
            this._methodRegister = methodRegister;
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="ExecutionContext"/> class
        /// </summary>
        /// <param name="routineExecutor"></param>
        /// <param name="methodRegister"></param>
        /// <param name="cancellationToken"></param>
        public ExecutionContext(IMacroRoutineExecutor routineExecutor, IMacroMethodRegister methodRegister, CancellationToken cancellationToken, IPauseToken pauseToken)
            : this(routineExecutor, methodRegister)
        {
            this._cancellationToken = cancellationToken;
            this._pauseToken = pauseToken;
        }

        /// <summary>
        /// Gets the routine executor doing the execution
        /// </summary>
        public IMacroRoutineExecutor RoutineExecutor
        {
            get { return this._routineExecutor; }
        }

        /// <summary>
        /// Gets the method register used during execution
        /// </summary>
        public IMacroMethodRegister MethodRegister
        {
            get { return this._methodRegister; }
        }

        /// <summary>
        /// Gets the cancellation token used during execution
        /// </summary>
        public CancellationToken CancellationToken
        {
            get { return this._cancellationToken; }
        }

        /// <summary>
        /// Gets the pause token used during execution
        /// </summary>
        public IPauseToken PauseToken
        {
            get { return this._pauseToken; }
        }
    }
}
