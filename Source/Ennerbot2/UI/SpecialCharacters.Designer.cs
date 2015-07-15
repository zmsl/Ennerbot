namespace Ennerbot
{
    partial class SpecialCharacters
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
            this.txtKeyList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtKeyList
            // 
            this.txtKeyList.Location = new System.Drawing.Point(12, 12);
            this.txtKeyList.Multiline = true;
            this.txtKeyList.Name = "txtKeyList";
            this.txtKeyList.ReadOnly = true;
            this.txtKeyList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeyList.Size = new System.Drawing.Size(392, 441);
            this.txtKeyList.TabIndex = 0;
            // 
            // SpecialCharacters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 464);
            this.Controls.Add(this.txtKeyList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpecialCharacters";
            this.Text = "SpecialCharacters";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpecialCharacters_FormClosing);
            this.Load += new System.EventHandler(this.SpecialCharacters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyList;
    }
}