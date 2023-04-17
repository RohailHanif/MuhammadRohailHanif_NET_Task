using SchoolApplication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
   
    public interface ITeacherService
    {
        BaseResponse createTeacher(Teachers teachers);
        BaseResponse updateTeacher(Teachers teacher);
        BaseResponse deleteTeacher(Teachers teacher);
        Task<BaseResponse> getTeachers();
        Task<BaseResponse> getTeacher(int id);
    }
}
