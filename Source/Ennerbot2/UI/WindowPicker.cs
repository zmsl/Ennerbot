using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ennerbot
{
    public partial class WindowPicker : Form
    {
        private readonly WindowFinder _finder = new WindowFinder();

        public WindowPicker()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ddlWindowTitles.SelectedIndex = -1;
            this.Hide();
        }

        private void WindowPicker_Load(object sender, EventArgs e)
        {
            this.btnRefresh_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ddlWindowTitles.Items.Clear();
            this.ddlWindowTitles.Items.AddRange(this._finder.FindAllWindowTitles().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (!string.IsNullOrWhiteSpace(this.SelectedTitle) && this.OnWindowSelected != null)
            {
                this.OnWindowSelected(this.SelectedTitle);
            }
        }

        public string SelectedTitle
        {
            get { return this.ddlWindowTitles.SelectedItem.ToString(); }
        }

        public delegate void WindowSelected(string windowTitle);
        public event WindowSelected OnWindowSelected;
    }
}
