using Autofac;
using DoxFrame.Hub.Core.Interfaces;
using DoxFrame.Hub.Core.Services;

namespace DoxFrame.Hub.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FormsRepository>()
                .As<FormsRepository>().InstancePerLifetimeScope();
        }
    }
}
