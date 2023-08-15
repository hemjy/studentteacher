using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.DTOs
{
    public class TeacherToReturn
    {
        public Guid Id { get; set; }
        public string NationalIdNumber { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public string Title { get; set; }
        public string TeacherNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
