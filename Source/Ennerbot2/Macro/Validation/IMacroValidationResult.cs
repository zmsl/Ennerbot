using System.Collections.Generic;

namespace Ennerbot
{
    public interface IMacroValidationResult
    {
        /// <summary>
        /// Gets whether the macro is valid
        /// </summary>
        bool Valid { get; }

        /// <summary>
        /// Gets the macro action validation results
        /// </summary>
        IList<IMacroActionValidationResult> Results { get; }
    }
}
