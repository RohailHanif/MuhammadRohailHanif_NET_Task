using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Domain.Model
{
    public class Teachers :BaseModel
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        [Required]
        public string TeacherName { get; set; }
        [MaxLength(50)]
        [Required]
        public string TeacherFatherName { get; set; }
         [Required]
        public DateTime DateofBirth { get; set; }
        [MaxLength(20)]
        [Required]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        [Required]
        public string Mobile { get; set; }
    }
}
