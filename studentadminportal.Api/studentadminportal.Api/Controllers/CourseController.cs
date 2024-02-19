using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal.Api.Models.Domain;
using studentadminportal.Api.Models.Dto;
using studentadminportal.Api.Repositorys.Interface;

namespace studentadminportal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepositry repositry;
        private readonly IStudentRepositry student;

        public CourseController(ICourseRepositry repositry,IStudentRepositry student)
        {
            this.repositry = repositry;
            this.student = student;
        }
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody]RequestCourseDto request)
        {
            var data = new Course
            {
                Code = request.Code,
                students = new List<student>()
            };
            foreach(var students in request.students)
            {
                var stu=await student.getbyid(students);
                if (stu != null)
                {
                    data.students.Add(stu);
                }
            }
             var course=await repositry.AddCourse(data);
            var response = new ResponseCourseDto
            {
                Id = course.Id,
                Code = course.Code,
                students = course.students.Select(s => new student
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Faculty = s.Faculty,
                }).ToList()
            };
            return Ok(response);

        }
        [HttpGet]
        public async Task<IActionResult> getallcode()
        {
            var my_list=new List<ViewCourse>();
            var response= await repositry.GetAllname();
            foreach(var item in response)
            {
                var data = new ViewCourse
                {
                    Id = item.Id,
                    Code = item.Code,
                };
                my_list.Add(data);
            }
            return Ok(my_list);

        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await repositry.GetCourseByid(id);
            if(response == null)
            {
                return NotFound();
            }
            else
            {
                var data = new ViewCourse { Code = response.Code };
                return Ok(data);
            }
            
        }
        
        
    }
}
