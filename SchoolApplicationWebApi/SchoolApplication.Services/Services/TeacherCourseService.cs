using SchoolApplication.Domain;
using SchoolApplication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
    public class TeacherCourseService : ITeacherCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherCourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseResponse createTeacherCourse(TeacherCourses teacherCourses)
        {
            try
            {
                var response = _unitOfWork._TeacherCoursesRepository.Add(teacherCourses);
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

        public BaseResponse deleteTeacherCourse(TeacherCourses teacherCourses)
        {
            try
            {
                _unitOfWork._TeacherCoursesRepository.Delete(teacherCourses);
                var response = _unitOfWork.Complete();
                if (response == 0)
                {
                    throw new Exception("Data deleted unsuccessfully!");
                }
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = "Data deleted successfully.",
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

        public async Task<BaseResponse> getTeacherCourses()
        {
            try
            {
                var response = await _unitOfWork._TeacherCoursesRepository.GetAll();
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

        public async Task<BaseResponse> getTeacherCourse(int id)
        {
            try
            {
                var response = await _unitOfWork._TeacherCoursesRepository.Get(id);
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

        public BaseResponse updateTeacherCourse(TeacherCourses teacherCourses)
        {
            try
            {
                _unitOfWork._TeacherCoursesRepository.Update(teacherCourses);
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
