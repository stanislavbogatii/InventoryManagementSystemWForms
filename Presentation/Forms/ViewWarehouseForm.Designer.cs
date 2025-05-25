using DocumentFormat.OpenXml.InkML;

namespace Presentation.Forms
{
    partial class ViewWarehouseForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblName;
        private TextBox txtName;

        private Label lblWidth;
        private TextBox txtWidth;

        private Label lblLength;
        private TextBox txtLength;

        private Label lblHeight;
        private TextBox txtHeight;

        private Label lblCapacity;
        private TextBox txtCapacity;

        private Label lblStorageType;
        private ComboBox cmbStorageType;

        private Label lblAccessLevel;
        private ComboBox cmbAccessLevel;
        private CheckBox chkHasSecuritySystem;

        private Button btnSave;

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
            txtName = new TextBox();
            lblName = new Label();
            txtWidth = new TextBox();
            lblWidth = new Label();
            txtLength = new TextBox();
            lblLength = new Label();
            txtHeight = new TextBox();
            lblHeight = new Label();
            txtCapacity = new TextBox();
            lblCapacity = new Label();
            cmbStorageType = new ComboBox();
            lblStorageType = new Label();
            chkHasSecuritySystem = new CheckBox();
            cmbAccessLevel = new ComboBox();
            lblAccessLevel = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(130, 57);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(200, 23);
            txtWidth.TabIndex = 5;
            // 
            // lblWidth
            // 
            lblWidth.Location = new Point(20, 57);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new Size(100, 23);
            lblWidth.TabIndex = 4;
            lblWidth.Text = "Width:";
            // 
            // txtLength
            // 
            txtLength.Location = new Point(130, 97);
            txtLength.Name = "txtLength";
            txtLength.Size = new Size(200, 23);
            txtLength.TabIndex = 7;
            // 
            // lblLength
            // 
            lblLength.Location = new Point(20, 97);
            lblLength.Name = "lblLength";
            lblLength.Size = new Size(100, 23);
            lblLength.TabIndex = 6;
            lblLength.Text = "Length:";
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(130, 137);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(200, 23);
            txtHeight.TabIndex = 9;
            // 
            // lblHeight
            // 
            lblHeight.Location = new Point(20, 137);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(100, 23);
            lblHeight.TabIndex = 8;
            lblHeight.Text = "Height:";
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(130, 177);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(200, 23);
            txtCapacity.TabIndex = 11;
            // 
            // lblCapacity
            // 
            lblCapacity.Location = new Point(20, 177);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(100, 23);
            lblCapacity.TabIndex = 10;
            lblCapacity.Text = "Capacity:";
            // 
            // cmbStorageType
            // 
            cmbStorageType.Items.AddRange(new object[] { "Shelf", "Rack", "Bin", "Pallet" });
            cmbStorageType.Location = new Point(130, 217);
            cmbStorageType.Name = "cmbStorageType";
            cmbStorageType.Size = new Size(200, 23);
            cmbStorageType.TabIndex = 13;
            cmbStorageType.SelectedIndex = 0;
            // 
            // lblStorageType
            // 
            lblStorageType.Location = new Point(20, 217);
            lblStorageType.Name = "lblStorageType";
            lblStorageType.Size = new Size(100, 23);
            lblStorageType.TabIndex = 12;
            lblStorageType.Text = "Storage Type:";
            // 
            // chkHasSecuritySystem
            // 
            chkHasSecuritySystem.Location = new Point(150, 340);
            chkHasSecuritySystem.Name = "chkHasSecuritySystem";
            chkHasSecuritySystem.Size = new Size(15, 14);
            chkHasSecuritySystem.TabIndex = 0;
            // 
            // cmbAccessLevel
            // 
            cmbAccessLevel.Items.AddRange(new object[] { "Public", "Restricted", "Confidential", "TopSecret" });
            cmbAccessLevel.Location = new Point(130, 257);
            cmbAccessLevel.Name = "cmbAccessLevel";
            cmbAccessLevel.Size = new Size(200, 23);
            cmbAccessLevel.TabIndex = 16;
            cmbAccessLevel.SelectedIndex = 0;
            // 
            // lblAccessLevel
            // 
            lblAccessLevel.Location = new Point(20, 257);
            lblAccessLevel.Name = "lblAccessLevel";
            lblAccessLevel.Size = new Size(100, 23);
            lblAccessLevel.TabIndex = 15;
            lblAccessLevel.Text = "Access Level:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(130, 307);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // CreateWarehouseForm
            // 
            ClientSize = new Size(370, 346);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblWidth);
            Controls.Add(txtWidth);
            Controls.Add(lblLength);
            Controls.Add(txtLength);
            Controls.Add(lblHeight);
            Controls.Add(txtHeight);
            Controls.Add(lblCapacity);
            Controls.Add(txtCapacity);
            Controls.Add(lblStorageType);
            Controls.Add(cmbStorageType);
            Controls.Add(lblAccessLevel);
            Controls.Add(cmbAccessLevel);
            Controls.Add(btnSave);
            Name = "CreateWarehouseForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Warehouse";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
