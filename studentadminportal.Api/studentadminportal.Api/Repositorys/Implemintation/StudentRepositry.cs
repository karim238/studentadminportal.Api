using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using studentadminportal.Api.Data;
using studentadminportal.Api.Models.Domain;
using studentadminportal.Api.Repositorys.Interface;

namespace studentadminportal.Api.Repositorys.Implemintation
{
    public class StudentRepositry : IStudentRepositry
    {
        private readonly StudentAdminDbContext context;

        public StudentRepositry(StudentAdminDbContext context)
        {
            this.context = context;
        }
        public async Task<student> CreateStudent(student student)
        {
            await context.AddAsync(student);
            await context.SaveChangesAsync();
            return student;
        }

        public async Task<student?> Delete(Guid id)
        {
            var exciting = await context.Student.FirstOrDefaultAsync(x => x.Id == id);
            if (exciting != null)
            {
                 context.Student.Remove(exciting);
                await context.SaveChangesAsync();
                return exciting;

            }
            return null;
        }

        public async Task<IEnumerable<student?>> GetAllStudent()
        {
            return  await context.Student.Include(x=>x.Courses).ToListAsync();
        }

        public async  Task<student?> getbyid(Guid id)
        {
            return await context.Student.Include(x=>x.Courses).FirstOrDefaultAsync(y => y.Id == id);
        }

        public async Task<student?> Update(student student)
        {
            var exciting = await context.Student.FirstOrDefaultAsync(x => x.Id == student.Id);
            if (exciting == null)
            {
                return null;
            }
            else
            {
                context.Entry(exciting).CurrentValues.SetValues(student);
            }
            await context.SaveChangesAsync();
            return student;
        }
    }
}
