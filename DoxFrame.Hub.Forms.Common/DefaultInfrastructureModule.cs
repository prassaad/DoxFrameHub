using Autofac;
using DoxFrame.Hub.Core.Interfaces;
using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.Infrastructure.Data;
using DoxFrame.Hub.SharedKernel.Interfaces;
using DoxFrameHub.Infrastructure;
using DoxFrameHub.SharedKernel.Interfaces;
using MediatR;
using MediatR.Pipeline;
using System.Collections.Generic;
using System.Reflection;
using Module = Autofac.Module;

namespace DoxFrame.Hub.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly bool _isDevelopment = false;
        private readonly List<Assembly> _assemblies = new List<Assembly>();

        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly = Assembly.GetAssembly(typeof(Project)); // TODO: Replace "Project" with any type from your Core project
            var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
            _assemblies.Add(coreAssembly);
            _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }
            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .As(typeof(IReadRepository<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                .RegisterAssemblyTypes(_assemblies.ToArray())
                .AsClosedTypesOf(mediatrOpenType)
                .AsImplementedInterfaces();
            }

            builder.RegisterType<EmailSender>().As<IEmailSender>()
                .InstancePerLifetimeScope();
            
            // Work flow Engine
            builder.RegisterType<CamundaWorkFlowEngine>().As<ICamundaClient>()
               .InstancePerLifetimeScope();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add development only services
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
            // TODO: Add production only services
        }

    }
}
