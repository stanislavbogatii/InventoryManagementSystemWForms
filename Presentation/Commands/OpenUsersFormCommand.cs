using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;

namespace Presentation.Commands
{
    public class OpenUsersFormCommand : ICommand
    {
        private readonly IServiceProvider _serviceProvider;

        public OpenUsersFormCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute()
        {
            var form = _serviceProvider.GetRequiredService<UserManagementForm>();
            form.Show();
        }
    }
}
