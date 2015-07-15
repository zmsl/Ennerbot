namespace Ennerbot
{
    partial class MacroManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.toolBtnValidate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnPause = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnPlay = new System.Windows.Forms.ToolStripButton();
            this.toolTxtIterations = new System.Windows.Forms.ToolStripTextBox();
            this.btnViewMethodEditor = new System.Windows.Forms.ToolStripButton();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMacro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMacroValidate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMacroRun = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMacroStop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMacroPause = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMacroOpenMethodRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpSpecialCharacters = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblClient = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnRefreshClient = new System.Windows.Forms.ToolStripSplitButton();
            this.lblGeneralStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIterationStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgIterationProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.FocusMe = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MacroEditor = new Ennerbot.MacroEditor();
            this.Tools.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tools
            // 
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnValidate,
            this.toolStripSeparator2,
            this.toolBtnPause,
            this.toolStripSeparator3,
            this.toolBtnStop,
            this.toolStripSeparator1,
            this.toolBtnPlay,
            this.toolTxtIterations,
            this.btnViewMethodEditor});
            this.Tools.Location = new System.Drawing.Point(0, 24);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(1124, 25);
            this.Tools.TabIndex = 2;
            // 
            // toolBtnValidate
            // 
            this.toolBtnValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnValidate.Name = "toolBtnValidate";
            this.toolBtnValidate.Size = new System.Drawing.Size(53, 22);
            this.toolBtnValidate.Text = "Validate";
            this.toolBtnValidate.Click += new System.EventHandler(this.toolBtnValidate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBtnPause
            // 
            this.toolBtnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnPause.Enabled = false;
            this.toolBtnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnPause.Name = "toolBtnPause";
            this.toolBtnPause.Size = new System.Drawing.Size(42, 22);
            this.toolBtnPause.Text = "Pause";
            this.toolBtnPause.Click += new System.EventHandler(this.toolBtnPause_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBtnStop
            // 
            this.toolBtnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnStop.Enabled = false;
            this.toolBtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnStop.Name = "toolBtnStop";
            this.toolBtnStop.Size = new System.Drawing.Size(35, 22);
            this.toolBtnStop.Text = "Stop";
            this.toolBtnStop.Click += new System.EventHandler(this.toolBtnStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolBtnPlay
            // 
            this.toolBtnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBtnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnPlay.Name = "toolBtnPlay";
            this.toolBtnPlay.Size = new System.Drawing.Size(32, 22);
            this.toolBtnPlay.Text = "Run";
            this.toolBtnPlay.Click += new System.EventHandler(this.toolBtnPlay_Click);
            // 
            // toolTxtIterations
            // 
            this.toolTxtIterations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolTxtIterations.Name = "toolTxtIterations";
            this.toolTxtIterations.Size = new System.Drawing.Size(50, 25);
            this.toolTxtIterations.Text = "1";
            // 
            // btnViewMethodEditor
            // 
            this.btnViewMethodEditor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnViewMethodEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewMethodEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewMethodEditor.Name = "btnViewMethodEditor";
            this.btnViewMethodEditor.Size = new System.Drawing.Size(119, 22);
            this.btnViewMethodEditor.Text = "Open Method Editor";
            this.btnViewMethodEditor.Click += new System.EventHandler(this.btnViewMethodEditor_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuMacro,
            this.menuHelp});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1124, 24);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.toolStripMenuItem1,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.toolStripMenuItem2,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Size = new System.Drawing.Size(123, 22);
            this.menuFileNew.Text = "New";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Size = new System.Drawing.Size(123, 22);
            this.menuFileOpen.Text = "Open...";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.Size = new System.Drawing.Size(123, 22);
            this.menuFileSave.Text = "Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(123, 22);
            this.menuFileSaveAs.Text = "Save As...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(120, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(123, 22);
            this.menuFileExit.Text = "Exit";
            // 
            // menuMacro
            // 
            this.menuMacro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMacroValidate,
            this.toolStripMenuItem7,
            this.menuMacroRun,
            this.menuMacroStop,
            this.menuMacroPause,
            this.toolStripMenuItem5,
            this.menuMacroOpenMethodRegister});
            this.menuMacro.Name = "menuMacro";
            this.menuMacro.Size = new System.Drawing.Size(53, 20);
            this.menuMacro.Text = "Macro";
            // 
            // menuMacroValidate
            // 
            this.menuMacroValidate.Name = "menuMacroValidate";
            this.menuMacroValidate.Size = new System.Drawing.Size(182, 22);
            this.menuMacroValidate.Text = "Validate";
            this.menuMacroValidate.Click += new System.EventHandler(this.menuMacroValidate_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(179, 6);
            // 
            // menuMacroRun
            // 
            this.menuMacroRun.Name = "menuMacroRun";
            this.menuMacroRun.ShortcutKeyDisplayString = "F5";
            this.menuMacroRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuMacroRun.Size = new System.Drawing.Size(182, 22);
            this.menuMacroRun.Text = "Run";
            this.menuMacroRun.Click += new System.EventHandler(this.menuMacroRun_Click);
            // 
            // menuMacroStop
            // 
            this.menuMacroStop.Name = "menuMacroStop";
            this.menuMacroStop.Size = new System.Drawing.Size(182, 22);
            this.menuMacroStop.Text = "Stop";
            this.menuMacroStop.Click += new System.EventHandler(this.menuMacroStop_Click);
            // 
            // menuMacroPause
            // 
            this.menuMacroPause.Name = "menuMacroPause";
            this.menuMacroPause.Size = new System.Drawing.Size(182, 22);
            this.menuMacroPause.Text = "Pause";
            this.menuMacroPause.Click += new System.EventHandler(this.menuMacroPause_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(179, 6);
            // 
            // menuMacroOpenMethodRegister
            // 
            this.menuMacroOpenMethodRegister.Name = "menuMacroOpenMethodRegister";
            this.menuMacroOpenMethodRegister.Size = new System.Drawing.Size(182, 22);
            this.menuMacroOpenMethodRegister.Text = "Open Method Editor";
            this.menuMacroOpenMethodRegister.Click += new System.EventHandler(this.menuMacroOpenMethodRegister_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpSpecialCharacters,
            this.toolStripMenuItem3,
            this.helpToolStripMenuItem});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "Help";
            // 
            // menuHelpSpecialCharacters
            // 
            this.menuHelpSpecialCharacters.Name = "menuHelpSpecialCharacters";
            this.menuHelpSpecialCharacters.Size = new System.Drawing.Size(170, 22);
            this.menuHelpSpecialCharacters.Text = "Special Characters";
            this.menuHelpSpecialCharacters.Click += new System.EventHandler(this.menuHelpSpecialCharacters_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(167, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblClient,
            this.btnRefreshClient,
            this.lblGeneralStatus,
            this.lblIterationStatus,
            this.prgIterationProgress});
            this.StatusStrip.Location = new System.Drawing.Point(0, 698);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1124, 26);
            this.StatusStrip.TabIndex = 4;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // lblClient
            // 
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(41, 21);
            this.lblClient.Text = "Client:";
            this.lblClient.Click += new System.EventHandler(this.lblClient_Click);
            // 
            // btnRefreshClient
            // 
            this.btnRefreshClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefreshClient.DropDownButtonWidth = 0;
            this.btnRefreshClient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshClient.Name = "btnRefreshClient";
            this.btnRefreshClient.Size = new System.Drawing.Size(51, 24);
            this.btnRefreshClient.Text = "Refresh";
            this.btnRefreshClient.ButtonClick += new System.EventHandler(this.btnRefreshClient_ButtonClick);
            // 
            // lblGeneralStatus
            // 
            this.lblGeneralStatus.Name = "lblGeneralStatus";
            this.lblGeneralStatus.Size = new System.Drawing.Size(754, 21);
            this.lblGeneralStatus.Spring = true;
            // 
            // lblIterationStatus
            // 
            this.lblIterationStatus.Name = "lblIterationStatus";
            this.lblIterationStatus.Size = new System.Drawing.Size(30, 21);
            this.lblIterationStatus.Text = "0 / 0";
            // 
            // prgIterationProgress
            // 
            this.prgIterationProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.prgIterationProgress.AutoSize = false;
            this.prgIterationProgress.Name = "prgIterationProgress";
            this.prgIterationProgress.Size = new System.Drawing.Size(200, 20);
            // 
            // FocusMe
            // 
            this.FocusMe.AutoSize = true;
            this.FocusMe.Location = new System.Drawing.Point(1129, 199);
            this.FocusMe.Name = "FocusMe";
            this.FocusMe.Size = new System.Drawing.Size(0, 13);
            this.FocusMe.TabIndex = 5;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Ennerbot Macro|*.ebm|All Files|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.ebm";
            this.saveFileDialog.Filter = "Ennerbot Macro|*.ebm|All Files|*.*";
            // 
            // MacroEditor
            // 
            this.MacroEditor.Location = new System.Drawing.Point(0, 51);
            this.MacroEditor.Margin = new System.Windows.Forms.Padding(2);
            this.MacroEditor.Name = "MacroEditor";
            this.MacroEditor.Size = new System.Drawing.Size(1123, 649);
            this.MacroEditor.TabIndex = 0;
            // 
            // MacroManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 724);
            this.Controls.Add(this.FocusMe);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.Tools);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.MacroEditor);
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MacroManager";
            this.Text = "Ennerbot Routine Designer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MacroManager_FormClosing);
            this.Load += new System.EventHandler(this.MacroManager_Load);
            this.Resize += new System.EventHandler(this.MacroManager_Resize);
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MacroEditor MacroEditor;
        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.ToolStripButton toolBtnPause;
        private System.Windows.Forms.ToolStripButton toolBtnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolBtnPlay;
        private System.Windows.Forms.ToolStripTextBox toolTxtIterations;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuMacro;
        private System.Windows.Forms.ToolStripMenuItem menuMacroRun;
        private System.Windows.Forms.ToolStripMenuItem menuMacroStop;
        private System.Windows.Forms.ToolStripMenuItem menuMacroPause;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuMacroOpenMethodRegister;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpSpecialCharacters;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblClient;
        private System.Windows.Forms.ToolStripProgressBar prgIterationProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblGeneralStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblIterationStatus;
        private System.Windows.Forms.ToolStripButton toolBtnValidate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton btnRefreshClient;
        private System.Windows.Forms.ToolStripMenuItem menuMacroValidate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnViewMethodEditor;
        private System.Windows.Forms.Label FocusMe;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;

    }
}