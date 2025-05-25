using Microsoft.Extensions.DependencyInjection;
using Presentation.Interfaces;

namespace Presentation.Forms
{
    public class FormFactory : IFormFactory
    {
        private readonly IServiceProvider _provider;

        public FormFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Form CreateForm(string role)
        {
            return role switch
            {
                "Admin" => _provider.GetRequiredService<AdminHomeForm>(),
                "User" => _provider.GetRequiredService<HomeForm>(),
                _ => throw new Exception("Unknown role")
            };
        }
    }
}
