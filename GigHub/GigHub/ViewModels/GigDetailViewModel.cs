using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigDetailViewModel
    {
        public ApplicationUser Artist { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Venue { get; set; }
        public bool IsUserAttending { get; set; }
        public bool IsUserFollowing { get; set; }
        public bool IsUserLoggedIn { get; set; }
    }
}