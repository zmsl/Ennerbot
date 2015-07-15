using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ennerbot.Conversion;

namespace Ennerbot
{
    public partial class MacroEditor : UserControl
    {
        private readonly MacroParser _parser;

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroEditor"/> class
        /// </summary>
        public MacroEditor()
        {
            InitializeComponent();

            this._parser = new MacroParser();
            this.MacroText.TextChanged += (sender, args) =>
            {
                if (this.TextChanged != null)
                {
                    this.TextChanged(sender, args);
                }
            };
        }

        /// <summary>
        /// Handles the load event for this control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacroEditor_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles resize events for this control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacroEditor_Resize(object sender, EventArgs e)
        {
            this.MacroText.Top = this.MacroText.Left = 0;
            this.MacroText.Width = this.Width;
            this.MacroText.Height = this.Height;
        }

        /// <summary>
        /// Parses the string
        /// </summary>
        /// <returns></returns>
        public IList<IMacroAction> GetMacroActions()
        {
            try
            {
                return this._parser.ParseString(MacroText.Text);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the macro text value
        /// </summary>
        public void SetMacroActions(IList<IMacroAction> actions)
        {
            var builder = new StringBuilder();
            foreach (var action in actions)
            {
                builder.AppendLine(action.ToString());
            }
            this.MacroText.Text = builder.ToString();
        }

        /// <summary>
        /// Gets whether the macro is valid or not
        /// </summary>
        public bool Validate(IMacroMethodRegister methodRegister)
        {
            return this.Validate(this.GetMacroActions(), methodRegister);
        }

        /// <summary>
        /// Gets whether the macro is valid or not
        /// </summary>
        /// <param name="actions"></param>
        /// <param name="methodRegister"></param>
        /// <returns></returns>
        public bool Validate(IList<IMacroAction> actions, IMacroMethodRegister methodRegister)
        {
            return new MacroValidator(new MacroActionValidator(), methodRegister).Validate(actions).Valid;
        }

        /// <summary>
        /// Gets or sets the macro text
        /// </summary>
        public override string Text
        {
            get { return this.MacroText.Text; }
            set { this.MacroText.Text = value; }
        }

        /// <summary>
        /// Triggered when the macro text changes
        /// </summary>
        public new event EventHandler TextChanged;
    }
}
