namespace Ennerbot
{
    public interface IMacroValidationContext
    {
        /// <summary>
        /// Gets the macro validator being used
        /// </summary>
        IMacroValidator MacroValidator { get; }

        /// <summary>
        /// Gets the method register to use during validation
        /// </summary>
        IMacroMethodRegister MethodRegister { get; }
    }
}
