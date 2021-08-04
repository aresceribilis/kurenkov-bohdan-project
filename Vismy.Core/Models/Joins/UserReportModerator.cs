using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Statuses;

#nullable disable

namespace Vismy.Core.Models.Joins
{
    public partial class UserReportModerator
    {
        public string UserId { get; set; }
        public string ReportId { get; set; }
        public string UserReportModeratorStatusId { get; set; }

        public virtual Report Report { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual UserReportModeratorStatus UserReportModeratorStatus { get; set; }
    }
}
