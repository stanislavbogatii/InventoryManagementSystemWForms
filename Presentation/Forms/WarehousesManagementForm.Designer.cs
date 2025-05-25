using System.Windows.Forms;

namespace Presentation.Forms
{
    partial class WarehouseManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvWarehouses;
        private Button btnCreateWarehouse;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnID;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
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
            dgvWarehouses = new DataGridView();
            dataGridViewTextBoxColumnID = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            deleteButtonColumn = new DataGridViewButtonColumn();
            btnCreateWarehouse = new Button();
            btnCloneWarehouse = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvWarehouses).BeginInit();
            SuspendLayout();
            // 
            // dgvWarehouses
            // 
            dgvWarehouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWarehouses.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumnID, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, deleteButtonColumn });
            dgvWarehouses.Location = new Point(12, 12);
            dgvWarehouses.Name = "dgvWarehouses";
            dgvWarehouses.ReadOnly = true;
            dgvWarehouses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarehouses.Size = new Size(600, 400);
            dgvWarehouses.TabIndex = 0;
            dgvWarehouses.CellContentClick += dgvWarehouses_CellDeleteClick;
            dgvWarehouses.CellDoubleClick += dgvWarehouses_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumnID
            // 
            dataGridViewTextBoxColumnID.HeaderText = "ID";
            dataGridViewTextBoxColumnID.Name = "dataGridViewTextBoxColumnID";
            dataGridViewTextBoxColumnID.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Name";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Length";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Width";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Height";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Capacity";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Storage Type";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Access Level";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // deleteButtonColumn
            // 
            deleteButtonColumn.HeaderText = "Actions";
            deleteButtonColumn.Name = "deleteButtonColumn";
            deleteButtonColumn.ReadOnly = true;
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            // 
            // btnCreateWarehouse
            // 
            btnCreateWarehouse.Location = new Point(630, 12);
            btnCreateWarehouse.Name = "btnCreateWarehouse";
            btnCreateWarehouse.Size = new Size(150, 30);
            btnCreateWarehouse.TabIndex = 1;
            btnCreateWarehouse.Text = "Create Warehouse";
            btnCreateWarehouse.UseVisualStyleBackColor = true;
            btnCreateWarehouse.Click += btnCreateWarehouse_Click;
            // 
            // btnCloneWarehouse
            // 
            btnCloneWarehouse.Location = new Point(630, 48);
            btnCloneWarehouse.Name = "btnCloneWarehouse";
            btnCloneWarehouse.Size = new Size(150, 30);
            btnCloneWarehouse.TabIndex = 2;
            btnCloneWarehouse.Text = "Clone Selected";
            btnCloneWarehouse.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCloneWarehouse.UseVisualStyleBackColor = true;
            btnCloneWarehouse.Click += btnCloneWarehouse_Click;
            // 
            // WarehouseManagementForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(btnCloneWarehouse);
            Controls.Add(btnCreateWarehouse);
            Controls.Add(dgvWarehouses);
            Name = "WarehouseManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Warehouse Management";
            Load += WarehouseManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWarehouses).EndInit();
            ResumeLayout(false);
        }
        private Button btnCloneWarehouse;
    }
}
