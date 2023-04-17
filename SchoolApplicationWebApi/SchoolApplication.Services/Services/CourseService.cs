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
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseResponse createCourse(Courses courses)
        {
            try
            {
              var response =  _unitOfWork._CoursesRepository.Add(courses);
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
        public  BaseResponse deleteCourse(Courses courses)
        {
            try
            {
                 _unitOfWork._CoursesRepository.Delete(courses);
               var response=  _unitOfWork.Complete();
                if (response==0)
                {
                    throw new Exception("Course deleted unsuccessfully!");
                }
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = "Course deleted successfully.",
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
        public async Task<BaseResponse> getCourses()
        {
            try
            {
                var response = await _unitOfWork._CoursesRepository.GetAll();
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
        public async Task<BaseResponse> getCourse(int id)
        {
            try
            {
                var response = await _unitOfWork._CoursesRepository.Get(id);
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
        public BaseResponse updateCourse(Courses courses)
        {
            try
            {
                _unitOfWork._CoursesRepository.Update(courses);
                var response= _unitOfWork.Complete();
                if (response == 0)
                {
                    throw new Exception("Course update unsuccessfully!");
                }
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = "Course update successfully.",
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
