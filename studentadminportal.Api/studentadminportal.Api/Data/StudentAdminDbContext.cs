using Microsoft.EntityFrameworkCore;
using studentadminportal.Api.Models.Domain;

namespace studentadminportal.Api.Data
{
    public class StudentAdminDbContext : DbContext
    {
        public StudentAdminDbContext(DbContextOptions<StudentAdminDbContext> options) : base(options)
        {
        }
        public DbSet<student> Student { get; set; }
        public DbSet<Course> Course { get; set; }

        
    }
}
