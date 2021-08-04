using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Interfaces;

#nullable disable

namespace Vismy.Core.Models.Joins
{
    public partial class PostTag : IEntity
    {
        public string PostId { get; set; }
        public string TagId { get; set; }

        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
