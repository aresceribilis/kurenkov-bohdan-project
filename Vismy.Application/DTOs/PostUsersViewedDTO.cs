using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // Post's users who viewed
    public class PostUsersViewedDTO
    {
        public int Id { get; set; }

        public ICollection<UserPreviewDTO> Viewers { get; set; }
    }
}