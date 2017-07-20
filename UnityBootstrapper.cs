using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVCTraining.App_Start.UnityBootstrapper), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(MVCTraining.App_Start.UnityBootstrapper), "Shutdown")]

namespace MVCTraining.App_Start
{
    public static class UnityBootstrapper
    {
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}