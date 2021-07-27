using System.Collections.Generic;
using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Interfaces;

#nullable disable

namespace Vismy.Core.Models.Statuses
{
    public partial class PostStatus : IEntity
    {
        public PostStatus()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
