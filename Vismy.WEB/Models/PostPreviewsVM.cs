using System.Collections.Generic;
using Vismy.Application.DTOs;

namespace Vismy.WEB.Models
{
    public class PostPreviewsVM
    {
        public IEnumerable<PostPreviewDTO> Posts { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}