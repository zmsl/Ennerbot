using System;
using System.Windows.Forms;
using ff14bot.Interfaces;

namespace Ennerbot
{
    public class Ennerbuddy : IBotPlugin
    {
        #region Constants

        private const string PluginAuthor = @"Enner";
        private const string PluginButtonText = @"Ennerbot";
        private const string PluginDescription = @"Rebornbuddy implementation of the original Ennerbot";
        private const string PluginName = @"Ennerbot";
        private const int PluginMajorVersion = 1;
        private const int PluginMinorVersion = 0;
        private const bool PluginWantButton = true;

        #endregion

        #region Private members

        private MacroManagerGuiThread _macroManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates a new instance of the <see cref="Ennerbot"/> class
        /// </summary>
        public Ennerbuddy()
        {
            TryWithMessage(() =>
            {
                var guiManager = new GuiManager();
                this._macroManager = guiManager.CreateMacroManager();
            });

            // this.pluginPath = Path.Combine(Environment.CurrentDirectory, ff14bot.Settings.GlobalSettings.Instance.PluginsPath);
        }

        #endregion

        #region Plugin Methods

        /// <summary>
        /// Procedure to execute when the plugin is clicked
        /// </summary>
        public void OnButtonPress()
        {
            TryWithMessage(() => this._macroManager.Show());
        }

        /// <summary>
        /// Procedure to execute when the plugin is disabled
        /// </summary>
        public void OnDisabled()
        {
        }

        /// <summary>
        /// Procedure to execute when the plugin is enabled
        /// </summary>
        public void OnEnabled()
        {
        }

        /// <summary>
        /// Procedure to execute when the plugin is initializing
        /// </summary>
        public void OnInitialize()
        {
            this._macroManager.Start();
        }

        /// <summary>
        /// Procedure to execute when the plugin is shutting down
        /// </summary>
        public void OnShutdown()
        {
        }

        /// <summary>
        /// Procedure to execute when the plugin is sent a pulse
        /// </summary>
        public void OnPulse()
        {
        }

        #endregion

        #region Private static methods

        /// <summary>
        /// Tries to execute the specified callback and displays a message box if an exception is thrown
        /// </summary>
        /// <param name="callback"></param>
        private static void TryWithMessage(Action callback)
        {
            try
            {
                callback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ennerbuddy encountered an error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region System.Object Methods

        /// <summary>
        /// Returns whether this instance of the Ennerbot class is equal to the specified instance
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IBotPlugin other)
        {
            return other.WantButton == this.WantButton &&
                   other.Author == this.Author &&
                   other.ButtonText == this.ButtonText &&
                   other.Description == this.Description &&
                   other.Name == this.Name &&
                   other.Version.Equals(this.Version);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the plugin author
        /// </summary>
        public string Author
        {
            get { return Ennerbuddy.PluginAuthor; }
        }

        /// <summary>
        /// Gets the button text to show on the plugin button
        /// </summary>
        public string ButtonText
        {
            get { return Ennerbuddy.PluginButtonText; }
        }

        /// <summary>
        /// Gets the plugin description
        /// </summary>
        public string Description
        {
            get { return Ennerbuddy.PluginDescription; }
        }

        /// <summary>
        /// Gets the plugin name
        /// </summary>
        public string Name
        {
            get { return Ennerbuddy.PluginName; }
        }

        /// <summary>
        /// Gets the plugin version
        /// </summary>
        public Version Version
        {
            get { return new Version(Ennerbuddy.PluginMajorVersion, PluginMinorVersion); }
        }

        /// <summary>
        /// Returns whether to display the button or not
        /// </summary>
        public bool WantButton
        {
            get { return Ennerbuddy.PluginWantButton; }
        }

        #endregion
    }
}
