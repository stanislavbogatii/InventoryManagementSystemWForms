using Application.Interfaces;
using Domain.Entitites;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;


namespace Presentation.Forms;
public partial class LoginForm : Form
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IServiceProvider _serviceProvider;

    public LoginForm(
        IAuthService authService, 
        IUserService userService,
        IProductService productService,
        IServiceProvider serviceProvider
    )
    {
        InitializeComponent();
        _authService = authService;
        _userService = userService;
        _serviceProvider = serviceProvider;

        this.AcceptButton = btnLogin;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        var success = await _authService.Login(txtUsername.Text, txtPassword.Text);
        if (success)
        {
            var user = await _userService.GetByUsername(txtUsername.Text);

            if (user != null)
            {
                Session.CurrentUser = new User
                {
                    Username = user.Username ?? "",
                    Id = user.Id,
                    Role = user.Role ?? "User"
                };
            }
            var home = _serviceProvider.GetRequiredService<HomeForm>();
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

