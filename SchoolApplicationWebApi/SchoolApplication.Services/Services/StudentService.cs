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
   
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BaseResponse createStudent(Students students)
        {
            try
            {
                var response = _unitOfWork._StudentRepository.Add(students);
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

        public BaseResponse deleteStudent(Students students)
        {
            try
            {
                _unitOfWork._StudentRepository.Delete(students);
                var response = _unitOfWork.Complete();
                if (response == 0)
                {
                    throw new Exception("Student deleted unsuccessfully!");
                }
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = "Student deleted successfully.",
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

        public async Task<BaseResponse> getStudent(int id)
        {
            try
            {
                var response = await _unitOfWork._StudentRepository.Get(id);
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

        public async Task<BaseResponse> getStudents()
        {
            try
            {
                var response = await _unitOfWork._StudentRepository.GetAll();
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

        public BaseResponse updateStudent(Students students)
        {
            try
            {
                _unitOfWork._StudentRepository.Update(students);
                var response = _unitOfWork.Complete();
                if (response == 0)
                {
                    throw new Exception("Student update unsuccessfully!");
                }
                return new BaseResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = "Student update successfully.",
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
