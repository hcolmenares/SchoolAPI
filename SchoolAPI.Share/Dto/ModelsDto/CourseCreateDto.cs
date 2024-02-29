namespace SchoolAPI.Shared.Dto.ModelsDto
{
    public class CourseCreateDto
    {
        public string Name { get; set; }
        public string CourseNumber { get; set; }
        public string ProfessorId { get; set; }
        public string SchoolId { get; set; }
    }
}
