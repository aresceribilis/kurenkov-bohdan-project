using System;

#nullable disable

namespace Vismy.Core.Models.Implementations
{
    public partial class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Length { get; set; }
        public string Path { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
