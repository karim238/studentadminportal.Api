using studentadminportal.Api.Models.Domain;

namespace studentadminportal.Api.Models.Dto
{
    public class ResponseStudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float GPA { get; set; }
        public string Faculty { get; set; }
        public string Year { get; set; }
        public List<ViewCourse> Courses { get; set; }

    }
}
