using System.Collections.Generic;
using Vismy.Core.Models.Joins;

#nullable disable

namespace Vismy.Core.Models.Implementations
{
    public partial class Tag
    {
        public Tag()
        {
            PostTags = new HashSet<PostTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
