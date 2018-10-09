using DataAccess;
using Domain;
using Microsoft.Practices.Unity;

namespace Infrastructure.Cross.IoC.Module
{
    public class RepositoryModule : IUnityConfigurationModule
    {
        public static void ConfigureModule(IUnityContainer container)
        {
            var sm = new RepositoryModule();
            sm.Configure(container);
        }

        public void Configure(IUnityContainer container)
        {
            container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}
