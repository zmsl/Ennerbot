namespace Ennerbot
{
    public class MacroValidationContext : IMacroValidationContext
    {
        private readonly IMacroValidator _macroValidator;
        private readonly IMacroMethodRegister _macroMethodRegister;

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroValidationContext"/> class
        /// </summary>
        /// <param name="macroValidator"></param>
        /// <param name="macroMethodRegister"></param>
        public MacroValidationContext(IMacroValidator macroValidator, IMacroMethodRegister macroMethodRegister)
        {
            this._macroValidator = macroValidator;
            this._macroMethodRegister = macroMethodRegister;
        }

        /// <summary>
        /// Gets the macro validator being used
        /// </summary>
        public IMacroValidator MacroValidator
        {
            get { return this._macroValidator; }
        }

        /// <summary>
        /// Gets the macro register to use during validation
        /// </summary>
        public IMacroMethodRegister MethodRegister
        {
            get { return this._macroMethodRegister; }
        }
    }
}
