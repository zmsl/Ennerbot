using System.Threading;

namespace Ennerbot
{
    public interface IExecutionContext
    {
        /// <summary>
        /// Gets the routine executor used during execution
        /// </summary>
        IMacroRoutineExecutor RoutineExecutor { get; }

        /// <summary>
        /// Gets the method register used during execution
        /// </summary>
        IMacroMethodRegister MethodRegister { get; }

        /// <summary>
        /// Gets the cancellation token used during execution
        /// </summary>
        CancellationToken CancellationToken { get; }

        /// <summary>
        /// Gets the pause token used during execution
        /// </summary>
        IPauseToken PauseToken { get; }
    }
}
