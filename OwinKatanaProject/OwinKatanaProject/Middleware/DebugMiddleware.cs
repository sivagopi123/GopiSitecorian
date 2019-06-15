using Microsoft.Owin;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;


namespace OwinKatanaProject.Middleware
{
    public class DebugMiddleware
    {
        AppFunc _next;
        DebugMiddlewareOptions _options;
        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;

            if (_options.OnIncomingRequest == null)
                _options.OnIncomingRequest = (ctx) => { Debug.WriteLine($"Incoming Requests Reset: {ctx.Request.Path}"); };
            if (_options.OnOutgoingRequest == null)
                _options.OnOutgoingRequest = (ctx) => { Debug.WriteLine($"Outgoing Requests Reset: {ctx.Request.Path}"); };

        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);
            //Debug.WriteLine($"Incoming Request :{ctx.Request.Path}");
            _options.OnIncomingRequest(ctx);
            await _next(environment);
            //Debug.WriteLine($"Outgoing Request :{ctx.Request.Path}");
            _options.OnOutgoingRequest(ctx);
        }
    }
}