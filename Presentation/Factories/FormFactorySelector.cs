using Presentation.Interfaces;

namespace Presentation.Factories
{
    public static class FormFactorySelector
    {
        public static IFormFactory GetFormFactory(IServiceProvider serviceProvider, string role)
        {
            switch (role.ToLower())
            {
                case "admin":
                    return new AdminFormFactory(serviceProvider);
                case "user":
                    return new UserFormFactory(serviceProvider);
                default:
                    return new UserFormFactory(serviceProvider);

            }
        }
    }
}
