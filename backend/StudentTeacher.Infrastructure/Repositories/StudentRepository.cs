using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Entities;
using StudentTeacher.Core.Interfaces.Infrastructure;
using StudentTeacher.Core.Models;
using StudentTeacher.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentTeacherContext context) : base(context)
        {
        }

        public async Task<PagedList<StudentToReturn>> GetStudentsAsync(int pageNumber, int pageSize)
        {

            var query = _context.Students
                .Where(s => !s.IsDeprecated);
            // total count of students
            var count = await query.CountAsync();

            // map student to studentToReturn 
            var students = await query
                .Select(s => new StudentToReturn
                {
                    Id = s.Id,
                    Name = s.Name,
                    Surname = s.Surname,
                    NationalIdNumber = s.NationalIdNumber,
                    DateOfBirth = s.DateOfBirth,
                    StudentNumber = s.StudentNumber
                }).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return new PagedList<StudentToReturn>(students, count, pageNumber, pageSize);
        }
    }
}
