using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Following
    {
        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followee { get; set; }

        public bool IsActive { get; private set; }

        public void MakeActiveFollowing()
        {
            IsActive = true;
        }
        public void MakeInActiveFollowing()
        {
            IsActive = false;
        }
        public Following()
        {
            IsActive = true;
        }

    }
}