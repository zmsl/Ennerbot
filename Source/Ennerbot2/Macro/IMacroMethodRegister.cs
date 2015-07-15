using System.Collections.Generic;

namespace Ennerbot
{
    public interface IMacroMethodRegister : IEnumerable<IMacroMethod>
    {
        /// <summary>
        /// Registers the macro method with the method store
        /// </summary>
        /// <param name="method"></param>
        void Register(IMacroMethod method);

        /// <summary>
        /// Clears the methods
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns true if the method name is found in the method store
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        bool Exists(string methodName);

        /// <summary>
        /// Gets the method by method name
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        IMacroMethod Get(string methodName);

        /// <summary>
        /// Deletes the method by method name
        /// </summary>
        /// <param name="methodName"></param>
        void Delete(string methodName);
    }
}
