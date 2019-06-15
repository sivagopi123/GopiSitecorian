using MvcIoc.Models;

namespace MvcIoc.Tests.Controllers
{
    public partial class ProteinTrackerControllerTest
    {
        public class StubTrackingService : IProteinTrackerService
        {
            public int Total { get; set; }
            public int Goal { get; set; }

            public void AddProtein(int amount)
            {
                Total += amount;
            }
        }
    }
}
