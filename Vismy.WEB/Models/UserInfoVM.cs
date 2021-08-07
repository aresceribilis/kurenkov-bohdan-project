using System;
using Vismy.Application.DTOs;

namespace Vismy.WEB.Models
{
    public class UserInfoVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IconPath { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string RoleName { get; set; }
    }
}