using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Domain;
using SchoolApplication.Domain.Model;
using SchoolApplication.Services.Interface;
using System.Threading.Tasks;

namespace SchoolApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet(nameof(getStudents))]
        public async Task<IActionResult> getStudents() => Ok(await _studentService.getStudents());
        [HttpGet(nameof(getStudent))]
        public async Task<IActionResult> getStudent(int id) => Ok(await _studentService.getStudent(id));

        [HttpPost(nameof(createStudent))]
        public IActionResult createStudent(Students students) => Ok(_studentService.createStudent(students));

        [HttpPut(nameof(updateStudent))]
        public IActionResult updateStudent(Students students) => Ok(_studentService.updateStudent(students));
    }
}
