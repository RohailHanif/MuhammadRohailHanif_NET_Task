using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Domain.Model
{
    public class TeacherCourses : BaseModel
    {
        
        [Key]
        public int ID { get; set; }
        public Courses Courses { get; set; }
        public Teachers Teachers { get; set; }
    }
}

