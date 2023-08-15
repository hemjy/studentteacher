using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Entities;
using StudentTeacher.Core.Interfaces.Infrastructure;
using StudentTeacher.Core.Models;
using StudentTeacher.Infrastructure.Data.Context;

namespace StudentTeacher.Infrastructure.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(StudentTeacherContext context) : base(context)
        {
        }

        public async Task<PagedList<TeacherToReturn>> GetTeachersAsync(int pageNumber, int pageSize)
        {

            var query = _context.Teachers
                .Where(s => !s.IsDeprecated);
            // total count of teachers
            var count = await query.CountAsync();

            // map Teacher to TeacherToReturn
            var teachers = await query
                .Select(t => new TeacherToReturn
                {
                    Id = t.Id,
                    Name = t.Name,
                    Surname = t.Surname,
                    NationalIdNumber = t.NationalIdNumber,
                    DateOfBirth = t.DateOfBirth,
                    Salary = t.Salary,
                    TeacherNumber = t.TeacherNumber,
                    Title = t.Title
                }).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return new PagedList<TeacherToReturn>(teachers, count, pageNumber, pageSize);
        }
    }
}
