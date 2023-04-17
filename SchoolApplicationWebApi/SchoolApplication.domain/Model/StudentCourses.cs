using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Domain.Model
{
    public class StudentCourses : BaseModel
    {
        [Key]
        public int ID { get; set; }
        public Courses Courses { get; set; }
        public Students Students { get; set; }
    }
}

