using System.Collections.Generic;
using Vismy.Core.Models.Interfaces;
using Vismy.Core.Models.Joins;

#nullable disable

namespace Vismy.Core.Models.Statuses
{
    public partial class UserReportModeratorStatus : IEntity
    {
        public UserReportModeratorStatus()
        {
            UserReportModerators = new HashSet<UserReportModerator>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserReportModerator> UserReportModerators { get; set; }
    }
}
