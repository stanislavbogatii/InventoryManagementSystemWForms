using Application.Interfaces;

namespace Presentation.Forms;
public partial class LoginForm : Form
{
    private readonly IAuthService _authService;

    public LoginForm(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        var success = _authService.Login(txtUsername.Text, txtPassword.Text);
        if (success)
        {

            var home = new HomeForm(null);
            home.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Invalid login.");
        }
    }

    private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var registerForm = new RegisterForm(_authService);
        registerForm.Show();
    }

}

