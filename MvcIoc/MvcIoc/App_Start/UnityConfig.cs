using MvcIoc.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using Unity;
using Unity.Injection;
using Unity.RegistrationByConvention;

namespace MvcIoc
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            //container.RegisterType<IProteinTrackerService, ProteinTrackerService>();
            //container.RegisterType<IProteinRepository, ProteinRepository>();
            //container.RegisterType(AllClasses)
            var assemblylist = new List<Assembly>
            {
                typeof(Controllers.ProteinTrackerController).Assembly
            };

            container.RegisterTypes(
                AllClasses.FromAssemblies(assemblylist),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient);

            //container.RegisterType<IProteinRepository, ProteinRepository>(new InjectionConstructor("Default Datasource"));

            container.RegisterInstance(typeof(IProteinRepository), new ProteinRepository("Instance Datasource"));

            container.RegisterType<IProteinRepository, ProteinRepository>("StandardRepository",
                new InjectionConstructor("Default Datasource"));
            container.RegisterType<IProteinRepository, DebugProteinRepository>("DebugRepository");

            container.RegisterType<IProteinTrackerService, ProteinTrackerService>(
                new InjectionConstructor(container.Resolve<IProteinRepository>("DebugRepository")));

        }
    }
}