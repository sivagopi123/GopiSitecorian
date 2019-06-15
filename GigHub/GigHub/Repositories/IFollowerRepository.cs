using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.Repositories
{
    public interface IFollowerRepository
    {
        IEnumerable<ApplicationUser> GetFollowerWithUserInfo(string currentUserId);
    }
}