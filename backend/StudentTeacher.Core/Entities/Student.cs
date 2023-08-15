using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Entities
{
    public class Student : User
    {
        [Required]
        public string StudentNumber { get; set; }
    }
}
