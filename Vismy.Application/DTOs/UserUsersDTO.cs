using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // User's followers or following
    public class UserUsersDTO
    {
        public int Id { get; set; }

        public ICollection<UserPreviewDTO> Users { get; set; }
    }
}