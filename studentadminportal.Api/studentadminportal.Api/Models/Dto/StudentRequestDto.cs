namespace studentadminportal.Api.Models.Dto
{
    public class StudentRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float GPA { get; set; }
        public string Faculty { get; set; }
        public string Year { get; set; }
        public Guid[] idcources {  get; set; } 
    }
}
