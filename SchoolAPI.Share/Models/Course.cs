using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Shared.Models
{
    public class Course
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CourseNumber { get; set; }
        //public string ProfessorId { get; set; }
        //public string SchoolId { get; set; }
        //public School School { get; set; }
        //public Course Professor { get; set; }
        //public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
