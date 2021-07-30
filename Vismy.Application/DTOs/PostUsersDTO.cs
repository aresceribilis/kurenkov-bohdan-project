using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // Post's users who viewed or liked
    public class PostUsersDTO
    {
        public int Id { get; set; }

        public ICollection<UserPreviewDTO> Users { get; set; }
    }
}