using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Vismy.Core.Models.Interfaces;
using Vismy.Core.Models.Joins;
using Vismy.Core.Models.Statuses;

#nullable disable

namespace Vismy.Core.Models.Implementations
{
    public partial class AspNetUser : IdentityUser, IEntity
    {
        public AspNetUser()
        {
            Posts = new HashSet<Post>();
            UserPosts = new HashSet<UserPost>();
            UserReportAuthors = new HashSet<UserReportAuthor>();
            UserReportModerators = new HashSet<UserReportModerator>();
            UserUserFollowers = new HashSet<UserUser>();
            UserUserUsers = new HashSet<UserUser>();
        }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IconPath { get; set; }
        
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UserPost> UserPosts { get; set; }
        public virtual ICollection<UserReportAuthor> UserReportAuthors { get; set; }
        public virtual ICollection<UserReportModerator> UserReportModerators { get; set; }
        public virtual ICollection<UserUser> UserUserFollowers { get; set; }
        public virtual ICollection<UserUser> UserUserUsers { get; set; }
    }
}
