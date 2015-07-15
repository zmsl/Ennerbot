using System;

namespace Ennerbot
{
    [Serializable]
    public class SendTextAction : BaseAction
    {
        private string _text;

        internal SendTextAction()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="SendTextAction"/> class
        /// </summary>
        /// <param name="text"></param>
        public SendTextAction(string text)
        {
            this._text = text;
        }

        /// <summary>
        /// Gets the text to send
        /// </summary>
        public string Text
        {
            get { return this._text; }
            set { this._text = value; }
        }

        /// <summary>
        /// Executes the send text action
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        public override void Execute(IMacroActionExecutor executor, IExecutionContext context)
        {
            executor.Execute(this, context);
        }

        /// <summary>
        /// Validates the send text action
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
            return string.Format("TEXT \"{0}\"", this.Text);
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
