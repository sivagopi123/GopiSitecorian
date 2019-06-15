namespace MvcIoc.Models
{
    public class ProteinTrackerService : IProteinTrackerService
    {

        private IProteinRepository repo;

        public ProteinTrackerService(IProteinRepository _repo)
        {
            repo = _repo;
        }
        public int Total { get { return repo.GetTotal(); } set { repo.SetTotal(value); } }
        public int Goal { get { return repo.GetGoal(); } set { repo.SetGoal(value); } }
        public void AddProtein(int amt)
        {
            Total += amt;
        }
    }
}