using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ICA.ViewModel
{
	public class CreatUserViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string ? Email { get; set; }

		[Required]
		public string? FirstName { get; set; }
		[Required]
		public string? SecoundName { get; set; }


		public IEnumerable<IdentityRole>? ListaOfRoles { get; set; }
		[Required]
		public string? TheRole { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string ?Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ?ConfirmPassword { get; set; }
		

	}
}
