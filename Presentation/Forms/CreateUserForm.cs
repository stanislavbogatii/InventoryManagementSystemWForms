using Application.DTOs.User;
using Application.Interfaces;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Presentation.Forms
{
    public partial class CreateUserForm : Form
    {
        private readonly IUserService _userService;
        public CreateUserForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            this.AcceptButton = btnCreateUser;
        }

        private async void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (!validateForm()) return;
            try
            {
                CreateUserDto userDto = new()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Role = cmbRole.SelectedItem?.ToString() ?? "User"
                };

                await _userService.Create(userDto);

                MessageBox.Show("User saved successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        public bool validateForm()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
