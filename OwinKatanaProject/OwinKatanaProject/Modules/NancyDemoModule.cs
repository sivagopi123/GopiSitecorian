using Nancy;
using Nancy.Owin;
using Nancy.Security;

namespace OwinKatanaProject.Modules
{
    public class NancyDemoModule : NancyModule
    {
        public NancyDemoModule()
        {
            this.RequiresMSOwinAuthentication();

            Get["/nancy"] = x =>
            {
                var environment = Context.GetOwinEnvironment();
                var user = Context.GetMSOwinUser();
                return $"Hello from Nancy! " +
                $"You Requested: {environment["owin.RequestPathBase"]} " +
                $"{environment["owin.RequestPath"]}" +
                $"\n\nUser:\t{user.Identity.Name}";
            };

        }
    }
}