using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Domain;
using SchoolApplication.Domain.Model;
using SchoolApplication.ModelDTO;
using System.Net;
using System;
using System.Threading.Tasks;
using SchoolApplication.Services;

namespace SchoolApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet(nameof(getTeachers))]
        public async Task<IActionResult> getTeachers() => Ok(await _teacherService.getTeachers());
        [HttpGet(nameof(getTeacher))]
        public async Task<IActionResult> getTeacher(int id) => Ok(await _teacherService.getTeacher(id));

        [HttpPost(nameof(createTeacher))]
        public IActionResult createTeacher(Teachers teachers) => Ok(_teacherService.createTeacher(teachers));

        [HttpPut(nameof(updateTeacher))]
        public IActionResult updateTeacher(Teachers teachers) => Ok(_teacherService.updateTeacher(teachers));
        [HttpDelete(nameof(deleteTeacher))]
        public IActionResult deleteTeacher(Teachers teachers) => Ok(_teacherService.deleteTeacher(teachers));
    }
}
