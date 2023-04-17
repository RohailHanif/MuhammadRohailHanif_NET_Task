using SchoolApplication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Services.Interface
{
   
    public interface IStudentCourseService
    {
        BaseResponse createStudentCourse(StudentCourses studentCourses);
        BaseResponse updateStudentCourse(StudentCourses studentCourses);
        BaseResponse deleteStudentCourse(StudentCourses studentCourses);
        Task<BaseResponse> getStudentCourses();
        Task<BaseResponse> getStudentCourse(int id);
    }
}
