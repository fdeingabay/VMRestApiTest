using Microsoft.Practices.Unity;

namespace Infrastructure.Cross.IoC
{
    public partial interface IUnityConfigurationModule
    {
        void Configure(IUnityContainer contatiner);
    }
}
