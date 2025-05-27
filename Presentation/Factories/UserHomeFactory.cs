using Microsoft.Extensions.DependencyInjection;
using Presentation.Forms;

namespace Presentation.Factories
{
    public class UserFormFactory : FormFactoryBase
    {
        public UserFormFactory(IServiceProvider provider) : base(provider) { }

        public override Form CreateForm()
        {
            return _provider.GetRequiredService<HomeForm>();
        }
    }
}
