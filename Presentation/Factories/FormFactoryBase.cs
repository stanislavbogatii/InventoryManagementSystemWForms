using Presentation.Interfaces;

namespace Presentation.Factories
{
    public abstract class FormFactoryBase : IFormFactory
    {
        protected readonly IServiceProvider _provider;

        protected FormFactoryBase(IServiceProvider provider)
        {
            _provider = provider;
        }

        public abstract Form CreateForm();
    }

}
