using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        public ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var followerId = dto.ArtistId;
            var currentFolloweeId = User.Identity.GetUserId();

            var following = _context.Followings.SingleOrDefault(f => f.FollowerId == dto.ArtistId && f.FolloweeId == currentFolloweeId);

            if (following != null)
            {
                if (following.IsActive)
                    return BadRequest("Already Following");
                else
                {
                    following.MakeActiveFollowing();
                    _context.SaveChanges();
                    return Ok();
                }
            }
                
            following = new Following
            {
                FolloweeId = currentFolloweeId,
                FollowerId = followerId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult UnFollow(FollowingDto dto)
        {
            var followerId = dto.ArtistId;
            var currentFolloweeId = User.Identity.GetUserId();

            var following = _context.Followings.SingleOrDefault(f => f.FollowerId == dto.ArtistId && f.FolloweeId == currentFolloweeId);

            if (following != null)
            {
                if (following.IsActive)
                {
                    following.MakeInActiveFollowing();
                    _context.SaveChanges();
                    return Ok(dto.ArtistId);
                }
            }

            return BadRequest("This given artist is not followed");

        }
    }
}
