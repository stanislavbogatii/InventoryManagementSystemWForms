using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Factories;
using Presentation.Forms;
using Presentation.Interfaces;


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
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<UserService>();
        services.AddScoped<IUserService>(sp =>
        {
            var inner = sp.GetRequiredService<UserService>();
            return new UserServiceProxy(inner);
        });
        services.AddScoped<ProductService>();

        services.AddScoped<IProductService>(sp =>
        {
            var inner = sp.GetRequiredService<ProductService>();
            return new ProductServiceDecorator(inner, "product_service_log.txt");
        });
        services.AddScoped<IWarehouseService, WarehouseService>();

        //services.AddScoped<IFormFactory, FormFactoryBase>();

        //auth
        services.AddTransient<LoginForm>();
        services.AddTransient<RegisterForm>();

        //product
        services.AddTransient<HomeForm>();
        services.AddTransient<AdminHomeForm>();
        services.AddTransient<ViewProductForm>();
        services.AddTransient<CreateProductForm>();

        //warehouse
        services.AddTransient<WarehouseManagementForm>();
        services.AddTransient<CreateWarehouseForm>();
        services.AddTransient<ViewWarehouseForm>();

        //user
        services.AddTransient<UserManagementForm>();
        services.AddTransient<CreateUserForm>();
        services.AddTransient<ViewUserForm>();
        
        //category
        services.AddTransient<CategoriesManagementForm>();
        services.AddTransient<CreateCategoryForm>();
        services.AddTransient<ViewCategoryForm>();

        var provider = services.BuildServiceProvider();


        var loginForm = provider.GetRequiredService<LoginForm>();
        System.Windows.Forms.Application.Run(loginForm);
    }

}
