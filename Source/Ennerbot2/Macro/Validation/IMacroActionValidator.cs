namespace Ennerbot
{
    public interface IMacroActionValidator
    {
        /// <summary>
        /// Validates the call method action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IMacroActionValidationResult Validate(CallMethodAction action, IMacroValidationContext context);

        /// <summary>
        /// Validates the send text action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IMacroActionValidationResult Validate(SendTextAction action, IMacroValidationContext context);

        /// <summary>
        /// Validates the simulate key action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IMacroActionValidationResult Validate(SimulateKeyAction action, IMacroValidationContext context);

        /// <summary>
        /// Validates the wait action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IMacroActionValidationResult Validate(WaitAction action, IMacroValidationContext context);
    }
}
