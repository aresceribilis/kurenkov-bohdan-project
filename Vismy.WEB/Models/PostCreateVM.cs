using System;
using System.Collections.Generic;

namespace Vismy.WEB.Models
{
    public class PostCreateVM
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }
}