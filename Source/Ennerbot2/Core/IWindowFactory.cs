namespace Ennerbot
{
    /// <summary>
    /// Interface for window factory objects
    /// </summary>
    public interface IWindowFactory
    {
        /// <summary>
        /// Attempts to hook a window by window caption
        /// </summary>
        /// <param name="windowCaption"></param>
        /// <returns></returns>
        IWindow HookWindowByCaption(string windowCaption);

        /// <summary>
        /// Attempts to hook a window by class
        /// </summary>
        /// <param name="windowClass"></param>
        /// <returns></returns>
        IWindow HookWindow(string windowClass);

        /// <summary>
        /// Attempts to hook a window by class and caption
        /// </summary>
        /// <param name="windowClass"></param>
        /// <param name="windowCaption"></param>
        /// <returns></returns>
        IWindow HookWindow(string windowClass, string windowCaption);
    }
}
