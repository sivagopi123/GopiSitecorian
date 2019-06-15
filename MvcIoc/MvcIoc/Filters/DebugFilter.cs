using MvcIoc.Models;
using System.Web.Mvc;

namespace MvcIoc.Filters
{
    public class DebugFilter : ActionFilterAttribute
    {
        private IDebugMessageService debugMessageService;

        public DebugFilter(IDebugMessageService debugMessageService)
        {
            this.debugMessageService = debugMessageService;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write(debugMessageService.Message); 
            base.OnActionExecuted(filterContext);
        }

    }
}