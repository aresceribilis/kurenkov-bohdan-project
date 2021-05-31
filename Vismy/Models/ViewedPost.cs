using Vismy.Models.Enums;
using Vismy.Models.Interfaces;

namespace Vismy.Models
{
    public class UserPost
    {
        public IPerson Viewer { get; }
        public LikeStatus Status { get; set; }

        private UserPost(IPerson viewer, LikeStatus status = LikeStatus.Viewed)
        {
            Viewer = viewer;
            Status = status;
        }
    }
}