using Microsoft.EntityFrameworkCore;
using SchoolApplication.Domain;
using SchoolApplication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Repository
{
    public class CoursesRepository : GenericRepository<Courses> ,ICoursesRepository
    {
        public CoursesRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task Add(Courses entity)
        {
           await _context.Courses.AddAsync(entity);
           
        }

        public void Delete(Courses entity)
        {
            _context.Courses.Remove(entity);
        }

        public async Task<Courses> Get(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<IEnumerable<Courses>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public void Update(Courses entity)
        {
            _context.Courses.Update(entity);
        }
    }
}
