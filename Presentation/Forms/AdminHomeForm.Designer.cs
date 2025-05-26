using System.Windows.Forms;

namespace Presentation.Forms
{
    partial class AdminHomeForm
    {
        private Label lblCurrentUser;
        public DataGridView dgvProducts;
        private TextBox txtFilterName;
        private TextBox txtFilterCategory;
        private Button btnFilter;
        private Button btnGenerateReport;
        public ComboBox comboBoxReportType;
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
            dataGridViewTextBoxColumnID = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            deleteButtonColumn = new DataGridViewButtonColumn();
            txtFilterName = new TextBox();
            txtFilterCategory = new TextBox();
            btnFilter = new Button();
            btnGenerateReport = new Button();
            comboBoxReportType = new ComboBox();
            btnLogout = new Button();
            btnManageUsers = new Button();
            btnCreateProduct = new Button();
            intMinPrice = new TextBox();
            intMaxPrice = new TextBox();
            btnManageWarehoues = new Button();
            btnManageCategories = new Button();
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
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumnID, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, deleteButtonColumn });
            dgvProducts.Location = new Point(10, 80);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1200, 800);
            dgvProducts.TabIndex = 1;
            dgvProducts.CellContentClick += dgvProducts_CellDeleteClick;
            dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;
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
            dataGridViewTextBoxColumn1.HeaderText = "Title";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Code";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Article";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Price";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Old price";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Quantity";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Category";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Warehouse";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
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
            // txtFilterName
            // 
            txtFilterName.Location = new Point(10, 40);
            txtFilterName.Name = "txtFilterName";
            txtFilterName.PlaceholderText = " Name, article, code";
            txtFilterName.Size = new Size(120, 27);
            txtFilterName.TabIndex = 2;
            // 
            // txtFilterCategory
            // 
            txtFilterCategory.Location = new Point(136, 40);
            txtFilterCategory.Name = "txtFilterCategory";
            txtFilterCategory.PlaceholderText = "Filter by category";
            txtFilterCategory.Size = new Size(120, 27);
            txtFilterCategory.TabIndex = 3;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(514, 40);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 23);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Apply";
            btnFilter.Click += btnFilter_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(1225, 116);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 30);
            btnGenerateReport.TabIndex = 6;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // comboBoxReportType
            // 
            comboBoxReportType.Items.AddRange(new object[] { "Short report", "Detailed report" });
            comboBoxReportType.Location = new Point(1225, 80);
            comboBoxReportType.Name = "comboBoxReportType";
            comboBoxReportType.Size = new Size(150, 28);
            comboBoxReportType.TabIndex = 6;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.ButtonFace;
            btnLogout.Location = new Point(1216, 850);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 30);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnManageUsers
            // 
            btnManageUsers.Location = new Point(1225, 152);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(150, 30);
            btnManageUsers.TabIndex = 8;
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.Click += btnManageUsers_Click;
            // 
            // btnCreateProduct
            // 
            btnCreateProduct.Location = new Point(1225, 260);
            btnCreateProduct.Name = "btnCreateProduct";
            btnCreateProduct.Size = new Size(150, 30);
            btnCreateProduct.TabIndex = 9;
            btnCreateProduct.Text = "Create product";
            btnCreateProduct.Click += btnCreateProduct_Click;
            // 
            // intMinPrice
            // 
            intMinPrice.Location = new Point(262, 40);
            intMinPrice.Name = "intMinPrice";
            intMinPrice.PlaceholderText = "Min price";
            intMinPrice.Size = new Size(120, 27);
            intMinPrice.TabIndex = 10;
            intMinPrice.KeyPress += NumericTextBox_KeyPress;
            // 
            // intMaxPrice
            // 
            intMaxPrice.Location = new Point(388, 40);
            intMaxPrice.Name = "intMaxPrice";
            intMaxPrice.PlaceholderText = "Max price";
            intMaxPrice.Size = new Size(120, 27);
            intMaxPrice.TabIndex = 11;
            intMaxPrice.KeyPress += NumericTextBox_KeyPress;
            // 
            // btnManageWarehoues
            // 
            btnManageWarehoues.Location = new Point(1225, 188);
            btnManageWarehoues.Name = "btnManageWarehoues";
            btnManageWarehoues.Size = new Size(150, 30);
            btnManageWarehoues.TabIndex = 12;
            btnManageWarehoues.Text = "Manage Warehouses";
            btnManageWarehoues.Click += btnManageWarehoues_Click;
            // 
            // btnManageCategories
            // 
            btnManageCategories.Location = new Point(1225, 224);
            btnManageCategories.Name = "btnManageCategories";
            btnManageCategories.Size = new Size(150, 30);
            btnManageCategories.TabIndex = 13;
            btnManageCategories.Text = "Manage Categories";
            btnManageCategories.Click += btnManageCategories_Click;
            // 
            // AdminHomeForm
            // 
            ClientSize = new Size(1387, 894);
            Controls.Add(btnManageCategories);
            Controls.Add(btnManageWarehoues);
            Controls.Add(intMaxPrice);
            Controls.Add(intMinPrice);
            Controls.Add(btnCreateProduct);
            Controls.Add(lblCurrentUser);
            Controls.Add(dgvProducts);
            Controls.Add(txtFilterName);
            Controls.Add(txtFilterCategory);
            Controls.Add(btnFilter);
            Controls.Add(btnGenerateReport);
            Controls.Add(comboBoxReportType);
            Controls.Add(btnLogout);
            Controls.Add(btnManageUsers);
            MaximizeBox = false;
            Name = "AdminHomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }



        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator)
            {
                e.Handled = true;
            }

            if (e.KeyChar == decimalSeparator && txtBox.Text.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }


        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnID;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

        private Button btnCreateProduct;
        private DataGridViewButtonColumn deleteButtonColumn;
        private TextBox intMinPrice;
        private TextBox intMaxPrice;
        private Button btnManageWarehoues;
        private Button btnManageCategories;
    }
}