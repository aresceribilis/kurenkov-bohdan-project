using System;
using System.Text.RegularExpressions;
using Vismy.Models.Implementations;
using Vismy.Services.Interfaces;

namespace Vismy.Services.Implementations
{
    public class ValidatorUserService : IValidatorService<User>
    {
        public bool Validate(User obj)
        {
            var bioString = new Regex("^[\\w]{2,}$");
            //var birthDate = new Regex("");
            var email = new Regex("^([\\w\\.\\-]+)@([\\w\\-]+)(\\.(\\w{2,3})+)$");
            var integers = new Regex("^[\\d]$");
            var nickname = new Regex("^[\\w\\.\\-]{3,}$");
            var password = new Regex("^([\\w])|([\\d])$");
            var phone = new Regex("^[\\d]{10,15}$");
            //var photoUrl = new Regex("");

            return
                bioString.IsMatch(obj.Name) &&
                bioString.IsMatch(obj.Surname) &&
                email.IsMatch(obj.Email) &&
                integers.IsMatch(Convert.ToString(obj.Id)) &&
                nickname.IsMatch(obj.Nickname) &&
                phone.IsMatch(obj.PhoneNumber) &&
                password.IsMatch(obj.Password)
                ;
        }
    }
}