using Microsoft.EntityFrameworkCore;
using SchoolApplication.Domain;
using SchoolApplication.Domain.Model;
using SchoolApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Repositorys
{
    public class TeacherRepository : GenericRepository<Teachers>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task Add(Teachers entity)
        {
            await _context.Teachers.AddAsync(entity);
        }

        public void Delete(Teachers entity)
        {
            _context.Teachers.Remove(entity);
        }

        public async Task<Teachers> Get(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public async Task<IEnumerable<Teachers>> GetAll()
        {
            return await _context.Teachers.ToListAsync();
        }

        public void Update(Teachers entity)
        {
            _context.Teachers.Update(entity);
        }
    }
}
