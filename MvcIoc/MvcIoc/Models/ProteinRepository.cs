namespace MvcIoc.Models
{
    public class ProteinRepository : IProteinRepository
    {
        private readonly string dataSource;

        public ProteinRepository(string dataSource)
        {
            this.dataSource = dataSource;
        }
        private static int Total { get; set; }
        private static int Goal { get; set; }
        public void SetTotal(int amt)
        {
            Total = amt;
        }

        public int GetTotal()
        {
            return Total;
        }

        public void SetGoal(int gl)
        {
            Goal = gl;
        }
        public int GetGoal()
        {
            return Goal;
        }
    }
}