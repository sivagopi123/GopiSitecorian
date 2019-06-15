using System.Web.Http;

namespace OwinKatanaProject.Controllers
{
    [RoutePrefix("api")]
    public class HelloWorldApiController : ApiController
    {
        
        [Route("Hello")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello from Web Api");
        }
          
    }
}