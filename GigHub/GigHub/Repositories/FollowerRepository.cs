using GigHub.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub.Repositories
{
    public class FollowerRepository : IFollowerRepository
    {
        public ApplicationDbContext _context { get; set; }

        public FollowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ApplicationUser> GetFollowerWithUserInfo(string currentUserId)
        {
            return _context.Followings
                                    .Where(f => f.FolloweeId == currentUserId)
                                    .Include(a => a.Follower)
                                    .Select(f => f.Follower)
                                    .ToList();
        }
    }
}