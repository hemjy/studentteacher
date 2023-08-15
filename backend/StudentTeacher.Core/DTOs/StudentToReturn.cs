using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.DTOs
{
    public class StudentToReturn
    {
        public Guid Id { get; set; }
        public string NationalIdNumber { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentNumber { get; set; }
    }
}
