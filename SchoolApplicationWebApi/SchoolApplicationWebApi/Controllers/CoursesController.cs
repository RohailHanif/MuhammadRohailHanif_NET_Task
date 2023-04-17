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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _CourseService;
        public CoursesController(ICourseService courseService)
        {
            _CourseService = courseService;
        }
        [HttpGet(nameof(getCourses))]
        public async Task<IActionResult> getCourses() => Ok(await _CourseService.getCourses());
        [HttpGet(nameof(getCourse))]
        public async Task<IActionResult> getCourse(int id) => Ok(await _CourseService.getCourse(id));

        [HttpPost(nameof(createCourse))]
        public IActionResult createCourse(Courses courses) => Ok(_CourseService.createCourse(courses));
        
        [HttpPut(nameof(updateCourse))]
        public IActionResult updateCourse(Courses courses) => Ok(_CourseService.updateCourse(courses));
        [HttpDelete(nameof(deleteCourse))]
        public IActionResult deleteCourse(Courses courses) => Ok(_CourseService.deleteCourse(courses));
    }
}
