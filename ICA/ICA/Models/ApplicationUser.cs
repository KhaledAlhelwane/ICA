using Microsoft.AspNetCore.Identity;

namespace ICA.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? SecoundName { get; set; }
        public string? ProfilePicture { get; set; }
     
    }
}
