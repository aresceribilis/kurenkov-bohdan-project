using System;
using System.Collections.Generic;
using Vismy.Models.Enums;
using Vismy.Models.Interfaces;

namespace Vismy.Models.Implementations
{
    public class ReportUser : IReportUser
    {
        public int Id { get; init; }
        public string Description { get; set; }
        public DateTime PublishDate { get; }
        public IPerson Entity { get; }
        public IPerson Author { get; }
        public Dictionary<IModerator, VerificationStatus> Moderators { get; }
        public ReportUser(string description, IPerson entity, IPerson author)
        {
            Description = description;
            PublishDate = DateTime.Today;
            Entity = entity;
            Author = author;
            Moderators = new Dictionary<IModerator, VerificationStatus>();
        }
    }
}