using Application.DTOs.Product;
using Application.Interfaces;
using Application.Builders;
using Application.Directors;
using Domain.Filters;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class AdminHomeForm : Form
    {
        private readonly IProductService _productService;
        private IServiceProvider _serviceProvider;

        public AdminHomeForm(
            IProductService productService,
            IServiceProvider serviceProvider
        )
        {
            InitializeComponent();
            _productService = productService;
            _serviceProvider = serviceProvider;

            lblCurrentUser.Text = $"Current user: {Session.Instance.UserName} (admin)";

            this.AcceptButton = btnFilter;

            _ = LoadProductsAsync();
        }

        private async void dgvProducts_CellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "deleteButtonColumn" && e.RowIndex >= 0)
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
            int minPrice = string.IsNullOrEmpty(intMinPrice.Text) ? 0 : int.Parse(intMinPrice.Text);
            int maxPrice = string.IsNullOrEmpty(intMaxPrice.Text) ? int.MaxValue : int.Parse(intMaxPrice.Text);
            var title = string.IsNullOrEmpty(txtFilterName.Text) ? null : txtFilterName.Text;
            ProductFilters filters = new()
            {
                minPrice = minPrice,
                maxPrice = maxPrice,
                title = title,
            };

            LoadProductsAsync(filters);
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var products = await _productService.GetAll();
            IExcelReportBuilder builder;
            string selected = comboBoxReportType.SelectedItem?.ToString();


            if (products is not null)
            {
                if (selected == "Detailed report")
                {
                    builder = new DetailedExcelReportBuilder((List<ProductDto>)products);
                }
                else
                {
                    builder = new ShortExcelReportBuilder((List<ProductDto>)products);
                }
            }
            else
            {
                MessageBox.Show("Please select report type");
                return;
            }
            var director = new ExcelReportDirector((IExcelReportBuilder)builder);
            director.ConstructReport();

            var workbook = builder.GetReport();

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.Title = "Save excel report";
                saveFileDialog.FileName = $"report_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Report success saved!");
                }
            }


        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Instance.Clear();
            var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
            loginForm.Show();
            this.Hide();
        }

        private async Task LoadProductsAsync(ProductFilters? filters = null)
        {
            var products = await _productService.GetAll(filters);

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

        private void btnManageWarehoues_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<WarehouseManagementForm>();
            form.Show();
        }
    }

}
