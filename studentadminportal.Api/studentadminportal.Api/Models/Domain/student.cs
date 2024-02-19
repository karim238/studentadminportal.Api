using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace studentadminportal.Api.Models.Domain
{
    public class student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float GPA { get; set; }
        public string Faculty { get; set; }
        public string Year { get; set; }
        // navigation properties
        public List<Course> Courses { get; set; }


    }
}
