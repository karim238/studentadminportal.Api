using studentadminportal.Api.Models.Domain;

namespace studentadminportal.Api.Models.Dto
{
    public class ResponseCourseDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public List<student> students { get; set; }
    }
}
