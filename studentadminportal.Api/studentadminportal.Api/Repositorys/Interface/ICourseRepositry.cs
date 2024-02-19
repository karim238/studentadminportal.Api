using studentadminportal.Api.Models.Domain;

namespace studentadminportal.Api.Repositorys.Interface
{
    public interface ICourseRepositry
    {
        public  Task<Course> AddCourse(Course course);
        public Task<IEnumerable<Course?>> GetAllname();
        public Task<Course> GetCourseByid(Guid id);
    }
}
