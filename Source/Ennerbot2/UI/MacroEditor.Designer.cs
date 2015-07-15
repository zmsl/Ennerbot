namespace Ennerbot
{
    partial class MacroEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MacroText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MacroText
            // 
            this.MacroText.Location = new System.Drawing.Point(0, 0);
            this.MacroText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MacroText.Multiline = true;
            this.MacroText.Name = "MacroText";
            this.MacroText.Size = new System.Drawing.Size(200, 100);
            this.MacroText.TabIndex = 0;
            // 
            // MacroEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MacroText);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MacroEditor";
            this.Size = new System.Drawing.Size(200, 100);
            this.Load += new System.EventHandler(this.MacroEditor_Load);
            this.Resize += new System.EventHandler(this.MacroEditor_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MacroText;
    }
}
