namespace Ennerbot
{
    public interface IMacroValidator
    {
        /// <summary>
        /// Validates the macro
        /// </summary>
        /// <param name="macro"></param>
        /// <returns></returns>
        IMacroValidationResult Validate(IMacro macro);
    }
}
