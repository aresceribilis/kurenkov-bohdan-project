using System;

namespace Vismy.Application.DTOs
{
    // Post's preview
    public class PostPreviewDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserPostsCount { get; set; }
    }
}