using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vismy.WEB.Models
{
    public class PostCreateVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Title is required", AllowEmptyStrings = false), 
         RegularExpression("^[a-zA-Zа-яА-Я\\s]{5,30}$",
            ErrorMessage = "Title has to contain only letters and space")]
        public string Title { get; set; }
        [RegularExpression("^.{20,200}$",
            ErrorMessage = "Description has to contain from 20 to 200 characters")]
        public string Description { get; set; }
        [RegularExpression("^[a-zA-Zа-яА-Я0-9\\s]{1,60}$|^$",
            ErrorMessage = "Tags has to contain from 1 to 60 alphabetic or number characters")]
        public string Tags { get; set; }
    }
}