using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // User's following
    public class UserFollowingDTO
    {
        public int Id { get; set; }

        public ICollection<UserPreviewDTO> Following { get; set; }
    }
}