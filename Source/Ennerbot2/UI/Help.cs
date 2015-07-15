using System.Windows.Forms;

namespace Ennerbot
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the close event
            e.Cancel = true;

            // Hide the form instead of closing
            this.Hide();
        }

        private void Help_Load(object sender, System.EventArgs e)
        {
            this.txtHelp.SelectionStart = this.txtHelp.SelectionLength = 0;
        }
    }
}
