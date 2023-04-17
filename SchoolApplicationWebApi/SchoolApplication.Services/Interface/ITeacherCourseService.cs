 using SchoolApplication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
   
    public interface ITeacherCourseService
    {
        BaseResponse createTeacherCourse(TeacherCourses teacherCourses);
        BaseResponse updateTeacherCourse(TeacherCourses teacherCourses);
        BaseResponse deleteTeacherCourse(TeacherCourses teacherCourses);
        Task<BaseResponse> getTeacherCourses();
        Task<BaseResponse> getTeacherCourse(int id);
    }
}
