using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Domain;
using SchoolApplication.Domain.Model;
using SchoolApplication.ModelDTO;
using System;
using System.Net;
using System.Threading.Tasks;
using SchoolApplication.Services;
using SchoolApplication.Services.Interface;

namespace SchoolApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly IStudentCourseService _StudentCourseService;
        public StudentCoursesController(IStudentCourseService studentCourseService)
        {
            _StudentCourseService = studentCourseService;
        }
        [HttpGet(nameof(getStudentCourses))]
        public async Task<IActionResult> getStudentCourses() => Ok(await _StudentCourseService.getStudentCourses());
        [HttpGet(nameof(getStudentCourse))]
        public async Task<IActionResult> getStudentCourse(int id) => Ok(await _StudentCourseService.getStudentCourse(id));

        [HttpPost(nameof(createStudentCourse))]
        public IActionResult createStudentCourse(StudentCourses studentCourses) => Ok(_StudentCourseService.createStudentCourse(studentCourses));
        [HttpPut(nameof(updateStudentCourse))]
        public IActionResult updateStudentCourse(StudentCourses studentCourses) => Ok(_StudentCourseService.updateStudentCourse(studentCourses));
        [HttpDelete(nameof(deleteStudentCourse))]
        public IActionResult deleteStudentCourse(StudentCourses studentCourses) => Ok(_StudentCourseService.deleteStudentCourse(studentCourses));
    }
}
