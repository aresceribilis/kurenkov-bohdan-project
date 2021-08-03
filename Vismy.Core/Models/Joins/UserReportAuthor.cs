using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Interfaces;

#nullable disable

namespace Vismy.Core.Models.Joins
{
    public partial class UserReportAuthor : IEntity
    {
        public string UserId { get; set; }
        public int ReportId { get; set; }

        public virtual Report Report { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
