using System;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class CreateWarehouseForm : Form
    {
        public CreateWarehouseForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string location = txtLocation.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(location))
            {
                MessageBox.Show("Please fill in all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
