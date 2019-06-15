using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Repositories
{
    public class GigsRepository : IGigsRepository
    {
        public ApplicationDbContext _context { get; set; }

        public GigsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Gig> GetGigsUserAttending(string currentUserId)
        {
            return _context.Attendances
                        .Where(a => a.AttendeeId == currentUserId)
                        .Select(g => g.Gig)
                        .Include(a => a.Artist)
                        .Include(g => g.Genre)
                        .ToList();
        }
        public Gig GetGigWithAttendees(int GigId)
        {
            return _context.Gigs
                            .Include(g => g.Attendances.Select(a => a.Attendee))
                            .Single(g => g.Id == GigId);
        }
        public IEnumerable<Gig> GetGigWithGenre(string userId)
        {
            return _context.Gigs
                        .Where(g => g.ArtistId == userId
                                && g.DateTime > DateTime.Now)
                        .Include(g => g.Genre)
                        .ToList();
        }

        public Gig GetGig(int id)
        {
            return _context.Gigs.Single(g => g.Id == id);
        }

        public Gig GetGigWithAttendeesAndFollowees(int? Id)
        {
            return _context.Gigs
                        .Include(g => g.Attendances.Select(a => a.Attendee))
                        .Include(g => g.Artist.Followees.Select(f => f.Followee))
                        .Single(g => g.Id == Id);
        }

        public IEnumerable<Gig> GetUpcomingGigsWithArtistAndGenre()
        {
            return _context.Gigs
                        .Include(a => a.Artist)
                        .Include(g => g.Genre)
                        .Where(g => g.DateTime > DateTime.Now);
        }

        public void AddGig(Gig gig)
        {
            _context.Gigs.Add(gig);
        }
    }
}