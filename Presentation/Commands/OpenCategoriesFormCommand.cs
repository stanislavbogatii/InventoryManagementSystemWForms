using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;

namespace Presentation.Commands
{
    public class OpenCategoriesFormCommand : ICommand
    {
        private readonly IServiceProvider _serviceProvider;

        public OpenCategoriesFormCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute()
        {
            var form = _serviceProvider.GetRequiredService<CategoriesManagementForm>();
            form.Show();
        }
    }
}
