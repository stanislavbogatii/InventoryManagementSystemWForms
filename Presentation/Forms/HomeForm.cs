using Application.Interfaces;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Forms
{
    public partial class HomeForm : Form
    {
        private readonly IProductService _productService;
        private IServiceProvider _serviceProvider;

        public HomeForm(
            IProductService productService,
            IServiceProvider serviceProvider
        )
        {
            InitializeComponent();
            _productService = productService;
            _serviceProvider = serviceProvider;

            if (Session.CurrentUser?.Role == "Admin")
            {
                btnManageUsers.Visible = true;
            }
            lblCurrentUser.Text = $"Current user: {Session.CurrentUser?.Username}";

            _ = LoadProductsAsync();
        }

        private async void dgvProducts_CellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "DeleteButton" && e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await _productService.Delete(productId);
                    dgvProducts.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private async void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value);
            var product = await _productService.GetById(productId);

            if (product == null)
            {
                MessageBox.Show("Product not found!");
                return;
            }

            var editProductForm = ActivatorUtilities.CreateInstance<ViewProductForm>(_serviceProvider, product);
            if (editProductForm.ShowDialog() == DialogResult.OK)
            {
                await LoadProductsAsync();
            }
        }


        private void homeForm_Load(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Логика фильтрации списка товаров
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Логика генерации и сохранения отчета
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
            loginForm.Show();
            this.Hide();
        }

        private async Task LoadProductsAsync()
        {
            var products = await _productService.GetAll();

            dgvProducts.Rows.Clear();

            foreach (var product in products)
            {
                dgvProducts.Rows.Add(
                    product.Id,
                    product.Title,
                    product.Code,
                    product.Article,
                    product.Price.ToString("F2"),
                    product.OldPrice.ToString("F2"),
                    product.Quantity.ToString(),
                    product.CategoryTitle
                );
            }
        }

        private async void btnCreateProduct_Click(object sender, EventArgs e)
        {
            var createProductForm = _serviceProvider.GetRequiredService<CreateProductForm>();
            if (createProductForm.ShowDialog() == DialogResult.OK)
            {
                await LoadProductsAsync();
            }
        }
    }

}
