using System.Collections.Generic;
using Vismy.Models;
using Vismy.Models.Interfaces;

namespace Vismy
{
    public static class DatabaseMock
    {
        public static List<IReport<IPerson>> UsersReports { get; set; }
        public static List<IReport<Post>> PostsReports { get; set; }
        public static List<IPerson> Users { get; set; }
        public static List<Post> Posts{ get; set; }
    }
}