using System;
using System.Collections.Generic;
using Vismy.Models.Enums;
using Vismy.Models.Interfaces;

namespace Vismy.Models.Implementations
{
    [Serializable]
    public class User : IUser
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
        public PersonRole Role { get; set; }
        [NonSerialized] 
        public readonly IEnumerable<IPerson> Followers = new List<IPerson>();
        [NonSerialized] 
        public readonly IEnumerable<IPerson> Following = new List<IPerson>();

        public override string ToString()
        {
            return $"Id: {Id,3}, Nickname: {Nickname,12}, Role: {GetType().Name,10}";
        }
    }
}