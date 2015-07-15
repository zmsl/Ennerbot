namespace Ennerbot
{
    public interface IMacroAction
    {
        /// <summary>
        /// Executes the action using the specified executor
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        void Execute(IMacroActionExecutor executor, IExecutionContext context);

        /// <summary>
        /// Validates the action using the specified validator
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="context"></param>
        IMacroActionValidationResult Validate(IMacroActionValidator validator, IMacroValidationContext context);

        /// <summary>
        /// Gets whether this implementation of IMacroAction 
        /// </summary>
        bool IsBuddyAction { get; }
    }
}
