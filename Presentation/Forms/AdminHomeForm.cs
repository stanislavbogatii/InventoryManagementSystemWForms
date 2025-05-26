using Application.Interfaces;
using Domain.Filters;
using Domain.Interfaces;
using Infrastructure;
using Presentation.Commands;

namespace Presentation.Forms
{
    public partial class AdminHomeForm : Form, IObserver
    {
        private readonly IProductService _productService;
        private IServiceProvider _serviceProvider;
        private readonly Dictionary<Button, ICommand> _commands = new();

        public AdminHomeForm(
            IProductService productService,
            IServiceProvider serviceProvider
        )
        {
            InitializeComponent();
            _productService = productService;
            _serviceProvider = serviceProvider;
            this.AcceptButton = btnFilter;
            _ = LoadProductsAsync();
            Update();
            _commands.Add(btnFilter, new FilterProductsCommand(this));
            _commands.Add(btnLogout, new LogoutCommand(this, _serviceProvider));
            _commands.Add(btnGenerateReport, new GenerateReportCommand(this, _productService));
            _commands.Add(btnCreateProduct, new OpenCreateProductFormCommand(this, _serviceProvider));
            _commands.Add(btnManageWarehoues, new OpenWarehouseFormCommand(_serviceProvider));
            _commands.Add(btnManageCategories, new OpenCategoriesFormCommand(_serviceProvider));
            _commands.Add(btnManageUsers, new OpenUsersFormCommand(_serviceProvider));

            Session.Instance.Attach(this);
        }

        public void Update()
        {
            lblCurrentUser.Text = $"Current user: {Session.Instance.UserName} (admin)";
        }

        private void btnFilter_Click(object sender, EventArgs e) => _commands[btnFilter].Execute();
        private void btnLogout_Click(object sender, EventArgs e) => _commands[btnLogout].Execute();
        private void btnGenerateReport_Click(object sender, EventArgs e) => _commands[btnGenerateReport].Execute();
        private void btnCreateProduct_Click(object sender, EventArgs e) => _commands[btnCreateProduct].Execute();
        private void btnManageWarehoues_Click(object sender, EventArgs e) => _commands[btnManageWarehoues].Execute();
        private void btnManageCategories_Click(object sender, EventArgs e) => _commands[btnManageCategories].Execute();
        private void btnManageUsers_Click(object sender, EventArgs e) => _commands[btnManageUsers].Execute();

        private void dgvProducts_CellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "deleteButtonColumn" && e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnID"].Value);
                new DeleteProductCommand(this, _productService, productId, e.RowIndex).Execute();
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int productId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnID"].Value);
                new ViewProductCommand(this, _serviceProvider, _productService, productId).Execute();
            }
        }

        public void FilterProducts()
        {
            int minPrice = string.IsNullOrEmpty(intMinPrice.Text) ? 0 : int.Parse(intMinPrice.Text);
            int maxPrice = string.IsNullOrEmpty(intMaxPrice.Text) ? int.MaxValue : int.Parse(intMaxPrice.Text);
            var title = string.IsNullOrEmpty(txtFilterName.Text) ? null : txtFilterName.Text;

            ProductFilters filters = new()
            {
                minPrice = minPrice,
                maxPrice = maxPrice,
                title = title
            };

            _ = LoadProductsAsync(filters);
        }
        public async Task LoadProductsAsync(ProductFilters? filters = null)
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
                    product.CategoryTitle,
                    product.WarehouseName
                );
            }
        }


    }

}
