using SchoolApplication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Services.Interface
{
   
    public interface IStudentService
    {
        BaseResponse createStudent(Students students);
        BaseResponse updateStudent(Students students);
        BaseResponse deleteStudent(Students students);
        Task<BaseResponse> getStudents();
        Task<BaseResponse> getStudent(int id);
    }
}
