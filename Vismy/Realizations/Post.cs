using System;
using System.Collections.Generic;

namespace Vismy
{
    enum RestrictionsStatus
    {
        None,
        Hidden,
        Freeze,
        Remove
    }

    class Post
    {
        public readonly User Author;
        public readonly DateTime PublishDate;
        public readonly Video Content;
        public int Likes { get; set; }
        public int Shared { get; set; }
        public string Description { get; set; }
        public HashSet<string> Tags { get; set; }
        public RestrictionsStatus Status { get; set; }

        public Post(in Video content, in User author, in string description, in HashSet<string> tags)
        {
            Author = author;
            PublishDate = DateTime.Today;
            Content = content;
            Description = description;
            Tags = tags;
            Likes = 0;
            Shared = 0;
            Status = RestrictionsStatus.None;
        }
    }
}