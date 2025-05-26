using Domain.Interfaces;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;

public class LogoutCommand : ICommand
{
    private readonly Form _form;
    private readonly IServiceProvider _serviceProvider;

    public LogoutCommand(Form form, IServiceProvider serviceProvider)
    {
        _form = form;
        _serviceProvider = serviceProvider;
    }

    public void Execute()
    {
        Session.Instance.Clear();
        var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
        loginForm.Show();
        _form.Hide();
    }
}
