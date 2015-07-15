namespace Ennerbot
{
    public class ArrWindowFactory
    {
        private const string WindowTitle = @"FINAL FANTASY XIV";

        private readonly IWindowFactory _windowFactory;

        /// <summary>
        /// Instantiates a new instance of the <see cref="ArrWindowFactory"/> class
        /// </summary>
        /// <param name="windowFactory"></param>
        public ArrWindowFactory(IWindowFactory windowFactory)
        {
            this._windowFactory = windowFactory;
        }

        /// <summary>
        /// Hooks the first A Realm Reborn window
        /// </summary>
        /// <returns></returns>
        public IWindow HookArr()
        {
            return this._windowFactory.HookWindowByCaption(ArrWindowFactory.WindowTitle);
        }
    }
}
