using Microsoft.Practices.Unity;
using Services.Cotizacion;
using Services.User;

namespace Infrastructure.Cross.IoC.Module
{
    public class ServiceModule : IUnityConfigurationModule
    {
        public static void ConfigureModule(IUnityContainer container)
        {
            var sm = new ServiceModule();
            sm.Configure(container);
        }

        public void Configure(IUnityContainer container)
        {
            container.RegisterType<ICotizacionService, CotizacionService>();
            container.RegisterType<IUserService, UserService>();
        }
    }
}
