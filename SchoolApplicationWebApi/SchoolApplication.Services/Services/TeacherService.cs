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
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseResponse createTeacher(Teachers teachers)
        {
            try
            {
                var response = _unitOfWork._TeacherRepository.Add(teachers);
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

        public BaseResponse deleteTeacher(Teachers teacher)
        {
            try
            {
                _unitOfWork._TeacherRepository.Delete(teacher);
                var response = _unitOfWork.Complete();
                if (response == 0)
                {
                    throw new Exception("Teacher deleted unsuccessfully!");
                }
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = "Teacher deleted successfully.",
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

        public async Task<BaseResponse> getTeachers()
        {
            try
            {
                var response = await _unitOfWork._TeacherRepository.GetAll();
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

        public async Task<BaseResponse> getTeacher(int id)
        {
            try
            {
                var response = await _unitOfWork._TeacherRepository.Get(id);
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

        public BaseResponse updateTeacher(Teachers teacher)
        {
            try
            {
                _unitOfWork._TeacherRepository.Update(teacher);
                var response = _unitOfWork.Complete();
                if (response == 0)
                {
                    throw new Exception("Teacher update unsuccessfully!");
                }
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = "Teacher update successfully.",
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
