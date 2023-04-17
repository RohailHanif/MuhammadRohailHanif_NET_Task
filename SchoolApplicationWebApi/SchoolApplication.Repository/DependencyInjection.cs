using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolApplication.Domain;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Repositorys;

namespace SchoolApplication.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddTransient<IStudentsCoursesRepository, StudentsCoursesRepository>();
            services.AddTransient<ITeacherCoursesRepository, TeacherCoursesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<ApplicationDbContext>(opt => opt
                .UseSqlServer("Server=DESKTOP-7GTDR5V\\SQLEXPRESS; Database=SchoolApplicationDB;Trusted_Connection=True;"));
            return services;
        }
    }
}
