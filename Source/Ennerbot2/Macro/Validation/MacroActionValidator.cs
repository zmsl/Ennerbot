namespace Ennerbot
{
    public class MacroActionValidator : IMacroActionValidator
    {
        /// <summary>
        /// Validates the call method action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IMacroActionValidationResult Validate(CallMethodAction action, IMacroValidationContext context)
        {
            var method = context.MethodRegister.Get(action.MethodName);
            return method == null
                ? new MacroActionValidationResult(action, false)
                : new MacroActionValidationResult(action, true, context.MacroValidator.Validate(method));
        }

        /// <summary>
        /// Validates the send text action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IMacroActionValidationResult Validate(SendTextAction action, IMacroValidationContext context)
        {
            return new MacroActionValidationResult(action, !string.IsNullOrWhiteSpace(action.Text));
        }

        /// <summary>
        /// Validates the simulate key action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IMacroActionValidationResult Validate(SimulateKeyAction action, IMacroValidationContext context)
        {
            return new MacroActionValidationResult(action, true);
        }

        /// <summary>
        /// Validates the wait action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IMacroActionValidationResult Validate(WaitAction action, IMacroValidationContext context)
        {
            return new MacroActionValidationResult(action, true);
        }
    }
}
