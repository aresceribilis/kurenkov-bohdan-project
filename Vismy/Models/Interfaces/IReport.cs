using System;
using System.Collections.Generic;
using Vismy.Models.Enums;

namespace Vismy.Models.Interfaces
{
    public interface IReport<T>
    {
        public int Id { get; init; }
        public string Description { get; set; }
        public DateTime PublishDate { get; }
        public T Entity { get; }
        public IPerson Author { get; }
        public Dictionary<IModerator, VerificationStatus> Moderators { get; }
    }
}