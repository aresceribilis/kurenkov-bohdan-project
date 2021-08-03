namespace Vismy.WEB.Models
{
    public class RegisterVM
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public bool RememberMe { get; set; }
    }
}