using MvcIoc.Filters;
using System.Web.Mvc;

namespace MvcIoc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(DependencyResolver.Current.GetService<DebugFilter>());
        }
    }
}
