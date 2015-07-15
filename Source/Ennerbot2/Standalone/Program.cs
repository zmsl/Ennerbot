using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ennerbot
{
    static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Launch console
            if (args.Any(a => a.Equals("/c", StringComparison.InvariantCulture)))
            {
                AllocConsole();
            }

            // Set test mode
            var testMode = args.Any(a => a.Equals("/t", StringComparison.InvariantCulture));

            // Launch window
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MacroManager(false));
        }
    }
}