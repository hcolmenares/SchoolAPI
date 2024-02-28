using Microsoft.AspNetCore.Identity;

namespace SchoolAPI.Shared.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
    }
}
