using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vismy.WEB.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Login is required.", AllowEmptyStrings = false),
        RegularExpression("^[a-zA-Z0-9а-яА-Я@\\.]{5,}$",
            ErrorMessage = "Login has to contain at least 5 characters (number, alphabet or @)")]
        public string Email { get; set; }
        [PasswordPropertyText,
         Required(ErrorMessage = "Password is required.", AllowEmptyStrings = false),
         DataType(DataType.Password),
         RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", 
             ErrorMessage = "Password has to contain from 8 to 20 characters, at least 1 alphabet, 1 number and 1 special character and avoid space")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}