using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Extensions
{
    public static class TeacherExtension
    {
        public static Teacher MapToTeacher(this NewTeacher newTeacher)
        {
            return new Teacher
            {
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Id = Guid.NewGuid(),
                Name = newTeacher.Name,
                TeacherNumber = newTeacher.TeacherNumber,
                Surname = newTeacher.Surname,
                DateOfBirth = newTeacher.DateOfBirth,
                NationalIdNumber = newTeacher.NationalIdNumber,
                Title = newTeacher.Title,
            };
        }
    }
}
