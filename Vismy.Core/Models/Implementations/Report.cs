using System.Collections.Generic;
using Vismy.Core.Models.Joins;
using Vismy.Core.Models.Statuses;

#nullable disable

namespace Vismy.Core.Models.Implementations
{
    public partial class Report
    {
        public Report()
        {
            UserReportAuthors = new HashSet<UserReportAuthor>();
            UserReportModerators = new HashSet<UserReportModerator>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int PostId { get; set; }
        public int ReportStatusId { get; set; }

        public virtual Post Post { get; set; }
        public virtual ReportStatus ReportStatus { get; set; }
        public virtual ICollection<UserReportAuthor> UserReportAuthors { get; set; }
        public virtual ICollection<UserReportModerator> UserReportModerators { get; set; }
    }
}
