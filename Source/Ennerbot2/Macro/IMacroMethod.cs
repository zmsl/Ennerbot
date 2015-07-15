using System;

namespace Ennerbot
{
    public interface IMacroMethod : IMacro, IEquatable<IMacroMethod>, IEquatable<string>
    {
        /// <summary>
        /// Gets the method name
        /// </summary>
        string Name { get; }
    }
}
