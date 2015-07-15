using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ennerbot.Conversion;

namespace Ennerbot
{
    public partial class MacroManager : Form
    {
        #region Private members

        private readonly bool _buddyEnabled;

        private readonly bool _testMode;

        private readonly ArrWindowFactory _windowFactory;

        private readonly MethodEditor _methodEditor;

        private readonly SpecialCharacters _specialCharacters;

        private readonly WindowPicker _windowPicker;

        private readonly Help _help;

        private IWindow _window;

        private Task _macroExecution;

        private CancellationTokenSource _cancellationToken;

        private IPauseToken _pauseToken;

        private string _currentFile;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroManager"/> class
        /// </summary>
        public MacroManager()
            : this(false)
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroManager"/> class
        /// </summary>
        /// <param name="buddyEnabled">
        /// Specifies whether macros allow RebornBuddy functionality. Passing true
        /// when Ennerbot is not being run under the context of a RebornBuddy plugin
        /// will cause the program to throw
        /// </param>
        public MacroManager(bool buddyEnabled)
            :this(buddyEnabled, false)
        {
        }

        /// <summary>
        /// Instantiates a new instance of the <see cref="MacroManager"/> class
        /// </summary>
        /// <param name="buddyEnabled">
        /// Specifies whether macros allow RebornBuddy functionality. Passing true
        /// when Ennerbot is not being run under the context of a RebornBuddy plugin
        /// will cause the program to throw
        /// </param>
        /// <param name="testMode">
        /// Test mode will use a different set of execution logic that will not actually
        /// send messages to the FFXIV client
        /// </param>
        public MacroManager(bool buddyEnabled, bool testMode)
        {
            this.InitializeComponent();

            this._buddyEnabled = buddyEnabled;
            this._testMode = testMode;

            this._currentFile = null;
            this._windowFactory = new ArrWindowFactory(new WindowFactory());
            this._help = new Help();
            this._specialCharacters = new SpecialCharacters();
            this._methodEditor = new MethodEditor(this, this._specialCharacters, this._help);
            this._windowPicker = new WindowPicker();
            this._windowPicker.OnWindowSelected += title => this.UpdateClient((new WindowFactory()).HookWindowByCaption(title));

            this.saveFileDialog.InitialDirectory = Application.StartupPath;
        }

        #endregion

        #region Form events

        /// <summary>
        /// Opens a macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            this.Open();
        }

        /// <summary>
        /// Starts a new macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        /// <summary>
        /// Triggered when the form is first loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacroManager_Load(object sender, EventArgs e)
        {
            this.UpdateClient();
        }

        /// <summary>
        /// Shows the method editor to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewMethodEditor_Click(object sender, EventArgs e)
        {
            this.ShowMethodEditor();
        }

        /// <summary>
        /// Triggered when the form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacroManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this._buddyEnabled || e.CloseReason != CloseReason.UserClosing) return;

            // Cancel the close event
            e.Cancel = true;

