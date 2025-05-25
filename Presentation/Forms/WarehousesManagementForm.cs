using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Forms
{
    public partial class WarehouseManagementForm : Form
    {
        private readonly IWarehouseService _warehouseService;
        private IServiceProvider _serviceProvider;
        public WarehouseManagementForm(IWarehouseService warehouseService, IServiceProvider serviceProvider)
        {
            _warehouseService = warehouseService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void btnCreateWarehouse_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateWarehouseForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadWarehouses();
            }
        }

        private async void LoadWarehouses()
        {
            var warehouses = await _warehouseService.GetAllAsync();
            dgvWarehouses.DataSource = warehouses;
        }

        private void WarehouseManagementForm_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
        }
    }
}
