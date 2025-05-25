namespace Presentation.Forms
{
    partial class ViewProductForm
    {
        private Label lblProductName;
        private TextBox txtTitle;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnSaveProduct;
        private System.ComponentModel.IContainer components = null;

        private Label label1;
        private TextBox txtArticle;
        private Label txtCodeLbl;
        private TextBox txtCode;
        private Label label2;
        private ComboBox cmbCategory;
        private Label label3;
        private ComboBox cmbWarehouse;
        private TextBox txtOldPrice;

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
            lblProductName = new Label();
            txtTitle = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            btnSaveProduct = new Button();
            label1 = new Label();
            txtArticle = new TextBox();
            txtCodeLbl = new Label();
            txtCode = new TextBox();
            label2 = new Label();
            cmbWarehouse = new ComboBox();
            cmbCategory = new ComboBox();
            label3 = new Label();
            txtOldPrice = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // lblProductName
            // 
            lblProductName.Location = new Point(30, 30);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(100, 23);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Product Name:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(140, 30);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 23);
            txtTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.Location = new Point(30, 70);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(100, 23);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(140, 70);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 60);
            txtDescription.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(30, 297);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(140, 297);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 23);
            txtPrice.TabIndex = 5;
            txtPrice.KeyPress += NumericTextBox_KeyPress;
            // 
            // lblQuantity
            // 
            lblQuantity.Location = new Point(30, 373);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 23);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(140, 373);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(200, 23);
            txtQuantity.TabIndex = 7;
            txtQuantity.KeyPress += NumericTextBox_KeyPress;
            // 
            // btnSaveProduct
            // 
            btnSaveProduct.Location = new Point(140, 413);
            btnSaveProduct.Name = "btnSaveProduct";
            btnSaveProduct.Size = new Size(200, 30);
            btnSaveProduct.TabIndex = 8;
            btnSaveProduct.Text = "Save";
            btnSaveProduct.Click += btnSaveProduct_Click;
            // 
            // label1
            // 
            label1.Location = new Point(30, 189);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 9;
            label1.Text = "Product Article:";
            // 
            // txtArticle
            // 
            txtArticle.Location = new Point(140, 189);
            txtArticle.Name = "txtArticle";
            txtArticle.Size = new Size(200, 23);
            txtArticle.TabIndex = 10;
            // 
            // txtCodeLbl
            // 
            txtCodeLbl.Location = new Point(30, 148);
            txtCodeLbl.Name = "txtCodeLbl";
            txtCodeLbl.Size = new Size(100, 23);
            txtCodeLbl.TabIndex = 11;
            txtCodeLbl.Text = "Product Code:";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(140, 148);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(200, 23);
            txtCode.TabIndex = 12;
            // 
            // label2
            // 
            label2.Location = new Point(30, 228);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 13;
            label2.Text = "Category:";
            // 
            // cmbWarehouse
            // 
            cmbWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbWarehouse.Location = new Point(140, 260);
            cmbWarehouse.Name = "cmbWarehouse";
            cmbWarehouse.Size = new Size(200, 23);
            cmbWarehouse.TabIndex = 7;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(140, 228);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(200, 23);
            cmbCategory.TabIndex = 7;
            // 
            // label3
            // 
            label3.Location = new Point(30, 335);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 15;
            label3.Text = "Old Price:";
            // 
            // txtOldPrice
            // 
            txtOldPrice.Location = new Point(140, 335);
            txtOldPrice.Name = "txtOldPrice";
            txtOldPrice.Size = new Size(200, 23);
            txtOldPrice.TabIndex = 16;
            txtOldPrice.KeyPress += NumericTextBox_KeyPress;
            // 
            // label4
            // 
            label4.Location = new Point(30, 260);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 17;
            label4.Text = "Warehouse:";
            // 
            // ViewProductForm
            // 
            ClientSize = new Size(407, 477);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtOldPrice);
            Controls.Add(label2);
            Controls.Add(cmbCategory);
            Controls.Add(cmbWarehouse);
            Controls.Add(txtCodeLbl);
            Controls.Add(txtCode);
            Controls.Add(label1);
            Controls.Add(txtArticle);
            Controls.Add(lblProductName);
            Controls.Add(txtTitle);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblQuantity);
            Controls.Add(txtQuantity);
            Controls.Add(btnSaveProduct);
            MaximizeBox = false;
            Name = "ViewProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Update product";
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
        private Label label4;
    }
}
