using Application.DTOs.Warehouse;
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

        private async void dgvWarehouses_CellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvWarehouses.Columns[e.ColumnIndex].Name == "deleteButtonColumn" && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvWarehouses.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this warehouse?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await _warehouseService.Delete(id);
                    dgvWarehouses.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private async void dgvWarehouses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvWarehouses.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnID"].Value);
            var warehouse = await _warehouseService.GetById(id);

            if (warehouse == null)
            {
                MessageBox.Show("Warehouse not found!");
                return;
            }

            var editProductForm = ActivatorUtilities.CreateInstance<ViewWarehouseForm>(_serviceProvider, warehouse);
            if (editProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadWarehouses();
            }
        }

        private async void btnCreateWarehouse_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateWarehouseForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadWarehouses();
            }
        }

        private async void LoadWarehouses()
        {
            var warehouses = await _warehouseService.GetAll();
            dgvWarehouses.Rows.Clear();

            foreach (var warehouse in warehouses)
            {
                dgvWarehouses.Rows.Add(
                    warehouse.Id,
                    warehouse.Name,
                    warehouse.Length.ToString(),
                    warehouse.Width.ToString(),
                    warehouse.Height.ToString(),
                    warehouse.MaxLoadCapacity.ToString(),
                    warehouse.StorageType.ToString(),
                    warehouse.AccessLevel.ToString()
                );
            }
        }

        private void WarehouseManagementForm_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
        }

        private async void btnCloneWarehouse_Click(object sender, EventArgs e)
        {
            if (dgvWarehouses.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvWarehouses.SelectedRows[0];

                var id = selectedRow.Cells[0].Value;
                if (id is not null)
                {
                    id = Convert.ToInt32(id);
                    var warehouse = await _warehouseService.GetById((int)id);
                    WarehouseDto warehouseClone = (WarehouseDto)warehouse.Clone();
                    if (warehouseClone is not null)
                    {
                        await _warehouseService.Create(new CreateWarehouseDto
                        {
                            Name = warehouseClone.Name + " (clone)",
                            Length = warehouseClone.Length,
                            Width = warehouseClone.Width,
                            AccessLevel = warehouseClone.AccessLevel,
                            StorageType = warehouseClone.StorageType,
                            Height = warehouseClone.Height,
                            HasSecuritySystem = warehouseClone.HasSecuritySystem,
                            MaxLoadCapacity = warehouseClone.MaxLoadCapacity,
                        });
                        LoadWarehouses();
                        MessageBox.Show("Warehouse cloned successfully.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }
    }
}
