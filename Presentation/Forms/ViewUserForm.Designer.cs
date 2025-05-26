namespace Presentation.Forms
{
    partial class ViewUserForm
    {
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblRole;
        private ComboBox cmbRole;
        private Button btnSaveUser;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            btnSaveUser = new Button();
            txtPassword = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.Location = new Point(30, 30);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(140, 30);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblRole
            // 
            lblRole.Location = new Point(30, 102);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(100, 23);
            lblRole.TabIndex = 2;
            lblRole.Text = "Role:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "Admin", "User" });
            cmbRole.Location = new Point(140, 102);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 23);
            cmbRole.TabIndex = 3;
            // 
            // btnSaveUser
            // 
            btnSaveUser.Location = new Point(140, 153);
            btnSaveUser.Name = "btnSaveUser";
            btnSaveUser.Size = new Size(200, 30);
            btnSaveUser.TabIndex = 4;
            btnSaveUser.Text = "Save";
            btnSaveUser.Click += btnSaveUser_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(140, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 6;
            // 
            // label1
            // 
            label1.Location = new Point(30, 67);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 5;
            label1.Text = "Password:";
            // 
            // ViewUserForm
            // 
            ClientSize = new Size(407, 236);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(btnSaveUser);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            MaximizeBox = false;
            Name = "ViewUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update User";
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox txtPassword;
        private Label label1;
    }
}