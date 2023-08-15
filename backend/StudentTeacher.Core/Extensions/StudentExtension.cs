using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Extensions
{
    public static class StudentExtension
    {
        public static Student MapToStudent(this NewStudent newStudent)
        {
            return new Student
            {
               Created = DateTime.Now,
               Modified = DateTime.Now,
               Id = Guid.NewGuid(),
               Name = newStudent.Name,
               StudentNumber = newStudent.StudentNumber,
               Surname = newStudent.Surname,
               DateOfBirth = newStudent.DateOfBirth,
               NationalIdNumber = newStudent.NationalIdNumber,
            };
        }
    }
}
