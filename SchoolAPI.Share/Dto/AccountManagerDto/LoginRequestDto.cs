using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Shared.Dto.AccountManagerDto
{
    public class LoginRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
