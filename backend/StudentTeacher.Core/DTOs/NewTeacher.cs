using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentTeacher.ValidationFilters;

namespace StudentTeacher.Core.DTOs
{
    public class NewTeacher
    {
        [Required]
        [WordRange("Mr", "Mrs", "Miss","Dr", "Prof", CustomErrorMessage = "Title can be either [Mr, Mrs, Miss, Dr, Prof]")]
        public string Title { get; set; }
        [Required]
        public string TeacherNumber { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Salary { get; set; }
        [Required]
        public string NationalIdNumber { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
