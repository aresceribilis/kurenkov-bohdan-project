using System;
using System.ComponentModel.DataAnnotations;
using Vismy.Application.DTOs;

namespace Vismy.WEB.Models
{
    public class UserInfoVM
    {
        public string Id { get; set; }
        [RegularExpression("^[a-zA-Zа-яА-Я]{5,20}$",
            ErrorMessage = "Name has to contain from 5 to 20 alphabetic characters")]
        public string Name { get; set; }
        [RegularExpression("^[a-zA-Zа-яА-Я]{5,20}$",
            ErrorMessage = "Surname has to contain from 5 to 20 alphabetic characters")]
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IconPath { get; set; }
        [Required(ErrorMessage = ("Nickname is required"), AllowEmptyStrings = false),
         RegularExpression("^[a-zA-Z0-9а-яА-Я]{5,20}$",
             ErrorMessage = "Nickname has to contain from 5 to 20 alphabetic or number characters")]
        public string Nickname { get; set; }
        [EmailAddress,
         Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string RoleName { get; set; }
    }
}