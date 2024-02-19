using studentadminportal.Api.Models.Domain;

namespace studentadminportal.Api.Repositorys.Interface
{
    public interface IStudentRepositry
    {
        public Task<student> CreateStudent(student student);
        public Task<IEnumerable<student?>> GetAllStudent();
        public Task<student?> getbyid(Guid id);
        public Task<student?> Update(student student);
        public Task<student?> Delete(Guid id);
    }
}
