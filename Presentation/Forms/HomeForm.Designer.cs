using System.Windows.Forms;

namespace Presentation.Forms
{
    partial class HomeForm
    {
        private Label lblCurrentUser;
        private DataGridView dgvProducts;
        private TextBox txtFilterName;
        private TextBox txtFilterCategory;
        private TextBox txtFilterPrice;
        private Button btnFilter;
        private Button btnGenerateReport;
        private Button btnLogout;
        private Button btnManageUsers;
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
            dgvProducts = new DataGridView();
            dataGridViewTextBoxColumnID = new DataGridViewTextBoxColumn{
                HeaderText = "ProductID",
                Name = "ProductID",
                Visible = false
            };
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            var deleteButtonColumn = new DataGridViewButtonColumn();

            txtFilterName = new TextBox();
            txtFilterCategory = new TextBox();
            txtFilterPrice = new TextBox();
            btnFilter = new Button();
            btnGenerateReport = new Button();
            btnLogout = new Button();
            btnManageUsers = new Button();
            btnCreateProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
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
            // dgvProducts
            // 
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] 
            {
                dataGridViewTextBoxColumnID,
                dataGridViewTextBoxColumn1, 
                dataGridViewTextBoxColumn2, 
                dataGridViewTextBoxColumn3, 
                dataGridViewTextBoxColumn4, 
                dataGridViewTextBoxColumn5, 
                dataGridViewTextBoxColumn6, 
                dataGridViewTextBoxColumn7,
                deleteButtonColumn
            });

            dgvProducts.CellContentClick += dgvProducts_CellDeleteClick;
            dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;

            deleteButtonColumn.HeaderText = "Actions";
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;


            dgvProducts.Location = new Point(10, 80);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1200, 800);
            dgvProducts.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Title";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Code";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Article";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Price";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Old price";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Quantity";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Category";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // txtFilterName
            // 
            txtFilterName.Location = new Point(10, 40);
            txtFilterName.Name = "txtFilterName";
            txtFilterName.PlaceholderText = "Filter by name";
            txtFilterName.Size = new Size(120, 23);
            txtFilterName.TabIndex = 2;
            // 
            // txtFilterCategory
            // 
            txtFilterCategory.Location = new Point(140, 40);
            txtFilterCategory.Name = "txtFilterCategory";
            txtFilterCategory.PlaceholderText = "Filter by category";
            txtFilterCategory.Size = new Size(120, 23);
            txtFilterCategory.TabIndex = 3;
            // 
            // txtFilterPrice
            // 
            txtFilterPrice.Location = new Point(270, 40);
            txtFilterPrice.Name = "txtFilterPrice";
            txtFilterPrice.PlaceholderText = "Filter by price";
            txtFilterPrice.Size = new Size(120, 23);
            txtFilterPrice.TabIndex = 4;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(400, 40);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 23);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Apply";
            btnFilter.Click += btnFilter_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(1220, 80);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 30);
            btnGenerateReport.TabIndex = 6;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(1220, 120);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 30);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // btnManageUsers
            // 
            btnManageUsers.Location = new Point(1220, 160);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(150, 30);
            btnManageUsers.TabIndex = 8;
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.Visible = false;
            // 
            // btnCreateProduct
            // 
            btnCreateProduct.Location = new Point(1220, 199);
            btnCreateProduct.Name = "btnCreateProduct";
            btnCreateProduct.Size = new Size(150, 30);
            btnCreateProduct.TabIndex = 9;
            btnCreateProduct.Text = "Create product";
            btnCreateProduct.Click += btnCreateProduct_Click;
            // 
            // HomeForm
            // 
            ClientSize = new Size(1387, 894);
            Controls.Add(btnCreateProduct);
            Controls.Add(lblCurrentUser);
            Controls.Add(dgvProducts);
            Controls.Add(txtFilterName);
            Controls.Add(txtFilterCategory);
            Controls.Add(txtFilterPrice);
            Controls.Add(btnFilter);
            Controls.Add(btnGenerateReport);
            Controls.Add(btnLogout);
            Controls.Add(btnManageUsers);
            MaximizeBox = false;
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnID;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

        private Button btnCreateProduct;
    }
}