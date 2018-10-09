using DataAccess;
using Microsoft.Practices.Unity;

namespace Infrastructure.Cross.IoC.Module
{
    public class CoreModule : IUnityConfigurationModule
    {
        public static void ConfigureModule(IUnityContainer container)
        {
            var cm = new CoreModule();
            cm.Configure(container);
        }

        public void Configure(IUnityContainer container)
        {
            container.RegisterType<IUserContext, UserContext>(new Microsoft.Practices.Unity.PerResolveLifetimeManager());
        }
    }
}
