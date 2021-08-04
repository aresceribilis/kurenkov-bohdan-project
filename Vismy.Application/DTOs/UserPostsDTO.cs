using System;
using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // User's posts
    public class UserPostsDTO
    {
        public string Id { get; set; }

        public ICollection<PostPreviewDTO> Posts { get; set; }
    }
}