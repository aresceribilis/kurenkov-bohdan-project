using System;
using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // Post's detail info
    public class PostInfoDTO
    {
        public int Id { get; set; }
        public int Shared { get; set; }
        public int Viewed { get; set; }
        public int Liked { get; set; }
        public string Description { get; set; }

        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public int AuthorId { get; set; }
        public string AuthorNickname { get; set; }
        public string VideoTitle { get; set; }
        public TimeSpan VideoLength { get; set; }
        public string VideoPath { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}