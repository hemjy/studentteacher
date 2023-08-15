using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Extensions;
using StudentTeacher.Core.Interfaces.Core;
using StudentTeacher.Core.Interfaces.Infrastructure;
using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddStudentAsync(NewStudent model)
        {
            await  _unitOfWork.Student.AddAsync(model.MapToStudent());
            await _unitOfWork.SaveAsync();
        }

        public async Task<PagedList<StudentToReturn>> GetStudentsAsync(int pageNumber, int pageSize)
        {
            var result = await _unitOfWork.Student.GetStudentsAsync(pageNumber, pageSize);
            return result;
        }
    }
}
