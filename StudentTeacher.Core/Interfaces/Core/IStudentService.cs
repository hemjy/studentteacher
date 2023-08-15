using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Interfaces.Core
{
    public interface IStudentService
    {
        Task<PagedList<StudentToReturn>> GetStudentsAsync(int pageNumber, int pageSize);
        Task AddStudentAsync(NewStudent model);
    }
}
