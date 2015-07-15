namespace Ennerbot
{
    public interface IMacroActionValidationResult
    {
        /// <summary>
        /// Gets the validity of the action
        /// </summary>
        bool Valid { get; }

        /// <summary>
        /// Gets the validated macro action
        /// </summary>
        IMacroAction Action { get; }

        /// <summary>
        /// 
        /// </summary>
        IMacroValidationResult ChildResult { get; }
    }
}
