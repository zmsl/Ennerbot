namespace Ennerbot
{
    public interface IPauseToken
    {
        /// <summary>
        /// Gets whether there is a pause requested
        /// </summary>
        bool PauseRequested { get; }

        /// <summary>
        /// Requests a pause
        /// </summary>
        void Pause();

        /// <summary>
        /// Requests an unpause
        /// </summary>
        void Unpause();
    }
}
