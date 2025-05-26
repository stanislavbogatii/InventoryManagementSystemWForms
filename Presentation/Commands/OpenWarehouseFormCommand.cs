using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;

namespace Presentation.Commands
{
    public class OpenWarehouseFormCommand : ICommand
    {
        private readonly IServiceProvider _serviceProvider;

        public OpenWarehouseFormCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute()
        {
            var form = _serviceProvider.GetRequiredService<WarehouseManagementForm>();
            form.Show();
        }
    }
}
