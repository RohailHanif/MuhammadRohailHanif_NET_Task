using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Models
{
    public class Students :BaseModel
    {
        [Key]
        public int Studentid { get; set; }
        [MaxLength(50)]
        [Required]
        public string StudentName { get; set; }
        [MaxLength(50)]
        [Required]
        public string FatherName { get; set; }
        [MaxLength(10)]
        public string RollNo { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
 
    }
}
