namespace Ennerbot
{
    public class MacroManagerGuiThread : GuiThread<MacroManager>
    {
        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroManagerGuiThread"/> class
        /// </summary>
        public MacroManagerGuiThread()
            : base(new MacroManagerGuiFactory())
        {
        }
    }
}
