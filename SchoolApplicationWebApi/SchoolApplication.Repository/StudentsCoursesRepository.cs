using SchoolApplication.Domain.Model;
using SchoolApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolApplication.Repository
{
    public class StudentsCoursesRepository : GenericRepository<StudentCourses>, IStudentsCoursesRepository
    {
        public StudentsCoursesRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task Add(StudentCourses entity)
        {
            await _context.StudentCourses.AddAsync(entity);
        }

        public void Delete(StudentCourses entity)
        {
            _context.StudentCourses.Remove(entity);
        }

        public async Task<StudentCourses> Get(int id)
        {
            // return await _context.TeacherCourses.FindAsync(id);
            return await _context.StudentCourses.Include(x => x.Students).Include(x => x.Courses).Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StudentCourses>> GetAll()
        {
            return await _context.StudentCourses.Include(x => x.Students).Include(x => x.Courses).ToListAsync();
        }

        public void Update(StudentCourses entity)
        {
            _context.StudentCourses.Update(entity);
        }
    }
}
