using Microsoft.AspNetCore.Identity;

namespace user_Identity.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string address { get; set; }
    }
}