            // Hide the form instead of closing
            this.Hide();
        }

        /// <summary>
        /// Validates the macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnValidate_Click(object sender, EventArgs e)
        {
            this.UpdateValidationStatus();
        }

        /// <summary>
        /// Refreshes the client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshClient_ButtonClick(object sender, EventArgs e)
        {
            this.UpdateClient();
        }

        /// <summary>
        /// Runs the macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnPlay_Click(object sender, EventArgs e)
        {
            this.RunMacro();
        }

        /// <summary>
        /// Pauses the macro execution
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnPause_Click(object sender, EventArgs e)
        {
            this.Pause();
            this.RefreshUi();
        }

        /// <summary>
        /// Stops the macro execution
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBtnStop_Click(object sender, EventArgs e)
        {
            this.Stop();
        }

        /// <summary>
        /// Validates the macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMacroValidate_Click(object sender, EventArgs e)
        {
            this.UpdateValidationStatus();
        }

        /// <summary>
        /// Runs the macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMacroRun_Click(object sender, EventArgs e)
        {
            this.RunMacro();
        }

        /// <summary>
        /// Stops the macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMacroStop_Click(object sender, EventArgs e)
        {
            this.Stop();
        }

        /// <summary>
        /// Pauses the macro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMacroPause_Click(object sender, EventArgs e)
        {
            this.Pause();
        }

        /// <summary>
        /// Handles form resizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MacroManager_Resize(object sender, EventArgs e)
        {
            this.MacroEditor.Width = this.Width - this.MacroEditor.Left - 16;
            this.MacroEditor.Height = this.Height - this.MacroEditor.Top - this.StatusStrip.Height - 39;
        }

        /// <summary>
        /// Shows the method editor to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuMacroOpenMethodRegister_Click(object sender, EventArgs e)
        {
            this.ShowMethodEditor();
        }

        /// <summary>
        /// Saves the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        /// <summary>
        /// Overrides the current file and saves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            this.SaveAs();
        }

        /// <summary>
        /// Shows the special characters window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHelpSpecialCharacters_Click(object sender, EventArgs e)
        {
            this._specialCharacters.Show();
            this._specialCharacters.Focus();
        }

        /// <summary>
        /// Shows the help window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._help.Show();
            this._help.Focus();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Opens the file
        /// </summary>
        private void Open()
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            // Set current file
            this._currentFile = this.openFileDialog.FileName;

            // Open the stream
            using (var fileStream = this.openFileDialog.OpenFile())
            {
                this.LoadMacro(SerializableMacro.Deserialize(fileStream));
            }
        }

        /// <summary>
        /// Loads the serializable macro
        /// </summary>
        /// <param name="macro"></param>
        private void LoadMacro(SerializableMacro macro)
        {
            this.MacroEditor.SetMacroActions(macro.Actions.Cast<IMacroAction>().ToList());
            this._methodEditor.SetMethods(macro.Register.Select(m => new MacroMethod(m.Name, m.Actions.Cast<IMacroAction>().ToList())).Cast<IMacroMethod>().ToList());
            this.toolTxtIterations.Text = macro.Repetitions.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Saves the macro
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            if (string.IsNullOrWhiteSpace(this._currentFile) && this.saveFileDialog.ShowDialog() != DialogResult.OK)
                return false;
            
            // Save the current filename
            this._currentFile = this.saveFileDialog.FileName = this._currentFile ?? this.saveFileDialog.FileName;

            using (var fileStream = this.saveFileDialog.OpenFile())
            {
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    streamWriter.Write(
                        SerializableMacro.Serialize(new SerializableMacro(new MacroRoutine(this.GetRepetitions(), this.MacroEditor.GetMacroActions()), this._methodEditor.MethodRegister))    
                        );
                }
            }

            return true;
        }

        /// <summary>
        /// Overrides the current file and saves
        /// </summary>
        private void SaveAs()
        {
            var tmpFile = this._currentFile;
            this._currentFile = null;
            if (!this.Save())
            {
                this._currentFile = tmpFile;
            }
        }

        /// <summary>
        /// Starts a new macro
        /// </summary>
        private void New()
        {
            this.ClearAll();
            this._currentFile = null;
        }

        /// <summary>
        /// Clears all forms
        /// </summary>
        private void ClearAll()
        {
            this.MacroEditor.SetMacroActions(new List<IMacroAction>(0));
            this._methodEditor.SetMethods(new List<IMacroMethod>(0));
        }

        /// <summary>
        /// Shows the method editor to the user
        /// </summary>
        private void ShowMethodEditor()
        {
            this.RefreshMethodEditor();
            this._methodEditor.Show();
            this._methodEditor.Focus();
        }

        /// <summary>
        /// Updates the repetition status
        /// </summary>
        /// <param name="repetition"></param>
        private void UpdateRepetitionStatus(int repetition)
        {
            lblIterationStatus.Text = string.Format("{0} / {1}", repetition, this.GetRepetitions());
            prgIterationProgress.Value = repetition;
        }

        /// <summary>
        /// Handles tasks ending
        /// </summary>
        /// <param name="task"></param>
        private void MacroExecution_OnTaskEnded(Task task)
        {
            this._macroExecution = null;
            this.Invoke((MethodInvoker) delegate
            {
                this.UpdateRepetitionStatus(0);
                this.RefreshUi();
            });
        }

        /// <summary>
        /// Handles repetitions starting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="context"></param>
        /// <param name="repetition"></param>
        private void MacroExecution_OnRepetitionStarted(IMacroRoutineExecutor sender, IExecutionContext context, int repetition)
        {
            this.Invoke((MethodInvoker) (() => this.UpdateRepetitionStatus(repetition)));
        }

        /// <summary>
        /// Handles repetitions ending
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="context"></param>
        /// <param name="repetition"></param>
        private void MacroExecution_OnRepetitionEnded(IMacroRoutineExecutor sender, IExecutionContext context, int repetition)
        {
        }

        /// <summary>
        /// Handles actions starting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="context"></param>
        /// <param name="action"></param>
        private void MacroExecution_OnActionStarted(IMacroRoutineExecutor sender, IExecutionContext context, IMacroAction action)
        {
        }

        /// <summary>
        /// Handles actions ending
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="context"></param>
        /// <param name="action"></param>
        private void MacroExecution_OnActionEnded(IMacroRoutineExecutor sender, IExecutionContext context, IMacroAction action)
        {
        }

        /// <summary>
        /// Refreshes the enabled status of certain UI elements
        /// </summary>
        private void RefreshUi()
        {
            this.toolBtnValidate.Enabled = this.menuMacroValidate.Enabled = this._macroExecution == null;
            this.menuMacroPause.Enabled = this.toolBtnPause.Enabled = this._macroExecution != null && this._pauseToken != null && !this._pauseToken.PauseRequested;
            this.menuMacroStop.Enabled = this.toolBtnStop.Enabled = this._macroExecution != null;
            this.menuMacroRun.Enabled = this.toolBtnPlay.Enabled = this._macroExecution == null || (this._pauseToken != null && this._pauseToken.PauseRequested);
            this.toolTxtIterations.Enabled = this._macroExecution == null;
            this.MacroEditor.Enabled = this._macroExecution == null;

            this.RefreshMethodEditor();
        }

        private void RefreshMethodEditor()
        {
            // Set the child forms
            this._methodEditor.SetTestability(this._macroExecution != null, this._pauseToken != null && this._pauseToken.PauseRequested);
        }

        /// <summary>
        /// Updates the macro validation status
        /// </summary>
        private void UpdateValidationStatus()
        {
            var valid = this.MacroEditor.Validate(this.GetMacroMethodRegister());
            this.SetGeneralStatus(string.Format("Macro {0} valid", valid ? "is" : "is not"));
        }

        /// <summary>
        /// Updates the client being used during macro execution
        /// </summary>
        private void UpdateClient()
        {
            this.UpdateClient(this._windowFactory.HookArr());
            
        }

        private void UpdateClient(IWindow window)
        {
            this._window = window;
            this.lblClient.Text = this._window != null
                ? string.Format("Client: {0} - ({1})", this._window.WindowTitle, this._window.HWnd)
                : "Client: None";
        }

        /// <summary>
        /// Shows the exception to the user
        /// </summary>
        /// <param name="ex"></param>
        private void ShowException(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ennerbot encountered a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Sets the general status text in the status bar
        /// </summary>
        /// <param name="statusText"></param>
        private void SetGeneralStatus(string statusText)
        {
            this.lblGeneralStatus.Text = statusText;
        }

        /// <summary>
        /// Gets the macro method register
        /// </summary>
        /// <returns></returns>
        private IMacroMethodRegister GetMacroMethodRegister()
        {
            return this._methodEditor.MethodRegister;
        }

        /// <summary>
        /// Gets the repetitions value
        /// </summary>
        /// <returns></returns>
        private int GetRepetitions()
        {
            var repetitions = 0;
            if (!int.TryParse(toolTxtIterations.Text, out repetitions))
            {
                throw new FormatException("Iteration count value is not valid");
            }
            return repetitions;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Cancels the macro execution
        /// </summary>
        public void Stop()
        {
            this._cancellationToken.Cancel();
        }

        /// <summary>
        /// Pause or unpause the macro
        /// </summary>
        public void Pause()
        {
            if (this._pauseToken.PauseRequested)
            {
                this._pauseToken.Unpause();
            }
            else
            {
                this._pauseToken.Pause();
            }

            this.RefreshUi();
        }

        /// <summary>
        /// Runs the macro
        /// </summary>
        public void RunMacro()
        {
            this.FocusMe.Focus();
            this.RunMacro(this.GetRepetitions(), this.MacroEditor.GetMacroActions(), this._methodEditor.MethodRegister);
        }

        /// <summary>
        /// Runs the macro
        /// </summary>
        /// <param name="repetitions"></param>
        /// <param name="actions"></param>
        /// <param name="register"></param>
        public void RunMacro(int repetitions, IList<IMacroAction> actions, IMacroMethodRegister register)
        {
            if (this._macroExecution != null)
            {
                if (this._pauseToken != null && this._pauseToken.PauseRequested)
                {
                    this.Pause();
                }

                return;
            }

            // Return if we're not ready to run
            if (this._window == null || !this.MacroEditor.Validate(actions, register)) return;

            // Create the routine and executor
            var routine = new MacroRoutine(repetitions, actions);
            var executor = new MacroRoutineExecutor(
                this._testMode
                ? (IMacroActionExecutor)new ConsoleMacroActionExecutor()
                : (IMacroActionExecutor)new WindowMacroActionExecutor(this._window)
            );

            // Wire-up callbacks
            executor.OnActionEnded += MacroExecution_OnActionEnded;
            executor.OnActionStarted += MacroExecution_OnActionStarted;
            executor.OnRepetitionEnded += MacroExecution_OnRepetitionEnded;
            executor.OnRepetitionStarted += MacroExecution_OnRepetitionStarted;

            // Create the cancellation and pause token
            this._cancellationToken = new CancellationTokenSource();
            this._pauseToken = new PauseToken();

            // Set the max value of progress
            prgIterationProgress.Minimum = 0;
            prgIterationProgress.Maximum = repetitions;

            // Start the execution
            this._macroExecution =
                executor.ExecuteAsync(routine, register, this._cancellationToken.Token, this._pauseToken)
                    .ContinueWith(MacroExecution_OnTaskEnded);

            // Refresh the UI
            this.RefreshUi();
        }

        /// <summary>
        /// Gets the macro from the form
        /// </summary>
        public IMacroRoutine GetMacro()
        {
            var macro = this.MacroEditor.GetMacroActions();

            // Get the iterations to run
            return macro != null ? new MacroRoutine(this.GetRepetitions(), macro) : null;
        }

        #endregion

        private void lblClient_Click(object sender, EventArgs e)
        {
            this._windowPicker.Show();
        }
    }
}
