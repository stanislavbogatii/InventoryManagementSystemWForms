using Application.DTOs;
using Application.Interfaces;

namespace Presentation.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly IAuthService _authService;

        public RegisterForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                _authService.Register(new UserRegisterDto
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                });

                MessageBox.Show("Registration successful!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
