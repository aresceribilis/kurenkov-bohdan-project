using System;
using System.Collections.Generic;
using Vismy.Models.Enums;
using Vismy.Models.Interfaces;

namespace Vismy.Models
{
    public class Post
    {
        public int Id { get; init; }
        public IPerson Author { get; }
        public DateTime PublishDate { get; }
        public Video Content { get; }
        public IEnumerable<IPerson> UsersLikes { get; }
        public int Shared { get; set; }
        public string Description { get; set; }
        public HashSet<string> Tags { get; set; }
        public RestrictionsStatus Status { get; set; }

        public Post(
            byte[] content,
            IPerson author,
            HashSet<string> tags,
            string videoTitle,
            string description)
        {
            Author = author;
            PublishDate = DateTime.Today;
            Content = new Video(videoTitle, TimeSpan.Zero,
                $"{Author.Nickname}\\{DateTime.Today.Date}\\{videoTitle}.mp4");
            // FileWrite(content, $"{Author.Nickname}\\{DateTime.Today.Date}\\{videoTitle}.mp4");
            Description = description;
            Tags = tags;
            UsersLikes = new List<IPerson>();
            Shared = 0;
            Status = RestrictionsStatus.None;
        }
    }
}