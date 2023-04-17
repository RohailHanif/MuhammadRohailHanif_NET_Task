using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Models
{
    public class StudentCourses : BaseModel
    {
        [Key]
        public int StudentCoursesID { get; set; }
        [Required]
        public ICollection<Courses> Courses { get; set; }
        [Required]
        public ICollection<Students> Students { get; set; }
    }
}

