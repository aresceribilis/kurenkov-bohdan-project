using System;
using System.Collections.Generic;

namespace Vismy
{
    enum VerificationStatus
    {
        Approved,
        Denied
    }

    class Report
    {
        public readonly string Description;
        public readonly DateTime PublishDate;
        public readonly object AccountOrPost;
        public readonly User Author;
        public readonly Dictionary<User, VerificationStatus> Moderators = new();

        Report(in string description, in object accountOrPost, in User author)
        {
            Description = description;
            AccountOrPost = accountOrPost;
            Author = author;
            PublishDate = DateTime.Today;
        }
    }
}