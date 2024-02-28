namespace SchoolAPI.Shared.Dto.AccountManagerDto
{
    public class ResetPasswordRequestDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
