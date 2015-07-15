namespace Ennerbot
{
    public class MacroManagerGuiFactory : IGuiFactory<MacroManager>
    {
        /// <summary>
        /// Creates a new MacroManager window
        /// </summary>
        /// <returns></returns>
        public MacroManager CreateWindow()
        {
            return new MacroManager(true);
        }
    }
}
