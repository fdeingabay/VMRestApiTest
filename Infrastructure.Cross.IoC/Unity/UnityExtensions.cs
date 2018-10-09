using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cross.IoC
{
    public static class UnityExtensions
    {
        public static IUnityContainer RegisterModule(this IUnityContainer container, IUnityConfigurationModule module)
        {
            if (module != null)
            {
                module.Configure(container);
            }
            return container;
        }

        public static IUnityContainer RegisterModule<T>(this IUnityContainer container) where T : class, IUnityConfigurationModule, new()
        {
            T module = new T();
            module.Configure(container);
            return container;
        }
    }
}
