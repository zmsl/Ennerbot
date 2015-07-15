using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ennerbot
{
    /// <summary>
    /// Base window class which wraps Win32 message transmissions to the window
    /// </summary>
    public class Window : IWindow
    {
        /// <summary>
        /// Instantiate a window using the specified hwnd
        /// </summary>
        /// <param name="hwnd"></param>
        public Window(IntPtr hwnd)
            : this(hwnd, string.Empty)
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="Window"/> class
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="windowTitle"></param>
        public Window(IntPtr hwnd, string windowTitle)
        {
            this.WindowTitle = windowTitle;
            this.HWnd = hwnd;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        protected static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        protected static extern bool PostMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Sends a key down and up
        /// </summary>
        /// <param name="key"></param>
        public virtual void SendKey(Keys key)
        {
            this.SendKey((int) key);
        }

        /// <summary>
        /// Sends a key down and up
        /// </summary>
        /// <param name="key"></param>
        public virtual void SendKey(ushort key)
        {
            SendKey((int)key);
        }

        /// <summary>
        /// Sends a key down and up
        /// </summary>
        /// <param name="key"></param>
        public virtual void SendKey(int key)
        {
            SendMessage(this.HWnd, (uint)WindowMessage.KEYDOWN, new IntPtr(key), IntPtr.Zero);
            SendMessage(this.HWnd, (uint)WindowMessage.KEYUP, new IntPtr(key), IntPtr.Zero);
        }

        /// <summary>
        /// Posta a key down and up
        /// </summary>
        /// <param name="key"></param>
        public virtual void PostKey(Keys key)
        {
            this.PostKey((int) key);
        }

        /// <summary>
        /// Posts a key down and up
        /// </summary>
        /// <param name="key"></param>
        public virtual void PostKey(ushort key)
        {
            PostKey((int)key);
        }

        /// <summary>
        /// Posts a key down and up
        /// </summary>
        /// <param name="key"></param>
        public virtual void PostKey(int key)
        {
            PostMessage(this.HWnd, (uint) WindowMessage.KEYDOWN, new IntPtr(key), IntPtr.Zero);
            PostMessage(this.HWnd, (uint) WindowMessage.KEYUP, new IntPtr(key), IntPtr.Zero);
        }

        /// <summary>
        /// Sends a character
        /// </summary>
        /// <param name="key"></param>
        public virtual void SendChar(char key)
        {
            SendMessage(this.HWnd, (uint) WindowMessage.CHAR, new IntPtr((int) key), IntPtr.Zero);
        }

        /// <summary>
        /// Posts a character to the message queue of the specified window
        /// </summary>
        /// <param name="key"></param>
        public virtual void PostChar(char key)
        {
            PostMessage(this.HWnd, (uint) WindowMessage.CHAR, new IntPtr((int) key), IntPtr.Zero);
        }

        /// <summary>
        /// Sends a string to the window
        /// </summary>
        /// <param name="text"></param>
        public void SendText(string text)
        {
            foreach (var c in (text ?? string.Empty).ToCharArray())
            {
                SendChar(c);
            }
        }

        /// <summary>
        /// Posts a character to the message queue of the specified window
        /// </summary>
        /// <param name="text"></param>
        public void PostText(string text)
        {
            foreach (var c in (text ?? string.Empty).ToCharArray())
            {
                PostChar(c);
            }
        }

        /// <summary>
        /// Handle of window
        /// </summary>
        public IntPtr HWnd { get; protected set; }

        /// <summary>
        /// Gets the window title
        /// </summary>
        public string WindowTitle { get; protected set; }
    }
}
