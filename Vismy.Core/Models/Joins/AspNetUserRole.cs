using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Statuses;

#nullable disable

namespace Vismy.Core.Models.Joins
{
    public partial class AspNetUserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual AspNetRole Role { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
