using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ennerbot
{
    public partial class MethodEditor : Form
    {
        #region Private members

        private static readonly IList<IMacroAction> NoActions = new IMacroAction[0];

        private readonly MacroManager _macroManager;

        private readonly SpecialCharacters _specialCharacters;

        private readonly Help _help;

        private IMacroMethodRegister _methodRegister;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates a new instance of the <see cref="MethodEditor"/> class
        /// </summary>
        /// <param name="parentManager"></param>
        /// <param name="specialCharacters"></param>
        /// <param name="help"></param>
        public MethodEditor(MacroManager parentManager, SpecialCharacters specialCharacters, Help help)
        {
            InitializeComponent();

            this._macroManager = parentManager;
            this._specialCharacters = specialCharacters;
            this._help = help;
            this._methodRegister = new MacroMethodRegister();
        }

        #endregion

        #region Form actions

        /// <summary>
        /// Shows the help menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this._help.Show();
            this._help.Focus();
        }

        /// <summary>
        /// Loads the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MethodEditor_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Shows the special characters window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void specialCharactersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._specialCharacters.Show();
            this._specialCharacters.Focus();
        }

        /// <summary>
        /// Cancels the form close in favor of a hide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MethodEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the close event
            e.Cancel = true;

            // Hide the form instead of closing
            this.Hide();
        }

        /// <summary>
        /// Creates a new method book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        /// <summary>
        /// Stores the method in the book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStore_Click(object sender, EventArgs e)
        {
            this.Store();
        }
        
        /// <summary>
        /// Deletes the method from the book
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        /// <summary>
        /// Handles when the selected value has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstStoredMethods_SelectedValueChanged(object sender, EventArgs e)
        {
            // Retain current selection for reference
            var selectedValue = (IMacroMethod) this.lstStoredMethods.SelectedItem;

            // Set form values
            this.SetForm(
                selectedValue == null ? string.Empty : selectedValue.Name,
                selectedValue == null ? NoActions : selectedValue.Actions
                );
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Tests the macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.MacroEditor.Validate(this._methodRegister))
            {
                MessageBox.Show("Method is not valid", "Invalid method cannot be run", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.FocusMe.Focus();
            this._macroManager.RunMacro(1, this.MacroEditor.GetMacroActions(), this._methodRegister);
        }

        /// <summary>
        /// Stops the macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._macroManager.Stop();
        }

        /// <summary>
        /// Pauses the macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._macroManager.Pause();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Creates a new method
        /// </summary>
        private void New()
        {
            this.ClearForm();
            this.MacroEditor.Focus();
        }

        /// <summary>
        /// Deletes the selected method from the register
        /// </summary>
        private void Delete()
        {
            if (this.lstStoredMethods.SelectedItem == null) return;

            // Delete the item
            this._methodRegister.Delete(((IMacroMethod) this.lstStoredMethods.SelectedItem).Name);

            // Refresh the UI
            this.lstStoredMethods.Items.Remove(this.lstStoredMethods.SelectedItem);

            // Clear the form
            this.ClearForm();
        }

        /// <summary>
        /// Stores the method in the method register
        /// </summary>
        private void Store()
        {
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                this.ShowError("Method name cannot be empty");
                return;
            }

            var updating = this._methodRegister.Get(this.txtName.Text) != null;
            var newMethod = new MacroMethod(this.txtName.Text, this.MacroEditor.GetMacroActions());
            this._methodRegister.Register(newMethod);

            // Set the form
            if (!updating)
            {
                this.SetForm(string.Empty, null);
                this.lstStoredMethods.Items.Add(newMethod);
            }
            else
            {
                for (var idx = 0; idx < this.lstStoredMethods.Items.Count; idx++)
                {
                    if (((IMacroMethod) this.lstStoredMethods.Items[idx]).Name != this.txtName.Text) continue;

                    this.lstStoredMethods.Items[idx] = newMethod;
                    break;
                }
            }
        }

        /// <summary>
        /// Shows an error to the user
        /// </summary>
        /// <param name="error"></param>
        private void ShowError(string error)
        {
            MessageBox.Show(this, error, "Ennerbot encountered a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Clears the form
        /// </summary>
        private void ClearForm()
        {
            this.lstStoredMethods.ClearSelected();
            this.SetForm(string.Empty, null);
        }

        /// <summary>
        /// Sets the form values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="actions"></param>
        private void SetForm(string name, IList<IMacroAction> actions)
        {
            this.txtName.Text = name;
            this.MacroEditor.SetMacroActions(actions ?? NoActions);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the enabled / disabled flags based on the testability of the main form
        /// </summary>
        /// <param name="executing"></param>
        /// <param name="paused"></param>
        public void SetTestability(bool executing, bool paused)
        {
            testToolStripMenuItem.Enabled = !executing || paused;
            stopToolStripMenuItem.Enabled = executing;
            pauseToolStripMenuItem.Enabled = executing && !paused;
        }

        /// <summary>
        /// Sets the methods in the form
        /// </summary>
        /// <param name="methods"></param>
        public void SetMethods(IList<IMacroMethod> methods)
        {
            this._methodRegister = new MacroMethodRegister();
            foreach (var m in methods)
            {
                this._methodRegister.Register(m);
            }

            this.ClearForm();
            this.lstStoredMethods.Items.Clear();
            this.lstStoredMethods.Items.AddRange(methods.Select(m => (object) m).ToArray());
        }

        /// <summary>
        /// Gets the method register
        /// </summary>
        public IMacroMethodRegister MethodRegister
        {
            get { return this._methodRegister; }
            set { this._methodRegister = value; }
        }

        #endregion
    }
}
