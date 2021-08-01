using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // User's followers
    public class UserFollowersDTO
    {
        public int Id { get; set; }

        public ICollection<UserPreviewDTO> Followers { get; set; }
    }
}