namespace Presentation.Forms
{
    partial class CreateUserForm
    {
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblRole;
        private ComboBox cmbRole;
        private Button btnCreateUser;
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
            btnCreateUser = new Button();
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
            lblRole.Location = new Point(30, 108);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(100, 23);
            lblRole.TabIndex = 2;
            lblRole.Text = "Role:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "Admin", "User" });
            cmbRole.SelectedIndex = 0;
            cmbRole.Location = new Point(140, 108);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 23);
            cmbRole.TabIndex = 3;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(140, 148);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(200, 30);
            btnCreateUser.TabIndex = 4;
            btnCreateUser.Text = "Create User";
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(140, 69);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 6;
            // 
            // label1
            // 
            label1.Location = new Point(30, 69);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 5;
            label1.Text = "Password:";
            // 
            // CreateUserForm
            // 
            ClientSize = new Size(407, 212);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(btnCreateUser);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            MaximizeBox = false;
            Name = "CreateUserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create User";
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox txtPassword;
        private Label label1;
    }
}