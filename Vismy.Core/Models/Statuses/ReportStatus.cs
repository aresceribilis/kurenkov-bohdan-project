using System.Collections.Generic;
using Vismy.Core.Models.Implementations;

#nullable disable

namespace Vismy.Core.Models.Statuses
{
    public partial class ReportStatus
    {
        public ReportStatus()
        {
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
