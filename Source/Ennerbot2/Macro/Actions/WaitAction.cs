using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Ennerbot
{
    [Serializable]
    public class WaitAction : BaseAction
    {
        private TimeSpan _waitSpan;

        internal WaitAction()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="WaitAction"/> class
        /// </summary>
        /// <param name="seconds"></param>
        public WaitAction(int seconds)
            : this(new TimeSpan(0, 0, 0, 0, seconds))
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="WaitAction"/> class
        /// </summary>
        /// <param name="waitSpan"></param>
        public WaitAction(TimeSpan waitSpan)
        {
            this._waitSpan = waitSpan;
        }

        /// <summary>
        /// Gets the timespan to wait
        /// </summary>
        [XmlIgnore()]
        public TimeSpan WaitSpan
        {
            get { return this._waitSpan; }
            set { this._waitSpan = value; }
        }

        /// <summary>
        /// Gets or sets the timespan by ticks
        /// </summary>
        public long WaitTicks
        {
            get { return this._waitSpan.Ticks; }
            set { this._waitSpan = new TimeSpan(value); }
        }

        /// <summary>
        /// Executes the wait action
        /// </summary>
        /// <param name="executor"></param>
        /// <param name="context"></param>
        public override void Execute(IMacroActionExecutor executor, IExecutionContext context)
        {
            executor.Execute(this, context);
        }

        /// <summary>
        /// Validates the wait action
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
            return string.Format("WAIT {0}", this.WaitSpan.Minutes > 0 ? this.WaitSpan.ToString() : this.WaitSpan.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
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
