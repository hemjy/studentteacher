using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Entities;
using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Interfaces.Infrastructure
{
    public interface ITeacherRepository: IGenericRepository<Teacher>
    {
        Task<PagedList<TeacherToReturn>> GetTeachersAsync(int pageNumber, int pageSize);
    }
}
