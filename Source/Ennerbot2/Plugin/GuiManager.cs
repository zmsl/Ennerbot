namespace Ennerbot
{
    public class GuiManager
    {
        /// <summary>
        /// Creates and returns a new MacroManagerGuiThread
        /// </summary>
        /// <returns></returns>
        public MacroManagerGuiThread CreateMacroManager()
        {
            return new MacroManagerGuiThread();
        }
    }
}
