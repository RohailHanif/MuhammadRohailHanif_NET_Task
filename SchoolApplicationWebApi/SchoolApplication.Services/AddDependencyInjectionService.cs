using Microsoft.Extensions.DependencyInjection;
using SchoolApplication.Services.Interface;
using SchoolApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
   
namespace SchoolApplication.Services
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddDIService(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ITeacherCourseService, TeacherCourseService>();
            services.AddTransient<IStudentCourseService, StudentCourseService>();
            return services;
        }
    }
}
