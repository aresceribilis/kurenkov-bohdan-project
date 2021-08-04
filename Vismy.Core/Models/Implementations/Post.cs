using System.Collections.Generic;
using Vismy.Core.Models.Interfaces;
using Vismy.Core.Models.Joins;
using Vismy.Core.Models.Statuses;

#nullable disable

namespace Vismy.Core.Models.Implementations
{
    public partial class Post : IEntity
    {
        public Post()
        {
            PostTags = new HashSet<PostTag>();
            Reports = new HashSet<Report>();
            UserPosts = new HashSet<UserPost>();
        }

        public string Id { get; set; }
        public int Shared { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostStatusId { get; set; }
        public string UserId { get; set; }

        public virtual PostStatus PostStatus { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<UserPost> UserPosts { get; set; }
    }
}
