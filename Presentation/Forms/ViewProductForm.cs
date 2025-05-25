using Application.DTOs.Product;
using Application.Interfaces;

namespace Presentation.Forms
{
    public partial class ViewProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ProductDto? _product;

        public ViewProductForm(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            this.AcceptButton = btnSaveProduct;
        }

        public ViewProductForm(IProductService productService, ProductDto product)
            : this(productService)
        {
            _product = product;
            if (product is not null)
            {
                populateForm(product);
            }
        }

        public void populateForm(ProductDto product)
        {
            txtTitle.Text = product.Title;
            txtCode.Text = product.Code;
            txtArticle.Text = product.Article;
            txtDescription.Text = product.Description;
            txtPrice.Text = product.Price.ToString();
            txtOldPrice.Text = product.OldPrice.ToString();
            txtQuantity.Text = product.Quantity.ToString();
        }

        public async void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            try
            {
                var dto = new UpdateProductDto
                {
                    Title = txtTitle.Text,
                    Code = txtCode.Text,
                    Article = txtArticle.Text,
                    Description = txtDescription.Text,
                    Price = Int32.Parse(txtPrice.Text),
                    Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : int.Parse(txtQuantity.Text),
                    OldPrice = string.IsNullOrEmpty(txtOldPrice.Text) ? 0 : int.Parse(txtOldPrice.Text),
                    CategoryId = string.IsNullOrEmpty(txtCategory.Text) ? null : int.Parse(txtCategory.Text)
                };

                if (dto is not null)
                {
                    await _productService.Update(_product.Id, dto);
                }

                MessageBox.Show($"Product '{dto.Title}' success created");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
            }
        }

        public bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Please enter product code .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtArticle.Text))
            {
                MessageBox.Show("Please enter product article .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArticle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Please enter product price .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }
            return true;
        }
    }
}
