using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository _StudentRepository { get; }
        ITeacherRepository _TeacherRepository { get; }
        ICoursesRepository _CoursesRepository { get; }
        ITeacherCoursesRepository _TeacherCoursesRepository { get; }
        IStudentsCoursesRepository _StudentsCoursesRepository { get; }
        int Complete();
    }
}
