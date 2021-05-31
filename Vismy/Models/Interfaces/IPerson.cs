using System;
using System.Collections.Generic;
using Vismy.Models.Enums;

namespace Vismy.Models.Interfaces
{
    public interface IPerson
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        //public PersonRole Role { get; set; }
        public IEnumerable<IPerson> Followers { get; init; }
        public IEnumerable<IPerson> Following { get; init; }

        public string ToString()
        {
            return $"Id: {Id}, Nickname: {Nickname}, Role: {GetType().Name}";
        }
    }
}