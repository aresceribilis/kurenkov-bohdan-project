using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // User's following
    public class UserFollowingDTO
    {
        public string Id { get; set; }

        public ICollection<UserPreviewDTO> Following { get; set; }
    }
}