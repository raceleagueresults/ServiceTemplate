using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Infrastructure.Data.MainModule.Hypermedia;
using Infrastructure.Common.Mappings;
using Infrastructure.Common.Caching;
using Infrastructure.Common.Configuration;
using DistributedServices.Entities;
using Microsoft.Practices.Unity.InterceptionExtension;
using Infrastructure.Common.Logging;
using Application.Services.Templates;
using Infrastructure.Data.MainModule.Templates;
using Infrastructure.Data.MainModule.Mocks.Templates;
using Infrastructure.Common.Mappings.Templates;

namespace DistributedServices.Api.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //container.RegisterTypes(
            //   AllClasses.FromAssembliesInBasePath(),
            //   WithMappings.FromMatchingInterface,
            //   WithName.Default,
            //   WithLifetime.ContainerControlled);

            container.AddNewExtension<Interception>();

            container.RegisterType<IMapper<Domain.Entities.Template, DistributedServices.Entities.TemplateDto>, TemplateMapper>();
            container.RegisterType<ICache<TemplateDto>, MemoryCache<TemplateDto>>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptBehavior>());
            container.RegisterType<ICacheConfiguration, CacheConfiguration>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptBehavior>());
            container.RegisterType<ILoggingConfiguration, LoggingConfiguration>();
            container.RegisterType<IAuthorizationConfiguration, AuthorizationConfiguration>();
            container.RegisterType<IAppLogger, AppLogger>();
            container.RegisterType<ITemplateService, TemplateService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<LoggingInterceptBehavior>());
            container.RegisterType<ITemplateRepository, MockTemplateRepository>();
        }
    }
}
