namespace MvcIoc.Models
{
    public class DebugProteinRepository : IProteinRepository
    {
        private static int Total { get; set; }
        private static int Goal { get; set; }
        public void SetTotal(int amt)
        {

        }

        public int GetTotal()
        {
            return Total;
        }

        public void SetGoal(int gl)
        {
        }
        public int GetGoal()
        {
            return Goal;
        }
    }
}