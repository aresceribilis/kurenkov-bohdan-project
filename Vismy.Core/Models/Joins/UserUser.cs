using Vismy.Core.Models.Implementations;

#nullable disable

namespace Vismy.Core.Models.Joins
{
    public partial class UserUser
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }

        public virtual AspNetUser Follower { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
