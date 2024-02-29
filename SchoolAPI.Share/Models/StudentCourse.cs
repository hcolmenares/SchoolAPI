using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Shared.Models
{
    public class StudentCourse
    {
        [Key]
        public string Id { get; set; }
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
