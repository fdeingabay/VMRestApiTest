using Infrastructure.Cross.IoC.Module;
using Microsoft.Practices.Unity;
using System;

namespace Infrastructure.Cross.IoC
{
    public class FactoryIoC
    {
        private static readonly FactoryIoC _container = new FactoryIoC();
        private readonly IUnityContainer _unityContainer;

        public static FactoryIoC Container { get { return _container; } }

        private FactoryIoC()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterModule<ServiceModule>();
            _unityContainer.RegisterModule<CoreModule>();
            _unityContainer.RegisterModule<RepositoryModule>();

            foreach (var registration in _unityContainer.Registrations)
            {
                try
                {
                    _unityContainer.Resolve(registration.RegisteredType, registration.Name);
                }
                catch (Exception ex)
                {
                    throw new Exception("IoC Exception" + registration?.Name, ex);
                }
            }
        }

        public TService Resolve<TService>() where TService : class
        {
            return _unityContainer.Resolve<TService>();
        }

        public TService Resolve<TService>(string name) where TService : class
        {
            return _unityContainer.Resolve<TService>(name);
        }

        public object Resolve(System.Type type)
        {
            return _unityContainer.Resolve(type);
        }
    }
}
