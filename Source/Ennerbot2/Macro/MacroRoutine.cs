using System.Collections.Generic;
using System.Text;

namespace Ennerbot
{
    public class MacroRoutine : IMacroRoutine
    {
        private readonly int _repetitions;
        private readonly IList<IMacroAction> _actions;

        internal MacroRoutine()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroRoutine"/> class
        /// </summary>
        /// <param name="repetitions"></param>
        public MacroRoutine(int repetitions)
            : this(repetitions, new List<IMacroAction>())
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroRoutine"/> class
        /// </summary>
        /// <param name="repetitions"></param>
        /// <param name="actions"></param>
        public MacroRoutine(int repetitions, IList<IMacroAction> actions)
        {
            this._repetitions = repetitions;
            this._actions = actions;
        }

        /// <summary>
        /// Returns a string representation of the routine
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            for (var idx = 0; idx < this._actions.Count; idx++)
            {
                builder.AppendFormat("{0}{1}", this._actions[idx].ToString(),
                    idx == this._actions.Count - 1 ? string.Empty : "\r\n");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Gets the macro actions
        /// </summary>
        public IList<IMacroAction> Actions
        {
            get { return this._actions; }
        }

        /// <summary>
        /// Gets the number of repetitions to run
        /// </summary>
        public int Repetitions
        {
            get { return this._repetitions; }
        }
    }
}
