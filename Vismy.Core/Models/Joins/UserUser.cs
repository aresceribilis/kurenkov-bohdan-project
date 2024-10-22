﻿using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Interfaces;

#nullable disable

namespace Vismy.Core.Models.Joins
{
    public partial class UserUser : IEntity
    {
        public string UserId { get; set; }
        public string FollowerId { get; set; }

        public virtual AspNetUser Follower { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
