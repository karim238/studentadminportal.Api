namespace studentadminportal.Api.Models.Domain
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public List<student> students { get; set; }
    }
}
