using System.ComponentModel.DataAnnotations;

namespace TravellerProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Please write your username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please write your password")]
        public string password { get; set; }
    }
}
