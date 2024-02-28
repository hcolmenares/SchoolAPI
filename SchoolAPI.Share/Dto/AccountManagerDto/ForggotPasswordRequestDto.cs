using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Shared.Dto.AccountManagerDto
{
    public class ForggotPasswordRequestDto
    {
        [Required]
        public string Email { get; set; }
    }
}
