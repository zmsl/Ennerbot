using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ennerbot
{
    public class WindowFinder
    {
        public List<string> FindAllWindowTitles()
        {
            return Process.GetProcesses().Select(p => p.MainWindowTitle).ToList();
        }
    }
}
