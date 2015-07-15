using System.Threading;
using System.Threading.Tasks;

namespace Ennerbot
{
    public interface IMacroRoutineExecutor
    {
        /// <summary>
        /// Executes the macro
        /// </summary>
        /// <param name="macro"></param>
        /// <param name="register"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="pauseToken"></param>
        void Execute(IMacroRoutine macro, IMacroMethodRegister register, CancellationToken cancellationToken = new CancellationToken(), IPauseToken pauseToken = null);

        /// <summary>
        /// Executes the macro asyncronously
        /// </summary>
        /// <param name="macro"></param>
        /// <param name="register"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="pauseToken"></param>
        /// <returns></returns>
        Task ExecuteAsync(IMacroRoutine macro, IMacroMethodRegister register, CancellationToken cancellationToken = new CancellationToken(), IPauseToken pauseToken = null);
    }
}
