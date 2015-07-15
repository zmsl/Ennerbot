using System;

namespace Ennerbot
{
    [Serializable]
    public class CallMethodAction : BaseAction
    {
        private string _methodName;
        private int _repeatEvery;
        private int _repeatCountdown;

        internal CallMethodAction()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="CallMethodAction"/> class
        /// </summary>
        /// <param name="methodName"></param>
        public CallMethodAction(string methodName)
            : this(methodName, 1)
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="CallMethodAction"/> class
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="repeatEvery"></param>
        public CallMethodAction(string methodName, int repeatEvery)
        {
            this._methodName = methodName;
            this._repeatEvery = repeatEvery;
            this._repeatCountdown = 1;
        }

        /// <summary>
        /// Returns the method name
        /// </summary>
        public string MethodName
        {
            get { return this._methodName; }
            set { this._methodName = value; }
        }

        /// <summary>
        /// Gets or sets the number of repetions in between execution
        /// </summary>
        public int RepeatEvery
        {
            get { return this._repeatEvery; }
            set { this._repeatEvery = value; }
        }

        /// <summary>
        /// Executes the call method action
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        public override void Execute(IMacroActionExecutor executor, IExecutionContext context)
        {
            this._repeatCountdown--;

            // If the countdown is less than or equal to 0 then execute
            if (this._repeatCountdown <= 0)
            {
                executor.Execute(this, context);

                // Set the repeat countdown to the default
                this._repeatCountdown = this._repeatEvery;
            }
        }

        /// <summary>
        /// Validates the action using the context
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="context"></param>
        /// <returns></returns>
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
            return string.Format("CALL \"{0}\"{1}", this.MethodName, this._repeatEvery > 1 ? string.Format(" EVERY {0}", this._repeatEvery) : string.Empty);
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
