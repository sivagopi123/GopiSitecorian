using Nancy.Owin;
using Owin;
using OwinKatanaProject.Middleware;
using System.Diagnostics;
using System.Web.Http;

namespace OwinKatanaProject
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            //app.Use<DebugMiddleware>();
            app.UseDebugMiddleware(new DebugMiddlewareOptions
            {
                OnIncomingRequest = (ctx) =>
                {
                    var watch = new Stopwatch();
                    watch.Start();
                    ctx.Environment["DebugStopwatch"] = watch;
                },
                OnOutgoingRequest = (ctx) =>
                {
                    var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
                    watch.Stop();
                    Debug.WriteLine($"Request took: {watch.ElapsedMilliseconds}");
                }

            });
            //app.Use<DebugMiddleware>(new DebugMiddlewareOptions
            //{
            //    OnIncomingRequest = (ctx) =>
            //    {
            //        var watch = new Stopwatch();
            //        watch.Start();
            //        ctx.Environment["DebugStopwatch"] = watch;
            //    },
            //    OnOutgoingRequest = (ctx) => {
            //        var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
            //        watch.Stop();
            //        Debug.WriteLine($"Request took: {watch.ElapsedMilliseconds}");
            //    }

            //});
            //app.Use(async (ctx, next) => {
            //    Debug.WriteLine($"Incoming Request :{ctx.Request.Path}");
            //    await next();
            //    Debug.WriteLine($"Outgoing Request :{ctx.Request.Path}");
            //});
            //app.Map("/nancy", mappedApp => { mappedApp.UseNancy(); });

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicaitonCookie",
                LoginPath = new Microsoft.Owin.PathString("/Auth/Login")
            });

            app.UseFacebookAuthentication(new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions
            {
                AppId = "979980915517227",
                AppSecret = "0d9a048db49c47e9e2c9f126a84247aa",
                SignInAsAuthenticationType = "ApplicationCookie",
                BackchannelCertificateValidator = null
            });

            //app.UseTwitterAuthentication(new Microsoft.Owin.Security.Twitter.TwitterAuthenticationOptions
            //{
            //    ConsumerKey = "",
            //    ConsumerSecret = "",
            //    AuthenticationType = "ApplicationCookie",
            //    BackchannelCertificateValidator = null
            //});

            app.Use(async (ctx, next) =>
            {
                if (ctx.Authentication.User.Identity.IsAuthenticated)
                    Debug.WriteLine($"User: {ctx.Authentication.User.Identity.Name}");
                else
                    Debug.WriteLine("User Not Authenticated");
                await next();
            });

            var configApi = new HttpConfiguration();
            configApi.MapHttpAttributeRoutes();
            app.UseWebApi(configApi);
            app.Map("/nancy", mappedApp => { mappedApp.UseNancy(); });
            //app.UseNancy(config => {
            //    config.PassThroughWhenStatusCodesAre(HttpStatusCode.NotFound);
            //});

            //app.Use(async (ctx, next) =>
            //{
            //    await ctx.Response.WriteAsync("Hello World");
            //});
        }
    }
}