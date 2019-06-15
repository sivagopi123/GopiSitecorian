using MvcIoc.Controllers;
using MvcIoc.Models;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MvcIoc.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower().StartsWith("proteintracker"))
            {
                var repo = new ProteinRepository();
                var service = new ProteinTrackerService(repo);
                var controller = new ProteinTrackerController(service);

                return controller;

            }
            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var controllerDispose = controller as IDisposable;
            if (controllerDispose != null)
                controllerDispose.Dispose();
        }
    }
}