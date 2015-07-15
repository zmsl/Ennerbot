using System;

namespace Ennerbot
{
    [Serializable]
    public class SimulateKeyAction : BaseAction
    {
        private VirtualKeys _key;

        internal SimulateKeyAction()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="SimulateKeyAction"/> class
        /// </summary>
        /// <param name="key"></param>
        public SimulateKeyAction(VirtualKeys key)
        {
            this._key = key;
        }

        /// <summary>
        /// Gets the key to simulate
        /// </summary>
        public VirtualKeys Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        /// <summary>
        /// Executes the simulate key action
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        public override void Execute(IMacroActionExecutor executor, IExecutionContext context)
        {
            executor.Execute(this, context);
        }

        /// <summary>
        /// Validates the simulate key action
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="context"></param>
        public override IMacroActionValidationResult Validate(IMacroActionValidator validator, IMacroValidationContext context)
        {
            return validator.Validate(this, context);
        }

        /// <summary>
        /// Converts action to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("KEY {0}", this.Key.ToString());
        }

        /// <summary>
        /// Returns false because this is not a buddy action
        /// </summary>
        public override bool IsBuddyAction
        {
            get { return false; }
        }
    }
}
