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
    public class StudentRepository :GenericRepository<Students>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task Add(Students entity)
        {
             await _context.Students.AddAsync(entity);
        }

        public void Delete(Students entity)
        {
             _context.Students.Remove(entity);
        }

        public async Task<Students> Get(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Students>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public void Update(Students entity)
        {
            _context.Students.Update(entity);
        }
    }
}
