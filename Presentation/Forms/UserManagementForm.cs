using Application.Interfaces;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Forms
{
    public partial class UserManagementForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserService _userService;

        public UserManagementForm(IServiceProvider serviceProvider, IUserService userService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _userService = userService;
            Update();
            LoadUsers();
        }

        public void Update()
        {
            lblCurrentUser.Text = $"Logged in as: {Session.Instance.UserName} ({Session.Instance.UserRole})";
        }

        private async void btnCreateUser_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CreateUserForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }


        private async void dgvUsers_CellDeleteClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvUsers.Columns[e.ColumnIndex].Name == "deleteButtonColumn" && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await _userService.Delete(id);
                    dgvUsers.Rows.RemoveAt(e.RowIndex);
                }
            }
        }


        private async void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumnID"].Value);
            var user = await _userService.GetById(id);

            if (user == null)
            {
                MessageBox.Show("User not found!");
                return;
            }

            var editUserForm = ActivatorUtilities.CreateInstance<ViewUserForm>(_serviceProvider, user);
            if (editUserForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private async Task LoadUsers()
        {
            var users = await _userService.GetAll();
            dgvUsers.Rows.Clear();

            foreach (var user in users)
            {
                dgvUsers.Rows.Add(
                    user.Id,
                    user.Username,
                    user.Role
                );
            }

        }
    }
}
