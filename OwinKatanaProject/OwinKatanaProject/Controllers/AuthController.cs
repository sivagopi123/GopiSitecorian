using OwinKatanaProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace OwinKatanaProject.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            var loginModel = new LoginModel();
            var providers = HttpContext
                                .GetOwinContext()
                                .Authentication
                                .GetAuthenticationTypes(x => !string.IsNullOrEmpty(x.Caption))
                                .ToList();

            loginModel.LoginProviders = providers;

            return View(loginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(model.UserName.Equals("chris", System.StringComparison.InvariantCultureIgnoreCase) && model.Password == "password")
            {
                var identity = new ClaimsIdentity("ApplicaitonCookie");
                identity.AddClaims(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, model.UserName),
                    new Claim(ClaimTypes.Name,model.UserName)
                });
                HttpContext.GetOwinContext().Authentication.SignIn(identity);
                return Redirect("/secret");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }

        public ActionResult SocialLogin(string id)
        {
            HttpContext
                .GetOwinContext()
                .Authentication
                .Challenge
                (new Microsoft.Owin.Security.AuthenticationProperties
                        {
                            RedirectUri = "/secret"
                        }
                , id
                );

            return new HttpUnauthorizedResult();
        }
    }
}