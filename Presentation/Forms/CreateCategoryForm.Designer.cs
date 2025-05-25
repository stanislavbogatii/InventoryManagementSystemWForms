using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.Forms
{
    partial class CreateCategoryForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private TextBox txtTitle;

        private Label lblCategoryCode;
        private TextBox txtCategoryCode;
        private ComboBox cmbParentCategory;


        private Label lblParentTitle;
        private TextBox txtParentTitle;

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
            txtTitle = new TextBox();
            lblTitle = new Label();
            txtCategoryCode = new TextBox();
            lblCategoryCode = new Label();
            txtParentTitle = new TextBox();
            lblParentTitle = new Label();
            btnSave = new Button();
            cmbParentCategory = new ComboBox();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(130, 12);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 23);
            txtTitle.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Title:";
            // 
            // txtCategoryCode
            // 
            txtCategoryCode.Location = new Point(130, 52);
            txtCategoryCode.Name = "txtCategoryCode";
            txtCategoryCode.Size = new Size(200, 23);
            txtCategoryCode.TabIndex = 5;
            // 
            // lblCategoryCode
            // 
            lblCategoryCode.Location = new Point(20, 52);
            lblCategoryCode.Name = "lblCategoryCode";
            lblCategoryCode.Size = new Size(100, 23);
            lblCategoryCode.TabIndex = 4;
            lblCategoryCode.Text = "Category Code:";
            // 
            // txtParentTitle
            // 
            txtParentTitle.Location = new Point(130, 92);
            txtParentTitle.Name = "txtParentTitle";
            txtParentTitle.Size = new Size(200, 23);
            txtParentTitle.TabIndex = 7;
            // 
            // lblParentTitle
            // 
            lblParentTitle.Location = new Point(20, 92);
            lblParentTitle.Name = "lblParentTitle";
            lblParentTitle.Size = new Size(100, 23);
            lblParentTitle.TabIndex = 6;
            lblParentTitle.Text = "Parent Category:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(130, 133);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // cmbParentCategory
            // 
            cmbParentCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParentCategory.Location = new Point(130, 92);
            cmbParentCategory.Name = "cmbParentCategory";
            cmbParentCategory.Size = new Size(200, 23);
            cmbParentCategory.TabIndex = 7;
            // 
            // CreateCategoryForm
            // 
            ClientSize = new Size(368, 198);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblCategoryCode);
            Controls.Add(txtCategoryCode);
            Controls.Add(lblParentTitle);
            Controls.Add(cmbParentCategory);
            Controls.Add(btnSave);
            Name = "CreateCategoryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Category";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
