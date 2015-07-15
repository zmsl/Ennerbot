using System;
using System.Runtime.InteropServices;

namespace Ennerbot
{
    /// <summary>
    /// Factory class for all window objects
    /// </summary>
    public class WindowFactory : IWindowFactory
    {
        [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(IntPtr zeroOnly, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// Attempts to hook a window by caption
        /// </summary>
        /// <param name="windowCaption"></param>
        /// <returns>null if no window is found with specified caption</returns>
        public IWindow HookWindowByCaption(string windowCaption)
        {
            var foundHwnd = FindWindowByCaption(IntPtr.Zero, windowCaption);
            return foundHwnd != IntPtr.Zero ? CreateWindow(foundHwnd, windowCaption) : null;
        }

        /// <summary>
        /// Attempts to hook a window by class
        /// </summary>
        /// <param name="windowClass"></param>
        /// <returns>null if no window is found with specified class</returns>
        public IWindow HookWindow(string windowClass)
        {
            var foundHwnd = FindWindow(windowClass, null);
            return foundHwnd != IntPtr.Zero ? CreateWindow(foundHwnd) : null;
        }

        /// <summary>
        /// Attempts to hook a window by class and caption
        /// </summary>
        /// <param name="windowClass"></param>
        /// <param name="windowCaption"></param>
        /// <returns>null if no window is found with specified class and caption</returns>
        public IWindow HookWindow(string windowClass, string windowCaption)
        {
            var foundHwnd = FindWindow(windowClass, windowCaption);
            return foundHwnd != IntPtr.Zero ? CreateWindow(foundHwnd) : null;
        }

        /// <summary>
        /// Creates a new instance of a Window with the specified hwnd handle value
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns>Window object instantiated with hwnd value</returns>
        private static IWindow CreateWindow(IntPtr hwnd)
        {
            return new Window(hwnd);
        }

        /// <summary>
        /// Creates a new instance of a Window with the specified hwnd handle value and window title
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="windowTitle"></param>
        /// <returns></returns>
        private static IWindow CreateWindow(IntPtr hwnd, string windowTitle)
        {
            return new Window(hwnd, windowTitle);
        }
    }
}
