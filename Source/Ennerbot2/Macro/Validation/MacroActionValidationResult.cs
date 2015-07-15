namespace Ennerbot
{
    public class MacroActionValidationResult : IMacroActionValidationResult
    {
        private readonly IMacroAction _action;
        private readonly bool _valid;
        private readonly IMacroValidationResult _childResult; 

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroActionValidationResult"/> class
        /// </summary>
        /// <param name="action"></param>
        /// <param name="valid"></param>
        /// <param name="childResult"></param>
        public MacroActionValidationResult(IMacroAction action, bool valid, IMacroValidationResult childResult = null)
        {
            this._action = action;
            this._valid = valid;
            this._childResult = childResult;
        }

        /// <summary>
        /// Gets whether or not the action is valid
        /// </summary>
        public bool Valid 
        {
            get { return this._valid && (this._childResult == null || this._childResult.Valid); }
        }

        /// <summary>
        /// Gets the validated action
        /// </summary>
        public IMacroAction Action
        {
            get { return this._action; }
        }

        /// <summary>
        /// Gets the child result
        /// </summary>
        public IMacroValidationResult ChildResult
        {
            get { return this._childResult; }
        }
    }
}
