using SchoolApplication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
   
    public interface ICourseService
    {
        BaseResponse createCourse(Courses courses);
        BaseResponse updateCourse(Courses courses);
        BaseResponse deleteCourse(Courses courses);
        Task<BaseResponse> getCourses();
        Task<BaseResponse> getCourse(int id);
    }
}
