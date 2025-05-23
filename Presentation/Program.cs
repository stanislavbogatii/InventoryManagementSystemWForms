using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;


namespace Presentation;
static class Program
{
    [STAThread]
    static void Main()
    {
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

        var services = new ServiceCollection();
        services.AddDbContext<AppDbContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthService, AuthService>();
        var provider = services.BuildServiceProvider();

        System.Windows.Forms.Application.Run(new LoginForm(provider.GetRequiredService<IAuthService>()));
    }
}
