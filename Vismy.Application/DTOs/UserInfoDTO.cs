using System;
using System.Collections.Generic;

namespace Vismy.Application.DTOs
{
    // User's detail info
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string IconPath { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }

        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }
}