using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.Repositories
{
    public interface IGigsRepository
    {
        void AddGig(Gig gig);
        Gig GetGig(int id);
        IEnumerable<Gig> GetGigsUserAttending(string currentUserId);
        Gig GetGigWithAttendees(int GigId);
        Gig GetGigWithAttendeesAndFollowees(int? Id);
        IEnumerable<Gig> GetGigWithGenre(string userId);
        IEnumerable<Gig> GetUpcomingGigsWithArtistAndGenre();
    }
}