using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Domain.Model;

namespace SchoolApplication.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<TeacherCourses> TeacherCourses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

    }
     
}
