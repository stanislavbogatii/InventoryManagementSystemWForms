namespace Presentation.Forms
{
    public partial class WarehouseManagementForm : Form
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseManagementForm(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
            InitializeComponent();
        }

        private void btnCreateWarehouse_Click(object sender, EventArgs e)
        {
            //var createForm = new CreateWarehouseForm();
            //if (createForm.ShowDialog() == DialogResult.OK)
            //{
            //    LoadWarehouses();
            //}
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
