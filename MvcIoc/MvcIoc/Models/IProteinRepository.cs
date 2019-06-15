namespace MvcIoc.Models
{
    public interface IProteinRepository
    {
        int GetGoal();
        int GetTotal();
        void SetGoal(int gl);
        void SetTotal(int amt);
    }
}