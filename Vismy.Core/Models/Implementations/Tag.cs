﻿using System.Collections.Generic;
using Vismy.Core.Models.Interfaces;
using Vismy.Core.Models.Joins;

#nullable disable

namespace Vismy.Core.Models.Implementations
{
    public partial class Tag : IEntity
    {
        public Tag()
        {
            PostTags = new HashSet<PostTag>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
