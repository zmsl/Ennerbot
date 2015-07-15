using System;
using System.Windows.Forms;

namespace Ennerbot
{
    /// <summary>
    /// Interface for all Win32 window operations
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        /// Send a key-down and an immediate key-up message to the window
        /// </summary>
        /// <param name="key"></param>
        void SendKey(Keys key);

        /// <summary>
        /// Sends a key-down and an immediate key-up message to the window
        /// </summary>
        /// <param name="key"></param>
        void SendKey(int key);

        /// <summary>
        /// Sends a key-down and an immediate key-up message to the window
        /// </summary>
        /// <param name="key"></param>
        void SendKey(ushort key);

        /// <summary>
        /// Sends a key-down and an immediate key-up message to the window message queue
        /// </summary>
        /// <param name="key"></param>
        void PostKey(Keys key);

        /// <summary>
        /// Sends a key-down and an immediate key-up message to the window message queue
        /// </summary>
        /// <param name="key"></param>
        void PostKey(int key);

        /// <summary>
        /// Sends a key-down and an immediate key-up message to the window message queue
        /// </summary>
        /// <param name="key"></param>
        void PostKey(ushort key);

        /// <summary>
        /// Sends a character to the window
        /// </summary>
        /// <param name="key"></param>
        void SendChar(char key);

        /// <summary>
        /// Posts a character to the specified window message queue
        /// </summary>
        /// <param name="key"></param>
        void PostChar(char key);

        /// <summary>
        /// Send a string of text to the window
        /// </summary>
        /// <param name="text"></param>
        void SendText(string text);

        /// <summary>
        /// Posts a string of text to the specified winow message queue
        /// </summary>
        /// <param name="text"></param>
        void PostText(string text);

        /// <summary>
        /// HWnd of window
        /// </summary>
        IntPtr HWnd { get; }

        /// <summary>
        /// Title of window
        /// </summary>
        string WindowTitle { get; }
    }
}
