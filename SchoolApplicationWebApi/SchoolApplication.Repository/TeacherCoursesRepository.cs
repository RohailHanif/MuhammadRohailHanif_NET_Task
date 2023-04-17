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
    public class TeacherCoursesRepository : GenericRepository<TeacherCourses>, ITeacherCoursesRepository
    {
        public TeacherCoursesRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task Add(TeacherCourses entity)
        {
            await _context.TeacherCourses.AddAsync(entity);
        }

        public void Delete(TeacherCourses entity)
        {
            _context.TeacherCourses.Remove(entity);
        }

        public async Task<TeacherCourses> Get(int id)
        {
           // return await _context.TeacherCourses.FindAsync(id);
            return await _context.TeacherCourses.Include(x => x.Teachers).Include(x => x.Courses).Where(x=>x.ID==id).FirstOrDefaultAsync(); 
        }

        public async Task<IEnumerable<TeacherCourses>> GetAll()
        {
            return await _context.TeacherCourses.Include(x => x.Teachers).Include(x => x.Courses).ToListAsync();
         }

        public void Update(TeacherCourses entity)
        {
            _context.TeacherCourses.Update(entity);
        }
    }
}
