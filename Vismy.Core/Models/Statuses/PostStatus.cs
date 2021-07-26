using System.Collections.Generic;
using Vismy.Core.Models.Implementations;

#nullable disable

namespace Vismy.Core.Models.Statuses
{
    public partial class PostStatus
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
