using Application.Interfaces;
using Infrastructure;
using Presentation.Factories;
using Presentation.Interfaces;


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
                Session.Instance.UserName = user.Username;
                Session.Instance.UserRole = user.Role;
                Session.Instance.Id = user.Id;
            }
            IFormFactory formFactory = FormFactorySelector.GetFormFactory(_serviceProvider, user.Role);
            Form form = formFactory.CreateForm();
            form.Show();
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

