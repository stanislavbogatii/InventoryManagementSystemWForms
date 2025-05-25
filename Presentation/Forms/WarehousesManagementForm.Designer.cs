namespace Presentation.Forms
{
    partial class WarehouseManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvWarehouses;
        private Button btnCreateWarehouse;

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
            this.dgvWarehouses = new DataGridView();
            this.btnCreateWarehouse = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWarehouses
            // 
            this.dgvWarehouses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarehouses.Location = new System.Drawing.Point(12, 12);
            this.dgvWarehouses.Name = "dgvWarehouses";
            this.dgvWarehouses.ReadOnly = true;
            this.dgvWarehouses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouses.Size = new System.Drawing.Size(600, 400);
            this.dgvWarehouses.TabIndex = 0;
            // 
            // btnCreateWarehouse
            // 
            this.btnCreateWarehouse.Location = new System.Drawing.Point(630, 12);
            this.btnCreateWarehouse.Name = "btnCreateWarehouse";
            this.btnCreateWarehouse.Size = new System.Drawing.Size(150, 30);
            this.btnCreateWarehouse.TabIndex = 1;
            this.btnCreateWarehouse.Text = "Create Warehouse";
            this.btnCreateWarehouse.UseVisualStyleBackColor = true;
            this.btnCreateWarehouse.Click += new EventHandler(this.btnCreateWarehouse_Click);
            // 
            // WarehouseManagementForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateWarehouse);
            this.Controls.Add(this.dgvWarehouses);
            this.Name = "WarehouseManagementForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Warehouse Management";
            this.Load += new EventHandler(this.WarehouseManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
