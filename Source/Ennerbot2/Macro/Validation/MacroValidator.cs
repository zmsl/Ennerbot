using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ennerbot
{
    public class MacroValidator : IMacroValidator
    {
        private readonly IMacroActionValidator _actionValidator;
        private readonly IMacroMethodRegister _register;

        private int _depth;

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroValidator"/> class
        /// </summary>
        /// <param name="actionValidator"></param>
        /// <param name="register"></param>
        public MacroValidator(IMacroActionValidator actionValidator, IMacroMethodRegister register)
        {
            this._actionValidator = actionValidator;
            this._register = register;
            this._depth = 0;
        }

        /// <summary>
        /// Validates the macro
        /// </summary>
        /// <param name="macro"></param>
        /// <returns></returns>
        public IMacroValidationResult Validate(IMacro macro)
        {
            return this.Validate(macro.Actions);
        }

        /// <summary>
        /// Validates the macro
        /// </summary>
        /// <param name="actions"></param>
        /// <returns></returns>
        public IMacroValidationResult Validate(IList<IMacroAction> actions)
        {
            var context = new MacroValidationContext(this, this._register);

            // Increase depth
            this._depth++;

            // Return invalid if the depth moves past 25
            if (this._depth > 25)
            {
                return new MacroValidationResult(false);
            }

            // Get validation result
            try
            {
                return
                    new MacroValidationResult(
                        actions.Select(a => a.Validate(this._actionValidator, context)).ToList());
            }
            catch (Exception)
            {
                return new MacroValidationResult(false);
            }
            finally
            {
                // Decrease depth
                this._depth--;
            }
        }
    }
}
