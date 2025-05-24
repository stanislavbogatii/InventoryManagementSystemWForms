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
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddTransient<LoginForm>();
        services.AddTransient<HomeForm>();
        services.AddTransient<RegisterForm>();
        services.AddTransient<ViewProductForm>();
        services.AddTransient<CreateProductForm>();

        var provider = services.BuildServiceProvider();


        var loginForm = provider.GetRequiredService<LoginForm>();
        System.Windows.Forms.Application.Run(loginForm);
    }

}
