using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Domain.Model
{
    public class Courses :BaseModel
    {
       
        [Key]
        public int ID { get; set; }
        [MaxLength(30)]
        [Required]
        public string CourseTitle { get; set; }
        [MaxLength(200)]
        [Required]
        public string Description { get; set; }
       

    }
}
