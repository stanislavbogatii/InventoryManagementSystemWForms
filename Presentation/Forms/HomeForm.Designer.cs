namespace Presentation.Forms
{
    partial class HomeForm
    {

        private Label lblWelcome;
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
            lblWelcome = new Label();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(100, 23);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 182);
            Controls.Add(lblWelcome);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            Load += homeForm_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}