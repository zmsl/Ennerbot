using System;
using System.Xml.Serialization;

namespace Ennerbot
{
    [Serializable]
    [XmlInclude(typeof(CallMethodAction))]
    [XmlInclude(typeof(SendTextAction))]
    [XmlInclude(typeof(SimulateKeyAction))]
    [XmlInclude(typeof(WaitAction))]
    public abstract class BaseAction : IMacroAction
    {
        /// <summary>
        /// Executes the action
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        public abstract void Execute(IMacroActionExecutor executor, IExecutionContext context);

        /// <summary>
        /// Validates the action
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract IMacroActionValidationResult Validate(IMacroActionValidator validator,
            IMacroValidationContext context);

        /// <summary>
        /// Gets whether this is a buddy action
        /// </summary>
        public abstract bool IsBuddyAction { get; }
    }
}
