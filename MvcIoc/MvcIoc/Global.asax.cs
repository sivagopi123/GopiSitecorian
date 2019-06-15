using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcIoc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityMvcActivator.Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var factory = new CustomControllerFactory();
            //ControllerBuilder.Current.SetControllerFactory(factory);


        }
    }
}
