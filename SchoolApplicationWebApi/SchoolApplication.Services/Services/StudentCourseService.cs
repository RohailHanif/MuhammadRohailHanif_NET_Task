using SchoolApplication.Domain;
using SchoolApplication.Domain.Model;
using SchoolApplication.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentCourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseResponse createStudentCourse(StudentCourses studentCourses)
        {
            try
            {
                var response = _unitOfWork._StudentsCoursesRepository.Add(studentCourses);
                _unitOfWork.Complete();
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = response,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Data = null,
                    Errors = ex.Message
                };
            }
        }

        public BaseResponse deleteStudentCourse(StudentCourses studentCourses)
        {
            try
            {
                _unitOfWork._StudentsCoursesRepository.Delete(studentCourses);
                var response = _unitOfWork.Complete();
                if (response == 0)
                {
                    throw new Exception("Deleted unsuccessfully!");
                }
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = "Deleted successfully.",
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Data = null,
                    Errors = ex.Message
                };
            }
        }

        public async Task<BaseResponse> getStudentCourses()
        {
            try
            {
                var response = await _unitOfWork._StudentsCoursesRepository.GetAll();
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = response,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Data = null,
                    Errors = ex.Message
                };
            }
        }

        public async Task<BaseResponse> getStudentCourse(int id)
        {
            try
            {
                var response = await _unitOfWork._StudentsCoursesRepository.Get(id);
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = response,
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Data = null,
                    Errors = ex.Message
                };
            }
        }

        public BaseResponse updateStudentCourse(StudentCourses studentCourses)
        {
            try
            {
                _unitOfWork._StudentsCoursesRepository.Update(studentCourses);
                var response = _unitOfWork.Complete();
                if (response == 0)
                {
                    throw new Exception("Data update unsuccessfully!");
                }
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = "Data update successfully.",
                    Errors = null
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Data = null,
                    Errors = ex.Message
                };
            }
        }
    }
}
