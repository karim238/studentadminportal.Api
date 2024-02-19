using Microsoft.EntityFrameworkCore;
using studentadminportal.Api.Data;
using studentadminportal.Api.Models.Domain;
using studentadminportal.Api.Repositorys.Interface;

namespace studentadminportal.Api.Repositorys.Implemintation
{
    public class CourseRepositry:ICourseRepositry

    {
        private readonly StudentAdminDbContext context;
        public CourseRepositry(StudentAdminDbContext context)
        {
            this.context = context;
        }

        public async Task<Course> AddCourse(Course course)
        {
            await context.AddAsync(course);
            await context.SaveChangesAsync();
            return course;
        }

        

        public async Task<IEnumerable<Course?>> GetAllname()
        {
            return await context.Course.ToListAsync();
        }

        public async Task<Course> GetCourseByid(Guid id)
        {
            return await context.Course.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
