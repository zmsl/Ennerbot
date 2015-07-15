using System.Collections.Generic;

namespace Ennerbot
{
    public interface IMacro
    {
        /// <summary>
        /// Actions to execute in the method
        /// </summary>
        IList<IMacroAction> Actions { get; }
    }
}
