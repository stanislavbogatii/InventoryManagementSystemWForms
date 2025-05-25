using Application.DTOs.Product;
using Application.DTOs.Warehouse;
using Application.Interfaces;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Presentation.Forms
{
    public partial class ViewWarehouseForm : Form
    {
        private readonly IWarehouseService _warehouseService;
        private readonly WarehouseDto? _warehouse;

        public ViewWarehouseForm(IWarehouseService warehouseService)
        {
            InitializeComponent();
            _warehouseService = warehouseService;
            this.AcceptButton = btnSave;
        }

        public ViewWarehouseForm(IWarehouseService warehouseService, WarehouseDto warehouse)
            : this(warehouseService)
        {
            _warehouse = warehouse;
            if (warehouse is not null)
            {
                PopulateForm(warehouse);
            }
        }

        public void PopulateForm(WarehouseDto warehouse)
        {
            txtWidth.Text = warehouse.Width.ToString();
            txtName.Text = warehouse.Name.ToString();
            txtLength.Text = warehouse.Length.ToString();
            txtCapacity.Text = warehouse.MaxLoadCapacity.ToString();
            txtHeight.Text = warehouse.Height.ToString();
            cmbStorageType.SelectedItem = warehouse.StorageType;
            cmbAccessLevel.SelectedItem = warehouse.AccessLevel;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                return;
            }
            try
            {
                var dto = new UpdateWarehouseDto
                {
                    Name = txtName.Text,
                    Width = double.TryParse(txtWidth.Text, out double width) ? width : 0,
                    Length = double.TryParse(txtLength.Text, out double length) ? length : 0,
                    Height = double.TryParse(txtHeight.Text, out double height) ? height : 0,
                    MaxLoadCapacity = double.TryParse(txtCapacity.Text, out double capacity) ? capacity : 0,
                    StorageType = cmbStorageType.SelectedItem?.ToString() ?? "",
                    AccessLevel = cmbAccessLevel.SelectedItem?.ToString() ?? ""
                };
                await _warehouseService.Update(_warehouse.Id, dto);
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Warehouse udpated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating warehouse: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLength.Text))
            {
                MessageBox.Show("Please enter length .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLength.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHeight.Text))
            {
                MessageBox.Show("Please enter height .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHeight.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtWidth.Text))
            {
                MessageBox.Show("Please enter width .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtWidth.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCapacity.Text))
            {
                MessageBox.Show("Please enter capacity .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapacity.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbAccessLevel.Text))
            {
                MessageBox.Show("Please enter access level .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAccessLevel.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbStorageType.Text))
            {
                MessageBox.Show("Please enter storage type .", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStorageType.Focus();
                return false;
            }
            return true;
        }
    }
}
