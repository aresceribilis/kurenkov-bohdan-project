using System;
using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // Post's detail info
    public class PostInfoDTO
    {
        public string Id { get; set; }
        public int Shared { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Viewed { get; set; }
        public int Liked { get; set; }
        public string AuthorNickname { get; set; }
        public string Status { get; set; }

        public string AuthorId { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}