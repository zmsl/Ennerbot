using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Ennerbot
{
    public abstract class GuiThread<T> : IGuiThread where T : Form
    {
        private readonly IGuiFactory<T> _guiFactory;

        private Thread _thread;
        private T _window;
        private bool _running;

        /// <summary>
        /// Instantiates a new instance of the <see cref="GuiThread{T}"/> class
        /// </summary>
        protected GuiThread(IGuiFactory<T> guiFactory)
        {
            this._guiFactory = guiFactory;
            this._running = false;
        }

        /// <summary>
        /// Starts the thread and opens the window
        /// </summary>
        public virtual void Start()
        {
            if (this._running) return;

            // Create a new thread
            this._thread = new Thread(delegate()
            {
                this._window = this._guiFactory.CreateWindow();

                this._window.Closed += (s, e) =>
                    System.Windows.Threading.Dispatcher.CurrentDispatcher.InvokeShutdown();

                System.Windows.Threading.Dispatcher.Run();
            });

            // Set to STA or it will throw
            this._thread.SetApartmentState(ApartmentState.STA);
            this._thread.IsBackground = true;
            this._thread.Start();

            // Set running state
            this._running = true;
        }

        /// <summary>
        /// Closes the window and stops the thread
        /// </summary>
        public virtual void Stop()
        {
            if (!this._running) return;

            // Close and dispose of the window
            Invoke(() => this._window.Close());

            // Destroy our thread and window
            this._thread = null;
            this._window = null;


            // Set the running state
            this._running = false;
        }

        /// <summary>
        /// Shows the window
        /// </summary>
        public void Show()
        {
            Invoke(() => this._window.Show());
        }

        /// <summary>
        /// Hides the window
        /// </summary>
        public void Hide()
        {
            Invoke(() => this._window.Hide());
        }

        /// <summary>
        /// Invokes the message to the current dispatcher
        /// </summary>
        /// <param name="callback"></param>
        protected static void Invoke(Action callback)
        {
            Dispatcher.CurrentDispatcher.Invoke(callback);
        }

        /// <summary>
        /// Gets the window
        /// </summary>
        protected T Window
        {
            get { return this._window; }
        }
    }
}
