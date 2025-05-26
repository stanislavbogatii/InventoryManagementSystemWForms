using Application.Interfaces;
using Infrastructure;
using Presentation.Interfaces;


namespace Presentation.Forms;
public partial class LoginForm : Form
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly IFormFactory _formFactory;

    public LoginForm(
        IAuthService authService,
        IUserService userService,
        IProductService productService,
        IFormFactory formFactory
    )
    {
        InitializeComponent();
        _authService = authService;
        _userService = userService;
        _formFactory = formFactory;

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
            Form form = _formFactory.CreateForm(user.Role ?? "User");
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

