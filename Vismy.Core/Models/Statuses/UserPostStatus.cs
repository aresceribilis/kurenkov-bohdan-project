using System.Collections.Generic;
using Vismy.Core.Models.Interfaces;
using Vismy.Core.Models.Joins;

#nullable disable

namespace Vismy.Core.Models.Statuses
{
    public partial class UserPostStatus : IEntity
    {
        public UserPostStatus()
        {
            UserPosts = new HashSet<UserPost>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserPost> UserPosts { get; set; }
    }
}
