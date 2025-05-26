using Application.DTOs.User;
using Application.Interfaces;
using Domain.Entitites;

namespace Presentation.Forms
{
    public partial class ViewUserForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserService _userService;
        private readonly UserDto _user;
        public ViewUserForm(IServiceProvider serviceProvider, IUserService userService)
        {
            InitializeComponent();
            this.AcceptButton = btnSaveUser;
            _serviceProvider = serviceProvider;
            _userService = userService;
        }

        public ViewUserForm(IServiceProvider serviceProvider, IUserService userService, UserDto user)
            :this(serviceProvider, userService)
        {
            _user = user;
            if (user is not null)
            {
                PopulateUser(user);
            }
            this.AcceptButton = btnSaveUser;
        }

        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (!validateForm()) return;
            try
            {
                UpdateUserDto user = new()
                {
                    Role = cmbRole.SelectedItem?.ToString() ?? "User",
                    Password = txtPassword.Text,
                };
                await _userService.Update(_user.Id, user);
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

        private void PopulateUser(UserDto user)
        {
            if (user is null) return;
            txtUsername.Text = user.Username;
            txtUsername.IsAccessible = false;
            for (int i = 0; i < cmbRole.Items.Count; i++)
            {
                if (string.Equals(cmbRole.Items[i].ToString(), user.Role, StringComparison.OrdinalIgnoreCase))
                {
                    cmbRole.SelectedIndex = i;
                    return;
                }
            }

            cmbRole.SelectedIndex = 0;
        }

        public bool validateForm()
        {
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
