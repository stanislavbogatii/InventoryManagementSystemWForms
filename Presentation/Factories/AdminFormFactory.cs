using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;

namespace Presentation.Factories
{
    public class AdminFormFactory : FormFactoryBase
    {
        public AdminFormFactory(IServiceProvider provider) : base(provider) { }

        public override Form CreateForm()
        {
            return _provider.GetRequiredService<AdminHomeForm>();
        }
    }
}
