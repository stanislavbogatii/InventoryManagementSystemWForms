using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Presentation.Forms
{

    partial class UserManagementForm
    {
        private Label lblCurrentUser;
        public DataGridView dgvUsers;
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
            lblCurrentUser = new Label();
            dgvUsers = new DataGridView();
            dataGridViewTextBoxColumnID = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            deleteButtonColumn = new DataGridViewButtonColumn();
            btnCreateUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Location = new Point(10, 10);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(300, 23);
            lblCurrentUser.TabIndex = 0;
            lblCurrentUser.Text = "Logged in as: [UserName]";
            // 
            // dgvUsers
            // 
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeight = 29;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumnID, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, deleteButtonColumn });
            dgvUsers.Location = new Point(10, 40);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1200, 800);
            dgvUsers.TabIndex = 1;
            dgvUsers.CellContentClick += dgvUsers_CellDeleteClick;
            dgvUsers.CellDoubleClick += dgvUsers_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumnID
            // 
            dataGridViewTextBoxColumnID.HeaderText = "ID";
            dataGridViewTextBoxColumnID.MinimumWidth = 6;
            dataGridViewTextBoxColumnID.Name = "dataGridViewTextBoxColumnID";
            dataGridViewTextBoxColumnID.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Username";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Role";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // deleteButtonColumn
            // 
            deleteButtonColumn.HeaderText = "Actions";
            deleteButtonColumn.MinimumWidth = 6;
            deleteButtonColumn.Name = "deleteButtonColumn";
            deleteButtonColumn.ReadOnly = true;
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(1225, 40);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(150, 30);
            btnCreateUser.TabIndex = 2;
            btnCreateUser.Text = "Create User";
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // UserManagementForm
            // 
            ClientSize = new Size(1387, 850);
            Controls.Add(btnCreateUser);
            Controls.Add(dgvUsers);
            Controls.Add(lblCurrentUser);
            MaximizeBox = false;
            Name = "UserManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Management";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }



        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnID;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewButtonColumn deleteButtonColumn;
    }
}