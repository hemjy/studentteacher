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
    public class TeacherService: ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddTeacherAsync(NewTeacher model)
        {
            await _unitOfWork.Teacher.AddAsync(model.MapToTeacher());
            await _unitOfWork.SaveAsync();
        }

        public async Task<PagedList<TeacherToReturn>> GetTeachersAsync(int pageNumber, int pageSize)
        {
            var result = await _unitOfWork.Teacher.GetTeachersAsync( pageNumber, pageSize);
            return result;
        }
    }
}
