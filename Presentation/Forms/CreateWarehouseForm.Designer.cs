namespace Presentation.Forms
{
    partial class CreateWarehouseForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtName;
        private TextBox txtLocation;
        private Label lblName;
        private Label lblLocation;
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
            this.txtName = new TextBox();
            this.txtLocation = new TextBox();
            this.lblName = new Label();
            this.lblLocation = new Label();
            this.btnSave = new Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 0;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(100, 60);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(200, 23);
            this.txtLocation.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Size = new System.Drawing.Size(60, 23);
            this.lblName.Text = "Name:";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(20, 60);
            this.lblLocation.Size = new System.Drawing.Size(60, 23);
            this.lblLocation.Text = "Location:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 100);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            // 
            // CreateWarehouseForm
            // 
            this.ClientSize = new System.Drawing.Size(330, 150);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtLocation);
            this.Name = "CreateWarehouseForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Create Warehouse";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
