using System.ComponentModel.DataAnnotations;

namespace TravellerProject.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Write your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Write your surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Write your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Write your mail")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Write your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Write your password again")]
        [Compare("Password", ErrorMessage ="Password is not compatible!")]
        public string ConfirmPassword { get; set; } 
    }
}
