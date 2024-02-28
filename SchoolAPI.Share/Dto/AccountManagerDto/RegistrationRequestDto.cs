using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Shared.Dto.AccountManagerDto
{
    public class RegistrationRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
