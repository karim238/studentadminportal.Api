using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal.Api.Models.Domain;
using studentadminportal.Api.Models.Dto;
using studentadminportal.Api.Repositorys.Interface;
using System.Diagnostics;

namespace studentadminportal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepositry repositry;
        private readonly ICourseRepositry courseRepositry;

        public StudentController(IStudentRepositry repositry,ICourseRepositry courseRepositry)
        {
            this.repositry = repositry;
            this.courseRepositry = courseRepositry;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]StudentRequestDto request)
        {
            var student = new student
            {

                Faculty = request.Faculty,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                GPA = request.GPA,
                Year = request.Year,
                Courses = new List<Course>()
            };
            foreach(var item in request.idcources)
            {
                var courses = await courseRepositry.GetCourseByid(item);
                if(courses != null)
                {
                    student.Courses.Add(courses);
                }
                
            }
           
            var data = await repositry.CreateStudent(student);
            var response = new ResponseStudentDto
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Faculty = data.Faculty,
                GPA = data.GPA,
                Year = data.Year,
                Courses=data.Courses.Select(x=> new ViewCourse
                {
                    Code=x.Code,
                }).ToList()
            };
            return Ok(response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var my_list=new List<ResponseStudentDto>();
            var response = await repositry.GetAllStudent();
            foreach(var item in response)
            {
                var add = new ResponseStudentDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Faculty = item.Faculty,
                    GPA = item.GPA,
                    Year = item.Year,
                    Courses=item.Courses.Select(x=> new ViewCourse {Id=x.Id, Code=x.Code}).ToList()
                };
                my_list.Add(add);
            }
            return Ok(my_list);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Getid([FromRoute] Guid id)
        {
            var response =await repositry.getbyid(id);
            if(response == null)
            {
                return NotFound("Student Not Found");
            }

            var data = new ResponseStudentDto
            {
                Id = response.Id,
                FirstName = response.FirstName,
                LastName = response.LastName,
                Email = response.Email,
                Faculty = response.Faculty,
                GPA = response.GPA,
                Year = response.Year,
                Courses = response.Courses.Select(x => new ViewCourse
                {
                    Code = x.Code,
                    Id = x.Id,
                }).ToList()

                };
                return Ok(data);
            }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute ]Guid id,[FromBody]StudentRequestDto student)
        {
            var request = new student
            {
                Email = student.Email,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Faculty=student.Faculty,
                GPA=student.GPA,
                Year = student.Year,
                Id = id
            };
            var data = await repositry.Update(request);
            if(data == null)
            {
                return NotFound("Student Not Found");
            }
            else
            {
                var response = new ResponseStudentDto
                {
                    Id = data.Id,

                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    Faculty = data.Faculty,
                    GPA = data.GPA,
                    Year = data.Year
                };
                return Ok(response);
            }
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var data =await repositry.Delete(id);
            if(data == null)
            {
                return NotFound();
            }
            else
            {
                var response = new ResponseStudentDto
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    Faculty = data.Faculty,
                    GPA = data.GPA,
                    Year = data.Year
                };
                return Ok(response);
            }
        }
        }
    }
    
