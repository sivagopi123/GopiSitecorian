using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly2.Controllers
{
    [AllowAnonymous]
    public class RentalsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}