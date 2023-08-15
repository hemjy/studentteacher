using StudentTeacher.Core.Interfaces.Infrastructure;
using StudentTeacher.Infrastructure.Data.Context;
using StudentTeacher.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentTeacherContext _context;
        private Lazy<IStudentRepository> _student;
        private Lazy<ITeacherRepository> _teacher;
        public UnitOfWork(StudentTeacherContext context)
        {
            _context = context;
            _student = new Lazy<IStudentRepository>(() => new StudentRepository(context));
            _teacher = new Lazy<ITeacherRepository>(() => new TeacherRepository(context));
        }

        public IStudentRepository Student => _student.Value;
        public ITeacherRepository Teacher => _teacher.Value;
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
