using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcIoc.Controllers;
using System.Web.Mvc;

namespace MvcIoc.Tests.Controllers
{
    [TestClass]
    public partial class ProteinTrackerControllerTest
    {

        [TestMethod]
        public void WhenNothingHasHappenedTotalAndGoalAreZero()
        {

            ProteinTrackerController controller = new ProteinTrackerController(new StubTrackingService());
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(0, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);
        }
         [TestMethod]
        public void WhenTotalIsNonZero_AmountAdded_TotalIncreased()
        {
            var service = new StubTrackingService();
            service.Total = 10;
            ProteinTrackerController controller = new ProteinTrackerController(service);
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(10, result.ViewBag.Total);
            Assert.AreEqual(0, result.ViewBag.Goal);
        }
    }
}
