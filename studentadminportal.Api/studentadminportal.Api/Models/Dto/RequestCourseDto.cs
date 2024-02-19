using studentadminportal.Api.Models.Domain;

namespace studentadminportal.Api.Models.Dto
{
    public class RequestCourseDto
    {
        public string Code { get; set; }
        public Guid[] students { get; set; }
    }
}
