using System;
using System.Collections.Generic;

namespace Ennerbot
{
    public class MacroMethod : IMacroMethod
    {
        private readonly string _name;
        private readonly IList<IMacroAction> _actions;

        internal MacroMethod()
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroMethod"/> class
        /// </summary>
        /// <param name="name"></param>
        public MacroMethod(string name)
            : this(name, null)
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroMethod"/> class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="actions"></param>
        public MacroMethod(string name, IList<IMacroAction> actions)
        {
            this._name = name ?? string.Empty;
            this._actions = actions ?? new List<IMacroAction>();
        }

        /// <summary>
        /// Implements <see cref="IEquatable{IMacroMethod}"/> Equals method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IMacroMethod other)
        {
            return this.Equals(other.Name);
        }

        /// <summary>
        /// Implements <see cref="IEquatable{IMacroMethod}"/> Equals method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(string other)
        {
            return this._name.Equals(other, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Returns the object hash code for hash set lookups
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this._name.GetHashCode();
        }

        /// <summary>
        /// Gets the name of the macro
        /// </summary>
        public string Name
        {
            get { return this._name; }
        }

        /// <summary>
        /// Gets the actions performed by the macro
        /// </summary>
        public IList<IMacroAction> Actions
        {
            get { return this._actions; }
        }
    }
}
