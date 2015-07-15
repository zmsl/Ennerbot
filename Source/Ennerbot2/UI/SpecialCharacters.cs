using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ennerbot
{
    public partial class SpecialCharacters : Form
    {
        /// <summary>
        /// Instantiates a new instance of the <see cref="SpecialCharacters"/> class
        /// </summary>
        public SpecialCharacters()
        {
            InitializeComponent();

            // Get all keys
            var keys = Enum.GetNames(typeof (VirtualKeys)).ToList();
            keys.Sort();

            // Display all keys
            var builder = new StringBuilder();
            foreach (var key in keys)
            {
                builder.AppendLine(key);
            }
            txtKeyList.Text = builder.ToString();
        }

        /// <summary>
        /// Cancels closing and hides instead
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpecialCharacters_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the close event
            e.Cancel = true;

            // Hide the form instead of closing
            this.Hide();
        }

        private void SpecialCharacters_Load(object sender, EventArgs e)
        {
            this.txtKeyList.SelectionStart = this.txtKeyList.SelectionLength = 0;
        }
    }
}
