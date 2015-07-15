namespace Ennerbot
{
    public interface IGuiThread
    {
        /// <summary>
        /// Starts the gui thread
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the gui thread
        /// </summary>
        void Stop();
    }
}
