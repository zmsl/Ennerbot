using System.Collections.Generic;
using System.Linq;

namespace Ennerbot
{
    public class MacroValidationResult : IMacroValidationResult
    {
        private readonly bool _valid = true;
        private readonly IList<IMacroActionValidationResult> _results;

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroValidationResult"/> class
        /// </summary>
        public MacroValidationResult()
            : this(new List<IMacroActionValidationResult>())
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroValidationResult"/> class
        /// </summary>
        /// <param name="results"></param>
        public MacroValidationResult(IList<IMacroActionValidationResult> results)
        {
            this._results = results;
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroValidationResult"/> class
        /// </summary>
        /// <param name="valid"></param>
        public MacroValidationResult(bool valid)
            : this(new List<IMacroActionValidationResult>())
        {
            this._valid = valid;
        }

        /// <summary>
        /// Gets the macro validity
        /// </summary>
        public bool Valid
        {
            get
            {
                return this._valid && this.Results.Aggregate(true, (current, r) => current & r.Valid);
            }
        }

        /// <summary>
        /// Gets the action validation results
        /// </summary>
        public IList<IMacroActionValidationResult> Results
        {
            get { return this._results; }
        }
    }
}
