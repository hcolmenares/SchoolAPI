using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Shared.Models
{
    public class Professor
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Charge { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        //public string SchoolId { get; set; }
        //public School School { get; set; }
        //public ICollection<Course> Courses { get; set; }
    }
}
