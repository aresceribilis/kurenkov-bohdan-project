using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vismy.WEB.Models
{
    public class RegisterVM
    {
        [EmailAddress, 
         Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
        public string Email { get; set; }
        [PasswordPropertyText, 
         Required(ErrorMessage = "Password is required", AllowEmptyStrings = false),
         DataType(DataType.Password),
        RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$",
            ErrorMessage = "Password has to contain from 8 to 20 characters, at least 1 alphabet, 1 number and 1 special character and avoid space")]
        public string Password { get; set; }
        [PasswordPropertyText, 
         Required(ErrorMessage = "Password confirm is required", AllowEmptyStrings = false),
         DataType(DataType.Password),
         Compare("Password"),
         RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$",
             ErrorMessage = "Password confirm has to contain from 8 to 20 characters, at least 1 alphabet, 1 number and 1 special character and avoid space")]
        public string PasswordConfirm { get; set; }
        [RegularExpression("^[a-zA-Z0-9а-яА-Я]{5,20}$|^$",
            ErrorMessage = "Nickname has to contain from 5 to 20 alphabetic or number characters")]
        public string Nickname { get; set; }
        [RegularExpression("^[a-zA-Zа-яА-Я]{5,20}$|^$",
            ErrorMessage = "Name has to contain from 5 to 20 alphabetic characters")]
        public string Name { get; set; }
        [RegularExpression("^[a-zA-Zа-яА-Я]{5,20}$|^$",
            ErrorMessage = "Surname has to contain from 5 to 20 alphabetic characters")]
        public string Surname { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public bool RememberMe { get; set; }
    }
}