namespace SchoolAPI.Shared.Dto.ModelsDto
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public string CardId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string EPS { get; set; }
        public string SecurityNumber { get; set; }
        public string Tutor { get; set; }
        //public string SchoolId { get; set; }
    }
}
