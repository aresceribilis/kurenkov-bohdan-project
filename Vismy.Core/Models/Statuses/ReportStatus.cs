﻿using System.Collections.Generic;
using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Interfaces;

#nullable disable

namespace Vismy.Core.Models.Statuses
{
    public partial class ReportStatus : IEntity
    {
        public ReportStatus()
        {
            Reports = new HashSet<Report>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
