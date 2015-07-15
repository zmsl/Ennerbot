using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ennerbot
{
    public class MacroMethodRegister : IMacroMethodRegister
    {
        private readonly IList<IMacroMethod> _methods;

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroMethodRegister"/> class
        /// </summary>
        public MacroMethodRegister()
        {
            this._methods = new List<IMacroMethod>();
        }

        /// <summary>
        /// Clears the methods
        /// </summary>
        public void Clear()
        {
            this._methods.Clear();
        }

        /// <summary>
        /// Registers a method with the method collection. If the method
        /// already exists it will be updated
        /// </summary>
        /// <param name="method"></param>
        public void Register(IMacroMethod method)
        {
            var idx = -1;
            for (var i = 0; i < this._methods.Count; i++)
            {
                if (!this._methods[i].Name.Equals(method.Name, StringComparison.InvariantCultureIgnoreCase)) continue;

                idx = i;
                break;
            }

            if (idx >= 0)
            {
                this._methods[idx] = method;
            }
            else
            {
                this._methods.Add(method);
            }
        }

        /// <summary>
        /// Returns whether the method exists in the collection
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public bool Exists(string methodName)
        {
            return this._methods.Any(mm => mm.Name.Equals(methodName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Returns the method referenced by the method name
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public IMacroMethod Get(string methodName)
        {
            return
                this._methods.FirstOrDefault(
                    mm => mm.Name.Equals(methodName, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Removes the method from the register
        /// </summary>
        /// <param name="methodName"></param>
        public void Delete(string methodName)
        {
            if (this.Exists(methodName))
            {
                this._methods.Remove(this.Get(methodName));
            }
        }

        /// <summary>
        /// Returns the register enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IMacroMethod> GetEnumerator()
        {
            return this._methods.GetEnumerator();
        }

        /// <summary>
        /// Returns the register enumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
