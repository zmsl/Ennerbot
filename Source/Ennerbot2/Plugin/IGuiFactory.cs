using System.Windows.Forms;

namespace Ennerbot
{
    public interface IGuiFactory<T> where T : Form
    {
        /// <summary>
        /// Creates a window
        /// </summary>
        /// <returns></returns>
        T CreateWindow();
    }
}
