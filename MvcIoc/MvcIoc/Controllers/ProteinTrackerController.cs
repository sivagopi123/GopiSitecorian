using MvcIoc.Models;
using System.Web.Mvc;

namespace MvcIoc.Controllers
{
    public class ProteinTrackerController : Controller
    {
        private IProteinTrackerService proteinTrackerService;

        public ProteinTrackerController(IProteinTrackerService _protienTrakerService)
        {
            proteinTrackerService = _protienTrakerService;
        }

        // GET: ProteinTracker
        public ActionResult Index()
        {
            ViewBag.Total = proteinTrackerService.Total;
            ViewBag.Goal = proteinTrackerService.Goal;
            return View();
        }
        [Route("ProteinTracker/AddProtein/{amount}")]
        public ActionResult AddProtein(int amount)
        {
            proteinTrackerService.AddProtein(amount);
            ViewBag.Total = proteinTrackerService.Total;
            ViewBag.Goal = proteinTrackerService.Goal;
            return View("Index");
        }
    }
}