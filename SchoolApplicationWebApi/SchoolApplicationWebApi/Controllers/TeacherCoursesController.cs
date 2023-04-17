using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Domain;
using SchoolApplication.Domain.Model;
using SchoolApplication.ModelDTO;
using System;
using System.Net;
using System.Threading.Tasks;
using SchoolApplication.Services;
namespace SchoolApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherCoursesController : ControllerBase
    {
        private readonly ITeacherCourseService _teacherCourseService;
        public TeacherCoursesController(ITeacherCourseService teacherCourseService)
        {
            _teacherCourseService = teacherCourseService;
        }
        [HttpGet(nameof(getTeacherCourses))]
        public async Task<IActionResult> getTeacherCourses() => Ok(await _teacherCourseService.getTeacherCourses());
        [HttpGet(nameof(getTeacherCourse))]
        public async Task<IActionResult> getTeacherCourse(int id) => Ok(await _teacherCourseService.getTeacherCourse(id));

        [HttpPost(nameof(createTeacherCourses))]
        public IActionResult createTeacherCourses(TeacherCourses teacherCourses) => Ok(_teacherCourseService.createTeacherCourse(teacherCourses));
        
        [HttpPut(nameof(updateTeacherCourses))]
        public IActionResult updateTeacherCourses(TeacherCourses teacherCourses) => Ok(_teacherCourseService.updateTeacherCourse(teacherCourses));
        [HttpDelete(nameof(deleteTeacherCourse))]
        public IActionResult deleteTeacherCourse(TeacherCourses teacherCourses) => Ok(_teacherCourseService.deleteTeacherCourse(teacherCourses));
    }
}
