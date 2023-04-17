using SchoolApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository _StudentRepository { get; }
        public ITeacherRepository _TeacherRepository { get; }
        public ICoursesRepository _CoursesRepository { get; }
        public ITeacherCoursesRepository _TeacherCoursesRepository { get; }
        public IStudentsCoursesRepository _StudentsCoursesRepository { get; }

        public UnitOfWork(ApplicationDbContext SchoolApplicationDbContext,
            IStudentRepository StudentsRepository,
            ITeacherRepository TeacherRepository,
            ICoursesRepository CoursesRepository,
             IStudentsCoursesRepository StudentsCoursesRepository,
            ITeacherCoursesRepository TeacherCoursesRepository
            )
        {
            this._context = SchoolApplicationDbContext;
            this._StudentRepository = StudentsRepository;
            this._TeacherRepository = TeacherRepository;
            this._CoursesRepository = CoursesRepository;
            this._TeacherCoursesRepository = TeacherCoursesRepository;
            this._StudentsCoursesRepository = StudentsCoursesRepository;
         }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
