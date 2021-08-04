using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // Post's users who liked
    public class PostUsersLikedDTO
    {
        public string Id { get; set; }

        public ICollection<UserPreviewDTO> Likers { get; set; }
    }
}