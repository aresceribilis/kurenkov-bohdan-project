using System.Collections.Generic;
using Vismy.Core.Models.Implementations;

#nullable disable

namespace Vismy.Core.Models.Statuses
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
