using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Models
{
    public class TeacherCourses : BaseModel
    {
        [Key]
        public int TeacherCoursesID { get; set; }
        [Required]
        public ICollection<Courses> Courses { get; set; }
        [Required]
        public ICollection<Teachers> Teachers { get; set; }
    }
}

