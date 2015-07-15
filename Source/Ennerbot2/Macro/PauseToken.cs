namespace Ennerbot
{
    public class PauseToken : IPauseToken
    {
        /// <summary>
        /// Gets whether the token has a requested pause
        /// </summary>
        public bool PauseRequested
        {
            get; 
            private set;
        }

        /// <summary>
        /// Requests a pause
        /// </summary>
        public void Pause()
        {
            this.PauseRequested = true;
        }

        /// <summary>
        /// Requests an unpause
        /// </summary>
        public void Unpause()
        {
            this.PauseRequested = false;
        }
    }
}
