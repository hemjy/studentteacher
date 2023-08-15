using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Entities
{
    public class Teacher: User
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string TeacherNumber { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Salary { get; set; }
    }
}
