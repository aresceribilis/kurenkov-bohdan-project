using System.Collections.Generic;
using Vismy.Application.DTOs;

namespace Vismy.WEB.Models
{
    public class UserPreviewsVM
    {
        public IEnumerable<UserPreviewDTO> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}