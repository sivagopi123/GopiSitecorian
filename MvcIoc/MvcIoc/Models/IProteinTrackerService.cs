namespace MvcIoc.Models
{
    public interface IProteinTrackerService
    {
        int Goal { get; set; }
        int Total { get; set; }

        void AddProtein(int amt);
    }
}