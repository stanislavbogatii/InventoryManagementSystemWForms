using System.Windows.Forms;

namespace Presentation.Forms
{
    partial class CategoriesManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvCategories;
        private Button btnCreateCategory;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnID;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnTitle;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnCode;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnParentTitle;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnProductCount;
        private DataGridViewButtonColumn deleteButtonColumn;

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
            dgvCategories = new DataGridView();
            dataGridViewTextBoxColumnID = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnTitle = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnCode = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnParentTitle = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnProductCount = new DataGridViewTextBoxColumn();
            deleteButtonColumn = new DataGridViewButtonColumn();
            btnCreateCategory = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
            SuspendLayout();
            // 
            // dgvCategories
            // 
            dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategories.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumnID, dataGridViewTextBoxColumnTitle, dataGridViewTextBoxColumnCode, dataGridViewTextBoxColumnParentTitle, dataGridViewTextBoxColumnProductCount, deleteButtonColumn });
            dgvCategories.Location = new Point(12, 12);
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.Size = new Size(600, 400);
            dgvCategories.TabIndex = 0;
            dgvCategories.CellContentClick += dgvCategories_CellDeleteClick;
            dgvCategories.CellDoubleClick += dgvCategories_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumnID
            // 
            dataGridViewTextBoxColumnID.HeaderText = "ID";
            dataGridViewTextBoxColumnID.Name = "dataGridViewTextBoxColumnID";
            dataGridViewTextBoxColumnID.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnTitle
            // 
            dataGridViewTextBoxColumnTitle.HeaderText = "Title";
            dataGridViewTextBoxColumnTitle.Name = "dataGridViewTextBoxColumnTitle";
            dataGridViewTextBoxColumnTitle.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnCode
            // 
            dataGridViewTextBoxColumnCode.HeaderText = "Category Code";
            dataGridViewTextBoxColumnCode.Name = "dataGridViewTextBoxColumnCode";
            dataGridViewTextBoxColumnCode.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnParentTitle
            // 
            dataGridViewTextBoxColumnParentTitle.HeaderText = "Parent Title";
            dataGridViewTextBoxColumnParentTitle.Name = "dataGridViewTextBoxColumnParentTitle";
            dataGridViewTextBoxColumnParentTitle.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumnProductCount
            // 
            dataGridViewTextBoxColumnProductCount.HeaderText = "Products Count";
            dataGridViewTextBoxColumnProductCount.Name = "dataGridViewTextBoxColumnProductCount";
            dataGridViewTextBoxColumnProductCount.ReadOnly = true;
            // 
            // deleteButtonColumn
            // 
            deleteButtonColumn.HeaderText = "Actions";
            deleteButtonColumn.Name = "deleteButtonColumn";
            deleteButtonColumn.ReadOnly = true;
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            // 
            // btnCreateCategory
            // 
            btnCreateCategory.Location = new Point(630, 12);
            btnCreateCategory.Name = "btnCreateCategory";
            btnCreateCategory.Size = new Size(150, 30);
            btnCreateCategory.TabIndex = 1;
            btnCreateCategory.Text = "Create Category";
            btnCreateCategory.UseVisualStyleBackColor = true;
            btnCreateCategory.Click += btnCreateCategory_Click;
            // 
            // CategoriesManagementForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(btnCreateCategory);
            Controls.Add(dgvCategories);
            Name = "CategoriesManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Category Management";
            Load += CategoryManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
            ResumeLayout(false);
        }

    }
}
