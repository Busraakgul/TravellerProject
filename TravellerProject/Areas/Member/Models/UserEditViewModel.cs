using System.ComponentModel.DataAnnotations;

namespace TravellerProject.Areas.Member.Models
{
	public class UserEditViewModel
	{
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string phonenumber { get; set; }
        public string mail { get; set; }

		[StringLength(255)] // or [StringLength(int.MaxValue)]
		public string? imageurl { get; set; }
        public IFormFile Image { get; set; }
    }
}
