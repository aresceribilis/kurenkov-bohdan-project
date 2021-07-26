using Vismy.Core.Models.Implementations;

#nullable disable

namespace Vismy.Core.Models.Joins
{
    public partial class UserReportAuthor
    {
        public int UserId { get; set; }
        public int ReportId { get; set; }

        public virtual Report Report { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
